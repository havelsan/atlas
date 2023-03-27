
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
    /// İlaç Uygulama
    /// </summary>
    public partial class DrugOrderDetail : BaseDrugOrder, IDrugOrderWorkList
    {
        public partial class DrugOrderDetailListReportNQL_Class : TTReportNqlObject
        {
        }

        public DrugOrderDetail OwnDrugOrderDetail
        {
            get { return this; }
            set { }
        }
        public partial class GetDrugOrderDetailsByDrugOrder_Class : TTReportNqlObject
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "NURSINGAPPLICATION":
                    {
                        NursingApplication value = (NursingApplication)newValue;
                        #region NURSINGAPPLICATION_SetParentScript
                        if (value != null)
                            SubEpisode = value.SubEpisode;
                        #endregion NURSINGAPPLICATION_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected override void PreInsert()
        {
            #region PreInsert

            base.PreInsert();
            //Generate new CRC for my new drug order detail
            TTUtils.Crc32 crc32 = new TTUtils.Crc32();
            byte[] byteArray = crc32.ObjectToByteArray(this);
            uint crcInt = crc32.ComputeChecksum(byteArray);
            CRCCode = crcInt.ToString();

            #endregion PreInsert
        }

        protected void PreTransition_UseRestDose2Apply()
        {
            // From State : UseRestDose   To State : Apply
            #region PreTransition_UseRestDose2Apply

            /* if (((DateTime)this.OrderPlannedDate).ToShortDateString() != Common.RecTime().ToShortDateString())
                 throw new TTException("Zamanı gelmemiş uygulamayı uygulayamazsınız.");
             */

            if (DrugOrder.PatientOwnDrug == false)
            {
                if (OrderPlannedDate.Value > Common.RecTime())
                {
                    throw new TTException(TTUtils.CultureService.GetText("M27269", "Zamanı gelmemiş uygulamayı uygulayamazsınız."));
                }
            }

            if ((bool)DrugDone)
            {
                double restAmount = 0;
                BindingList<DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class> outtableTransactions = DrugOrderTransaction.GetOuttableDrugOrderTransactions(Episode.ObjectID.ToString(), Material.ObjectID.ToString());
                foreach (DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class inTrx in outtableTransactions)
                {
                    restAmount += Convert.ToDouble(inTrx.Restamount);
                }
                DoseAmount = restAmount;
                foreach (DrugOrderDetail anotherDrugOrderDetail in DrugOrder.DrugOrderDetails)
                {
                    if (anotherDrugOrderDetail.ObjectID.Equals(ObjectID) == false)
                    {
                        if (anotherDrugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Supply || anotherDrugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.UseRestDose)
                        {
                            anotherDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                        }
                    }
                }
            }

            /*DrugOrderDetail drugOrderDetail = this;
            DrugOrder drugOrder = drugOrderDetail.DrugOrder ;
            
            if(drugOrder.PatientOwnDrug.HasValue == false || drugOrder.PatientOwnDrug == false)
            {
                // PatientRestDose güncelleniyor.
                double patientRestDose = 0;
                double usedAmount = 0 ;
                double usedVolume = 0;
                double usedCount = 0;
                bool fullDose = false ;
                
                bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrderDetail.Material);
                double restDose = DrugOrderTransaction.GetRestDose(drugOrder);
                
                
                if (drugType)
                {
                    usedAmount = (double)drugOrderDetail.Amount;
                    usedVolume = (double)drugOrderDetail.Amount * (double)((DrugDefinition)drugOrderDetail.Material).Volume;
                }
                else
                {
                    usedAmount = (double)drugOrderDetail.Amount / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
                    usedVolume = (double)drugOrderDetail.Amount;
                    double totalUsageVolume = 0 ;
                    double newRestDose = 0;
                    double drugVolume = (double)((DrugDefinition)drugOrderDetail.Material).Volume;
                    double afterVolume = 0;
                    double beforeVolume = 0;
                    BindingList<DrugOrderTransaction> transaction = drugOrder.DrugOrderTransactions.Select("INOUT = 1");
                    foreach (DrugOrderTransaction drugOrderTransaction in transaction)
                    {
                        totalUsageVolume = totalUsageVolume + (double)drugOrderTransaction.Volume ;
                    }
                    if (totalUsageVolume <= drugVolume )
                    {
                        drugOrderDetail.Amount = 1;
                    }
                    else
                    {
                        afterVolume = Math.Truncate(restDose / drugVolume);
                        newRestDose = restDose - usedVolume;
                        beforeVolume = Math.Truncate(newRestDose / drugVolume);
                        if (beforeVolume != afterVolume)
                        {
                            drugOrderDetail.Amount = afterVolume - beforeVolume ;
                            drugOrderDetail.Eligible = true;
                        }
                    }
                }

                if (restDose > 0)
                {
                    patientRestDose = restDose - (double)drugOrderDetail.Amount;
                    if (patientRestDose >= 0)  //TotalDose 'u kullanıcı bitirirse kalan orderler ne olacak ?
                    {
                        if (patientRestDose == 0)
                        {
                            fullDose = true;
                        }

                        DrugOrderTransaction newDrugOrderTransaction = new DrugOrderTransaction(drugOrderDetail.ObjectContext);

                        newDrugOrderTransaction.DrugOrder = drugOrder;
                        newDrugOrderTransaction.DrugOrderDetail = drugOrderDetail;
                        newDrugOrderTransaction.InOut = 2;
                        if (!(bool)drugOrderDetail.DrugDone)
                        {
                            newDrugOrderTransaction.Amount = usedAmount;
                            newDrugOrderTransaction.Volume = usedVolume;
                        }
                        else
                        {
                            newDrugOrderTransaction.Amount = restDose / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
                            newDrugOrderTransaction.Volume = restDose;
                            fullDose = true;
                            //Buraya mesaj verdirilmesi gerekiyor.
                        }
                    }
                    else
                    {
                        throw new Exception("Hastanın bu uygulama için belirtiğiniz miktarda dozu bulunmamaktadır.");
                    }
                }
                else
                {
                    Dictionary<object, double> patientRestDictionary = DrugOrderTransaction.GetPatientRestDose(drugOrderDetail.Material, drugOrderDetail.Episode);
                    foreach (KeyValuePair<object, double> restDic in patientRestDictionary)
                    {
                        if (restDic.Value >= (double)drugOrderDetail.Amount & usedCount == 0 )
                        {
                            DrugOrderTransaction newDrugOrderTransaction = new DrugOrderTransaction(drugOrderDetail.ObjectContext);

                            newDrugOrderTransaction.DrugOrder = (DrugOrder)restDic.Key ;
                            newDrugOrderTransaction.DrugOrderDetail = drugOrderDetail;
                            newDrugOrderTransaction.InOut = 2;
                            usedCount = 1;
                            if (!(bool)drugOrderDetail.DrugDone)
                            {
                                newDrugOrderTransaction.Amount = usedAmount;
                                newDrugOrderTransaction.Volume = usedVolume;
                            }
                            else
                            {
                                newDrugOrderTransaction.Amount = restDose / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
                                newDrugOrderTransaction.Volume = restDose;
                                fullDose = true;
                                //Buraya mesaj verdirilmesi gerekiyor.
                            }
                            
                        }
                    }
                }
                
                //            if (fullDose)
                //            {
                //                foreach (DrugOrderDetail anotherDrugOrderDetail in  drugOrderDetail.KScheduleCollectedOrder.DrugOrderDetails)
                //                {
                //                    if (anotherDrugOrderDetail.CurrentStateDefID == new Guid ("d4f85132-8d05-4dc7-b9b2-fc04bae622b0") & anotherDrugOrderDetail.ObjectID != drugOrderDetail.ObjectID )
                //                    {
                //                        anotherDrugOrderDetail.CurrentStateDefID = new Guid("cb22e74b-a2be-456f-8680-660d0b21dc24");
                //                    }
                //                }
                //            }
            }
            
            // Order Statusu güncelleniyor. SS
            int CompletedAplication = 0 ;
            int NonCompletedAplication = 0;
            if (drugOrder.DrugOrderDetails.Count == 1)
            {
                drugOrder.CurrentStateDefID = new Guid (DrugOrder.States.Completed.ToString());
            }
            else
            {
                foreach(DrugOrderDetail oldDrugOrderDetail in drugOrder.DrugOrderDetails)
                {
                    if (oldDrugOrderDetail != drugOrderDetail)
                    {
                        if (oldDrugOrderDetail.CurrentStateDefID == new Guid("d39a37a6-610e-4143-aca2-691ce5818915") || oldDrugOrderDetail.CurrentStateDefID == new Guid("add6e452-c007-4849-b477-17d30400abe8"))
                        {
                            CompletedAplication = CompletedAplication + 1 ;
                        }
                        else
                        {
                            NonCompletedAplication = NonCompletedAplication + 1 ;
                        }
                    }
                }
                
                if (CompletedAplication == 0)
                {
                    // drugOrder.CurrentStateDefID = new Guid("c227b72e-56bc-4279-81dd-a2be3a843ee0");
                    
                    drugOrder.CurrentStateDefID = DrugOrder.States.Planned;
                    drugOrder.Update();
                    drugOrder.CurrentStateDefID = DrugOrder.States.Continued;
                    
                }
                else if ( drugOrder.DrugOrderDetails.Count - 1 == CompletedAplication )
                {
                    // drugOrder.CurrentStateDefID = new Guid ("c423baa7-7c23-4a04-beef-0162ad204877");
                    if(drugOrderDetail.DrugOrder.GetType()== typeof(DrugOrder))
                        drugOrderDetail.DrugOrder.CurrentStateDefID = DrugOrder.States.Completed;
                }
            }*/
            #endregion PreTransition_UseRestDose2Apply
        }

        protected void PostTransition_UseRestDose2Apply()
        {
            // From State : UseRestDose   To State : Apply
            #region PostTransition_UseRestDose2Apply

            //            DrugOrderDetail drugOrderDetail = this;
            //            DrugOrder drugOrder = drugOrderDetail.DrugOrder ;
            //            
            //            // PatientRestDose güncelleniyor.
            //            double patientRestDose = 0;
            //            double usedAmount = 0 ;
            //            double usedVolume = 0;
            //            double usedCount = 0;
            //            bool fullDose = false ;
            //            
            //            bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrderDetail.Material);
            //
            //            if (drugType)
            //            {
            //                usedAmount = (double)drugOrderDetail.Amount;
            //                usedVolume = (double)drugOrderDetail.Amount * (double)((DrugDefinition)drugOrderDetail.Material).Volume;
            //            }
            //            else
            //            {
            //                usedAmount = (double)drugOrderDetail.Amount / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
            //                usedVolume = (double)drugOrderDetail.Amount;
            //                double totalUsageAmount = 0 ;
            //                BindingList<DrugOrderTransaction> transaction = drugOrder.DrugOrderTransactions.Select("INOUT = 1");
            //                foreach (DrugOrderTransaction drugOrderTransaction in transaction)
            //                {
            //                    totalUsageAmount = totalUsageAmount + (double)drugOrderTransaction.Amount;
            //                }
            //                if(usedAmount < 1)
            //                {
            //                    drugOrderDetail.Amount = totalUsageAmount;
            //                }
            //            }
            //
            //            double restDose = DrugOrderTransaction.GetRestDose (drugOrder);
            //
            //            if (restDose > 0)
            //            {
            //                patientRestDose = restDose - (double)drugOrderDetail.Amount;
            //                if (patientRestDose >= 0)  //TotalDose 'u kullanıcı bitirirse kalan orderler ne olacak ? 
            //                {
            //                    if (patientRestDose == 0)
            //                    {
            //                        fullDose = true;
            //                    }
            //
            //                    DrugOrderTransaction newDrugOrderTransaction = new DrugOrderTransaction(drugOrderDetail.ObjectContext);
            //
            //                    newDrugOrderTransaction.DrugOrder = drugOrder;
            //                    newDrugOrderTransaction.DrugOrderDetail = drugOrderDetail;
            //                    newDrugOrderTransaction.InOut = 2;
            //                    if (!(bool)drugOrderDetail.DrugDone)
            //                    {
            //                        newDrugOrderTransaction.Amount = usedAmount;
            //                        newDrugOrderTransaction.Volume = usedVolume;
            //                    }
            //                    else
            //                    {
            //                        newDrugOrderTransaction.Amount = restDose / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
            //                        newDrugOrderTransaction.Volume = restDose;
            //                        fullDose = true;
            //                        //Buraya mesaj verdirilmesi gerekiyor. 
            //                    }
            //                }
            //                else
            //                {
            //                    throw new Exception("Hastanın bu uygulama için belirtiğiniz miktarda dozu bulunmamaktadır.");
            //                }
            //            }
            //            else
            //            {
            //                Dictionary<object, double> patientRestDictionary = DrugOrderTransaction.GetPatientRestDose(drugOrderDetail.Material, drugOrderDetail.Episode);
            //                foreach (KeyValuePair<object, double> restDic in patientRestDictionary)
            //                {
            //                    if (restDic.Value >= (double)drugOrderDetail.Amount & usedCount == 0 )
            //                    {
            //                        DrugOrderTransaction newDrugOrderTransaction = new DrugOrderTransaction(drugOrderDetail.ObjectContext);
            //
            //                        newDrugOrderTransaction.DrugOrder = (DrugOrder)restDic.Key ;
            //                        newDrugOrderTransaction.DrugOrderDetail = drugOrderDetail;
            //                        newDrugOrderTransaction.InOut = 2;
            //                        usedCount = 1;
            //                        if (!(bool)drugOrderDetail.DrugDone)
            //                        {
            //                            newDrugOrderTransaction.Amount = usedAmount;
            //                            newDrugOrderTransaction.Volume = usedVolume;
            //                        }
            //                        else
            //                        {
            //                            newDrugOrderTransaction.Amount = restDose / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
            //                            newDrugOrderTransaction.Volume = restDose;
            //                            fullDose = true;
            //                            //Buraya mesaj verdirilmesi gerekiyor. 
            //                        }
            //                        
            //                    }
            //                }
            //            }
            //            
            //            if (fullDose)
            //            {
            //                foreach (DrugOrderDetail anotherDrugOrderDetail in  drugOrderDetail.KScheduleCollectedOrder.DrugOrderDetails)
            //                {
            //                    if (anotherDrugOrderDetail.CurrentStateDefID == new Guid ("d4f85132-8d05-4dc7-b9b2-fc04bae622b0") & anotherDrugOrderDetail.ObjectID != drugOrderDetail.ObjectID )
            //                    {
            //                        anotherDrugOrderDetail.CurrentStateDefID = new Guid("cb22e74b-a2be-456f-8680-660d0b21dc24");
            //                    }
            //                }
            //            }
            //            
            //            
            //            // Order Statusu güncelleniyor.
            //            int CompletedAplication = 0 ;
            //            int NonCompletedAplication = 0;
            //            if (drugOrder.DrugOrderDetails.Count == 1)
            //            {
            //                drugOrder.CurrentStateDefID = new Guid (DrugOrder.States.Completed.ToString());
            //            }
            //            else
            //            {
            //                foreach(DrugOrderDetail oldDrugOrderDetail in drugOrder.DrugOrderDetails)
            //                {
            //                    if (oldDrugOrderDetail != drugOrderDetail)
            //                    {
            //                        if (oldDrugOrderDetail.CurrentStateDefID == new Guid("d39a37a6-610e-4143-aca2-691ce5818915") || oldDrugOrderDetail.CurrentStateDefID == new Guid("add6e452-c007-4849-b477-17d30400abe8"))
            //                        {
            //                            CompletedAplication = CompletedAplication + 1 ;
            //                        }
            //                        else
            //                        {
            //                            NonCompletedAplication = NonCompletedAplication + 1 ;
            //                        }
            //                    }
            //                }
            //                
            //                if (CompletedAplication == 0)
            //                {
            //                    // drugOrder.CurrentStateDefID = new Guid("c227b72e-56bc-4279-81dd-a2be3a843ee0");
            //                    
            //                    if(drugOrderDetail.DrugOrder.GetType()== typeof(DrugOrder))
            //                        drugOrderDetail.DrugOrder.CurrentStateDefID = DrugOrder.States.Continued;
            //                    
            //                }
            //                else if ( drugOrder.DrugOrderDetails.Count - 1 == CompletedAplication )
            //                {
            //                   // drugOrder.CurrentStateDefID = new Guid ("c423baa7-7c23-4a04-beef-0162ad204877");
            //                   if(drugOrderDetail.DrugOrder.GetType()== typeof(DrugOrder))
            //                        drugOrderDetail.DrugOrder.CurrentStateDefID = DrugOrder.States.Completed;
            //                }
            //            }

            #endregion PostTransition_UseRestDose2Apply
        }

        protected void PreTransition_Planned2ReturnPharmacy()
        {
            // From State : Planned   To State : ReturnPharmacy
            #region PreTransition_Planned2ReturnPharmacy

            /*  DrugOrderDetail drugOrderDetail = this;
             DrugOrder drugOrder = drugOrderDetail.DrugOrder ;
             drugOrderDetail.Eligible = false;
             bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrderDetail.Material);
             double usedAmount = 0;
             double usedVolume = 0 ;
             if (drugType)
             {
                 usedAmount = (double)drugOrderDetail.Amount;
                 usedVolume = (double)drugOrderDetail.Amount * (double)((DrugDefinition)drugOrderDetail.Material).Volume;
             }
             else
             {
                 usedAmount = (double)drugOrderDetail.Amount / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
                 usedVolume = (double)drugOrderDetail.Amount;
             }

             DrugOrderTransaction newDrugOrderTransaction = new DrugOrderTransaction(drugOrderDetail.ObjectContext);
             newDrugOrderTransaction.DrugOrder = drugOrder;
             newDrugOrderTransaction.DrugOrderDetail = drugOrderDetail;
             newDrugOrderTransaction.InOut = 2;
             newDrugOrderTransaction.Amount = usedAmount;
             newDrugOrderTransaction.Volume = usedVolume;

             if(drugOrder.CurrentStateDefID != DrugOrder.States.Completed)
             {
                 drugOrder.CurrentStateDefID = DrugOrder.States.Completed;
             }*/
            #endregion PreTransition_Planned2ReturnPharmacy
        }

        protected void PreTransition_Planned2PatientDelivery()
        {
            // From State : Planned   To State : PatientDelivery
            #region PreTransition_Planned2PatientDelivery


            if (OrderPlannedDate.Value > Common.RecTime())
                throw new TTException(TTUtils.CultureService.GetText("M27269", "Zamanı gelmemiş uygulamayı uygulayamazsınız."));

            /*DrugOrderDetail drugOrderDetail = this;
            DrugOrder drugOrder = drugOrderDetail.DrugOrder ;
            double usedAmount = (double)drugOrderDetail.Amount;
            double usedVolume = (double)drugOrderDetail.Amount * (double)((DrugDefinition)drugOrderDetail.Material).Volume;
            DrugOrderTransaction newDrugOrderTransaction = new DrugOrderTransaction(drugOrderDetail.ObjectContext);
            newDrugOrderTransaction.DrugOrder = drugOrder;
            newDrugOrderTransaction.DrugOrderDetail = drugOrderDetail;
            newDrugOrderTransaction.InOut = 2;
            newDrugOrderTransaction.Amount = usedAmount;
            newDrugOrderTransaction.Volume = usedVolume;
            
            bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrderDetail.Material);
            double restDose = DrugOrderTransaction.GetRestDose(drugOrder);
            
            
            if (drugType)
            {
                usedAmount = (double)drugOrderDetail.Amount;
                usedVolume = (double)drugOrderDetail.Amount * (double)((DrugDefinition)drugOrderDetail.Material).Volume;
            }
            else
            {
                usedAmount = (double)drugOrderDetail.Amount / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
                usedVolume = (double)drugOrderDetail.Amount;
                double totalUsageVolume = 0 ;
                double newRestDose = 0;
                double drugVolume = (double)((DrugDefinition)drugOrderDetail.Material).Volume;
                double afterVolume = 0;
                double beforeVolume = 0;
                BindingList<DrugOrderTransaction> transaction = drugOrder.DrugOrderTransactions.Select("INOUT = 1");
                foreach (DrugOrderTransaction drugOrderTransaction in transaction)
                {
                    totalUsageVolume = totalUsageVolume + (double)drugOrderTransaction.Volume ;
                }
                if (totalUsageVolume <= drugVolume )
                {
                    drugOrderDetail.Amount = 1;
                }
                else
                {
                    afterVolume = Math.Truncate(restDose / drugVolume);
                    newRestDose = restDose - usedVolume;
                    beforeVolume = Math.Truncate(newRestDose / drugVolume);
                    if (beforeVolume != afterVolume)
                    {
                        drugOrderDetail.Amount = afterVolume - beforeVolume ;
                        drugOrderDetail.Eligible = true;
                    }
                }
            }
            
            bool orderStatus = true ;
            foreach(DrugOrderDetail alldetail in drugOrder.DrugOrderDetails)
            {
                if(alldetail.CurrentStateDef.Status == StateStatusEnum.Uncompleted && alldetail.ObjectID != drugOrderDetail.ObjectID )
                {
                    orderStatus = false ;
                    break;
                }
            }
            
            if(orderStatus)
            {
                drugOrder.CurrentStateDefID = DrugOrder.States.Completed;
            }*/


            #endregion PreTransition_Planned2PatientDelivery
        }

        protected void PreTransition_Supply2Cancel()
        {
            // From State : Supply   To State : Cancel
            #region PreTransition_Supply2Cancel

            DrugOrderDetail drugOrderDetail = this;
            DrugDefinition drug = (DrugDefinition)Material;
            bool drugType = DrugOrder.GetDrugUsedType(drug);
            if (drugType == false && Eligible == true)
            {

                /*List<DrugOrderDetail> anotherDrugOrderDetail = drugOrderDetail.DrugOrder.DrugOrderDetails.Where(x => x.ObjectID != drugOrderDetail.ObjectID).ToList();
                if (anotherDrugOrderDetail.Count > 0)
                {
                    if (anotherDrugOrderDetail.Select(x => x.CurrentStateDef.Status != TTDefinitionManagement.StateStatusEnum.Uncompleted).Count() == 0)
                        throw new Exception("Bu uygulama fatura ya yansıdığı için geri alınamaz");
                }
                else
                    throw new Exception("Bu uygulama fatura ya yansıdığı için geri alınamaz");*/

                drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
                DrugOrdertrasactionDetailCompToCancel(drugOrderDetail);
            }
            else
            {
                drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
                DrugOrdertrasactionDetailCompToCancel(drugOrderDetail);
            }

            #endregion PreTransition_Supply2Cancel
        }


        public void DrugOrdertrasactionDetailCompToCancel(DrugOrderDetail detail)
        {
            TTObjectContext context = new TTObjectContext(false);
            IBindingList transactionDetails = context.QueryObjects(typeof(DrugOrderTransactionDetail).Name, "DRUGORDERDETAIL = '" + detail.ObjectID + "'");
            if (transactionDetails.Count > 0)
            {
                DrugOrderTransactionDetail drugOrderTransactionDetail = (DrugOrderTransactionDetail)transactionDetails[0];

                /*List<StockTransaction> returnableStockTransaction = drugOrderTransactionDetail.DrugOrderTransaction.KScheduleMaterial.StockTransactions.Select(string.Empty).ToList();
                foreach (StockTransaction st in returnableStockTransaction)
                {
                    st.StockCollectedTrxs.DeleteChildren();
                }*/


                drugOrderTransactionDetail.CurrentStateDefID = DrugOrderTransactionDetail.States.Cancel;
                context.Save();
                context.Dispose();
            }
        }

        protected void PreTransition_Apply2Cancel()
        {
            // From State : Apply   To State : Cancel
            #region PreTransition_Apply2Cancel

            DrugOrderDetail drugOrderDetail = this;
            DrugDefinition drug = (DrugDefinition)Material;
            bool drugType = DrugOrder.GetDrugUsedType(drug);

            if (drugType == false && Eligible == true)
            {
                if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Apply)
                {

                    /*List<DrugOrderDetail> anotherDrugOrderDetail = drugOrderDetail.DrugOrder.DrugOrderDetails.Where(x => x.ObjectID != drugOrderDetail.ObjectID).ToList();
                    if (anotherDrugOrderDetail.Count > 0)
                    {
                        if (anotherDrugOrderDetail.Select(x => x.CurrentStateDef.Status != TTDefinitionManagement.StateStatusEnum.Uncompleted).Count() == 0)
                            throw new Exception("Bu uygulama fatura ya yansıdığı için geri alınamaz");
                    }
                    else
                        throw new Exception("Bu uygulama fatura ya yansıdığı için geri alınamaz");*/

                    drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
                    DrugOrdertrasactionDetailCompToCancel(drugOrderDetail);

                }
                else
                {
                    drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Apply;
                }
            }
            else
            {
                drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
                DrugOrdertrasactionDetailCompToCancel(drugOrderDetail);
            }


            #endregion PreTransition_Apply2Cancel
        }

        protected void UndoTransition_Apply2Supply()
        {
            // From State : Apply    To State :Supply
            #region UndoTransition_Apply2Supply

            DrugOrderDetail drugOrderDetail = this;
            DrugDefinition drug = (DrugDefinition)Material;
            bool drugType = DrugOrder.GetDrugUsedType(drug);

            if (drugType == false && Eligible == true)
            {
                if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Apply)
                {

                    if (drugOrderDetail.DrugOrder.CurrentStateDefID != DrugOrder.States.Planned)
                    { ((ITTObject)drugOrderDetail.DrugOrder).UndoLastTransition(); }
                    DrugOrdertrasactionDetailCompToCancel(drugOrderDetail);
                }

            }
            else
            {
                if (drugOrderDetail.DrugOrder.CurrentStateDefID != DrugOrder.States.Planned)
                { ((ITTObject)drugOrderDetail.DrugOrder).UndoLastTransition(); }

                DrugOrdertrasactionDetailCompToCancel(drugOrderDetail);
            }


            #endregion UndoTransition_Apply2Supply
        }

        protected void PostTransition_Supply2Cancel()
        {
            // From State : Supply   To State : Cancel
            #region PostTransition_Supply2Cancel

            //            DrugOrderDetail drugOrderDetail = this;
            //            DrugOrder drugOrder = (DrugOrder)drugOrderDetail.DrugOrder;
            //            int CompletedApplication = 0 ;
            //            int NonCopmpletedAplication = 0;
            //            if (drugOrder.DrugOrderDetails.Count == 1)
            //            {
            //                drugOrder.CurrentStateDefID = new Guid ("c423baa7-7c23-4a04-beef-0162ad204877");
            //            }
            //            else
            //            {
            //                foreach(DrugOrderDetail oldDrugOrderDetail in drugOrder.DrugOrderDetails)
            //                {
            //                    if (oldDrugOrderDetail != drugOrderDetail)
            //                    {
            //                        if (oldDrugOrderDetail.CurrentStateDefID == new Guid("d39a37a6-610e-4143-aca2-691ce5818915") || oldDrugOrderDetail.CurrentStateDefID == new Guid("add6e452-c007-4849-b477-17d30400abe8"))
            //                        {
            //                            CompletedApplication = CompletedApplication + 1 ;
            //                        }
            //                        else
            //                        {
            //                            NonCopmpletedAplication = NonCopmpletedAplication + 1 ;
            //                        }
            //                    }
            //                }
            //                
            //                if (CompletedApplication == 0)
            //                {
            //                    drugOrder.CurrentStateDefID = new Guid("c227b72e-56bc-4279-81dd-a2be3a843ee0");
            //                }
            //                else if ( drugOrder.DrugOrderDetails.Count - 1 == CompletedApplication )
            //                {
            //                    drugOrder.CurrentStateDefID = new Guid ("c423baa7-7c23-4a04-beef-0162ad204877");
            //                }
            //            }

            #endregion PostTransition_Supply2Cancel
        }

        protected void PreTransition_Supply2Apply()
        {
            // From State : Supply   To State : Apply
            #region PreTransition_Supply2Apply

            if (OrderPlannedDate.Value > Common.RecTime())
                throw new TTException(TTUtils.CultureService.GetText("M27269", "Zamanı gelmemiş uygulamayı uygulayamazsınız."));

            if (DrugReturnActionDetail != null)
                throw new TTException(DrugReturnActionDetail.DrugReturnAction.ID.ToString() + " İşlem numarası ile iade işlemi başlatıldığı için uygulama yapılamaz. ");

            if ((bool)DrugDone)
            {
                double restAmount = 0;
                BindingList<DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class> outtableTransactions = DrugOrderTransaction.GetOuttableDrugOrderTransactions(Episode.ObjectID.ToString(), Material.ObjectID.ToString());
                foreach (DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class inTrx in outtableTransactions)
                {
                    restAmount += Convert.ToDouble(inTrx.Restamount);
                }
                DoseAmount = restAmount;
                foreach (DrugOrderDetail anotherDrugOrderDetail in DrugOrder.DrugOrderDetails)
                {
                    if (anotherDrugOrderDetail.ObjectID.Equals(ObjectID) == false)
                    {
                        if (anotherDrugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Supply || anotherDrugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.UseRestDose)
                        {
                            anotherDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                            anotherDrugOrderDetail.KScheduleCollectedOrder = null;
                        }
                    }
                }
            }
            /*DrugOrderDetail drugOrderDetail = this;
            DrugOrder drugOrder = drugOrderDetail.DrugOrder ;
            
            // PatientRestDose güncelleniyor.
            double patientRestDose = 0;
            double usedAmount = 0 ;
            double usedVolume = 0;
            double usedCount = 0;
            bool fullDose = false ;
            
            bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrderDetail.Material);
            double restDose = DrugOrderTransaction.GetRestDose(drugOrder);
            if ((bool)this.DrugDone)
            {
                this.Amount = restDose;
                fullDose = true;
            }
            else
            {
                if (drugType)
                {
                    usedAmount = (double)drugOrderDetail.Amount;
                    usedVolume = (double)drugOrderDetail.Amount * (double)((DrugDefinition)drugOrderDetail.Material).Volume;
                }
                else
                {
                    usedAmount = (double)drugOrderDetail.Amount / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
                    usedVolume = (double)drugOrderDetail.Amount;
                    double totalUsageVolume = 0;
                    double newRestDose = 0;
                    double drugVolume = (double)((DrugDefinition)drugOrderDetail.Material).Volume;
                    double afterVolume = 0;
                    double beforeVolume = 0;
                    BindingList<DrugOrderTransaction> transaction = drugOrder.DrugOrderTransactions.Select("INOUT = 1");
                    foreach (DrugOrderTransaction drugOrderTransaction in transaction)
                    {
                        totalUsageVolume = totalUsageVolume + (double)drugOrderTransaction.Volume;
                    }
                    if (totalUsageVolume <= drugVolume)
                    {
                        drugOrderDetail.Amount = 1;
                    }
                    else
                    {
                        afterVolume = Math.Truncate(restDose / drugVolume);
                        newRestDose = restDose - usedVolume;
                        beforeVolume = Math.Truncate(newRestDose / drugVolume);
                        if (beforeVolume != afterVolume)
                        {
                            drugOrderDetail.Amount = afterVolume - beforeVolume;
                            drugOrderDetail.Eligible = true;
                        }
                    }
                }

                if (restDose > 0)
                {
                    patientRestDose = restDose - (double)drugOrderDetail.Amount;
                    if (patientRestDose >= 0)  //TotalDose 'u kullanıcı bitirirse kalan orderler ne olacak ?
                    {
                        if (patientRestDose == 0)
                        {
                            fullDose = true;
                        }

                        DrugOrderTransaction newDrugOrderTransaction = new DrugOrderTransaction(drugOrderDetail.ObjectContext);

                        newDrugOrderTransaction.DrugOrder = drugOrder;
                        newDrugOrderTransaction.DrugOrderDetail = drugOrderDetail;
                        newDrugOrderTransaction.InOut = 2;
                        if (!(bool)drugOrderDetail.DrugDone)
                        {
                            newDrugOrderTransaction.Amount = usedAmount;
                            newDrugOrderTransaction.Volume = usedVolume;
                        }
                        else
                        {
                            newDrugOrderTransaction.Amount = restDose / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
                            newDrugOrderTransaction.Volume = restDose;
                            fullDose = true;
                            //Buraya mesaj verdirilmesi gerekiyor.
                        }
                    }
                    else
                    {
                        throw new Exception("Hastanın bu uygulama için belirtiğiniz miktarda dozu bulunmamaktadır.");
                    }
                }
                else
                {
                    Dictionary<object, double> patientRestDictionary = DrugOrderTransaction.GetPatientRestDose(drugOrderDetail.Material, drugOrderDetail.Episode);
                    foreach (KeyValuePair<object, double> restDic in patientRestDictionary)
                    {
                        if (restDic.Value >= (double)drugOrderDetail.Amount & usedCount == 0)
                        {
                            DrugOrderTransaction newDrugOrderTransaction = new DrugOrderTransaction(drugOrderDetail.ObjectContext);

                            newDrugOrderTransaction.DrugOrder = (DrugOrder)restDic.Key;
                            newDrugOrderTransaction.DrugOrderDetail = drugOrderDetail;
                            newDrugOrderTransaction.InOut = 2;
                            usedCount = 1;
                            if (!(bool)drugOrderDetail.DrugDone)
                            {
                                newDrugOrderTransaction.Amount = usedAmount;
                                newDrugOrderTransaction.Volume = usedVolume;
                            }
                            else
                            {
                                newDrugOrderTransaction.Amount = restDose / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
                                newDrugOrderTransaction.Volume = restDose;
                                fullDose = true;
                                //Buraya mesaj verdirilmesi gerekiyor.
                            }

                        }
                    }
                }
            }
            if (fullDose)
            {
                foreach (DrugOrderDetail anotherDrugOrderDetail in  drugOrderDetail.KScheduleCollectedOrder.DrugOrderDetails)
                {
                    if (anotherDrugOrderDetail.CurrentStateDefID == new Guid ("d4f85132-8d05-4dc7-b9b2-fc04bae622b0") & anotherDrugOrderDetail.ObjectID != drugOrderDetail.ObjectID )
                    {
                        anotherDrugOrderDetail.CurrentStateDefID = new Guid("cb22e74b-a2be-456f-8680-660d0b21dc24");
                    }
                }
            }
            
            
            // Order Statusu güncelleniyor. SS
            int CompletedAplication = 0 ;
            int NonCompletedAplication = 0;
            if (drugOrder.DrugOrderDetails.Count == 1)
            {
                drugOrder.CurrentStateDefID = new Guid (DrugOrder.States.Completed.ToString());
            }
            else
            {
                foreach(DrugOrderDetail oldDrugOrderDetail in drugOrder.DrugOrderDetails)
                {
                    if (oldDrugOrderDetail != drugOrderDetail)
                    {
                        if (oldDrugOrderDetail.CurrentStateDefID == new Guid("d39a37a6-610e-4143-aca2-691ce5818915") || oldDrugOrderDetail.CurrentStateDefID == new Guid("add6e452-c007-4849-b477-17d30400abe8"))
                        {
                            CompletedAplication = CompletedAplication + 1 ;
                        }
                        else
                        {
                            NonCompletedAplication = NonCompletedAplication + 1 ;
                        }
                    }
                }
                
//                if (CompletedAplication == 0)
//                {
//                    // drugOrder.CurrentStateDefID = new Guid("c227b72e-56bc-4279-81dd-a2be3a843ee0");
//                    
//                    drugOrder.CurrentStateDefID = DrugOrder.States.Planned;
//                    drugOrder.Update();
//                    drugOrder.CurrentStateDefID = DrugOrder.States.Continued;
//                    
//                }
                if ( drugOrder.DrugOrderDetails.Count - 1 == CompletedAplication )
                {
                    // drugOrder.CurrentStateDefID = new Guid ("c423baa7-7c23-4a04-beef-0162ad204877");
                    if(drugOrderDetail.DrugOrder.GetType()== typeof(DrugOrder))
                        drugOrderDetail.DrugOrder.CurrentStateDefID = DrugOrder.States.Completed;
                }
            }*/

            #endregion PreTransition_Supply2Apply
        }

        protected void PostTransition_Supply2Apply()
        {
            // From State : Supply   To State : Apply
            #region PostTransition_Supply2Apply



            string drugOrderDetailDoseAmount = SystemParameter.GetParameterValue("DRUGORDERDETAILDOSEAMOUNT", "100");
            if (Amount > Convert.ToDouble(drugOrderDetailDoseAmount))
            {
                IList kScheduleMaterials = ObjectContext.QueryObjects("KSCHEDULEMATERIAL", "KSCHEDULECOLLECTEDORDER=" + ConnectionManager.GuidToString(KScheduleCollectedOrder.ObjectID));
                if (kScheduleMaterials.Count > 0)
                {
                    KScheduleMaterial kScheduleMaterial = (KScheduleMaterial)kScheduleMaterials[0];
                    double drugCount = KScheduleCollectedOrder.DrugOrderDetails.Count;
                    double requestAmount = (double)kScheduleMaterial.RequestAmount;
                    double amount = (double)kScheduleMaterial.Amount;
                    if (amount > 0 && drugCount > 0)
                    {
                        double prospectiveAmount = amount / drugCount;
                        Amount = prospectiveAmount;
                    }
                }
            }



            //            DrugOrderDetail drugOrderDetail = this;
            //            DrugOrder drugOrder = drugOrderDetail.DrugOrder ;
            //            
            //            // PatientRestDose güncelleniyor.
            //            double patientRestDose = 0;
            //            double usedAmount = 0 ;
            //            double usedVolume = 0;
            //            double usedCount = 0;
            //            bool fullDose = false ;
            //            
            //            bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrderDetail.Material);
            //            double restDose = DrugOrderTransaction.GetRestDose(drugOrder);
            //            
            //            
            //            if (drugType)
            //            {
            //                usedAmount = (double)drugOrderDetail.Amount;
            //                usedVolume = (double)drugOrderDetail.Amount * (double)((DrugDefinition)drugOrderDetail.Material).Volume;
            //            }
            //            else
            //            {
            //                usedAmount = (double)drugOrderDetail.Amount / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
            //                usedVolume = (double)drugOrderDetail.Amount;
            //                double totalUsageVolume = 0 ;
            //                double newRestDose = 0;
            //                double drugVolume = (double)((DrugDefinition)drugOrderDetail.Material).Volume;
            //                double afterVolume = 0;
            //                double beforeVolume = 0;
            //                BindingList<DrugOrderTransaction> transaction = drugOrder.DrugOrderTransactions.Select("INOUT = 1");
            //                foreach (DrugOrderTransaction drugOrderTransaction in transaction)
            //                {
            //                    totalUsageVolume = totalUsageVolume + (double)drugOrderTransaction.Volume ;
            //                }
            //                if (totalUsageVolume <= drugVolume )
            //                {
            //                    drugOrderDetail.Amount = 1;
            //                }
            //                else
            //                {
            //                    afterVolume = Math.Truncate(restDose / drugVolume);  
            //                    newRestDose = restDose - usedVolume;
            //                    beforeVolume = Math.Truncate(newRestDose / drugVolume);
            //                    if (beforeVolume != afterVolume)
            //                    {
            //                       drugOrderDetail.Amount = afterVolume - beforeVolume ;
            //                       drugOrderDetail.Eligible = true;
            //                    }
            //                }
            //            }
            //
            //            if (restDose > 0)
            //            {
            //                patientRestDose = restDose - (double)drugOrderDetail.Amount;
            //                if (patientRestDose >= 0)  //TotalDose 'u kullanıcı bitirirse kalan orderler ne olacak ?
            //                {
            //                    if (patientRestDose == 0)
            //                    {
            //                        fullDose = true;
            //                    }
            //
            //                    DrugOrderTransaction newDrugOrderTransaction = new DrugOrderTransaction(drugOrderDetail.ObjectContext);
            //
            //                    newDrugOrderTransaction.DrugOrder = drugOrder;
            //                    newDrugOrderTransaction.DrugOrderDetail = drugOrderDetail;
            //                    newDrugOrderTransaction.InOut = 2;
            //                    if (!(bool)drugOrderDetail.DrugDone)
            //                    {
            //                        newDrugOrderTransaction.Amount = usedAmount;
            //                        newDrugOrderTransaction.Volume = usedVolume;
            //                    }
            //                    else
            //                    {
            //                        newDrugOrderTransaction.Amount = restDose / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
            //                        newDrugOrderTransaction.Volume = restDose;
            //                        fullDose = true;
            //                        //Buraya mesaj verdirilmesi gerekiyor.
            //                    }
            //                }
            //                else
            //                {
            //                    throw new Exception("Hastanın bu uygulama için belirtiğiniz miktarda dozu bulunmamaktadır.");
            //                }
            //            }
            //            else
            //            {
            //                Dictionary<object, double> patientRestDictionary = DrugOrderTransaction.GetPatientRestDose(drugOrderDetail.Material, drugOrderDetail.Episode);
            //                foreach (KeyValuePair<object, double> restDic in patientRestDictionary)
            //                {
            //                    if (restDic.Value >= (double)drugOrderDetail.Amount & usedCount == 0 )
            //                    {
            //                        DrugOrderTransaction newDrugOrderTransaction = new DrugOrderTransaction(drugOrderDetail.ObjectContext);
            //
            //                        newDrugOrderTransaction.DrugOrder = (DrugOrder)restDic.Key ;
            //                        newDrugOrderTransaction.DrugOrderDetail = drugOrderDetail;
            //                        newDrugOrderTransaction.InOut = 2;
            //                        usedCount = 1;
            //                        if (!(bool)drugOrderDetail.DrugDone)
            //                        {
            //                            newDrugOrderTransaction.Amount = usedAmount;
            //                            newDrugOrderTransaction.Volume = usedVolume;
            //                        }
            //                        else
            //                        {
            //                            newDrugOrderTransaction.Amount = restDose / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
            //                            newDrugOrderTransaction.Volume = restDose;
            //                            fullDose = true;
            //                            //Buraya mesaj verdirilmesi gerekiyor.
            //                        }
            //                        
            //                    }
            //                }
            //            }
            //            
            //            if (fullDose)
            //            {
            //                foreach (DrugOrderDetail anotherDrugOrderDetail in  drugOrderDetail.KScheduleCollectedOrder.DrugOrderDetails)
            //                {
            //                    if (anotherDrugOrderDetail.CurrentStateDefID == new Guid ("d4f85132-8d05-4dc7-b9b2-fc04bae622b0") & anotherDrugOrderDetail.ObjectID != drugOrderDetail.ObjectID )
            //                    {
            //                        anotherDrugOrderDetail.CurrentStateDefID = new Guid("cb22e74b-a2be-456f-8680-660d0b21dc24");
            //                    }
            //                }
            //            }
            //            
            //            
            //            // Order Statusu güncelleniyor. SS
            //            int CompletedAplication = 0 ;
            //            int NonCompletedAplication = 0;
            //            if (drugOrder.DrugOrderDetails.Count == 1)
            //            {
            //                drugOrder.CurrentStateDefID = new Guid (DrugOrder.States.Completed.ToString());
            //            }
            //            else
            //            {
            //                foreach(DrugOrderDetail oldDrugOrderDetail in drugOrder.DrugOrderDetails)
            //                {
            //                    if (oldDrugOrderDetail != drugOrderDetail)
            //                    {
            //                        if (oldDrugOrderDetail.CurrentStateDefID == new Guid("d39a37a6-610e-4143-aca2-691ce5818915") || oldDrugOrderDetail.CurrentStateDefID == new Guid("add6e452-c007-4849-b477-17d30400abe8"))
            //                        {
            //                            CompletedAplication = CompletedAplication + 1 ;
            //                        }
            //                        else
            //                        {
            //                            NonCompletedAplication = NonCompletedAplication + 1 ;
            //                        }
            //                    }
            //                }
            //                
            //                if (CompletedAplication == 0)
            //                {
            //                    // drugOrder.CurrentStateDefID = new Guid("c227b72e-56bc-4279-81dd-a2be3a843ee0");
            //                    
            //                    drugOrder.CurrentStateDefID = DrugOrder.States.Planned;
            //                    drugOrder.Update();
            //                    drugOrder.CurrentStateDefID = DrugOrder.States.Continued;
            //                    
            //                }
            //                else if ( drugOrder.DrugOrderDetails.Count - 1 == CompletedAplication )
            //                {
            //                    // drugOrder.CurrentStateDefID = new Guid ("c423baa7-7c23-4a04-beef-0162ad204877");
            //                    if(drugOrderDetail.DrugOrder.GetType()== typeof(DrugOrder))
            //                        drugOrderDetail.DrugOrder.CurrentStateDefID = DrugOrder.States.Completed;
            //                }
            //            }

            #endregion PostTransition_Supply2Apply
        }

        protected void PreTransition_Supply2PatientDelivery()
        {
            // From State : Supply   To State : PatientDelivery
            #region PreTransition_Supply2PatientDelivery


            if (OrderPlannedDate.Value > Common.RecTime())
                throw new TTException(TTUtils.CultureService.GetText("M27269", "Zamanı gelmemiş uygulamayı uygulayamazsınız."));

            /* DrugOrderDetail drugOrderDetail = this;
             DrugOrder drugOrder = drugOrderDetail.DrugOrder ;
             bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrderDetail.Material);
             double usedAmount = 0;
             double usedVolume = 0 ;
             if (drugType)
             {
                 usedAmount = (double)drugOrderDetail.Amount;
                 usedVolume = (double)drugOrderDetail.Amount * (double)((DrugDefinition)drugOrderDetail.Material).Volume;
             }
             else
             {
                 usedAmount = (double)drugOrderDetail.Amount / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
                 usedVolume = (double)drugOrderDetail.Amount;
             }

             DrugOrderTransaction newDrugOrderTransaction = new DrugOrderTransaction(drugOrderDetail.ObjectContext);
             newDrugOrderTransaction.DrugOrder = drugOrder;
             newDrugOrderTransaction.DrugOrderDetail = drugOrderDetail;
             newDrugOrderTransaction.InOut = 2;
             newDrugOrderTransaction.Amount = usedAmount;
             newDrugOrderTransaction.Volume = usedVolume;


             double restDose = DrugOrderTransaction.GetRestDose(drugOrder);


             if (drugType == false)
             {
                 double totalUsageVolume = 0 ;
                 double newRestDose = 0;
                 double drugVolume = (double)((DrugDefinition)drugOrderDetail.Material).Volume;
                 double afterVolume = 0;
                 double beforeVolume = 0;
                 BindingList<DrugOrderTransaction> transaction = drugOrder.DrugOrderTransactions.Select("INOUT = 1");
                 foreach (DrugOrderTransaction drugOrderTransaction in transaction)
                 {
                     totalUsageVolume = totalUsageVolume + (double)drugOrderTransaction.Volume ;
                 }
                 if (totalUsageVolume <= drugVolume )
                 {
                     drugOrderDetail.Amount = 1;
                 }
                 else
                 {
                     afterVolume = Math.Truncate(restDose / drugVolume);
                     newRestDose = restDose - usedVolume;
                     beforeVolume = Math.Truncate(newRestDose / drugVolume);
                     if (beforeVolume != afterVolume)
                     {
                         drugOrderDetail.Amount = afterVolume - beforeVolume ;
                         drugOrderDetail.Eligible = true;
                     }
                 }
             }

             bool orderStatus = true ;
             foreach(DrugOrderDetail alldetail in drugOrder.DrugOrderDetails)
             {
                 if(alldetail.CurrentStateDef.Status == StateStatusEnum.Uncompleted && alldetail.ObjectID != drugOrderDetail.ObjectID )
                 {
                     orderStatus = false ;
                     break;
                 }
             }

             if(orderStatus)
             {
                 drugOrder.CurrentStateDefID = DrugOrder.States.Completed;
             }*/

            #endregion PreTransition_Supply2PatientDelivery
        }

        protected void PreTransition_Supply2ReturnPharmacy()
        {
            // From State : Supply   To State : ReturnPharmacy
            #region PreTransition_Supply2ReturnPharmacy

            /*DrugOrderDetail drugOrderDetail = this;
            DrugOrder drugOrder = drugOrderDetail.DrugOrder ;
            drugOrderDetail.Eligible = false;
            bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrderDetail.Material);
            double usedAmount = 0;
            double usedVolume = 0 ;
            if (drugType)
            {
                usedAmount = (double)drugOrderDetail.Amount;
                usedVolume = (double)drugOrderDetail.Amount * (double)((DrugDefinition)drugOrderDetail.Material).Volume;
            }
            else
            {
                usedAmount = (double)drugOrderDetail.Amount / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
                usedVolume = (double)drugOrderDetail.Amount;
            }

            DrugOrderTransaction newDrugOrderTransaction = new DrugOrderTransaction(drugOrderDetail.ObjectContext);
            newDrugOrderTransaction.DrugOrder = drugOrder;
            newDrugOrderTransaction.DrugOrderDetail = drugOrderDetail;
            newDrugOrderTransaction.InOut = 2;
            newDrugOrderTransaction.Amount = usedAmount;
            newDrugOrderTransaction.Volume = usedVolume;

            if(drugOrder.CurrentStateDefID != DrugOrder.States.Completed)
            {
                drugOrder.CurrentStateDefID = DrugOrder.States.Completed;
            }*/

            #endregion PreTransition_Supply2ReturnPharmacy
        }

        protected void PreTransition_Planned2UseRestDose()
        {
            // From State : Planned   To State : UseRestDose
            #region PreTransition_Supply2ReturnPharmacy
            if (this.DrugOrder.DrugOrderTransactions.Any() == false)
            {
                DrugDefinition drugDefinition = ((DrugDefinition)this.Material);
                bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                if (drugType == false)
                {
                    if (this.Eligible == true)
                        this.Eligible = false;
                }
            }
            #endregion PreTransition_Supply2ReturnPharmacy
        }

        protected void PostTransition_ExPharmacySupply2Apply()
        {
            // From State : ExPharmacySupply   To State : Apply
            #region PostTransition_ExPharmacySupply2Apply

            /*DrugOrderDetail drugOrderDetail = this;
            DrugOrder drugOrder = drugOrderDetail.DrugOrder ;

            // PatientRestDose güncelleniyor.
            double patientRestDose = 0;
            double usedAmount = 0 ;
            double usedVolume = 0;
            double usedCount = 0;
            bool fullDose = false ;

            bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrderDetail.Material);

            if ((double?)((DrugDefinition)drugOrderDetail.Material).Volume != null)
            {
                if (drugType)
                {
                    usedAmount = (double)drugOrderDetail.Amount;
                    usedVolume = (double)drugOrderDetail.Amount * (double)((DrugDefinition)drugOrderDetail.Material).Volume;
                }
                else
                {
                    usedAmount = (double)drugOrderDetail.Amount / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
                    usedVolume = (double)drugOrderDetail.Amount;
                }
            }
            else
            {
                throw new Exception("Bu ilacın İlaç Doz bilgisi bulunmamaktadır. İlaç tanımları kontrol edilmelidir.");
            }

            double restDose = DrugOrderTransaction.GetRestDose (drugOrder);

            if (restDose > 0)
            {
                patientRestDose = restDose - (double)drugOrderDetail.Amount;
                if (patientRestDose >= 0)  //TotalDose 'u kullanıcı bitirirse kalan orderler ne olacak ?
                {
                    if (patientRestDose == 0)
                    {
                        fullDose = true;
                    }

                    DrugOrderTransaction newDrugOrderTransaction = new DrugOrderTransaction(drugOrderDetail.ObjectContext);

                    newDrugOrderTransaction.DrugOrder = drugOrder;
                    newDrugOrderTransaction.DrugOrderDetail = drugOrderDetail;
                    newDrugOrderTransaction.InOut = 2;
                    if (!(bool)drugOrderDetail.DrugDone)
                    {
                        newDrugOrderTransaction.Amount = usedAmount;
                        newDrugOrderTransaction.Volume = usedVolume;
                    }
                    else
                    {
                        newDrugOrderTransaction.Amount = restDose / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
                        newDrugOrderTransaction.Volume = restDose;
                        fullDose = true;
                        //Buraya mesaj verdirilmesi gerekiyor.
                    }
                }
                else
                {
                    throw new Exception("Hastanın bu uygulama için belirtiğiniz miktarda dozu bulunmamaktadır.");
                }
            }
            else
            {
                Dictionary<object, double> patientRestDictionary = DrugOrderTransaction.GetPatientRestDose(drugOrderDetail.Material, drugOrderDetail.Episode);
                foreach (KeyValuePair<object, double> restDic in patientRestDictionary)
                {
                    if (restDic.Value >= (double)drugOrderDetail.Amount & usedCount == 0 )
                    {
                        DrugOrderTransaction newDrugOrderTransaction = new DrugOrderTransaction(drugOrderDetail.ObjectContext);

                        newDrugOrderTransaction.DrugOrder = (DrugOrder)restDic.Key ;
                        newDrugOrderTransaction.DrugOrderDetail = drugOrderDetail;
                        newDrugOrderTransaction.InOut = 2;
                        usedCount = 1;
                        if (!(bool)drugOrderDetail.DrugDone)
                        {
                            newDrugOrderTransaction.Amount = usedAmount;
                            newDrugOrderTransaction.Volume = usedVolume;
                        }
                        else
                        {
                            newDrugOrderTransaction.Amount = restDose / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
                            newDrugOrderTransaction.Volume = restDose;
                            fullDose = true;
                            //Buraya mesaj verdirilmesi gerekiyor.
                        }

                    }
                }
            }

            if (fullDose)
            {
                if(drugOrderDetail.KScheduleCollectedOrder != null)
                {
                    foreach (DrugOrderDetail anotherDrugOrderDetail in  drugOrderDetail.KScheduleCollectedOrder.DrugOrderDetails)
                    {
                        if (anotherDrugOrderDetail.CurrentStateDefID == new Guid ("d4f85132-8d05-4dc7-b9b2-fc04bae622b0") & anotherDrugOrderDetail.ObjectID != drugOrderDetail.ObjectID )
                        {
                            anotherDrugOrderDetail.CurrentStateDefID = new Guid("cb22e74b-a2be-456f-8680-660d0b21dc24");
                        }
                    }
                }
            }


            // Order Statusu güncelleniyor. SS
            int CompletedAplication = 0 ;
            int NonCompletedAplication = 0;
            if (drugOrder.DrugOrderDetails.Count == 1)
            {
                drugOrder.CurrentStateDefID = new Guid (DrugOrder.States.Completed.ToString());
            }
            else
            {
                foreach(DrugOrderDetail oldDrugOrderDetail in drugOrder.DrugOrderDetails)
                {
                    if (oldDrugOrderDetail != drugOrderDetail)
                    {
                        if (oldDrugOrderDetail.CurrentStateDefID == new Guid("d39a37a6-610e-4143-aca2-691ce5818915") || oldDrugOrderDetail.CurrentStateDefID == new Guid("add6e452-c007-4849-b477-17d30400abe8"))
                        {
                            CompletedAplication = CompletedAplication + 1 ;
                        }
                        else
                        {
                            NonCompletedAplication = NonCompletedAplication + 1 ;
                        }
                    }
                }

//                if (CompletedAplication == 0)
//                {
//                    // drugOrder.CurrentStateDefID = new Guid("c227b72e-56bc-4279-81dd-a2be3a843ee0");
//                    
//                    drugOrder.CurrentStateDefID = DrugOrder.States.Planned;
//                    drugOrder.Update();
//                    drugOrder.CurrentStateDefID = DrugOrder.States.Continued;
//                    
//                }
                if ( drugOrder.DrugOrderDetails.Count - 1 == CompletedAplication )
                {
                    // drugOrder.CurrentStateDefID = new Guid ("c423baa7-7c23-4a04-beef-0162ad204877");
                    if(drugOrderDetail.DrugOrder.GetType()== typeof(DrugOrder))
                        drugOrderDetail.DrugOrder.CurrentStateDefID = DrugOrder.States.Completed;
                }
            }*/
            #endregion PostTransition_ExPharmacySupply2Apply
        }

        protected void PreTransition_ExPharmacySupply2PatientDelivery()
        {
            // From State : ExPharmacySupply   To State : PatientDelivery
            #region PreTransition_ExPharmacySupply2PatientDelivery

            /* DrugOrderDetail drugOrderDetail = this;
             DrugOrder drugOrder = drugOrderDetail.DrugOrder ;
             double usedAmount = (double)drugOrderDetail.Amount;
             double usedVolume = (double)drugOrderDetail.Amount * (double)((DrugDefinition)drugOrderDetail.Material).Volume;
             DrugOrderTransaction newDrugOrderTransaction = new DrugOrderTransaction(drugOrderDetail.ObjectContext);
             newDrugOrderTransaction.DrugOrder = drugOrder;
             newDrugOrderTransaction.DrugOrderDetail = drugOrderDetail;
             newDrugOrderTransaction.InOut = 2;
             newDrugOrderTransaction.Amount = usedAmount;
             newDrugOrderTransaction.Volume = usedVolume;

             bool orderStatus = true ;
             foreach(DrugOrderDetail alldetail in drugOrder.DrugOrderDetails)
             {
                 if(alldetail.CurrentStateDef.Status == StateStatusEnum.Uncompleted && alldetail.ObjectID != drugOrderDetail.ObjectID )
                 {
                     orderStatus = false ;
                     break;
                 }
             }

             if(orderStatus)
             {
                 drugOrder.CurrentStateDefID = DrugOrder.States.Completed;
             }
             */
            #endregion PreTransition_ExPharmacySupply2PatientDelivery
        }

        #region Methods
        #region IDrugOrderDetailApply Members
        public DrugOrderDetail GetOwnDrugOrderDetail()
        {
            return OwnDrugOrderDetail;
        }

        public void SetOwnDrugOrderDetail(DrugOrderDetail value)
        {
            OwnDrugOrderDetail = value;
        }
        #endregion
        override public object GetDVO(AccountTransaction AccTrx)
        {
            HizmetKayitIslemleri.ilacBilgisiDVO ilacBilgisiDVO = new HizmetKayitIslemleri.ilacBilgisiDVO();

            if (Material.AccTrxAmountMultiplier.HasValue)
                ilacBilgisiDVO.adet = AccTrx.Amount * Material.AccTrxAmountMultiplier.Value;
            else
                ilacBilgisiDVO.adet = AccTrx.Amount;

            //ilacBilgisiDVO.adetSpecified = true;
            ilacBilgisiDVO.barkod = string.IsNullOrEmpty(AccTrx.Barcode) ? Material.Barcode : AccTrx.Barcode;
            ilacBilgisiDVO.hizmetSunucuRefNo = AccTrx.MedulaReferenceNumber;
            ilacBilgisiDVO.islemTarihi = AccTrx.MedulaTransactionDate;
            ilacBilgisiDVO.paketHaric = AccTrx.MedulaPackageInOut;
            ilacBilgisiDVO.tutar = AccTrx.UnitPrice;
            //ilacBilgisiDVO.tutarSpecified = true;

            // 1 : Barkodlu ilaç , 2 : Majistral ilaç , 3 : Radyofarmasötik Ajan  (Şimdilik 3 göndermiyoruz)
            if (Material is MagistralPreparationDefinition)
            {
                ilacBilgisiDVO.ilacTuru = "2";
                ilacBilgisiDVO.aciklama = MedulaMagistralPreparationDescription;   // majistral ilacın içeriğini döndüren coded property
            }
            else
                ilacBilgisiDVO.ilacTuru = "1";

            StockTransaction stockTransaction = GetStockTransactionForDrugDVO();
            if (stockTransaction != null)
            {
                ilacBilgisiDVO.SN = stockTransaction.SerialNo;
                ilacBilgisiDVO.sonKullanimTarihi = stockTransaction.ExpirationDate.HasValue ? stockTransaction.ExpirationDate.Value.ToString("dd.MM.yyyy") : null;
                ilacBilgisiDVO.batchNo = stockTransaction.LotNo;
                //ilacBilgisiDVO.itsBirimSarfId = null;  // Şimdilik tutulan bir bilgi değil, ileride gerek olursa doldurulacak. 
            }
            
            return ilacBilgisiDVO;
        }

        public StockTransaction GetStockTransactionForDrugDVO()
        {
            DrugOrderTransactionDetail drugOrderTransactionDetail = this.ObjectContext.QueryObjects<DrugOrderTransactionDetail>("DRUGORDERDETAIL = '" + this.ObjectID + "'").FirstOrDefault();
            if (drugOrderTransactionDetail != null && drugOrderTransactionDetail.StockTransaction != null)
                return drugOrderTransactionDetail.StockTransaction;

            // Normalde üstteki şekilde StockTransaction a ulaşabilmesi lazım ama üstte bulamazsa aşağıdaki şekilde de StockTransaction a ulaşılabilir
            if (DrugOrder != null)
            {
                DrugOrderTransaction drugOrderTransaction = DrugOrder.DrugOrderTransactions.FirstOrDefault();
                if (drugOrderTransaction != null && drugOrderTransaction.KScheduleMaterial != null)
                {
                    return drugOrderTransaction.KScheduleMaterial.StockTransactions.Select(string.Empty).FirstOrDefault();
                }
            }

            return null;
        }

        #endregion Methods

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DrugOrderDetail).Name)
                return;


            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DrugOrderDetail.States.Supply && toState == DrugOrderDetail.States.Apply)
                UndoTransition_Apply2Supply();
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DrugOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DrugOrderDetail.States.UseRestDose && toState == DrugOrderDetail.States.Apply)
                PreTransition_UseRestDose2Apply();
            else if (fromState == DrugOrderDetail.States.Planned && toState == DrugOrderDetail.States.ReturnPharmacy)
                PreTransition_Planned2ReturnPharmacy();
            else if (fromState == DrugOrderDetail.States.Planned && toState == DrugOrderDetail.States.PatientDelivery)
                PreTransition_Planned2PatientDelivery();
            else if (fromState == DrugOrderDetail.States.Supply && toState == DrugOrderDetail.States.Cancel)
                PreTransition_Supply2Cancel();
            else if (fromState == DrugOrderDetail.States.Supply && toState == DrugOrderDetail.States.Apply)
                PreTransition_Supply2Apply();
            else if (fromState == DrugOrderDetail.States.Supply && toState == DrugOrderDetail.States.PatientDelivery)
                PreTransition_Supply2PatientDelivery();
            else if (fromState == DrugOrderDetail.States.Supply && toState == DrugOrderDetail.States.ReturnPharmacy)
                PreTransition_Supply2ReturnPharmacy();
            else if (fromState == DrugOrderDetail.States.ExPharmacySupply && toState == DrugOrderDetail.States.PatientDelivery)
                PreTransition_ExPharmacySupply2PatientDelivery();
            else if (fromState == DrugOrderDetail.States.Apply && toState == DrugOrderDetail.States.Cancel)
                PreTransition_Apply2Cancel();
            else if (fromState == DrugOrderDetail.States.Planned && toState == DrugOrderDetail.States.UseRestDose)
                PreTransition_Planned2UseRestDose();

        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DrugOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DrugOrderDetail.States.UseRestDose && toState == DrugOrderDetail.States.Apply)
                PostTransition_UseRestDose2Apply();
            else if (fromState == DrugOrderDetail.States.Supply && toState == DrugOrderDetail.States.Cancel)
                PostTransition_Supply2Cancel();
            else if (fromState == DrugOrderDetail.States.Supply && toState == DrugOrderDetail.States.Apply)
                PostTransition_Supply2Apply();
            else if (fromState == DrugOrderDetail.States.ExPharmacySupply && toState == DrugOrderDetail.States.Apply)
                PostTransition_ExPharmacySupply2Apply();
        }

    }
}