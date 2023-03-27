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
    /// İlaç Direktifi
    /// </summary>
    public partial class DrugOrder : BaseDrugOrder
    {
        public partial class GetAllDrugsWithDetailForDoctorReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetDrugsFromPharmacyReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetDrugsToPatientWithPrescriptionReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetAllDrugsForPatientGroupsReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetDrugsExceededMaxPackageAmountReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetDrugsToPatientsForEpisodeReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetDrugsToPatientsForDateReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetDrugOrder_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetCancelledDrugOrder_Class : TTReportNqlObject
        {
        }

        public partial class IlacOdemeQuery_Class : TTReportNqlObject
        {
        }

        public partial class VEM_RECETE_ILAC_ACIKLAMA_Class : TTReportNqlObject
        {
        }

        /// <summary>
        /// İlaç Hacmi
        /// </summary>
        public string VolumeUnit
        {
            get
            {
                try
                {
                    #region VolumeUnit_GetScript                    
                    if (Material != null && Material is DrugDefinition)
                    {
                        DrugDefinition drug = (DrugDefinition)Material;
                        if (drug.Volume != null && drug.Unit != null)
                            return drug.Volume.ToString() + " " + drug.Unit.Name;
                    }

                    return string.Empty;
                    #endregion VolumeUnit_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "VolumeUnit") + " : " + ex.Message, ex);
                }
            }

            set
            {
                try
                {
                    #region VolumeUnit_SetScript                    
                    this["VolumeUnit"] = value;
                    #endregion VolumeUnit_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "VolumeUnit") + " : " + ex.Message, ex);
                }
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "INPATIENTPHYSICIANAPPLICATION":
                    {
                        InPatientPhysicianApplication value = (InPatientPhysicianApplication)newValue;
                        #region INPATIENTPHYSICIANAPPLICATION_SetParentScript
                        if (value != null)
                        {
                            FromResource = value.FromResource;
                            MasterResource = value.MasterResource;
                            Episode = value.Episode;
                            if (value.InPatientTreatmentClinicApp != null)
                            {
                                if (value.InPatientTreatmentClinicApp.NursingApplications.Count > 0)
                                {
                                    NursingApplication = value.InPatientTreatmentClinicApp.NursingApplications[0];
                                }
                            }

                            SubEpisode = value.SubEpisode;
                        }
                        #endregion INPATIENTPHYSICIANAPPLICATION_SetParentScript
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
            if (Material != null)
            {
                if (Material.ObjectID.ToString() == SystemParameter.GetParameterValue("MAGISTRALPRE", ""))
                {
                    if (MagistralDrugDetails.Count == 0 && MagistralChemicalDetails.Count == 0)
                        throw new Exception(SystemMessage.GetMessage(613));
                }
            }
            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert
            if (GetType() == typeof(DrugOrder))
            {
                DrugOrder drugOrder = this;
                drugOrder.PhysicianOrderedDrug = drugOrder.Material;

                if (CheckCreateInfectionCommitee())
                {
                    drugOrder.CurrentStateDefID = DrugOrder.States.Approve;
                    // TO DO : Enfeksiyon Komitesi işlemi başlatılacak.
                    InfectionCommittee infectionCommittee = new InfectionCommittee(drugOrder.ObjectContext);
                    infectionCommittee.ActionDate = Common.RecTime();
                    infectionCommittee.FromResource = MasterResource;
                    infectionCommittee.MasterResource = drugOrder.MasterResource;
                    infectionCommittee.Episode = drugOrder.Episode;
                    infectionCommittee.SubEpisode = drugOrder.SubEpisode;
                    infectionCommittee.InPatientPhysicianApplication = drugOrder.InPatientPhysicianApplication;
                    infectionCommittee.CurrentStateDefID = InfectionCommittee.States.New;
                    infectionCommittee.ProcedureDoctor = drugOrder.RequestedByUser;
                    InfectionCommitteeDetail infectionCommitteeDetail = new InfectionCommitteeDetail(drugOrder.ObjectContext);
                    infectionCommitteeDetail.DrugOrder = drugOrder;
                    infectionCommitteeDetail.InfectionCommittee = infectionCommittee;
                }

                if (drugOrder.DrugOrderDetails.Count > 1)
                {
                    int detailno = 1;
                    foreach (DrugOrderDetail drugOrderDetail in drugOrder.DrugOrderDetails.Select(string.Empty, "ORDERPLANNEDDATE"))
                    {
                        if (drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.Cancel)
                        {
                            drugOrderDetail.DetailNo = detailno;
                            detailno++;
                        }
                    }
                }
            }
            #endregion PostInsert
        }

        protected override void PreDelete()
        {
            #region PreDelete
            if (DrugOrderDetails.Count > 0)
            {
                throw new Exception(SystemMessage.GetMessage(614));
            }
            else
            {
                base.PreDelete();
            }
            #endregion PreDelete
        }

        protected void PostTransition_New2Planned()
        {
            // From State : New   To State : Planned
            #region PostTransition_New2Planned
            //            DrugOrder drugOrder = this ;
            //            
            //            
            //            if (DrugOrder.GetContinueDrugOrder(drugOrder, (DateTime)drugOrder.PlannedStartTime))
            //            {
            //                if (drugOrder.Material.ObjectDef.Name.ToString() != "MAGISTRALPREPARATIONDEFINITION")
            //                {
            //                    bool inheld = false;
            //                    double totalAmount = 0;
            //                    double detailCount = DrugOrder.GetDetailCount(drugOrder.Frequency);
            //                    double detailTimePeriod = DrugOrder.GetDetailTimePeriod(drugOrder.Frequency);
            //                    double unitAmount = 0 ;
            //                    DrugDefinition drugDefinition = ((DrugDefinition)drugOrder.Material);
            //                    detailCount = detailCount * (double)drugOrder.Day;
            //                    bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
            //                    
            //                    if (drugType)
            //                    {
            //                        unitAmount = (double)drugOrder.DoseAmount ;
            //                        totalAmount = unitAmount * (double)detailCount;
            //                    }
            //                    else
            //                    {
            //                        unitAmount = (double)drugOrder.DoseAmount * (double)drugDefinition.Dose ;
            //                        totalAmount = Math.Ceiling((unitAmount / (double)drugDefinition.Volume) * (double)detailCount);
            //                    }
            //                    
            //                    drugOrder.Amount = (double)totalAmount;
            //
            //                    IList pharmacyStore = drugOrder.ObjectContext.QueryObjects("PHARMACYSTORE", "PHARMACYTYPE = 1 AND STATUS = 1") ;
            //                    //BindingList<PharmacyStore>  pharmacyStore = PharmacyStore.GetPharmacyStores(drugOrder.ObjectContext);
            //                    
            //                    if (pharmacyStore.Count == 1)
            //                    {
            //                        PharmacyStore pharmacyStoreClinic = (PharmacyStore)pharmacyStore[0];
            //                        BindingList<Stock> stocks = pharmacyStoreClinic.Stocks.Select("MATERIAL = '" +  drugOrder.Material.ObjectID.ToString() + "'");
            //                        if(stocks != null && stocks.Count > 0 )
            //                        {
            //                            Stock stock = stocks[0];
            //                            if(stock != null && stock.Inheld > 0)
            //                                inheld = true;
            //                            else
            //                                inheld = false;
            //                        }
            //
            //                        if (inheld)// Inheld TotalAmount tan büyük veya eşit olacak SS.
            //                        {  
            //                            DateTime detailTime = (DateTime)drugOrder.PlannedStartTime ;
            //                            drugOrder.Type = "K-Çizelgesi";
            //                            for (int i = 0; i < detailCount ; i++)
            //                            {
            //                                DrugOrderDetail drugOrderDetail = new DrugOrderDetail(drugOrder.ObjectContext);
            //                                drugOrderDetail.Material = (Material)drugOrder.Material  ;
            //                                drugOrderDetail.MasterResource = drugOrder.MasterResource ;
            //                                drugOrderDetail.FromResource = drugOrder.FromResource ;
            //                                drugOrderDetail.Episode = drugOrder.Episode ;
            //                                drugOrderDetail.ActionDate = drugOrder.ActionDate;// Bu actionun açıldığı tarih olmalı. SS
            //                                drugOrderDetail.OrderPlannedDate = detailTime ;
            //                                detailTime = detailTime.AddHours(detailTimePeriod);
            //                                drugOrderDetail.Amount = unitAmount ;
            //                                drugOrderDetail.Day = drugOrder.Day ;
            //                                drugOrderDetail.DoseAmount = drugOrder.DoseAmount ;
            //                                drugOrderDetail.Frequency = drugOrder.Frequency;
            //                                drugOrderDetail.UsageNote = drugOrder.UsageNote ;
            //                                drugOrderDetail.DrugOrder = drugOrder;
            //                                drugOrderDetail.ID = 3000 + i;
            //                                drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
            ////                                if( drugOrder.CurrentStateDefID == DrugOrder.States.Cancelled)
            ////                                    drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
            //                            }
            //                            
            //                        }
            //                        else
            //                        {
            //                            drugOrder.Type = "Yatan Hasta Reçetesi";
            //                            InpatientPrescription inpatientPrescription = new InpatientPrescription (drugOrder.ObjectContext);
            //                            inpatientPrescription.ActionDate = drugOrder.ActionDate ;
            //                            inpatientPrescription.Episode = drugOrder.Episode ;
            //                            inpatientPrescription.FillingDate = drugOrder.ActionDate ;
            //                            inpatientPrescription.FromResource = drugOrder.FromResource ;
            //                            inpatientPrescription.MasterResource = drugOrder.MasterResource ;
            //                            inpatientPrescription.PrescriptionNO = "432523";
            //                            inpatientPrescription.CurrentStateDefID = InpatientPrescription.States.Request;//new Guid ("5a418789-3458-44d2-87a8-662fb1f3f8ab");
            //                            
            //                            InpatientDrugOrder inpatientDrugOrder = new InpatientDrugOrder (drugOrder.ObjectContext);//inpatientPrescription.InpatientDrugOrders.AddNew();
            //                            inpatientDrugOrder.InpatientPrescription = inpatientPrescription;
            //                            inpatientDrugOrder.ActionDate = drugOrder.ActionDate ;
            //                            inpatientDrugOrder.Amount = drugOrder.Amount;
            //                            inpatientDrugOrder.Day = drugOrder.Day;
            //                            inpatientDrugOrder.DoseAmount = drugOrder.DoseAmount ;
            //                            inpatientDrugOrder.Episode = drugOrder.Episode;
            //                            inpatientDrugOrder.Frequency = drugOrder.Frequency;
            //                            inpatientDrugOrder.FromResource = drugOrder.FromResource;
            //                            inpatientDrugOrder.MasterResource = drugOrder.MasterResource;
            //                            inpatientDrugOrder.Material = drugOrder.Material;
            //                            inpatientDrugOrder.UsageNote = drugOrder.UsageNote;
            //                            inpatientDrugOrder.ID = 23232;
            //                            inpatientDrugOrder.CurrentStateDefID = InpatientDrugOrder.States.New;
            //                           // drugOrder.CurrentStateDefID = DrugOrder.States.Cancelled;
            //                            //inpatientPrescription.InpatientDrugOrders.Add(inpatientDrugOrder);
            //                            
            //                            
            //                            
            //                        }
            //                        
            //                        //Şimdi verilen Order'ın Amountu rest kalan amounttan büyük ise kalan restdose'u otomatik olarak bitirme. SS.
            //                        Dictionary <object,double> restDictionary =DrugOrderTransaction.GetPatientRestDose(drugOrder.Material, drugOrder.Episode);
            //                        if (restDictionary.Count > 0)
            //                        {
            //                            foreach (KeyValuePair<object, double> rest in restDictionary)
            //                            {
            //                                if (rest.Value < unitAmount)
            //                                {
            //                                    DrugOrder restDrugOrder = (DrugOrder)rest.Key ;
            //                                    DrugDoseCompletion drugDoseCompletion = new DrugDoseCompletion(drugOrder.ObjectContext);
            //                                    DrugDoseCompletionDetail drugDoseCompletionDetail = new DrugDoseCompletionDetail(drugOrder.ObjectContext);
            //                                    drugDoseCompletionDetail.ActionDate = DateTime.Today;
            //                                    drugDoseCompletionDetail.Amount = rest.Value;
            //                                    drugDoseCompletionDetail.Day = restDrugOrder.Day;
            //                                    drugDoseCompletionDetail.DoseAmount = rest.Value;
            //                                    drugDoseCompletionDetail.DrugDone = true;
            //                                    drugDoseCompletionDetail.DrugOrder = restDrugOrder;
            //                                    drugDoseCompletionDetail.Episode = restDrugOrder.Episode;
            //                                    drugDoseCompletionDetail.Frequency = restDrugOrder.Frequency;
            //                                    drugDoseCompletionDetail.FromResource = restDrugOrder.FromResource;
            //                                    drugDoseCompletionDetail.MasterResource = restDrugOrder.MasterResource;
            //                                    drugDoseCompletionDetail.Material = restDrugOrder.Material;
            //                                    drugDoseCompletionDetail.OrderPlannedDate = DateTime.Today;
            //                                    drugDoseCompletionDetail.PackageQuantity = 1;
            //                                    drugDoseCompletionDetail.SecondaryMasterResource = restDrugOrder.SecondaryMasterResource;
            //                                    drugDoseCompletionDetail.UsageNote = restDrugOrder.UsageNote;
            //                                    drugDoseCompletionDetail.DrugDoseCompletion = drugDoseCompletion;
            //                                    drugDoseCompletion.CurrentStateDefID = new Guid(DrugDoseCompletion.States.New.ToString());
            //                                    drugDoseCompletionDetail.CurrentStateDefID = new Guid(DrugDoseCompletionDetail.States.Planned.ToString());
            //                                    DrugOrderTransaction drugOrderTransaction = new DrugOrderTransaction(drugOrder.ObjectContext);
            //                                    drugOrderTransaction.DrugOrder = drugDoseCompletionDetail.DrugOrder;
            //                                    drugOrderTransaction.DrugOrderDetail = drugDoseCompletionDetail;
            //                                    drugOrderTransaction.Amount = 1;
            //                                    drugOrderTransaction.InOut = 2;
            //                                    drugOrderTransaction.Volume = rest.Value;
            //                                    
            //                                    //                                    ITTObject completion = (ITTObject)drugDoseCompletion;
            //                                    //                                    ITTObject completionDetail = (ITTObject)drugDoseCompletionDetail;
            //                                    //                                    completion.SetCurrentStateDef(new Guid(DrugDoseCompletion.States.Completed.ToString()));
            //                                    //                                    completionDetail.SetCurrentStateDef(new Guid(DrugDoseCompletionDetail.States.Apply.ToString()));
            //                                    
            //                                }
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        throw new TTException ("Birden fazla Klinik Eczanesi Tanımlandığı İçin işleminiz sona erdirilmiştir.!!!");
            //                    }
            //                }
            //                else
            //                {
            //                    drugOrder.Amount = 1; //Bu alan şimdilik elle dolduruluyor. SS.
            //                    MagistralPreparationPrescription magistralPreparationPrescription = new MagistralPreparationPrescription (drugOrder.ObjectContext);
            //                    magistralPreparationPrescription.ActionDate = DateTime.Now.Date;
            //                    magistralPreparationPrescription.Episode = drugOrder.Episode;
            //                    magistralPreparationPrescription.FromResource = drugOrder.FromResource;
            //                    //magistralPreparationPrescription.ID = 22332;
            //                    //magistralPreparationPrescription.ID.GetNextValue();
            //                    magistralPreparationPrescription.MasterResource = drugOrder.MasterResource;
            //                    magistralPreparationPrescription.CurrentStateDefID = new Guid("0652d3ea-fd0f-4078-87a7-1295ae09c9f6");
            //                    
            //                    MagistralPreparationPrescriptionDetail magistralPreparationPrescriptionDetail = new MagistralPreparationPrescriptionDetail(drugOrder.ObjectContext);
            //                    magistralPreparationPrescriptionDetail.Amount = drugOrder.Amount ;
            //                    magistralPreparationPrescriptionDetail.MagistralPreparationDefinition = (MagistralPreparationDefinition)drugOrder.Material;
            //                    magistralPreparationPrescriptionDetail.MagistralPreparationPrescription = magistralPreparationPrescription;
            //                }
            //            }
            //            else
            //            {
            //                throw new TTException ("Bu ilaç daha önce order edilmiş ve hala tedavisi devam etmektedir!!!");
            //            }
            #endregion PostTransition_New2Planned
        }

        protected void PostTransition_Stopped2Cancelled()
        {
            // From State : Stopped   To State : Cancelled
            #region PostTransition_Stopped2Cancelled
            foreach (DrugOrderDetail drugOrderDetail in DrugOrderDetails)
            {
                if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Stop)
                    drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
            }
            #endregion PostTransition_Stopped2Cancelled
        }

        protected void PostTransition_Approve2Planned()
        {
            #region PostTransition_Approve2Planned
            if (CaseOfNeed.HasValue && CaseOfNeed.Value)
            {
                DateTime now = Common.RecTime().AddHours(1);

                DateTime detailTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, 00, 00);
                double totalAmount = 0;
                int detailCount = (int)HospitalTimeSchedule.Frequency;// gridViewModel.DrugOrderIntroductionDetail.DrugOrderDetailTimeSchedule.Count;
                int detailHour = 24 / detailCount;                                                                           //double detailTimePeriod = DrugOrder.GetDetailTimePeriod(drugOrder.Frequency);
                DrugDefinition drugDefinition = ((DrugDefinition)Material);
                detailCount = detailCount * (int)Day;
                bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);

                //this.Amount = (double)totalAmount;

                for (int i = 0; i < detailCount; i++)
                {
                    DrugOrderDetail drugOrderDetail = new DrugOrderDetail(ObjectContext);
                    drugOrderDetail.Material = (Material)Material;
                    drugOrderDetail.MasterResource = MasterResource;
                    drugOrderDetail.FromResource = FromResource;
                    drugOrderDetail.Episode = Episode;
                    drugOrderDetail.ActionDate = ActionDate; // Bu actionun açıldığı tarih olmalı. SS
                    drugOrderDetail.OrderPlannedDate = detailTime;
                    drugOrderDetail.UsageNote = UsageNote;
                    drugOrderDetail.Day = Day;
                    drugOrderDetail.SubEpisode = SubEpisode;
                    drugOrderDetail.MedulaReportNo = MedulaReportNo;

                    double unitAmount = Math.Ceiling(DoseAmount.Value);
                    double doseAmount = 0;

                    if (drugType)
                    {
                        totalAmount = unitAmount * (double)detailCount;
                        doseAmount = (double)DoseAmount;
                    }
                    else
                    {
                        totalAmount = Math.Ceiling((unitAmount / (double)drugDefinition.Volume) * (double)detailCount);
                        doseAmount = (double)DoseAmount * (double)drugDefinition.Dose;
                    }

                    drugOrderDetail.Amount = unitAmount;
                    drugOrderDetail.DoseAmount = doseAmount;
                    drugOrderDetail.Frequency = Frequency;
                    drugOrderDetail.HospitalTimeSchedule = HospitalTimeSchedule;
                    drugOrderDetail.DrugOrder = this;
                    drugOrderDetail.DetailNo = i + 1;
                    drugOrderDetail.SecondaryMasterResource = NursingApplication.SecondaryMasterResource;
                    drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                    drugOrderDetail.Eligible = true;
                    detailTime = detailTime.AddHours(detailHour);

                }
            }

            #endregion PostTransition_Approve2Planned
        }

        protected void PostTransition_Stopped2Continued()
        {
            // From State : Stopped   To State : Continued
            #region PostTransition_Stopped2Continued
            foreach (DrugOrderDetail drugOrderDetail in DrugOrderDetails)
            {
                if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Stop)
                    drugOrderDetail.CurrentStateDefID = drugOrderDetail.PrevState.StateDefID;
            }
            #endregion PostTransition_Stopped2Continued
        }

        protected void PostTransition_Continued2Stopped()
        {
            // From State : Continued   To State : Stopped
            #region PostTransition_Continued2Stopped
            foreach (DrugOrderDetail drugOrderDetail in DrugOrderDetails)
            {
                if (((DateTime)drugOrderDetail.OrderPlannedDate).Date > Common.RecTime().Date)
                {
                    if (drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.Apply && drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.Cancel)
                        drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Stop;
                }
                else
                {
                    if (drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.Apply && drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.Cancel)
                    {
                        if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Supply)
                        {
                            drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Apply;
                        }
                        else if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.UseRestDose)
                        {
                            drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Apply;
                        }
                        else
                        {
                            if (drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.Apply && drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.PatientDelivery)
                                drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Stop;
                        }
                    }
                }
            }
            #endregion PostTransition_Continued2Stopped
        }

        protected void PostTransition_Planned2Stopped()
        {
            // From State : Planned   To State : Stopped
            #region PostTransition_Planned2Stopped
            foreach (DrugOrderDetail drugOrderDetail in DrugOrderDetails)
            {
                if (((DateTime)drugOrderDetail.OrderPlannedDate).Date > Common.RecTime().Date)
                {
                    if (drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.Apply && drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.Cancel)
                        drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Stop;
                }
                else
                {
                    if (drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.Apply && drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.Cancel)
                    {
                        if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Supply)
                        {
                            drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Stop;
                        }
                        else if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.UseRestDose)
                        {
                            drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Stop;
                        }
                        else
                        {
                            if (drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.Apply && drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.PatientDelivery)
                                if (drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.ReturnPharmacy)
                                    drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Stop;
                        }
                    }
                }
            }
            #endregion PostTransition_Planned2Stopped
        }

        protected void PostTransition_Planned2Cancelled()
        {
            // From State : Planned   To State : Cancelled
            #region PostTransition_Planned2Cancelled
            foreach (DrugOrderDetail drugOrderDetail in DrugOrderDetails)
            {
                drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
            }
            #endregion PostTransition_Planned2Cancelled
        }

        protected void PostTransition_Approve2Cancelled()
        {
            // From State : Approve   To State : Cancelled
            #region PostTransition_Approve2Cancelled
            foreach (DrugOrderDetail drugOrderDetail in DrugOrderDetails)
            {
                drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
            }
            #endregion PostTransition_Approve2Cancelled
        }

        #region Methods


        public bool CheckCreateInfectionCommitee()
        {
            bool returnValue = false;
            if (((DrugDefinition)Material).InfectionApproval == true && PatientOwnDrug == false)
            {
                if (SystemParameter.GetParameterValue("INFECTIONCOMMITEEDAYAPPROVEL", "FALSE") == "TRUE")
                {
                    DateTime pTem = DrugOrderDetails[DrugOrderDetails.Count - 1].OrderPlannedDate.Value;
                    if (Day == 1)
                        pTem = PlannedStartTime.Value;

                    var infectionComCount = InfectionCommittee.GetActiveInfectionComApprovelByMat(SubEpisode.ObjectID, pTem, Material.ObjectID).Count();

                    if (infectionComCount == 0)
                        returnValue = true;
                }
                else
                    returnValue = true;
            }
            return returnValue;
        }

        public override string ToString()
        {
            return ObjectID.ToString() + " " + Material.Name.ToString() + " " + Frequency.Value.ToString() + "te " + DoseAmount.Value.ToString() + " sefer " + Day.Value.ToString() + " gün boyunca uygulanacak.";
        }

        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if (ttObject.IsNew)
            {
                //Guid episodeGuid = new Guid("408272e7-e0de-47bd-b868-fe3318b44986");
                //this.Episode = (Episode)this.ObjectContext.GetObject(episodeGuid,"EPISODE");
                //Guid resourceGuid = new Guid ("8010e088-8e50-4d92-bdfa-9da7ada9796f");
                //this.MasterResource = (Resource)this.ObjectContext.GetObject(resourceGuid,"RESOURCE");
                //this.FromResource = (Resource)this.ObjectContext.GetObject(resourceGuid,"RESOURCE");
                //this.CurrentStateDefID = new Guid("66c795fb-1c52-4e78-b70b-5ad565573360");
                if (ActionDate == null)
                    ActionDate = DateTime.Now;
                if (Active == null)
                    Active = true;
                if (GetType() == typeof(DrugOrder))
                    CurrentStateDefID = DrugOrder.States.New;
                else if (GetType() == typeof(InpatientDrugOrder))
                    CurrentStateDefID = InpatientDrugOrder.States.New;
            }
        }

        public static double GetDetailCount(FrequencyEnum? pFrequency)
        {
            if (pFrequency.HasValue == false)
                throw new TTException(SystemMessage.GetMessage(615));
            FrequencyEnum Frequency = pFrequency.Value;
            double detailCount = 0;
            switch (Frequency)
            {
                case FrequencyEnum.Q1H:
                    detailCount = 24;
                    break;
                case FrequencyEnum.Q2H:
                    detailCount = 12;
                    break;
                case FrequencyEnum.Q3H:
                    detailCount = 8;
                    break;
                case FrequencyEnum.Q4H:
                    detailCount = 6;
                    break;
                case FrequencyEnum.Q6H:
                    detailCount = 4;
                    break;
                case FrequencyEnum.Q8H:
                    detailCount = 3;
                    break;
                case FrequencyEnum.Q12H:
                    detailCount = 2;
                    break;
                case FrequencyEnum.Q24H:
                    detailCount = 1;
                    break;
                default:
                    throw new TTException(SystemMessage.GetMessage(616));
            }

            return detailCount;
        }

        public static double GetDetailTimePeriod(FrequencyEnum? pFrequency)
        {
            if (pFrequency.HasValue == false)
                throw new TTException(SystemMessage.GetMessage(615));
            FrequencyEnum Frequency = pFrequency.Value;
            double detailTimePeriod = 0;
            switch (Frequency)
            {
                case FrequencyEnum.Q1H:
                    detailTimePeriod = 1;
                    break;
                case FrequencyEnum.Q2H:
                    detailTimePeriod = 2;
                    break;
                case FrequencyEnum.Q3H:
                    detailTimePeriod = 3;
                    break;
                case FrequencyEnum.Q4H:
                    detailTimePeriod = 4;
                    break;
                case FrequencyEnum.Q6H:
                    detailTimePeriod = 6;
                    break;
                case FrequencyEnum.Q8H:
                    detailTimePeriod = 8;
                    break;
                case FrequencyEnum.Q12H:
                    detailTimePeriod = 12;
                    break;
                case FrequencyEnum.Q24H:
                    detailTimePeriod = 24;
                    break;
                default:
                    throw new TTException(SystemMessage.GetMessage(616));
            }

            return detailTimePeriod;
        }

        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Yatan_Hasta_Recetesi_Istek, TTRoleNames.Yatan_Hasta_Recetesi_Okuma)]
        public static bool GetDrugUsedType(DrugDefinition Drug)
        {
            bool drugType = true;
            if (Drug.Volume > Drug.Dose)
                drugType = false;
            //if (Drug is MagistralPreparationDefinition || Drug is MedicinalProductDefinition)
            //{
            //    drugType = true;
            //}
            //else
            //{
            //    if (Drug.NFC != null)
            //    {
            //        string nfc = string.Empty;
            //        if (Drug.NFC.ParentCode != null)
            //        {
            //            nfc = Drug.NFC.ParentCode.Code.ToString();
            //        }
            //        else
            //        {
            //            nfc = Drug.NFC.Code.ToString();
            //        }
            //        switch (nfc)
            //        {
            //            case "A":
            //                drugType = true;
            //                break;
            //            case "B":
            //                drugType = true;
            //                break;
            //            case "C":
            //                drugType = true;
            //                break;
            //            case "D":
            //                drugType = true;
            //                break;
            //            case "E":
            //                drugType = false;
            //                break;
            //            case "F":
            //                drugType = false;
            //                break;
            //            case "G":
            //                drugType = false;
            //                break;
            //            case "H":
            //                drugType = false;
            //                break;
            //            case "J":
            //                drugType = true;
            //                break;
            //            case "K":
            //                drugType = true;
            //                break;
            //            case "L":
            //                drugType = false;
            //                break;
            //            case "M":
            //                drugType = true;
            //                break;
            //            case "N":
            //                drugType = true;
            //                break;
            //            case "P":
            //                drugType = false;
            //                break;
            //            case "Q":
            //                drugType = false;
            //                break;
            //            case "R":
            //                drugType = true;
            //                break;
            //            case "S":
            //                drugType = false;
            //                break;
            //            case "T":
            //                drugType = false;
            //                break;
            //            case "V":
            //                drugType = false;
            //                break;
            //            case "W":
            //                drugType = true;
            //                break;
            //            case "X":
            //                drugType = true;
            //                break;
            //            case "Y":
            //                drugType = true;
            //                break;
            //            case "Z":
            //                drugType = true;
            //                break;
            //            default:
            //                throw new TTException(SystemMessage.GetMessage(617));
            //                //break;
            //        }
            //    }
            //    else
            //        throw new TTException(SystemMessage.GetMessage(617));
            //}
            return drugType;
        }

        public static bool GetContinueDrugOrder(Guid EpisodeObjectID, Guid MaterialObjectID, DateTime planStart)
        {
            bool continueOrder = true;
            BindingList<DrugOrderDetail.GetActiveDrugOrderDetailByMaterial_Class> myDrugOrders = DrugOrderDetail.GetActiveDrugOrderDetailByMaterial(EpisodeObjectID, MaterialObjectID);
            //BindingList<DrugOrder> myDrugOrders = DrugOrder.GetDrugOrderForPatientbyDrug(drugOrder.ObjectContext, drugOrder.Episode.ObjectID, drugOrder.Material.ObjectID);
            foreach (DrugOrderDetail.GetActiveDrugOrderDetailByMaterial_Class olddrugOrder in myDrugOrders)
            {
                if (olddrugOrder.OrderPlannedDate >= planStart)
                {
                    continueOrder = false;
                    break;
                }
            }

            //if (continueOrder == false)
            //{
            //    string result = "D"; // ShowBox.Show(ShowBoxTypeEnum.Message, "&Devam,&Vazgeç", "D,V", "Uyarı", "Devam Eden İlaç Uyarısı", "Bu ilaç daha önce order edilmiş ve devam eden uygulamaları var\r\nDevam Etmek İstiyor Musunuz?");
            //    if (result == "D")
            //    {
            //        continueOrder = true;
            //    }
            //}

            return continueOrder;
        }

        public static bool GetContinueDrugOrderNew(DrugOrder drugOrder, DateTime planStartTime)
        {
            if (drugOrder.DrugOrderDetails.Count(x => x.CurrentStateDef.Status == StateStatusEnum.Uncompleted && x.OrderPlannedDate >= planStartTime) > 0)
                return false;
            else
                return true;
        }


        public static Dictionary<string, double?> GetMaxDose(List<DrugOrderIntroductionDet> drugOrderIntroductionDetails)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                Dictionary<string, double?> overDoseDrugs = new Dictionary<string, double?>();
                foreach (DrugOrderIntroductionDet drugOrderIntroductionDet in drugOrderIntroductionDetails)
                {
                    bool maxDose = true;
                    double totaldose = 0;
                    double detailCount = drugOrderIntroductionDet.DetailCount; //DrugOrder.GetDetailCount(drugOrderIntroductionDet.Frequency);
                    totaldose = ((double)drugOrderIntroductionDet.DoseAmount * detailCount) / (double)drugOrderIntroductionDet.Day;
                    DrugDefinition drugDefinition = objectContext.GetObject<DrugDefinition>(drugOrderIntroductionDet.Material.ObjectID);
                    if (totaldose > drugDefinition.MaxDose)
                        overDoseDrugs.Add(drugDefinition.Name, drugDefinition.MaxDose);
                }

                return overDoseDrugs;
            }
        }

        public static bool GetMaxDose(DrugOrder drugOrder)
        {
            bool maxDose = true;
            double totaldose = 0;
            double detailCount = DrugOrder.GetDetailCount(drugOrder.Frequency);
            totaldose = ((double)drugOrder.DoseAmount * detailCount) / (double)drugOrder.Day;
            DrugDefinition drugDefinition = ((DrugDefinition)drugOrder.Material);
            if (totaldose > ((DrugDefinition)drugOrder.Material).MaxDose)
            {
                maxDose = false;
            }

            return maxDose;
        }

        public static Dictionary<string, double?> GetMaxDoseDay(List<DrugOrderIntroductionDet> drugOrderIntroductionDetails)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                Dictionary<string, double?> overMaxDoseDay = new Dictionary<string, double?>();
                foreach (DrugOrderIntroductionDet drugOrderIntroductionDet in drugOrderIntroductionDetails)
                {
                    bool maxDoseDay = true;
                    DrugDefinition drugDefinition = objectContext.GetObject<DrugDefinition>(drugOrderIntroductionDet.Material.ObjectID);
                    if (drugOrderIntroductionDet.Day > drugDefinition.MaxDoseDay)
                        overMaxDoseDay.Add(drugDefinition.Name, drugDefinition.MaxDoseDay);
                }
                return overMaxDoseDay;
            }
        }

        public static bool GetMaxDoseDay(DrugOrder drugOrder, double day)
        {
            bool maxDoseDay = true;
            DrugDefinition drugDefinition = ((DrugDefinition)drugOrder.Material);
            if (day > ((DrugDefinition)drugOrder.Material).MaxDoseDay)
            {
                maxDoseDay = false;
            }

            return maxDoseDay;
        }

        protected void UndoTransition_Completed2Planned()
        {
            #region PostTransition_Completed2Planned
            DrugOrder drugOrder = this;
            #endregion PostTransition_Completed2Planned
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DrugOrder).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DrugOrder.States.Completed && toState == DrugOrder.States.Planned)
                UndoTransition_Completed2Planned();
        }


        #endregion Methods
        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DrugOrder).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == DrugOrder.States.New && toState == DrugOrder.States.Planned)
                PostTransition_New2Planned();
            else if (fromState == DrugOrder.States.Stopped && toState == DrugOrder.States.Cancelled)
                PostTransition_Stopped2Cancelled();
            else if (fromState == DrugOrder.States.Stopped && toState == DrugOrder.States.Continued)
                PostTransition_Stopped2Continued();
            else if (fromState == DrugOrder.States.Continued && toState == DrugOrder.States.Stopped)
                PostTransition_Continued2Stopped();
            else if (fromState == DrugOrder.States.Planned && toState == DrugOrder.States.Stopped)
                PostTransition_Planned2Stopped();
            else if (fromState == DrugOrder.States.Planned && toState == DrugOrder.States.Cancelled)
                PostTransition_Planned2Cancelled();
            else if (fromState == DrugOrder.States.Approve && toState == DrugOrder.States.Planned)
                PostTransition_Approve2Planned();
            else if (fromState == DrugOrder.States.Approve && toState == DrugOrder.States.Cancelled)
                PostTransition_Approve2Cancelled();
            else if (fromState == DrugOrder.States.Completed && toState == DrugOrder.States.Cancelled)
                PostTransition_Completed2Cancelled();

        }
    }
}