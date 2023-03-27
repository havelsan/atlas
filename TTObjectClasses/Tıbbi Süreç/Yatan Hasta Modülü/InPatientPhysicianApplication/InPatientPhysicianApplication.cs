
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
    /// Klinik Doktor Ýþlemleri
    /// </summary>
    public partial class InPatientPhysicianApplication : PhysicianApplication, IOAInPatientApplication, IWorkListEpisodeAction, IAllocateSpeciality, IWorkListInpatient
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "EMERGENCYINTERVENTION":
                    {
                        EmergencyIntervention value = (EmergencyIntervention)newValue;
                        #region EMERGENCYINTERVENTION_SetParentScript
                        if (value != null)
                        {
                            ProcedureDoctor = value.ResponsibleDoctor;

                            //Allocation kapatýldý
                            //bool addNewAuthorizedUser=true;
                            //if (value.ResponsibleDoctor!=null)
                            //{
                            //    if (this.AuthorizedUsers.Count>0)
                            //    {
                            //        foreach(AuthorizedUser authorizedUser in this.AuthorizedUsers)
                            //        {
                            //            if(authorizedUser.User.ObjectID==value.ResponsibleDoctor.ObjectID)
                            //            {
                            //                authorizedUser.User=value.ResponsibleDoctor;
                            //                addNewAuthorizedUser=false;
                            //                break;
                            //            }
                            //        }

                            //    }
                            //    if(addNewAuthorizedUser)
                            //    {
                            //        AuthorizedUser newAuthorizedUser = new AuthorizedUser(this.ObjectContext);
                            //        newAuthorizedUser.User=(ResUser)value.ResponsibleDoctor;
                            //        this.AuthorizedUsers.Add(newAuthorizedUser);

                            //    }
                            //}


                        }
                        #endregion EMERGENCYINTERVENTION_SetParentScript
                    }
                    break;
                case "INPATIENTTREATMENTCLINICAPP":
                    {
                        InPatientTreatmentClinicApplication value = (InPatientTreatmentClinicApplication)newValue;
                        #region INPATIENTTREATMENTCLINICAPP_SetParentScript
                        if (value != null)
                        {
                            ProcedureDoctor = value.ProcedureDoctor;

                            //bool addNewAuthorizedUser=true;
                            //if (value.ProcedureDoctor != null)
                            //{
                            //    if (this.AuthorizedUsers.Count>0)
                            //    {
                            //        foreach(AuthorizedUser authorizedUser in this.AuthorizedUsers)
                            //        {
                            //            if(authorizedUser.User.ObjectID==value.ProcedureDoctor.ObjectID)
                            //            {
                            //                authorizedUser.User=value.ProcedureDoctor;
                            //                addNewAuthorizedUser=false;
                            //                break;
                            //            }
                            //        }

                            //    }
                            //    if(addNewAuthorizedUser)
                            //    {
                            //        AuthorizedUser newAuthorizedUser = new AuthorizedUser(this.ObjectContext);
                            //        newAuthorizedUser.User=(ResUser)value.ProcedureDoctor;
                            //        this.AuthorizedUsers.Add(newAuthorizedUser);

                            //    }
                            //}

                        }
                        #endregion INPATIENTTREATMENTCLINICAPP_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        #region IAllocateSpeciality Members
        public Episode GetEpisode()
        {
            return Episode;
        }

        public void SetEpisode(Episode value)
        {
            Episode = value;
        }

        public EpisodeAction GetMyEpisodeAction()
        {
            return MyEpisodeAction;
        }

        public void SetMyEpisodeAction(EpisodeAction value)
        {
            MyEpisodeAction = value;
        }

        public SubActionProcedure GetMySubActionProcedure()
        {
            return MySubActionProcedure;
        }

        public void SetMySubActionProcedure(SubActionProcedure value)
        {
            MySubActionProcedure = value;
        }

        public SpecialityDefinition GetProcedureSpeciality()
        {
            return ProcedureSpeciality;
        }

        public void SetProcedureSpeciality(SpecialityDefinition value)
        {
            ProcedureSpeciality = value;
        }

        #endregion

        /// <summary>
        /// Adli muayene olup olmadýðýný döndürü
        /// </summary>
        public bool IsForensicMedicalExam
        {
            get
            {
                try
                {
                    #region IsForensicMedicalExam_GetScript    
                    //todo bg
                    /*                
                    if (this.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.JudicialMedicineAdmission )
                        return true;*/
                    return false;
                    #endregion IsForensicMedicalExam_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "IsForensicMedicalExam") + " : " + ex.Message, ex);
                }
            }
        }


        /// <summary>
        /// yeþil Alan muayene olup olmadýðýný döndürü
        /// </summary>
        public bool IsGreenAreaExamination
        {
            get
            {
                try
                {
                    #region IsGreenAreaExamination_GetScript                    
                    if (EmergencyIntervention != null)
                        return EmergencyIntervention.IsGreenAreaExamination;

                    return false;
                    #endregion IsGreenAreaExamination_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "IsGreenAreaExamination") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();
            if(InPatientTreatmentClinicApp != null)
                ArrangePandemicProcedureForFirstDay();

            #endregion PostUpdate
        }

        // Yatýþýn yapýldýðý ilk gün içinde IsPandemic deðeri deðiþirse PandemicProcedure oluþturur veya iptal eder 
        public void ArrangePandemicProcedureForFirstDay()
        {
            BedProcedure bedProcedure = null;
            DateTime today = Common.RecTime().Date;

            foreach (BaseBedProcedure baseBedProcedure in InPatientTreatmentClinicApp.BaseBedProcedures.Where(x => !x.IsCancelled && x.BedInPatientDate.HasValue && x.BedInPatientDate.Value.Date.Equals(today)))
                bedProcedure = baseBedProcedure.BedProcedures.FirstOrDefault(x => !x.IsCancelled && x.PricingDate.Value.Date.Equals(today));

            if (bedProcedure != null) // Yatýþýn yapýldýðý gün için oluþan BedProcedure
            {
                PandemicProcedure pandemicProcedure = bedProcedure.ChildSubActionProcedure.FirstOrDefault(x => !x.IsCancelled && x is PandemicProcedure) as PandemicProcedure;

                if (IsPandemic == YesNoEnum.Yes)
                {
                    if (pandemicProcedure == null)
                        bedProcedure.CreatePandemicProcedure();
                }
                else
                {   // Yoðun bakým ise ilk gün için oluþturulan PandemicProcedure iptal edilmemeli.
                    if (pandemicProcedure != null && bedProcedure.BaseBedProcedure.Bed.Room.RoomGroup.Ward.IsIntensiveCare != true) 
                        ((ITTObject)pandemicProcedure).Cancel();
                }
            }
        }

        protected void PostTransition_Application2PreDischarged()
        {
            // From State : Application   To State : PreDischarged
            #region PostTransition_Application2PreDischarged

            if (IsOldAction != true)
            {
                if (Episode.SecDiagnosis.Count == 0)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25926", "Herhangi bir kesin taný  girmeden taburcu iþlemi yapamazsýnýz!"));
            }

            CancelOrders(true);
            ControlGreenAreaExamination();
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
            // From State : Application   To State : Discharged
            #region PostTransition_Application2Discharged

            // EmergencyIntervationda direk Application2Dischage olabilir 
            if (Episode.SecDiagnosis.Count == 0)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25927", "Herhangi bir taný kesin  girmeden taburcu iþlemi yapamazsýnýz!"));
            if (EmergencyIntervention != null)
            {
                CancelOrders(false);
                DischargeNursingApplicationForEmergencyIntervention();
                ControlGreenAreaExamination();//MUSTAFA_SOR
            }

            #endregion PostTransition_Application2Discharged
        }

        protected void UndoTransition_Application2Discharged(TTObjectStateTransitionDef transitionDef)
        {

            // From State : Application   To State : Discharged
            #region UndoTransition_Application2Discharged  
            // EmergencyIntervationda direk Application2Dischage olabilir 
            UndoNursingApplicationAsApplicationForEmergencyIntervation();
            #endregion UndoTransition_Application2Discharged
        }


        protected void PostTransition_PreDischarged2Discharged()
        {
            // From State : Application   To State : Discharged
            #region PostTransition_PreDischarged2Discharged
            if (IsOldAction != true)
            {
                if (Episode.SecDiagnosis.Count == 0)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25927", "Herhangi bir taný kesin  girmeden taburcu iþlemi yapamazsýnýz!"));
            }

            CancelOrders(false);
            ControlGreenAreaExamination();
            CheckHealthCommittee();
            #endregion PostTransition_PreDischarged2Discharged
        }

        protected void UndoTransition_PreDischarged2Discharged(TTObjectStateTransitionDef transitionDef)
        {
            // From State : PreDischarged   To State : Discharged
            #region UndoTransition_PreDischarged2Discharged  

            #endregion UndoTransition_PreDischarged2Discharged
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

        public static InPatientPhysicianApplication GetActiveInPatientPhysicianApplication(Guid episodeID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var physicianApps = InPatientPhysicianApplication.GetActiveInpatientPhAppByEpisode(objectContext, episodeID);

                if (physicianApps.Count > 0)
                {
                    return physicianApps[0];
                }

            }
            return null;
        }
        #region Methods


        public override void CreateSpecialityBasedObject() // Uzmanlýk için  Yatan için  
        {
            if (MasterResource is ResWard)
            {
                ResWard resClinic = MasterResource as ResWard;
                if (resClinic.IsIntensiveCare == true)
                {
                    SpecialityBasedObject specialityBasedObject = null;
                    //if (SubEpisode.PatientAdmission.IsNewBorn == true)//Yenidoðan Kabulü ise yenidoðan uzmanlýðý açýlacak
                    //{
                    //    specialityBasedObject = new NewBornIntensiveCare(this);
                    //}
                    //else
                    //{
                    specialityBasedObject = new IntensiveCareSpecialityObj(this);
                    //}

                    if (specialityBasedObject != null)
                    {
                        specialityBasedObject.PhysicianApplication = this;
                    }
                }
            }

            //ilk acil kabulü alýnýrken oluþturulan uzmanlýk iþlemi Klinik doktor iþlemlerine taþýnýyor
            if (EmergencyIntervention != null && MasterAction is EmergencyIntervention && ((EmergencyIntervention)MasterAction).PatientExaminations.Count > 0
                && ((EmergencyIntervention)MasterAction).PatientExaminations[0] is PatientExamination)//Acilden müþahedeye al
            {
                foreach (var specialityBasedObject in ((EmergencyIntervention)MasterAction).PatientExaminations[0].SpecialityBasedObject)
                {
                    specialityBasedObject.OldPhysicianApplication = specialityBasedObject.PhysicianApplication;
                    specialityBasedObject.PhysicianApplication = this;
                    break;
                    //this.SpecialityBasedObject
                }

            }
        }

        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.InPatientPhysicianApplication;
            }
        }



        public InPatientPhysicianApplication(InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication) : this(inPatientTreatmentClinicApplication.ObjectContext)
        {
            SetMandatoryEpisodeActionProperties((EpisodeAction)inPatientTreatmentClinicApplication, inPatientTreatmentClinicApplication.MasterResource, inPatientTreatmentClinicApplication.FromResource, true);
            SecondaryMasterResource = inPatientTreatmentClinicApplication.BaseInpatientAdmission.RoomGroup;
            CurrentStateDefID = InPatientPhysicianApplication.States.Application;
            InPatientTreatmentClinicApp = inPatientTreatmentClinicApplication;
            ProcedureSpeciality = inPatientTreatmentClinicApplication.ProcedureSpeciality;

        }

        public InPatientPhysicianApplication(EmergencyIntervention emergencyIntervention) : this(emergencyIntervention.ObjectContext)
        {
            SetMandatoryEpisodeActionProperties((EpisodeAction)emergencyIntervention, emergencyIntervention.MasterResource, emergencyIntervention.MasterResource, true);
            CurrentStateDefID = InPatientPhysicianApplication.States.Application;
            EmergencyIntervention = emergencyIntervention;
            ProcedureSpeciality = emergencyIntervention.ProcedureSpeciality;
            DescriptionForWorkList = emergencyIntervention.DescriptionForWorkList;
            ActionDate = Common.RecTime();
        }

        public bool CancelOrders(Boolean IsPreDischarge)//#TABURCULUK Taburcu tarihinden sonra Girilmiþ Hizmet ve Orderlarý iptal etmek için 
        {
            bool cancelled = false;
            DateTime? DischargeDate = null;
            if (IsPreDischarge)
            {
                if (InPatientTreatmentClinicApp != null && InPatientTreatmentClinicApp.ClinicDischargeDate != null)
                    DischargeDate = InPatientTreatmentClinicApp.ClinicDischargeDate.Value.Date;
            }
            if (DischargeDate != null) // PreDischarge'da Yanlýz taburcu tarihinden sonra olan uygulanmayanlar Discharge'da tüm uygulanmayanlar cancel edilir
            {
                foreach (DrugOrder drugOrder in DrugOrders)
                {
                    if (drugOrder.IsTransfered != true)
                    {
                        foreach (DrugOrderDetail drugOrderDetail in drugOrder.DrugOrderDetails.Where(drd => drd.OrderPlannedDate.Value.Date > DischargeDate
                                                                            && drd.CurrentStateDef.Status == StateStatusEnum.Uncompleted))
                        {
                            ((ITTObject)drugOrderDetail).Cancel();
                            cancelled = true;
                        }
                    }
                }

                foreach (NursingOrder nursingOrder in NursingOrders)
                {
                    foreach (NursingOrderDetail nursingOrderDetail in nursingOrder.OrderDetails.Where(drd => drd.WorkListDate.Value.Date > DischargeDate && drd.CurrentStateDefID == NursingOrderDetail.States.Execution))
                    {
                        nursingOrderDetail.ExtraDescription += "Taburcu Edilirken iptal edildi";
                        ((ITTObject)nursingOrderDetail).Cancel();
                        cancelled = true;
                    }
                }

                foreach (DietOrder dietOrder in DietOrders)
                {
                    foreach (DietOrderDetail dietOrderDetail in dietOrder.OrderDetails.Where(drd => drd.WorkListDate.Value.Date > DischargeDate && (drd.CurrentStateDefID == DietOrderDetail.States.Execution || drd.CurrentStateDefID == DietOrderDetail.States.Approval)))
                    {

                        dietOrderDetail.ExtraDescription += "Taburcu Edilirken iptal edildi";
                        ((ITTObject)dietOrderDetail).Cancel();
                        cancelled = true;
                    }
                }

                var uncompletedRequest = Episode.PhysiotherapyRequests.Where(c => c.MasterAction == this && c.CurrentStateDef.Status == StateStatusEnum.Uncompleted);
                if (uncompletedRequest.Count() == 1)
                {
                    uncompletedRequest.FirstOrDefault().CompleteRequestByDate(DischargeDate.Value);
                }
            }
            else
            {
                foreach (DrugOrder drugOrder in DrugOrders)
                {
                    foreach (DrugOrderDetail drugOrderDetail in drugOrder.DrugOrderDetails.Where(drd => drd.DrugOrder.IsTransfered != true && drd.CurrentStateDef.Status == StateStatusEnum.Uncompleted))
                    {
                        ((ITTObject)drugOrderDetail).Cancel();
                        cancelled = true;
                    }
                }

                foreach (NursingOrder nursingOrder in NursingOrders)
                {
                    foreach (NursingOrderDetail nursingOrderDetail in nursingOrder.OrderDetails.Where(drd => drd.CurrentStateDefID == NursingOrderDetail.States.Execution))
                    {
                        nursingOrderDetail.ExtraDescription += "Taburcu Edilirken iptal edildi";
                        ((ITTObject)nursingOrderDetail).Cancel();
                        cancelled = true;
                    }
                }

                foreach (DietOrder dietOrder in DietOrders)
                {
                    foreach (DietOrderDetail dietOrderDetail in dietOrder.OrderDetails.Where(drd => drd.CurrentStateDefID == DietOrderDetail.States.Execution || drd.CurrentStateDefID == DietOrderDetail.States.Approval))
                    {

                        dietOrderDetail.ExtraDescription += "Taburcu Edilirken iptal edildi";
                        ((ITTObject)dietOrderDetail).Cancel();
                        cancelled = true;
                    }
                }

                var uncompletedRequest = Episode.PhysiotherapyRequests.Where(c => c.MasterAction == this && c.CurrentStateDef.Status == StateStatusEnum.Uncompleted);
                if (uncompletedRequest.Count() == 1)
                {
                    uncompletedRequest.FirstOrDefault().CompleteRequest();
                }
            }


            return cancelled;
        }

        public void DischargeNursingApplicationForEmergencyIntervention()
        {
            if (EmergencyIntervention != null)
            {
                foreach (NursingApplication nursingApplication in EmergencyIntervention.NursingApplications)
                {
                    if (nursingApplication.CurrentStateDefID == NursingApplication.States.Application)
                    {
                        nursingApplication.CurrentStateDefID = NursingApplication.States.Discharged;
                    }
                }
            }
        }

        public void UndoNursingApplicationAsApplicationForEmergencyIntervation()
        {
            if (EmergencyIntervention != null)
            {
                foreach (NursingApplication nursingApplication in EmergencyIntervention.NursingApplications)
                {
                    if (nursingApplication.CurrentStateDefID == NursingApplication.States.Discharged)
                    {
                        ((ITTObject)nursingApplication).UndoLastTransition();
                    }
                }
            }
        }


        public override CreatingEpicrisis MyEpicrisisReport()
        {

            TTObjectContext context = new TTObjectContext(true);
            BindingList<TTObjectClasses.CreatingEpicrisis> epicrisisList = TTObjectClasses.CreatingEpicrisis.GetEpicrisisByMasterAction(context, ObjectID);
            foreach (TTObjectClasses.CreatingEpicrisis epicrisis in epicrisisList)
            {
                if ((!epicrisis.IsCancelled) && epicrisis.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully)
                    return epicrisis;
            }
            return null;
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
                string msg = "Klinik Doktor Ýþlemleri tek baþýna geri alýnamaz ";
                throw new Exception(msg);
            }
        }

        private bool _cancelledByMasterAction = false;
        public bool CancelledByMasterAction
        {
            get
            {
                return _cancelledByMasterAction;
            }
            set
            {
                _cancelledByMasterAction = value;
            }
        }


        public override void Cancel()
        {
            if (!CancelledByMasterAction)
            {
                string msg = "Klinik Doktor Ýþlemleri tek baþýna iptal edilemez. ";
                string treatClinic = "";
                if (EmergencyIntervention != null)
                    msg += EmergencyIntervention.ID + TTUtils.CultureService.GetText("M26184", "iþlem nolu 'Acil Müdahale'");
                else if (InPatientTreatmentClinicApp != null)
                {
                    treatClinic = "'Klinik Ýþlemleri',";
                    if (InPatientTreatmentClinicApp != null)
                        msg += InPatientTreatmentClinicApp.ID + " nolu iþlem ";
                }
                msg += " iptal edildiðinde ona baðlý " + treatClinic + " 'Hemþirelik Ýþlemleri' ve 'Klinik Doktor' iþlemleri otomatik olarak iptal edilir.";
                throw new Exception(msg);
            }
        }

        public override void UndoCancel()
        {
            NoBackStateBack();
        }



        public void ControlGreenAreaExamination()
        {
            if (EmergencyIntervention != null)
            {
                if (EmergencyIntervention.NotCreateExaminationProcedure() == true)
                    return;
                Guid emergencyExaminationGuid = ProcedureDefinition.EmergencyExaminationProcedureObjectId;
                Guid greenAreaExaminationGuid = ProcedureDefinition.GreenAreaExaminationProcedureObjectId;

                if (IsGreenAreaExamination == true)
                {
                    bool greenAreaExaminationExists = false;
                    foreach (EmergencyInterventionProcedure proc in EmergencyIntervention.EmergencyInterventionProcedures)
                    {
                        if (proc.ProcedureObject.ObjectID.Equals(emergencyExaminationGuid))
                            proc.CancelMyAccountTransactions();
                        else if (proc.ProcedureObject.ObjectID.Equals(greenAreaExaminationGuid))
                        {
                            foreach (AccountTransaction accTrx in proc.AccountTransactions)
                            {
                                if (accTrx.CurrentStateDefID == AccountTransaction.States.Cancelled)
                                    accTrx.CurrentStateDefID = AccountTransaction.States.New;
                            }
                            greenAreaExaminationExists = true;
                        }
                    }

                    if (!greenAreaExaminationExists)
                    {
                        EmergencyInterventionProcedure emergencyExaminationProcedure = new EmergencyInterventionProcedure(EmergencyIntervention, greenAreaExaminationGuid.ToString());
                        emergencyExaminationProcedure.AccountOperation(AccountOperationTimeEnum.PREPOST);
                    }
                    /* kpayi ---EmergencyIntervention.ControlAndAddMedulaPatientParticipation(); */
                }
                else
                {
                    bool emergencyExaminationExists = false;
                    foreach (EmergencyInterventionProcedure proc in EmergencyIntervention.EmergencyInterventionProcedures)
                    {
                        if (proc.ProcedureObject.ObjectID.Equals(greenAreaExaminationGuid))
                            proc.CancelMyAccountTransactions();
                        else if (proc.ProcedureObject.ObjectID.Equals(emergencyExaminationGuid))
                        {
                            foreach (AccountTransaction accTrx in proc.AccountTransactions)
                            {
                                if (accTrx.CurrentStateDefID == AccountTransaction.States.Cancelled)
                                    accTrx.CurrentStateDefID = AccountTransaction.States.New;
                            }
                            emergencyExaminationExists = true;
                        }
                    }

                    if (!emergencyExaminationExists)
                    {
                        EmergencyInterventionProcedure emergencyExaminationProcedure = new EmergencyInterventionProcedure(EmergencyIntervention, emergencyExaminationGuid.ToString());
                        emergencyExaminationProcedure.AccountOperation(AccountOperationTimeEnum.PREPOST);
                    }
                    /* kpayi--- EmergencyIntervention.CancelMedulaPatientParticipation();*/
                }
            }
        }

        public void CheckHealthCommittee()
        {
            if (InPatientTreatmentClinicApp != null && InPatientTreatmentClinicApp.TreatmentDischarge != null)
            {
                if (InPatientTreatmentClinicApp.TreatmentDischarge.GetMyDischargeTypeEnum() != DischargeTypeEnum.TransferToOtherClinic)
                {
                    foreach (HealthCommittee healthCommittee in Episode.HealthCommittees)
                    {
                        if (healthCommittee.CurrentStateDefID == HealthCommittee.States.CommitteeAcceptance)

                            throw new Exception(SystemMessage.GetMessage(718));
                    }

                }
            }
        }


        public override BaseAdditionalApplication CreateBaseAdditionalApplication()
        {
            return new InpatientPhysicianApplicationAdditionalApplication(ObjectContext);
        }

        //        protected override List<OldActionPropertyObject> OldActionPropertyList()
        //        {
        //            List<OldActionPropertyObject> propertyList;
        //            if(base.OldActionPropertyList()==null)
        //                propertyList = new List<OldActionPropertyObject>();
        //            else
        //                propertyList = base.OldActionPropertyList();
        //            propertyList.Add(new OldActionPropertyObject("Klinik Doktor Ýþlemleri Hasta Dosyasý",Common.ReturnObjectAsString(this.InPatientFolder)));
        //            return propertyList;
        //        }
        //
        //        protected override List<List<List<OldActionPropertyObject>>> OldActionChildRelationList()
        //        {
        //            List<List<List<OldActionPropertyObject>>> gridList;
        //            if(base.OldActionChildRelationList()==null)
        //                gridList=new List<List<List<OldActionPropertyObject>>>();
        //            else
        //                gridList=base.OldActionChildRelationList();
        //
        //            gridList.Add(this.OldActionPreDiagnosisList());
        //            gridList.Add(this.OldActionSecDiagnosisList());
        //            // Hasta Güncesi
        //            List<List<OldActionPropertyObject>> gridProgressRowList=new List<List<OldActionPropertyObject>>();
        //            foreach(InPatientPhysicianProgresses Progress in this.Progresses)
        //            {
        //                List<OldActionPropertyObject> gridProgressRowColumnList=new List<OldActionPropertyObject>();
        //                gridProgressRowColumnList.Add(new OldActionPropertyObject("Ýþlem Tarihi",Common.ReturnObjectAsString(Progress.ProgressDate)));
        //                gridProgressRowColumnList.Add(new OldActionPropertyObject("Hasta Güncesi",Common.ReturnObjectAsString(Progress.Description)));
        //                gridProgressRowList.Add(gridProgressRowColumnList);
        //            }
        //            gridList.Add(gridProgressRowList);
        //
        //            //Beslenme Diyet
        //            List<List<OldActionPropertyObject>> gridNutritionDietRowList=new List<List<OldActionPropertyObject>>();
        //            foreach(InPatientPhysicianApplicationNutritionDiet NutritionDiet in this.NutritionDiets)
        //            {
        //                List<OldActionPropertyObject> gridNutritionDietRowColumnList=new List<OldActionPropertyObject>();
        //                gridNutritionDietRowColumnList.Add(new OldActionPropertyObject("Ýþlem Tarihi",Common.ReturnObjectAsString(NutritionDiet.ActionDate)));
        //                gridNutritionDietRowColumnList.Add(new OldActionPropertyObject("Diyet Ýþlemi",Common.ReturnObjectAsString(NutritionDiet.ProcedureObject)));
        //                gridNutritionDietRowColumnList.Add(new OldActionPropertyObject("Yeme Yeri",Common.ReturnObjectAsString(NutritionDiet.Place)));
        //                gridNutritionDietRowColumnList.Add(new OldActionPropertyObject("Beslenme",Common.ReturnObjectAsString(NutritionDiet.Nutrition)));
        //                gridNutritionDietRowList.Add(gridNutritionDietRowColumnList);
        //            }
        //            gridList.Add(gridNutritionDietRowList);
        //            // Hemþire Takip Gözlem Talimatlarý
        //            List<List<OldActionPropertyObject>> gridNursingOrderRowList=new List<List<OldActionPropertyObject>>();
        //            foreach(NursingOrder NursingOrder in this.NursingOrders)
        //            {
        //                List<OldActionPropertyObject> gridNursingOrderRowColumnList=new List<OldActionPropertyObject>();
        //                gridNursingOrderRowColumnList.Add(new OldActionPropertyObject("Hemþire Takip Gözlem Talimatlarý",Common.ReturnObjectAsString(NursingOrder.ProcedureObject.Name)));
        //                gridNursingOrderRowColumnList.Add(new OldActionPropertyObject("Baþlama Zamaný",Common.ReturnObjectAsString(NursingOrder.PeriodStartTime)));
        //                gridNursingOrderRowColumnList.Add(new OldActionPropertyObject("Uygulama Aralýðý",Common.ReturnObjectAsString(NursingOrder.Frequency)));
        //                gridNursingOrderRowColumnList.Add(new OldActionPropertyObject("Uygulama Miktarý",Common.ReturnObjectAsString(NursingOrder.AmountForPeriod)));
        //                gridNursingOrderRowColumnList.Add(new OldActionPropertyObject("Gün",Common.ReturnObjectAsString(NursingOrder.RecurrenceDayAmount)));
        //                gridNursingOrderRowList.Add(gridNursingOrderRowColumnList);
        //            }
        //            gridList.Add(gridNursingOrderRowList);
        //
        //            // Ýlaç Direktifleri
        //            List<List<OldActionPropertyObject>> gridDrugOrderRowList=new List<List<OldActionPropertyObject>>();
        //            foreach(DrugOrder DrugOrder in this.DrugOrders)
        //            {
        //                List<OldActionPropertyObject> gridDrugOrderRowColumnList=new List<OldActionPropertyObject>();
        //                gridDrugOrderRowColumnList.Add(new OldActionPropertyObject("Ýlaç",Common.ReturnObjectAsString(DrugOrder.Material.Name)));
        //                gridDrugOrderRowColumnList.Add(new OldActionPropertyObject("Planlama Baþlangýç Tarihi",Common.ReturnObjectAsString(DrugOrder.PlannedStartTime)));
        //                gridDrugOrderRowColumnList.Add(new OldActionPropertyObject("Doz Aralýðý",Common.ReturnObjectAsString(DrugOrder.Frequency)));
        //                gridDrugOrderRowColumnList.Add(new OldActionPropertyObject("Doz Miktarý",Common.ReturnObjectAsString(DrugOrder.DoseAmount)));
        //                gridDrugOrderRowColumnList.Add(new OldActionPropertyObject("Gün",Common.ReturnObjectAsString(DrugOrder.Day)));
        //                gridDrugOrderRowList.Add(gridDrugOrderRowColumnList);
        //            }
        //            gridList.Add(gridDrugOrderRowList);
        //
        //
        //            return gridList;
        //        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InPatientPhysicianApplication).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            //if (fromState == States.Application && toState == States.Discharged)
            //    PreTransition_Application2Discharged();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InPatientPhysicianApplication).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == InPatientPhysicianApplication.States.Discharged && toState == InPatientPhysicianApplication.States.Cancelled)
                PostTransition_Discharged2Cancelled();
            else if (fromState == InPatientPhysicianApplication.States.Application && toState == InPatientPhysicianApplication.States.PreDischarged)
                PostTransition_Application2PreDischarged();
            else if (fromState == InPatientPhysicianApplication.States.Application && toState == InPatientPhysicianApplication.States.Discharged)
                PostTransition_Application2Discharged();
            else if (fromState == InPatientPhysicianApplication.States.PreDischarged && toState == InPatientPhysicianApplication.States.Discharged)
                PostTransition_PreDischarged2Discharged();
            else if (fromState == InPatientPhysicianApplication.States.Application && toState == InPatientPhysicianApplication.States.Cancelled)
                PostTransition_Application2Cancelled();
            else if (fromState == InPatientPhysicianApplication.States.PreDischarged && toState == InPatientPhysicianApplication.States.Cancelled)
                PostTransition_PreDischarged2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InPatientPhysicianApplication).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (EmergencyIntervention == null) // aciller haricinde 
                CheckUndo();
            if (fromState == InPatientPhysicianApplication.States.Discharged && toState == InPatientPhysicianApplication.States.Cancelled)
                UndoTransition_Discharged2Cancelled(transDef);
            else if (fromState == InPatientPhysicianApplication.States.Application && toState == InPatientPhysicianApplication.States.PreDischarged)
                UndoTransition_Application2PreDischarged(transDef);
            else if (fromState == InPatientPhysicianApplication.States.Application && toState == InPatientPhysicianApplication.States.Discharged)
                UndoTransition_Application2Discharged(transDef);
            else if (fromState == InPatientPhysicianApplication.States.PreDischarged && toState == InPatientPhysicianApplication.States.Discharged)
                UndoTransition_PreDischarged2Discharged(transDef);
            else if (fromState == InPatientPhysicianApplication.States.Application && toState == InPatientPhysicianApplication.States.Cancelled)
                UndoTransition_Application2Cancelled(transDef);
            else if (fromState == InPatientPhysicianApplication.States.PreDischarged && toState == InPatientPhysicianApplication.States.Cancelled)
                UndoTransition_PreDischarged2Cancelled(transDef);
        }

    }
}