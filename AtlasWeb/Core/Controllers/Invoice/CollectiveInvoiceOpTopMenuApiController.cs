using Infrastructure.Filters;
using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TTDataDictionary;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using static TTObjectClasses.SubEpisodeProtocol;
using TTUtils;
using TTStorageManager.Security;
using TTVisual;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using Core.Security;

namespace Core.Controllers.Invoice
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class CollectiveInvoiceOpTopMenuApiController : Controller
    {
        public class PrepareCollectiveInvoiceOpWithSearchCriteria_Model
        {
            public SubEpisodeProtocol.InvoiceSEPSearchCriteria issc
            {
                get;
                set;
            }

            public CollectiveInvoiceOpTypeEnum opType
            {
                get;
                set;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Toplu_Islemler)]
        public Guid PrepareCollectiveInvoiceOpWithSearchCriteria(PrepareCollectiveInvoiceOpWithSearchCriteria_Model pciom)
        {
            InvoiceApiController iac = new InvoiceApiController();
            //iac.InvoiceSEPSearch(pciom.issc, 1); // InvoiceSEPSearch methoduna sadece parametre eklendi içi de düzenlenmesi lazım. 
            Guid result = Guid.NewGuid();
            return result;
        }

        public class AddWatchListModel
        {
            public List<Guid> objectIDList
            {
                get;
                set;
            }

            public Guid? resUserObjectID
            {
                get;
                set;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Toplu_Islemler)]
        public void ClearWatchList()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                Guid UserObjectID = Common.CurrentResource.ObjectID;
                BindingList<SubEpisodeProtocol> sepList = SubEpisodeProtocol.GetSEPByIzlemUser(objectContext, UserObjectID);

                foreach (SubEpisodeProtocol sep in sepList)
                {
                    sep.IzlemUser = null;
                }

                objectContext.Save();
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Toplu_Islemler)]
        public List<TrxTotalAmount_Model> getTrxTotalPriceAndAmountForChangeState(Guid cioObjectID, Guid? procedureID1, Guid? procedureID2)
        {
            List<TrxTotalAmount_Model> result = new List<TrxTotalAmount_Model>();
            using (var objectContext = new TTObjectContext(false))
            {
                CollectiveInvoiceOp cio = objectContext.GetObject<CollectiveInvoiceOp>(cioObjectID) as CollectiveInvoiceOp;
                //ProcedureDefinition p1 = null;
                //ProcedureDefinition p2 = null;
                //if (procedureID1 != null)
                //    p1 = objectContext.GetObject<ProcedureDefinition>(procedureID1.Value) as ProcedureDefinition;
                //if (procedureID2 != null)
                //    p2 = objectContext.GetObject<ProcedureDefinition>(procedureID2.Value) as ProcedureDefinition;

                CollectiveInvoiceOpTypeEnum typeEnum = cio.OpType.Value;
                List<CollectiveInvoiceOpDetail> ciodList = cio.CollectiveInvoiceOpDetails.Select("").ToList();
                List<Guid> objectIDList = new List<Guid>();

                foreach (var item in ciodList)
                {
                    objectIDList.Add(item.ExecObjectID.Value);
                }
                string addSql = "";
                if (procedureID1 != null && procedureID2 != null)
                    addSql = "SubActionProcedure.ProcedureObject = '" + procedureID1 + "' or SubActionProcedure.ProcedureObject = '" + procedureID2 + "' ";
                else if (procedureID1 != null)
                    addSql = "SubActionProcedure.ProcedureObject = '" + procedureID1 + "'";
                else if (procedureID2 != null)
                    addSql = "SubActionProcedure.ProcedureObject = '" + procedureID2 + "'";
                else
                    throw new TTException("Toplu işlem statü değiştirebilmek için sorgulama ekranında en az bir işlem şeçilmiş olmalıdır.");


                string wheresql = Common.CreateFilterExpressionOfGuidList(" AND SubActionProcedure is not null and CURRENTSTATEDEFID <> STATES.Cancelled and (" + addSql + ") ", " SubEpisodeProtocol ", objectIDList);

                BindingList<AccountTransaction.GetTrxGroupedTrxs_Class> tempResult = AccountTransaction.GetTrxGroupedTrxs(wheresql);
                foreach (var item in tempResult)
                {
                    TrxTotalAmount_Model tempItem = new TrxTotalAmount_Model();
                    tempItem.amount = Convert.ToInt32(item.Totalamount);
                    tempItem.totalPrice = Convert.ToDecimal(item.Totalprice);
                    tempItem.procedure = item.ProcedureObject.Value;
                    tempItem.unitPrice = Convert.ToDecimal(item.UnitPrice);
                    tempItem.description = item.Description;
                    tempItem.externalCode = item.ExternalCode;
                    result.Add(tempItem);
                }
            }
            return result;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Toplu_Islemler)]
        public void ChangeTrxCurrentState(Guid cioObjectID, List<TrxTotalAmount_Model> execItems)
        {
            using (var objectContext = new TTObjectContext(false))
            {

                CollectiveInvoiceOp cio = objectContext.GetObject<CollectiveInvoiceOp>(cioObjectID) as CollectiveInvoiceOp;
                List<CollectiveInvoiceOpDetail> ciodList = cio.CollectiveInvoiceOpDetails.Select("").ToList();

                foreach (var ciodItem in ciodList)
                {
                    using (var objectContextInner = new TTObjectContext(false))
                    {
                        try
                        {
                            SubEpisodeProtocol sep = objectContextInner.GetObject<SubEpisodeProtocol>(ciodItem.ExecObjectID.Value) as SubEpisodeProtocol;
                            CollectiveInvoiceOpDetail ciod = objectContextInner.GetObject<CollectiveInvoiceOpDetail>(ciodItem.ObjectID) as CollectiveInvoiceOpDetail;
                            MedulaResult medulaResult = new MedulaResult();
                            foreach (TrxTotalAmount_Model procedureItem in execItems)
                            {

                                List<AccountTransaction> accList = sep.AccountTransactions.Select(" CURRENTSTATEDEFID <> '" + AccountTransaction.States.Cancelled + "' AND EXTERNALCODE = '" + procedureItem.externalCode + "' ").ToList();
                                if (procedureItem.choice == 1) //Gönder
                                {
                                    if (accList.Where(x => x.CurrentStateDefID == AccountTransaction.States.MedulaDontSend || x.CurrentStateDefID == AccountTransaction.States.ToBeNew).Count() > 0)
                                    {
                                        List<AccountTransaction> accListMDS = accList.Where(x => x.CurrentStateDefID == AccountTransaction.States.MedulaDontSend || x.CurrentStateDefID == AccountTransaction.States.ToBeNew).ToList();
                                        List<string> ssList = new List<string>();
                                        List<AccountTransaction> tempList = new List<AccountTransaction>();
                                        List<Guid> accountTransactionIDs = new List<Guid>();
                                        foreach (var item in accListMDS)
                                        {
                                            ssList.Add(item.ObjectID.ToString());
                                            tempList.Add(item);
                                        }
                                        if (ssList.Count > 0)
                                            Utils.UpdateTransactionState(ssList, true, tempList);//true gönderilecek yap.
                                    }
                                    medulaResult.Succes = true;//Eğer hizmet kayıt  denenmemişse true kabul edilsin.
                                    if (sep.IsSGK)
                                    {
                                        if (accList.Where(x => x.CurrentStateDefID != AccountTransaction.States.MedulaEntrySuccessful).Count() > 0)
                                        {
                                            List<AccountTransaction> accListNMES = accList.Where(x => x.CurrentStateDefID != AccountTransaction.States.MedulaEntrySuccessful).ToList();
                                            List<Guid> accountTransactionIDs = new List<Guid>();
                                            foreach (var item in accListNMES)
                                            {
                                                if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                                                    accountTransactionIDs.Add(item.ObjectID);
                                            }

                                            medulaResult = sep.HizmetKayitSync(true, accountTransactionIDs);
                                        }
                                    }
                                }
                                else if (procedureItem.choice == 2) //Gönderme
                                {
                                    medulaResult.Succes = true;//Eğer hizmet kayıt iptal denenmemişse true kabul edilsin.

                                    if (sep.IsSGK)
                                    {
                                        if (accList.Where(x => x.CurrentStateDefID == AccountTransaction.States.MedulaEntrySuccessful).Count() > 0)
                                        {
                                            List<AccountTransaction> accListMES = accList.Where(x => x.CurrentStateDefID == AccountTransaction.States.MedulaEntrySuccessful).ToList();
                                            List<string> ssList = new List<string>();
                                            List<Guid> accountTransactionIDs = new List<Guid>();
                                            foreach (var item in accListMES)
                                            {
                                                if (item.CurrentStateDefID == AccountTransaction.States.MedulaEntrySuccessful && !string.IsNullOrEmpty(item.MedulaProcessNo))
                                                {
                                                    ssList.Add(item.MedulaProcessNo.ToString());
                                                    accountTransactionIDs.Add(item.ObjectID);
                                                }
                                            }
                                            medulaResult = sep.HizmetKayitIptalSync(ssList, accountTransactionIDs, true);
                                        }
                                    }
                                    List<string> updateList = new List<string>();
                                    List<AccountTransaction> updateActList = new List<AccountTransaction>();
                                    foreach (var item in accList)
                                    {
                                        if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.ToBeNew || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful)
                                        {
                                            updateList.Add(item.ObjectID.ToString());
                                            updateActList.Add(item);
                                        }
                                    }
                                    if (updateList.Count > 0)
                                        Utils.UpdateTransactionState(updateList, false, updateActList);//false gönderilmeyecek yap.
                                }
                            }

                            if (medulaResult.Succes)
                                ciod.CurrentStateDefID = CollectiveInvoiceOpDetail.States.Succes;
                            else
                            {
                                ciod.CurrentStateDefID = CollectiveInvoiceOpDetail.States.Error;
                                ciod.ErrorCode = medulaResult.SonucKodu;
                                ciod.ErrorMessage = medulaResult.SonucMesaji;
                            }

                            objectContextInner.Save();

                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                using (var objectContextCatch = new TTObjectContext(false))
                                {
                                    CollectiveInvoiceOpDetail ciod = objectContextCatch.GetObject<CollectiveInvoiceOpDetail>(ciodItem.ObjectID) as CollectiveInvoiceOpDetail;

                                    ciod.CurrentStateDefID = CollectiveInvoiceOpDetail.States.Error;
                                    ciod.ErrorCode = "AutoScript0002";
                                    ciod.ErrorMessage = ex.StackTrace + " - " + ex.Message;

                                    objectContextCatch.Save();
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Toplu_Islemler)]
        public void AddWatchList(AddWatchListModel awl)
        {
            List<SubEpisodeProtocol> tempSEPList = new List<SubEpisodeProtocol>();
            List<Guid> execSEPList = new List<Guid>();
            using (var objectContext = new TTObjectContext(false))
            {
                foreach (Guid item in awl.objectIDList)
                {
                    if (!execSEPList.Contains(item))
                    {
                        SubEpisodeProtocol sep = objectContext.GetObject<SubEpisodeProtocol>(item) as SubEpisodeProtocol;
                        tempSEPList = sep.SEPMaster.SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && x.CurrentStateDefID != SubEpisodeProtocol.States.Closed && x.Payer.Type.PayerType == PayerTypeEnum.SGK).ToList();
                        foreach (SubEpisodeProtocol sepInner in tempSEPList)
                        {
                            if (!awl.resUserObjectID.HasValue)
                            {
                                if (sepInner.IzlemUser == null)
                                {
                                    sepInner.IzlemUser = Common.CurrentResource;
                                    objectContext.Save();
                                }
                            }
                            else
                            {
                                sepInner.IzlemUser = objectContext.GetObject<ResUser>(awl.resUserObjectID.Value) as ResUser;
                                objectContext.Save();
                            }

                            execSEPList.Add(sepInner.ObjectID);
                        }
                    }
                }
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Toplu_Islemler)]
        public void RemoveWatchList(AddWatchListModel awl)
        {
            List<SubEpisodeProtocol> tempSEPList = new List<SubEpisodeProtocol>();
            using (var objectContext = new TTObjectContext(false))
            {
                foreach (Guid item in awl.objectIDList)
                {
                    SubEpisodeProtocol sep = objectContext.GetObject<SubEpisodeProtocol>(item) as SubEpisodeProtocol;
                    tempSEPList = sep.SEPMaster.SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && x.CurrentStateDefID != SubEpisodeProtocol.States.Closed && x.Payer.Type.PayerType == PayerTypeEnum.SGK).ToList();
                    foreach (SubEpisodeProtocol sepInner in tempSEPList)
                    {
                        if (!awl.resUserObjectID.HasValue)
                        {
                            if (sepInner.IzlemUser != null && sepInner.IzlemUser.ObjectID == Common.CurrentResource.ObjectID)
                            {
                                sepInner.IzlemUser = null;
                                objectContext.Save();
                            }
                        }
                        else
                        {
                            sepInner.IzlemUser = null;
                            objectContext.Save();
                        }
                    }
                }
            }
        }

        public class TrxTotalAmount_Model
        {
            public Guid procedure { get; set; }
            public int amount { get; set; }
            public decimal unitPrice { get; set; }
            public decimal totalPrice { get; set; }
            public string externalCode { get; set; }
            public string description { get; set; }
            public int choice { get; set; }
        }
        public class SavedTaskListModel
        {
            public Guid CioObjectID { get; set; }
            public DateTime CreateDate { get; set; }
            public DateTime ExecDate { get; set; }
            public string Status { get; set; }
            public Guid CurrentStateDefID { get; set; }
        }
        public class PrepareCollectiveInvoiceOpWithObjectIDList_Model
        {
            public List<Guid> objectIDList
            {
                get;
                set;
            }

            public CollectiveInvoiceOpTypeEnum opType
            {
                get;
                set;
            }
            public bool processSearchCriteriaData { get; set; }
            public InvoiceSEPSearchCriteria invoiceSEPSearchCriteria;

            //public PayerTypeEnum invoiceSearchType
            //{
            //    get;
            //    set;
            //}

            //public string invoiceResultListType
            //{
            //    get;
            //    set;
            //}

            public DateTime invoiceDate
            {
                get;
                set;
            }

            public string invoiceDescription
            {
                get;
                set;
            }

            public Guid? invoiceCollectionID
            {
                get;
                set;
            }
            public string extraData
            {
                get;
                set;
            }
        }

        public class TaskListModel
        {
            public int Order { get; set; }
            public string TaskString { get; set; }
            public CollectiveInvoiceOpTypeEnum TaskEnum { get; set; }
            public MedulaSubEpisodeStatusEnum NextTaskEnum { get; set; }
            public string Detail { get; set; }
            public InvoiceSEPSearchCriteria SearchCriteria { get; set; }
            public int TotalCount { get; set; }
            public int NewCount { get; set; }
            public int SuccesCount { get; set; }
            public int ErrorCount { get; set; }

        }

        public class FixTaskListModel : TaskListModel
        {
            public string ErrorCodeText { get; set; }
            public string SutCode { get; set; }
            public Guid? ErrorCode { get; set; }
            public CollectiveInvoiceTaskType TaskType { get; set; }
        }

        public class SaveTaskListModel
        {
            public List<TaskListModel> TaskList { get; set; }
            public List<FixTaskListModel> FixTaskList { get; set; }
            public DateTime? ExecTime { get; set; }
            public Guid? ObjectID { get; set; }
            public SaveTaskListModel()
            {
                this.TaskList = new List<TaskListModel>();
                this.FixTaskList = new List<FixTaskListModel>();
            }
        }
        public class CancelTaskModel
        {
            public Guid ObjectID { get; set; }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Toplu_Islemler)]
        public List<SavedTaskListModel> GetSavedScheduledTask()
        {
            List<SavedTaskListModel> result = new List<SavedTaskListModel>();
            using (var objectContext = new TTObjectContext(false))
            {
                ResUser u = Common.CurrentResource;
                DateTime d = DateTime.Now.AddMonths(-2);
                BindingList<CollectiveInvoiceOp.GetSavedCIO_Class>  tempList = CollectiveInvoiceOp.GetSavedCIO(d, u.ObjectID, CollectiveInvoiceExecType.Ontask);
                var query =
                   from i in tempList
                   orderby i.StartDate descending
                   select new SavedTaskListModel { CioObjectID = i.ObjectID.Value,
                       CreateDate = i.CreateDate.Value,ExecDate = i.StartDate.Value,
                       Status = i.Status,CurrentStateDefID = i.CurrentStateDefID.Value  };  
                result = query.ToList();
            }
            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Toplu_Islemler)]
        public SaveTaskListModel GetScheduledTask([FromQuery]Guid ObjectID)
        {
            SaveTaskListModel result = new SaveTaskListModel();
            using (var objectContext = new TTObjectContext(false))
            {
                CollectiveInvoiceOp cio = objectContext.GetObject<CollectiveInvoiceOp>(ObjectID) as CollectiveInvoiceOp;
                result.ObjectID = cio.ObjectID;
                result.ExecTime = cio.StartDate;
                FixTaskListModel tempModel = null;
                bool conti = false;
                int i = 0;
                do
                {
                    tempModel = new FixTaskListModel();
                    i++;
                    conti = loadScheduledTaskToViewModel(cio, i, ref tempModel);

                    if (cio.TaskType == CollectiveInvoiceTaskType.Task)
                        result.TaskList.Add((TaskListModel)tempModel);
                    else if (cio.TaskType == CollectiveInvoiceTaskType.FixTask)
                        result.FixTaskList.Add(tempModel);

                    if (cio.NextCIO != null)
                        cio = cio.NextCIO;
                } while (conti);
            }
            return result;
        }

        private bool loadScheduledTaskToViewModel(CollectiveInvoiceOp _cio, int _order,ref FixTaskListModel tempModel)
        {
             
            tempModel.Detail = _cio.ExtraData;
            tempModel.Order = _order;
            tempModel.TaskEnum = _cio.OpType.Value;
            tempModel.TaskString = Common.GetDisplayTextOfEnumValue("CollectiveInvoiceOpTypeEnum", (int)_cio.OpType.Value);
            tempModel.SutCode = _cio.ErrorSutCodeText;
            tempModel.ErrorCodeText = _cio.ErrorCodeText;
            List<CollectiveInvoiceOpDetail> tempList = _cio.CollectiveInvoiceOpDetails.Select("").ToList();
            tempModel.TotalCount = tempList.Count();
            tempModel.NewCount = tempList.Count(x => x.CurrentStateDefID == CollectiveInvoiceOpDetail.States.New);
            tempModel.ErrorCount = tempList.Count(x => x.CurrentStateDefID == CollectiveInvoiceOpDetail.States.Error);
            tempModel.SuccesCount= tempList.Count(x => x.CurrentStateDefID == CollectiveInvoiceOpDetail.States.Succes);
            if (_cio.NextCIO != null)
                return true;
            else
                return false;
        }
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Toplu_Islemler)]
        public bool CancelScheduledTask(CancelTaskModel cancelTask)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                CollectiveInvoiceOp cio = objectContext.GetObject<CollectiveInvoiceOp>(cancelTask.ObjectID) as CollectiveInvoiceOp;
                cio.CurrentStateDefID = CollectiveInvoiceOp.States.Cancel;
                objectContext.Save();
                //CollectiveInvoiceOp c = new CollectiveInvoiceOp();
                //c.ExecuteOnTaskOperation(cancelTask.ObjectID);
            }
            return true;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Toplu_Islemler)]
        public bool SaveScheduledTask(SaveTaskListModel saveTaskList)
        {
            List<FixTaskListModel> tempList = new List<FixTaskListModel>();
            foreach (var item in saveTaskList.TaskList.OrderByDescending(x => x.Order))
            {
                FixTaskListModel tempItem = new FixTaskListModel();
                tempItem.Detail = item.Detail;
                tempItem.NextTaskEnum = item.NextTaskEnum;
                tempItem.Order = item.Order;
                tempItem.SearchCriteria = item.SearchCriteria;
                tempItem.TaskEnum = item.TaskEnum;
                tempItem.TaskString = item.TaskString;
                tempItem.TaskType = CollectiveInvoiceTaskType.Task;
                tempList.Add(tempItem);
            }
            foreach (var item in saveTaskList.FixTaskList.OrderByDescending(x => x.Order))
            {
                item.TaskType = CollectiveInvoiceTaskType.FixTask;
                tempList.Add(item);
            }

            if(saveTaskList.ExecTime == null ||  !saveTaskList.ExecTime.HasValue)
                throw new TTException("Planlı görev kayıt için çalışma zamanı zorunlu alandır. Lütfen giriş yapınız.");

            using (var objectContext = new TTObjectContext(false))
            {
                int i = 0;
                CollectiveInvoiceOp nextCio = null;
                foreach (var item in tempList)
                {
                    i++;
                    
                    List<Guid> _objectIDList;
                    CollectiveInvoiceOp cio = new CollectiveInvoiceOp(objectContext);
                    cio.NextCIO = nextCio;
                    nextCio = cio;
                    cio.CurrentStateDefID = CollectiveInvoiceOp.States.New;
                    cio.OpType = item.TaskEnum;
                    cio.TaskType = item.TaskType;
                    cio.ErrorCodeText = item.ErrorCodeText;
                    cio.ErrorSutCodeText = item.SutCode;
                    cio.PayerType = (PayerTypeEnum)item.SearchCriteria.InvoiceSearchType.Value;
                    cio.CreateDate = DateTime.Now;
                    if (i == tempList.Count)
                        cio.StartDate = saveTaskList.ExecTime;
                    else
                        cio.StartDate = null;
                    cio.User = Common.CurrentResource;
                    cio.ExecType = CollectiveInvoiceExecType.Ontask;
                    cio.ExtraData = item.Detail;
                    if (item.TaskEnum == CollectiveInvoiceOpTypeEnum.SaveInvoice || item.TaskEnum == CollectiveInvoiceOpTypeEnum.ReadInvoicePrice ||
                    item.TaskEnum == CollectiveInvoiceOpTypeEnum.Fix1108AndInvoice || item.TaskEnum == CollectiveInvoiceOpTypeEnum.Fix1108AndReadInvoice)
                    {
                        var tempItem = Newtonsoft.Json.JsonConvert.DeserializeObject<CollectiveInvoiceOp.invoiceTaskModel>(item.Detail, 
                            new Newtonsoft.Json.Converters.IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });
                        if(tempItem.faturaTarihi == null || tempItem.faturaTarihi.HasValue == false )
                            throw new TTException(TTUtils.CultureService.GetText("M27111", "Toplu faturalama/tutar okuma işlemi kayıt edebilmek için faturalama tarihi zorunludur. Lütfen giriş yaptınız."));
                    }
                        
                    if (item.TaskEnum == CollectiveInvoiceOpTypeEnum.AddInvoiceCollection && cio.InvoiceCollectionID == null)
                        throw new TTException(TTUtils.CultureService.GetText("M27111", "Toplu faturalama/tutar okuma işlemi kayıt edebilmek için faturalama tarihi zorunludur. Lütfen giriş yaptınız."));
                    StringBuilder sb = SubEpisodeProtocol.InvoiceSEPSearchFilter(item.SearchCriteria, objectContext);
                    _objectIDList = SubEpisodeProtocol.GetSEPObjectIDByInjection(" AND " + sb.ToString()).Select(x => x.ObjectID.Value).ToList();


                    foreach (var itemInner in _objectIDList)
                    {
                        CollectiveInvoiceOpDetail ciod = new CollectiveInvoiceOpDetail(objectContext);
                        ciod.CollectiveInvoiceOp = cio;
                        ciod.CurrentStateDefID = CollectiveInvoiceOpDetail.States.New;
                        ciod.ExecObjectID = itemInner;
                        ciod.ExecObjectType = typeof(SubEpisodeProtocol).ToString();
                    }

                }
                objectContext.Save();
            }
            return true;
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Toplu_Islemler)]
        public Guid PrepareCollectiveInvoiceOpWithObjectIDList(PrepareCollectiveInvoiceOpWithObjectIDList_Model pciom)
        {
            if (pciom == null)
                throw new TTException(TTUtils.CultureService.GetText("M27113", "Toplu işlem başlatılamadı. (pciom is null)"));

            //if (pciom.objectIDList == null)
            //    throw new TTException(TTUtils.CultureService.GetText("M27114", "Toplu işlem başlatılamadı. (pciom.objectIDList is null)"));

            //if (pciom.objectIDList.Count > 0)
            //{
            List<Guid> _objectIDList;
            using (var objectContext = new TTObjectContext(false))
            {
                CollectiveInvoiceOp cio = new CollectiveInvoiceOp(objectContext);
                cio.CurrentStateDefID = CollectiveInvoiceOp.States.New;
                cio.OpType = pciom.opType;
                cio.PayerType = (PayerTypeEnum)pciom.invoiceSEPSearchCriteria.InvoiceSearchType.Value;
                cio.StartDate = DateTime.Now;
                cio.User = Common.CurrentResource;
                //cio.InvoiceDate = pciom.invoiceDate;
                //cio.InvoiceDescription = pciom.invoiceDescription;
                cio.InvoiceCollectionID = pciom.invoiceCollectionID;
                cio.ExecType = CollectiveInvoiceExecType.Online;
                cio.ExtraData = pciom.extraData;
                if (pciom.opType == CollectiveInvoiceOpTypeEnum.SaveInvoice || pciom.opType == CollectiveInvoiceOpTypeEnum.ReadInvoicePrice ||
                    pciom.opType == CollectiveInvoiceOpTypeEnum.Fix1108AndInvoice || pciom.opType == CollectiveInvoiceOpTypeEnum.Fix1108AndReadInvoice )
                {
                    var tempItem = Newtonsoft.Json.JsonConvert.DeserializeObject<CollectiveInvoiceOp.invoiceTaskModel>(pciom.extraData);
                    if (tempItem.faturaTarihi == null || tempItem.faturaTarihi.HasValue == false)
                        throw new TTException(TTUtils.CultureService.GetText("M27111", "Toplu faturalama/tutar okuma işlemi kayıt edebilmek için faturalama tarihi zorunludur. Lütfen giriş yaptınız."));

                }
                if (pciom.opType == CollectiveInvoiceOpTypeEnum.AddInvoiceCollection && cio.InvoiceCollectionID == null)
                    throw new TTException(TTUtils.CultureService.GetText("M27111", "Toplu icmale ekleme yapabilmek için faturalama tarihi zorunludur. Lütfen giriş yaptınız."));
                if (pciom.processSearchCriteriaData)
                {
                    StringBuilder sb = SubEpisodeProtocol.InvoiceSEPSearchFilter(pciom.invoiceSEPSearchCriteria, objectContext);
                    _objectIDList = SubEpisodeProtocol.GetSEPObjectIDByInjection(" AND " + sb.ToString()).Select(x => x.ObjectID.Value).ToList();
                }
                else
                    _objectIDList = pciom.objectIDList;

                foreach (var item in _objectIDList)
                {
                    CollectiveInvoiceOpDetail ciod = new CollectiveInvoiceOpDetail(objectContext);
                    ciod.CollectiveInvoiceOp = cio;
                    ciod.CurrentStateDefID = CollectiveInvoiceOpDetail.States.New;
                    ciod.ExecObjectID = item;
                    if (pciom.invoiceSEPSearchCriteria.searchResultType == TTUtils.CultureService.GetText("M26997", "Takip"))
                        ciod.ExecObjectType = typeof(SubEpisodeProtocol).ToString();
                    else
                        ciod.ExecObjectType = typeof(Episode).ToString();
                }

                objectContext.Save();
                return cio.ObjectID;
            }
            //}

            throw new TTException(TTUtils.CultureService.GetText("M26828", "Seçili hiç bir işlem bulunamadı."));
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Toplu_Islemler)]
        public void ExecCollectiveOperation([FromQuery] Guid cioObjectID)
        {
            //if (cioObjectID == Guid.Empty)
            //    throw new TTException("Toplu işlem başlatılamadı. (cioObjectID is Guid.Empty)");
            try
            {
                CollectiveInvoiceOp.ExecuteSingleCollectiveOperation(cioObjectID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public class CollectiveOperationResultCount
        {
            public int succesCount
            {
                get;
                set;
            }

            public int errorCount
            {
                get;
                set;
            }

            public int newCount
            {
                get;
                set;
            }

            public List<CollectiveOperationErrors> errorList
            {
                get;
                set;
            }

            public CollectiveOperationResultCount()
            {
                this.errorList = new List<CollectiveOperationErrors>();
            }
        }

        public class CollectiveOperationErrors
        {
            public Guid ObjectID;
            public string Takip;
            public string Protocol;
            public string Code;
            public string Message;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Toplu_Islemler)]
        public CollectiveOperationResultCount GetCollectiveOperationResultCounts([FromQuery] Guid cioObjectID)
        {
            CollectiveOperationResultCount result = new CollectiveOperationResultCount();
            using (var objectContext = new TTObjectContext(false))
            { //TODO: AAE CollectiveInvoiceOp ve detail tabloları düzenli olarak boşaltılacak.
                //if(cioObjectID == Guid.Empty)
                //    throw new TTException("Toplu işlem başlatılamadı. (cioObjectID is Guid.Empty)");
                CollectiveInvoiceOp cio = objectContext.GetObject<CollectiveInvoiceOp>(cioObjectID) as CollectiveInvoiceOp;
                List<CollectiveInvoiceOpDetail> ciodList = cio.CollectiveInvoiceOpDetails.Select("").ToList();
                //BindingList<CollectiveInvoiceOp.GetCountOfDetail_Class> queryResult =  CollectiveInvoiceOp.GetCountOfDetail(cioObjectID);
                //CollectiveInvoiceOp.GetCountOfDetail_Class qu = queryResult.First();
                result.errorCount = ciodList.Where(x => x.CurrentStateDefID == CollectiveInvoiceOpDetail.States.Error).Count();
                result.newCount = ciodList.Where(x => x.CurrentStateDefID == CollectiveInvoiceOpDetail.States.New).Count();
                result.succesCount = ciodList.Where(x => x.CurrentStateDefID == CollectiveInvoiceOpDetail.States.Succes).Count();
                foreach (var item in ciodList.Where(x => x.CurrentStateDefID == CollectiveInvoiceOpDetail.States.Error).ToList())
                {
                    CollectiveOperationErrors error = new CollectiveOperationErrors();
                    error.Code = item.ErrorCode;
                    error.Message = item.ErrorMessage;
                    error.ObjectID = item.ExecObjectID.Value;
                    error.Takip = item.MedulaTakipNo;
                    error.Protocol = item.ProtocolNo;
                    result.errorList.Add(error);
                }
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Toplu_Islemler)]
        public Infrastructure.Models.ComboListItem[] uygunIcmalleriGetir([FromQuery] Guid payerObjectID)
        {
            Infrastructure.Models.ComboListItem[] result;
            Guid? userID = Common.CurrentResource.ObjectID;
            using (var objectContext = new TTObjectContext(true))
            {
                if (userID.HasValue)
                {
                    PayerDefinition payer = (PayerDefinition)objectContext.GetObject(payerObjectID, typeof(PayerDefinition));
                    if (payer != null)
                    {
                        var icList = objectContext.QueryObjects<InvoiceCollection>().Where(x => x.CurrentStateDefID == InvoiceCollection.States.Open && payer.ObjectID == x.Payer.ObjectID && (x.CreateUser.ObjectID == userID.Value || x.IsGeneral.Value == true) && x.IsAutoGenerated != true).ToArray();
                        //TODO: AAE false yapılacak daha sonra. şimdi false olan hiç kayıt yok.
                        result = new Infrastructure.Models.ComboListItem[icList.Count()];
                        int i = 0;
                        foreach (InvoiceCollection ic in icList)
                        {
                            result[i] = new Infrastructure.Models.ComboListItem(ic.ObjectID, ic.Name);
                            i++;
                        }

                        objectContext.FullPartialllyLoadedObjects();
                        return result;
                    }
                }
            }

            return null;
        }
    }
}