
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


namespace TTObjectClasses
{
    /// <summary>
    /// Eczaneye İlaç İade
    /// </summary>
    public partial class DrugReturnAction : EpisodeAction
    {
        public partial class GetDrugReturnReportQuery_Class : TTReportNqlObject
        {
        }

        protected void PreTransition_New2Approval()
        {
            // From State : New   To State : Approval
            #region PreTransition_New2Approval

            if (DrugReturnActionDetails.Count == 0)
            {
                throw new TTException(TTUtils.CultureService.GetText("M26065", "İlaç Seçilmeden İşleme Devam Edilemez."));
            }

            foreach (DrugReturnActionDetail detail in DrugReturnActionDetails)
            {
                if (detail.Amount == 0 && detail.Amount > detail.SendAmount)
                    throw new TTException(TTUtils.CultureService.GetText("M26527", "Miktarlar 0 ve Gönderilen Miktardan Büyük Olamaz."));
            }

            if (string.IsNullOrEmpty(DrugReturnReason))
                throw new TTException(TTUtils.CultureService.GetText("M25997", "İade nedeni olmadan işlemi ilerletemessiniz."));


            #endregion PreTransition_New2Approval
        }

        protected void PreTransition_Approval2Completed()
        {
            // From State : Approval   To State : Completed
            #region PreTransition_Approval2Completed

            if (DrugReturnActionDetails.Count > 0)
            {
                List<DrugOrderDetail> unListDrugOrderDetail = new List<DrugOrderDetail>();
                Dictionary<DrugReturnActionDetail, DrugOrderDetail> addList = new Dictionary<DrugReturnActionDetail, DrugOrderDetail>();
                foreach (DrugReturnActionDetail drugReturnActionDetail in DrugReturnActionDetails)
                {
                    if (drugReturnActionDetail.Amount > 0)
                    {
                        //Transaction ları ve ilgili alanları güncelliyor. SS
                        double returnAmount = (Double)drugReturnActionDetail.Amount;
                        List<StockTransaction> outTrxs = drugReturnActionDetail.DrugOrderTransaction.KScheduleMaterial.StockTransactions.Select(string.Empty).Where(t => t.CurrentStateDefID == StockTransaction.States.Completed).OrderBy(s => s.TransactionDate).ToList();
                        foreach (StockTransaction trx in outTrxs)
                        {
                            if (returnAmount > 0)
                            {
                                if (trx.StockCollectedTrxs.Select(string.Empty).Count > 0)
                                {
                                    throw new TTException(trx.Stock.Material.Name + " isimli ilacın İcmali olurşturulmuştur iade kabul edemezsınız. İçmal İşlem No: " + trx.StockCollectedTrxs[0].StockActionDetail.StockAction.StockActionID.ToString());
                                }
                                else
                                {
                                    if (returnAmount < trx.Amount)
                                    {
                                        trx.Amount = trx.Amount - returnAmount;
                                        trx.Stock.Inheld = trx.Stock.Inheld + returnAmount;
                                        StockLevel stockLevel = trx.Stock.StockLevels.Where(l => l.StockLevelType == trx.StockLevelType).FirstOrDefault();
                                        stockLevel.Amount = stockLevel.Amount + returnAmount;
                                        trx.StockActionDetail.Amount = trx.StockActionDetail.Amount - returnAmount;
                                        IBindingList details = ObjectContext.QueryObjects("STOCKTRANSACTIONDETAIL", "OUTSTOCKTRANSACTION=" + ConnectionManager.GuidToString(trx.ObjectID));
                                        foreach (StockTransactionDetail detail in details)
                                            detail.Amount = detail.Amount - returnAmount;
                                        returnAmount = 0;
                                    }
                                    else if (returnAmount == trx.Amount || returnAmount > trx.Amount)
                                    {
                                        trx.CurrentStateDefID = StockTransaction.States.Cancelled;
                                        trx.StockActionDetail.Amount = trx.StockActionDetail.Amount - trx.Amount;
                                        if (trx.StockActionDetail.Amount == 0)
                                            trx.StockActionDetail.Status = StockActionDetailStatusEnum.Cancelled;
                                        returnAmount = returnAmount - (double)trx.Amount;
                                    }
                                }
                            }
                            else
                                break;
                        }

                        /*DrugDefinition drug = (DrugDefinition)drugReturnActionDetail.DrugOrderTransaction.KScheduleMaterial.Material;
                        bool drugType = DrugOrder.GetDrugUsedType(drug);
                        if (drugType)
                            drugReturnActionDetail.DrugOrderTransaction.Amount = drugReturnActionDetail.DrugOrderTransaction.Amount - (Double)drugReturnActionDetail.Amount;
                        else
                        {
                            double totalVolume = (double)drug.Volume * (Double)drugReturnActionDetail.Amount;
                            drugReturnActionDetail.DrugOrderTransaction.Amount = drugReturnActionDetail.DrugOrderTransaction.Amount - totalVolume;
                        }*/

                        // Order ları tamamlıyor.SS
                        double restAmount = (Double)drugReturnActionDetail.Amount;

                        foreach (DrugOrderDetail drugOrderDetail in drugReturnActionDetail.DrugOrderDetails.OrderByDescending(x => x.OrderPlannedDate))
                        {
                            if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Supply)
                            {
                                if (restAmount >= (double)drugOrderDetail.Amount)
                                {
                                    drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.ReturnPharmacy;
                                    restAmount = restAmount - (double)drugOrderDetail.Amount;
                                }
                                else if (restAmount == 0)
                                {
                                    unListDrugOrderDetail.Add(drugOrderDetail);
                                }
                                else if ((double)drugOrderDetail.Amount > restAmount)
                                {
                                    drugOrderDetail.Amount = (double)drugOrderDetail.Amount - restAmount;
                                    unListDrugOrderDetail.Add(drugOrderDetail);
                                    //restAmount = 0;

                                    DrugOrderDetail newDrugOrderDetail = new DrugOrderDetail(ObjectContext);
                                    newDrugOrderDetail.Amount = drugOrderDetail.Amount;

                                    bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrderDetail.Material);
                                    if (drugType)
                                        newDrugOrderDetail.DoseAmount = restAmount;
                                    else
                                        newDrugOrderDetail.DoseAmount = restAmount * (double)((DrugDefinition)drugOrderDetail.Material).Dose;

                                    newDrugOrderDetail.ActionDate = DateTime.Now;
                                    newDrugOrderDetail.Day = drugOrderDetail.Day;
                                    //newDrugOrderDetail.DrugReturnActionDetail = drugReturnActionDetail;
                                    newDrugOrderDetail.DrugOrder = drugOrderDetail.DrugOrder;
                                    newDrugOrderDetail.Episode = drugOrderDetail.Episode;
                                    newDrugOrderDetail.Frequency = drugOrderDetail.Frequency;
                                    newDrugOrderDetail.FromResource = drugOrderDetail.FromResource;
                                    newDrugOrderDetail.MasterResource = drugOrderDetail.MasterResource;
                                    newDrugOrderDetail.Material = drugOrderDetail.Material;
                                    newDrugOrderDetail.Note = TTUtils.CultureService.GetText("M25626", "Ezcaneye İade Edildi.");
                                    newDrugOrderDetail.NursingApplication = drugOrderDetail.NursingApplication;
                                    newDrugOrderDetail.OrderPlannedDate = drugOrderDetail.OrderPlannedDate;
                                    newDrugOrderDetail.PlannedStartTime = drugOrderDetail.PlannedStartTime;
                                    newDrugOrderDetail.Store = drugOrderDetail.Store;
                                    newDrugOrderDetail.UsageNote = drugOrderDetail.UsageNote;
                                    newDrugOrderDetail.Eligible = drugOrderDetail.Eligible;
                                    newDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                                    newDrugOrderDetail.Update();
                                    newDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.ReturnPharmacy;
                                    newDrugOrderDetail.Update();
                                    addList.Add(drugReturnActionDetail, newDrugOrderDetail);

                                    restAmount = 0;
                                }
                                else
                                    break;
                            }
                        }

                        if (restAmount == 0)
                        {
                            bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugReturnActionDetail.DrugOrderDetails[0].Material);
                            if (drugType == false)
                            {
                                foreach (DrugOrderDetail orderDetail in drugReturnActionDetail.DrugOrderDetails[0].DrugOrder.DrugOrderDetails.Select(string.Empty))
                                {
                                    if (orderDetail.CurrentStateDefID == DrugOrderDetail.States.Supply || orderDetail.CurrentStateDefID == DrugOrderDetail.States.UseRestDose)
                                    {
                                        orderDetail.CurrentStateDefID = DrugOrderDetail.States.ReturnPharmacy;
                                    }
                                }
                            }
                        }


                        if (restAmount > 0)
                        {
                            DrugOrderDetail newDrugOrderDetail = new DrugOrderDetail(ObjectContext);
                            DrugOrder drugOrder = drugReturnActionDetail.DrugOrderTransaction.DrugOrder;
                            newDrugOrderDetail.Amount = restAmount;

                            bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrder.Material);
                            if (drugType)
                                newDrugOrderDetail.DoseAmount = restAmount;
                            else
                                newDrugOrderDetail.DoseAmount = restAmount * (double)((DrugDefinition)drugOrder.Material).Dose;

                            newDrugOrderDetail.ActionDate = DateTime.Now;
                            newDrugOrderDetail.Day = drugOrder.Day;
                            newDrugOrderDetail.DrugReturnActionDetail = drugReturnActionDetail;
                            newDrugOrderDetail.DrugOrder = drugOrder;
                            newDrugOrderDetail.Episode = drugOrder.Episode;
                            newDrugOrderDetail.Frequency = drugOrder.Frequency;
                            newDrugOrderDetail.FromResource = drugOrder.FromResource;
                            newDrugOrderDetail.MasterResource = drugOrder.MasterResource;
                            newDrugOrderDetail.Material = drugOrder.Material;
                            newDrugOrderDetail.Note = TTUtils.CultureService.GetText("M25626", "Ezcaneye İade Edildi.");
                            newDrugOrderDetail.NursingApplication = drugOrder.NursingApplication;
                            newDrugOrderDetail.OrderPlannedDate = DateTime.Now;
                            newDrugOrderDetail.PlannedStartTime = DateTime.Now;
                            newDrugOrderDetail.Store = drugOrder.Store;
                            newDrugOrderDetail.UsageNote = drugOrder.UsageNote;
                            newDrugOrderDetail.Eligible = false;
                            newDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                            newDrugOrderDetail.Update();
                            newDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.ReturnPharmacy;
                            newDrugOrderDetail.Update();
                            drugReturnActionDetail.DrugOrderDetails.Add(newDrugOrderDetail);
                        }
                    }
                    else
                    {
                        foreach (DrugOrderDetail drugOrderDetail in drugReturnActionDetail.DrugOrderDetails)
                        {
                            unListDrugOrderDetail.Add(drugOrderDetail);
                        }
                    }
                }

                foreach (KeyValuePair<DrugReturnActionDetail, DrugOrderDetail> add in addList)
                {
                    add.Key.DrugOrderDetails.Add(add.Value);
                }

                foreach (DrugOrderDetail unList in unListDrugOrderDetail)
                {
                    UndoTransitionDrugOrderDetail(unList, ObjectContext);
                }

            }

            //this.createStockIn(this, this.ObjectContext);


            #endregion PreTransition_Approval2Completed
        }


        public void UndoTransitionDrugOrderDetail(DrugOrderDetail drugOrderDetail, TTObjectContext objectContext)
        {
            if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Cancel)
            {
                ((ITTObject)drugOrderDetail).UndoLastTransition();
                //objectContext.Update();
                drugOrderDetail.DrugReturnActionDetail = null;
                drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
                //objectContext.Update(); zaten update modda olduğu için gerek kalmadı..
            }
            else
            {
                drugOrderDetail.DrugReturnActionDetail = null;
            }
        }

        protected void PreTransition_New2Cancel()
        {
            foreach (DrugReturnActionDetail drugReturnActionDetail in DrugReturnActionDetails)
            {
                foreach (DrugOrderDetail det in drugReturnActionDetail.DrugOrderDetails.Select(string.Empty))
                {
                    det.DrugReturnActionDetail = null;
                }
            }
        }
        protected void PreTransition_ApprovalCancel()
        {
            foreach (DrugReturnActionDetail drugReturnActionDetail in DrugReturnActionDetails)
            {
                foreach (DrugOrderDetail det in drugReturnActionDetail.DrugOrderDetails.Select(string.Empty))
                {
                    if (det.CurrentStateDefID != DrugOrderDetail.States.Cancel)
                        det.DrugReturnActionDetail = null;
                }
            }
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DrugReturnAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DrugReturnAction.States.New && toState == DrugReturnAction.States.Approval)
                PreTransition_New2Approval();
            else if (fromState == DrugReturnAction.States.Approval && toState == DrugReturnAction.States.Completed)
                PreTransition_Approval2Completed();
            else if (fromState == DrugReturnAction.States.New && toState == DrugReturnAction.States.Cancelled)
                PreTransition_New2Cancel();
            else if (fromState == DrugReturnAction.States.Approval && toState == DrugReturnAction.States.Cancelled)
                PreTransition_ApprovalCancel();

        }
        public void CancelStockAction()
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                StockAction sa = objectContext.GetObject<StockAction>(new Guid("edf41a8c-12eb-4bc2-86d6-740d044734ee"));
                ((StockAction)sa).CurrentStateDefID = StockAction.States.Cancelled;
                objectContext.Save();
            }

        }

        public void createStockIn(DrugReturnAction drugReturnAction, TTObjectContext objectContext)
        {
            List<Guid> detailIDs = new List<Guid>();
            foreach (DrugReturnActionDetail detail in drugReturnAction.DrugReturnActionDetails)
                foreach (DrugOrderDetail orderDetail in detail.DrugOrderDetails)
                    detailIDs.Add(orderDetail.ObjectID);
            Dictionary<StockTransaction, double> trxs = new Dictionary<StockTransaction, double>();
            foreach (DrugOrderTransactionDetail.GetDrugOrderTransactionDetailWithDeail_Class trxDetail in DrugOrderTransactionDetail.GetDrugOrderTransactionDetailWithDeail(detailIDs))
            {
                DrugOrderTransactionDetail det = (DrugOrderTransactionDetail)objectContext.GetObject((Guid)trxDetail.ObjectID, typeof(DrugOrderTransactionDetail));
                double calcAmount = 0;
                if (DrugOrder.GetDrugUsedType((DrugDefinition)det.StockTransaction.Stock.Material))
                    calcAmount = (double)det.Amount;
                else
                    calcAmount = 1;
                if (trxs.ContainsKey(det.StockTransaction))
                    trxs[det.StockTransaction] = trxs[det.StockTransaction] + calcAmount;
                else
                    trxs.Add(det.StockTransaction, calcAmount);
            }

            Dictionary<BudgetTypeDefinition, List<StockInMaterial>> inMaterials = new Dictionary<BudgetTypeDefinition, List<StockInMaterial>>();
            foreach (KeyValuePair<StockTransaction, double> dOTrx in trxs)
            {
                if (inMaterials.ContainsKey(dOTrx.Key.BudgetTypeDefinition))
                {
                    StockTransaction inTrx = dOTrx.Key.OutStockTransactionDetails.Select(t => t.InStockTransaction).FirstOrDefault();
                    StockInMaterial stockInMaterial = new StockInMaterial(objectContext);
                    stockInMaterial.Material = dOTrx.Key.Stock.Material;
                    stockInMaterial.Amount = dOTrx.Value;
                    stockInMaterial.Status = StockActionDetailStatusEnum.New;
                    stockInMaterial.StockLevelType = StockLevelType.NewStockLevel;
                    stockInMaterial.UnitPrice = dOTrx.Key.UnitPrice;
                    stockInMaterial.ExpirationDate = dOTrx.Key.ExpirationDate;
                    stockInMaterial.LotNo = dOTrx.Key.LotNo;
                    stockInMaterial.MKYS_StokHareketID = inTrx.StockActionDetail.MKYS_StokHareketID;
                    stockInMaterial.NotDiscountedUnitPrice = dOTrx.Key.UnitPrice;
                    inMaterials[dOTrx.Key.BudgetTypeDefinition].Add(stockInMaterial);
                }
                else
                {
                    StockTransaction inTrx = dOTrx.Key.OutStockTransactionDetails.Select(t => t.InStockTransaction).FirstOrDefault();
                    StockInMaterial stockInMaterial = new StockInMaterial(objectContext);
                    stockInMaterial.Material = dOTrx.Key.Stock.Material;
                    stockInMaterial.Amount = dOTrx.Value;
                    stockInMaterial.Status = StockActionDetailStatusEnum.New;
                    stockInMaterial.StockLevelType = StockLevelType.NewStockLevel;
                    stockInMaterial.UnitPrice = dOTrx.Key.UnitPrice;
                    stockInMaterial.ExpirationDate = dOTrx.Key.ExpirationDate;
                    stockInMaterial.LotNo = dOTrx.Key.LotNo;
                    stockInMaterial.MKYS_StokHareketID = inTrx.StockActionDetail.MKYS_StokHareketID;
                    stockInMaterial.NotDiscountedUnitPrice = dOTrx.Key.UnitPrice;
                    List<StockInMaterial> detaillist = new List<StockInMaterial>();
                    detaillist.Add(stockInMaterial);
                    inMaterials.Add(dOTrx.Key.BudgetTypeDefinition, detaillist);
                }
            }

            foreach (KeyValuePair<BudgetTypeDefinition, List<StockInMaterial>> action in inMaterials)
            {
                StockIn inAction = new StockIn(objectContext);
                inAction.Store = drugReturnAction.PharmacyStoreDefinition;
                AccountingTerm openAccountingTerm = ((PharmacyStoreDefinition)drugReturnAction.PharmacyStoreDefinition).Accountancy.GetOpenAccountingTerm();
                inAction.AccountingTerm = openAccountingTerm;
                inAction.BudgetTypeDefinition = action.Key;
                inAction.DrugReturnAction = drugReturnAction;
                inAction.DestinationStore = drugReturnAction.MasterResource.Store;
                foreach (StockInMaterial detIn in action.Value)
                    detIn.StockAction = inAction;
                inAction.CurrentStateDefID = StockIn.States.New;
                inAction.Update();
                inAction.CurrentStateDefID = StockIn.States.Completed;
                inAction.Update();
                objectContext.Save();
                if (inAction.CurrentStateDefID == StockIn.States.Completed)
                {
                    if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
                    {
                        var sonucMesaji = inAction.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                        TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                    }
                }
            }
        }




        private List<StockAction.DocumentRecordLogContent> _documentRecordLogContents = null;
        public void CreateDocumentRecordLog(DrugReturnAction drugReturnAction)
        {
            TTObjectContext newContext = new TTObjectContext(false);
            StockIn inAction;
            IBindingList inActionList = newContext.QueryObjects("STOCKIN", "DRUGRETURNACTION = " + ConnectionManager.GuidToString(drugReturnAction.ObjectID));
            if (inActionList.Count > 0)
            {
                inAction = (StockIn)inActionList[0];
                if (inAction.DocumentRecordLogs == null || inAction.DocumentRecordLogs.Count == 0)
                {
                    Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>> inRecordLogs = new Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>();
                    foreach (StockInMaterial detail in inAction.StockActionDetails)
                    {
                        foreach (StockTransaction inTrx in detail.StockTransactions.Select(string.Empty))
                        {
                            if (inTrx.InOut == TransactionTypeEnum.In)
                            {
                                if (inTrx.BudgetTypeDefinition.MKYS_Butce == null)
                                    throw new TTException(inTrx.BudgetTypeDefinition.Name + " bütcesi MKYS ile eşleştirilmemiştir. Lütfen eşleştirip işleme öyle devam ediniz.");
                                MKYS_EButceTurEnum butce = (MKYS_EButceTurEnum)inTrx.BudgetTypeDefinition.MKYS_Butce;
                                if (inRecordLogs.ContainsKey(butce))
                                {
                                    if (inRecordLogs[butce].Contains(detail) == false)
                                        inRecordLogs[butce].Add(detail);
                                }
                                else
                                {
                                    List<StockActionDetail> dets = new List<StockActionDetail>();
                                    dets.Add(detail);
                                    inRecordLogs.Add(butce, dets);
                                }
                            }
                        }
                    }
                    if (inRecordLogs.Count > 0)
                    {
                        _documentRecordLogContents = new List<StockAction.DocumentRecordLogContent>();
                        foreach (KeyValuePair<MKYS_EButceTurEnum, List<StockActionDetail>> inLog in inRecordLogs)
                        {
                            TTObjectContext readOnlyCont = new TTObjectContext(true);
                            DrugReturnAction getAction = (DrugReturnAction)readOnlyCont.GetObject(drugReturnAction.ObjectID, typeof(DrugReturnAction));
                            string place = getAction.Episode.Patient.FullName;
                            StockAction.DocumentRecordLogContent logContent = new StockAction.DocumentRecordLogContent(DocumentTransactionTypeEnum.In, inAction, inLog.Value.Count, place, inLog.Key);
                            _documentRecordLogContents.Add(logContent);
                        }
                        foreach (StockAction.DocumentRecordLogContent documentRecordLogContent in _documentRecordLogContents)
                        {
                            string filterexp = " CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(DocumentRecordLog.States.Completed) + " AND DOCUMENTTRANSACTIONTYPE = " + (int)documentRecordLogContent.TransactionType + " AND BUDGETYPE = " + (int)documentRecordLogContent.ButceTur + " AND DESCRIPTIONS = '" + documentRecordLogContent.Descriptions + "'";
                            IList documentRecordLogs = inAction.DocumentRecordLogs.Select(filterexp);
                            if (documentRecordLogs.Count > 0)
                                inAction.UpdateStockActionDocumentRecordLog(documentRecordLogContent);
                            else
                                inAction.CreateStockActionNewDocumentRecordLog(documentRecordLogContent);
                        }
                    }
                }
                newContext.Save();
            }
            else
                throw new TTException(TTUtils.CultureService.GetText("M25726", "Girişi Oluşmamış işlem."));
        }

        public static CheckPatientDrugOrderTransaction GetNewReturnableDrugsOnPatient(Guid subEpisodeObjectID, DateTime? dischargeDate)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                CheckPatientDrugOrderTransaction output = new CheckPatientDrugOrderTransaction();
                List<GetReturnableDrugOrders_Output> returnableDrugOrders = new List<GetReturnableDrugOrders_Output>();
                if (subEpisodeObjectID != null)
                {
                    BindingList<DrugOrderTransaction.GetReturnableDrugOrderTrxBySubEpisode_Class> allDrugOrderTransaction = DrugOrderTransaction.GetReturnableDrugOrderTrxBySubEpisode(subEpisodeObjectID);
                    foreach (DrugOrderTransaction.GetReturnableDrugOrderTrxBySubEpisode_Class allPatientDrugOrderTrx in allDrugOrderTransaction)
                    {
                        DrugOrderTransaction trx = (DrugOrderTransaction)objectContext.GetObject(allPatientDrugOrderTrx.ObjectID.Value, "DRUGORDERTRANSACTION");
                        bool isReturnable = trx.KScheduleMaterial.StockTransactions.Select(string.Empty).Where(t => t.StockCollectedTrxs.Count == 0).Any();
                        DrugOrder drugOrder = (DrugOrder)objectContext.GetObject((Guid)allPatientDrugOrderTrx.Drugorder, typeof(DrugOrder));
                        if (drugOrder.IsTransfered != true)
                        {
                            double restAmount;
                            bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrder.Material);
                            if (drugType) // Tablet , Hap gibi sayıca iade ediilebilir ilaçlar
                                restAmount = Convert.ToDouble(allPatientDrugOrderTrx.Restamount);
                            else
                                restAmount = Math.Round(Convert.ToDouble(allPatientDrugOrderTrx.Restamount) / Convert.ToDouble(((DrugDefinition)drugOrder.Material).Volume),2);
                            if (restAmount > 0)
                            {
                                GetReturnableDrugOrders_Output item = new GetReturnableDrugOrders_Output();
                                item.amount = restAmount;
                                item.doseAmount = drugOrder.DoseAmount.Value;
                                item.drugName = drugOrder.Material.Name;
                                item.frequency = drugOrder.HospitalTimeSchedule.Name;
                                item.objectID = drugOrder.ObjectID;
                                item.transactionDate = drugOrder.PlannedStartTime.Value;
                                if (dischargeDate != null)
                                {
                                    if (drugOrder.DrugOrderDetails.Where(x => x.OrderPlannedDate > dischargeDate).Any())
                                        item.isTransferable = true;
                                    else
                                        item.isTransferable = false;
                                }
                                else
                                    item.isTransferable = false;
                                returnableDrugOrders.Add(item);
                            }
                        }
                    }
                }
                int doseCount = returnableDrugOrders.Where(y => y.amount < 1).ToList().Count();
                int checkCount = doseCount - returnableDrugOrders.Count;
                if (checkCount == 0)
                    output.isDischarge = true;
                else
                    output.isDischarge = false;
                output.returnableDrugOrdes = returnableDrugOrders;
                return output;
            }
        }

        public static GetReturnDetails GetReturnableDrugsOnPatient(Guid episodeObjectID)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            DrugReturnAction.GetReturnDetails output = new DrugReturnAction.GetReturnDetails();

            List<DrugReturnAction.GetReturnableDetails_Output> getReturnableDetails = new List<DrugReturnAction.GetReturnableDetails_Output>();
            List<DrugReturnAction.GetReturnableDetails_Output> getReviewDetails = new List<DrugReturnAction.GetReturnableDetails_Output>();

            IList allDrugOrderTransaction = DrugOrderTransaction.GetReturnableDrugOrderTrx(objectContext, episodeObjectID);
            Dictionary<Guid, DrugReturnAction.ReturnableDrugsOnPatient> returnList = new Dictionary<Guid, DrugReturnAction.ReturnableDrugsOnPatient>(); // iade edilebilir ilaçların bulundugu liste, bu liste dolu ise hasta üzerinde doz bulunuyor anlamına gelir.
            foreach (DrugOrderTransaction.GetReturnableDrugOrderTrx_Class drugOrderTransaction in allDrugOrderTransaction)
            {


                var drugDeliveryActionDetailList = objectContext.QueryObjects("DRUGDELIVERYACTIONDETAIL", " DRUGORDERTRANSACTION ='" + drugOrderTransaction.ObjectID.ToString() + "'");
                if (drugDeliveryActionDetailList.Count == 0)
                {
                    var drugReturnActionDetailList = objectContext.QueryObjects("DRUGRETURNACTIONDETAIL", " DRUGORDERTRANSACTION ='" + drugOrderTransaction.ObjectID.ToString() + "' AND DRUGRETURNACTION.CURRENTSTATEDEFID <> 'a3b9f936-e351-4bfd-831c-ef9e8975b0f2' ORDER BY DRUGRETURNACTION.ACTIONDATE DESC ");
                    if (drugReturnActionDetailList.Count > 0)
                    {
                        foreach (DrugReturnActionDetail returnDetail in drugReturnActionDetailList)
                        {
                            System.Diagnostics.Debug.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(returnDetail));

                            if (returnDetail.CurrentStateDefID != DrugReturnAction.States.Cancelled)
                            {
                                if (returnDetail.DrugReturnAction.CurrentStateDefID == DrugReturnAction.States.Approval)
                                {
                                    CreateReturnableObjectAndAddToReturnDrugList(objectContext, returnList, drugOrderTransaction, returnDetail.SendAmount.Value);
                                }
                                else if (returnDetail.DrugReturnAction.CurrentStateDefID == DrugReturnAction.States.Completed)
                                {
                                    CreateReturnableObjectAndAddToReturnDrugList(objectContext, returnList, drugOrderTransaction, 0);
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (KeyValuePair<Guid, DrugReturnAction.ReturnableDrugsOnPatient> det in returnList)
                        {
                            System.Diagnostics.Debug.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(det.Value));
                        }
                        CreateReturnableObjectAndAddToReturnDrugList(objectContext, returnList, drugOrderTransaction, 0);
                    }
                }
            }


            foreach (KeyValuePair<Guid, DrugReturnAction.ReturnableDrugsOnPatient> outobject in returnList)
            {
                DrugReturnAction.ReturnableDrugsOnPatient returnableDrugsOnPatient = outobject.Value;
                DrugOrderTransaction trx = (DrugOrderTransaction)objectContext.GetObject(returnableDrugsOnPatient.drugOrderTransaction, "DRUGORDERTRANSACTION");
                List<StockTransaction> returnableStockTransaction = trx.KScheduleMaterial.StockTransactions.Select(string.Empty).Where(t => t.StockCollectedTrxs.Count == 0).ToList();

                DrugReturnAction.GetReturnableDetails_Output drugDeliveryActionDetail = new DrugReturnAction.GetReturnableDetails_Output();
                drugDeliveryActionDetail.Amount = returnableDrugsOnPatient.Amount;
                drugDeliveryActionDetail.ReturnAmount = returnableDrugsOnPatient.ReturnAmount;
                drugDeliveryActionDetail.drugName = returnableDrugsOnPatient.drugName;
                drugDeliveryActionDetail.drugOrderTransaction = trx;
                drugDeliveryActionDetail.transactionDate = (DateTime)trx.KScheduleMaterial.StockAction.TransactionDate;

                if (returnableStockTransaction.Count > 0)
                {
                    getReturnableDetails.Add(drugDeliveryActionDetail);
                }
                else
                {
                    getReviewDetails.Add(drugDeliveryActionDetail);
                }

            }

            output.getReturnableDetails = getReturnableDetails;
            output.getReviewDetails = getReviewDetails;
            output.IsThereAnyReturnableDrugs = getReviewDetails.Count > 0 || getReturnableDetails.Count > 0;
            return output;
        }
        private static void CreateReturnableObjectAndAddToReturnDrugList(TTObjectContext objectContext, Dictionary<Guid, DrugReturnAction.ReturnableDrugsOnPatient> returnList, DrugOrderTransaction.GetReturnableDrugOrderTrx_Class drugOrderTransaction, double returnAbleAmount)
        {

            double resAmount = 0;
            DrugDefinition drugDefinition = (DrugDefinition)objectContext.GetObject((Guid)drugOrderTransaction.Drugdefinition, "DRUGDEFINITION");
            bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
            DrugReturnAction.ReturnableDrugsOnPatient returnableDrugsOnPatient = null;
            bool insertBefore = returnList.TryGetValue(drugOrderTransaction.ObjectID.Value, out returnableDrugsOnPatient);


            if (drugType) // Tablet , Hap gibi sayıca iade ediilebilir ilaçlar
            {
                if (insertBefore == false) // aynı ilacın eczaneye birden fazla iade durumu kontrolu
                {
                    returnableDrugsOnPatient = new DrugReturnAction.ReturnableDrugsOnPatient();
                    resAmount = Convert.ToDouble(drugOrderTransaction.Restamount) - returnAbleAmount;
                }
                else
                {
                    resAmount = returnableDrugsOnPatient.Amount - returnAbleAmount;
                }
            }
            else
            {
                if (insertBefore == false) // aynı ilacın eczaneye birden fazla iade durumu kontrolu
                {
                    returnableDrugsOnPatient = new DrugReturnAction.ReturnableDrugsOnPatient();
                    //Şurup, Krem gibi açılınca eczaneye iadesi olmayan ilaçlar.
                    double resVolume = Convert.ToDouble(drugOrderTransaction.Restamount) - returnAbleAmount;
                    resAmount = Math.Truncate(resVolume / (double)drugDefinition.Volume);
                }
                else
                {
                    double resVolume = returnableDrugsOnPatient.Amount - returnAbleAmount;
                    resAmount = Math.Truncate(resVolume / (double)drugDefinition.Volume);
                }

            }

            if (resAmount > 0)
            {
                returnableDrugsOnPatient.Amount = resAmount;
                returnableDrugsOnPatient.ReturnAmount = resAmount;
                returnableDrugsOnPatient.drugName = drugDefinition.Name;
                returnableDrugsOnPatient.drugOrderTransaction = drugOrderTransaction.ObjectID.Value;
                if (insertBefore == false)
                    returnList.Add(drugOrderTransaction.ObjectID.Value, returnableDrugsOnPatient);
            }

        }


        public class GetReturnDetails
        {
            public GetReturnDetails()
            {
                IsThereAnyReturnableDrugs = false;
            }

            public List<DrugReturnAction.GetReturnableDetails_Output> getReturnableDetails { get; set; }
            public List<DrugReturnAction.GetReturnableDetails_Output> getReviewDetails { get; set; }

            public bool IsThereAnyReturnableDrugs { get; set; }// iade edilebilir ilaçların bulundugu boolean, true ise hasta üzerinde doz bulunuyor anlamına gelir.
        }

        public class ReturnableDrugsOnPatient
        {
            public string drugName
            {
                get;
                set;
            }
            public double Amount
            {
                get;
                set;
            }
            public double ReturnAmount
            {
                get;
                set;
            }

            public Guid drugOrderTransaction
            {
                get;
                set;
            }

            public bool drugType { get; set; }
        }

        public class GetReturnableDetails_Output
        {
            public DateTime transactionDate
            {
                get;
                set;
            }

            public string drugName
            {
                get;
                set;
            }
            public double Amount
            {
                get;
                set;
            }
            public double ReturnAmount
            {
                get;
                set;
            }
            public Guid MaterialObjectID
            {
                get;
                set;
            }
            public DrugOrderTransaction drugOrderTransaction
            {
                get;
                set;
            }


        }
        public class GetReturnableDetails_Input
        {
            public Guid episodeID
            {
                get;
                set;
            }
        }

        public class HalfDoseDestructionDVO
        {
            public string drugName { get; set; }
            public DrugOrderDetail drugOrderDetail { get; set; }
            public string unitName { get; set; }
            public UnitDefinition unitDefinition { get; set; }
            public double amount { get; set; }
        }

        public class GetDrugReturnAndDeliveryDetails
        {
            public List<DrugReturnAction.GetReturnableDrugOrderDetails_Output> getDrugReturnAndDeliveryDetails { get; set; }
            public Guid MasterResource { get; set; }
            public Guid SecondaryMasterResource { get; set; }
            public Guid Episode { get; set; }
            public Guid SubEpisode { get; set; }
            public List<DrugReturnAction.GetReturnableDrugOrderDetails_Output> SelectedDrugReturnAndDeliveryDetails { get; set; }
            public List<HalfDoseDestructionDVO> halfDoseDestructionDVOs { get; set; }
        }
        public class GetReturnableDrugOrderDetails_Output
        {
            public Guid ObjectID { get; set; }
            public DateTime transactionDate { get; set; }
            public string drugName { get; set; }
            public double amount { get; set; }
            public double returnAmount { get; set; }
            public Guid materialObjectID { get; set; }
            public Guid drugOrderTransaction { get; set; }
            public string status { get; set; }
            public bool isReturnable { get; set; }
        }

        public class CheckPatientDrugOrderTransaction
        {
            public bool isDischarge { get; set; }
            public List<GetReturnableDrugOrders_Output> returnableDrugOrdes = new List<GetReturnableDrugOrders_Output>();
        }

        public class GetReturnableDrugOrders_Output
        {
            public Guid objectID { get; set; }
            public DateTime transactionDate { get; set; }
            public string drugName { get; set; }
            public double amount { get; set; }
            public string frequency { get; set; }
            public double doseAmount { get; set; }
            public bool isTransferable { get; set; }
        }
        public class DrugReturnActionCreate_Input
        {
            public DrugReturnAction.GetDrugReturnAndDeliveryDetails getDrugReturnAndDeliveryDetail { get; set; }
            public string txtIadeNedeni { get; set; }
        }

        public class DrugDeliveryActionCreate_Input
        {
            public DrugReturnAction.GetDrugReturnAndDeliveryDetails getDrugReturnAndDeliveryDetail { get; set; }
        }

        public class GetDrugReturnAndDeliveryDetail_Input
        {
            public string subEpisodeID
            {
                get;
                set;
            }
        }

        public class GetWaitingPharmacy_Input
        {
            public Guid episode
            {
                get;
                set;
            }
            public Guid subepisode
            {
                get;
                set;
            }
        }

        public class GetWaitingPharmacy_Output
        {
            public Guid ObjectID { get; set; }
            public string ID { get; set; }
            public DateTime ActionDate { get; set; }
            public string DrugReturnReason { get; set; }
            public List<DrugReturnAction.GetWaitingPharmacyDetail_Output> details { get; set; }
        }

        public class GetWaitingPharmacyDetail_Output
        {
            public Guid ObjectID { get; set; }
            public string MaterialName { get; set; }
            public string Amount { get; set; }

        }

        public class GetComplatedPharmacy_Output
        {
            public Guid ObjectID { get; set; }
            public string ID { get; set; }
            public DateTime ActionDate { get; set; }
            public string DrugReturnReason { get; set; }
            public List<DrugReturnAction.GetComplatedPharmacyDetail_Output> details { get; set; }
        }

        public class GetComplatedPharmacyDetail_Output
        {
            public Guid ObjectID { get; set; }
            public string MaterialName { get; set; }
            public string Amount { get; set; }

        }

    }
}