using Infrastructure.Filters;
using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using static TTObjectClasses.SubEpisodeProtocol;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers.Invoice
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class InvoiceDiagnosisContextMenuApiController : Controller
    {
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void taniKayit(List<InvoiceSEPDiagnoseListModel> selectedDiagnosis)
        {
            try
            {
                List<Guid> ssList = new List<Guid>();
                foreach (var item in selectedDiagnosis)
                {
                    if (item.CurrentStateDefID == SEPDiagnosis.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == SEPDiagnosis.States.New)
                        ssList.Add(item.ObjectID);
                }

                string resultMessage = string.Empty;
                int maxHizmetSayisi = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULAHIZMETKAYITUSTLIMIT", "20"));
                if (ssList.Count > maxHizmetSayisi)
                {
                    throw new Exception("Hizmet kayıt sırasında tek seferde en fazla " + maxHizmetSayisi + " kayıt gönderilebilir! Toplu hizmet kaydını deneyiniz.");
                }
                else
                {
                    if (ssList.Count > 0)
                    {
                        TTObjectContext objectcontext = new TTObjectContext(false);
                        SEPDiagnosis sepDia = (SEPDiagnosis)objectcontext.GetObject(ssList[0], typeof (SEPDiagnosis));
                        MedulaResult medulaResult = sepDia.SubEpisodeProtocol.TaniHizmetKayitSync(ssList);
                        if (medulaResult != null)
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("taniKayit: "+ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void taniKayitIptal(InvoiceSEPHizmetKayitIptalModelDiagnosis Ishkimd)
        {
            try
            {
                List<string> ssList = new List<string>();
                ;
                List<Guid> accountTransactionIDs = new List<Guid>();
                foreach (var item in Ishkimd.DiagnoseList)
                {
                    if (item.CurrentStateDefID == SEPDiagnosis.States.MedulaEntrySuccessful && !string.IsNullOrEmpty(item.MedulaProcessNo))
                    {
                        ssList.Add(item.MedulaProcessNo.ToString());
                        accountTransactionIDs.Add(item.ObjectID);
                    }
                }

                string resultMessage = string.Empty;
                int maxHizmetSayisi = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULAHIZMETKAYITUSTLIMIT", "20"));
                if (ssList.Count > maxHizmetSayisi)
                {
                    throw new Exception("Hizmet kayıt sırasında tek seferde en fazla " + maxHizmetSayisi + " kayıt gönderilebilir! Toplu hizmet kaydını deneyiniz.");
                }
                else
                {
                    if (ssList.Count > 0)
                    {
                        TTObjectContext objectcontext = new TTObjectContext(false);
                        SubEpisodeProtocol sep = (SubEpisodeProtocol)objectcontext.GetObject(Ishkimd.SEPObjectID, typeof (SubEpisodeProtocol));
                        MedulaResult medulaResult = sep.HizmetKayitIptalSync(ssList, accountTransactionIDs, false);
                        if (medulaResult != null && medulaResult.SonucKodu != null)
                        {
                            if (!medulaResult.SonucKodu.Equals("0000"))
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(" taniKayitIptal " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void taniDurumGuncelle(List<InvoiceSEPDiagnoseListModel> selectedDiagnosis, bool state)
        {
            try
            {
                List<string> ssList = new List<string>();
                foreach (var item in selectedDiagnosis)
                { //TODO: AAE Faturalandı durumundaki SEP in tani durumu değiştirilmemesi lazım.
                    if (item.CurrentStateDefID == SEPDiagnosis.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == SEPDiagnosis.States.MedulaDontSend || item.CurrentStateDefID == SEPDiagnosis.States.New)
                        ssList.Add(item.ObjectID.ToString());
                }

                if (ssList.Count > 0)
                    Utils.UpdateDiagnosisState(ssList, state);
            }
            catch (Exception ex)
            {
                throw new Exception(" taniDurumGuncelle " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void addDiagnosis(Guid? sepObjectID, List<InvoiceSEPDiagnoseListModel> GridDiagnosisGridList)
        {
            if (GridDiagnosisGridList.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                SubEpisodeProtocol sep = (SubEpisodeProtocol)objectcontext.GetObject(sepObjectID.Value, typeof (SubEpisodeProtocol));
                if (sep.CurrentStateDefID == SubEpisodeProtocol.States.Open)
                {
                    if (!sep.IsInvoiced)
                    {
                        foreach (InvoiceSEPDiagnoseListModel item in GridDiagnosisGridList)
                        {
                            SEPDiagnosis sd = new SEPDiagnosis(objectcontext);
                            sd.SubEpisodeProtocol = sep;
                            sd.Diagnose = item.Diagnose;
                            sd.DiagnosisType = string.IsNullOrWhiteSpace(item.DiagnosisType) ? DiagnosisTypeEnum.Primer : (DiagnosisTypeEnum)Common.GetEnumValueDefOfEnumValueV2("DiagnosisTypeEnum", Int32.Parse(item.DiagnosisType)).EnumValue;
                            sd.IsMainDiagnose = item.IsMainDiagnose;
                            sd.CurrentStateDefID = SEPDiagnosis.States.New;
                            InvoiceLog.AddInfo("Yeni tanı eklendi. Kodu: " + item.Diagnose.Code + " Adı: " + item.Diagnose.Name, sepObjectID.Value, InvoiceOperationTypeEnum.AddNewDiagnosis, InvoiceLogObjectTypeEnum.SubEpisodeProtocol, objectcontext);
                        }
                    }

                    objectcontext.Save();
                }
            }
        }
    }
}