
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


using static TTObjectClasses.SubEpisodeProtocol;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TTObjectClasses
{
    /// <summary>
    /// Fatura ekranındaki toplu işlemlerin master objesi
    /// </summary>
    public partial class CollectiveInvoiceOp : TTObject
    {
        //public static void ExecuteCollectiveOperation()
        //{
        //    using (var objectContext = new TTObjectContext(true))
        //    {
        //        List<Guid> states = new List<Guid>();
        //        states.Add(CollectiveInvoiceOp.States.New);
        //        BindingList<CollectiveInvoiceOp> listOfCio = CollectiveInvoiceOp.GetByStartDateAndStates(objectContext, DateTime.Now, states);

        //        foreach(var item in listOfCio)
        //        {
        //            if(item.PayerType == PayerTypeEnum.SGK)// SGK dışında arka planda toplu yapılacak işlem yok.
        //                ExecuteSingleCollectiveOperation(item.ObjectID);

        //            break;
        //        }
        //    }
        //}

        public void ExecuteOnTaskOperation(Guid? cioObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(false);
            BindingList<CollectiveInvoiceOp> execCioList = new BindingList<CollectiveInvoiceOp>();
            List<Guid> states = new List<Guid>();
            states.Add(CollectiveInvoiceOp.States.New);
            states.Add(CollectiveInvoiceOp.States.Started);
            states.Add(CollectiveInvoiceOp.States.Pending);

            if (cioObjectID == null && !cioObjectID.HasValue)
                execCioList = CollectiveInvoiceOp.GetByStartDateAndStates(objectcontext, DateTime.Now, states, " AND EXECTYPE = " + (int)CollectiveInvoiceExecType.Ontask);
            else
            {
                CollectiveInvoiceOp cio = objectcontext.GetObject<CollectiveInvoiceOp>(cioObjectID.Value) as CollectiveInvoiceOp;
                if (cio.ExecType == CollectiveInvoiceExecType.Ontask && states.Contains(cio.CurrentStateDefID.Value))
                    execCioList.Add(cio);
            }
            if (execCioList != null && execCioList.Count > 0)
            {
                foreach (var item in execCioList)
                {
                    Guid firstObjectID = Guid.Empty;
                    CollectiveInvoiceOp cio = objectcontext.GetObject<CollectiveInvoiceOp>(item.ObjectID) as CollectiveInvoiceOp;
                    bool conti = false;
                    int i = 0;
                    do
                    {
                        if (cio.CollectiveInvoiceOpDetails.Select("").Count(x => x.CurrentStateDefID == CollectiveInvoiceOpDetail.States.New) > 0)
                        {
                            cio.CurrentStateDefID = CollectiveInvoiceOp.States.Started;
                            objectcontext.Save();
                            CollectiveInvoiceOp.ExecuteSingleCollectiveOperation(cio.ObjectID, true);

                            if (i != 0)
                            {
                                cio.CurrentStateDefID = CollectiveInvoiceOp.States.Ended;
                                cio.EndDate = DateTime.Now;
                                objectcontext.Save();
                            }
                        }
                        if (i == 0)
                            firstObjectID = cio.ObjectID;
                        i++;
                        conti = false;
                        if (cio.NextCIO != null)
                        {
                            conti = true;
                            cio = cio.NextCIO;
                        }

                    } while (conti);
                    CollectiveInvoiceOp cioFirst = objectcontext.GetObject<CollectiveInvoiceOp>(firstObjectID);
                    cioFirst.CurrentStateDefID = CollectiveInvoiceOp.States.Ended;
                    cioFirst.EndDate = DateTime.Now;
                    objectcontext.Save();
                }
            }
        }

        public static void ExecuteSingleCollectiveOperation(Guid ObjectID, bool fromAutoScript = false)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            CollectiveInvoiceOp cio = objectContext.GetObject<CollectiveInvoiceOp>(ObjectID) as CollectiveInvoiceOp;

            if (!fromAutoScript)
            {
                cio.CurrentStateDefID = CollectiveInvoiceOp.States.Started;
                objectContext.Save();
            }

            if (cio != null && (cio.PayerType == PayerTypeEnum.SGK || cio.PayerType == PayerTypeEnum.Official))
            {
                switch (cio.OpType)
                {
                    case CollectiveInvoiceOpTypeEnum.GetProvision:
                    case CollectiveInvoiceOpTypeEnum.DeleteProvision:
                    case CollectiveInvoiceOpTypeEnum.SaveProcedure:
                    case CollectiveInvoiceOpTypeEnum.DeleteProcedure:
                    case CollectiveInvoiceOpTypeEnum.RunRule:
                    case CollectiveInvoiceOpTypeEnum.ChangeDoctor:
                    case CollectiveInvoiceOpTypeEnum.AddDiagnosis:
                    case CollectiveInvoiceOpTypeEnum.AddDescription:
                    case CollectiveInvoiceOpTypeEnum.SetDonotSendMedula:
                    case CollectiveInvoiceOpTypeEnum.SendNabiz:
                    case CollectiveInvoiceOpTypeEnum.SendNabiz700:
                        sepBasedCollectiveOperations(ObjectID);
                        break;
                    case CollectiveInvoiceOpTypeEnum.SaveInvoice:
                    case CollectiveInvoiceOpTypeEnum.DeleteInvoice:
                    case CollectiveInvoiceOpTypeEnum.ReadInvoicePrice:
                    case CollectiveInvoiceOpTypeEnum.AddInvoiceCollection:
                    case CollectiveInvoiceOpTypeEnum.RemoveInvoiceCollection:
                    case CollectiveInvoiceOpTypeEnum.Fix1108:
                    case CollectiveInvoiceOpTypeEnum.Fix1108AndInvoice:
                    case CollectiveInvoiceOpTypeEnum.Fix1108AndReadInvoice:
                    case CollectiveInvoiceOpTypeEnum.ArrangeInvoice:
                        saveInvoiceCollectiveOperation(ObjectID);
                        break;
                    default:
                        throw new TTException(TTUtils.CultureService.GetText("M27141", "Uygun çalıştırma methodu bulunamadı."));
                }
            }

            if (!fromAutoScript)
            {
                cio.CurrentStateDefID = CollectiveInvoiceOp.States.Ended;
                cio.EndDate = DateTime.Now;
                objectContext.Save();
            }
        }
        public class fix1108Model : CollectiveInvoiceOp.invoiceTaskModel
        {
            public string firstSutCode { get; set; }
            public string secondSutCode { get; set; }

        }
        public class changeDoctorModel
        {
            public Guid errorCodeObjectID { get; set; }
            public Guid newDoctor { get; set; }
            public string doctorName { get; set; }
        }
        public class addDiagnosisModel
        {
            public string TaniKodu { get; set; }
            public string TaniAdi { get; set; }
            public DiagnosisDefinition Diagnose { get; set; }
            public DiagnosisTypeEnum? DiagnosisType { get; set; }
            public bool? IsMainDiagnose { get; set; }
        }
        public class addDescriptionModel
        {
            public string AccTrxDesc { get; set; }
            public string Code { get; set; }
        }
        public class setDonotSendMedulaModel
        {
            public string Code { get; set; }
            public Guid? errorCodeObjectID { get; set; }
            public Guid? StateDefID { get; set; }
        }
        public class onlyCodeModel
        {
            public string Code { get; set; }
        }
        public class invoiceTaskModel
        {
            public DateTime? faturaTarihi { get; set; }
            public string faturaAciklamasi { get; set; }
        }

        private static void saveInvoiceCollectiveOperation(Guid ObjectID)
        {
            TTObjectContext cioContext = new TTObjectContext(true);
            CollectiveInvoiceOp cio = cioContext.GetObject<CollectiveInvoiceOp>(ObjectID);

            CollectiveInvoiceOpTypeEnum typeEnum = cio.OpType.Value;
            //List<Guid> ciodGuidList = cio.CollectiveInvoiceOpDetails.Select("").Select(x => x.ObjectID).ToList();
            List<CollectiveInvoiceOpDetail> ciodList = cio.CollectiveInvoiceOpDetails.Select("").ToList();
            foreach (var item in ciodList)
            {
                try
                {
                    using (var ciodContext = new TTObjectContext(false))
                    {
                        CollectiveInvoiceOpDetail ciod = ciodContext.GetObject<CollectiveInvoiceOpDetail>(item.ObjectID);
                        if (ciod.CurrentStateDefID == CollectiveInvoiceOpDetail.States.New)
                        {
                            using (var sepContext = new TTObjectContext(false))
                            {
                                SubEpisodeProtocol sep = sepContext.GetObject<SubEpisodeProtocol>(ciod.ExecObjectID.Value);

                                bool? errorFound = false;
                                List<MedulaResult> result = new List<MedulaResult>();
                                List<SubEpisodeProtocol> sepList = null;
                                CollectiveInvoiceOp.invoiceTaskModel tempITM = null;
                                CollectiveInvoiceOp.fix1108Model tempFixModel = null;
                                if (typeEnum == CollectiveInvoiceOpTypeEnum.Fix1108 || typeEnum == CollectiveInvoiceOpTypeEnum.Fix1108AndInvoice || typeEnum == CollectiveInvoiceOpTypeEnum.Fix1108AndReadInvoice)
                                    tempFixModel = JsonConvert.DeserializeObject<CollectiveInvoiceOp.fix1108Model>(cio.ExtraData);
                                if (typeEnum == CollectiveInvoiceOpTypeEnum.SaveInvoice || typeEnum == CollectiveInvoiceOpTypeEnum.ReadInvoicePrice)
                                    tempITM = JsonConvert.DeserializeObject<CollectiveInvoiceOp.invoiceTaskModel>(cio.ExtraData);
                                switch (typeEnum)
                                {
                                    case CollectiveInvoiceOpTypeEnum.ArrangeInvoice:
                                        sepList = getSEPListFromSEP(sep);
                                        if (sepList.Count > 0)
                                        {
                                            bool tempResult = sep.SEPMaster.ArrangeInvoice(sepList);
                                            MedulaResult resultItem = new MedulaResult();
                                            resultItem.Succes = tempResult;
                                            resultItem.SEPObjectID = sep.ObjectID;
                                            resultItem.TakipNo = sep.MedulaTakipNo;
                                            result.Add(resultItem);
                                        }
                                        break;
                                    case CollectiveInvoiceOpTypeEnum.SaveInvoice:
                                        sepList = getSEPListFromSEP(sep);
                                        if (sepList.Count > 0)
                                        {
                                            result = sep.SEPMaster.SaveInvoice(sepList, tempITM.faturaTarihi.Value, tempITM.faturaAciklamasi, Guid.Empty, (int)InvoiceOperationTypeEnum.Faturalandir);

                                            if (result.FirstOrDefault().SonucKodu == "1108" && TTObjectClasses.SystemParameter.GetParameterValue("TOPLUFATURAOTOMATIKDUZELT", "FALSE") == "TRUE")
                                                result = sep.SEPMaster.Fix1108MedulaErrorCodeAndSaveInvoice(result, sepList, tempITM.faturaTarihi.Value, tempITM.faturaAciklamasi, Guid.Empty, (int)InvoiceOperationTypeEnum.Faturalandir, 0, "");
                                        }
                                        break;
                                    case CollectiveInvoiceOpTypeEnum.DeleteInvoice:
                                        result = sep.InvoiceCollectionDetail?.PayerInvoiceDocument?.Cancel();
                                        break;
                                    case CollectiveInvoiceOpTypeEnum.ReadInvoicePrice:
                                        sepList = getSEPListFromSEP(sep);
                                        if (sepList.Count > 0)
                                        {
                                            result = sep.SEPMaster.ReadInvoicePrice(sepList, tempITM.faturaTarihi.Value, tempITM.faturaAciklamasi);

                                            if (result.FirstOrDefault().SonucKodu == "1108" && TTObjectClasses.SystemParameter.GetParameterValue("TOPLUFATURAOTOMATIKDUZELT", "FALSE") == "TRUE")
                                                result = sep.SEPMaster.Fix1108MedulaErrorCodeAndSaveInvoice(result, sepList, tempITM.faturaTarihi.Value, tempITM.faturaAciklamasi, Guid.Empty, (int)InvoiceOperationTypeEnum.FaturaTutarOku, 1, "");
                                        }
                                        break;
                                    case CollectiveInvoiceOpTypeEnum.AddInvoiceCollection:
                                        InvoiceCollection ic = sepContext.GetObject<InvoiceCollection>(cio.InvoiceCollectionID.Value);
                                        InvoiceCollectionDetail icd = ic.AddInvoiceCollectionDetail(sep);
                                        if (icd != null)
                                            errorFound = false;
                                        break;
                                    case CollectiveInvoiceOpTypeEnum.RemoveInvoiceCollection:
                                        errorFound = !(sep?.InvoiceCollectionDetail?.InvoiceCollection?.RemoveInvoiceCollectionDetail(sep.InvoiceCollectionDetail, CancelledInvoiceTypeEnum.OutOfInvoiceCollection));
                                        break;
                                    case CollectiveInvoiceOpTypeEnum.Fix1108:
                                        sepList = getSEPListFromSEPErrorCode(sep, "1108");
                                        if (sepList.Count > 0)
                                        {
                                            result = sep.SEPMaster.Fix1108MedulaErrorCodeAndSaveInvoice(result, sepList, DateTime.Now, "", Guid.Empty, (int)InvoiceOperationTypeEnum.FaturaTutarOku, 2, "");
                                        }
                                        break;
                                    case CollectiveInvoiceOpTypeEnum.Fix1108AndInvoice:
                                        sepList = getSEPListFromSEPErrorCode(sep, "1108");
                                        if (sepList.Count > 0)
                                        {
                                            result = sep.SEPMaster.Fix1108MedulaErrorCodeAndSaveInvoice(result, sepList, tempFixModel.faturaTarihi.Value, tempFixModel.faturaAciklamasi, Guid.Empty, (int)InvoiceOperationTypeEnum.Faturalandir, 0, "");
                                        }
                                        break;
                                    case CollectiveInvoiceOpTypeEnum.Fix1108AndReadInvoice:
                                        sepList = getSEPListFromSEPErrorCode(sep, "1108");
                                        if (sepList.Count > 0)
                                        {
                                            result = sep.SEPMaster.Fix1108MedulaErrorCodeAndSaveInvoice(result, sepList, tempFixModel.faturaTarihi.Value, tempFixModel.faturaAciklamasi, Guid.Empty, (int)InvoiceOperationTypeEnum.FaturaTutarOku, 1, "");
                                        }
                                        break;
                                    default:
                                        throw new TTException(TTUtils.CultureService.GetText("M27141", "Uygun çalıştırma methodu bulunamadı."));
                                }

                                ciod.ExecDate = DateTime.Now;

                                foreach (var mr in result)
                                {
                                    if (!mr.Succes)
                                    {
                                        ciod.CurrentStateDefID = CollectiveInvoiceOpDetail.States.Error;
                                        ciod.ErrorCode = mr.SonucKodu;
                                        ciod.ErrorMessage = mr.SonucMesaji;
                                        ciod.MedulaTakipNo = mr.TakipNo;
                                        ciod.ProtocolNo = mr.ProtocolNo;
                                        break;
                                    }
                                    else
                                        ciod.CurrentStateDefID = CollectiveInvoiceOpDetail.States.Succes;
                                }

                                if (errorFound != null && !errorFound.Value &&
                                    (typeEnum == CollectiveInvoiceOpTypeEnum.AddInvoiceCollection || typeEnum == CollectiveInvoiceOpTypeEnum.RemoveInvoiceCollection))
                                    ciod.CurrentStateDefID = CollectiveInvoiceOpDetail.States.Succes;

                                if (sepList != null)
                                {
                                    foreach (var sepInner in sepList)
                                    {
                                        if (sepInner.ObjectID != sep.ObjectID)
                                        {
                                            var tempItem = ciodList.FirstOrDefault(x => x.ExecObjectID == sepInner.ObjectID);
                                            if (tempItem != null)
                                            {
                                                CollectiveInvoiceOpDetail ciodBySEPList = ciodContext.GetObject<CollectiveInvoiceOpDetail>(tempItem.ObjectID);
                                                ciodBySEPList.CurrentStateDefID = ciod.CurrentStateDefID;
                                                ciodBySEPList.ExecDate = ciod.ExecDate;
                                                if (!string.IsNullOrEmpty(ciod.ErrorCode))
                                                {
                                                    ciodBySEPList.ErrorCode = ciod.ErrorCode;
                                                    ciodBySEPList.ErrorMessage = ciod.ErrorMessage;
                                                }
                                            }
                                        }
                                    }
                                }
                                sepContext.Save();
                            }
                            ciodContext.Save();
                        }
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        using (var objectContextCatch = new TTObjectContext(false))
                        {
                            CollectiveInvoiceOpDetail ciodError = objectContextCatch.GetObject<CollectiveInvoiceOpDetail>(item.ObjectID);
                            SubEpisodeProtocol sepError = objectContextCatch.GetObject<SubEpisodeProtocol>(ciodError.ExecObjectID.Value);
                            ciodError.CurrentStateDefID = CollectiveInvoiceOpDetail.States.Error;
                            ciodError.ErrorCode = "AutoScript0001";
                            ciodError.ErrorMessage = ex.StackTrace + " - " + ex.Message;
                            ciodError.MedulaTakipNo = sepError.MedulaTakipNo;
                            ciodError.ProtocolNo = sepError.SubEpisode.ProtocolNo;
                            objectContextCatch.Save();
                        }
                    }
                    catch { }
                }   
            }
            cioContext.Dispose();
        }

        private static List<SubEpisodeProtocol> getSEPListFromSEP(SubEpisodeProtocol sep)
        {
            List<SubEpisodeProtocol> sepList = sep.SEPMaster.SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled
                                                                                       && x.CurrentStateDefID != SubEpisodeProtocol.States.Closed
                                                                                       && !x.IsInvoiced
                                                                                       && x.Payer.Type.PayerType == PayerTypeEnum.SGK).ToList();
            return sepList;
        }

        private static List<SubEpisodeProtocol> getSEPListFromSEPErrorCode(SubEpisodeProtocol sep, string MedulaSonucKodu)
        {
            List<SubEpisodeProtocol> sepList = sep.SEPMaster.SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled
                                                                                       && x.CurrentStateDefID != SubEpisodeProtocol.States.Closed
                                                                                       && !x.IsInvoiced && x.MedulaSonucKodu == MedulaSonucKodu
                                                                                       && x.Payer.Type.PayerType == PayerTypeEnum.SGK).ToList();
            return sepList;
        }
        private static void sepBasedCollectiveOperations(Guid ObjectID)
        {
            TTObjectContext cioContext = new TTObjectContext(true);
            CollectiveInvoiceOp cio = cioContext.GetObject<CollectiveInvoiceOp>(ObjectID) as CollectiveInvoiceOp;

            CollectiveInvoiceOpTypeEnum typeEnum = cio.OpType.Value;

            List<Guid> ciodGuidList = cio.CollectiveInvoiceOpDetails.Select("").Select(x => x.ObjectID).ToList();

            MedulaErrorCodeDefinition mecd = null;
            ResUser ru = null;
            List<CollectiveInvoiceOp.addDiagnosisModel> tempDiaGridList = null;
            CollectiveInvoiceOp.addDescriptionModel tempAddDescriptionModel = null;
            CollectiveInvoiceOp.setDonotSendMedulaModel tempSetDonotSendMedulaModel = null;
            CollectiveInvoiceOp.onlyCodeModel tempOnlyCodeModel = null;
            if (typeEnum == CollectiveInvoiceOpTypeEnum.ChangeDoctor)
            {
                var tempItem = JsonConvert.DeserializeObject<CollectiveInvoiceOp.changeDoctorModel>(cio.ExtraData);
                mecd = cioContext.GetObject<MedulaErrorCodeDefinition>(tempItem.errorCodeObjectID) as MedulaErrorCodeDefinition;
                ru = cioContext.GetObject<ResUser>(tempItem.newDoctor) as ResUser;
            }
            else if (typeEnum == CollectiveInvoiceOpTypeEnum.AddDiagnosis)
            {
                tempDiaGridList = JsonConvert.DeserializeObject<List<CollectiveInvoiceOp.addDiagnosisModel>>(cio.ExtraData);

            }
            else if (typeEnum == CollectiveInvoiceOpTypeEnum.AddDescription)
            {
                tempAddDescriptionModel = JsonConvert.DeserializeObject<CollectiveInvoiceOp.addDescriptionModel>(cio.ExtraData);
            }
            else if (typeEnum == CollectiveInvoiceOpTypeEnum.SetDonotSendMedula)
            {
                tempSetDonotSendMedulaModel = JsonConvert.DeserializeObject<CollectiveInvoiceOp.setDonotSendMedulaModel>(cio.ExtraData);
                if(tempSetDonotSendMedulaModel.errorCodeObjectID.HasValue)
                    mecd = cioContext.GetObject<MedulaErrorCodeDefinition>(tempSetDonotSendMedulaModel.errorCodeObjectID.Value) as MedulaErrorCodeDefinition;

            }
            else if (typeEnum == CollectiveInvoiceOpTypeEnum.SendNabiz)
            {
                tempOnlyCodeModel = JsonConvert.DeserializeObject<CollectiveInvoiceOp.onlyCodeModel>(cio.ExtraData);
            }

            foreach (var item in ciodGuidList)
            {
                try
                {
                    using (var ciodContext = new TTObjectContext(false))
                    {
                        CollectiveInvoiceOpDetail ciod = ciodContext.GetObject<CollectiveInvoiceOpDetail>(item);
                        if (ciod.CurrentStateDefID == CollectiveInvoiceOpDetail.States.New)
                        {
                            using (var sepContext = new TTObjectContext(false))
                            {
                                SubEpisodeProtocol sep = sepContext.GetObject<SubEpisodeProtocol>(ciod.ExecObjectID.Value);
                                MedulaResult mr = new MedulaResult();
                                string sql = "";
                                switch (typeEnum)
                                {
                                    case CollectiveInvoiceOpTypeEnum.ChangeDoctor:
                                        mr = sep.ChangeDoctorWithErrorCode(mecd, ru);
                                        break;
                                    case CollectiveInvoiceOpTypeEnum.AddDiagnosis:
                                        mr = sep.AddSEPDiagnosis(tempDiaGridList);
                                        break;
                                    case CollectiveInvoiceOpTypeEnum.AddDescription:

                                        if (!string.IsNullOrEmpty(tempAddDescriptionModel.Code))
                                            sql = " AND EXTERNALCODE = '" + tempAddDescriptionModel.Code + "' ";

                                        List<AccountTransaction> actxList = sep.AccountTransactions.
                                            Select(" CURRENTSTATEDEFID = '" + AccountTransaction.States.MedulaEntryUnsuccessful + "' AND MEDULARESULTCODE ='1299' " + sql).ToList();
                                        mr = sep.UpdateMedulaDescription(actxList, tempAddDescriptionModel.AccTrxDesc); ;
                                        break;
                                    case CollectiveInvoiceOpTypeEnum.SendNabiz:

                                        if (!string.IsNullOrEmpty(tempOnlyCodeModel.Code))
                                            sql = " AND EXTERNALCODE = '" + tempOnlyCodeModel.Code + "' ";
                                        List<AccountTransaction> accList = sep.AccountTransactions.
                                            Select(" NABIZ700STATUS = 2 " + sql).ToList();
                                        List<Guid> actxListSendNabiz = sep.AccountTransactions.
                                            Select(" NABIZ700STATUS = 2 " + sql).Select(x => x.ObjectID).ToList();
                                        sep.SendNabiz(accList);
                                        mr = sep.SendNabiz700(true, actxListSendNabiz);
                                        break;
                                    case CollectiveInvoiceOpTypeEnum.SendNabiz700:
                                        mr = sep.SendNabiz700(true, null); ;
                                        break;
                                    case CollectiveInvoiceOpTypeEnum.SetDonotSendMedula:
                                        if (!string.IsNullOrEmpty(tempSetDonotSendMedulaModel.Code))
                                            sql = " AND EXTERNALCODE = '" + tempSetDonotSendMedulaModel.Code + "' ";

                                        List<AccountTransaction> actxListToDontSend = null;
                                        if (tempSetDonotSendMedulaModel.errorCodeObjectID.HasValue)
                                        {
                                            actxListToDontSend = sep.AccountTransactions.
                                              Select(" CURRENTSTATEDEFID = '" + AccountTransaction.States.MedulaEntryUnsuccessful + "' AND MEDULARESULTCODE ='" + mecd.Code + "' " + sql).ToList();
                                        }
                                        else if(tempSetDonotSendMedulaModel.StateDefID.HasValue)
                                        {
                                            actxListToDontSend = sep.AccountTransactions.Select(" SUBACTIONPROCEDURE IS NOT NULL AND CURRENTSTATEDEFID not in ('" + AccountTransaction.States.Cancelled + "','" + AccountTransaction.States.MedulaDontSend + "') " + sql).
                                                Where(x => x.SubActionProcedure.CurrentStateDefID == tempSetDonotSendMedulaModel.StateDefID.Value || x.SubActionProcedure.EpisodeAction.CurrentStateDefID == tempSetDonotSendMedulaModel.StateDefID.Value  ).ToList();
                                        }
                                        mr = sep.UpdateMedulaCurrentState(actxListToDontSend); ;
                                        break;
                                    case CollectiveInvoiceOpTypeEnum.GetProvision:
                                        mr = sep.GetProvisionFromMedula();
                                        break;
                                    case CollectiveInvoiceOpTypeEnum.DeleteProvision:
                                        mr = sep.DeleteProvisionFromMedula();
                                        break;
                                    case CollectiveInvoiceOpTypeEnum.SaveProcedure:
                                        mr = sep.HizmetKayitSync(true);
                                        break;
                                    case CollectiveInvoiceOpTypeEnum.DeleteProcedure:
                                        mr = sep.HizmetKayitIptalSync(null, null, true);
                                        break;
                                    case CollectiveInvoiceOpTypeEnum.RunRule:
                                        mr.Succes = sep.ArrangeAllTrxs();
                                        mr.ProtocolNo = sep.SubEpisode?.ProtocolNo;
                                        mr.TakipNo = sep.MedulaTakipNo;
                                        break;
                                    default:
                                        throw new TTException(TTUtils.CultureService.GetText("M27141", "Uygun çalıştırma methodu bulunamadı."));
                                }
                                ciod.ExecDate = DateTime.Now;

                                if (mr.Succes)
                                    ciod.CurrentStateDefID = CollectiveInvoiceOpDetail.States.Succes;
                                else
                                {
                                    ciod.CurrentStateDefID = CollectiveInvoiceOpDetail.States.Error;
                                    ciod.MedulaTakipNo = mr.TakipNo;
                                    ciod.ProtocolNo = mr.ProtocolNo;
                                    ciod.ErrorCode = mr.SonucKodu;
                                    ciod.ErrorMessage = mr.SonucMesaji.Substring(0, (mr.SonucMesaji.Length < 999 ? mr.SonucMesaji.Length : 999)).Trim();
                                }
                                sepContext.Save();
                            }
                            ciodContext.Save();
                        }
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        using (var objectContextCatch = new TTObjectContext(false))
                        {
                            CollectiveInvoiceOpDetail ciodCatch = objectContextCatch.GetObject<CollectiveInvoiceOpDetail>(item) as CollectiveInvoiceOpDetail;
                            ciodCatch.CurrentStateDefID = CollectiveInvoiceOpDetail.States.Error;
                            ciodCatch.ErrorCode = "AutoScript0001";
                            ciodCatch.ErrorMessage = ex.StackTrace + " - " + ex.Message;
                            objectContextCatch.Save();
                        }
                    }
                    catch { }
                }
            }
            cioContext.Dispose();
        }
    }
}