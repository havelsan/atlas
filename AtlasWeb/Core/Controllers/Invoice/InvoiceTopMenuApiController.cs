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
using TTUtils;
using TTVisual;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using Core.Security;

namespace Core.Controllers.Invoice
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class InvoiceTopMenuApiController : Controller
    {
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Medula_Takip_Alma)]
        public MedulaResult takipAl([FromQuery] Guid sepObjectID, [FromQuery] string bagliTakipNo = null)
        {
            MedulaResult result = new MedulaResult();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    SubEpisodeProtocol sep = objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                    result = sep.GetProvisionFromMedula(bagliTakipNo);
                    objectContext.Save();
                }
                catch (Exception ex)
                {
                    InvoiceLog.AddException(ex.Message + " - " + ex.StackTrace, sepObjectID, InvoiceOperationTypeEnum.TakipAl, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                    throw new TTException(TTUtils.CultureService.GetText("M26998", "Takip alınırken bir hata oluştu, lütfen logları kontrol ediniz."), ex);
                    //result.SEPObjectID = sepObjectID;
                    //result.SonucKodu = "0001";
                    //result.SonucMesaji = ex.Message + " - " + ex.StackTrace.ToString();
                    //result.Succes = false;
                }

                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Medula_Takip_Silme)]
        public MedulaResult takipSil([FromQuery] Guid sepObjectID)
        {
            MedulaResult result = new MedulaResult();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    SubEpisodeProtocol sep = objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                    result = sep.DeleteProvisionFromMedula();
                    objectContext.Save();
                    objectContext.FullPartialllyLoadedObjects();
                }
                catch (Exception ex)
                {
                    result.SEPObjectID = sepObjectID;
                    result.SonucKodu = "0001";
                    result.SonucMesaji = ex.Message + " - " + ex.StackTrace.ToString();
                    result.Succes = false;
                    InvoiceLog.AddException(ex.Message, sepObjectID, InvoiceOperationTypeEnum.TakipSil, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                }
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Medula_Takip_Silme)]
        public MedulaResult topluTakipSil([FromQuery] Guid sepObjectID)
        {
            MedulaResult result = new MedulaResult();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    SubEpisodeProtocol sep = objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                    result = sep.SEPMaster.deleteAllMedulaProvision();
                    objectContext.Save();
                    objectContext.FullPartialllyLoadedObjects();
                }
                catch (Exception ex)
                {
                    result.SEPObjectID = sepObjectID;
                    result.SonucKodu = "0001";
                    result.SonucMesaji = ex.Message + " - " + ex.StackTrace.ToString();
                    result.Succes = false;
                    InvoiceLog.AddException(ex.Message, sepObjectID, InvoiceOperationTypeEnum.TakipSil, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                }
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Medula_Takip_Silme)]
        public MedulaResult topluTakipAl([FromQuery] Guid sepObjectID)
        {
            MedulaResult result = new MedulaResult();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    SubEpisodeProtocol sep = objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                    result = sep.SEPMaster.getProvisionToAllSEP();
                    objectContext.Save();
                    objectContext.FullPartialllyLoadedObjects();
                }
                catch (Exception ex)
                {
                    result.SEPObjectID = sepObjectID;
                    result.SonucKodu = "0001";
                    result.SonucMesaji = ex.Message + " - " + ex.StackTrace.ToString();
                    result.Succes = false;
                    InvoiceLog.AddException(ex.Message, sepObjectID, InvoiceOperationTypeEnum.TakipSil, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                }
            }
            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Medula_Takip_Silme)]
        public MedulaResult takipSilConfirm([FromQuery] Guid sepObjectID)
        {
            MedulaResult result = new MedulaResult();
            using (var objectContext = new TTObjectContext(false))
            {
                SubEpisodeProtocol sep = objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                result = sep.ConfirmDeleteProvision();
            }

            return result;
        }


        //public class SendToENabiz700_Model
        //{
        //    public List<SendToENabiz700_InnerModel> sendList  {get;set;}
        //}

        public class SendToENabiz700_Model
        {
            public Guid sepObjectID { get; set; }
            public List<Guid> accTrxList { get; set; }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public List<MedulaResult> sendToENabiz700(List<SendToENabiz700_Model> sten)
        {
            List<MedulaResult> mr = new List<MedulaResult>();

            using (var objectContext = new TTObjectContext(false))
            {
                foreach (SendToENabiz700_Model item in sten)
                {
                    MedulaResult result = null;
                    SubEpisodeProtocol sep = objectContext.GetObject<SubEpisodeProtocol>(item.sepObjectID);
                    result = sep.SendNabiz700(true, item.accTrxList);
                    mr.Add(result);
                    objectContext.Save();
                }
            }
            return mr;
        }
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public List<MedulaResult> takipBazliHizmetKayit(TopluSEPGirisModel tom)
        {
            List<MedulaResult> mr = new List<MedulaResult>();
            MedulaResult result = null;
            using (var objectContext = new TTObjectContext(false))
            {
                for (int i = 0; i < tom.sepObjectIDs.Count; i++)
                {
                    SubEpisodeProtocol sep = (SubEpisodeProtocol)objectContext.GetObject(tom.sepObjectIDs[i], typeof(SubEpisodeProtocol));
                    result = sep.HizmetKayitSync(true);
                    mr.Add(result);
                    InvoiceLog.AddInfo(TTUtils.CultureService.GetText("M27003", "Takip bazlı hizmet kayıt yapıldı"), sep.ObjectID, InvoiceOperationTypeEnum.HizmetKayit, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                }

                return mr;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public List<MedulaResult> takipBazliHizmetKayitIptal(TopluSEPGirisModel tom)
        {
            List<MedulaResult> mr = new List<MedulaResult>();
            TTObjectContext objectcontext = new TTObjectContext(false);
            MedulaResult result = null;
            for (int i = 0; i < tom.sepObjectIDs.Count; i++)
            {
                SubEpisodeProtocol sep = (SubEpisodeProtocol)objectcontext.GetObject(tom.sepObjectIDs[i], typeof(SubEpisodeProtocol));
                result = sep.HizmetKayitIptalSync(null, null, true);
                mr.Add(result);
                InvoiceLog.AddInfo(TTUtils.CultureService.GetText("M27002", "Takip bazlı hizmet kayıt iptal yapıldı"), sep.ObjectID, InvoiceOperationTypeEnum.HizmetSil, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
            }

            return mr;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public string getRule([FromQuery] Guid sepObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                InvoiceInclusionMaster result = null;
                SubEpisodeProtocol sep = objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                result = sep.GetInvoiceInclusionMaster();
                if (result == null)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27144", "Uygun kural bulunamadı."));
                InvoiceLog.AddInfo(TTUtils.CultureService.GetText("M27145", "Uygun kural getirildi. Kural Adı:") + result.Name, sepObjectID, InvoiceOperationTypeEnum.GetRule, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                return result.Name;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Takip_Kopyalama)]
        public Guid copySEP([FromQuery] Guid sepObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                SubEpisodeProtocol newSEP = null;
                SubEpisodeProtocol sep = objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                newSEP = sep.CloneMe(SEPCloneTypeEnum.InvoiceScreenCopySEP);
                newSEP.MedulaProvizyonTarihi = sep.MedulaProvizyonTarihi;
                newSEP.ParentSEP = sep;
                newSEP.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProvisionNoNotExists;
                if (newSEP == null)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26339", "Kopyalama işlemi hatalı oldu."));
                objectContext.Save();
                objectContext.FullPartialllyLoadedObjects();
                InvoiceLog.AddInfo("Takip satırı kopyalama işlemi yapıldı. Mevcut: " + sep.Id + " Kopya:" + newSEP.Id, sepObjectID, InvoiceOperationTypeEnum.CopySEP, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                return newSEP.ObjectID;
            }
        }

        public class HizmetKayitIptalWithSUTCodeModel
        {
            public List<Guid> sepObjectIDs { get; set; }
            public string SUTCode { get; set; }
        }
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public bool hizmetKayitIptalWithSEPAndSutCode(HizmetKayitIptalWithSUTCodeModel hhiscm)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<SubEpisodeProtocol> sepList = new List<SubEpisodeProtocol>();
                foreach (Guid item in hhiscm.sepObjectIDs)
                {
                    SubEpisodeProtocol sep = objectContext.GetObject(item, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                    sepList.Add(sep);
                }
                return SubEpisodeProtocol.HizmetKayitIptalWithSEPAndSutCode(sepList, hhiscm.SUTCode);
            }
        }


        public class TransactionTotalPriceAndAmountModel
        {
            public List<Guid> sepObjectIDs { get; set; }
            public string firstSUTCode { get; set; }
            public string secondSUTCode { get; set; }
        }
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public List<SEPMaster.ForbiddenSUTOperation> getTransactionTotalAmountAndPrice(TransactionTotalPriceAndAmountModel ttpam)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<SubEpisodeProtocol> sepList = new List<SubEpisodeProtocol>();
                foreach (Guid item in ttpam.sepObjectIDs)
                {
                    SubEpisodeProtocol sep = objectContext.GetObject(item, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                    sepList.Add(sep);
                }
                return SEPMaster.GetTransactionTotalAmountAndPrice(sepList, ttpam.firstSUTCode, ttpam.secondSUTCode);
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Takip_Iptal_Etme)]
        public Guid cancelSEP([FromQuery] Guid sepObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                SubEpisodeProtocol sep = objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                sep.Cancel();
                SubEpisodeProtocol retSEP = sep.SEPMaster.SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled).FirstOrDefault();
                objectContext.Save();
                objectContext.FullPartialllyLoadedObjects();
                InvoiceLog.AddInfo(TTUtils.CultureService.GetText("M27015", "Takip satırı iptal edildi."), sepObjectID, InvoiceOperationTypeEnum.CancelSEP, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                return retSEP != null ? retSEP.ObjectID : Guid.Empty;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Takip_Iptal_Etme)]
        public void bagliTakipBilgisiKopar([FromQuery] Guid sepObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                SubEpisodeProtocol sep = objectContext.GetObject<SubEpisodeProtocol>(sepObjectID);

                if (!string.IsNullOrWhiteSpace(sep.MedulaTakipNo) || sep.InvoiceStatus != MedulaSubEpisodeStatusEnum.ProvisionNoNotExists)
                    throw new TTException("Bağlı takip bilgisini koparabilmek için, takip numarası boş olmalıdır.");

                if (sep.ParentSEP == null)
                    throw new TTException("Bağlı takip bilgisi bulunmamaktadır.");

                string parentSEPID = sep.ParentSEP.Id.ToString();

                sep.ParentSEP = null;
                objectContext.Save();
                objectContext.FullPartialllyLoadedObjects();

                InvoiceLog.AddInfo("Bağlı takip bilgisi koparıldı. Önceki bağlı takip ID: " + parentSEPID, sepObjectID, InvoiceOperationTypeEnum.BagliTakipBilgisiKopar, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public string getLastRule([FromQuery] Guid sepObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                SubEpisodeProtocol sep = objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                if (sep.LastIIM == null)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26914", "Son çalışmış kural bulunamadı."));
                InvoiceLog.AddInfo("Takip için son çalıştırılmış kural getirildi. Kural Adı: " + sep.LastIIM.Name, sepObjectID, InvoiceOperationTypeEnum.GetLastRule, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                return sep.LastIIM.Name;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public bool fixBasedOnTakip([FromQuery] Guid sepObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                SubEpisodeProtocol sep = objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                bool result = false;
                if (!sep.IsInvoiced)
                    result = sep.ArrangeAllTrxs();
                objectContext.Save();
                objectContext.FullPartialllyLoadedObjects();

                if (result && sep.LastIIM != null)
                    InvoiceLog.AddInfo("Takip için kural çalıştırıldı. Kural Adı: " + sep.LastIIM.Name, sepObjectID, InvoiceOperationTypeEnum.ExecRule, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);

                return result;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public bool fixBasedOnBasvuru(Guid[] sepObjectIDs)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                bool result = false;
                for (int i = 0; i < sepObjectIDs.Length; i++)
                {
                    SubEpisodeProtocol sep = objectContext.GetObject(sepObjectIDs[i], typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                    if (!sep.IsInvoiced)
                        result = sep.ArrangeAllTrxs();
                    objectContext.Save();
                    objectContext.FullPartialllyLoadedObjects();

                    if (result && sep.LastIIM != null)
                        InvoiceLog.AddInfo("Takip için kural çalıştırıldı. Kural Adı: " + sep.LastIIM.Name, sepObjectIDs[i], InvoiceOperationTypeEnum.ExecRule, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                }

                return result;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Kayit)]
        public bool faturaDuzelt(FaturaKayitModel fkm)
        {
            bool result = false;
            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    if (fkm.sepObjectIDs.Count > 0)
                    {
                        List<SubEpisodeProtocol> sepList = new List<SubEpisodeProtocol>();
                        foreach (Guid item in fkm.sepObjectIDs)
                        {
                            SubEpisodeProtocol sep = objectContext.GetObject(item, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                            sepList.Add(sep);
                        }

                        if (sepList[0].SEPMaster != null)
                        {
                            if (fkm.invoiceType == (int)PayerTypeEnum.SGK) //SGK fatura düzenleme methodu
                                result = sepList[0].SEPMaster.ArrangeInvoice(sepList);
                            else
                                throw new TTException(TTUtils.CultureService.GetText("M26780", "Sadece SGK faturalarında düzenleme işlemleri yapılabilir."));

                            objectContext.Save();
                        }
                    }

                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            catch (Exception ex)
            {
                InvoiceLog.AddException(ex.Message, fkm.sepObjectIDs[0], InvoiceOperationTypeEnum.Faturalandir, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                throw ex;
            }

            return result;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Kayit)]
        public List<MedulaResult> faturaKayit(FaturaKayitModel fkm)
        {
            List<MedulaResult> result = new List<MedulaResult>();
            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    if (fkm.sepObjectIDs.Count > 0)
                    {
                        List<SubEpisodeProtocol> sepList = new List<SubEpisodeProtocol>();
                        foreach (Guid item in fkm.sepObjectIDs)
                        {
                            SubEpisodeProtocol sep = objectContext.GetObject(item, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                            sepList.Add(sep);
                        }

                        if (sepList[0].SEPMaster != null)
                        {
                            if (fkm.invoiceType != (int)PayerTypeEnum.Paid) //SGK ve Resmi Fatura kayit methodu
                            {
                                DateTime logStartDate = DateTime.Now;
                                result = sepList[0].SEPMaster.SaveInvoice(sepList, fkm.invoiceDate, fkm.invoiceDescription, fkm.invoiceCollection, fkm.type);
                                if (result.FirstOrDefault().SonucKodu == "1108" && TTObjectClasses.SystemParameter.GetParameterValue("TEKLIFATURAOTOMATIKDUZELT", "FALSE") == "TRUE")
                                    result = sepList[0].SEPMaster.Fix1108MedulaErrorCodeAndSaveInvoice(result, sepList, fkm.invoiceDate, fkm.invoiceDescription, fkm.invoiceCollection, fkm.type, 0, "");
                                DateTime logEndDate = DateTime.Now;
                                InvoiceLog.AddInfo("faturaKayit-> get and set Inmemory totalMilisecond: " + (logEndDate.TimeOfDay.TotalMilliseconds - logStartDate.TimeOfDay.TotalMilliseconds), sepList[0].ObjectID, InvoiceOperationTypeEnum.Faturalandir, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                            }
                            else
                            {
                                //Ücretli hasta faturası method u
                                result = sepList[0].SEPMaster.SavePatientInvoice(sepList, fkm.invoiceDate, fkm.invoiceDescription, fkm.transactionlist, fkm.type);
                            }

                            DateTime logStartDate2 = DateTime.Now;
                            objectContext.Save();
                            DateTime logEndDate2 = DateTime.Now;
                            InvoiceLog.AddInfo("faturaKayit-> objectContext.Save() operation totalMilisecond: " + (logEndDate2.TimeOfDay.TotalMilliseconds - logStartDate2.TimeOfDay.TotalMilliseconds), sepList[0].ObjectID, InvoiceOperationTypeEnum.Faturalandir, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                        }
                    }

                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            catch (Exception ex)
            {
                InvoiceLog.AddException(ex.Message, fkm.sepObjectIDs[0], (InvoiceOperationTypeEnum)Common.GetEnumValueDefOfEnumValueV2("InvoiceOperationTypeEnum", fkm.type).EnumValue, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                throw new TTException(ex.Message);
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Iptal)]
        public List<MedulaResult> faturaIptal([FromQuery] Guid sepObjectID)
        {
            List<MedulaResult> result = new List<MedulaResult>();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    SubEpisodeProtocol sep = objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                    result = sep.InvoiceCollectionDetail?.PayerInvoiceDocument?.Cancel();
                    if (result.Count > 0)
                        result[0].SEPObjectID = sepObjectID;
                    objectContext.Save();
                }
                catch (Exception ex)
                {
                    InvoiceLog.AddException("Fatura iptal edilirken hata oluştu. Hata mesajı: " + ex.Message, sepObjectID, InvoiceOperationTypeEnum.FaturaSil, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                    throw new TTException(ex.Message);
                }
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public faturaOkuCevapDTO faturaOku([FromQuery] Guid sepObjectID)
        {
            FaturaKayitIslemleri.faturaOkuCevapDVO tempResult = new FaturaKayitIslemleri.faturaOkuCevapDVO();
            faturaOkuCevapDTO result = new faturaOkuCevapDTO();
            using (var objectContext = new TTObjectContext(false))
            {
                SubEpisodeProtocol sep = objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                try
                {
                    tempResult = sep.InvoiceCollectionDetail?.PayerInvoiceDocument?.Read();
                    if (!string.IsNullOrEmpty(tempResult.faturaTeslimNo))
                    {
                        result.faturaRefNoField = tempResult.faturaRefNo;
                        result.faturaTarihiField = tempResult.faturaTarihi;
                        result.faturaTeslimNoField = tempResult.faturaTeslimNo;
                        result.faturaTutariField = tempResult.faturaTutari;
                        result.sonucKoduField = tempResult.sonucKodu;
                        result.sonucMesajiField = tempResult.sonucMesaji;
                        if (tempResult.sonucKodu.Equals("0000"))
                            result.succes = true;
                        else
                            result.succes = false;
                        result.faturaDetaylariField = new List<faturaCevapDetayDTO>();
                        List<InvoiceCollectionDetail> icdList = sep.InvoiceCollectionDetail?.PayerInvoiceDocument?.InvoiceCollectionDetails.ToList();
                        foreach (var fd in tempResult.faturaDetaylari)
                        {
                            faturaCevapDetayDTO fcdDTO = new faturaCevapDetayDTO();
                            fcdDTO.aciklamaField = fd.aciklama;
                            fcdDTO.protokolNoField = fd.protokolNo;
                            fcdDTO.taburcuKoduField = fd.taburcuKodu;
                            fcdDTO.takipNoField = fd.takipNo;
                            fcdDTO.takipToplamTutarField = fd.takipToplamTutar;
                            foreach (InvoiceCollectionDetail icd in icdList)
                            {
                                fcdDTO.islemDetaylariField = new List<islemDetayDTO>();
                                SubEpisodeProtocol sepInner = icd.SubEpisodeProtocols.Where(x => x.MedulaTakipNo == fd.takipNo).FirstOrDefault();
                                if (sepInner != null)
                                {
                                    foreach (var id in fd.islemDetaylari)
                                    {
                                        islemDetayDTO idDTO = new islemDetayDTO();
                                        AccountTransaction act = sepInner.AccountTransactions.Select("").Where(x => x.MedulaProcessNo == id.islemSiraNo).FirstOrDefault();
                                        if (act != null)
                                        {
                                            idDTO.islemAdiField = act.Description;
                                            idDTO.islemKoduField = act.ExternalCode;
                                            idDTO.islemTarihiField = act.TransactionDate.HasValue ? act.TransactionDate.Value.ToString("dd.MM.yyyy") : "";
                                        }
                                        else
                                        {
                                            SEPDiagnosis sepDia = sepInner.SEPDiagnoses.Where(x => x.MedulaProcessNo == id.islemSiraNo).FirstOrDefault();
                                            if (sepDia != null)
                                            {
                                                idDTO.islemAdiField = sepDia.Diagnose.Name;
                                                idDTO.islemKoduField = sepDia.Diagnose.Code;
                                            }
                                        }

                                        idDTO.islemSiraNoField = id.islemSiraNo;
                                        idDTO.islemTutariField = id.islemTutari;
                                        fcdDTO.islemDetaylariField.Add(idDTO);
                                    }
                                }

                                result.faturaDetaylariField.Add(fcdDTO);
                            }
                        }
                    }

                    objectContext.Save();
                }
                catch (Exception ex)
                {
                    InvoiceLog.AddException("Meduladan fatura okuma sırasında hata oluştu. Mesaj:" + ex.Message, sep.ObjectID, InvoiceOperationTypeEnum.FaturaSil, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                    throw new TTException(ex.Message);
                }
            }

            return result;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public List<MedulaResult> faturaTutarOku(FaturaKayitModel fkm)
        {
            List<MedulaResult> result = new List<MedulaResult>();
            using (var objectContext = new TTObjectContext(false))
            {
                if (fkm.sepObjectIDs.Count > 0)
                {
                    List<SubEpisodeProtocol> sepList = new List<SubEpisodeProtocol>();
                    foreach (Guid item in fkm.sepObjectIDs)
                    {
                        SubEpisodeProtocol sep = objectContext.GetObject(item, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                        sepList.Add(sep);
                    }

                    if (sepList[0].SEPMaster != null)
                    {
                        DateTime logStartDate = DateTime.Now;
                        result = sepList[0].SEPMaster.ReadInvoicePrice(sepList, fkm.invoiceDate, fkm.invoiceDescription);
                        if (result.FirstOrDefault().SonucKodu == "1108" && TTObjectClasses.SystemParameter.GetParameterValue("TEKLIFATURAOTOMATIKDUZELT", "FALSE") == "TRUE")
                            result = sepList[0].SEPMaster.Fix1108MedulaErrorCodeAndSaveInvoice(result, sepList, fkm.invoiceDate, fkm.invoiceDescription, fkm.invoiceCollection, fkm.type, 1, "");

                        DateTime logEndDate = DateTime.Now;
                        InvoiceLog.AddInfo("faturaTutarOku-> get and set Inmemory totalMilisecond: " + (logEndDate.TimeOfDay.TotalMilliseconds - logStartDate.TimeOfDay.TotalMilliseconds), sepList[0].ObjectID, InvoiceOperationTypeEnum.FaturaOkuveBilgileriGuncelle, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                        DateTime logStartDate2 = DateTime.Now;
                        objectContext.Save();
                        DateTime logEndDate2 = DateTime.Now;
                        InvoiceLog.AddInfo("faturaTutarOku-> objectContext.Save() operation totalMilisecond: " + (logEndDate2.TimeOfDay.TotalMilliseconds - logStartDate2.TimeOfDay.TotalMilliseconds), sepList[0].ObjectID, InvoiceOperationTypeEnum.FaturaOkuveBilgileriGuncelle, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                    }
                }

                objectContext.FullPartialllyLoadedObjects();
                return result;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Medula_Takip_Okuma)]
        public List<HastaKabulIslemleri.takipDVO> takipOku(TopluSEPGirisModel tom)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<HastaKabulIslemleri.takipDVO> listOfTakip = new List<HastaKabulIslemleri.takipDVO>();
                if (tom.sepObjectIDs.Count > 0)
                {
                    foreach (Guid item in tom.sepObjectIDs)
                    {
                        SubEpisodeProtocol sep = objectContext.GetObject(item, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                        try
                        {
                            if (sep != null)
                            {
                                HastaKabulIslemleri.takipDVO tempTakip = sep.ReadProvisionFromMedula();
                                if (tempTakip != null)
                                    listOfTakip.Add(tempTakip);
                                objectContext.Save();
                            }
                        }
                        catch
                        {
                            InvoiceLog.AddException(TTUtils.CultureService.GetText("M27014", "Takip okuma sırasında hata oluştu. Takip no:") + sep.MedulaTakipNo, sep.ObjectID, InvoiceOperationTypeEnum.TakipOku, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                        }
                    }
                }

                objectContext.FullPartialllyLoadedObjects();
                return listOfTakip;
            }
        }

        public class updateSEPDischargeType_Model
        {
            public Guid sepObjectID { get; set; }
            public Guid taburcuKodu { get; set; }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public bool updateSEPDischargeType(updateSEPDischargeType_Model usd)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    if (usd.sepObjectID != null)
                    {
                        SubEpisodeProtocol sep = objectContext.GetObject(usd.sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                        sep.updateDischargeType(usd.taburcuKodu);
                    }

                    objectContext.FullPartialllyLoadedObjects();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public HastaKabulIslemleri.basvuruTakipOkuCevapDVO basvuruOku([FromQuery] Guid sepObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                SubEpisodeProtocol sep = objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                //
                if (!string.IsNullOrEmpty(sep.MedulaBasvuruNo))
                {
                    return SEPMaster.basvuruOku(sep.MedulaBasvuruNo);
                }
                else
                {
                    foreach (var sepItem in sep.SEPMaster.SubEpisodeProtocols)
                    {
                        if (!string.IsNullOrEmpty(sepItem.MedulaBasvuruNo))
                        {
                            return SEPMaster.basvuruOku(sepItem.MedulaBasvuruNo);
                        }
                    }

                    return null;
                }
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public MedulaResult icmaleEkle([FromQuery] Guid sepObjectID, [FromQuery] Guid invoiceCollectionID)
        {
            MedulaResult result = new MedulaResult();
            using (var objectContext = new TTObjectContext(false))
            {
                InvoiceCollection ic = (InvoiceCollection)objectContext.GetObject(invoiceCollectionID, typeof(InvoiceCollection));
                SubEpisodeProtocol sep = (SubEpisodeProtocol)objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol));
                ic.AddInvoiceCollectionDetail(sep);
                objectContext.Save();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Icmalden_Cikar)]
        public MedulaResult icmaldenCikar([FromQuery] Guid sepObjectID)
        {
            MedulaResult result = new MedulaResult();
            using (var objectContext = new TTObjectContext(false))
            {
                SubEpisodeProtocol sep = (SubEpisodeProtocol)objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol));
                sep.InvoiceCollectionDetail.InvoiceCollection.RemoveInvoiceCollectionDetail(sep.InvoiceCollectionDetail, CancelledInvoiceTypeEnum.OutOfInvoiceCollection);
                objectContext.Save();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public List<Infrastructure.Models.ComboListItem> uygunIcmalleriGetir([FromQuery] Guid sepObjectID)
        {
            Guid? userID = Common.CurrentResource.ObjectID;
            using (var objectContext = new TTObjectContext(true))
            {
                if (userID.HasValue)
                {
                    SubEpisodeProtocol sep = (SubEpisodeProtocol)objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol));
                    if (sep != null)
                    {
                        string ttKodu = "A";
                        if (sep.SubEpisode.Episode.PatientStatus != PatientStatusEnum.Outpatient)
                            ttKodu = "Y";
                        var icList = objectContext.QueryObjects<InvoiceCollection>().Where(x => x.InvoiceTerm != null && x.InvoiceTerm.CurrentStateDefID == InvoiceTerm.States.Open && x.CurrentStateDefID == InvoiceCollection.States.Open && sep.Payer.ObjectID == x.Payer.ObjectID && (x.CreateUser.ObjectID == userID.Value || x.IsGeneral.Value == true) && x.IsAutoGenerated == false && (x.TedaviTuru == null || (x.TedaviTuru != null && x.TedaviTuru.tedaviTuruKodu == ttKodu))).ToArray();
                        //TODO: AAE false yapılacak daha sonra. şimdi false olan hiç kayıt yok.
                        List<Infrastructure.Models.ComboListItem> result = new List<Infrastructure.Models.ComboListItem>();
                        foreach (InvoiceCollection ic in icList)
                        {
                            if (((sep.MedulaTedaviTuru.tedaviTuruKodu == "A" || sep.MedulaTedaviTuru.tedaviTuruKodu == "G") && sep.SubEpisode.Episode.OpeningDate <= ic.InvoiceTerm.EndDate) ||
                                sep.MedulaTedaviTuru.tedaviTuruKodu == "Y" && sep.SubEpisode.InpatientAdmission != null && sep.SubEpisode.InpatientAdmission.HospitalDischargeDate <= ic.InvoiceTerm.EndDate)
                            {
                                Infrastructure.Models.ComboListItem resultItem = new Infrastructure.Models.ComboListItem(ic.ObjectID, ic.InvoiceTerm.Name + " | " + ic.Name);
                                result.Add(resultItem);
                            }
                        }

                        objectContext.FullPartialllyLoadedObjects();
                        return result;
                    }
                }
            }

            return null;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public Guid? getDoctorObjectIDFromSEP([FromQuery] Guid sepObjectID)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                SubEpisodeProtocol sep = (SubEpisodeProtocol)objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol));
                ResUser doctor = sep.getDoctor();
                if (doctor != null)
                    return doctor.ObjectID;
                else
                    return null;
            }
        }

        public class getSutRuleEngineResultCodes_Model
        {
            public Guid ObjectID { get; set; }
            public Guid RuleGroupID { get; set; }
            public string RuleName { get; set; }
            public string ExternalCode { get; set; }
            public string RelatedCode { get; set; }
            public string Description { get; set; }
            public string Message { get; set; }
            public double Price { get; set; }
            public int? Choice { get; set; }

            public getSutRuleEngineResultCodes_Model()
            { }
            public getSutRuleEngineResultCodes_Model(Guid _objectID, Guid _ruleGroupID,string _ruleName,string _externalCode,string _relatedCode,string _description,
                string _message,double _price)
            {
                this.ObjectID = _objectID;
                this.RuleGroupID = _ruleGroupID;
                this.Description = _description;
                this.ExternalCode = _externalCode;
                this.Message = _message;
                this.Price = _price;
                this.RelatedCode = _relatedCode;
                this.RuleName = _ruleName;
                this.Choice = null;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public List<getSutRuleEngineResultCodes_Model> getSutRuleEngineResultCodes([FromQuery] Guid sepObjectID)
        {
            List<getSutRuleEngineResultCodes_Model> result = new List<getSutRuleEngineResultCodes_Model>();
            using (var objectContext = new TTObjectContext(true))
            {
                SubEpisodeProtocol sep = (SubEpisodeProtocol)objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol));

                IRuleCheckEngine service = SutRuleServiceFactory.Instance;
                object patientId = sep.Episode.Patient.ObjectID;
                List<string> yasakliKodlar = new List<string>();
                object episodeId = sep.Episode.ObjectID; 
                TTUtils.Entities.RuleValidateResultDto validateResults = service.ValidateRulesForInvoice(patientId, episodeId);
                bool ruleViolationExists = false;
                if (validateResults != null && validateResults.Messages.Count > 0)
                {
                    ruleViolationExists = true;
                    foreach (var item in validateResults.Messages)
                    {
                        if (item.RuleGroupId.ToString() == "20c01606-e7f6-4356-9653-7f36028366e6"//Cinsiyet Kuralı
                            || item.RuleGroupId.ToString() == "3a0e1357-a980-49a3-a008-5b05d4c00c7d")//Zorunlu Branş Kuralı
                        {
                            List<AccountTransaction> tempTrxList = AccountTransaction.GetTransactionsBySEPMaster(objectContext, sep.SEPMaster.ObjectID, " AND SubActionProcedure.ProcedureObject.SUTCode = '" + item.ProcedureCode + "'").ToList();
                            foreach (var itemTrx in tempTrxList)
                            {
                                string ruleName = "";
                                if (item.RuleGroupId.ToString() == "20c01606-e7f6-4356-9653-7f36028366e6")
                                    ruleName = "Cinsiyet Kuralı";
                                else if (item.RuleGroupId.ToString() == "3a0e1357-a980-49a3-a008-5b05d4c00c7d")
                                    ruleName = "Zorunlu Branş Kuralı";

                                getSutRuleEngineResultCodes_Model tempItem = new getSutRuleEngineResultCodes_Model(itemTrx.ObjectID, item.RuleGroupId, ruleName, itemTrx.ExternalCode, "", itemTrx.Description, item.Message, itemTrx.UnitPrice.Value * itemTrx.Amount.Value);

                                result.Add(tempItem);
                            }
                        }
                        else if (item.RuleGroupId.ToString() == "60d1d499-61b6-4e45-907b-4a843861bedc" // X günde Y adet uygulanabilir.
                                || item.RuleGroupId.ToString() == "925eadd4-5c73-465c-a05d-2ff128afb946" // Yaş Sınırı Kuralı
                                || item.RuleGroupId.ToString() == "2b904884-ec27-d146-a9bc-663d6cacf779" // Kabul Bazında Adet Sınırı Kuralı
                                || item.RuleGroupId.ToString() == "919b6ff9-cd98-4b30-887b-304dc8d5deca") // Arşiv Bazında Adet Sınırı Kuralı
                        {
                            AccountTransaction itemTrx = objectContext.GetObject<AccountTransaction>(new Guid(item.DetailId1.ToString()));
                            string ruleName = "";
                            if (item.RuleGroupId.ToString() == "60d1d499-61b6-4e45-907b-4a843861bedc")
                                ruleName = "X Günde Y Adet Uygulanabilir Kuralı";
                            else if (item.RuleGroupId.ToString() == "925eadd4-5c73-465c-a05d-2ff128afb946")
                                ruleName = "Yaş Sınırı Kuralı";
                            else if (item.RuleGroupId.ToString() == "2b904884-ec27-d146-a9bc-663d6cacf779")
                                ruleName = "Kabul Bazında Adet Sınırı Kuralı";
                            else if (item.RuleGroupId.ToString() == "919b6ff9-cd98-4b30-887b-304dc8d5deca")
                                ruleName = "Arşiv Bazında Adet Sınırı Kuralı";

                            getSutRuleEngineResultCodes_Model tempItem = new getSutRuleEngineResultCodes_Model(itemTrx.ObjectID, item.RuleGroupId, ruleName, itemTrx.ExternalCode, "", itemTrx.Description, item.Message, itemTrx.UnitPrice.Value * itemTrx.Amount.Value);
                           
                            result.Add(tempItem); 
                        }
                        else if (item.RuleGroupId.ToString() == "45421845-01db-4e02-8a59-b0208ba507a0")//Yasaklı Hizmet Kuralı
                        {
                            if(yasakliKodlar.Count(x => x == item.ProcedureCode) == 0)
                            {
                                string ruleName = "Yasaklı Hizmet Kuralı";
                                List<AccountTransaction> tempTrxList1 = AccountTransaction.GetTransactionsBySEPMaster(objectContext, sep.SEPMaster.ObjectID, " AND SubActionProcedure.ProcedureObject.SUTCode = '" + item.DetailId1.ToString() + "'").ToList();
                                foreach (var itemTrx in tempTrxList1)
                                {

                                    getSutRuleEngineResultCodes_Model tempItem = new getSutRuleEngineResultCodes_Model(itemTrx.ObjectID, item.RuleGroupId, ruleName, itemTrx.ExternalCode, item.DetailId2.ToString(), itemTrx.Description, item.Message, itemTrx.UnitPrice.Value * itemTrx.Amount.Value);

                                    result.Add(tempItem);
                                }
                                yasakliKodlar.Add(item.DetailId1.ToString());

                                List<AccountTransaction> tempTrxList2 = AccountTransaction.GetTransactionsBySEPMaster(objectContext, sep.SEPMaster.ObjectID, " AND SubActionProcedure.ProcedureObject.SUTCode = '" + item.DetailId2.ToString() + "'").ToList();
                                foreach (var itemTrx in tempTrxList2)
                                {
                                    getSutRuleEngineResultCodes_Model tempItem = new getSutRuleEngineResultCodes_Model(itemTrx.ObjectID, item.RuleGroupId, ruleName, itemTrx.ExternalCode, item.DetailId1.ToString(), itemTrx.Description, item.Message, itemTrx.UnitPrice.Value * itemTrx.Amount.Value);

                                    result.Add(tempItem);
                                }
                                yasakliKodlar.Add(item.DetailId2.ToString());
                            }
                        }
                    }
                }
                return result;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void execSutRuleEngineResultCodes(List<getSutRuleEngineResultCodes_Model> inputList )
        {
            using (var objectContext = new TTObjectContext(false))
            {
                foreach (getSutRuleEngineResultCodes_Model item in inputList)
                {
                    if(item.Choice == 1)//Gönderme
                    {
                        AccountTransaction itemTrx = objectContext.GetObject<AccountTransaction>(item.ObjectID);
                        if (itemTrx.SubEpisodeProtocol.IsSGK && itemTrx.CurrentStateDefID == AccountTransaction.States.MedulaEntrySuccessful)
                        {
                            List<string> ssList = new List<string>();
                            List<Guid> accountTransactionIDs = new List<Guid>();
                            ssList.Add(itemTrx.MedulaProcessNo.ToString());
                            accountTransactionIDs.Add(itemTrx.ObjectID);
                            itemTrx.SubEpisodeProtocol.HizmetKayitIptalSync(ssList, accountTransactionIDs, true);
                        }
                        List<string> updateList = new List<string>();
                        List<AccountTransaction> updateActList = new List<AccountTransaction>();
                        if (itemTrx.CurrentStateDefID == AccountTransaction.States.New || itemTrx.CurrentStateDefID == AccountTransaction.States.ToBeNew || itemTrx.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful)
                        {
                            updateList.Add(item.ObjectID.ToString());
                            updateActList.Add(itemTrx);
                        }
                        if (updateList.Count > 0)
                            Utils.UpdateTransactionState(updateList, false, updateActList);//false gönderilmeyecek yap.
                    }
                }
            }
        }
           
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Hizmet_Ekleme)]
        public bool addNewProcedureToSEP(AddNewProcedureToSEPModel anp)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                SubEpisodeProtocol sep = (SubEpisodeProtocol)objectContext.GetObject(anp.SEPObjectID, typeof(SubEpisodeProtocol));
                ProcedureMaterialAdding pma = null;
                foreach (var item in anp.NewProcedures)
                {
                    try
                    {
                        if (item.Amount <= 0 || item.Doctor == null || !item.TransactionDate.HasValue || item.ProcedureObjectID == null)
                            throw new TTException(TTUtils.CultureService.GetText("M25969", "Hizmetin eklenebilmesi için adet, doktor ve işlem tarihi alanlarının doğru/dolu olması gereklidir."));
                        pma = sep.AddNewProcedure(item.Amount, item.ProcedureObjectID.ObjectID.Value, item.Doctor, item.TransactionDate, pma);
                    }
                    catch (Exception ex)
                    {
                        InvoiceLog.AddException(item.Code + " kodlu " + item.Name + " işlemini eklerken hata oluştu.Eklenmeye çalışılan tarih: " + (item.TransactionDate.HasValue ? item.TransactionDate.Value.ToString("dd.MM.yyyy") : "") + " " + ex.Message, sep.ObjectID, InvoiceOperationTypeEnum.AddNewProcedure, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                        throw new TTException(item.Code + " kodlu " + item.Name + " işlemini eklerken hata oluştu.Eklenmeye çalışılan tarih: " + (item.TransactionDate.HasValue ? item.TransactionDate.Value.ToString("dd.MM.yyyy") : "") + " " + ex.Message);
                    }
                }

                objectContext.Update();
                if (pma != null)
                    pma.AccountOperationDirect(AccountOperationTimeEnum.PREPOST, sep);
                objectContext.Save();
                return true;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public List<InvoiceLogModel> getSEPHistory([FromQuery] Guid sepObjectID)
        {
            List<InvoiceLogModel> result = new List<InvoiceLogModel>();
            using (var objectContext = new TTObjectContext(true))
            {
                BindingList<InvoiceLog.GetInvoiceLog_Class> items = InvoiceLog.GetInvoiceLog(objectContext, sepObjectID, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                var query =
                    from i in items
                    orderby i.Date descending
                    select new InvoiceLogModel { Date = i.Date.Value.ToString("dd/MM/yyyy HH:mm:ss"), UserName = i.Name, LogType = i.Mtype.ToString(), Message = i.Message, Operation = i.Optype.ToString() };
                result = query.ToList();
            }

            return result;
        }


        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public List<InvoiceBlockingModel> getSEPInvoiceBlocking([FromQuery] Guid sepObjectID)
        {
            List<InvoiceBlockingModel> result = new List<InvoiceBlockingModel>();
            List<Guid> episodeObjectIDList = new List<Guid>();

            using (var objectContext = new TTObjectContext(true))
            {
                SubEpisodeProtocol sep = (SubEpisodeProtocol)objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol));
                List<SubEpisodeProtocol> sepList = sep.SEPMaster.SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && x.Payer.Type.PayerType == sep.Payer.Type.PayerType).ToList();

                foreach (SubEpisodeProtocol sepInner in sepList)
                {
                    Guid tempG = sepInner.SubEpisode.Episode.ObjectID;
                    if (!episodeObjectIDList.Contains(tempG))
                    {
                        episodeObjectIDList.Add(tempG);
                    }
                }

                BindingList<InvoiceBlocking.GetInvoiceBlocking_Class> items = InvoiceBlocking.GetInvoiceBlocking(objectContext, episodeObjectIDList);
                var query =
                    from i in items
                    orderby i.BlockDate descending
                    select new InvoiceBlockingModel
                    {
                        ObjectID = i.ObjectID.Value,
                        BlockDate = i.BlockDate.Value.ToString("dd/MM/yyyy HH:mm:ss"),
                        BlockUserName = i.Blockusername,
                        BlockUserObjectID = i.Blockuserobjectid,
                        BlockDescription = i.BlockDescription,
                        UnblockDate = i.UnblockDate.HasValue ? i.UnblockDate.Value.ToString("dd/MM/yyyy HH:mm:ss") : null,
                        UnblockUserName = i.Unblockusername,
                        UnblockUserObjectID = i.Unblockuserobjectid,
                        UnblockDescription = i.UnblockDescription,
                        ModuleName = i.ModuleName,
                        Active = i.Active.HasValue ? i.Active.Value : false
                    };
                result = query.ToList();
            }

            return result;
        }

        public class AddNewInvoiceBlocking
        {
            public Guid sepObjectID { get; set; }
            public string invoiceBlockingDescription { get; set; }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void saveNewInvoiceBlocking(AddNewInvoiceBlocking ibsm)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                SubEpisodeProtocol sep = (SubEpisodeProtocol)objectContext.GetObject(ibsm.sepObjectID, typeof(SubEpisodeProtocol));

                InvoiceBlocking.saveNewInvoiceBlocking(sep.SubEpisode.Episode.ObjectID, ibsm.invoiceBlockingDescription, TTUtils.CultureService.GetText("M25639", "Fatura Modülü"), InvoiceBlockingTypeEnum.ManuelBlock);
            }
        }
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void saveNewInvoiceDescription(AddNewInvoiceBlocking ibsm)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                SubEpisodeProtocol sep = (SubEpisodeProtocol)objectContext.GetObject(ibsm.sepObjectID, typeof(SubEpisodeProtocol));
                sep.Description = ibsm.invoiceBlockingDescription;
                objectContext.Save();
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void clearSEPDescription(AddNewInvoiceBlocking ibsm)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                SubEpisodeProtocol sep = (SubEpisodeProtocol)objectContext.GetObject(ibsm.sepObjectID, typeof(SubEpisodeProtocol));
                List<SubEpisodeProtocol> sepList = sep.SEPMaster.SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled).ToList();
                foreach (SubEpisodeProtocol sepInner in sepList)
                {
                    sepInner.Description = null;
                }
                objectContext.Save();
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class PassInvoiceBlockingModel
        {
            public Guid ibObjectID { get; set; }
            public string passInvoiceBlockingDescription { get; set; }

        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void passInvoiceBlocking(PassInvoiceBlockingModel ibsm)
        {
            InvoiceBlocking ib = InvoiceBlocking.passInvoiceBlocking(ibsm.ibObjectID, ibsm.passInvoiceBlockingDescription);
        }

        public class FazlaTakipSilModel
        {

            public string takipNo { get; set; }

        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Medula_Takip_Silme)]
        public string FazlaTakipSil(FazlaTakipSilModel model)
        {
            XXXXXXMedulaServices ams = new XXXXXXMedulaServices();
            HastaKabulIslemleri.takipSilCevapDVO result = new HastaKabulIslemleri.takipSilCevapDVO();
            if (!string.IsNullOrEmpty(model.takipNo))
                result = ams.fazlaTakipSil(model.takipNo);
            else
                throw new TTException(TTUtils.CultureService.GetText("M27017", "Takip silebilmek için takip numarası dolu olmalıdır."));

            return result.sonucMesaji;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Medula_Takip_Okuma, TTRoleNames.Hasta_Kabul_Kurum_Degistirme)]
        public List<FazlaTakipDTO> FazlaTakipOku([FromQuery] string tc, string ilkTarih, string sonTarih)
        {
            List<FazlaTakipDTO> result = new List<FazlaTakipDTO>();
            using (var objectContext = new TTObjectContext(false))
            {
                BindingList<Patient> patList = Patient.GetPatientsByUniqueRefNo(objectContext, Convert.ToInt64(tc));

                if (patList.Count == 0)
                    throw new TTException(TTUtils.CultureService.GetText("M25721", "Girilen TC numarasına ait bir hasta kaydı sistemde bulunamadı."));
                else
                {
                    MedulaYardimciIslemler.takipAraCevapDVO takipAraCevapDVO = patList[0].ReadExtraProvision(ilkTarih, sonTarih);
                    if (takipAraCevapDVO.sonucKodu == "0000" && takipAraCevapDVO.takipler != null && takipAraCevapDVO.takipler.Length > 0)
                    {
                        foreach (var item in takipAraCevapDVO.takipler)
                        {
                            SubEpisodeProtocol sep = SubEpisodeProtocol.GetSEPByProvisionNo(item.takipNo);
                            FazlaTakipDTO ftd = new FazlaTakipDTO();
                            if (sep == null)
                                ftd.ID = "0";
                            else
                                ftd.ID = sep.SubEpisode.ProtocolNo + "-" + sep.Id.Value.ToString();

                            BindingList<SpecialityDefinition> speList = SpecialityDefinition.GetSpecialityByCode(objectContext, item.bransKodu);
                            if (speList.Count == 0)
                                ftd.bransKodu = item.bransKodu;
                            else
                                ftd.bransKodu = speList[0].Code + "-" + speList[0].Name;

                            ftd.hastaBasvuruNo = item.hastaBasvuruNo;
                            ftd.takipNo = item.takipNo;
                            ftd.takipTarihi = item.takipTarihi;
                            TedaviTuru tt = TedaviTuru.GetTedaviTuru(item.tedaviTuru);

                            if (tt == null)
                                ftd.tedaviTuru = item.tedaviTuru;
                            else
                                ftd.tedaviTuru = tt.tedaviTuruKodu + "-" + tt.tedaviTuruAdi;

                            result.Add(ftd);
                        }
                    }
                    else
                    {
                        if (takipAraCevapDVO.sonucKodu != "0000")
                            throw new TTException(takipAraCevapDVO.sonucMesaji);
                        else
                            throw new TTException("Belirtilen tarihler arasında kayıtlı bir takip bilgisi bulunamadı.");
                    }
                }
                return result;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public HastaYatisOkuCevapDTO HastaYatisOku([FromQuery] Guid sepObjectID)
        {
            HastaYatisOkuCevapDTO result = new HastaYatisOkuCevapDTO();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    SubEpisodeProtocol sep = objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                    if (!string.IsNullOrEmpty(sep.MedulaBasvuruNo) && !string.IsNullOrEmpty(sep.MedulaTakipNo))
                    {
                        if (sep.SubEpisode.InpatientAdmission != null)
                        {
                            result.ClinicDischargeDate = sep.SubEpisode.InpatientAdmission.HospitalDischargeDate;
                        }
                        HastaKabulIslemleri.hastaYatisOkuCevapDVO yatisResult = sep.HastaYatisOkuFromMedula();
                        if (yatisResult != null)
                        {

                            result.sonucKodu = yatisResult.sonucKodu;
                            result.sonucMesaji = yatisResult.sonucMesaji;
                            if (yatisResult.sonucKodu == "0000")
                            {
                                result.basvuruYatisBilgileri = new List<BasvuruYatisBilgileriDTO>();
                                foreach (var item in yatisResult.basvuruYatisBilgileri)
                                {
                                    BasvuruYatisBilgileriDTO tempItem = new BasvuruYatisBilgileriDTO();
                                    tempItem.baslangicTarihi = item.baslangicTarihi;
                                    tempItem.bitisTarihi = item.bitisTarihi == "01.01.0001" ? "-" : item.bitisTarihi;
                                    tempItem.durum = item.durum == "0" ? TTUtils.CultureService.GetText("M25665", "Faturalanmamış") : TTUtils.CultureService.GetText("M25666", "Faturalanmış");
                                    result.basvuruYatisBilgileri.Add(tempItem);
                                }
                                result.donorTck = yatisResult.donorTck;
                                result.hastaBasvuruNo = yatisResult.hastaBasvuruNo;
                                result.saglikTesisiKodu = yatisResult.saglikTesisiKodu.ToString();
                                result.yeniDoganCocukSiraNo = yatisResult.yeniDoganCocukSiraNo;
                                result.yeniDoganDogumTarihi = yatisResult.yeniDoganDogumTarihi;
                            }
                        }
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    result.sonucMesaji += " " + ex.Message;
                    return result;
                    //InvoiceLog.AddException(ex.Message, sepObjectID, InvoiceOperationTypeEnum.AddNewDiagnosis, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                }
            }
            return result;
        }

        public class YatisCikisKayitModel
        {
            public Guid sepObjectID { get; set; }
            public string ClinicDischargeDate { get; set; }

        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public string YatisCikisKayit(YatisCikisKayitModel yckm)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    SubEpisodeProtocol sep = objectContext.GetObject(yckm.sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                    if (!string.IsNullOrEmpty(sep.MedulaBasvuruNo) && !string.IsNullOrEmpty(sep.MedulaTakipNo))
                    {
                        if (!string.IsNullOrEmpty(yckm.ClinicDischargeDate))
                        {
                            HastaKabulIslemleri.hastaCikisCevapDVO yatisResult = sep.HastaCikisKayitToMedula(yckm.ClinicDischargeDate);
                            if (yatisResult != null)
                            {
                                objectContext.Save();


                                SendToENabiz sendToENabiz = new SendToENabiz();
                                sendToENabiz.ControlAndCreatePackageToSendToENabiz(objectContext, sep.SubEpisode, sep.SubEpisode.ObjectID, "SUBEPISODE", "106");
                                List<NabizResponse> resList = sendToENabiz.ENABIZSend106(sep.SubEpisode.ObjectID.ToString(), Convert.ToDateTime(yckm.ClinicDischargeDate));
                                foreach (var item in resList)
                                {
                                    yatisResult.sonucMesaji += " Nabiz Çıkış Kayıt(106) Sonucu: " + item.SonucMesaji;
                                }
                                return yatisResult.sonucMesaji;
                            }
                        }
                    }
                    return TTUtils.CultureService.GetText("M26176", "İşlem başarısız.");
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public VefatKayitBilgileriDTO VefatKayit(VefatKayitBilgileriDTO vkb)
        { 

            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    MedulaYardimciIslemler.kisiOlumKayitGirisDVO kisiOlumKayitGirisDVO = new MedulaYardimciIslemler.kisiOlumKayitGirisDVO();
                    kisiOlumKayitGirisDVO.tcKimlikNo = vkb.tc;
                    kisiOlumKayitGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                    kisiOlumKayitGirisDVO.olumTarihi = vkb.vefatTarihi.HasValue ? vkb.vefatTarihi.Value.ToString("dd.MM.yyyy") : null;

                    MedulaYardimciIslemler.kisiOlumKayitCevapDVO sonucDVO = MedulaYardimciIslemler.WebMethods.kisiVefatKayitSync(Sites.SiteLocalHost, kisiOlumKayitGirisDVO);
                    if (sonucDVO != null) {
                        vkb.sonucKoduMesaji = sonucDVO.sonucKodu + " - " + sonucDVO.sonucMesaji;
                        if(sonucDVO.kisiOlumKayitDetay != null && sonucDVO.kisiOlumKayitDetay.Length > 0)
                        {
                            vkb.adi = sonucDVO.kisiOlumKayitDetay[0].adi;
                            vkb.cevapTc = sonucDVO.kisiOlumKayitDetay[0].tcKimlikNo;
                            vkb.cevapVefatTarihi = sonucDVO.kisiOlumKayitDetay[0].olumTarihi;
                            vkb.soyadi = sonucDVO.kisiOlumKayitDetay[0].soyadi;
                            vkb.tesis = sonucDVO.kisiOlumKayitDetay[0].saglikTesisKodu.ToString();
                        }
                    }
                    return vkb;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public string YatisCikisKayitIptal(YatisCikisKayitModel yckm)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    SubEpisodeProtocol sep = objectContext.GetObject(yckm.sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                    if (!string.IsNullOrEmpty(sep.MedulaBasvuruNo) && !string.IsNullOrEmpty(sep.MedulaTakipNo))
                    {
                        if (yckm.ClinicDischargeDate != null && yckm.ClinicDischargeDate != "-")
                        {
                            HastaKabulIslemleri.hastaCikisCevapDVO yatisResult = sep.HastaCikisKayitIptalFromMedula(yckm.ClinicDischargeDate);
                            if (yatisResult != null)
                            {
                                return yatisResult.sonucMesaji;
                            }
                        }
                    }
                    return TTUtils.CultureService.GetText("M26176", "İşlem başarısız.");
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public MedulaYardimciIslemler.doktorAraCevapDVO DoktorAra(XXXXXXMedulaServices.DoktorAraGirisDVO searchModel)
        {
            XXXXXXMedulaServices XXXXXXMedulaService = new XXXXXXMedulaServices();
            return XXXXXXMedulaService.DoktorAra(searchModel);
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public MedulaYardimciIslemler.ilacAraCevapDVO IlacAra(XXXXXXMedulaServices.IlacAraGirisDVO searchModel)
        {
            XXXXXXMedulaServices XXXXXXMedulaService = new XXXXXXMedulaServices();
            return XXXXXXMedulaService.IlacAra(searchModel);
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public MedulaYardimciIslemler.tesisYatakSorguCevapDVO TesisYatakSorgu(XXXXXXMedulaServices.TesisYatakSorguGirisDVO searchModel)
        {
            XXXXXXMedulaServices XXXXXXMedulaService = new XXXXXXMedulaServices();
            if (!string.IsNullOrEmpty(searchModel.tarih))
                searchModel.tarih = Convert.ToDateTime(searchModel.tarih).ToString("dd.MM.yyyy");
            return XXXXXXMedulaService.TesisYatakSorgu(searchModel);
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public List<SuitableFTRTransaction> TedaviRaporuOkuGetTransactions([FromQuery] Guid sepObjectID, [FromQuery] long raporTakipNo, [FromQuery]string TC)
        {
            List<SuitableFTRTransaction> result = new List<SuitableFTRTransaction>();
            using (var objectContext = new TTObjectContext(false))
            {
                SubEpisodeProtocol sep = objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                List<SubEpisodeProtocol> sepList = sep.SEPMaster.SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled).ToList();
                FTRTedaviRaporuOkuDTOList reports = TedaviRaporuOkuFTR(TC);
                FTRTedaviRaporuOkuDTO report = reports.raporList.Where(r => r.raporTakipNo == raporTakipNo).FirstOrDefault();
                foreach (var innerSEP in sepList)
                {
                    //List<AccountTransaction> actList = innerSEP.AccountTransactions.Select(" CURRENTSTATEDEFID <> '" + AccountTransaction.States.Cancelled + "' AND EXTERNALCODE = '" + report.butKodu + "'").ToList();
                    BindingList<AccountTransaction.GetTrxForFTR_Class> actList = AccountTransaction.GetTrxForFTR(innerSEP.ObjectID, report.butKodu, Convert.ToDateTime(report.raporBaslangicTarihi), Convert.ToDateTime(report.raporBitisTarihi));
                    foreach (var innerAccT in actList)
                    {
                        SuitableFTRTransaction resultItem = new SuitableFTRTransaction();
                        resultItem.accTrxObjectID = innerAccT.Accobjectid.Value;
                        resultItem.CurrentState = innerAccT.Statetext.ToString();
                        resultItem.CurrentStateDefID = innerAccT.CurrentStateDefID;
                        resultItem.Description = innerAccT.Description;
                        resultItem.ExternalCode = innerAccT.ExternalCode;
                        resultItem.Id = innerAccT.Id.ToString();
                        resultItem.MedulaProvisionDate = innerAccT.MedulaProvizyonTarihi;
                        resultItem.MedulaProvisionNo = innerAccT.MedulaTakipNo;
                        resultItem.sepObjectID = innerAccT.Sepobjectid.Value;
                        resultItem.TransactionDate = innerAccT.TransactionDate;
                        resultItem.MedulaReportNo = innerAccT.MedulaReportNo;
                        result.Add(resultItem);
                    }
                }
            }
            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public FTRTedaviRaporuOkuDTOList TedaviRaporuOkuFTR([FromQuery] string TC)
        {
            RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
            FTRTedaviRaporuOkuDTOList result = new FTRTedaviRaporuOkuDTOList();
            _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            _raporOkuTCKimlikNodanDVO.raporTuru = "1";
            _raporOkuTCKimlikNodanDVO.tckimlikNo = TC;

            RaporIslemleri.raporCevapTCKimlikNodanDVO response = RaporIslemleri.WebMethods.raporBilgisiBulTCKimlikNodanSync(Sites.SiteLocalHost, _raporOkuTCKimlikNodanDVO);

            if (response != null)
            {
                if (!response.sonucKodu.Equals(0))
                    result.totalMessage = "Sonuc Açıklaması : " + response.sonucAciklamasi + " Sonuç Kodu :" + response.sonucKodu;
                else if (response.raporlar == null)
                    result.totalMessage = TTUtils.CultureService.GetText("M26313", "Kişinin Herhangi Bir Tedavi Rapor Bilgisi Bulunamamıştır.");
                else if (response.sonucKodu.Equals(0))
                {
                    result.totalMessage = TTUtils.CultureService.GetText("M26622", "Okuma İşlemi Başarı İle Sonuçlandı.");
                    using (var objectContext = new TTObjectContext(false))
                    {
                        BindingList<FTRVucutBolgesi> fTRVucutBolgesiList = FTRVucutBolgesi.GetFTRVucutBolgesi(objectContext);
                        foreach (RaporIslemleri.raporCevapDVO item in response.raporlar)
                        {

                            if (item.tedaviRapor != null)
                            {
                                if (item.tedaviRapor.tedaviRaporTuru == 7 || item.tedaviRapor.tedaviRaporTuru == 5)
                                {
                                    if (item.tedaviRapor.islemler != null && item.tedaviRapor.islemler.Length > 0)
                                    {
                                        foreach (var innerItem in item.tedaviRapor.islemler)
                                        {
                                            if (innerItem.ftrRaporBilgisi != null)
                                            {
                                                FTRTedaviRaporuOkuDTO resultItem = new FTRTedaviRaporuOkuDTO();
                                                if (item.tedaviRapor.raporDVO != null)
                                                {
                                                    resultItem.raporBaslangicTarihi = item.tedaviRapor.raporDVO.baslangicTarihi;
                                                    resultItem.raporBitisTarihi = item.tedaviRapor.raporDVO.bitisTarihi;
                                                    resultItem.raporTakipNo = item.raporTakipNo;
                                                    result.nameSurname = item.tedaviRapor.raporDVO.hakSahibi.adi + " " + item.tedaviRapor.raporDVO.hakSahibi.soyadi;
                                                    resultItem.aciklama = item.tedaviRapor.raporDVO.aciklama;
                                                    resultItem.protocolNo = item.tedaviRapor.raporDVO.protokolNo;
                                                    resultItem.protocolTarihi = item.tedaviRapor.raporDVO.protokolTarihi;
                                                    resultItem.tesisKodu = item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu;
                                                    resultItem.raporTarihi = item.tedaviRapor.raporDVO.raporBilgisi.tarih;
                                                    foreach (var itemDr in item.tedaviRapor.raporDVO.doktorlar)
                                                    {
                                                        resultItem.doktorlar.Add(itemDr.drAdi + " " + itemDr.drSoyadi + " | " + itemDr.drBransKodu + " | " + itemDr.drTescilNo + " \n");
                                                    }
                                                    foreach (var itemTani in item.tedaviRapor.raporDVO.tanilar)
                                                    {
                                                        resultItem.tanilar.Add(itemTani.taniKodu + " \n");
                                                    }
                                                }
                                                resultItem.butKodu = innerItem.ftrRaporBilgisi.butKodu;// getGroupFromButCode (innerItem.ftrRaporBilgisi.butKodu);
                                                resultItem.seansGun = innerItem.ftrRaporBilgisi.seansGun;
                                                resultItem.seansSayi = innerItem.ftrRaporBilgisi.seansSayi;
                                                resultItem.vucutBolgesi = fTRVucutBolgesiList.Where(x => x.ftrVucutBolgesiKodu == innerItem.ftrRaporBilgisi.ftrVucutBolgesiKodu).Select(x => x.ftrVucutBolgesiAdi).FirstOrDefault();
                                                if (innerItem.ftrRaporBilgisi.tedaviTuru != null)
                                                {
                                                    TedaviTuru tt = TedaviTuru.GetTedaviTuru(innerItem.ftrRaporBilgisi.tedaviTuru);
                                                    if (tt != null)
                                                        resultItem.tedaviTuru = tt.tedaviTuruAdi;
                                                }

                                                result.raporList.Add(resultItem);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (result.raporList.Count == 0)
                    result.totalMessage = TTUtils.CultureService.GetText("M26312", "Kişinin Herhangi Bir FTR Tipinde Tedavi Rapor Bilgisi Bulunamamıştır.");
            }
            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public IlacRaporuOkuDTOList IlacRaporOkuFromTC([FromQuery] string TC)
        {
            RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
            IlacRaporuOkuDTOList result = new IlacRaporuOkuDTOList();
            _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            _raporOkuTCKimlikNodanDVO.raporTuru = "10";
            _raporOkuTCKimlikNodanDVO.tckimlikNo = TC;

            RaporIslemleri.raporCevapTCKimlikNodanDVO response = RaporIslemleri.WebMethods.raporBilgisiBulTCKimlikNodanSync(Sites.SiteLocalHost, _raporOkuTCKimlikNodanDVO);

            if (response != null)
            {
                if (!response.sonucKodu.Equals(0))
                    result.totalMessage = "Sonuc Açıklaması : " + response.sonucAciklamasi + " Sonuç Kodu :" + response.sonucKodu;
                else if (response.raporlar == null)
                    result.totalMessage = TTUtils.CultureService.GetText("M26313", "Kişinin Herhangi Bir Tedavi Rapor Bilgisi Bulunamamıştır.");
                else if (response.sonucKodu.Equals(0))
                {
                    result.totalMessage = TTUtils.CultureService.GetText("M26622", "Okuma İşlemi Başarı İle Sonuçlandı.");
                    foreach (var item in response.raporlar)
                    {
                        if (item.ilacRapor != null && item.ilacRapor.raporDVO != null && item.ilacRapor.raporEtkinMaddeler != null)
                        {
                            foreach (var iteminner in item.ilacRapor.raporEtkinMaddeler)
                            {
                                IlacRaporuOkuDTO newItem = new IlacRaporuOkuDTO();
                                newItem.raporTakipNo = item.raporTakipNo;
                                newItem.ilacEtkinMadde = iteminner.etkinMaddeKodu;
                                newItem.basTarihi = item.ilacRapor.raporDVO.baslangicTarihi;
                                newItem.bitTarihi = item.ilacRapor.raporDVO.bitisTarihi;
                                newItem.saglikTesisKodu = item.ilacRapor.raporDVO.raporBilgisi.raporTesisKodu;

                                if (item.ilacRapor.raporDVO.hakSahibi != null)
                                    result.nameSurname = item.ilacRapor.raporDVO.hakSahibi.adi + " " + item.ilacRapor.raporDVO.hakSahibi.soyadi;

                                result.raporList.Add(newItem);
                            }
                        }

                    }

                }
                if (result.raporList.Count == 0)
                    result.totalMessage = TTUtils.CultureService.GetText("M26312", "Kişinin Herhangi Bir FTR Tipinde Tedavi Rapor Bilgisi Bulunamamıştır.");
            }
            return result;
        }
        private string getGroupFromButCode(string butCode)
        {
            if (butCode.Equals("P915033"))
                return TTUtils.CultureService.GetText("M25092", "A Grubu (") + butCode + ")";
            else if (butCode.Equals("P915032"))
                return TTUtils.CultureService.GetText("M25218", "B Grubu (") + butCode + ")";
            else if (butCode.Equals("P915031"))
                return TTUtils.CultureService.GetText("M25354", "C Grubu (") + butCode + ")";
            else if (butCode.Equals("P915030"))
                return TTUtils.CultureService.GetText("M25384", "D Grubu (") + butCode + ")";
            else
                return TTUtils.CultureService.GetText("M27041", "Tanımsız (") + butCode + ")";
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri, TTRoleNames.Hasta_Kabul_Kurum_Degistirme)]
        public MedulaResult mustehaklikSorgusu([FromQuery] Guid sepObjectID, [FromQuery] string date = null)
        {
            MedulaResult result = new MedulaResult();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    SubEpisodeProtocol sep = objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                    result = sep.mustehaklikSorgusuFromMedula(date);
                    InvoiceLog.AddInfo("Müstehaklık sorgusu başarılı. Referans takip numarası:" + result.TakipNo, sepObjectID, InvoiceOperationTypeEnum.TakipAl, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);

                }
                catch (Exception ex)
                {
                    InvoiceLog.AddException(ex.Message + " - " + ex.StackTrace, sepObjectID, InvoiceOperationTypeEnum.TakipAl, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                    throw new TTException(TTUtils.CultureService.GetText("M26998", "Takip alınırken bir hata oluştu, lütfen logları kontrol ediniz."), ex);
                }

                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        public class SaveNewPayerModel
        {
            public Guid newPayer { get; set; }
            public Guid newProtocol { get; set; }
            public Guid sepObjectID { get; set; }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Kurumsal_Islemler, TTRoleNames.Hasta_Kabul_Kurum_Degistirme)]
        public Guid SaveNewPayer(SaveNewPayerModel snpm)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    if (snpm.newPayer == Guid.Empty)
                        throw new TTException(TTUtils.CultureService.GetText("M25843", "Hastanın Kurum bilgisini kontrol ediniz."));

                    if (snpm.newProtocol == Guid.Empty)
                        throw new TTException(TTUtils.CultureService.GetText("M25823", "Hastanın Anlaşma bilgisini kontrol ediniz."));

                    SubEpisodeProtocol sep = objectContext.GetObject(snpm.sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;

                    Guid returnValue = sep.SubEpisode.Episode.ChangeAllSEPsPayerAndProtocol(snpm.newPayer, snpm.newProtocol, sep);

                    objectContext.Save();
                    objectContext.FullPartialllyLoadedObjects();

                    return returnValue;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public class AddNewPayerModel
        {
            public Guid Payer { get; set; }
            public Guid Protocol { get; set; }
            public List<Guid> Subepisodes { get; set; }

            public AddNewPayerModel()
            {
                this.Subepisodes = new List<Guid>();
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Kurumsal_Islemler)]
        public Guid AddNewPayer(AddNewPayerModel sanp)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                Guid sepObjectID = new Guid();
                foreach (Guid item in sanp.Subepisodes)
                {
                    SubEpisode se = objectContext.GetObject(item, typeof(SubEpisode)) as SubEpisode;

                    sepObjectID = se.AddNewPayer(sanp.Payer, sanp.Protocol);
                }
                objectContext.Save();
                objectContext.FullPartialllyLoadedObjects();
                return sepObjectID;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public List<UTSMaterialDTO> GetUTSMaterials([FromQuery] Guid sepObjectID)
        {
            List<UTSMaterialDTO> result = new List<UTSMaterialDTO>();

            using (var objectContext = new TTObjectContext(true))
            {
                SubEpisodeProtocol sep = objectContext.GetObject<SubEpisodeProtocol>(sepObjectID);
                List<Guid> sepList = sep.SEPMaster.SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && x.Payer.IsSGK).Select(x => x.ObjectID).ToList();

                BindingList<AccountTransaction> UTSAccTrxList = AccountTransaction.GetTrxsForUTS(objectContext, sepList);
                foreach (AccountTransaction accTrx in UTSAccTrxList)
                {
                    UTSMaterialDTO utsMaterial = new UTSMaterialDTO();
                    utsMaterial.objectID = accTrx.ObjectID;
                    utsMaterial.id = accTrx.Id.ToString();
                    utsMaterial.transactionDate = accTrx.MedulaTransactionDate;
                    utsMaterial.description = accTrx.Description;
                    utsMaterial.utsUsageCommitment = accTrx.UTSUsageCommitment.HasValue ? accTrx.UTSUsageCommitment.Value : false;
                    utsMaterial.resultCode = accTrx.MedulaResultCode;
                    utsMaterial.resultMessage = accTrx.MedulaResultMessage;
                    result.Add(utsMaterial);
                }
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public UXXXXXXesinlestirmeSorguSonucDTO UXXXXXXullanimKesinlestirmeSorgu([FromQuery] Guid sepObjectID)
        {
            UXXXXXXesinlestirmeSorguSonucDTO sorguSonuc = new UXXXXXXesinlestirmeSorguSonucDTO();
            try
            {
                using (var objectContext = new TTObjectContext(true))
                {
                    SubEpisodeProtocol sep = objectContext.GetObject<SubEpisodeProtocol>(sepObjectID);

                    FaturaKayitIslemleri.utsKesinlestirmeSorguGirisDVO utsKesinlestirmeSorguGirisDVO = new FaturaKayitIslemleri.utsKesinlestirmeSorguGirisDVO();
                    utsKesinlestirmeSorguGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                    utsKesinlestirmeSorguGirisDVO.tckNo = sep.SubEpisode.Episode.Patient.UniqueRefNo.HasValue ? sep.SubEpisode.Episode.Patient.UniqueRefNo.ToString() : null;

                    FaturaKayitIslemleri.utsKesinlestirmeSorguCevapDVO result = FaturaKayitIslemleri.WebMethods.utsKullanimKesinlestirmeSorguSync(Sites.SiteLocalHost, utsKesinlestirmeSorguGirisDVO);
                    sorguSonuc.message = result.sonucKodu + " - " + result.sonucMesaji;
                    if (result.sonucKodu.Equals("0000"))
                    {
                        foreach (FaturaKayitIslemleri.utsKesinlestirmeKayitDVO kayit in result.utsKesinlestirmeKayitDVO)
                        {
                            UXXXXXXesinlestirmeSorguDTO detail = new UXXXXXXesinlestirmeSorguDTO();
                            detail.kullanimBildirimID = kayit.kullanimBildirimID;
                            detail.saglikTesisKodu = kayit.saglikTesisKodu.ToString();
                            detail.tcKimlikNo = kayit.TCKimlikNo;
                            detail.seriNo = kayit.seriNo;
                            detail.lotNo = kayit.lotNo;
                            detail.hizmetSunucuReferansNo = kayit.hizmetSunucuReferansNo;
                            detail.takipNo = kayit.takipNo;
                            detail.durum = kayit.durum;
                            sorguSonuc.detailList.Add(detail);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sorguSonuc.message = ex.Message;
            }

            return sorguSonuc;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public MedulaResult UXXXXXXullanimKesinlestirme(List<UTSMaterialDTO> selectedUTSMaterials)
        {
            MedulaResult result = new MedulaResult();
            if (selectedUTSMaterials.Count > 0)
            {
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    try
                    {
                        List<AccountTransaction> accTrxList = new List<AccountTransaction>();
                        foreach (UTSMaterialDTO utsMaterial in selectedUTSMaterials)
                        {
                            AccountTransaction accTrx = objectContext.GetObject<AccountTransaction>(utsMaterial.objectID);
                            accTrxList.Add(accTrx);
                        }

                        if (accTrxList.Count > 0)
                        {
                            result = accTrxList[0].SubEpisodeProtocol.SEPMaster.UTSUsageCommitment(accTrxList);
                            objectContext.Save();
                            objectContext.FullPartialllyLoadedObjects();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new TTException(ex.Message);
                    }
                }
            }

            return result;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public List<MedulaResult> UXXXXXXullanimKesinlestirmeIptal(List<UTSMaterialDTO> selectedUTSMaterials)
        {
            List<MedulaResult> result = new List<MedulaResult>();
            if (selectedUTSMaterials.Count > 0)
            {
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    try
                    {
                        List<AccountTransaction> accTrxList = new List<AccountTransaction>();
                        foreach (UTSMaterialDTO utsMaterial in selectedUTSMaterials)
                        {
                            AccountTransaction accTrx = objectContext.GetObject<AccountTransaction>(utsMaterial.objectID);
                            accTrxList.Add(accTrx);
                        }

                        if (accTrxList.Count > 0)
                        {
                            result = accTrxList[0].SubEpisodeProtocol.UTSUsageCommitmentCancel(accTrxList);
                            objectContext.Save();
                            objectContext.FullPartialllyLoadedObjects();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new TTException(ex.Message);
                    }
                }
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public Guid GetEpisodeActionObjectIDForSEP(Guid sepObjectID)
        {
            TTObjectContext context = new TTObjectContext(true);
            SubEpisodeProtocol sep = context.GetObject<SubEpisodeProtocol>(sepObjectID, false);
            if (sep != null)
            {
                EpisodeAction ea = sep.SubEpisode.EpisodeActions.FirstOrDefault(x => !x.IsCancelled);
                if (ea != null)
                    return ea.ObjectID;
            }

            return Guid.Empty;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public MedulaDokumanIslemModel GetUploadedDocuments([FromQuery] Guid sepObjectID)
        {
            MedulaDokumanIslemModel result = new MedulaDokumanIslemModel();

            using (var objectContext = new TTObjectContext(true))
            {
                SubEpisodeProtocol sep = objectContext.GetObject<SubEpisodeProtocol>(sepObjectID);
                result.header.takipNo = sep.MedulaTakipNo;

                BindingList<UploadedDocument> documentList = objectContext.QueryObjects<UploadedDocument>(" EPISODE = '" + sep.SubEpisode.Episode.ObjectID + "'");

                foreach (UploadedDocument document in documentList)
                {
                    UploadedDocumentModel upDoc = new UploadedDocumentModel();
                    upDoc.objectID = document.ObjectID;
                    upDoc.protocolNo = document?.SubEpisode?.ProtocolNo;
                    upDoc.dosyaTuru = document.DosyaTuru != null ? document.DosyaTuru.dosyaTuruKodu + " : " + document.DosyaTuru.dosyaTuruAdi : null;
                    upDoc.dosyaAdi = document.FileName;
                    upDoc.explanation = document.Explanation;
                    //upDoc.uploadDate = document.UploadDate.HasValue ? document.UploadDate.Value.ToString("dd.MM.yyyy") : null;
                    //upDoc.uploadUser = document?.Uploader?.Name;

                    MedulaDocumentEntry medulaDocumentEntry = sep.MedulaDocumentEntries.FirstOrDefault(x => x.UploadedDocument.ObjectID == document.ObjectID && x.CurrentStateDefID == MedulaDocumentEntry.States.Saved);
                    if (medulaDocumentEntry != null)
                    {
                        upDoc.kayitReferansNo = medulaDocumentEntry.ReferenceNo;
                        upDoc.evrakId = medulaDocumentEntry.EvrakId;
                        upDoc.takipNo = medulaDocumentEntry.TakipNo;
                    }
                    result.documentArray.Add(upDoc);
                }
            }

            return result;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public MedulaTakipDokumanSorguSonucModel MedulaTakipDokumanListesiSorgu(MedulaTakipDokumanSorguModel request)
        {
            MedulaTakipDokumanSorguSonucModel sorguSonuc = new MedulaTakipDokumanSorguSonucModel();
            try
            {
                using (var objectContext = new TTObjectContext(true))
                {
                    SubEpisodeProtocol sep = objectContext.GetObject<SubEpisodeProtocol>(request.header.sepObjectID);

                    if (string.IsNullOrWhiteSpace(sep.MedulaTakipNo))
                        throw new TTException("Sorgulama yapabilmek için Takip Numarası dolu olmalıdır.");

                    if (!request.header.evrakId.HasValue)
                        throw new TTException("Sorgulama yapabilmek için Evrak No dolu olmalıdır.");

                    EvrakDokumanIslemleri.evrakDokumanListesiDVO evrakDokumanListesiDVO = new EvrakDokumanIslemleri.evrakDokumanListesiDVO();
                    evrakDokumanListesiDVO.evrakId = request.header.evrakId.Value;
                    evrakDokumanListesiDVO.takipNo = sep.MedulaTakipNo;
                    evrakDokumanListesiDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

                    EvrakDokumanIslemleri.evrakDokumanListesiCevapDVO result = EvrakDokumanIslemleri.WebMethods.takipDokumanListesiSync(Sites.SiteLocalHost, evrakDokumanListesiDVO);
                    sorguSonuc.message = result.sonucKodu + " - " + result.sonucMesaji;
                    if (result.sonucKodu.Equals("0000"))
                    {
                        BindingList<DosyaTuru> dosyaTurList = objectContext.QueryObjects<DosyaTuru>();

                        foreach (EvrakDokumanIslemleri.evrakDokumanDVO evrakDokumanDVO in result.dokumanlar)
                        {
                            MedulaTakipDokumanModel document = new MedulaTakipDokumanModel();
                            document.evrakId = result.evrakId;
                            document.takipNo = result.takipNo;
                            document.kayitReferansNo = evrakDokumanDVO.kayitReferansNo;
                            document.islemSiraNo = evrakDokumanDVO.islemSiraNo.ToString();

                            DosyaTuru dosyaTuru = dosyaTurList.FirstOrDefault(x => x.dosyaTuruKodu == evrakDokumanDVO.turu);
                            if (dosyaTuru != null)
                                document.dosyaTuru = dosyaTuru.dosyaTuruKodu + " : " + dosyaTuru.dosyaTuruAdi;
                            else
                                document.dosyaTuru = evrakDokumanDVO.turu.ToString();

                            document.dosyaAdi = evrakDokumanDVO.dosyaAdi;
                            sorguSonuc.medulaDocumentArray.Add(document);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sorguSonuc.message = ex.Message;
            }

            return sorguSonuc;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public List<MedulaResult> MedulaDokumanKaydet(MedulaDokumanIslemModel request)
        {
            List<MedulaResult> result = new List<MedulaResult>();

            if (request.documentArray.Count > 0)
            {
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    try
                    {
                        SubEpisodeProtocol sep = objectContext.GetObject<SubEpisodeProtocol>(request.header.sepObjectID);

                        List<UploadedDocument> documentList = new List<UploadedDocument>();
                        foreach (UploadedDocumentModel doc in request.documentArray)
                        {
                            UploadedDocument document = objectContext.GetObject<UploadedDocument>(doc.objectID);
                            documentList.Add(document);
                        }

                        if (documentList.Count > 0)
                        {
                            result = sep.SaveMedulaDocument(request.header.evrakId, documentList);
                            objectContext.Save();
                            objectContext.FullPartialllyLoadedObjects();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new TTException(ex.Message);
                    }
                }
            }

            return result;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public List<MedulaResult> MedulaDokumanSil(MedulaDokumanIslemModel request)
        {
            List<MedulaResult> result = new List<MedulaResult>();

            if (request.documentArray.Count > 0)
            {
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    try
                    {
                        SubEpisodeProtocol sep = objectContext.GetObject<SubEpisodeProtocol>(request.header.sepObjectID);

                        List<UploadedDocument> documentList = new List<UploadedDocument>();
                        foreach (UploadedDocumentModel doc in request.documentArray)
                        {
                            UploadedDocument document = objectContext.GetObject<UploadedDocument>(doc.objectID);
                            documentList.Add(document);
                        }

                        if (documentList.Count > 0)
                        {
                            result = sep.DeleteMedulaDocument(request.header.evrakId, documentList);
                            objectContext.Save();
                            objectContext.FullPartialllyLoadedObjects();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new TTException(ex.Message);
                    }
                }
            }

            return result;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public BarcodeSUTMatchModel MedulaBarcodeSUTMatchQuery(BarcodeSUTMatchDetailModel request)
        {
            BarcodeSUTMatchModel result = new BarcodeSUTMatchModel();
            try
            {
                MedulaYardimciIslemler.barkodSutEslesmeSorguGirisDVO girisDVO = new MedulaYardimciIslemler.barkodSutEslesmeSorguGirisDVO();
                girisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                girisDVO.tarih = request.tarih.HasValue ? request.tarih.Value.ToString("dd.MM.yyyy") : null;
                girisDVO.barkod = request.barkod;
                girisDVO.firmaTanimlayiciNo = request.firmaTanimlayiciNo;
                girisDVO.sutKodu = request.sutKodu;

                MedulaYardimciIslemler.barkodSutEslesmeSorguCevapDVO sonucDVO = MedulaYardimciIslemler.WebMethods.barkodSutEslesmeSorguSync(Sites.SiteLocalHost, girisDVO);
                result.resultMessage = sonucDVO.sonucKodu + " - " + sonucDVO.sonucMesaji;
                if (sonucDVO.sonucKodu.Equals("0000"))
                {
                    foreach (MedulaYardimciIslemler.barkodSutDVO barkodSutDVO in sonucDVO.eslesmeler)
                    {
                        BarcodeSUTMatchDetailModel match = new BarcodeSUTMatchDetailModel()
                        {
                            barkod = barkodSutDVO.barkod,
                            firmaTanimlayiciNo = barkodSutDVO.firmaTanimlayiciNo,
                            sutKodu = barkodSutDVO.sutKodu,
                            baslangicTarihi = barkodSutDVO.baslangicTarihi,
                            bitisTarihi = barkodSutDVO.bitisTarihi
                        };
                        result.medulaBarcodeSUTMatchArray.Add(match);
                    }
                }
            }
            catch (Exception ex)
            {
                result.resultMessage = ex.Message;
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public List<ENabizBildirimHizmetModel> GetENabizNotification([FromQuery] Guid sepObjectID)
        {
            List<ENabizBildirimHizmetModel> result = new List<ENabizBildirimHizmetModel>();

            using (var objectContext = new TTObjectContext(true))
            {
                SubEpisodeProtocol sep = objectContext.GetObject<SubEpisodeProtocol>(sepObjectID, false);

                if (sep == null)
                    throw new TTException("Takip bulunamadı.");

                if (string.IsNullOrWhiteSpace(sep.MedulaTakipNo))
                    throw new TTException("Sorgulama yapabilmek için Takip Numarası dolu olmalıdır.");

                MedulaYardimciIslemler.eNabizBildirimSorguGirisDVO girisDVO = new MedulaYardimciIslemler.eNabizBildirimSorguGirisDVO()
                {
                    saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu(),
                    takipNo = sep.MedulaTakipNo
                };

                MedulaYardimciIslemler.eNabizBildirimSorguCevapDVO sonucDVO = MedulaYardimciIslemler.WebMethods.eNabizBildirimSorguSync(Sites.SiteLocalHost, girisDVO);
                if (sonucDVO.sonucKodu.Equals("0000"))
                {
                    foreach (MedulaYardimciIslemler.eNabizHizmetBilgiDVO eNabizHizmet in sonucDVO.hizmetler)
                    {
                        ENabizBildirimHizmetModel hizmet = new ENabizBildirimHizmetModel()
                        {
                            hizmetSunucuRefNo = eNabizHizmet.hizmetSunucuRefNo,
                            islemKodu = eNabizHizmet.islemKodu,
                            islemTarihi = eNabizHizmet.islemTarihi
                        };
                        result.Add(hizmet);
                    }
                }
                else
                    throw new TTException(sonucDVO.sonucKodu + " " + sonucDVO.sonucMesaji);
            }

            return result;
        }
    }
}