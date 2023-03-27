
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
    /// Acil Hasta Müdahale İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
    public partial class EmergencyIntervention : EpisodeAction, IAllocateSpeciality, IOAExamination, IWorkListEpisodeAction, ITreatmentMaterialCollection
    {
        public partial class OLAP_GetEmergencyObservation_Class : TTReportNqlObject
        {
        }

        public partial class GetByEpisodeInfo_Class : TTReportNqlObject
        {
        }

        public partial class GetEpisodeAndPatientInfoAccordingToDiagnosis_Class : TTReportNqlObject
        {
        }

        public partial class GetEpisodeAndPatientInfo_Class : TTReportNqlObject
        {
        }

        public partial class GetEmergencyInterventionsByDateForReport_Class : TTReportNqlObject
        {
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

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "TRIAJCODE":
                    {
                        TriajCode? value = (TriajCode?)(int?)newValue;
                        #region TRIAJCODE_SetScript
                        if (value == null)
                            DescriptionForWorkList = "";
                        else
                            DescriptionForWorkList = TTUtils.CultureService.GetText("M27119", "Triaj Kodu:")+ Common.GetDisplayTextOfDataTypeEnum(value);
                        #endregion TRIAJCODE_SetScript
                    }
                    break;
                case "RESPONSIBLEDOCTOR":
                    {
                        ResUser value = (ResUser)newValue;
                        #region RESPONSIBLEDOCTOR_SetParentScript
                        if (HasMemberChanged("ResponsibleDoctor"))
                        {
                            EmergencyInterventionDoctorGroup responsibleDoctor = new EmergencyInterventionDoctorGroup(ObjectContext);
                            responsibleDoctor.Doctor = value;
                            responsibleDoctor.ActionDate = Common.RecTime();
                            DoctorGroups.Add(responsibleDoctor);
                        }

                        foreach (InPatientPhysicianApplication physicianApplication in InPatientPhysicianApplications)
                        {
                            if (!physicianApplication.IsCancelled)
                            {
                                physicianApplication.ProcedureDoctor = value;
                                //                    bool addNewAuthorizedUser=true;
                                //                    if (this.ResponsibleDoctor!=null)
                                //                    {
                                //                        if (physicianApplication.AuthorizedUsers.Count>0)
                                //                        {
                                //                            foreach(AuthorizedUser authorizedUser in physicianApplication.AuthorizedUsers)
                                //                            {
                                //                                if(authorizedUser.User.ObjectID==this.ResponsibleDoctor.ObjectID)
                                //                                {
                                //                                    if(value!=null)
                                //                                    {
                                //                                        authorizedUser.User=value;
                                //                                    }
                                //                                    else
                                //                                    {
                                //                                        //YAPILACAKLAR// İnstance silme gelince eski autorizedUser instance'ı silinmeli
                                //                                        physicianApplication.AuthorizedUsers.Remove(authorizedUser);
                                //                                    }
                                //                                    addNewAuthorizedUser=false;
                                //                                    break;
                                //                                }
                                //                            }
                                //
                                //                        }
                                //                    }
                                //                    if(addNewAuthorizedUser)
                                //                    {
                                //                        if (value!=null)
                                //                        {
                                //                            AuthorizedUser newAuthorizedUser = new AuthorizedUser(this.ObjectContext);
                                //                            newAuthorizedUser.User=(ResUser)value;
                                //                            physicianApplication.AuthorizedUsers.Add(newAuthorizedUser);
                                //                        }
                                //                    }
                            }
                        }
                        #endregion RESPONSIBLEDOCTOR_SetParentScript
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
            UpdateSEPsTriage();
            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();
            FireExaminationAndNursingDetail();
            #endregion PostInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate

            base.PostUpdate();
            CheckReponsibleDoctorIsChange();

            //Transition post'ta nedense çalışmıyor. O yüzden buraya taşıdım MC
            if (TransDef == null || ((TransDef != null) && (TransDef.ToStateDefID == EmergencyIntervention.States.Completed || TransDef.ToStateDefID == EmergencyIntervention.States.InpatientObservation || TransDef.ToStateDefID == EmergencyIntervention.States.Observation || TransDef.ToStateDefID == EmergencyIntervention.States.Triage)))
            {
                foreach (EmergencyInterventionProcedure emergencyInterventionProcedure in EmergencyInterventionProcedures.Where(x => x.CurrentStateDef.Status != StateStatusEnum.Cancelled))
                {
                    emergencyInterventionProcedure.SetPerformedDate();
                }
            }

            //Triaj değişmişse sep lerin triaj bilgiside güncellenir.
            TTObjectContext objContext = new TTObjectContext(true);
            EmergencyIntervention originalEI = objContext.GetObject(ObjectID, ObjectDef, false) as EmergencyIntervention;
            if (originalEI?.Triage?.ObjectID != this?.Triage?.ObjectID)
                UpdateSEPsTriage();

            if (HasMemberChanged("Triage") == true && Triage != null)
            {
                foreach(PatientExamination patientExamination in PatientExaminations)
                {
                    foreach(SpecialityBasedObject specialityBasedObject in patientExamination.SpecialityBasedObject)
                    {
                        if(specialityBasedObject is EmergencySpecialityObject)
                        {
                            EmergencySpecialityObject sbObject = (EmergencySpecialityObject)specialityBasedObject;
                            sbObject.SetTriage(Triage);
                        }
                    }
                }

                foreach (InPatientPhysicianApplication inPatientPhysicianApplication in InPatientPhysicianApplications)
                {
                    foreach (SpecialityBasedObject specialityBasedObject in inPatientPhysicianApplication.SpecialityBasedObject)
                    {
                        if (specialityBasedObject is EmergencySpecialityObject)
                        {
                            EmergencySpecialityObject sbObject = (EmergencySpecialityObject)specialityBasedObject;
                            sbObject.SetTriage(Triage);
                        }
                    }
                }
            }
            #endregion PostUpdate
        }

        protected void PostTransition_Intervention2Cancelled()
        {
            // From State : Intervention   To State : Cancelled
            #region PostTransition_Intervention2Cancelled

            Cancel();
            TerminationPatients();

            #endregion PostTransition_Intervention2Cancelled
        }

        protected void UndoTransition_Intervention2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Intervention   To State : Cancelled
            #region UndoTransition_Intervention2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_Intervention2Cancelled
        }


        protected void PreTransition_Intervention2Observation()
        {
            // From State : Intervention   To State : Observation
            #region PreTransition_Intervention2Observation
            //SetDailyBedProcedure();

            if (OlapDate == null)
                OlapDate = DateTime.Now;

            #endregion PreTransition_Intervention2Observation
        }

        protected void PostTransition_Intervention2Observation()
        {
            // From State : Intervention   To State : Observation
            #region PostTransition_Intervention2Observation



            #endregion PostTransition_Intervention2Observation
        }

        protected void UndoTransition_Intervention2Observation(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Intervention   To State : Observation
            #region UndoTransition_Intervention2Observation


            //Geri alınması engellendi Çünkü bu stepe geçerken Doktor ve Hemşire hizmetlerini fire ediyor geri alınırsa onaların iptali gerekir o da oda girilen tüm işlemlerin ipali demek ki sakıncalıbilir.
            NoBackStateBack();

            #endregion UndoTransition_Intervention2Observation
        }

        protected void PostTransition_Intervention2Missing()
        {
            // From State : Intervention   To State : Missing
            #region PostTransition_Intervention2Missing
            Cancel();
            TerminationPatients();

            #endregion PostTransition_Intervention2Missing
        }



        protected void PreTransition_Observation2Completed()
        {
            // From State : Observation   To State : Completed
            #region PreTransition_Observation2Completed


           /* foreach (PatientExamination patientExamination in this.PatientExaminations)
            {
                if (patientExamination.CurrentStateDefID != PatientExamination.States.ExaminationCompleted)
                    throw new Exception("Önce Hastanın Tamamlanmamış Muayenelerini Tamamlamalısınız!");

                patientExamination.CurrentStateDefID = PatientExamination.States.Completed;
            }*/
            #endregion PreTransition_Observation2Completed
        }

        protected void PostTransition_Observation2Completed()
        {
            // From State : Observation   To State : Completed
            #region PostTransition_Observation2Completed

            if (Episode.EmergencyPatientStatusInfo != null)
                Episode.EmergencyPatientStatusInfo.PatientStatus = EmergencyPatientStatusInfoEnum.Completed;

            TerminationPatients();
            /* kpayi --- this.UpdateMedulaPatientParticipationToSentServer();*/
            #endregion PostTransition_Observation2Completed
        }

        protected void UndoTransition_Observation2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Observation   To State : Completed
            #region UndoTransition_Observation2Completed


            foreach (PatientExamination pe in PatientExaminations)
            {
                pe.CurrentStateDefID = PatientExamination.States.Examination;
            }

            #endregion UndoTransition_Observation2Completed
        }

        protected void PostTransition_Observation2Cancelled()
        {
            // From State : Observation   To State : Cancelled
            #region PostTransition_Observation2Cancelled

            Cancel();
            TerminationPatients();

            #endregion PostTransition_Observation2Cancelled
        }

        protected void UndoTransition_Observation2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Observation   To State : Cancelled
            #region UndoTransition_Observation2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_Observation2Cancelled
        }

        protected void PreTransition_Observation2InpatientObservation()
        {
            // From State : Observation   To State : InpatientObservation
            #region PreTransition_Observation2InpatientObservation


            foreach (PatientExamination patientExamination in PatientExaminations)
            {
                if (patientExamination.CurrentStateDefID != PatientExamination.States.ExaminationCompleted && patientExamination.CurrentStateDefID != PatientExamination.States.ProcedureRequested)
                    throw new Exception(TTUtils.CultureService.GetText("M26671", "Önce Hastanın Tamamlanmamış Muayenelerini Tamamlamalısınız!"));

                patientExamination.CurrentStateDefID = PatientExamination.States.Completed;
            }

            #endregion PreTransition_Observation2InpatientObservation
        }

        protected void UndoTransition_Observation2InpatientObservation(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Observation   To State : InpatientObservation
            #region UndoTransition_Observation2InpatientObservation

            //Geri alınması engellendi Çünkü bu stepe geçerken Doktor ve Hemşire hizmetlerini fire ediyor geri alınırsa onaların iptali gerekir o da oda girilen tüm işlemlerin ipali demek ki sakıncalıbilir.
            NoBackStateBack();

            #endregion UndoTransition_Observation2InpatientObservation
        }

        protected void PreTransition_Completed2Observation()
        {
            // From State : Completed   To State : Observation
            #region PreTransition_Completed2Observation

            OlapDate = DateTime.Now;

            #endregion PreTransition_Completed2Observation
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled

            Cancel();
            TerminationPatients();

            #endregion PostTransition_Completed2Cancelled
        }

        protected void UndoTransition_Completed2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
            #region UndoTransition_Completed2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_Completed2Cancelled
        }




        protected void PostTransition_InpatientObservation2Completed()
        {
            // From State : InpatientObservation   To State : Completed
            #region PostTransition_InpatientObservation2Completed
            SetDischargeTime();
            TerminationPatients();
            #endregion PostTransition_InpatientObservation2Completed
        }

        protected void UndoTransition_InpatientObservation2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : InpatientObservation   To State : Completed
            #region UndoTransition_InpatientObservation2Completed


            DischargeTime = null;
            foreach (NursingApplication nursingApplication in NursingApplications)
            {
                if (!nursingApplication.IsCancelled && nursingApplication.CurrentStateDefID == NursingApplication.States.Discharged)
                {
                    ((ITTObject)nursingApplication).UndoLastTransition();
                }
            }

            #endregion UndoTransition_InpatientObservation2Completed
        }

        protected void PostTransition_InpatientObservation2Cancelled()
        {
            // From State : InpatientObservation   To State : Cancelled
            #region PostTransition_InpatientObservation2Cancelled

            Cancel();
            TerminationPatients();

            #endregion PostTransition_InpatientObservation2Cancelled
        }

        protected void UndoTransition_InpatientObservation2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : InpatientObservation   To State : Cancelled
            #region UndoTransition_InpatientObservation2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_InpatientObservation2Cancelled
        }

        #region Methods
        public void CreateEmergencyPatientStatusInfo()
        {
            ResHospital hospital = Common.GetCurrentHospital(ObjectContext);

            EmergencyPatientStatusInfo ei = new EmergencyPatientStatusInfo(ObjectContext);
            ei.LastUpdateTime = Common.RecTime();
            ei.PatientStatus = EmergencyPatientStatusInfoEnum.InExamination;
            Episode.EmergencyPatientStatusInfo = ei;

        }

        public void FireExaminationAndNursingDetail()
        {
            FirePatientExamination();
            //bg kayıt aşamasından başlaması engellendi
            //FireEmergencyInterventionNursingDetail();

            CompleteMyExaminationQueueItems();

            CreateEmergencyPatientStatusInfo();
        }

        public void FireEmergencyInterventionNursingDetail()
        {
            EmergencyInterventionNursingDetail eind = new EmergencyInterventionNursingDetail(this);
        }


        public void UpdateSEPsTriage()
        {
            List<SubEpisodeProtocol> SEPs =  SubEpisode.SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && x.IsInvoiced == false).ToList();
            foreach(SubEpisodeProtocol sep in SEPs)
            {
                sep.Triage = Triage;
            }
        }

        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.EmergencyIntervention;
            }
        }

        public bool IsGreenAreaExamination
        {
            get
            {
                return (Triage != null && Triage.KODU == "1") ? true : false;
            }
        }

        public bool NotCreateExaminationProcedure()
        {
            bool notCreateExaminationProcedure = false;
            PatientAdmissionStartedActions oaStartedAct = PatientAdmissionStartedActions.GetFiredActionsandProcedures((ResPoliclinic)MasterResource, PatientAdmission.AdmissionStatus);
            if (oaStartedAct != null)
            {
                BindingList<PAProcedureObject> procedureObj = oaStartedAct.PAProcedureObject;
                if (procedureObj.Count > 0)
                {
                    //Acil pansuman ve enjeksiyon için pol. muayene hizmeti atıp atmayacağı kontrol ediliyor.
                    foreach (PAProcedureObject procedureObjDef in procedureObj)
                    {
                        if (procedureObjDef.Resource is null || procedureObjDef.Resource.ObjectID.Equals(MasterResource.ObjectID))
                        {
                            ProcedureDefinition procedureDef = procedureObjDef.ProcedureObject;
                            return PatientExaminations[0].HasPatientAdmissionStartedSP(procedureDef, (ResSection)MasterResource);
                        }
                    }
                }
            }
            return notCreateExaminationProcedure;
        }

        public void AddEmergencyInterventionProcedure()
        {
            bool createExaminationProcedure = true;
            PatientAdmissionStartedActions oaStartedAct = PatientAdmissionStartedActions.GetFiredActionsandProcedures((ResPoliclinic)MasterResource, PatientAdmission.AdmissionStatus);
            if (oaStartedAct != null)
            {
                BindingList<PAProcedureObject> procedureObj = oaStartedAct.PAProcedureObject;
                if (procedureObj.Count > 0)
                {
                    //Burada Tanım ekranında girilmiş procedureobjects create ediliyor.
                    foreach (PAProcedureObject procedureObjDef in procedureObj)
                    {
                        if (procedureObjDef.Resource is null || procedureObjDef.Resource.ObjectID.Equals(MasterResource.ObjectID))
                        {
                            ProcedureDefinition procedureDef = procedureObjDef.ProcedureObject;
                            //Daha önce eklenmiş bir hizmet varsa tekrar eklemesin.
                            SubActionProcedure spr = PatientExaminations[0].SubactionProcedures.Where(sp => sp.ProcedureObject.ObjectID.Equals(procedureDef.ObjectID) && sp.CurrentStateDef.Status != StateStatusEnum.Cancelled && sp.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully).FirstOrDefault();
                            if (spr != null)
                                createExaminationProcedure = false;
                            else
                            {
                                SubActionProcedure sa = PatientExaminations[0].SetSubactionProcedureOfEpisodeAction(procedureDef, (ResSection)MasterResource);
                                if (sa != null)
                                {

                                    sa.ProcedureByUser = ProcedureDoctor;
                                    sa.RequestedByUser = Common.CurrentResource;
                                    sa.PerformedDate = Common.RecTime();
                                    //TRIAJ sarı alan olarak set edilsin. Acil muayene hizmeti atmasın.
                                    Triage = SKRSTRIAJKODU.GetSKRSTRIAJByKODU(ObjectContext, "2").FirstOrDefault();
                                    createExaminationProcedure = false;
                                }
                            }
                        }
                    }
                }
            }
            if (createExaminationProcedure)
            {
                EmergencyInterventionProcedure emergencyExaminationProcedure;
                if (IsGreenAreaExamination)
                    emergencyExaminationProcedure = new EmergencyInterventionProcedure(this, ProcedureDefinition.GreenAreaExaminationProcedureObjectId.ToString());
                else
                    emergencyExaminationProcedure = new EmergencyInterventionProcedure(this, ProcedureDefinition.EmergencyExaminationProcedureObjectId.ToString());
                emergencyExaminationProcedure.AccountOperation(AccountOperationTimeEnum.PREPOST);
            }
        }

        protected void FirePatientExamination()
        {
            PatientExamination patientExamination = new PatientExamination(this);
            patientExamination.PatientExaminationType = PatientExaminationEnum.Emergency;
            //Acil kabulde oluşan hasta muayenesi için kuyruğu null bir examinationqueueitem oluşturulur. (Havuz mantığı)      
            IList<ExaminationQueueDefinition> myQueue = ExaminationQueueDefinition.GetQueueByResource(this.ObjectContext, this.MasterResource.ObjectID.ToString());
            if (myQueue.Count > 0)
                patientExamination.CreateExaminationQueueItem(PatientAdmission, myQueue[0], false);
            else
                patientExamination.CreateExaminationQueueItem(PatientAdmission,null,false);

            // PatientExamination başlatılır başlatılmaz Procedure atılsın ve ücretlendirilsin diye
            AddEmergencyInterventionProcedure();            
        }

        public static void FireNursingAndPhysicianApplication(EmergencyIntervention ei)
        {
            InPatientPhysicianApplication inPatientPhysicianApplication = new InPatientPhysicianApplication(ei);
            NursingApplication nursingApplication = new NursingApplication(ei);
        }


        public ExaminationQueueItem CreateMyExaminationQueueItem()
        {
            Dictionary<int, string> PriorityPair;
            ExaminationQueueItem eq = null;
            if (MasterResource is ResClinic && ((ResClinic)MasterResource).PCSInUse != null && Convert.ToBoolean(((ResClinic)MasterResource).PCSInUse))
            {
                BindingList<ExaminationQueueDefinition> eqList = ExaminationQueueDefinition.GetEmergencyQueues(ObjectContext);
                //if (eqList.Count == 1 && TriajCode != null && TriajCode.Value != null)
                if (eqList.Count == 1 && Triage != null)
                {
                    eq = new ExaminationQueueItem(ObjectContext);
                    eq.CurrentStateDefID = ExaminationQueueItem.States.New;
                    eq.EpisodeAction = (EpisodeAction)this;
                    //todo bg
                    // eq.Priority = Convert.ToInt32(this.Triage);
                    eq.Priority = 0;
                    eq.PriorityReason = "";
                    eq.Appointment = null;
                    eq.Patient = Episode.Patient;
                    eq.QueueDate = Common.RecTime().Date;
                    eq.CallTime = Common.RecTime();
                    eq.ExaminationQueueDefinition = eqList[0];
                    eq.DivertedTime = Common.RecTime();
                    eq.Doctor = null;
                    eq.IsEmergency = true;
                    eq.CallCount = 0;
                }
            }

            return eq;
        }


        public override void Cancel()
        {
            foreach (InPatientPhysicianApplication inPatientPhysApp in InPatientPhysicianApplications)
            {
                if (inPatientPhysApp.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    inPatientPhysApp.CancelledByMasterAction = true;
                    if (string.IsNullOrEmpty(inPatientPhysApp.ReasonOfCancel))
                    {
                        inPatientPhysApp.ReasonOfCancel = ReasonOfCancel;
                    }
                    ((ITTObject)inPatientPhysApp).Cancel();
                }
            }
            foreach (NursingApplication nursingApp in NursingApplications)
            {
                if (nursingApp.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    nursingApp.CancelledByMasterAction = true;
                    if (string.IsNullOrEmpty(nursingApp.ReasonOfCancel))
                    {
                        nursingApp.ReasonOfCancel = ReasonOfCancel;
                    }
                    ((ITTObject)nursingApp).Cancel();
                }
            }
            //foreach (PatientExamination patientExamination in this.PatientExaminations)
            //{
            //    if (patientExamination.CurrentStateDef.Status != StateStatusEnum.Cancelled)
            //    {
            //        patientExamination.Cancelled = true;
            //        if (string.IsNullOrEmpty(patientExamination.ReasonOfCancel))
            //        {
            //            patientExamination.ReasonOfCancel = this.ReasonOfCancel;
            //        }
            //        ((ITTObject)patientExamination).Cancel();
            //    }
            //}
            base.Cancel();
            /* kpayi --- this.CancelMedulaPatientParticipation(); */
        }
        public void SetDischargeTime()
        {
            DischargeTime = Common.RecTime();
        }

        public void CheckReponsibleDoctorIsChange()
        {
            if (((ITTObject)this).IsNew == false)
            {
                ResUser OldDoctor = null;
                if (((ITTObject)this).HasOriginal == true)
                    OldDoctor = ((EmergencyIntervention)((ITTObject)this).Original).ResponsibleDoctor;

                bool IsChanged = true;
                if (OldDoctor == null && ResponsibleDoctor == null)
                {
                    IsChanged = false;
                }
                else if (OldDoctor != null && ResponsibleDoctor != null)
                {
                    if (OldDoctor.ObjectID == ResponsibleDoctor.ObjectID)
                    {
                        IsChanged = false;
                    }
                }

                if (IsChanged)
                {

                    EmergencyInterventionDoctorGroup responsibleDoctor = new EmergencyInterventionDoctorGroup(ObjectContext);
                    responsibleDoctor.Doctor = ResponsibleDoctor;
                    responsibleDoctor.ActionDate = Common.RecTime();
                    DoctorGroups.Add(responsibleDoctor);
                    SetAuthorizedUserOfInPatientPhysicianApplication(this);

                }
            }
        }
        public void SetAuthorizedUserOfPatientExamination()
        {
            if (((ITTObject)this).IsNew == false)
            {
                // ResUser OldDoctor=((EmergencyIntervention)((ITTObject)this).Original).ResponsibleDoctor;
                foreach (PatientExamination patientExamination in PatientExaminations)
                {
                    if (!patientExamination.IsCancelled)
                    {
                        patientExamination.ProcedureDoctor = ResponsibleDoctor;
                    }
                }
            }
        }

        public static void SetAuthorizedUserOfInPatientPhysicianApplication(EmergencyIntervention ei)
        {
            if (((ITTObject)ei).IsNew == false)
            {
                // ResUser OldDoctor=((EmergencyIntervention)((ITTObject)this).Original).ResponsibleDoctor;
                foreach (InPatientPhysicianApplication physicianApplication in ei.InPatientPhysicianApplications)
                {
                    if (!physicianApplication.IsCancelled)
                    {
                        physicianApplication.ProcedureDoctor = ei.ResponsibleDoctor;

                    }
                }
            }
        }


        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList = base.OldActionPropertyList();
            if (propertyList == null)
                propertyList = new List<EpisodeAction.OldActionPropertyObject>();

            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M20566", "Protokol No"), Common.ReturnObjectAsString(ProtocolNo)));
            if (ResponsibleDoctor != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M22142", "Sorumlu Doktor"), Common.ReturnObjectAsString(ResponsibleDoctor.Name)));
            if (ResponsibleNurse != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M22151", "Sorumlu Hemşire"), Common.ReturnObjectAsString(ResponsibleNurse.Name)));

            return propertyList;
        }
      

        public void TerminationPatients()
        {
            /*if (this.Sevkli112 == true)
            {
                string ipAddr = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112IP", null);
                TTUtils.TTWebServiceUri uri = new TTUtils.TTWebServiceUri(ipAddr);
                string userName112 = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME", null);
                string password112 = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD", null);
                IList<EmergencyIntervention.GetEpisodeAndPatientInfo_Class> EpisodeAndPatientInfoList = EmergencyIntervention.GetEpisodeAndPatientInfo(this.ObjectContext, this.Episode.ObjectID.ToString());
                try
                {
                    if (EpisodeAndPatientInfoList[0].ProtocolNo != null && EpisodeAndPatientInfoList[0].Sosyalguvenlikkurumu != null)
                    {
                        if (EpisodeAndPatientInfoList[0].Tcno != null)
                        {
                            EmergencyIntervention emergencyIntervention = (EmergencyIntervention)this.ObjectContext.GetObject(new Guid(EpisodeAndPatientInfoList[0].ObjectID.ToString()), typeof(EmergencyIntervention));
                            string vakaTanisi = String.Empty;
                            foreach (PatientExamination pe in emergencyIntervention.PatientExaminations)
                            {
                                foreach (DiagnosisGrid d in pe.SecDiagnosis)
                                {
                                    vakaTanisi += d.Diagnose != null ? d.Diagnose.Name : string.Empty;
                                }
                            }

                            TTObjectClasses.XXXXXX112Services.VakaSonlandirParam inputParam = new TTObjectClasses.XXXXXX112Services.VakaSonlandirParam();
                            TTObjectClasses.Acil112Servis.WebMethods.VakaSonlandirmaMetoduASync(Sites.SiteLocalHost, inputParam, uri, userName112, password112, "", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Convert.ToDateTime(EpisodeAndPatientInfoList[0].EnteranceTime).ToString("yyyy-MM-dd HH:mm:ss"),
                                                                                                System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), vakaTanisi, "yatış", vakaTanisi, EpisodeAndPatientInfoList[0].Sosyalguvenlikkurumu.ToString(), "0", "");

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }*/
        }

        public string GetTriajForENabiz()
        {
            if (Triage == null)
                return "0";
            switch (Triage.KODU)
            {
                //todo bg
                /*    case TTObjectClasses.TriajCode.Red:
                        return "3";
                    case TTObjectClasses.TriajCode.Yellow:
                        return "2";
                    case TTObjectClasses.TriajCode.Green:
                        return "1";*/
                default:
                    return "0";
            }

        }

        /// <summary>
        /// Kullanici Doktor ise islemi Yapan Doktor Olarak Atar
        /// </summary>
        public override void SetProcedureDoctorAsCurrentResource()
        {
            if (CurrentStateDef.Status == StateStatusEnum.Uncompleted)
            {
                if (ProcedureDoctor == null && Common.CurrentResource.TakesPerformanceScore == true)
                {
                    IList userResources = UserResource.GetByUserAndResource(ObjectContext, Common.CurrentResource.ObjectID, MasterResource.ObjectID);
                    if (userResources.Count > 0)
                    {
                        ProcedureDoctor = Common.CurrentResource;
                        if (ResponsibleDoctor == null || ResponsibleDoctor.ObjectID != Common.CurrentResource.ObjectID)
                            ResponsibleDoctor = Common.CurrentResource;
                    }
                }
            }
        }
        public void SetProcedureDoctorAsResponsibleDoctor()
        {
            if (ProcedureDoctor != ResponsibleDoctor)
                ProcedureDoctor = ResponsibleDoctor;
        }
        public void SetResponsibleDoctorAsProcedureDoctor()
        {
            if (ProcedureDoctor != null && ProcedureDoctor != ResponsibleDoctor)
                ResponsibleDoctor = ProcedureDoctor;
        }

        public static void TakeInpatientObservation(EmergencyIntervention ei)
        {
            if (ei.CurrentStateDefID != null && ei.CurrentStateDefID == EmergencyIntervention.States.InpatientObservation)
                throw new Exception(TTUtils.CultureService.GetText("M26563", "Müşahedeye alınmış bir hastayı tekrar müşahadeye alamazsınız."));

            if (ei.Triage != null && ei.Triage.KODU == "1")
                throw new Exception(TTUtils.CultureService.GetText("M25096", "Acil triaj kodu 'Yeşil alan' olan hastaları müşahedeye alamazsınız.Triaj kodu alanı bilgisini değiştiriniz."));

            if (ei.CurrentStateDefID != EmergencyIntervention.States.Cancelled && ei.CurrentStateDefID != EmergencyIntervention.States.InpatientObservation)
            {
                if (ei.CurrentStateDefID == EmergencyIntervention.States.Triage)
                {
                    ei.CurrentStateDefID = EmergencyIntervention.States.Observation;
                    ei.ObjectContext.Update();
                }
                ei.CurrentStateDefID = EmergencyIntervention.States.InpatientObservation;

                EmergencyIntervention.FireNursingAndPhysicianApplication(ei);
                EmergencyIntervention.SetAuthorizedUserOfInPatientPhysicianApplication(ei);
                ei.InpatientObservationTime = Common.RecTime();

                //PatientExamination.ChildPatientExaminationCollection pec = new PatientExamination.ChildPatientExaminationCollection(ei.PatientExaminations, "PatientExaminations");

                foreach (PatientExamination patientExamination in ei.PatientExaminations)
                {
                    List<BaseAction> ee = new List<BaseAction>(patientExamination.LinkedActions);
                    foreach (EpisodeAction ea in ee)
                    {
                        ei.InPatientPhysicianApplications[0].LinkedActions.Add(ea);
                    }
                }

                //kayıt kabulde girilen triaj kodunu güncelle
                if (ei.PatientAdmission.Triage != null && ei.PatientAdmission.Triage != ei.Triage)
                {
                    ei.PatientAdmission.OldTriage = ei.PatientAdmission.Triage;
                }
                ei.PatientAdmission.Triage = ei.Triage;

                //triaj ekranından girilen bilgileri güncelle
                if (ei.PatientAdmission.EmergencyIntervention.Triage != null && ei.PatientAdmission.EmergencyIntervention.Triage != ei.Triage)
                {
                    ei.PatientAdmission.EmergencyIntervention.OldTriage = ei.PatientAdmission.EmergencyIntervention.Triage;
                }
                ei.PatientAdmission.EmergencyIntervention.Triage = ei.Triage;

            }
        }


        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(EmergencyIntervention).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == EmergencyIntervention.States.Triage && toState == EmergencyIntervention.States.Observation)
                PreTransition_Intervention2Observation();
            else if (fromState == EmergencyIntervention.States.Observation && toState == EmergencyIntervention.States.Completed)
                PreTransition_Observation2Completed();
            else if (fromState == EmergencyIntervention.States.Observation && toState == EmergencyIntervention.States.InpatientObservation)
                PreTransition_Observation2InpatientObservation();
            else if (fromState == EmergencyIntervention.States.Completed && toState == EmergencyIntervention.States.Observation)
                PreTransition_Completed2Observation();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(EmergencyIntervention).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == EmergencyIntervention.States.Triage && toState == EmergencyIntervention.States.Cancelled)
                PostTransition_Intervention2Cancelled();
            else if (fromState == EmergencyIntervention.States.Triage && toState == EmergencyIntervention.States.Observation)
                PostTransition_Intervention2Observation();
            else if (fromState == EmergencyIntervention.States.Triage && toState == EmergencyIntervention.States.Missing)
                PostTransition_Intervention2Missing();
            else if (fromState == EmergencyIntervention.States.Observation && toState == EmergencyIntervention.States.Completed)
                PostTransition_Observation2Completed();
            else if (fromState == EmergencyIntervention.States.Observation && toState == EmergencyIntervention.States.Cancelled)
                PostTransition_Observation2Cancelled();
            else if (fromState == EmergencyIntervention.States.Completed && toState == EmergencyIntervention.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == EmergencyIntervention.States.InpatientObservation && toState == EmergencyIntervention.States.Completed)
                PostTransition_InpatientObservation2Completed();
            else if (fromState == EmergencyIntervention.States.InpatientObservation && toState == EmergencyIntervention.States.Cancelled)
                PostTransition_InpatientObservation2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(EmergencyIntervention).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == EmergencyIntervention.States.Triage && toState == EmergencyIntervention.States.Cancelled)
                UndoTransition_Intervention2Cancelled(transDef);
            else if (fromState == EmergencyIntervention.States.Triage && toState == EmergencyIntervention.States.Observation)
                UndoTransition_Intervention2Observation(transDef);
            else if (fromState == EmergencyIntervention.States.Observation && toState == EmergencyIntervention.States.Completed)
                UndoTransition_Observation2Completed(transDef);
            else if (fromState == EmergencyIntervention.States.Observation && toState == EmergencyIntervention.States.Cancelled)
                UndoTransition_Observation2Cancelled(transDef);
            else if (fromState == EmergencyIntervention.States.Observation && toState == EmergencyIntervention.States.InpatientObservation)
                UndoTransition_Observation2InpatientObservation(transDef);
            else if (fromState == EmergencyIntervention.States.Completed && toState == EmergencyIntervention.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
            else if (fromState == EmergencyIntervention.States.InpatientObservation && toState == EmergencyIntervention.States.Completed)
                UndoTransition_InpatientObservation2Completed(transDef);
            else if (fromState == EmergencyIntervention.States.InpatientObservation && toState == EmergencyIntervention.States.Cancelled)
                UndoTransition_InpatientObservation2Cancelled(transDef);
        }


    }
}