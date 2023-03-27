
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
    /// Hemşirelik Hizmetlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class NursingApplication : EpisodeAction, IOAInPatientApplication, IWorkListEpisodeAction, ITreatmentMaterialCollection, IWorkListInpatient
    {
        protected override void PreInsert()
        {
#region PreInsert
            
            base.PreInsert();

#endregion PreInsert
        }

        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();

#endregion PostInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
            

            
            foreach (NursingOrderDetail nursingOrderDetail in NursingApplicationNursingOrderDetails)
            {
                if(nursingOrderDetail.CurrentStateDef.Status== StateStatusEnum.Uncompleted )
                {
                    nursingOrderDetail.SecondaryMasterResource=SecondaryMasterResource;
                }
            }
#endregion PostUpdate
        }

         protected void PostTransition_Application2PreDischarged()
        {
            // From State : Application   To State : PreDischarged
            #region PostTransition_Application2PreDischarged
            //CheckDrugOrders(); Burada  iade gerektirmeyenleri iptal eden bir kod olmalı
            #endregion PostTransition_Application2PreDischarged
        }

        protected void UndoTransition_Application2PreDischarged(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Application   To State : PreDischarged
            #region UndoTransition_Application2PreDischarged  

            #endregion UndoTransition_Application2PreDischarged
        }


        protected void PostTransition_Application2Discharged()
        {
            // From State : Application  To State : Discharged
            #region PostTransition_Application2Discharged
            CheckDrugOrders();
            DischargeInPatientPhysicianApplicationForEmergencyIntervention();

            #endregion PostTransition_Application2Discharged
        }

        protected void UndoTransition_Application2Discharged(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Application   To State : Discharged
            #region PreTransition_Application2Discharged
            UndoInPatientPhysicianApplicationForEmergencyIntervation();
            #endregion PreTransition_Application2Discharged
        }


        protected void PostTransition_PreDischarged2Discharged()
        {
            // From State : PreDischarged   To State : Discharged
#region PostTransition_PreDischarged2Discharged
            // Aslında Acilden başlamış hemşireliğin bu statede olma ihtimali yok
#endregion PostTransition_PreDischarged2Discharged
        }

        protected void UndoTransition_PreDischarged2Discharged(TTObjectStateTransitionDef transitionDef)
        {
            // From State : PreDischarged   To State : Discharged
            #region UndoTransition_PreDischarged2Discharged

            #endregion UndoTransition_PreDischarged2Discharged
        }



        protected void PostTransition_PreDischarged2Cancelled()
        {
            // From State : PreDischarged   To State : Cancelled
#region PostTransition_PreDischarged2Cancelled
            Cancel();
#endregion PostTransition_PreDischarged2Cancelled
        }

        protected void UndoTransition_PreDischarged2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : PreDischarged   To State : Cancelled
#region UndoTransition_PreDischarged2Cancelled
            UndoCancel();
#endregion UndoTransition_PreDischarged2Cancelled
        }

        protected void PostTransition_Application2Cancelled()
        {
            // From State : Application   To State : Cancelled
#region PostTransition_Application2Cancelled
            Cancel();
#endregion PostTransition_Application2Cancelled
        }

        protected void UndoTransition_Application2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Application   To State : Cancelled
#region UndoTransition_Application2Cancelled
            UndoCancel();
#endregion UndoTransition_Application2Cancelled
        }

        protected void PostTransition_Discharged2Cancelled()
        {
            // From State : Discharged   To State : Cancelled
            #region PostTransition_Discharged2Cancelled
            Cancel();
            #endregion PostTransition_Discharged2Cancelled
        }


        protected void UndoTransition_Discharged2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Discharged   To State : Cancelled
            #region UndoTransition_Discharged2Cancelled
            UndoCancel();
            #endregion UndoTransition_Discharged2Cancelled
        }


        #region Methods
        public NursingApplication(InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication) : this(inPatientTreatmentClinicApplication.ObjectContext)
        {
            SetMandatoryEpisodeActionProperties((EpisodeAction)inPatientTreatmentClinicApplication,inPatientTreatmentClinicApplication.MasterResource,inPatientTreatmentClinicApplication.FromResource,true);
            CurrentStateDefID = NursingApplication.States.Application;
            InPatientTreatmentClinicApp=inPatientTreatmentClinicApplication;
            ProcedureSpeciality=inPatientTreatmentClinicApplication.ProcedureSpeciality;
            SecondaryMasterResource=inPatientTreatmentClinicApplication.BaseInpatientAdmission.RoomGroup;
        }
        public NursingApplication(EmergencyIntervention emergencyIntervention ) : this(emergencyIntervention .ObjectContext)
        {
            SetMandatoryEpisodeActionProperties((EpisodeAction)emergencyIntervention,emergencyIntervention.MasterResource,emergencyIntervention.MasterResource,true);
            CurrentStateDefID = NursingApplication.States.Application;
            EmergencyIntervention=emergencyIntervention;
            ProcedureSpeciality=emergencyIntervention.ProcedureSpeciality;
            SecondaryMasterResource=MasterResource;
            DescriptionForWorkList = emergencyIntervention.DescriptionForWorkList;
        }


        public void UndoInPatientPhysicianApplicationForEmergencyIntervation()
        {
            if (EmergencyIntervention != null)
            {
                foreach (InPatientPhysicianApplication inPatientPhysicianApplication in EmergencyIntervention.InPatientPhysicianApplications)
                {
                    if (inPatientPhysicianApplication.CurrentStateDefID == InPatientPhysicianApplication.States.Discharged)
                    {
                        ((ITTObject)inPatientPhysicianApplication).UndoLastTransition();
                    }
                }
            }
        }
        public void DischargeInPatientPhysicianApplicationForEmergencyIntervention()
        {
            if (EmergencyIntervention != null)
            {
                foreach (InPatientPhysicianApplication inPatientPhysicianApplication in EmergencyIntervention.InPatientPhysicianApplications)
                {
                    if (inPatientPhysicianApplication.CurrentStateDefID == InPatientPhysicianApplication.States.Application)
                    {
                        inPatientPhysicianApplication.CurrentStateDefID = InPatientPhysicianApplication.States.Discharged;
                    }
                }
                //Zaten kliniğe kabul edilemden bu işlem fire olmamamış olmalı. Complete ise bu işlem step back yapılmış demektir
                if (EmergencyIntervention.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                {
                    EmergencyIntervention.CurrentStateDefID = EmergencyIntervention.States.Completed;
                }
            }
        }



        protected void CheckDrugOrders()
        {
            bool isInpatientAndIntensiveCareAfterSurgery = false;
            if (Episode.PatientStatus == PatientStatusEnum.Inpatient || Episode.PatientStatus == PatientStatusEnum.PreDischarge)
            {
                if (InPatientTreatmentClinicApp != null && InPatientTreatmentClinicApp.BaseInpatientAdmission is IntensiveCareAfterSurgery)
                    isInpatientAndIntensiveCareAfterSurgery = true;
            }
            if (!isInpatientAndIntensiveCareAfterSurgery)
            {
                bool resDose = false;
                IList allDrugOrderTransaction = DrugOrderTransaction.GetDrugOrderTransactionByEpisode(ObjectContext, Episode.ObjectID);

                foreach (DrugOrderTransaction drugOrderTransaction in allDrugOrderTransaction)
                {
                    double rest = DrugOrderTransaction.GetRestDose(drugOrderTransaction.DrugOrder);
                    DrugDefinition drugDefinition = (DrugDefinition)drugOrderTransaction.DrugOrder.Material;
                    bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);

                    if (drugType)
                    {
                        if (rest > 0)
                        {
                            resDose = true;
                        }
                    }
                    else
                    {
                        if (rest >= drugDefinition.Volume)
                        {
                            resDose = true;
                        }
                        else
                        {
                            DrugOrder restDrugOrder = drugOrderTransaction.DrugOrder;
                            DrugDoseCompletion drugDoseCompletion = new DrugDoseCompletion(restDrugOrder.ObjectContext);
                            drugDoseCompletion.MasterResource = MasterResource;
                            drugDoseCompletion.FromResource = FromResource;
                            drugDoseCompletion.Episode = Episode;
                            drugDoseCompletion.SecondaryMasterResource = SecondaryMasterResource;
                            DrugDoseCompletionDetail drugDoseCompletionDetail = new DrugDoseCompletionDetail(restDrugOrder.ObjectContext);
                            drugDoseCompletionDetail.ActionDate = DateTime.Today;
                            drugDoseCompletionDetail.Amount = rest;
                            drugDoseCompletionDetail.Day = restDrugOrder.Day;
                            drugDoseCompletionDetail.DoseAmount = rest;
                            drugDoseCompletionDetail.DrugDone = true;
                            drugDoseCompletionDetail.DrugOrder = restDrugOrder;
                            drugDoseCompletionDetail.Episode = restDrugOrder.Episode;
                            drugDoseCompletionDetail.Frequency = restDrugOrder.Frequency;
                            drugDoseCompletionDetail.FromResource = FromResource;
                            drugDoseCompletionDetail.MasterResource = MasterResource;
                            drugDoseCompletionDetail.Material = restDrugOrder.Material;
                            drugDoseCompletionDetail.OrderPlannedDate = DateTime.Today;
                            drugDoseCompletionDetail.PackageQuantity = 1;
                            drugDoseCompletionDetail.SecondaryMasterResource = restDrugOrder.SecondaryMasterResource;
                            drugDoseCompletionDetail.UsageNote = restDrugOrder.UsageNote;
                            drugDoseCompletionDetail.DrugDoseCompletion = drugDoseCompletion;
                            drugDoseCompletion.CurrentStateDefID = new Guid(DrugDoseCompletion.States.New.ToString());
                            drugDoseCompletionDetail.CurrentStateDefID = new Guid(DrugDoseCompletionDetail.States.Planned.ToString());

                            DrugOrderTransaction dOrderTransaction = new DrugOrderTransaction(restDrugOrder.ObjectContext);
                            dOrderTransaction.DrugOrder = drugDoseCompletionDetail.DrugOrder;
                           /* dOrderTransaction.DrugOrderDetail = drugDoseCompletionDetail;
                            dOrderTransaction.Amount = 1;
                            dOrderTransaction.InOut = 2;
                            dOrderTransaction.Volume = rest;*/

                            foreach (DrugOrderDetail restDrugOrderDetail in restDrugOrder.DrugOrderDetails)
                            {
                                if (restDrugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Supply)
                                {
                                    restDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Apply;
                                }
                            }

                        }
                    }
                }
                if (resDose)
                {
                    throw new Exception(SystemMessage.GetMessage(1032));
                }

                foreach (DrugOrderDetail drugOrderDetail in DrugOrderDetails)
                {
                    bool drugType = DrugOrder.GetDrugUsedType(((DrugDefinition)drugOrderDetail.Material));
                    if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.ExPharmacySupply || drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.PharmacologyRequest || drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Planned || drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Request || drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Supply || drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.UseRestDose)
                    {
                        if ((bool)drugOrderDetail.Eligible && drugType == false)
                        {
                            if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Request)
                            {
                                drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
                            }
                            else
                            {
                                drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Apply;
                            }
                        }
                        else
                        {
                            drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
                        }
                    }

                }


            }
        }
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.NursingApplication;
            }
        }
        private bool _undoByMasterAction = false;
        public bool UndoByMasterAction
        {
            get
            {
                return _undoByMasterAction;
            }
            set
            {
                _undoByMasterAction = value;
            }
        }

        public void CheckUndo()
        {
            if (!UndoByMasterAction)
            {
                string msg = "Hemşirelik İşlemleri tek başına geri alınamaz ";
                throw new Exception(msg);
            }
        }

        private bool _cancelledByMasterAction = false;
        public  bool CancelledByMasterAction
        {
            get
            {
                return _cancelledByMasterAction;
            }
            set
            {
                _cancelledByMasterAction=value;
            }
        }
        public override void Cancel()
        {
            if (CancelledByMasterAction)
                base.Cancel();
            else
            {
                string msg="Hemşirelik İşlemleri tek başına iptal edilemez. ";
                string treatClinic = "";
                if( EmergencyIntervention != null)
                    msg += EmergencyIntervention.ID + TTUtils.CultureService.GetText("M26184", "işlem nolu 'Acil Müdahale'");
                else if (InPatientTreatmentClinicApp != null)
                {
                    treatClinic = "'Klinik İşlemleri',";
                    if(InPatientTreatmentClinicApp!=null)
                        msg += InPatientTreatmentClinicApp.ID + " nolu işlem ";
                }
                msg += " iptal edildiğinde ona bağlı " + treatClinic + " 'Hemşirelik İşlemleri' ve 'Klinik Doktor' işlemleri otomatik olarak iptal edilir.";
                throw new Exception(msg);
            }
        }
        
        public override void UndoCancel()
        {
            NoBackStateBack();
        }

        
      
        
        public override Resource SpecialResourceForStore()
        {
            if(TTObjectClasses.SystemParameter.GetParameterValue("UseSecMasterResourceAsSpecialResourceForStore", "TRUE") == "FALSE") // Hastanın tedavi gördüğü birim
            {
                Resource tgb= null;
                if(InPatientTreatmentClinicApp != null)
                {
                    return InPatientTreatmentClinicApp.MasterResource;
                }
            }
            return SecondaryMasterResource == null ? MasterResource : SecondaryMasterResource ;
        }

        public override string GetTreatmentMaterialListFilter(TTObjectDef treatmentMaterialDef)
        {
            // set edilen depoya göre Malzeme listesinin filtrelenmesi
            string filterString = "";
            if (EmergencyIntervention == null)// HARİCİ YERLERDE  DRUG GELMEZ
                filterString = " THIS.OBJECTDEFNAME IN ('CONSUMABLEMATERIALDEFINITION','DRUGDEFINITION') ";
            else
                filterString = " THIS.OBJECTDEFNAME IN ('CONSUMABLEMATERIALDEFINITION','DRUGDEFINITION') ";


            if (!(TTObjectClasses.SystemParameter.GetParameterValue("WORKWITHOUTSTOCK", "FALSE") == "TRUE"))// Böyle Çalışmasının sebebi True haricince ne yazılırsa yazılsın aşağıdaki kodun çalışmasının istenmesi
            {
                Store store = GetStore(treatmentMaterialDef);
                if (store == null)
                {
                    filterString = "OBJECTID is null";
                }
                else
                {
                    filterString = filterString + " AND STOCKS.INHELD>0 AND STOCKS.STORE = '" + store.ObjectID.ToString() + "'";
                }
            }

            return filterString;

        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(NursingApplication).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            //if (fromState == States.PreDischarged && toState == States.Discharged)
            //    PreTransition_PreDischarged2Discharged();
            //else if (fromState == States.Application && toState == States.Discharged)
            //    PreTransition_Application2Discharged();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(NursingApplication).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == NursingApplication.States.Discharged && toState == NursingApplication.States.Cancelled)
                PostTransition_Discharged2Cancelled();
            else if (fromState == NursingApplication.States.Application && toState == NursingApplication.States.PreDischarged)
                PostTransition_Application2PreDischarged();
            else if (fromState == NursingApplication.States.Application && toState == NursingApplication.States.Discharged)
                PostTransition_Application2Discharged();
            else if (fromState == NursingApplication.States.PreDischarged && toState == NursingApplication.States.Discharged)
                PostTransition_PreDischarged2Discharged();
            else if (fromState == NursingApplication.States.PreDischarged && toState == NursingApplication.States.Cancelled)
                PostTransition_PreDischarged2Cancelled();
            else if (fromState == NursingApplication.States.Application && toState == NursingApplication.States.Cancelled)
                PostTransition_Application2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(NursingApplication).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (EmergencyIntervention == null) // aciller haricinde 
                CheckUndo();
            if (fromState == NursingApplication.States.Discharged && toState == NursingApplication.States.Cancelled)
                UndoTransition_Discharged2Cancelled(transDef);
            else if (fromState == NursingApplication.States.Application && toState == NursingApplication.States.PreDischarged)
                UndoTransition_Application2PreDischarged(transDef);
            else if (fromState == NursingApplication.States.PreDischarged && toState == NursingApplication.States.Discharged)
                UndoTransition_PreDischarged2Discharged(transDef);
            else if (fromState == NursingApplication.States.Application && toState == NursingApplication.States.Discharged)
                UndoTransition_Application2Discharged(transDef);
            else if (fromState == NursingApplication.States.PreDischarged && toState == NursingApplication.States.Cancelled)
                UndoTransition_PreDischarged2Cancelled(transDef);
            else if (fromState == NursingApplication.States.Application && toState == NursingApplication.States.Cancelled)
                UndoTransition_Application2Cancelled(transDef);
        }

    }
}