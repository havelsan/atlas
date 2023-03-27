
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
    /// K-Çizelgesi
    /// </summary>
    public partial class KSchedule : StockAction, ICheckStockActionOutDetail, IStockOutTransaction
    {
        public partial class GetKScheduleDrugPrescriptionTotalReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetQuarantineNOForKScheduleQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetQuaratineNOQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetKScheduleReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class KScheduleMaterialBarcodeRQ_Class : TTReportNqlObject
        {
        }

        protected override void PostInsert()
        {
            #region PostInsert



            //            KSchedule kSchedule = this;
            //            BindingList<DrugOrderDetail> myDrugOrderDetails = DrugOrderDetail.GetDrugOrderDetails(kSchedule.ObjectContext, (DateTime)kSchedule.StartDate, (DateTime)kSchedule.EndDate, this.DestinationStore.ObjectID);
            //            foreach (KScheduleMaterial kScheduleMaterial in kSchedule.StockActionOutDetails)
            //            {
            //                KScheduleCollectedOrder kScheduleCollectedOrder = new KScheduleCollectedOrder(this.ObjectContext);
            //                kScheduleMaterial.KScheduleCollectedOrder = kScheduleCollectedOrder;
            //                foreach (DrugOrderDetail orderDetail in myDrugOrderDetails)
            //                {
            //                    if (orderDetail.Material.Equals(kScheduleMaterial.Material))
            //                    {
            //                        Dictionary<object, double> transactionDictionary = DrugOrderTransaction.GetDrugOrderTransactions(orderDetail.Material, orderDetail.Episode);
            //                        if (transactionDictionary.Count == 1)
            //                        {
            //                            foreach (KeyValuePair<object, double> transaction in transactionDictionary)
            //                            {
            //                                orderDetail.KScheduleCollectedOrder = ((DrugOrderTransaction)transaction.Key).KScheduleMaterial.KScheduleCollectedOrder;
            //                            }
            //                            orderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
            //                            kSchedule.ObjectContext.Update();
            //                            orderDetail.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;
            //                        }
            //                        else
            //                        {
            //                            orderDetail.KScheduleCollectedOrder = kScheduleCollectedOrder;
            //                        }
            //                    }
            //                }
            //            }


            #endregion PostInsert
        }

        protected void PreTransition_RequestPreparation2RequestFulfilled()
        {
            // From State : MKYS   To State : RequestFulfilled
            #region PreTransition_RequestPreparation2RequestFulfilled

            TransactionDate = Common.RecTime();

            #endregion PreTransition_MKYS2RequestFulfilled
        }

        protected void PostTransition_RequestPreparation2RequestFulfilled()
        {
            // From State : RequestPreparation   To State : RequestFulfilled
            #region PostTransition_RequestPreparation2RequestFulfilled

            KSchedule kSchedule = this;
            double restAmount = 0;
            double restVolume = 0;

            string concurrencyError = string.Empty;
            foreach (KScheduleMaterial kScheduleMaterial in kSchedule.StockActionOutDetails)
            {
                if (kScheduleMaterial.Status == StockActionDetailStatusEnum.Completed)
                {
                    foreach (DrugOrderDetail stateDrugOrderDetail in kScheduleMaterial.KScheduleCollectedOrder.DrugOrderDetails)
                    {
                        if (stateDrugOrderDetail.DrugOrder.CurrentStateDefID == DrugOrder.States.Stopped)
                        {
                            concurrencyError += kScheduleMaterial.Material.Name + " , ";
                        }
                    }
                }
            }
            foreach (KSchedulePatienOwnDrug ownDrug in kSchedule.KSchedulePatienOwnDrugs)
            {
                if (ownDrug.StockActionStatus == StockActionDetailStatusEnum.Completed)
                {
                    foreach (DrugOrderDetail stateDrugOrderDetail in ownDrug.DrugOrderDetails)
                    {
                        if (stateDrugOrderDetail.DrugOrder.CurrentStateDefID == DrugOrder.States.Stopped)
                        {
                            concurrencyError += ownDrug.Material.Name + " , ";
                        }
                    }
                }
            }
            if (String.IsNullOrEmpty(concurrencyError) == false)
            {
                throw new TTException(concurrencyError + " ilaçlar doktor tarafından durdurulmuştur.Karşılanma Durumu İPTAL'E getirip istek karşılama işlemini tekrar deneyiniz.");
            }







            foreach (KScheduleMaterial kScheduleMaterial in kSchedule.StockActionOutDetails)
            {
                Dictionary<Guid, object> drugOrderDetailDictionary = new Dictionary<Guid, object>();
                if (kScheduleMaterial.Status != StockActionDetailStatusEnum.Deleted && kScheduleMaterial.Status != StockActionDetailStatusEnum.Cancelled && kScheduleMaterial.Status != StockActionDetailStatusEnum.BarcodeIsNotVerified)
                {
                    Dictionary<Guid, object> drugOrderDictionary = new Dictionary<Guid, object>();
                    restAmount = (double)kScheduleMaterial.Amount;

                    if (((DrugDefinition)kScheduleMaterial.Material).Volume == null)
                    {
                        throw new TTException(kScheduleMaterial.Material.Name + " isimli ilacın \"Hacim\" bilgisi tanımlanmamış durumda olduğu için işlem ilerletilemez!. Belirtilen ilacın \"Hacim\" bilgisinin tanımlanmasını sağladıktan sonra İstek Karşılama işlemini tekrar deneyiniz.");
                    }

                    restVolume = (double)((DrugDefinition)kScheduleMaterial.Material).Volume * (double)kScheduleMaterial.Amount;
                    foreach (DrugOrderDetail stateDrugOrderDetail in kScheduleMaterial.KScheduleCollectedOrder.DrugOrderDetails)
                    {
                        if (DrugOrder.GetDrugUsedType(((DrugDefinition)stateDrugOrderDetail.Material)))
                        {
                            if (restAmount >= stateDrugOrderDetail.Amount)
                            {
                                if (stateDrugOrderDetail.CurrentStateDefID.ToString() == DrugOrderDetail.States.Request.ToString())
                                {
                                    stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Supply;
                                    if (!drugOrderDictionary.ContainsKey(stateDrugOrderDetail.DrugOrder.ObjectID))
                                    {
                                        drugOrderDictionary.Add(stateDrugOrderDetail.DrugOrder.ObjectID, stateDrugOrderDetail.DrugOrder);
                                    }
                                }
                                restAmount = restAmount - (double)stateDrugOrderDetail.Amount;
                            }
                            else
                            {
                                if (stateDrugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Request)
                                {
                                    stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                                }
                                if (drugOrderDetailDictionary.ContainsKey(stateDrugOrderDetail.ObjectID) == false)
                                {
                                    drugOrderDetailDictionary.Add(stateDrugOrderDetail.ObjectID, stateDrugOrderDetail);
                                }
                            }
                        }
                        else
                        {
                            if (restVolume >= stateDrugOrderDetail.Amount)
                            {
                                if (stateDrugOrderDetail.CurrentStateDefID.ToString() == DrugOrderDetail.States.Request.ToString())
                                {
                                    stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Supply;
                                    if (!drugOrderDictionary.ContainsKey(stateDrugOrderDetail.DrugOrder.ObjectID))
                                    {
                                        drugOrderDictionary.Add(stateDrugOrderDetail.DrugOrder.ObjectID, stateDrugOrderDetail.DrugOrder);
                                    }
                                }
                                restVolume = restVolume - (double)stateDrugOrderDetail.Amount;
                            }
                            else
                            {
                                if (stateDrugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Request)
                                {
                                    stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                                }
                                if (drugOrderDetailDictionary.ContainsKey(stateDrugOrderDetail.ObjectID) == false)
                                {
                                    drugOrderDetailDictionary.Add(stateDrugOrderDetail.ObjectID, stateDrugOrderDetail);
                                }

                            }
                        }
                    }
                    foreach (KeyValuePair<Guid, object> dic in drugOrderDictionary)
                    {
                        DrugOrderTransaction drugOrderTransaction = new DrugOrderTransaction(kSchedule.ObjectContext);
                        drugOrderTransaction.DrugOrder = (DrugOrder)dic.Value;
                        drugOrderTransaction.KScheduleMaterial = kScheduleMaterial;
                        drugOrderTransaction.TransactionDate = TransactionDate;
                        bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)kScheduleMaterial.Material);
                        if (drugType)
                        {
                            drugOrderTransaction.Amount = kScheduleMaterial.Amount;
                        }
                        else
                        {
                            drugOrderTransaction.Amount = kScheduleMaterial.Amount * ((DrugDefinition)kScheduleMaterial.Material).Volume;
                        }
                    }
                }
                else if (kScheduleMaterial.Status == StockActionDetailStatusEnum.Deleted)
                {
                    kScheduleMaterial.Amount = 0;
                }
                else
                {
                    foreach (DrugOrderDetail stateDrugOrderDetail in kScheduleMaterial.KScheduleCollectedOrder.DrugOrderDetails)
                    {
                        if (stateDrugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Request)
                        {
                            stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                        }
                        if (drugOrderDetailDictionary.ContainsKey(stateDrugOrderDetail.ObjectID) == false)
                        {
                            drugOrderDetailDictionary.Add(stateDrugOrderDetail.ObjectID, stateDrugOrderDetail);
                        }
                    }
                    kScheduleMaterial.Amount = 0;
                }
                if (drugOrderDetailDictionary.Count > 0)
                {
                    foreach (KeyValuePair<Guid, object> detail in drugOrderDetailDictionary)
                    {
                        if (((DrugOrderDetail)detail.Value).CurrentStateDefID != DrugOrderDetail.States.Cancel)
                            ((DrugOrderDetail)detail.Value).KScheduleCollectedOrder = null;
                    }
                }
            }
            //SS :  INC056882 Windesk işi ile istenen özellik için değiştirildi.

            foreach (KScheduleMaterial kScheduleMaterial in kSchedule.KScheduleMaterials)
            {
                if (kScheduleMaterial.Status == StockActionDetailStatusEnum.BarcodeIsNotVerified)
                    throw new Exception(kScheduleMaterial.Material.Barcode + " barkodlu " + kScheduleMaterial.Material.Name + " isimli ilacın doğrulaması yapılmamıştır.");
            }

            foreach (KSchedulePatienOwnDrug kSchedulePatienOwnDrug in kSchedule.KSchedulePatienOwnDrugs)
            {
                if (kSchedulePatienOwnDrug.StockActionStatus == StockActionDetailStatusEnum.BarcodeIsNotVerified)
                    throw new Exception("Hastanın yanında getirdiği " + kSchedulePatienOwnDrug.Material.Barcode + " barkodlu " + kSchedulePatienOwnDrug.Material.Name + " isimli ilacın doğrulaması yapılmamıştır.");

                if (kSchedulePatienOwnDrug.StockActionStatus == StockActionDetailStatusEnum.New)
                {
                    foreach (DrugOrderDetail orderDetail in kSchedulePatienOwnDrug.DrugOrderDetails)
                    {
                        if (orderDetail.CurrentStateDefID != DrugOrderDetail.States.Cancel)
                        {
                            orderDetail.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;
                            BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class> patientOwnDrugTrx =
                                PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode(kSchedulePatienOwnDrug.KSchedule.Episode.ObjectID, kSchedulePatienOwnDrug.Material.ObjectID);

                            double trxAmount = 0;
                            if (DrugOrder.GetDrugUsedType((DrugDefinition)orderDetail.Material))
                            {
                                if (orderDetail.Amount != null)
                                    trxAmount = (double)orderDetail.Amount.Value;
                            }
                            else
                            {
                                if (orderDetail.Amount != null)
                                {
                                    double unitDose = (double)((DrugDefinition)orderDetail.Material).Dose / (double)((DrugDefinition)orderDetail.Material).Volume;
                                    trxAmount = (double)orderDetail.Amount.Value * unitDose;
                                }
                            }

                            foreach (PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class trx in patientOwnDrugTrx)
                            {
                                if (trxAmount == 0)
                                    break;
                                PatientOwnDrugTrxDetail trxDet = new PatientOwnDrugTrxDetail(ObjectContext);
                                trxDet.DrugOrderDetail = orderDetail;
                                if (DrugOrder.GetDrugUsedType((DrugDefinition)orderDetail.Material))
                                {
                                    if (orderDetail.Amount != null)
                                        trxDet.Amount = (double)orderDetail.Amount.Value;
                                }
                                else
                                {
                                    if (orderDetail.Amount != null)
                                    {
                                        double unitDose = (double)((DrugDefinition)orderDetail.Material).Dose / (double)((DrugDefinition)orderDetail.Material).Volume;
                                        trxDet.Amount = (double)orderDetail.Amount.Value * unitDose;
                                    }
                                }
                                trxDet.CurrentStateDefID = PatientOwnDrugTrxDetail.States.Completed;
                                trxDet.PatientOwnDrugTrx = (PatientOwnDrugTrx)ObjectContext.GetObject((Guid)trx.ObjectID, typeof(PatientOwnDrugTrx).Name);
                                trxAmount = trxAmount - (double)trxDet.Amount;
                            }
                        }
                    }
                    kSchedulePatienOwnDrug.StockActionStatus = StockActionDetailStatusEnum.Completed;
                }
            }




            if (this is KScheduleDaily)
            {
                foreach (KScheduleMaterial kScheduleMaterial in kSchedule.StockActionOutDetails)
                {
                    foreach (DrugOrderDetail stateDrugOrderDetail in kScheduleMaterial.KScheduleCollectedOrder.DrugOrderDetails)
                    {
                        stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Supply;
                    }
                }
            }

            #endregion PostTransition_RequestPreparation2RequestFulfilled
        }

        protected void PostTransition_RequestPreparation2Cancelled()
        {
            // From State : RequestPreparation   To State : Cancelled
            #region PostTransition_RequestPreparation2Cancelled

            KSchedule kSchedule = this;
            Dictionary<Guid, Guid> collectedOrderDic = new Dictionary<Guid, Guid>();
            foreach (KScheduleMaterial kScheduleMaterial in kSchedule.StockActionOutDetails)
            {
                foreach (DrugOrderDetail stateDrugOrderDetail in kScheduleMaterial.KScheduleCollectedOrder.DrugOrderDetails)
                {
                    if (stateDrugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.Cancel)
                    {
                        //stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                        if (collectedOrderDic.ContainsKey(stateDrugOrderDetail.KScheduleCollectedOrder.ObjectID) == false)
                            collectedOrderDic.Add(stateDrugOrderDetail.KScheduleCollectedOrder.ObjectID, stateDrugOrderDetail.KScheduleCollectedOrder.ObjectID);
                    }
                }
            }

            //Task46997 için yapıldı.
            List<DrugOrder> drugOrderList = new List<DrugOrder>();
            foreach (KScheduleMaterial material in kSchedule.KScheduleMaterials)
            {
                foreach (DrugOrderDetail drugOrderDet in material.KScheduleCollectedOrder.DrugOrderDetails)
                {
                    if (drugOrderDet.CurrentStateDefID != DrugOrderDetail.States.Stop)
                        drugOrderDet.CurrentStateDefID = DrugOrderDetail.States.Cancel;
                    drugOrderList.Add(drugOrderDet.DrugOrder);
                }
            }
            foreach (KScheduleUnListMaterial kScheduleUnListMaterial in kSchedule.KScheduleUnListMaterials)
            {
                foreach (DrugOrderDetail drugOrderDetail in kScheduleUnListMaterial.DrugOrderDetails)
                {
                    if (drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.Stop)
                        drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
                    drugOrderList.Add(drugOrderDetail.DrugOrder);
                }
            }
            foreach (KSchedulePatienOwnDrug kScheduleUnListMaterial in kSchedule.KSchedulePatienOwnDrugs)
            {
                foreach (DrugOrderDetail drugOrderDetail in kScheduleUnListMaterial.DrugOrderDetails)
                {
                    if (drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.Stop)
                        drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
                    drugOrderList.Add(drugOrderDetail.DrugOrder);
                }
            }

            foreach (DrugOrder drugOrder in drugOrderList)
            {
                if (drugOrder.CurrentStateDefID != DrugOrder.States.Stopped)
                    drugOrder.CurrentStateDefID = DrugOrder.States.Cancelled;
            }


            foreach (KeyValuePair<Guid, Guid> deletedCol in collectedOrderDic)
            {
                KScheduleCollectedOrder delOrder = (KScheduleCollectedOrder)ObjectContext.GetObject(deletedCol.Value, "KSCHEDULECOLLECTEDORDER");
                ((ITTObject)delOrder).Delete();
            }

            #endregion PostTransition_RequestPreparation2Cancelled
        }

        protected void PreTransition_RequestFulfilled2Cancelled()
        {
            // From State : RequestFulfilled   To State : Cancelled
            #region PreTransition_RequestFulfilled2Cancelled


            bool cancelled = true;
            string errorMsg = string.Empty;
            foreach (KScheduleMaterial kScheduleMaterial in KScheduleMaterials)
            {
                foreach (DrugOrderDetail drugOrderDetail in kScheduleMaterial.KScheduleCollectedOrder.DrugOrderDetails)
                {
                    if (drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.Supply)
                    {
                        cancelled = false;
                        errorMsg += drugOrderDetail.Material.Name + ", ";
                    }
                }
            }
            foreach (KScheduleUnListMaterial kScheduleUnListMaterial in KScheduleUnListMaterials)
            {
                foreach (DrugOrderDetail drugOrderDetail in kScheduleUnListMaterial.DrugOrderDetails)
                {
                    if (drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.UseRestDose)
                    {
                        cancelled = false;
                        errorMsg += drugOrderDetail.Material.Name + ", ";
                    }
                }
            }

            if (cancelled)
            {
                Dictionary<Guid, Guid> collectedOrderDic = new Dictionary<Guid, Guid>();
                foreach (KScheduleMaterial kScheduleMaterial in KScheduleMaterials)
                {
                    IList drugOrderTransantions = ObjectContext.QueryObjects("DRUGORDERTRANSACTION", "KSCHEDULEMATERIAL=" + ConnectionManager.GuidToString(kScheduleMaterial.ObjectID));
                    foreach (DrugOrderTransaction drugOrderTransaction in drugOrderTransantions)
                    {
                        ((ITTObject)drugOrderTransaction).Delete();
                    }

                    foreach (DrugOrderDetail drugOrderDetail in kScheduleMaterial.KScheduleCollectedOrder.DrugOrderDetails)
                    {
                        drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;//Task46997 için yapıldı.
                        if (collectedOrderDic.ContainsKey(drugOrderDetail.KScheduleCollectedOrder.ObjectID) == false)
                        {
                            collectedOrderDic.Add(drugOrderDetail.KScheduleCollectedOrder.ObjectID, drugOrderDetail.KScheduleCollectedOrder.ObjectID);
                        }
                    }

                    foreach (KeyValuePair<Guid, Guid> deletedCol in collectedOrderDic)
                    {
                        KScheduleCollectedOrder delOrder = (KScheduleCollectedOrder)ObjectContext.GetObject(deletedCol.Value, "KSCHEDULECOLLECTEDORDER");
                        ((ITTObject)delOrder).Delete();
                    }
                }

                foreach (KScheduleUnListMaterial kScheduleUnListMaterial in KScheduleUnListMaterials)
                {
                    foreach (DrugOrderDetail drugOrderDetail in kScheduleUnListMaterial.DrugOrderDetails)
                    {
                        drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;//Task46997 için yapıldı.
                    }
                }
            }
            else
            {
                errorMsg = errorMsg.Substring(0, errorMsg.Length - 2);
                errorMsg = errorMsg + "  ilaç(ların) uygulaması yapıldığı için K-Çizelgesi iptal edilemez.";
                throw new TTException(errorMsg);
            }


            #endregion PreTransition_RequestFulfilled2Cancelled
        }

        protected void PostTransition_Approval2RequestPreparation()
        {
            // From State : Approval   To State : RequestPreparation
            #region PostTransition_Approval2RequestPreparation



            KSchedule kSchedule = this;


            foreach (KScheduleMaterial kScheduleMaterial in KScheduleMaterials)
            {
                if (kScheduleMaterial.Status == StockActionDetailStatusEnum.BarcodeIsNotVerified)
                {
                    throw new Exception(kScheduleMaterial.Material.Barcode + " Barkodlu " + kScheduleMaterial.Material.Name + " ilaç doğrulanmamıştır.");
                }
            }
            foreach (KSchedulePatienOwnDrug patientOwnDrug in KSchedulePatienOwnDrugs)
            {
                if (patientOwnDrug.StockActionStatus == StockActionDetailStatusEnum.BarcodeIsNotVerified)
                {
                    throw new Exception(patientOwnDrug.Material.Barcode + " Barkodlu " + patientOwnDrug.Material.Name + " ilaç doğrulanmamıştır.");
                }
            }


            foreach (KScheduleMaterial kScheduleMaterial in kSchedule.StockActionOutDetails)
            {
                foreach (DrugOrderDetail stateDrugOrderDetail in kScheduleMaterial.KScheduleCollectedOrder.DrugOrderDetails)
                {
                    if (stateDrugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Planned)
                    {
                        stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Request;
                    }
                }
            }




            foreach (KScheduleUnListMaterial kScheduleUnListMaterial in KScheduleUnListMaterials)
            {
                foreach (DrugOrderDetail usedDetail in kScheduleUnListMaterial.DrugOrderDetails)
                {
                    if (usedDetail.CurrentStateDefID == DrugOrderDetail.States.Planned)
                        usedDetail.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;
                    DrugDefinition drugDefinition = ((DrugDefinition)usedDetail.Material);
                    bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                    if (drugType == false)
                    {
                        if (usedDetail.Eligible == true)
                            usedDetail.Eligible = false;
                    }
                }
            }



            #endregion PostTransition_Approval2RequestPreparation
        }

        protected void PostTransition_Approval2MKYS()
        {
            // From State : Approval   To State : MKYS
            #region PostTransition_Approval2MKYS



            KSchedule kSchedule = this;
            foreach (KScheduleMaterial kScheduleMaterial in kSchedule.StockActionOutDetails)
            {
                foreach (DrugOrderDetail stateDrugOrderDetail in kScheduleMaterial.KScheduleCollectedOrder.DrugOrderDetails)
                {
                    if (stateDrugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Planned)
                    {
                        stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Request;
                    }
                }
            }

            foreach (KScheduleUnListMaterial kScheduleUnListMaterial in KScheduleUnListMaterials)
            {
                foreach (DrugOrderDetail usedDetail in kScheduleUnListMaterial.DrugOrderDetails)
                {
                    if (usedDetail.CurrentStateDefID == DrugOrderDetail.States.Planned)
                        usedDetail.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;
                }
            }


            #endregion PostTransition_Approval2MKYS
        }

        protected void PostTransition_InfectionApproval2RequestPreparation()
        {
            // From State : InfectionApproval   To State : RequestPreparation
            #region PostTransition_InfectionApproval2RequestPreparation


            KSchedule kSchedule = this;
            foreach (KScheduleMaterial kScheduleMaterial in kSchedule.StockActionOutDetails)
            {
                foreach (DrugOrderDetail stateDrugOrderDetail in kScheduleMaterial.KScheduleCollectedOrder.DrugOrderDetails)
                {
                    if (stateDrugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Planned)
                        stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Request;
                }
            }
            foreach (KScheduleUnListMaterial kScheduleUnListMaterial in KScheduleUnListMaterials)
            {
                foreach (DrugOrderDetail usedDetail in kScheduleUnListMaterial.DrugOrderDetails)
                {
                    if (usedDetail.CurrentStateDefID == DrugOrderDetail.States.Planned)
                        usedDetail.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;
                }
            }

            #endregion PostTransition_InfectionApproval2RequestPreparation
        }

        protected void PostTransition_InfectionApproval2MKYS()
        {
            // From State : InfectionApproval   To State : MKYS
            #region PostTransition_InfectionApproval2MKYS


            KSchedule kSchedule = this;
            foreach (KScheduleMaterial kScheduleMaterial in kSchedule.StockActionOutDetails)
            {
                foreach (DrugOrderDetail stateDrugOrderDetail in kScheduleMaterial.KScheduleCollectedOrder.DrugOrderDetails)
                {
                    if (stateDrugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Planned)
                        stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Request;
                }
            }
            foreach (KScheduleUnListMaterial kScheduleUnListMaterial in KScheduleUnListMaterials)
            {
                foreach (DrugOrderDetail usedDetail in kScheduleUnListMaterial.DrugOrderDetails)
                {
                    if (usedDetail.CurrentStateDefID == DrugOrderDetail.States.Planned)
                        usedDetail.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;
                }
            }

            #endregion PostTransition_InfectionApproval2MKYS
        }

        protected void PreTransition_MKYS2RequestFulfilled()
        {
            // From State : MKYS   To State : RequestFulfilled
            #region PreTransition_MKYS2RequestFulfilled

            if (MKYSControl == false)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26672", "Önce MKYS Gönder Yapmanız Gerekmektedir.!"));
            }

            #endregion PreTransition_MKYS2RequestFulfilled
        }

        protected void PostTransition_MKYS2RequestFulfilled()
        {
            // From State : MKYS   To State : RequestFulfilled
            #region PostTransition_MKYS2RequestFulfilled



            KSchedule kSchedule = this;
            double restAmount = 0;
            double restVolume = 0;
            foreach (KScheduleMaterial kScheduleMaterial in kSchedule.StockActionOutDetails)
            {
                Dictionary<Guid, object> drugOrderDetailDictionary = new Dictionary<Guid, object>();
                if (kScheduleMaterial.Status != StockActionDetailStatusEnum.Deleted && kScheduleMaterial.Status != StockActionDetailStatusEnum.Cancelled)
                {
                    Dictionary<Guid, object> drugOrderDictionary = new Dictionary<Guid, object>();
                    restAmount = (double)kScheduleMaterial.Amount;
                    restVolume = (double)((DrugDefinition)kScheduleMaterial.Material).Volume * (double)kScheduleMaterial.Amount;
                    foreach (DrugOrderDetail stateDrugOrderDetail in kScheduleMaterial.KScheduleCollectedOrder.DrugOrderDetails)
                    {
                        if (DrugOrder.GetDrugUsedType(((DrugDefinition)stateDrugOrderDetail.Material)))
                        {
                            if (restAmount >= stateDrugOrderDetail.Amount)
                            {
                                if (stateDrugOrderDetail.CurrentStateDefID.ToString() == DrugOrderDetail.States.Request.ToString())
                                {
                                    stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Supply;
                                    if (!drugOrderDictionary.ContainsKey(stateDrugOrderDetail.DrugOrder.ObjectID))
                                    {
                                        drugOrderDictionary.Add(stateDrugOrderDetail.DrugOrder.ObjectID, stateDrugOrderDetail.DrugOrder);
                                    }
                                }
                                restAmount = restAmount - (double)stateDrugOrderDetail.Amount;
                            }
                            else
                            {
                                if (stateDrugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Request)
                                {
                                    stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                                }
                                if (drugOrderDetailDictionary.ContainsKey(stateDrugOrderDetail.ObjectID) == false)
                                {
                                    drugOrderDetailDictionary.Add(stateDrugOrderDetail.ObjectID, stateDrugOrderDetail);
                                }
                            }
                        }
                        else
                        {
                            if (restVolume >= stateDrugOrderDetail.Amount)
                            {
                                if (stateDrugOrderDetail.CurrentStateDefID.ToString() == DrugOrderDetail.States.Request.ToString())
                                {
                                    stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Supply;
                                    if (!drugOrderDictionary.ContainsKey(stateDrugOrderDetail.DrugOrder.ObjectID))
                                    {
                                        drugOrderDictionary.Add(stateDrugOrderDetail.DrugOrder.ObjectID, stateDrugOrderDetail.DrugOrder);
                                    }
                                }
                                restVolume = restVolume - (double)stateDrugOrderDetail.Amount;
                            }
                            else
                            {
                                if (stateDrugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Request)
                                {
                                    stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                                }
                                if (drugOrderDetailDictionary.ContainsKey(stateDrugOrderDetail.ObjectID) == false)
                                {
                                    drugOrderDetailDictionary.Add(stateDrugOrderDetail.ObjectID, stateDrugOrderDetail);
                                }

                            }
                        }
                    }
                    foreach (KeyValuePair<Guid, object> dic in drugOrderDictionary)
                    {
                        DrugOrderTransaction drugOrderTransaction = new DrugOrderTransaction(kSchedule.ObjectContext);
                        drugOrderTransaction.DrugOrder = (DrugOrder)dic.Value;
                        drugOrderTransaction.KScheduleMaterial = kScheduleMaterial;
                        drugOrderTransaction.Amount = kScheduleMaterial.Amount;
                        bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)kScheduleMaterial.Material);
                        if (drugType)
                        {
                            drugOrderTransaction.Amount = kScheduleMaterial.Amount;
                        }
                        else
                        {
                            drugOrderTransaction.Amount = kScheduleMaterial.Amount * ((DrugDefinition)kScheduleMaterial.Material).Volume;
                        }
                    }
                }
                else
                {
                    foreach (DrugOrderDetail stateDrugOrderDetail in kScheduleMaterial.KScheduleCollectedOrder.DrugOrderDetails)
                    {
                        if (stateDrugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Request)
                        {
                            stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                        }
                        if (drugOrderDetailDictionary.ContainsKey(stateDrugOrderDetail.ObjectID) == false)
                        {
                            drugOrderDetailDictionary.Add(stateDrugOrderDetail.ObjectID, stateDrugOrderDetail);
                        }
                    }
                    kScheduleMaterial.Amount = 0;
                }
                if (drugOrderDetailDictionary.Count > 0)
                {
                    foreach (KeyValuePair<Guid, object> detail in drugOrderDetailDictionary)
                    {
                        ((DrugOrderDetail)detail.Value).KScheduleCollectedOrder = null;
                    }
                }
            }
            //SS :  INC056882 Windesk işi ile istenen özellik için değiştirildi.

            if (this is KScheduleDaily)
            {
                foreach (KScheduleMaterial kScheduleMaterial in kSchedule.StockActionOutDetails)
                {
                    foreach (DrugOrderDetail stateDrugOrderDetail in kScheduleMaterial.KScheduleCollectedOrder.DrugOrderDetails)
                    {
                        stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Supply;
                    }
                }
            }
            #endregion PostTransition_MKYS2RequestFulfilled
        }

        protected void PostTransition_MKYS2Cancelled()
        {
            // From State : MKYS   To State : Cancelled
            #region PostTransition_MKYS2Cancelled


            KSchedule kSchedule = this;
            Dictionary<Guid, Guid> collectedOrderDic = new Dictionary<Guid, Guid>();
            foreach (KScheduleMaterial kScheduleMaterial in kSchedule.StockActionOutDetails)
            {
                foreach (DrugOrderDetail stateDrugOrderDetail in kScheduleMaterial.KScheduleCollectedOrder.DrugOrderDetails)
                {
                    stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                    if (collectedOrderDic.ContainsKey(stateDrugOrderDetail.KScheduleCollectedOrder.ObjectID) == false)
                    {
                        collectedOrderDic.Add(stateDrugOrderDetail.KScheduleCollectedOrder.ObjectID, stateDrugOrderDetail.KScheduleCollectedOrder.ObjectID);
                    }
                }
            }
            foreach (KeyValuePair<Guid, Guid> deletedCol in collectedOrderDic)
            {
                KScheduleCollectedOrder delOrder = (KScheduleCollectedOrder)ObjectContext.GetObject(deletedCol.Value, "KSCHEDULECOLLECTEDORDER");
                ((ITTObject)delOrder).Delete();
            }

            #endregion PostTransition_MKYS2Cancelled
        }

        #region Methods
        override protected void OnConstruct()
        {
            base.OnConstruct();

        }

        public class KScheduleTotalMaterial
        {
            public string QuarantinaNo;
            public double TotalAmount;
        }

        public static KScheduleMaterial CreateKScheduleMaterial(TTObjectContext context, DrugOrder drugOrder, double amount)
        {
            KScheduleMaterial kScheduleMaterial = new KScheduleMaterial(context);
            kScheduleMaterial.Material = drugOrder.Material;

            DrugDefinition drugDefinition = (DrugDefinition)drugOrder.Material;
            bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
            if (drugType)
            {

                kScheduleMaterial.RequestAmount = amount;
                kScheduleMaterial.Amount = amount;

            }
            else
            {
                double rAmount = ((double)amount) / ((double)drugDefinition.Volume);
                kScheduleMaterial.Amount = Math.Ceiling(rAmount);
                kScheduleMaterial.RequestAmount = Math.Ceiling(rAmount);
            }
            foreach (InpatientAdmission inpatientAdmission in drugOrder.Episode.InpatientAdmissions)
            {
                if (inpatientAdmission.CurrentStateDefID != InpatientAdmission.States.Cancelled)
                {
                    kScheduleMaterial.QuarantinaNO = inpatientAdmission.QuarantineProtocolNo.Value.ToString();
                    break;
                }
            }

            kScheduleMaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
            kScheduleMaterial.PatientName = drugOrder.Episode.Patient.FullName.ToString();
            kScheduleMaterial.PatientID = drugOrder.Episode.Patient.ID.Value.ToString();

            return kScheduleMaterial;

        }

        public void SetMKYSProperties()
        {
            MKYS_CikisIslemTuru = MKYS_ECikisIslemTuruEnum.cikis;

            MainStoreDefinition mainStoreDefinition = Store as MainStoreDefinition; // Deponun bütçe türünden alınır
            if (mainStoreDefinition != null)
                MKYS_EButceTur = mainStoreDefinition.MKYS_ButceTuru;

            MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckTuketim;

            if (Store != null && Store.UnitStoreGetData != null)
                MKYS_DepoKayitNo = Store.UnitStoreGetData.StoreRecordNo;

            //if(DestinationStore != null && DestinationStore.UnitStoreGetData != null)            // Zorunlu alan değil
            //    MKYS_CikisYapilanDepoKayitNo = DestinationStore.UnitStoreGetData.StoreRecordNo;

            MKYS_MakbuzTarihi = TransactionDate; // TODO : Alınabilecek bir yer varsa alınacak
            MKYS_MakbuzNo = GetNextMKYS_MakbuzNo();

            foreach (StockActionSignDetail stockActionSignDetail in StockActionSignDetails)
            {
                if (stockActionSignDetail.SignUser != null)
                {
                    MKYS_TeslimEden = stockActionSignDetail.SignUser.Name;
                    break;
                }
            }

            SubStoreDefinition subStoreDefinition = DestinationStore as SubStoreDefinition;
            if (subStoreDefinition != null && subStoreDefinition.StoreResponsible != null)
            {
                MKYS_TeslimAlan = subStoreDefinition.StoreResponsible.Name;
                if (subStoreDefinition.StoreResponsible.Person != null && subStoreDefinition.StoreResponsible.Person.UniqueRefNo.HasValue)
                    MKYS_CikisYapilanKisiTCNo = subStoreDefinition.StoreResponsible.Person.UniqueRefNo.Value.ToString();
            }
        }
        #region ICheckStockActionOutDetail Members
        public StockActionDetailOut.ChildStockActionDetailOutCollection GetStockActionOutDetails()
        {
            return StockActionOutDetails;
        }
        #endregion
        #region IStockOutTransaction Members
        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }
        public void SetStore(Store value)
        {
            Store = value;
        }
        #endregion
        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(KSchedule).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == KSchedule.States.RequestFulfilled && toState == KSchedule.States.Cancelled)
                PreTransition_RequestFulfilled2Cancelled();
            else if (fromState == KSchedule.States.MKYS && toState == KSchedule.States.RequestFulfilled)
                PreTransition_MKYS2RequestFulfilled();
            else if (fromState == KSchedule.States.RequestPreparation && toState == KSchedule.States.RequestFulfilled)
                PreTransition_RequestPreparation2RequestFulfilled();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(KSchedule).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == KSchedule.States.RequestPreparation && toState == KSchedule.States.RequestFulfilled)
                PostTransition_RequestPreparation2RequestFulfilled();
            else if (fromState == KSchedule.States.RequestPreparation && toState == KSchedule.States.Cancelled)
                PostTransition_RequestPreparation2Cancelled();
            else if (fromState == KSchedule.States.Approval && toState == KSchedule.States.RequestPreparation)
                PostTransition_Approval2RequestPreparation();
            else if (fromState == KSchedule.States.Approval && toState == KSchedule.States.MKYS)
                PostTransition_Approval2MKYS();
            else if (fromState == KSchedule.States.InfectionApproval && toState == KSchedule.States.RequestPreparation)
                PostTransition_InfectionApproval2RequestPreparation();
            else if (fromState == KSchedule.States.InfectionApproval && toState == KSchedule.States.MKYS)
                PostTransition_InfectionApproval2MKYS();
            else if (fromState == KSchedule.States.MKYS && toState == KSchedule.States.RequestFulfilled)
                PostTransition_MKYS2RequestFulfilled();
            else if (fromState == KSchedule.States.MKYS && toState == KSchedule.States.Cancelled)
                PostTransition_MKYS2Cancelled();
        }

    }
}