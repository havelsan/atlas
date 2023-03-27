//$311C13FB
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using static TTObjectClasses.DrugReturnAction;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class DrugReturnActionServiceController : Controller
    {
        public class GetDrugReturnReportQuery_Input
        {
            public Guid TTOBJECTID
            {
                get;
                set;
            }
        }

        public class CreateStockInAction_Input
        {
            public DrugReturnAction DrugReturnAction
            {
                get;
                set;
            }
            public TTObjectContext ObjectContext
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public bool CreateStockInAction(CreateStockInAction_Input input)
        {
            input.DrugReturnAction.CancelStockAction();
            //input.DrugReturnAction.createStockIn(input.DrugReturnAction, input.ObjectContext);
            if (input.DrugReturnAction.StockInActions != null)
                return true;
            else
                return false;
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public bool CreateDocumentRecordLog(CreateStockInAction_Input input)
        {
            input.DrugReturnAction.CreateDocumentRecordLog(input.DrugReturnAction);
            return false;
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public BindingList<DrugReturnAction.GetDrugReturnReportQuery_Class> GetDrugReturnReportQuery(GetDrugReturnReportQuery_Input input)
        {
            var ret = DrugReturnAction.GetDrugReturnReportQuery(input.TTOBJECTID);
            return ret;
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<DocumentRecordLog> GetDocumentRecordLog(GetDrugReturnReportQuery_Input input)
        {
            List<DocumentRecordLog> returnDoc = new List<DocumentRecordLog>();
            TTObjectContext context = new TTObjectContext(false);
            IBindingList stockIns = context.QueryObjects("STOCKIN", "DRUGRETURNACTION =" + TTConnectionManager.ConnectionManager.GuidToString(input.TTOBJECTID));
            foreach (StockIn ins in stockIns)
            {
                foreach (DocumentRecordLog log in ins.DocumentRecordLogs)
                {
                    returnDoc.Add(log);
                }
            }
            return returnDoc;
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public GetReturnDetails GetReturnableDetails(DrugReturnAction.GetReturnableDetails_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                DrugReturnAction.GetReturnDetails output = new DrugReturnAction.GetReturnDetails();
                List<DrugReturnAction.GetReturnableDetails_Output> getReturnableDetails = new List<DrugReturnAction.GetReturnableDetails_Output>();
                List<DrugReturnAction.GetReturnableDetails_Output> getReviewDetails = new List<DrugReturnAction.GetReturnableDetails_Output>();
                BindingList<DrugOrderTransaction.GetReturnableDrugOrderTrx_Class> allDrugOrderTransaction = DrugOrderTransaction.GetReturnableDrugOrderTrx(input.episodeID);
                return DrugReturnAction.GetReturnableDrugsOnPatient(input.episodeID);

                //foreach (DrugOrderTransaction.GetReturnableDrugOrderTrx_Class drugOrderTransaction in allDrugOrderTransaction)
                //{


                //    DrugOrderTransaction trx = (DrugOrderTransaction)objectContext.GetObject((Guid)drugOrderTransaction.ObjectID, "DRUGORDERTRANSACTION");
                //    List<StockTransaction> returnableStockTransaction = trx.KScheduleMaterial.StockTransactions.Select(string.Empty).Where(t => t.StockCollectedTrxs.Count == 0).ToList();
                //    if (returnableStockTransaction.Count > 0)
                //    {
                //        //DrugDefinition drugDefinition = (DrugDefinition)objectContext.GetObject((Guid)drugOrderTransaction.Drugdefinition, "DRUGDEFINITION");
                //        DrugDefinition drugDefinition = (DrugDefinition)objectContext.GetObject((Guid)drugOrderTransaction.Drugdefinition, "DRUGDEFINITION");
                //        bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                //        if (drugType)
                //        {
                //            GetReturnableDetails_Output drugDeliveryActionDetail = new GetReturnableDetails_Output();
                //            drugDeliveryActionDetail.Amount =(double) ((DrugReturnActionDetail)drugReturnActionDetailList[0]).Amount.Value - ((DrugReturnActionDetail)drugReturnActionDetailList[0]).SendAmount.Value;
                //            drugDeliveryActionDetail.ReturnAmount = Convert.ToDouble(drugOrderTransaction.Restamount);
                //            drugDeliveryActionDetail.drugName = drugDefinition.Name;
                //            drugDeliveryActionDetail.drugOrderTransaction = trx;
                //            drugDeliveryActionDetail.transactionDate = (DateTime)trx.KScheduleMaterial.StockAction.TransactionDate;
                //            getReturnableDetails.Add(drugDeliveryActionDetail);
                //        }
                //        else
                //        {
                //            double resVolume = Convert.ToDouble(drugOrderTransaction.Restamount);
                //            double resAmount = 0;
                //            if (resVolume > 0)
                //            {
                //                resAmount = Math.Truncate(resVolume / (double)drugDefinition.Volume);
                //                if (resAmount > 0)
                //                {
                //                    GetReturnableDetails_Output drugDeliveryActionDetail = new GetReturnableDetails_Output();
                //                    drugDeliveryActionDetail.Amount = resAmount;
                //                    drugDeliveryActionDetail.ReturnAmount = resAmount;
                //                    drugDeliveryActionDetail.drugName = drugDefinition.Name;
                //                    drugDeliveryActionDetail.drugOrderTransaction = trx;
                //                    drugDeliveryActionDetail.transactionDate = (DateTime)trx.KScheduleMaterial.StockAction.TransactionDate;
                //                    getReturnableDetails.Add(drugDeliveryActionDetail);
                //                }
                //            }
                //        }
                //    }
                //    else
                //    {
                //        DrugDefinition drugDefinition = (DrugDefinition)objectContext.GetObject((Guid)drugOrderTransaction.Drugdefinition, "DRUGDEFINITION");
                //        bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                //        if (drugType)
                //        {
                //            GetReviewActionDetails_Output drugDeliveryActionDetail = new GetReviewActionDetails_Output();
                //            drugDeliveryActionDetail.Amount = Convert.ToDouble(drugOrderTransaction.Restamount);
                //            drugDeliveryActionDetail.drugName = drugDefinition.Name;
                //            drugDeliveryActionDetail.transactionDate = (DateTime)trx.KScheduleMaterial.StockAction.TransactionDate;
                //            getReviewDetails.Add(drugDeliveryActionDetail);
                //        }
                //        else
                //        {
                //            double resVolume = Convert.ToDouble(drugOrderTransaction.Restamount);
                //            double resAmount = 0;
                //            if (resVolume > 0)
                //            {
                //                resAmount = Math.Truncate(resVolume / (double)drugDefinition.Volume);
                //                if (resAmount > 0)
                //                {
                //                    GetReviewActionDetails_Output drugDeliveryActionDetail = new GetReviewActionDetails_Output();
                //                    drugDeliveryActionDetail.Amount = resAmount;
                //                    drugDeliveryActionDetail.drugName = drugDefinition.Name;
                //                    drugDeliveryActionDetail.transactionDate = (DateTime)trx.KScheduleMaterial.StockAction.TransactionDate;
                //                    getReviewDetails.Add(drugDeliveryActionDetail);
                //                }
                //            }
                //        }
                //    }
                //}
                //objectContext.FullPartialllyLoadedObjects();

                //output.getReturnableDetails = getReturnableDetails;
                //output.getReviewDetails = getReviewDetails;
                //output.getPharmacyControlDrugs = new List<GetReturnableDetails_Output>();
                //return output;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<PatientOwnDrugReturnDetail> GetReturnableOwnDetails(DrugReturnAction.GetReturnableDetails_Input input)
        {
            List<PatientOwnDrugReturnDetail> output = new List<PatientOwnDrugReturnDetail>();
            using (var objectContext = new TTObjectContext(false))
            {
                BindingList<PatientOwnDrugTrx.GetRestOwnDrugTrx_Class> restDrugTRXs = PatientOwnDrugTrx.GetRestOwnDrugTrx(input.episodeID);
                foreach (PatientOwnDrugTrx.GetRestOwnDrugTrx_Class rest in restDrugTRXs)
                {
                    PatientOwnDrugReturnDetail patientOwnDrugReturnDetail = new PatientOwnDrugReturnDetail(objectContext);
                    Material material = objectContext.GetObject<Material>(rest.Material.Value);
                    PatientOwnDrugTrx patientOwnDrugTrx = objectContext.GetObject<PatientOwnDrugTrx>(rest.ObjectID.Value);
                    patientOwnDrugReturnDetail.Material = material;
                    patientOwnDrugReturnDetail.Amount = Convert.ToDouble(rest.Restamount);
                    patientOwnDrugReturnDetail.PatientOwnDrugTrx = patientOwnDrugTrx;
                    output.Add(patientOwnDrugReturnDetail);
                }
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }




        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public GetDrugReturnAndDeliveryDetails GetDrugReturnAndDeliveryDetail(DrugReturnAction.GetDrugReturnAndDeliveryDetail_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                DrugReturnAction.GetDrugReturnAndDeliveryDetails getDrugReturnAndDeliveryDetails = new DrugReturnAction.GetDrugReturnAndDeliveryDetails();
                if (input.subEpisodeID != null)
                {
                    List<DrugReturnAction.GetReturnableDrugOrderDetails_Output> getReturnableDrugOrderDetails = new List<DrugReturnAction.GetReturnableDrugOrderDetails_Output>();
                    getDrugReturnAndDeliveryDetails.halfDoseDestructionDVOs = new List<HalfDoseDestructionDVO>();
                    BindingList<DrugOrderTransaction.GetReturnableDrugOrderTrxBySubEpisode_Class> allDrugOrderTransaction = DrugOrderTransaction.GetReturnableDrugOrderTrxBySubEpisode(new Guid(input.subEpisodeID));

                    foreach (DrugOrderTransaction.GetReturnableDrugOrderTrxBySubEpisode_Class allPatientDrugOrderTrx in allDrugOrderTransaction)
                    {
                        DrugOrderTransaction trx = (DrugOrderTransaction)objectContext.GetObject(allPatientDrugOrderTrx.ObjectID.Value, "DRUGORDERTRANSACTION");
                        bool isReturnable = trx.KScheduleMaterial.StockTransactions.Select(string.Empty).Where(t => t.StockCollectedTrxs.Count == 0).Any();
                        DrugOrder drugOrder = (DrugOrder)objectContext.GetObject((Guid)allPatientDrugOrderTrx.Drugorder, typeof(DrugOrder));
                        if (drugOrder.IsTransfered != true)
                        {
                            List<DrugOrderDetail> drugOrderDetails = drugOrder.DrugOrderDetails.Where(x => x.CurrentStateDef.Status != TTDefinitionManagement.StateStatusEnum.CompletedSuccessfully && x.CurrentStateDefID != DrugOrderDetail.States.Planned).ToList();
                            double restAmount;
                            bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrder.Material);
                            if (drugType) // Tablet , Hap gibi sayıca iade ediilebilir ilaçlar
                            {
                                restAmount = Convert.ToDouble(allPatientDrugOrderTrx.Restamount);
                            }
                            else
                            {
                                restAmount = Math.Truncate(Convert.ToDouble(allPatientDrugOrderTrx.Restamount) / Convert.ToDouble(((DrugDefinition)drugOrder.Material).Volume));
                            }


                            foreach (DrugOrderDetail drugOrderDetail in drugOrderDetails)
                            {
                                if (getReturnableDrugOrderDetails.Where(x => x.ObjectID == drugOrderDetail.ObjectID).Any() == false)
                                {
                                    if (restAmount == 0)
                                        break;

                                    if (drugOrderDetail.DrugReturnActionDetail == null && drugOrderDetail.DrugDeliveryActionDetail == null)
                                    {
                                        DrugReturnAction.GetReturnableDrugOrderDetails_Output getReturnable = new DrugReturnAction.GetReturnableDrugOrderDetails_Output();
                                        getReturnable.ObjectID = drugOrderDetail.ObjectID;
                                        getReturnable.drugName = drugOrderDetail.Material.Name;
                                        if (restAmount < (double)drugOrderDetail.Amount)
                                        {
                                            getReturnable.amount = restAmount;
                                            getReturnable.returnAmount = restAmount;
                                        }
                                        else
                                        {
                                            getReturnable.amount = (double)drugOrderDetail.Amount;
                                            getReturnable.returnAmount = (double)drugOrderDetail.Amount;
                                        }
                                        getReturnable.drugOrderTransaction = allPatientDrugOrderTrx.ObjectID.Value;
                                        getReturnable.materialObjectID = drugOrderDetail.Material.ObjectID;
                                        getReturnable.returnAmount = (double)drugOrderDetail.Amount;
                                        getReturnable.transactionDate = (DateTime)drugOrderDetail.OrderPlannedDate;
                                        getReturnable.status = drugOrderDetail.CurrentStateDef.Description;

                                        getReturnable.isReturnable = isReturnable;
                                        restAmount = restAmount - (double)drugOrderDetail.Amount;
                                        getReturnableDrugOrderDetails.Add(getReturnable);
                                    }
                                    else
                                    {
                                        if (drugOrderDetail.DrugReturnActionDetail != null)
                                        {
                                            if (drugOrderDetail.DrugReturnActionDetail.DrugReturnAction.CurrentStateDefID == DrugReturnAction.States.Approval)
                                                restAmount = restAmount - (double)drugOrderDetail.Amount;
                                        }
                                        else if (drugOrderDetail.DrugDeliveryActionDetail != null)
                                        {
                                            if (drugOrderDetail.DrugDeliveryActionDetail.DrugDeliveryAction != null)
                                                if (drugOrderDetail.DrugDeliveryActionDetail.DrugDeliveryAction.CurrentStateDefID == DrugReturnAction.States.New)
                                                    restAmount = restAmount - (double)drugOrderDetail.Amount;
                                        }
                                    }
                                }
                            }

                            if (restAmount > 0)
                            {
                                DrugReturnAction.GetReturnableDrugOrderDetails_Output getReturnable = new DrugReturnAction.GetReturnableDrugOrderDetails_Output();
                                getReturnable.ObjectID = drugOrder.ObjectID;
                                getReturnable.drugName = drugOrder.Material.Name;
                                getReturnable.amount = restAmount;
                                getReturnable.drugOrderTransaction = allPatientDrugOrderTrx.ObjectID.Value;
                                getReturnable.materialObjectID = drugOrder.Material.ObjectID;
                                getReturnable.returnAmount = restAmount;
                                getReturnable.transactionDate = (DateTime)drugOrder.PlannedStartTime;
                                getReturnable.status = "Bulunamadı";
                                getReturnable.isReturnable = isReturnable;
                                getReturnableDrugOrderDetails.Add(getReturnable);
                            }
                            getDrugReturnAndDeliveryDetails.getDrugReturnAndDeliveryDetails = getReturnableDrugOrderDetails;
                        }
                    }

                    BindingList<DrugOrderDetail.GetHalfDoseDrugOrderDetail_Class> halfDoses = DrugOrderDetail.GetHalfDoseDrugOrderDetail(new Guid(input.subEpisodeID));
                    foreach (DrugOrderDetail.GetHalfDoseDrugOrderDetail_Class halfDose in halfDoses)
                    {

                        DrugOrderDetail drugOrderDetail = (DrugOrderDetail)objectContext.GetObject(halfDose.ObjectID.Value, typeof(DrugOrderDetail));
                        DrugActiveIngredient activeIngredient = findDrugActiveIngredient((DrugDefinition)drugOrderDetail.Material);
                        HalfDoseDestructionDVO halfDoseDestructionDVO = new HalfDoseDestructionDVO();
                        halfDoseDestructionDVO.drugName = drugOrderDetail.Material.Name;
                        halfDoseDestructionDVO.drugOrderDetail = drugOrderDetail;
                        halfDoseDestructionDVO.unitName = activeIngredient.Unit.Name;
                        halfDoseDestructionDVO.unitDefinition = activeIngredient.Unit;
                        double restAmount = (double)drugOrderDetail.Amount - (double)drugOrderDetail.DoseAmount;
                        halfDoseDestructionDVO.amount = restAmount * (double)activeIngredient.Value;
                        getDrugReturnAndDeliveryDetails.halfDoseDestructionDVOs.Add(halfDoseDestructionDVO);

                    }
                }
                return getDrugReturnAndDeliveryDetails;
            }
        }


        public DrugActiveIngredient findDrugActiveIngredient(DrugDefinition drugDefinition)
        {
            DrugActiveIngredient drugActiveIngredient = null;
            if (drugDefinition.DrugActiveIngredients.Count > 0)
            {
                if (drugDefinition.DrugActiveIngredients.Select(x => x.IsParentIngredient = true).Any())
                {
                    drugActiveIngredient = drugDefinition.DrugActiveIngredients.Where(t => t.IsParentIngredient == true).FirstOrDefault();
                }
                else
                {
                    drugActiveIngredient = drugDefinition.DrugActiveIngredients[0];
                }
            }
            return drugActiveIngredient;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public GetDrugReturnAndDeliveryDetails CreateDrugReturnAction(DrugReturnAction.DrugReturnActionCreate_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<DrugReturnActionDetail> details = new List<DrugReturnActionDetail>();
                foreach (DrugReturnAction.GetReturnableDrugOrderDetails_Output item in input.getDrugReturnAndDeliveryDetail.SelectedDrugReturnAndDeliveryDetails)
                {

                    if (details.Where(x => x.DrugOrderTransaction.DrugOrder.Material.ObjectID == item.materialObjectID
                                 && x.DrugOrderTransaction.ObjectID == item.drugOrderTransaction).Any())
                    {
                        details.Where(x => x.DrugOrderTransaction.DrugOrder.Material.ObjectID == item.materialObjectID && x.DrugOrderTransaction.ObjectID == item.drugOrderTransaction).FirstOrDefault().Amount += item.amount;
                        details.Where(x => x.DrugOrderTransaction.DrugOrder.Material.ObjectID == item.materialObjectID && x.DrugOrderTransaction.ObjectID == item.drugOrderTransaction).FirstOrDefault().SendAmount += item.amount;
                        DrugOrderDetail detailOrder = (DrugOrderDetail)objectContext.GetObject(item.ObjectID, typeof(DrugOrderDetail));
                        UndoTransitionDrugOrderDetail(details.Where(x => x.DrugOrderTransaction.DrugOrder.Material.ObjectID == item.materialObjectID && x.DrugOrderTransaction.ObjectID == item.drugOrderTransaction).FirstOrDefault(), detailOrder, objectContext);
                        details.Where(x => x.DrugOrderTransaction.DrugOrder.Material.ObjectID == item.materialObjectID && x.DrugOrderTransaction.ObjectID == item.drugOrderTransaction).FirstOrDefault().DrugOrderDetails.Add(detailOrder);
                    }
                    else
                    {
                        if (item.status == "Bulunamadı")
                        {
                            DrugOrderDetail newDrugOrderDetail = new DrugOrderDetail(objectContext);
                            DrugOrder drugOrder = (DrugOrder)objectContext.GetObject(item.ObjectID, typeof(DrugOrder));
                            newDrugOrderDetail.Amount = item.amount;

                            bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrder.Material);
                            if (drugType)
                            {
                                newDrugOrderDetail.DoseAmount = item.amount;
                                newDrugOrderDetail.Eligible = true;
                            }
                            else
                            {
                                newDrugOrderDetail.DoseAmount = item.amount * (double)((DrugDefinition)drugOrder.Material).Dose;
                                newDrugOrderDetail.Eligible = false;
                            }

                            newDrugOrderDetail.ActionDate = DateTime.Now;
                            newDrugOrderDetail.Day = drugOrder.Day;
                            newDrugOrderDetail.DrugOrder = drugOrder;
                            newDrugOrderDetail.Episode = drugOrder.Episode;
                            newDrugOrderDetail.Frequency = drugOrder.Frequency;
                            newDrugOrderDetail.FromResource = drugOrder.FromResource;
                            newDrugOrderDetail.MasterResource = drugOrder.MasterResource;
                            newDrugOrderDetail.SecondaryMasterResource = drugOrder.SecondaryMasterResource;
                            newDrugOrderDetail.HospitalTimeSchedule = drugOrder.HospitalTimeSchedule;
                            newDrugOrderDetail.Material = drugOrder.Material;
                            newDrugOrderDetail.Note = TTUtils.CultureService.GetText("M25626", "Ezcaneye İade Edildi.");
                            newDrugOrderDetail.NursingApplication = drugOrder.NursingApplication;
                            newDrugOrderDetail.OrderPlannedDate = DateTime.Now.AddMinutes(-5);
                            newDrugOrderDetail.PlannedStartTime = DateTime.Now.AddMinutes(-5);
                            newDrugOrderDetail.Store = drugOrder.Store;
                            newDrugOrderDetail.UsageNote = drugOrder.UsageNote;
                            newDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                            newDrugOrderDetail.Update();
                            newDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.ReturnPharmacy;
                            newDrugOrderDetail.Update();


                            DrugReturnActionDetail doDetail = new DrugReturnActionDetail(objectContext);
                            doDetail.Amount = item.amount;
                            doDetail.DrugName = item.drugName;
                            doDetail.DrugOrderDetails.Add(newDrugOrderDetail);
                            DrugOrderTransaction xTrans = (DrugOrderTransaction)objectContext.GetObject(item.drugOrderTransaction, typeof(DrugOrderTransaction));
                            doDetail.DrugOrderTransaction = xTrans;
                            doDetail.SendAmount = item.amount;
                            details.Add(doDetail);

                            newDrugOrderDetail.DrugReturnActionDetail = doDetail;

                        }
                        else
                        {

                            DrugReturnActionDetail doDetail = new DrugReturnActionDetail(objectContext);
                            doDetail.Amount = item.amount;
                            doDetail.DrugName = item.drugName;
                            DrugOrderDetail xDet = (DrugOrderDetail)objectContext.GetObject(item.ObjectID, typeof(DrugOrderDetail));
                            UndoTransitionDrugOrderDetail(doDetail, xDet, objectContext);
                            DrugOrderTransaction xTrans = (DrugOrderTransaction)objectContext.GetObject(item.drugOrderTransaction, typeof(DrugOrderTransaction));
                            doDetail.DrugOrderTransaction = xTrans;
                            doDetail.SendAmount = item.amount;
                            details.Add(doDetail);
                        }
                    }
                }
                DrugReturnAction drugReturnAction = new DrugReturnAction(objectContext);
                drugReturnAction.DrugReturnReason = input.txtIadeNedeni;
                drugReturnAction.ActionDate = Common.RecTime();
                drugReturnAction.PharmacyStoreDefinition = Store.GetPharmacyStore(objectContext);
                drugReturnAction.DrugReturnReason = input.txtIadeNedeni;


                if (input.getDrugReturnAndDeliveryDetail.MasterResource != Guid.Empty)
                {
                    drugReturnAction.MasterResource = (ResSection)objectContext.GetObject(input.getDrugReturnAndDeliveryDetail.MasterResource, typeof(ResSection));

                }
                if (input.getDrugReturnAndDeliveryDetail.SecondaryMasterResource != Guid.Empty)
                    drugReturnAction.SecondaryMasterResource = (ResSection)objectContext.GetObject(input.getDrugReturnAndDeliveryDetail.SecondaryMasterResource, typeof(ResSection));
                if (input.getDrugReturnAndDeliveryDetail.SubEpisode != Guid.Empty)
                    drugReturnAction.SubEpisode = (SubEpisode)objectContext.GetObject(input.getDrugReturnAndDeliveryDetail.SubEpisode, typeof(SubEpisode));
                BindingList<Resource> resources = ResSection.GetResourceByStore(objectContext, drugReturnAction.PharmacyStoreDefinition.ObjectID);
                if (resources.Count > 0)
                {
                    drugReturnAction.FromResource = (ResSection)resources[0];
                }

                drugReturnAction.Episode = (Episode)objectContext.GetObject(input.getDrugReturnAndDeliveryDetail.Episode, typeof(Episode));

                foreach (DrugReturnActionDetail itemDet in details)
                {
                    itemDet.DrugReturnAction = drugReturnAction;
                }

                drugReturnAction.CurrentStateDefID = DrugReturnAction.States.New;
                objectContext.Update();
                drugReturnAction.CurrentStateDefID = DrugReturnAction.States.Approval;
                objectContext.Save();
            }

            DrugReturnAction.GetDrugReturnAndDeliveryDetail_Input createNew = new DrugReturnAction.GetDrugReturnAndDeliveryDetail_Input();
            createNew.subEpisodeID = input.getDrugReturnAndDeliveryDetail.SubEpisode.ToString();
            return this.GetDrugReturnAndDeliveryDetail(createNew);

        }

        public void UndoTransitionDrugOrderDetail(DrugReturnActionDetail doDetail, DrugOrderDetail drugOrderDetail, TTObjectContext objectContext)
        {
            if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Cancel)
            {
                ((ITTObject)drugOrderDetail).UndoLastTransition();
                objectContext.Update();
                doDetail.DrugOrderDetails.Add(drugOrderDetail);
                drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
                objectContext.Update();
            }
            else
            {
                doDetail.DrugOrderDetails.Add(drugOrderDetail);
            }
        }

        public void UndoTransitionDrugOrderDetail(DrugDeliveryActionDetail doDetail, DrugOrderDetail drugOrderDetail, TTObjectContext objectContext)
        {
            if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Cancel)
            {
                ((ITTObject)drugOrderDetail).UndoLastTransition();
                objectContext.Update();
                doDetail.DrugOrderDetails.Add(drugOrderDetail);
                drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
                objectContext.Update();
            }
            else
            {
                doDetail.DrugOrderDetails.Add(drugOrderDetail);
            }
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public DrugReturnAction.GetDrugReturnAndDeliveryDetails CreateDrugDeliveryAction(DrugReturnAction.DrugDeliveryActionCreate_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<DrugDeliveryActionDetail> details = new List<DrugDeliveryActionDetail>();
                foreach (DrugReturnAction.GetReturnableDrugOrderDetails_Output item in input.getDrugReturnAndDeliveryDetail.SelectedDrugReturnAndDeliveryDetails)
                {

                    if (details.Where(x => x.DrugOrderTransaction.DrugOrder.Material.ObjectID == item.materialObjectID
                                 && x.DrugOrderTransaction.ObjectID == item.drugOrderTransaction).Any())
                    {
                        details.Where(x => x.DrugOrderTransaction.DrugOrder.Material.ObjectID == item.materialObjectID && x.DrugOrderTransaction.ObjectID == item.drugOrderTransaction).FirstOrDefault().ResDose += item.amount;
                        DrugOrderDetail detailOrder = (DrugOrderDetail)objectContext.GetObject(item.ObjectID, typeof(DrugOrderDetail));
                        details.Where(x => x.DrugOrderTransaction.DrugOrder.Material.ObjectID == item.materialObjectID && x.DrugOrderTransaction.ObjectID == item.drugOrderTransaction).FirstOrDefault().DrugOrderDetails.Add(detailOrder);
                    }
                    else
                    {
                        if (item.status == "Bulunamadı")
                        {
                            DrugOrderDetail newDrugOrderDetail = new DrugOrderDetail(objectContext);
                            DrugOrder drugOrder = (DrugOrder)objectContext.GetObject(item.ObjectID, typeof(DrugOrder));
                            newDrugOrderDetail.Amount = item.amount;

                            bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrder.Material);
                            if (drugType)
                            {
                                newDrugOrderDetail.DoseAmount = item.amount;
                                newDrugOrderDetail.Eligible = true;
                            }
                            else
                            {
                                newDrugOrderDetail.DoseAmount = item.amount * (double)((DrugDefinition)drugOrder.Material).Dose;
                                newDrugOrderDetail.Eligible = false;
                            }

                            newDrugOrderDetail.ActionDate = DateTime.Now;
                            newDrugOrderDetail.Day = drugOrder.Day;
                            newDrugOrderDetail.DrugOrder = drugOrder;
                            newDrugOrderDetail.Episode = drugOrder.Episode;
                            newDrugOrderDetail.Frequency = drugOrder.Frequency;
                            newDrugOrderDetail.FromResource = drugOrder.FromResource;
                            newDrugOrderDetail.MasterResource = drugOrder.MasterResource;
                            newDrugOrderDetail.SecondaryMasterResource = drugOrder.SecondaryMasterResource;
                            newDrugOrderDetail.HospitalTimeSchedule = drugOrder.HospitalTimeSchedule;
                            newDrugOrderDetail.Material = drugOrder.Material;
                            newDrugOrderDetail.Note = TTUtils.CultureService.GetText("M25626", "Ezcaneye İade Edildi.");
                            newDrugOrderDetail.NursingApplication = drugOrder.NursingApplication;
                            newDrugOrderDetail.OrderPlannedDate = DateTime.Now.AddMinutes(-5);
                            newDrugOrderDetail.PlannedStartTime = DateTime.Now.AddMinutes(-5);
                            newDrugOrderDetail.Store = drugOrder.Store;
                            newDrugOrderDetail.UsageNote = drugOrder.UsageNote;
                            newDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                            newDrugOrderDetail.Update();
                            newDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.PatientDelivery;
                            newDrugOrderDetail.Update();



                            DrugDeliveryActionDetail doDetail = new DrugDeliveryActionDetail(objectContext);
                            doDetail.ResDose = item.amount;
                            doDetail.DrugName = item.drugName;

                            doDetail.DrugOrderDetails.Add(newDrugOrderDetail);
                            DrugOrderTransaction xTrans = (DrugOrderTransaction)objectContext.GetObject(item.drugOrderTransaction, typeof(DrugOrderTransaction));
                            doDetail.DrugOrderTransaction = xTrans;
                            newDrugOrderDetail.DrugDeliveryActionDetail = doDetail;
                            details.Add(doDetail);
                        }
                        else
                        {
                            DrugDeliveryActionDetail doDetail = new DrugDeliveryActionDetail(objectContext);
                            doDetail.ResDose = item.amount;
                            doDetail.DrugName = item.drugName;
                            DrugOrderDetail xDet = (DrugOrderDetail)objectContext.GetObject(item.ObjectID, typeof(DrugOrderDetail));
                            UndoTransitionDrugOrderDetail(doDetail, xDet, objectContext);
                            doDetail.DrugOrderDetails.Add(xDet);
                            DrugOrderTransaction xTrans = (DrugOrderTransaction)objectContext.GetObject(item.drugOrderTransaction, typeof(DrugOrderTransaction));
                            doDetail.DrugOrderTransaction = xTrans;
                            xDet.DrugDeliveryActionDetail = doDetail;
                            details.Add(doDetail);
                        }
                    }
                }
                DrugDeliveryAction drugDeliveryAction = new DrugDeliveryAction(objectContext);
                drugDeliveryAction.ActionDate = Common.RecTime();
                drugDeliveryAction.Episode = (Episode)objectContext.GetObject(input.getDrugReturnAndDeliveryDetail.Episode, typeof(Episode));
                if (input.getDrugReturnAndDeliveryDetail.MasterResource != Guid.Empty)
                    drugDeliveryAction.MasterResource = (ResSection)objectContext.GetObject(input.getDrugReturnAndDeliveryDetail.MasterResource, typeof(ResSection));
                if (input.getDrugReturnAndDeliveryDetail.SecondaryMasterResource != Guid.Empty)
                    drugDeliveryAction.SecondaryMasterResource = (ResSection)objectContext.GetObject(input.getDrugReturnAndDeliveryDetail.SecondaryMasterResource, typeof(ResSection));
                if (input.getDrugReturnAndDeliveryDetail.SubEpisode != Guid.Empty)
                    drugDeliveryAction.SubEpisode = (SubEpisode)objectContext.GetObject(input.getDrugReturnAndDeliveryDetail.SubEpisode, typeof(SubEpisode));

                foreach (DrugDeliveryActionDetail itemDet in details)
                {
                    itemDet.DrugDeliveryAction = drugDeliveryAction;
                }


                drugDeliveryAction.CurrentStateDefID = DrugDeliveryAction.States.New;
                objectContext.Update();
                drugDeliveryAction.CurrentStateDefID = DrugDeliveryAction.States.Completed;
                objectContext.Save();
            }
            DrugReturnAction.GetDrugReturnAndDeliveryDetail_Input createNew = new DrugReturnAction.GetDrugReturnAndDeliveryDetail_Input();
            createNew.subEpisodeID = input.getDrugReturnAndDeliveryDetail.SubEpisode.ToString();
            return this.GetDrugReturnAndDeliveryDetail(createNew);
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<DrugReturnAction.GetWaitingPharmacy_Output> GetWaitingPharmacy(DrugReturnAction.GetWaitingPharmacy_Input input)
        {
            List<DrugReturnAction.GetWaitingPharmacy_Output> getWaitingList = new List<DrugReturnAction.GetWaitingPharmacy_Output>();
            using (var objectContext = new TTObjectContext(false))
            {
                BindingList<DrugReturnAction.GetWaitingPharmcyByEpisode_Class> getWaitingPharmcyList = DrugReturnAction.GetWaitingPharmcyByEpisode(input.subepisode, input.episode);
                foreach (DrugReturnAction.GetWaitingPharmcyByEpisode_Class action in getWaitingPharmcyList)
                {
                    DrugReturnAction.GetWaitingPharmacy_Output outputItem = new DrugReturnAction.GetWaitingPharmacy_Output();
                    DrugReturnAction drugReturn = (DrugReturnAction)objectContext.GetObject(action.ObjectID.Value, typeof(DrugReturnAction));
                    outputItem.ObjectID = drugReturn.ObjectID;
                    outputItem.ID = drugReturn.ID.ToString();
                    outputItem.DrugReturnReason = drugReturn.DrugReturnReason;
                    outputItem.ActionDate = drugReturn.ActionDate.Value;

                    List<DrugReturnAction.GetWaitingPharmacyDetail_Output> xDet = new List<DrugReturnAction.GetWaitingPharmacyDetail_Output>();
                    foreach (DrugReturnActionDetail det in drugReturn.DrugReturnActionDetails.Select(string.Empty))
                    {
                        DrugReturnAction.GetWaitingPharmacyDetail_Output inDet = new DrugReturnAction.GetWaitingPharmacyDetail_Output();
                        inDet.ObjectID = det.ObjectID;
                        inDet.MaterialName = det.DrugName;
                        inDet.Amount = det.Amount.ToString();
                        xDet.Add(inDet);
                    }
                    outputItem.details = xDet;
                    getWaitingList.Add(outputItem);
                }
            }
            return getWaitingList;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<DrugReturnAction.GetComplatedPharmacy_Output> GetComplatedPharmacy(DrugReturnAction.GetWaitingPharmacy_Input input)
        {
            List<DrugReturnAction.GetComplatedPharmacy_Output> getComplatedList = new List<DrugReturnAction.GetComplatedPharmacy_Output>();
            using (var objectContext = new TTObjectContext(false))
            {
                BindingList<DrugReturnAction.GetComplatedPharmcyByEpisode_Class> getWaitingPharmcyList = DrugReturnAction.GetComplatedPharmcyByEpisode(input.episode, input.subepisode);
                foreach (DrugReturnAction.GetComplatedPharmcyByEpisode_Class action in getWaitingPharmcyList)
                {
                    DrugReturnAction.GetComplatedPharmacy_Output outputItem = new DrugReturnAction.GetComplatedPharmacy_Output();
                    DrugReturnAction drugReturn = (DrugReturnAction)objectContext.GetObject(action.ObjectID.Value, typeof(DrugReturnAction));
                    outputItem.ObjectID = drugReturn.ObjectID;
                    outputItem.ID = drugReturn.ID.ToString();
                    outputItem.DrugReturnReason = drugReturn.DrugReturnReason;
                    outputItem.ActionDate = drugReturn.ActionDate.Value;

                    List<DrugReturnAction.GetComplatedPharmacyDetail_Output> xDet = new List<DrugReturnAction.GetComplatedPharmacyDetail_Output>();
                    foreach (DrugReturnActionDetail det in drugReturn.DrugReturnActionDetails.Select(string.Empty))
                    {
                        DrugReturnAction.GetComplatedPharmacyDetail_Output inDet = new DrugReturnAction.GetComplatedPharmacyDetail_Output();
                        inDet.ObjectID = det.ObjectID;
                        inDet.MaterialName = det.DrugName;
                        inDet.Amount = det.Amount.ToString();
                        xDet.Add(inDet);
                    }
                    outputItem.details = xDet;
                    getComplatedList.Add(outputItem);
                }
            }
            return getComplatedList;
        }

        public class CreateHalfDoseDestruction_Input
        {
            public Guid episodeID { get; set; }
            public Guid subEpisodeID { get; set; }
            public Guid masterResourceID { get; set; }
            public Guid secondaryMasterResourceID { get; set; }
            public List<HalfDoseDestructionDVO> halfDoseDestructionDetails { get; set; }
        }

        public class CreateHalfDoseDestruction_Output
        {
            public List<HalfDoseDestructionDVO> halfDoseDestructionDVOs { get; set; }
            public Guid objectID { get; set; }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public CreateHalfDoseDestruction_Output CreateHalfDoseDestruction(CreateHalfDoseDestruction_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                HalfDoseDestruction halfDoseDestruction = new HalfDoseDestruction(objectContext);
                halfDoseDestruction.ActionDate = Common.RecTime();
                halfDoseDestruction.PharmacyStoreDefinition = Store.GetPharmacyStore(objectContext);

                if (input.episodeID != Guid.Empty)
                {
                    Episode episode = (Episode)objectContext.GetObject(input.episodeID, typeof(Episode));
                    halfDoseDestruction.Episode = episode;
                }
                if (input.subEpisodeID != Guid.Empty)
                {
                    SubEpisode subEpisode = (SubEpisode)objectContext.GetObject(input.subEpisodeID, typeof(SubEpisode));
                    halfDoseDestruction.SubEpisode = subEpisode;
                }
                if (input.masterResourceID != Guid.Empty)
                {
                    ResSection masterResource = (ResSection)objectContext.GetObject(input.masterResourceID, typeof(ResSection));
                    halfDoseDestruction.MasterResource = masterResource;
                }
                if (input.secondaryMasterResourceID != Guid.Empty)
                {
                    ResSection secondaryMasterResource = (ResSection)objectContext.GetObject(input.secondaryMasterResourceID, typeof(ResSection));
                    halfDoseDestruction.SecondaryMasterResource = secondaryMasterResource;
                }

                BindingList<Resource> resources = ResSection.GetResourceByStore(objectContext, halfDoseDestruction.PharmacyStoreDefinition.ObjectID);
                if (resources.Count > 0)
                {
                    halfDoseDestruction.FromResource = (ResSection)resources[0];
                }
                List<DrugOrderDetail> details = new List<DrugOrderDetail>();
                foreach (HalfDoseDestructionDVO detail in input.halfDoseDestructionDetails)
                {
                    HalfDoseDestructionDetail halfDoseDestructionDetail = new HalfDoseDestructionDetail(objectContext);
                    halfDoseDestructionDetail.Amount = detail.amount;
                    halfDoseDestructionDetail.DrugName = detail.drugName;
                    halfDoseDestructionDetail.UnitDefinition = detail.unitDefinition;
                    DrugOrderDetail drugOrderDetail = (DrugOrderDetail)objectContext.GetObject(detail.drugOrderDetail.ObjectID, typeof(DrugOrderDetail));
                    DrugDefinition drugDefinition = (DrugDefinition)drugOrderDetail.Material;
                    if (drugDefinition.DrugShapeType != null)
                        halfDoseDestructionDetail.NFCType = Common.GetDisplayTextOfEnumValue("DrugShapeTypeEnum", (int)drugDefinition.DrugShapeType.Value);
                    drugOrderDetail.HalfDoseDestructionDetail = halfDoseDestructionDetail;
                    details.Add(drugOrderDetail);
                    halfDoseDestructionDetail.HalfDoseDestruction = halfDoseDestruction;
                }
                halfDoseDestruction.ProcedureByUser = (ResUser)Common.CurrentUser.UserObject;
                halfDoseDestruction.StartDate = details.Select(x => x.OrderPlannedDate).Min();
                halfDoseDestruction.EndDate = details.Select(x => x.OrderPlannedDate).Max();

                halfDoseDestruction.CurrentStateDefID = HalfDoseDestruction.States.New;
                objectContext.Update();
                halfDoseDestruction.CurrentStateDefID = HalfDoseDestruction.States.Approval;
                objectContext.Save();

                CreateHalfDoseDestruction_Output output = new CreateHalfDoseDestruction_Output();
                output.objectID = halfDoseDestruction.ObjectID;
                output.halfDoseDestructionDVOs = new List<HalfDoseDestructionDVO>();
                BindingList<DrugOrderDetail.GetHalfDoseDrugOrderDetail_Class> halfDoses = DrugOrderDetail.GetHalfDoseDrugOrderDetail(halfDoseDestruction.SubEpisode.ObjectID);
                foreach (DrugOrderDetail.GetHalfDoseDrugOrderDetail_Class halfDose in halfDoses)
                {

                    DrugOrderDetail drugOrderDetail = (DrugOrderDetail)objectContext.GetObject(halfDose.ObjectID.Value, typeof(DrugOrderDetail));
                    DrugActiveIngredient activeIngredient = findDrugActiveIngredient((DrugDefinition)drugOrderDetail.Material);
                    HalfDoseDestructionDVO halfDoseDestructionDVO = new HalfDoseDestructionDVO();
                    halfDoseDestructionDVO.drugName = drugOrderDetail.Material.Name;
                    halfDoseDestructionDVO.drugOrderDetail = drugOrderDetail;
                    halfDoseDestructionDVO.unitName = activeIngredient.Unit.Name;
                    halfDoseDestructionDVO.unitDefinition = activeIngredient.Unit;
                    double restAmount = (double)drugOrderDetail.Amount - (double)drugOrderDetail.DoseAmount;
                    halfDoseDestructionDVO.amount = restAmount * (double)activeIngredient.Value;
                    output.halfDoseDestructionDVOs.Add(halfDoseDestructionDVO);

                }
                return output;
            }
        }
    }
}