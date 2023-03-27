
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
    /// Vakaya Bağlı Hasta İşlemlerinini Ana Nesnesi
    /// </summary>
    public abstract partial class EpisodeAction : BaseAction, ISUTEpisodeAction, IEpisodeActionResources, IAccountOperation, ICheckPaid, ITreatmentMaterialCollection, IEpisodeActionPermission, IOldActions, IEpisodeAction, ISubEpisodeStarter, IStartFromNewActionInPatientFolder
    {
        public partial class GetBirthEpisodeAction_Class : TTReportNqlObject
        {
        }

        public partial class GetPatientInfoByEpisodeAction_Class : TTReportNqlObject
        {
        }

        public partial class GetEpisodesNotExistsMTS_Class : TTReportNqlObject
        {
        }

        public partial class GetPoliclinicExaminationDetail_Class : TTReportNqlObject
        {
        }

        public partial class GetEmergencyAdmissionCount_Class : TTReportNqlObject
        {
        }

        public partial class GetEpisodeActionsByRequestDate_Class : TTReportNqlObject
        {
        }

        public partial class GetInpatientFolderInfoForIAandNA_Class : TTReportNqlObject
        {
        }

        public partial class GetEHREpisodeActionSubactProcFlowablesTotalAmount_Class : TTReportNqlObject
        {
        }

        public partial class GetUnCompletedEpisodeActionsByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetByEpisodeActionFilterExpressionReport_Class : TTReportNqlObject
        {
            #region GetByEpisodeActionFilterExpressionReport_Methods

            public string RefNo
            {
                get
                {
                    if (Foreign == true)
                        return "(*) " + Convert.ToString(UniqueRefNo);
                    else
                        return Convert.ToString(UniqueRefNo);
                }
            }

            public DateTime? WorkListDateTime
            {
                get
                {
                    if (WorkListDate.HasValue && Convert.ToDateTime(WorkListDate.Value.ToString("yyyy-MM-dd 00:00:00")).Equals(new DateTime(1800, 1, 1)))
                        return ActionDate;
                    else
                        return WorkListDate;
                }
            }

            #endregion GetByEpisodeActionFilterExpressionReport_Methods

        }

        public partial class GetEndOfDayPoliclinicReport_Class : TTReportNqlObject
        {
        }

        public partial class GetByEpisodeActionWorklistDateReport_Class : TTReportNqlObject
        {
            #region GetByWorklistDateReport_Methods

            //public string RefNo
            //{
            //    get
            //    {
            //        if (this.Foreign == true)
            //            return "(*) " + Convert.ToString(this.UniqueRefNo);
            //        else
            //            return Convert.ToString(this.UniqueRefNo);
            //    }
            //}

            //public DateTime? WorkListDateTime
            //{
            //    get
            //    {
            //        if (this.WorkListDate.HasValue && Convert.ToDateTime(this.WorkListDate.Value.ToString("yyyy-MM-dd 00:00:00")).Equals(new DateTime(1800, 1, 1)))
            //            return this.ActionDate;
            //        else
            //            return this.WorkListDate;
            //    }
            //}


            #endregion GetByWorklistDateReport_Methods

        }

        public partial class GetEpisodeActionsCount_Class : TTReportNqlObject
        {
        }

        public partial class GetByMasterAction_Class : TTReportNqlObject
        {
        }

        public partial class GetEHREpisodeActionSubactionProcedures_Class : TTReportNqlObject
        {
        }

        public partial class GetPoliclinicAdmissionCount_Class : TTReportNqlObject
        {
        }

        public partial class GetEpisodeActionsByObjectIDs_Class : TTReportNqlObject
        {
        }

        public partial class GetEHREpisodeActionDiagnosis_Class : TTReportNqlObject
        {
        }

        public partial class GetEHREpisodeActionSubactionMaterialsTotalAmount_Class : TTReportNqlObject
        {
        }

        public partial class GetEHREpisodeActionSubactionProceduresTotalAmount_Class : TTReportNqlObject
        {
        }

        public partial class GetClinicStatisticsByDateDiagnosisAndPoliclinics_Class : TTReportNqlObject
        {
        }

        public partial class GetEpisodeActionByObjectID_Class : TTReportNqlObject
        {
        }

        public partial class GetPatientFolderEpisodeActions_Class : TTReportNqlObject
        {
        }

        public partial class GetActionDetailNQLByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetEpisodeActionsGroupByHasApp_Class : TTReportNqlObject
        {
        }

        /// <summary>
        /// İşlemin Bir İş Emri ile Başlatılıp Başlatılmadığını Döndürür
        /// </summary>
        /// 

        #region ITTBaseObject Members
        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }

        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }
        #endregion

        #region IStartFromNewActionInPatientFolder Members

        public MenuDefinition GetMenuDefinition()
        {
            return MenuDefinition;
        }

        public void SetMenuDefinition(MenuDefinition value)
        {
            MenuDefinition = value;
        }

        public ActionTypeEnum GetActionType()
        {
            return ActionType;
        }
        #endregion

        #region IEpisodeActionPermission Members

        public AuthorizedUser.ChildAuthorizedUserCollection GetAuthorizedUsers()
        {
            return AuthorizedUsers;
        }

        public ResUser GetProcedureDoctor()
        {
            return ProcedureDoctor;
        }

        public void GetProcedureDoctor(ResUser value)
        {
            ProcedureDoctor = value;
        }

        public void SetCurrentStateDef(TTObjectStateDef value)
        {
            CurrentStateDef = value;
        }
        #endregion
        #region IEpisodeAction Members

        public Episode GetEpisode()
        {
            return Episode;
        }

        public void SetEpisode(Episode value)
        {
            Episode = value;
        }

        public ResSection GetFromResource()
        {
            return FromResource;
        }

        public void SetFromResource(ResSection value)
        {
            FromResource = value;
        }

        public ResSection GetMasterResource()
        {
            return MasterResource;
        }

        public void SetMasterResource(ResSection value)
        {
            MasterResource = value;
        }

        public ResSection GetSecondaryMasterResource()
        {
            return SecondaryMasterResource;
        }

        public void SetSecondaryMasterResource(ResSection value)
        {
            SecondaryMasterResource = value;
        }

        public SpecialityDefinition GetProcedureSpeciality()
        {
            return ProcedureSpeciality;
        }

        public void SetProcedureSpeciality(SpecialityDefinition value)
        {
            ProcedureSpeciality = value;
        }

        public SubEpisode GetSubEpisode()
        {
            return SubEpisode;
        }

        public void SetSubEpisode(SubEpisode value)
        {
            SubEpisode = value;
        }

        public PatientMedulaHastaKabul GetMedulaHastaKabul()
        {
            return MedulaHastaKabul;
        }

        public void SetMedulaHastaKabul(PatientMedulaHastaKabul value)
        {
            MedulaHastaKabul = value;
        }

        #endregion

        public bool? IsOrderDetailObject
        {
            get
            {
                try
                {
                    #region IsOrderDetailObject_GetScript                    
                    return false;
                    #endregion IsOrderDetailObject_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "IsOrderDetailObject") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Diş Ve Hasta Muayeneleri İçin Muayne Adımını Döndürür.
        /// </summary>
        public string GotoStateDefID
        {
            get
            {
                try
                {
                    #region GotoStateDefID_GetScript                    
                    if (this is PatientExamination)
                        return Convert.ToString(PatientExamination.States.Examination);
                    //return Convert.ToString(PatientExamination.States.New);
                    //else if (this is DentalExamination)
                    //    return Convert.ToString(DentalExamination.States.New);
                    else
                        return null;
                    #endregion GotoStateDefID_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", TTUtils.CultureService.GetText("M25731", "GotoStateDefID")) + " : " + ex.Message, ex);
                }
            }
        }

        public Dictionary<int, string> GetMyPriority(ExaminationQueueDefinition queueDef, bool isEmergency, PatientAdmission patientAdmission)
        {
            Dictionary<int, string> returnValue = new Dictionary<int, string>();
            if (isEmergency == false)
            {
                string priorityReason = string.Empty;
                int priorityPoint = 50000;//50 den fazla priority tanımlanırsa 50 numaradan sonrakiler önceliksiz hastaların altında kalabilir.
                List<QueuePriorityDefinition> myPriorityDefs = new List<QueuePriorityDefinition>();
                List<QueuePrioritySystemEnum> mySystemPriorities = new List<QueuePrioritySystemEnum>();
                //foreach (PA_PCSGridObject pcsObj in PA_PCSGridObjects)//TODO
                //{
                //    if (pcsObj.QueuePriorityDefinition != null && (bool)pcsObj.Checked)
                //        myPriorityDefs.Add(pcsObj.QueuePriorityDefinition);
                //    else if (pcsObj.QueuePrioritySystem != null && (bool)pcsObj.Checked)
                //        mySystemPriorities.Add(pcsObj.QueuePrioritySystem.Value);
                //}

                QueueTemplatePriorityGridObject highestPriorityObj = null;
                QueuePriorityTemplateDef queuePriorityTemplateDef = queueDef.QueuePriorityTemplateDef;
                foreach (QueueTemplatePriorityGridObject gridObj in queuePriorityTemplateDef.QueueTemplatePriorityGridObjects)
                {
                    if ((gridObj.QueuePriorityDefinition != null && myPriorityDefs.Contains(gridObj.QueuePriorityDefinition) && gridObj.Priority < priorityPoint)
                        || gridObj.QueuePrioritySystem != null && mySystemPriorities.Contains((QueuePrioritySystemEnum)gridObj.QueuePrioritySystem) && gridObj.Priority < priorityPoint)
                    {
                        priorityPoint = (int)gridObj.Priority;
                        highestPriorityObj = gridObj;
                    }
                }

                if (priorityPoint != 50000)
                    priorityPoint = priorityPoint * 1000;

                if (highestPriorityObj != null)
                {
                    if (highestPriorityObj.QueuePriorityDefinition != null)
                        priorityReason = highestPriorityObj.QueuePriorityDefinition.PriorityName;
                    else if (highestPriorityObj.QueuePrioritySystem != null)
                        priorityReason = (Common.GetEnumValueDefOfEnumValue((Enum)highestPriorityObj.QueuePrioritySystem)).DisplayText;
                }

                returnValue.Add(priorityPoint, priorityReason);
            }
            else
            {
                foreach (EpisodeAction ea in patientAdmission.Episode.EpisodeActions)
                {
                    if (ea is EmergencyIntervention)
                        returnValue.Add(Convert.ToInt32(((EmergencyIntervention)ea).Triage), null);
                }
            }
            return returnValue;
        }
        public void UpdateExaminationQueueItem(PatientAdmission patientAdmission)
        {
            foreach (ExaminationQueueItem examinationQueueItem in QueueItems)
            {
                if (patientAdmission.ResultQueueNumber.Value < 10)
                    examinationQueueItem.OrderNo = "S-00" + patientAdmission.ResultQueueNumber.ToString();
                else if (patientAdmission.ResultQueueNumber.Value < 100)
                    examinationQueueItem.OrderNo = "S-0" + patientAdmission.ResultQueueNumber.ToString();
                else
                    examinationQueueItem.OrderNo = "S-" + patientAdmission.ResultQueueNumber.ToString();

                examinationQueueItem.QueueDate = Common.RecTime();
                examinationQueueItem.CallTime = Common.RecTime();
                examinationQueueItem.DivertedTime = Common.RecTime();
                if (examinationQueueItem.CurrentStateDefID == ExaminationQueueItem.States.Completed || examinationQueueItem.CurrentStateDefID == ExaminationQueueItem.States.Cancelled)
                    ((ITTObject)examinationQueueItem).UndoLastTransition();
                examinationQueueItem.IsResultExamination = true;
                examinationQueueItem.CallCount = 0;
                examinationQueueItem.Doctor = patientAdmission.ProcedureDoctor;
                examinationQueueItem.Priority = 5000;
                examinationQueueItem.Appointment = null;
                ExaminationQueueDefinition myQueue = ExaminationQueueDefinition.GetQueueByResource(patientAdmission.ObjectContext, patientAdmission.Policlinic.ObjectID.ToString()).FirstOrDefault();
                if (myQueue != null)
                    examinationQueueItem.ExaminationQueueDefinition = myQueue;

            }
            if (patientAdmission.PAStatus == PAStatusEnum.MuayenesiSonlandı)
                patientAdmission.PAStatus = PAStatusEnum.Muayenede;

        }
        public ExaminationQueueItem CreateExaminationQueueItem(PatientAdmission patientAdmission, ExaminationQueueDefinition appQueueDef, bool isEmergency)
        {
            Dictionary<int, string> PriorityPair;
            ExaminationQueueItem examinationQueueItem = null;
            if (this is INumaratorAppointment)
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("CloseExaminationQueueItem", "FALSE") != "TRUE")
                {
                    if (MasterResource != null && MasterResource is ResPoliclinic)
                    {
                        //Kuyruk boşsa da oluştur.
                        if (appQueueDef == null || Episode.Patient.HasActiveQueueItemInQueue(appQueueDef, ProcedureDoctor) == null)
                        {
                            examinationQueueItem = new ExaminationQueueItem(ObjectContext);
                            examinationQueueItem.EpisodeAction = this;
                            examinationQueueItem.Appointment = null;
                            examinationQueueItem.CurrentStateDefID = TTObjectClasses.ExaminationQueueItem.States.New;
                            examinationQueueItem.Patient = Episode.Patient;
                            examinationQueueItem.Priority = (patientAdmission.PriorityStatus == null) ? 5000 : patientAdmission.PriorityStatus.Order;
                            examinationQueueItem.PriorityReason = (patientAdmission.PriorityStatus == null) ? "" : patientAdmission.PriorityStatus.Name;
                            examinationQueueItem.ExaminationQueueDefinition = appQueueDef;
                            examinationQueueItem.DivertedTime = Common.RecTime();
                            if (appQueueDef != null)
                                examinationQueueItem.Doctor = ProcedureDoctor;
                            examinationQueueItem.IsResultExamination = false;
                            examinationQueueItem.OrderNo = patientAdmission.AdmissionQueueNumber.ToString();
                            examinationQueueItem.QueueDate = patientAdmission.ActionDate;
                            examinationQueueItem.CallTime = patientAdmission.ActionDate;
                            examinationQueueItem.CallCount = 0;
                        }
                    }
                }
            }
            return examinationQueueItem;
        }



        /// <summary>
        /// Konsültasyon gridini doldurur.
        /// </summary>
        public BindingList<Consultation> GetConsultationsHistory()
        {
            //BindingList<Consultation> consList = Consultation.GetAllConsultationsOfPatient(this.ObjectContext, this.Episode.Patient.ObjectID.ToString());
            BindingList<Consultation> consList = Consultation.GetAllConsultationsOfEpisode(ObjectContext, Episode.ObjectID.ToString());
            return consList;
        }

        /// <summary>
        /// Konsültasyon gridini doldurur.
        /// </summary>
        public BindingList<PatientInterviewForm> GetPatientInterviewsHistory()
        {
            BindingList<PatientInterviewForm> consList = PatientInterviewForm.GetAllPatientInterviewForms(ObjectContext, Episode.Patient.ObjectID.ToString());
            return consList;
        }

        public BindingList<ConsultationFromExternalHospital> GetExternalConsultationsHistory()
        {
            BindingList<ConsultationFromExternalHospital> consList = ConsultationFromExternalHospital.GetAllExternalConsultationsOfEpisode(ObjectContext, Episode.ObjectID.ToString());
            return consList;
        }

        /// <summary>
        /// İşlemin İş Listesinde hangi Renk Gözükeceği Bilgisini Döndürür
        /// </summary>
        public string PrescriptionColorType
        {
            get
            {
                try
                {
                    #region PrescriptionColorType_GetScript                    
                    string prescriptionColorType;
                    if (this is Prescription)
                    {
                        prescriptionColorType = ((Prescription)this).PrescriptionType.Value.ToString();
                    }
                    else
                    {
                        prescriptionColorType = null;
                    }
                    return prescriptionColorType;
                    #endregion PrescriptionColorType_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "PrescriptionColorType") + " : " + ex.Message, ex);
                }
            }
        }

        public void SetProcedureSpeciality()
        {
            if (SetProcedureSpecialtyBy().ToUpper() == "MASTERRESOURCE" && MasterResource != null)
            {
                if (MasterResource.ResourceSpecialities != null && MasterResource.ResourceSpecialities.Count > 0)
                {
                    ProcedureSpeciality = MasterResource.ResourceSpecialities[0].Speciality;
                }
            }
            else if (SetProcedureSpecialtyBy().ToUpper() == "FROMRESOURCE" && FromResource != null)
            {
                if (FromResource.ResourceSpecialities != null && FromResource.ResourceSpecialities.Count > 0)
                {
                    ProcedureSpeciality = FromResource.ResourceSpecialities[0].Speciality;
                }
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "ORDEROBJECT":
                    {
                        string value = (string)newValue;
                        #region ORDEROBJECT_SetScript
                        value = null;
                        #endregion ORDEROBJECT_SetScript
                    }
                    break;
                case "MASTERRESOURCE":
                    {
                        ResSection value = (ResSection)newValue;
                        #region MASTERRESOURCE_SetParentScript
                        //YAPILACAKLAR// koddaki set masterresource silindiğinde açılacak
                        //            if ( this.LimitedMasterResourceTypes()!= null)
                        //            {
                        //                if(LimitedMasterResourceTypes().Count > 0 && !(LimitedMasterResourceTypes().Contains(value)))
                        //                {
                        //                    throw new Exception(this.ObjectDef.Description.ToString() + " işlemi " + value.GetType().Name.ToString() + " tipinde bir kaynak'da yapılamaz . Lütfen Bilgi işleme başvurunuz.");
                        //                }
                        //            }
                        //PreInsert ve PreUpdate e taşındı.
                        //if (value != null)
                        //{
                        //    //if( this.Episode!=null)
                        //    //{
                        //    if (SetProcedureSpecialtyBy().ToUpper() == "MASTERRESOURCE")
                        //    {
                        //        if (value.ResourceSpecialities.Count == 1)
                        //        {
                        //            this.ProcedureSpeciality = value.ResourceSpecialities[0].Speciality;
                        //        }

                        //    }

                        //    // }
                        //}
                        #endregion MASTERRESOURCE_SetParentScript
                    }
                    break;
                case "FROMRESOURCE":
                    {
                        ResSection value = (ResSection)newValue;
                        #region FROMRESOURCE_SetParentScript
                        if (value != null)
                        {
                            //PreInsert ve PreUpdate e taşındı.
                            //if (SetProcedureSpecialtyBy().ToUpper() == "FROMRESOURCE")
                            //{
                            //    // if( this.Episode!=null)
                            //    // {
                            //    if (value.ResourceSpecialities.Count == 1)
                            //    {
                            //        this.ProcedureSpeciality = value.ResourceSpecialities[0].Speciality;
                            //    }
                            //    // }
                            //}
                            //Acil Klinikten istenen işlemlerin acil okark başlatılması için
                            if (value is ResClinic)
                            {
                                if (((ResClinic)value).IsEmergencyClinic == true)
                                    Emergency = true;
                            }
                        }
                        #endregion FROMRESOURCE_SetParentScript
                    }
                    break;
                case "PROCEDURESPECIALITY":
                    {
                        SpecialityDefinition value = (SpecialityDefinition)newValue;
                        #region PROCEDURESPECIALITY_SetParentScript
                        string codeReasonForAdmission = "27";
                        if (Episode != null)
                        {
                            if (IsAttributeExists(typeof(AllocateSpecialityAttribute)) == true)
                            {
                                foreach (Allocation allocation in GetExistingAllocationList())
                                {
                                    if (allocation.SubActionProcedure == MySubActionProcedure)
                                    {
                                        allocation.Speciality = value;
                                    }
                                }
                            }

                            // Kabul Sebebi Sağlık Kurulu Muayenesi, Profesörler Sağlık Kurulu veya Geçici Sağlık Kurulu Muayenesi ise Episode'un Uzmanlık Dalı güncellenmesin
                            if (SubEpisode.PatientAdmission.AdmissionStatus != AdmissionStatusEnum.SaglikKurulu)
                            {
                                //Episodeda ilk başlatılan işlem hangisi ise onun uzmanlık dalı Vakanın Uzmanlık dalı olur.Ancak daha sonrada Yatış ve ya Muayene yapılırsa  son yapılanın uzmanlık dalı Episodeun uzmanlık dalı olarak set edilir.
                                //if (this is PatientExamination || (this is InPatientTreatmentClinicApplication && (((InPatientTreatmentClinicApplication)this).BaseInpatientAdmission is IntensiveCareAfterSurgery) == false) || this is DentalExamination)
                                if (this is PatientExamination || (this is InPatientTreatmentClinicApplication && (((InPatientTreatmentClinicApplication)this).BaseInpatientAdmission is IntensiveCareAfterSurgery) == false))
                                {
                                    Episode.MainSpeciality = value;
                                }
                                else
                                {
                                    if (Episode.MainSpeciality == null)
                                    {
                                        Episode.MainSpeciality = value;
                                    }
                                    else
                                    {
                                        if (PatientAdmission != null)
                                        {

                                            // todo bg if (this.PatientAdmission.AdmissionType.Value.ToString() == codeReasonForAdmission)
                                            Episode.MainSpeciality = value;

                                        }
                                    }
                                }
                            }
                        }
                        #endregion PROCEDURESPECIALITY_SetParentScript
                    }
                    break;
                case "EPISODE":
                    {
                        Episode value = (Episode)newValue;
                        #region EPISODE_SetParentScript
                        ObjectContext.IsInvalidMemberValueExceptionsEnabled = true;
                        if (value != null)
                        {

                            SetFromResource(value);
                            SetMasterResource(value, false);
                            if (IsOldAction != true) // Aktarımla gelen işlemlerde kontrol edilmesi gerekmiyor
                            {
                                CheckEpisodeStateToOpenAction(value);
                                CheckPatientExclusive(value);
                                CheckEpisodeExclusive(value);
                                CheckRequiredPatientStatus(value);
                            }

                            // Bu koşul kaldırıldı, FTR gibi CreateSubEpisodeAttribute ü olduğu halde her durumda altvaka açmayacak olan işlemler var
                            // bu koşuldan dolayı altvaka açmadığı durumlarda SubEpisode null kalıyordu. )
                            //if (!this.IsAttributeExists(typeof(CreateSubEpisodeAttribute))) // eğer kendisi  yeni sub episode açacaksa subepisode set etmeye gerek yok
                            //{
                            if (MasterAction != null && MasterAction is EpisodeAction && ((EpisodeAction)MasterAction).SubEpisode != null)
                                SubEpisode = ((EpisodeAction)MasterAction).SubEpisode;// eğer master actıonı varsa direk onun Subepisodunu alır
                            else
                                SetMyProperOpenedSubEpisode(value, false);// Episode değiştirme yapılınca yeni episodedaki subepisodu alması için false yapıldı
                                                                          //}
                        }
                        #endregion EPISODE_SetParentScript
                    }
                    break;
                case "SUBEPISODE":
                    {
                        SubEpisode value = (SubEpisode)newValue;
                        if (value != null)
                        {
                            BeforeSetSubEpisode(value);
                            #region SUBEPISODE_SetParentScript
                            foreach (SubActionProcedure sp in SubactionProcedures)
                            {
                                if (sp.CurrentStateDef == null || sp.CurrentStateDef.Status != StateStatusEnum.Cancelled) // Cancel Objelerde Property Set edilebildiğinde silisin
                                    sp.SubEpisode = value;
                            }
                            foreach (BaseTreatmentMaterial tm in TreatmentMaterials)
                            {
                                if (tm.CurrentStateDef == null || tm.CurrentStateDef.Status != StateStatusEnum.Cancelled) // Cancel Objelerde Property Set edilebildiğinde silisin
                                    tm.SubEpisode = value;
                            }
                            if (this is InPatientPhysicianApplication)
                            {
                                foreach (DrugOrder drugOrder in ((InPatientPhysicianApplication)this).DrugOrders)
                                {
                                    if (drugOrder.CurrentStateDef == null || drugOrder.CurrentStateDef.Status != StateStatusEnum.Cancelled) // Cancel Objelerde Property Set edilebildiğinde silisin
                                        drugOrder.SubEpisode = value;
                                }
                            }
                            if (this is NursingApplication)
                            {
                                foreach (DrugOrderDetail drugOrderDetail in ((NursingApplication)this).DrugOrderDetails)
                                {
                                    //if(drugOrderDetail.CurrentStateDef == null || drugOrderDetail.CurrentStateDef.Status != StateStatusEnum.Cancelled) // Cancel Objelerde Property Set edilebildiğinde silisin
                                    drugOrderDetail.SubEpisode = value;
                                }
                            }
                            #endregion SUBEPISODE_SetParentScript
                        }
                    }
                    break;
                case "PROCEDUREDOCTOR":
                    {
                        ResUser value = (ResUser)newValue;
                        #region PROCEDUREDOCTOR_SetParentScript
                        //if (value != null)
                        //{
                        //    bool IsAssignable;
                        //    IsAssignable = value.IsAssignablePatientGroup(this.Episode);
                        //    if (IsAssignable == false)
                        //    {
                        //        throw new Exception(SystemMessage.GetMessage(1010));
                        //    }
                        //}


                        ////if (this is PatientExamination || this is FollowUpExamination || this is DentalExamination || this is InPatientPhysicianApplication || this is AnesthesiaConsultation || this is ConsultationFromOtherHospital)// Doktorun Eski ve Yeni Tüm İşlemleri görebilmesi için
                        //if (this is PatientExamination || this is FollowUpExamination || this is InPatientPhysicianApplication || this is AnesthesiaConsultation || this is ConsultationFromOtherHospital)// Doktorun Eski ve Yeni Tüm İşlemleri görebilmesi için
                        //{

                        //    if (this.ProcedureDoctor != null && value != null)
                        //    {
                        //        if (this.ProcedureDoctor.ObjectID != value.ObjectID)
                        //        {
                        //            if (this.Episode.Patient.SecurePerson != null && this.Episode.Patient.SecurePerson.Value == true)
                        //            {
                        //                if (this is InPatientPhysicianApplication || this is PatientExamination)
                        //                {
                        //                    if (!(Common.CurrentUser.IsSuperUser || Common.CurrentUser.IsPowerUser || Common.CurrentResource.ObjectID == this.ProcedureDoctor.ObjectID))
                        //                        throw new Exception(SystemMessage.GetMessage(1011));
                        //                }
                        //                else
                        //                {
                        //                    if (!(Common.CurrentUser.IsSuperUser || Common.CurrentUser.IsPowerUser))
                        //                        throw new Exception(SystemMessage.GetMessage(1012));
                        //                }
                        //            }
                        //            this.ProcedureDoctor.DeleteFromPatientAuthorizedResource(this.Episode);
                        //            value.SetAsPatientAuthorizedResource(this.Episode);
                        //        }
                        //    }
                        //    else if (this.ProcedureDoctor == null && value != null)
                        //    {
                        //        value.SetAsPatientAuthorizedResource(this.Episode);
                        //    }
                        //    else if (value == null && this.ProcedureDoctor != null)
                        //    {
                        //        this.ProcedureDoctor.DeleteFromPatientAuthorizedResource(this.Episode);
                        //    }
                        //}

                        //if (value != null)
                        //{
                        //    AddSpecialProcedure(value);
                        //    bool addNewAuthorizedUser = true;
                        //    if (this.ProcedureDoctor != null)
                        //    {
                        //        if (this.AuthorizedUsers.Count > 0)
                        //        {
                        //            foreach (AuthorizedUser authorizedUser in this.AuthorizedUsers)
                        //            {
                        //                if (authorizedUser.User.ObjectID == this.ProcedureDoctor.ObjectID)
                        //                {
                        //                    if (value != null)
                        //                    {
                        //                        authorizedUser.User = (ResUser)value;
                        //                    }
                        //                    else
                        //                    {
                        //                        this.AuthorizedUsers.Remove(authorizedUser);
                        //                        ((ITTObject)authorizedUser).Delete();
                        //                    }
                        //                    addNewAuthorizedUser = false;
                        //                    break;
                        //                }
                        //            }
                        //        }

                        //    }

                        //    if (addNewAuthorizedUser)
                        //    {
                        //        AuthorizedUser newAuthorizedUser = new AuthorizedUser(this.ObjectContext);
                        //        newAuthorizedUser.User = (ResUser)value;
                        //        this.AuthorizedUsers.Add(newAuthorizedUser);
                        //    }
                        //}
                        if (value != null)
                        {

                            // ProcedureDoctor değiştikçe SubactionProcedurelerinşn ProceduerDoctorları değiştirilir
                            if (SetMyProcedureDoctorToMySubactionProcedure())
                            {
                                foreach (SubActionProcedure sp in SubactionProcedures)
                                {
                                    if (sp.GetProcedureDoctorFromMyEpisodeAction() && sp.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                                    {
                                        if (sp.ProcedureDoctor == null || (ProcedureDoctor != null && ProcedureDoctor.ObjectID == sp.ProcedureDoctor.ObjectID))// SubactionProcedurün Procedur doktoru boşsa yada Episode Actionın değişmeden önceki değeri ile yanı ise değişitr
                                            sp.ProcedureDoctor = value;
                                    }
                                }
                            }

                            if (this is SubSurgery)// SubSurgery nin procedureDoctoru değiştikçe SubSurgeryProcedure'lerinin ProcedureDoctor'ları güncellenir
                            {

                                foreach (SubSurgeryProcedure sp in ((SubSurgery)this).SubSurgeryProcedures)
                                {
                                    if (sp.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                                    {
                                        if (sp.ProcedureDoctor == null || (ProcedureDoctor != null && ProcedureDoctor.ObjectID == sp.ProcedureDoctor.ObjectID))
                                            sp.ProcedureDoctor = value;
                                    }
                                }
                            }
                        }
                        #endregion PROCEDUREDOCTOR_SetParentScript
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

            DateTime tempDate = this.RequestDate.HasValue ? this.RequestDate.Value : DateTime.Now;

            if (this is NursingOrder)
            {
                tempDate = ((NursingOrder)this).PeriodStartTime.Value;
            }

            string message = PatientOnVacation.HasActiveVacation(tempDate, this.Episode.Patient.ObjectID);

            if (!string.IsNullOrEmpty(message))
            {
                throw new Exception(message + "\n Bu tarihe yeni bir action başlatılamaz");
            }

            base.PreInsert();
            SetMasterResource(Episode, true);
            SetProcedureSpeciality();
            //Sequence bir Protocolno propertysi  olan tüm işlemlerin masterresourceu set edildiğinde bölüme ve yıla göre protokol numarası almasını sağlar
            //Tıbbi Cerrahi Uygulamalar için istek kabul yapılmadan yeni protokol numarası atanmaz.
            if (!(GetType() == typeof(TTObjectClasses.Manipulation) && CurrentStateDefID == TTObjectClasses.Manipulation.States.RequestAcception))
            {
                System.Reflection.PropertyInfo propInfo = GetType().GetProperty("ProtocolNo");
                if (propInfo != null && propInfo.PropertyType == typeof(TTSequence))
                {
                    TTSequence protocolNo = propInfo.GetValue(this, null) as TTSequence;
                    if (protocolNo.Value == null && IsOldAction != true)
                        protocolNo.GetNextValue(MasterResource.ObjectID.ToString(), Common.RecTime().Year);
                }
            }

            //TODO: sutrule engine burada calsıtırılacak
            //if (!ValidateSutRules(this))
            //{
            //    throw new TTUtils.TTException("Sut kuralları doğrulaması başarısız oldu");//ApplicationException
            //}


            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert

            base.PostInsert();
            AccountOperation();
            int codeReasonForAdmission = 27;
            if (Episode != null)
            {
                // Kabul Sebebi Sağlık Kurulu Muayenesi, Profesörler Sağlık Kurulu veya Geçici Sağlık Kurulu Muayenesi ise Episode'un Uzmanlık Dalı güncellenmesin
                //                if (this.Episode.ReasonForAdmission.Type != AdmissionTypeEnum.HealthCommitteeExamination)
                //                {
                //                      if (this is InPatientTreatmentClinicApplication && this.ProcedureSpeciality != null)
                //                        this.Episode.MainSpeciality = this.ProcedureSpeciality;
                //
                //                }
            }
            if (IsOldAction != true)
                ActionDate = Common.RecTime();




            #endregion PostInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate

            base.PreUpdate();
            SetProcedureSpeciality();
            if (!NotUpdateEpisodeAction)
            {
                CheckEpisodeStateToUpdateAction();
                if (CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                {
                    if (IsOldAction != true)
                        ActionDate = Common.RecTime();
                }
            }


            //TODO: sutrule engine burada calsıtırılacak
            //if (!ValidateSutRules(this))
            //{
            //    throw new TTUtils.TTException("Sut kuralları doğrulaması başarısız oldu");//ApplicationException
            //}

            #endregion PreUpdate
        }

        protected override void PostUpdate()
        {
            #region PostUpdate

            base.PostUpdate();
            if (!NotUpdateEpisodeAction)
            {
                StockOutTreatmentMaterials();
                AccountOperation();
                //this.CloseCloseToOpenEpisode();
            }

            // Cancel veya Başarısız tamamlndı hariç her Updatede
            if (TransDef == null || ((TransDef != null) && (TransDef.ToStateDef.Status != StateStatusEnum.Cancelled || TransDef.ToStateDef.Status != StateStatusEnum.CompletedUnsuccessfully)))
            {
                foreach (SubActionProcedure subactionProcedure in SubactionProcedures.Where(x => x.CurrentStateDef.Status != StateStatusEnum.Cancelled))
                {

                    if (subactionProcedure.ProcedureDoctor == null)
                        subactionProcedure.ProcedureDoctor = ProcedureDoctor;
                }
            }
            // Tamamlanırken
            if (TransDef != null && TransDef.ToStateDef.Status == StateStatusEnum.CompletedSuccessfully)// Doktor Performansa gitmsi için Tüm subactionProcedureler tamamlanmış olmalı
            {
                CompleteMySubActionProcedures();
                SetMySubActionProceduresPerformedDate();
            }

            if (Episode.HasMemberChanged("Complaint") || Episode.HasMemberChanged("PatientHistory") || Episode.HasMemberChanged("PhysicalExamination"))
            {
                if (SubEpisode != null && SendToENabiz())
                    new SendToENabiz(ObjectContext, SubEpisode, SubEpisode.ObjectID, SubEpisode.ObjectDef.Name, "103", Common.RecTime());
            }
            #endregion PostUpdate
        }

        protected override void PreDelete()
        {
            #region PreDelete
            base.PreDelete();

            #endregion PreDelete
        }

        protected override void PostDelete()
        {
            #region PostDelete
            base.PostDelete();

            #endregion PostDelete
        }


        public bool ValidateSutRules(object owner)
        {
            TTUtils.Entities.RuleValidateResultDto validateResult = CheckSutRules(false);
            // SUT kural doğrulama sonucu hiç bir mesaj dönmedi
            if (validateResult == null || !EnumerableHelper.Any(validateResult.Messages))
                return true;


            //TTFormClasses.SutRuleCheckResultsForm form = new TTFormClasses.SutRuleCheckResultsForm();
            //form.BlockRequest = false;
            //form.RuleViolateMessages = validateResult.Messages;
            //form.BlockRequest = validateResult.BlockRequest;
            //DialogResult result = form.ShowDialog((IWin32Window)owner);


            bool returnValue = false;
            // Doktor devam seçeneğini kullanıyor
            //if (result == DialogResult.Ignore)
            //{
            //    this.SetSutRulesIgnored(validateResult.Messages);
            //    returnValue = true;
            //}

            string resultXml = SerializationHelper.XmlSerializeObject(validateResult.Messages);

            string resultText = resultXml;

            if (resultText.Length > 4000)
            {
                resultText = resultText.Substring(0, 4000);
            }

            TTObjectContext context = new TTObjectContext(false);
            SUTRuleCheckResult sutCheckResult = new SUTRuleCheckResult(context);
            sutCheckResult.ProcessDate = DateTime.Now;
            sutCheckResult.ResUser = TTUser.CurrentUser.UserObject as ResUser;
            sutCheckResult.Results = resultText;
            sutCheckResult.Status = SUTRuleCheckResultStatus.Rejected;
            sutCheckResult.Episode = Episode;
            sutCheckResult.CheckResults = resultXml;

            //if (result == DialogResult.Ignore)
            //{
            //    sutCheckResult.Status = SUTRuleCheckResultStatus.Ignored;
            //}
            context.Save();

            // SUT kural doğrulama başarısız oldu işleme devam edilmeyecek
            return returnValue;
        }


        #region Methods

        #region ITreatmentMaterialCollection Members
        public BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection GetTreatmentMaterials()
        {
            return TreatmentMaterials;
        }
        #endregion

        public override bool NotSetWorklist
        {
            get { return (IgnoreEpisodeStateOnUpdate == true); }// subepisode seti için
            set
            {
            }
        }

        public virtual bool NotUpdateEpisodeAction
        {
            get { return (IgnoreEpisodeStateOnUpdate == true); }// subepisode seti için
            set
            {
            }
        }

        public bool IsSpecialTemplate = false;
        //Hasta Kabulden başlatılacak işlemlerin için overreide edilmeli.

        [TTStorageManager.Attributes.TTSerializeProperty]
        public virtual ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.UnDefinedAction;
            }
        }

        private MenuDefinition menuDefinition;
        public MenuDefinition MenuDefinition
        {
            get { return menuDefinition; }
            set { menuDefinition = value; }
        }

        //IAllocateSpeciality için kullanılacak
        public EpisodeAction MyEpisodeAction
        {
            get { return (EpisodeAction)this; }
            set
            {
            }
        }


        public static BindingList<Appointment> GetMyNewAppointments(Guid objectID)
        {
            TTObjectContext objContext = new TTObjectContext(true);

            BindingList<Appointment> retList = (BindingList<Appointment>)objContext.QueryObjects<Appointment>("(EPISODEACTION = " + ConnectionManager.GuidToString(objectID) + " OR ACTION = " + ConnectionManager.GuidToString(objectID) + ") AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.New), "APPDATE");
            foreach (Appointment app in objContext.LocalQuery("APPOINTMENT", "(EPISODEACTION = " + ConnectionManager.GuidToString(objectID) + " OR ACTION = " + ConnectionManager.GuidToString(objectID) + ") AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.New), "APPDATE"))
                if (retList.Contains(app) == false)
                    retList.Add(app);
            return retList;

        }




        public override BindingList<Appointment> GetMyNewAppointments()
        {
            BindingList<Appointment> retList = (BindingList<Appointment>)ObjectContext.QueryObjects<Appointment>("(EPISODEACTION = " + ConnectionManager.GuidToString(ObjectID) + " OR ACTION = " + ConnectionManager.GuidToString(ObjectID) + ") AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.New), "APPDATE");
            foreach (Appointment app in ObjectContext.LocalQuery("APPOINTMENT", "(EPISODEACTION = " + ConnectionManager.GuidToString(ObjectID) + " OR ACTION = " + ConnectionManager.GuidToString(ObjectID) + ") AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.New), "APPDATE"))
                if (retList.Contains(app) == false)
                    retList.Add(app);
            return retList;
        }

        public static BindingList<Appointment> MyCompletedAppointments(Guid objectID)
        {

            TTObjectContext objContext = new TTObjectContext(true);

            BindingList<Appointment> retList = (BindingList<Appointment>)objContext.QueryObjects<Appointment>("(EPISODEACTION = " + ConnectionManager.GuidToString(objectID) + " OR ACTION = " + ConnectionManager.GuidToString(objectID) + ") AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.Completed), "APPDATE");
            foreach (Appointment app in objContext.LocalQuery("APPOINTMENT", "(EPISODEACTION = " + ConnectionManager.GuidToString(objectID) + " OR ACTION = " + ConnectionManager.GuidToString(objectID) + ") AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.Completed), "APPDATE"))
                if (retList.Contains(app) == false)
                    retList.Add(app);
            return retList;

        }


        public override BindingList<Appointment> MyCancelledAppointments
        {
            get
            {
                BindingList<Appointment> retList = (BindingList<Appointment>)ObjectContext.QueryObjects<Appointment>("(EPISODEACTION = " + ConnectionManager.GuidToString(ObjectID) + " OR ACTION = " + ConnectionManager.GuidToString(ObjectID) + ") AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.Cancelled), "APPDATE");
                foreach (Appointment app in ObjectContext.LocalQuery("APPOINTMENT", "(EPISODEACTION = " + ConnectionManager.GuidToString(ObjectID) + " OR ACTION = " + ConnectionManager.GuidToString(ObjectID) + ") AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.Cancelled), "APPDATE"))
                    if (retList.Contains(app) == false)
                        retList.Add(app);
                return retList;
            }
        }

        public BindingList<Appointment> MyNotApprovedAppointments()
        {
            BindingList<Appointment> retList = (BindingList<Appointment>)ObjectContext.QueryObjects<Appointment>("(EPISODEACTION = " + ConnectionManager.GuidToString(ObjectID) + " OR ACTION = " + ConnectionManager.GuidToString(ObjectID) + ") AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.NotApproved), "APPDATE");
            foreach (Appointment app in ObjectContext.LocalQuery("APPOINTMENT", "(EPISODEACTION = " + ConnectionManager.GuidToString(ObjectID) + " OR ACTION = " + ConnectionManager.GuidToString(ObjectID) + ") AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.NotApproved), "APPDATE"))
                if (retList.Contains(app) == false)
                    retList.Add(app);
            return retList;

        }


        public SubEpisode GetMyProperOpenedSubEpisode()
        {
            return GetMyProperOpenedSubEpisode(Episode, false, false);

        }
        public void SetMyProperOpenedSubEpisode(Episode episode, bool setOnlyIfSubEpisodeNull)
        {
            GetMyProperOpenedSubEpisode(episode, setOnlyIfSubEpisodeNull, true);
        }

        private SubEpisode GetMyProperOpenedSubEpisode(Episode episode, bool setOnlyIfSubEpisodeNull, bool setMySubEpisode)
        {
            DateTime? minDate5 = Common.MinDateTime();
            DateTime? minDate4 = minDate5;
            DateTime? minDate3 = minDate5;
            DateTime? minDate2 = minDate5;

            SubEpisode properSubEpisode = null;
            int oncelik = 0;
            int opendEpisode = 0;
            if (episode.SubEpisodes.Count == 1)
            {
                properSubEpisode = episode.SubEpisodes[0];
            }
            else
            {
                foreach (SubEpisode subEpisode in episode.SubEpisodes)
                {   // İptal olmayan ve ortez-protez işleminden oluşmamış SubEpisode lardan uygun olan seçilir. 
                    // Ortez-Protez işleminden oluşan SubEpisode un için Ortez-Protez işleminden başka bir EpisodeAction girmemeli.
                    if (subEpisode.CurrentStateDefID != SubEpisode.States.Cancelled && !(subEpisode.StarterEpisodeAction is OrthesisProsthesisRequest))
                    {

                        //bool IsDailyEpisode = false;
                        //if(subEpisode.LastActiveSubEpisodeProtocol != null && subEpisode.LastActiveSubEpisodeProtocol.MedulaTedaviTuru != null)
                        //    IsDailyEpisode = (subEpisode.LastActiveSubEpisodeProtocol.MedulaTedaviTuru.tedaviTuruKodu.Equals("G") == true);

                        //if (IsDailyEpisode || subEpisode.PatientStatus.Value != SubEpisodeStatusEnum.Daily)
                        //{
                        if (subEpisode.CurrentStateDefID == SubEpisode.States.Opened)// en az bir açık sub episode varsa onu yakalasın ve closedlar onceliğe takılsın diye
                        {
                            if (opendEpisode == 0)
                            {
                                minDate5 = Common.MinDateTime();
                                minDate4 = minDate5;
                                minDate3 = minDate5;
                                minDate2 = minDate5;
                            }
                            opendEpisode = 10;
                        }
                        if (subEpisode.ResSection != null && subEpisode.ResSection.ObjectID == FromResource.ObjectID)// en öncelikli durum Açık,Aynı FromResource sahip ve max dateli olan
                        {
                            if (minDate5 < subEpisode.OpeningDate)
                            {
                                properSubEpisode = subEpisode;
                                minDate5 = subEpisode.OpeningDate;
                                oncelik = 5 + opendEpisode;
                            }
                        }
                        if (oncelik < (5 + opendEpisode))// ikinci öncelikli fromresourceun speciality'si aynı olan max dateli
                        {
                            if (subEpisode.Speciality != null && FromResource.IsSpecialityExistsInResourceSpecialities(subEpisode.Speciality))
                            {
                                if (minDate4 < subEpisode.OpeningDate)
                                {
                                    properSubEpisode = subEpisode;
                                    minDate4 = subEpisode.OpeningDate;
                                    oncelik = 4 + opendEpisode;
                                }
                            }
                        }
                        if (oncelik < (4 + opendEpisode))
                        {
                            if (ProcedureSpeciality != null && subEpisode.Speciality != null && subEpisode.Speciality.ObjectID == ProcedureSpeciality.ObjectID)
                            {
                                if (minDate3 < subEpisode.OpeningDate)// üçüncü öncelikli durum Açık,Aynı Specialy sahip ve max dateli olan
                                {
                                    properSubEpisode = subEpisode;
                                    minDate3 = subEpisode.OpeningDate;
                                    oncelik = 3 + opendEpisode;
                                }
                            }
                        }
                        if (oncelik < (2 + opendEpisode))
                        {
                            if (minDate2 < subEpisode.OpeningDate)
                            {
                                properSubEpisode = subEpisode;
                                minDate2 = subEpisode.OpeningDate;
                                oncelik = 1 + opendEpisode;
                            }
                        }
                        //}
                    }
                }
            }
            if (setMySubEpisode)
            {
                if (setOnlyIfSubEpisodeNull)
                {
                    if (SubEpisode == null)
                    {
                        SubEpisode = properSubEpisode;
                    }
                }
                else
                {
                    SubEpisode = properSubEpisode;
                }

            }
            return properSubEpisode;
        }
        /*
        public virtual System.Collections.Generic.IEnumerable<SubActionProcedure> AccountableSubActionProcedures
        {
            get
            {
                return SubactionProcedures;
                //List <SubActionProcedure> accountableSubActions = new List<SubActionProcedure>();
                //return accountableSubActions;
            }
        }
         */
        /// <summary>
        /// İşlemin Ücretlenen Alt İşlemlerini Döndürür
        /// </summary>
        public virtual List<SubActionProcedure> GetAccountableSubActionProcedures()
        {
            List<SubActionProcedure> myCol = new List<SubActionProcedure>();
            foreach (SubActionProcedure sp in SubactionProcedures)
            {
                if (sp.IsCancelled == false && sp.Eligible == true && sp.ProcedureObject.Chargable == true)
                    myCol.Add(sp);
            }
            return myCol;


        }

        /// <summary>
        /// İşlemin Ücretlenen Malzemelerini Döndürür
        /// </summary>
        public virtual List<SubActionMaterial> GetAccountableSubActionMaterials()
        {

            List<SubActionMaterial> myCol = new List<SubActionMaterial>();
            foreach (BaseTreatmentMaterial tm in TreatmentMaterials)
            {
                if (tm.IsCancelled == false && tm.Eligible == true && tm.Material.Chargable == true)
                    myCol.Add((SubActionMaterial)tm);
            }
            return myCol;

        }

        public virtual EpisodeAction GetCurrentAction()
        {
            return this;
        }

        /// <summary>
        ///Yalnız Enterprise daki scriplerden çağırılabilir bir Cancel kodu; (NOT Ç:kullanıcının cancelled edemiyeceği işlemler koddan cancelled edilebiliyorsa kullanılır)
        /// </summary>
        public override void CancelByCode()
        {
            base.CancelByCode();
            foreach (SubActionProcedure subActionProcedure in SubactionProcedures)
            {
                ((ITTObject)subActionProcedure).Cancel();
            }
            foreach (BaseTreatmentMaterial treatmentMaterial in TreatmentMaterials)
            {
                ((ITTObject)treatmentMaterial).Cancel();
            }
        }



        /// <summary>
        /// Action Cancel edilmek istendiğinde çalıştırılmalı
        /// </summary>
        public override void Cancel()
        {
            CancelSubEpisode();// iptallerden önce ilgili değişiklikler yapılmalı yoksa iptal edilenlerin subepisodeları
            base.Cancel();

            List<TTObject> deletedObject = new List<TTObject>();
            foreach (SubActionProcedure subActionProcedure in SubactionProcedures)
            {
                //                if (((ITTObject)subActionProcedure).IsNew == true)
                //                    deletedObject.Add((TTObject)subActionProcedure);
                //                else
                //                {
                if (subActionProcedure.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    foreach (BaseTreatmentMaterial baseTreatmentMaterial in TreatmentMaterials)
                    {
                        if (baseTreatmentMaterial.StockActionDetail != null)
                        {
                            if (baseTreatmentMaterial.StockActionDetail.StockAction is StockOut)
                            {
                                if (((StockOut)baseTreatmentMaterial.StockActionDetail.StockAction).CurrentStateDefID != StockOut.States.Cancelled)
                                {
                                    ((StockOut)baseTreatmentMaterial.StockActionDetail.StockAction).CurrentStateDefID = StockOut.States.Cancelled;
                                }
                            }
                        }
                    }
                    ((ITTObject)subActionProcedure).Cancel();
                }

                //               }
            }
            foreach (BaseTreatmentMaterial treatmentMaterial in TreatmentMaterials)
            {
                if (((ITTObject)treatmentMaterial).IsNew == true)
                    deletedObject.Add((TTObject)treatmentMaterial);
                else
                {
                    if (treatmentMaterial.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                        ((ITTObject)treatmentMaterial).Cancel();
                }
            }

            int delCount = deletedObject.Count;
            while (delCount > 0)
            {
                delCount--;
                ((ITTObject)deletedObject[delCount]).Delete();

            }

            if (this is IAppointmentWithoutResources)
            {
                foreach (AppointmentWithoutResource appointmentWithoutResource in AppointmentWithoutResources)
                {
                    if (appointmentWithoutResource.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                    {
                        appointmentWithoutResource.CurrentStateDefID = AppointmentWithoutResource.States.Cancelled;
                    }
                }
            }
            CompleteMyUnCompletedAppoinments();

            //Subepisode altında iptal olmamış hiç işlem kalmadıysa Subepisode iptal edilsin.
            if (SubEpisode.CurrentStateDefID != SubEpisode.States.Cancelled)
            {
                if (SubEpisode.EpisodeActions.Select("").Where(x => x.IsCancelled == false && x.CurrentStateDefID != PatientExamination.States.PatientNoShown && x.ObjectID.Equals(ObjectID) == false).Count() <= 0
                    && SubEpisode.SubActionProcedures.Select("").Where(x => x.IsCancelled == false && x.EpisodeAction.ObjectID.Equals(ObjectID) == false).Count() <= 0)
                {
                    SubEpisode.CurrentStateDefID = SubEpisode.States.Cancelled;
                    SubEpisode.CancelSubEpisodeProtocols(); // SubEpisode iptal olurken, SubEpisodeProtocol lerini de iptal eder  
                }
            }
        }

        public virtual void UndoCancel()
        {
        }
        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew == true)
            {
                if (IsOldAction != true)
                {
                    if (RequestDate == null)
                        RequestDate = Common.RecTime();
                    if (ActionDate == null)
                        ActionDate = Common.RecTime();
                }
                FillMyRequiredPropertiesDefaultValues();
            }

        }
        public virtual void FillMyRequiredPropertiesDefaultValues() { }

        /// <summary>
        /// İşlemin Yapıldığı Uzmanlık Dalı Zorunlu ama boş ise Hata verir.
        /// </summary>
        public void ProcedureSpecialityIsRequired()
        {
            if (ProcedureSpeciality == null)
            {
                string[] hataParamList = new string[] { "'İşlemin Yapıldığı Uzmanlık Dalı' " };
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(95, hataParamList));
                // throw new Exception("'İşlemin Yapıldığı Uzmanlık Dalı' alanın boş olamaz");
            }
        }

        /// <summary>
        /// İşlemiYapan Doktor Alanı Zorunlu ama boş ise Hata verir.
        /// </summary>
        public void ProcedureDoctorIsRequired()
        {
            if (ProcedureDoctor == null)
            {
                string[] hataParamList = new string[] { "'İşlemi yapan Doktor' " };
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(95, hataParamList));
                // throw new Exception("'İşlemi yapan Doktor' alanın boş olamaz");
            }
        }

        /// <summary>
        /// İşlemi Başlatmak için Ön Tanı veya Tanı Zorunlu Ama Boş ise Hata Verir.
        /// </summary>
        public void DiagnosisIsRequired(SubEpisode subEpisode)
        {
            if (IsOldAction != true) // Aktarımla gelen işlemlerde kontrol edilmesi gerekmiyor
            {
                if (EpisodeAction.IsFiredByPatientAdmission(this) != true)
                {
                    bool IsHealthCommitAdmission = false;
                    bool IsDispatchExamination = false;

                    if (subEpisode.PatientAdmission.AdmissionType != null)
                    {
                        IsHealthCommitAdmission = subEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.SaglikKurulu;
                        IsDispatchExamination = subEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.HizmetProtokol;
                    }

                    if (IsRequiredPreDiagnosis() && !(subEpisode.IsDiagnosisExists()) && (!IsHealthCommitAdmission) && (!IsDispatchExamination))
                    {
                        string[] hataParamList = new string[] { _objectDef.ApplicationName };
                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(157, hataParamList));
                        //throw new Exception("Vakaya, Ön Tanı veya Tanı girilmeden '" + this._objectDef.Description + "' başlatılamaz .");
                    }
                }
            }
        }

        public static void DiagnosisIsRequired(EpisodeAction episodeAction)
        {
            episodeAction.DiagnosisIsRequired(episodeAction.SubEpisode);
        }

        /// <summary>
        /// Class'a bağlanan RequiredPreDiagnosisAttribute varsa true yoksa false doner
        /// </summary>
        protected bool IsRequiredPreDiagnosis()
        {
            if (IsAttributeExists(typeof(RequiredPreDiagnosisAttribute)) == true)
                return true;
            return false;
        }

        /// <summary>
        /// Class'a bağlanan RequiredSecDiagnosisAttribute varsa true yoksa false doner
        /// </summary>
        protected bool IsRequiredSecDiagnosis()
        {
            if (IsAttributeExists(typeof(RequiredSecDiagnosisAttribute)) == true)
                return true;
            return false;
        }
        /// <summary>
        /// İşlemi Başlatmak için Öntanı Zorunlu Ama Boş ise Hata Verir.
        /// </summary>
        public void PreDiagnosisIsRequired(SubEpisode subEpisode)
        {
            if (IsOldAction != true) // Aktarımla gelen işlemlerde kontrol edilmesi gerekmiyor
            {
                if (EpisodeAction.IsFiredByPatientAdmission(this) != true)
                {//todo bg
                    bool IsHealthCommitAdmission = false;
                    if (subEpisode.PatientAdmission.AdmissionType != null)
                        IsHealthCommitAdmission = subEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.SaglikKurulu;
                    /*   || subEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.TemporaryHealthCommitteExamination
                       || subEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.HealthCommitteeOfProffesors
                       || subEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.PeriodicExamination
                       || subEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.PortorExamination
                       || subEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.MaterialAdmission;*/
                    if (IsRequiredPreDiagnosis() && !(subEpisode.IsPreDiagnosisExists()) && (!IsHealthCommitAdmission))
                    {
                        string[] hataParamList = new string[] { _objectDef.ApplicationName };
                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(157, hataParamList));
                        //throw new Exception("Vakaya, Ön Tanı  girilmeden '" + this._objectDef.Description + "' başlatılamaz .");
                    }
                }
            }
        }

        public void PreDiagnosisIsRequired()
        {
            PreDiagnosisIsRequired(SubEpisode);
        }

        public static string GetProcedureDefinitionNames(string objectDefName)
        {
            string procedureDefNames = "";
            TTObjectDef objDef = null;
            TTObjectDefManager.Instance.ObjectDefs.TryGetValue(objectDefName, out objDef);
            if (objDef != null)
            {
                if (objDef.IsOfType(typeof(EpisodeAction).Name.ToUpperInvariant()))
                {
                    foreach (TTObjectRelationSubtypeDef rSubType in objDef.AllChildRelationsSubtypeDefs)
                    {
                        if (rSubType.RelationDef.ParentObjectDef.IsOfType(typeof(EpisodeAction).Name.ToUpperInvariant()) && rSubType.RelationDef.ChildObjectDef.IsOfType(typeof(SubActionProcedure).Name.ToUpperInvariant()))
                        {
                            if (rSubType.ChildObjectDef.AllParentRelationDefs["ProcedureObject"].ParentObjectDef.Name.ToUpperInvariant() != "PROCEDUREDEFINITION")
                            {
                                if (procedureDefNames != "")
                                    procedureDefNames = procedureDefNames + ",";
                                procedureDefNames = procedureDefNames + "'" + rSubType.ChildObjectDef.AllParentRelationDefs["ProcedureObject"].ParentObjectDef.Name.ToUpperInvariant() + "'";
                            }
                            foreach (TTDefinitionManagement.TTObjectRelationSubtypeDef pi in rSubType.ChildObjectDef.AllParentRelationsSubtypeDefs.Values)
                            {
                                if (Common.IsBaseOfInheritedObject(pi.ParentObjectDef, TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"]))
                                {
                                    if (procedureDefNames != "")
                                        procedureDefNames = procedureDefNames + ",";
                                    procedureDefNames = procedureDefNames + "'" + pi.ParentObjectDef.Name.ToUpperInvariant() + "'";
                                }
                            }
                            foreach (TTRelationParentRestrictions rr in rSubType.ChildObjectDef.ParentRelationRestrictions.Values)
                            {
                                foreach (TTObjectDef od in rr.RestrictedObjectDefs)
                                {
                                    if (Common.IsBaseOfInheritedObject(od, TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"]))
                                    {
                                        if (procedureDefNames != "")
                                            procedureDefNames = procedureDefNames + ",";
                                        procedureDefNames = procedureDefNames + "'" + od.Name.ToUpperInvariant() + "'";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return procedureDefNames;
        }

        /// <summary>
        /// İşlemi Başlatmak için tanı Zorunlu Ama Boş ise Hata Verir.
        /// </summary>
        public void SecDiagnosisIsRequired(SubEpisode subEpisode)
        {
            if (IsRequiredSecDiagnosis() && !(subEpisode.IsSecDiagnosisExists()))
            {
                string[] hataParamList = new string[] { _objectDef.ApplicationName };
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(158, hataParamList));
                //throw new Exception("Vakaya, Kesin Tanı  girilmeden '" + this._objectDef.Description + "' başlatılamaz .");
            }
        }
        public void SecDiagnosisIsRequired()
        {
            SecDiagnosisIsRequired(SubEpisode);
        }

        /// <summary>
        /// İşlem Hataya Bağlanmadan Önce Gerekli Kontrolleri Çalıştırır
        /// </summary>
        /// <param name="episode"></param>
        protected virtual void BeforeSetSubEpisode(SubEpisode subEpisode)
        {
            // yeni süreçden (yeni kabul harici) başlatılan işlemler hasta kabul tamam olmadan başlatılamaz
            if (subEpisode.PatientStatus == SubEpisodeStatusEnum.Outpatient && subEpisode.PatientAdmission == null)
            {
                throw new TTUtils.TTException(SystemMessage.GetMessage(159));
                //throw new Exception("İşlemin başlatılacağı vakaya  ait 'Hasta Kabul' işlemi bulunmamakdadır.İşlem başlatılamaz ");
            }

            //todo bg
            //ITTObject ttObject = (ITTObject)this;
            //if (!(this is ImportantMedicalInformation) && !(this is InfectiousIllnesesInformation))
            //{
            //    if (ttObject.IsNew)
            //    {
            //        if (this.PatientAdmission == null)// yeni kabul ile kabul edilen işlemeler
            //        {
            //            if (subEpisode.PatientAdmission.PAStatus == PAStatusEnum.Sirada)
            //                throw new TTUtils.TTException(SystemMessage.GetMessage(160));
            //            //throw new Exception("Hasta Kabul tamamlanmadan yeni işlem başlatılamaz.");
            //        }
            //    }
            //}
            DiagnosisIsRequired(subEpisode);
        }



        public static List<Resource> GetAvailableUserResourcesByAllocation(Episode episode, EpisodeAction episodeAction)
        {
            return episodeAction.AvailableUserResourcesByAllocation(episode);
        }

        /// <summary>
        /// çağırıldığı EpisodeActionda RequiredAllocation Attribute'ü varsa Episod'unun Allocationında yer alan  Resourceları döndürür.
        /// </summary>
        /// <param name="userResouces"></param>
            //  public ArrayList AvailableUserResourcesByAllocation (UserResource.ChildUserResourceCollection userResouces)
        public List<Resource> AvailableUserResourcesByAllocation(Episode episode)
        {
            List<Resource> availableUserResources = new List<Resource>();
            if (IsRequiredAllocation() == true && EpisodeAction.IsFiredByPatientAdmission(this) == false && (!(MasterAction is HealthCommittee)))//Hasta Kabulden başlatılan işlemler için allocationa gerek yok.
            {
                // AŞAĞIDAKİ COMMENTİ SİLME...Kullanıcının bağlı olduğu herhangi bir birimin uzmanlık dallı allaocationlara uygunsa
                //                List<string> specialityList = new List<string>();
                //                foreach (Allocation allocation in episode.Allocations)
                //                {
                //                    if (allocation.Speciality != null)
                //                    {
                //                        specialityList.Add(allocation.Speciality.ObjectID.ToString());
                //                    }
                //                }
                //                if (specialityList.Count > 0)
                //                {
                //                    int enableType = 1;
                //                    if (episode.PatientStatus == PatientStatusEnum.Inpatient)
                //                        enableType = 0;
                //                    foreach (ResSection resource in ResSection.GetResourceOfUserBySpeciality(this.ObjectContext, Common.CurrentResource.ObjectID, enableType, specialityList.ToArray()))
                //                    {
                //                            availableUserResources.Add(resource);
                //                    }
                //                }

                // Sadece kullanıcının seçdiği birimin uzmanlık dallı allaocationlara uygunsa istek yapabilir
                if (episode.PatientStatus == PatientStatusEnum.Inpatient)
                {
                    //if (episode.HasAllocation(Common.CurrentResource.SelectedInPatientResource))// TODO Nida Allacationlar şimdilik comentlendi
                    //{
                    availableUserResources.Add(Common.CurrentResource.SelectedInPatientResource);
                    // }
                }
                else
                {
                    // if (episode.HasAllocation(Common.CurrentResource.SelectedOutPatientResource))
                    // {
                    availableUserResources.Add(Common.CurrentResource.SelectedOutPatientResource);
                    // }
                }

                //                if (episode.PatientStatus == PatientStatusEnum.Inpatient)
                //                {
                //                    foreach (ResSection resource in Common.CurrentResource.InPatientUserResources)
                //                    {
                //                        if (episode.HasAllocation(resource))
                //                        {
                //                            availableUserResources.Add(resource);
                //                        }
                //                    }
                //                }
                //                else
                //                {
                //                    foreach (ResSection resource in Common.CurrentResource.OutPatientUserResources)
                //                    {
                //                        if (episode.HasAllocation(resource))
                //                        {
                //                            availableUserResources.Add(resource);
                //                        }
                //                    }
                //                }
                return availableUserResources;
            }
            else
            {
                if (episode.PatientStatus == PatientStatusEnum.Outpatient)
                {
                    return Common.CurrentResource.OutPatientUserResources;
                }
                else
                {
                    return Common.CurrentResource.InPatientUserResources;
                }
            }
        }
        /// <summary>
        /// İşlemi İsteyen Birimin Atamasını Yapar
        /// </summary>
        /// <param name="episode"></param>
        public virtual void SetFromResource(Episode episode)
        {

            if (FromResource == null)
            {
                if (episode != null)
                {
                    if (Common.CurrentResource != null)
                    {
                        if (episode.PatientStatus == PatientStatusEnum.Inpatient)
                        {
                            if (Common.CurrentResource.SelectedInPatientResource != null)
                            {
                                if (IsRequiredAllocation() == true)
                                {
                                    if (episode.HasAllocation((ResSection)Common.CurrentResource.SelectedInPatientResource) || EpisodeAction.IsFiredByPatientAdmission(this))
                                    {
                                        FromResource = (ResSection)Common.CurrentResource.SelectedInPatientResource;
                                        return;
                                    }
                                }
                                else
                                {
                                    FromResource = (ResSection)Common.CurrentResource.SelectedInPatientResource;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (Common.CurrentResource.SelectedOutPatientResource != null)
                            {
                                if (IsRequiredAllocation() == true)
                                {
                                    if (episode.HasAllocation((ResSection)Common.CurrentResource.SelectedOutPatientResource) || EpisodeAction.IsFiredByPatientAdmission(this))
                                    {
                                        FromResource = (ResSection)Common.CurrentResource.SelectedOutPatientResource;
                                        return;
                                    }
                                    //                                    if(this.ActionType == ActionTypeEnum.Surgery && episode.PatientAdmission.ReasonForAdmission.Code == 27) ///günübirlik kabul ile ameliyat başlamış ise
                                    //                                    {
                                    //                                        this.FromResource = (ResSection)Common.CurrentResource.SelectedOutPatientResource;
                                    //                                        return;
                                    //                                    }
                                }
                                else
                                {
                                    FromResource = (ResSection)Common.CurrentResource.SelectedOutPatientResource;
                                    return;
                                }
                            }
                        }


                        var availableUserResourcesByAllocation = AvailableUserResourcesByAllocation(episode);

                        if (availableUserResourcesByAllocation.Count < 1)
                        {
                            throw new TTUtils.TTException(SystemMessage.GetMessage(145));
                            //throw new Exception("Bağlı olduğunuz birimler, bu vakada bu işlemi yapmak için uygun değildir.");
                        }
                        else if (availableUserResourcesByAllocation.Count == 1)
                        {
                            FromResource = (ResSection)availableUserResourcesByAllocation[0];
                        }
                    }
                    else
                    {
                        //YAPILACAKLAR// Kullanıcılar tanımlanmaya başladığında Sil yerine KUllanıcı bulunmadı hatası veren kod koy //-----
                        BindingList<ResDepartment> resources = ObjectContext.QueryObjects<ResDepartment>();
                        if (resources.Count == 0)
                        {
                            throw new TTUtils.TTException(SystemMessage.GetMessage(161));
                            //throw new Exception("Hiç Kaynak Tanımlanmamış.");
                        }

                        FromResource = resources[0];
                        if (resources.Count > 1)
                            MasterResource = resources[1];
                        else
                            MasterResource = resources[0];
                        //------
                    }
                }
            }
        }
        /// <summary>
        /// İşlem için "İşlem Kayna Eşleştirme" tanım ekranından işlemi yapacak birim tanımlandı ise Tanımlanan Değerler Döndürür
        /// </summary>
        /// <param name="context"></param>
        /// <param name="actionType"></param>
        /// <returns></returns>
        public static List<ResSection> AcionDefualtMasterResources(TTObjectContext context, ActionTypeEnum? actionType, EpisodeAction episodeAction)
        {
            IList actionDefaultMasterResources;
            List<ResSection> resources = new List<ResSection>();
            if (actionType == null)
                actionType = episodeAction.ActionType;
            if (actionType != ActionTypeEnum.UnDefinedAction)
            {
                actionDefaultMasterResources = ActionDefaultMasterResourceDefinition.GetByActionType(context, (ActionTypeEnum)actionType);
                if (actionDefaultMasterResources.Count > 0)
                {
                    foreach (ActionDefaultMasterResourceDefinition defualtMasterResource in actionDefaultMasterResources)
                    {
                        if (defualtMasterResource.MasterResources.Count > 0)
                        {
                            TTObjectDef objectDef = Common.GetObjectDefByActionType((ActionTypeEnum)actionType);
                            if (objectDef != null)
                            {
                                ArrayList limitedMasterResourceTypeList = episodeAction.LimitedMasterResourceTypes(objectDef);
                                foreach (ActionDefaultMasterResourceGrid dMRG in defualtMasterResource.MasterResources)
                                {
                                    if (limitedMasterResourceTypeList.Contains(dMRG.Resource.ObjectDef.Name) || limitedMasterResourceTypeList.Count < 1)
                                    {
                                        resources.Add((ResSection)dMRG.Resource);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return resources;
        }

        /// <summary>
        /// İşlemi Gerçekleştirecek Birimin Atamasını Yapar
        /// </summary>
        /// <param name="episode"></param>
        /// <param name="notSetNull"></param>
        public virtual void SetMasterResource(Episode episode, bool notSetNull)
        {
            //ActionDefaultMasterResourceDefinition tanım ekranında defualt masterresource tanımlandı ise..

            if (MasterResource == null)
            {

                List<ResSection> actionDefualtMasterResourcesList = AcionDefualtMasterResources(ObjectContext, ActionType, this);
                if (actionDefualtMasterResourcesList.Count == 1)
                {
                    MasterResource = (ResSection)actionDefualtMasterResourcesList[0];
                    return;
                }

                ArrayList limitedMasterResourceTypeList = EpisodeAction.LimitedMasterResourceTypes(this);
                if (FromResource != null)
                {
                    //if (actionDefualtMasterResourcesList.Count < 1 || actionDefualtMasterResourcesList.Contains(this.FromResource))
                    if (actionDefualtMasterResourcesList.Count < 1)
                    {
                        if (limitedMasterResourceTypeList.Count < 1 || limitedMasterResourceTypeList.Contains(FromResource.ObjectDef.Name))
                        {
                            MasterResource = FromResource;
                            return;
                        }
                    }
                }
                // Form açıp kapandıktan sonra hala seçilmediyse ilk bulduğunu ata
                if (notSetNull)
                {
                    if (actionDefualtMasterResourcesList.Count > 1)
                    {
                        MasterResource = (ResSection)actionDefualtMasterResourcesList[0];
                        return;
                    }
                    string[] hataParamList = new string[] { ObjectDef.Name };
                    throw new TTUtils.TTException(SystemMessage.GetMessageV3(162, hataParamList));
                    //throw new Exception("Bağlı olduğunuz birimler , bu vakada " + this.ObjectDef.Name + " işlemini yapmaya uygun değildir.");
                }
            }

        }



        /// <summary>
        /// bulunduğunuz işlemi başlatılabileceği Resource tiplerini  string Array olark döndürür.
        /// </summary>
        public static ArrayList LimitedMasterResourceTypes(EpisodeAction episodeAction)
        {
            ArrayList typesArrayList = new ArrayList();

            if (episodeAction.IsAttributeExists(typeof(LimitedMResourceTypeAttribute)) == true)
            {
                string typesString = episodeAction.ObjectDef.Attributes["LIMITEDMRESOURCETYPEATTRIBUTE"].Parameters["LimitedResourceType"].Value.ToString();
                char[] splitter = { ',' };
                foreach (string typeS in typesString.Split(splitter))
                {
                    typesArrayList.Add(typeS.ToUpperInvariant());
                }

            }
            return typesArrayList;
        }

        /// <summary>
        /// verdiğiniz objenin başlatılabileceği Resource tiplerini  string Array olark döndürür.
        /// </summary>
        public ArrayList LimitedMasterResourceTypes(TTObjectDef ttObjectDef)
        {
            ArrayList typesArrayList = new ArrayList();

            if (Common.IsAttributeExistsV2(typeof(LimitedMResourceTypeAttribute), ttObjectDef) == true)
            {
                string typesString = ttObjectDef.Attributes["LIMITEDMRESOURCETYPEATTRIBUTE"].Parameters["LimitedResourceType"].Value.ToString();
                char[] splitter = { ',' };
                foreach (string typeS in typesString.Split(splitter))
                {
                    typesArrayList.Add(typeS.ToUpperInvariant());
                }

            }
            return typesArrayList;
        }


        /// <summary>
        /// Class'a bağlanan SetProcedureSpecialtyByAttribute yoksa MASTERRESOURCE varda parametre değeri ne ise o döner.
        /// </summary>
        public static string SetProcedureSpecialtyBy(Guid objectDefID)
        {
            TTObjectDef objectDef = null;

            if (TTObjectDefManager.Instance.ObjectDefs.TryGetValue(objectDefID, out objectDef))
            {

                if (Common.IsAttributeExistsV2(typeof(SetProcedureSpecialtyByAttribute), objectDef) == false)
                {
                    return "MASTERRESOURCE";
                }
                else
                {
                    return objectDef.Attributes["SETPROCEDURESPECIALTYBYATTRIBUTE"].Parameters["By"].Value.ToString();
                }
            }
            else
                return null;
        }
        public string SetProcedureSpecialtyBy()
        {
            if (IsAttributeExists(typeof(SetProcedureSpecialtyByAttribute)) == false)
            {
                return "MASTERRESOURCE";
            }
            else
            {
                return ObjectDef.Attributes["SETPROCEDURESPECIALTYBYATTRIBUTE"].Parameters["By"].Value.ToString();
            }
        }


        public ResSection GetResourceOfSepeciality()
        {
            if (SetProcedureSpecialtyBy().ToUpper() == "MASTERRESOURCE")
                return MasterResource;
            else if (SetProcedureSpecialtyBy().ToUpper() == "FROMRESOURCE")
                return FromResource;
            return null;
        }


        /// <summary>
        /// Class'a bağlanan RequiredAllocationAttribute varsa true yoksa false doner
        /// </summary>
        protected bool IsRequiredAllocation()
        {
            //if (this.IsAttributeExists(typeof(RequiredAllocationAttribute)) == true)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            //todo bg allocationlar açılması gerektiğinde açılacak
            return false;
        }


        /// <summary>
        /// İşlemin Başngıç Adımını Döndürür
        /// </summary>
        /// <param name="episode"></param>
        protected void CheckEpisodeStateToOpenAction(Episode episode)
        {
            if (IsOldAction != true)
            {
                if ((IsEpisodeStatesIgnored() == false))
                {
                    if ((episode.CurrentStateDefID == Episode.States.ClosedToNew) || (episode.CurrentStateDefID == Episode.States.Closed))
                    {
                        string[] hataParamList = new string[] { episode.CurrentStateDef.DisplayText };
                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(163, hataParamList));
                        //throw new TTException("Vaka " + episode.CurrentStateDef.DisplayText + " durumda. Yeni işlem başlatılamaz.");
                    }
                }
            }
        }

        public TTUtils.Entities.RuleValidateResultDto CheckSutRules(bool throwException)
        {
            string sutRuleEngineEnabled = SystemParameter.GetParameterValue("SUT_RULE_ENGINE_ENABLED", string.Empty);

            if (sutRuleEngineEnabled != "TRUE")
                return null;

            List<TTUtils.Entities.ProcedureEntryDto> procedureEntries = new List<TTUtils.Entities.ProcedureEntryDto>();

            List<SubActionProcedure> subActionProcedureList = new List<SubActionProcedure>();

            DateTime? ruleStartDate = null;
            string ruleStartDateParam = SystemParameter.GetParameterValue("SUT_RULE_ENGINE_STARTDATE", null);
            if (!string.IsNullOrWhiteSpace(ruleStartDateParam))
            {
                DateTime startDate;
                if (DateTime.TryParse(ruleStartDateParam, out startDate))
                    ruleStartDate = startDate;
            }

            foreach (SubActionProcedure subActionProcedure in SubactionProcedures)
            {
                if (subActionProcedure.ProcedureObject == null)
                    continue;

                if (subActionProcedure.IsCancelled)
                    continue;

                ITTObject subActionProcedureObject = subActionProcedure as ITTObject;
                if (!subActionProcedureObject.IsNew)
                    continue;

                if (subActionProcedure.SUTRuleStatus == SutRuleEngineStatus.Passed || subActionProcedure.SUTRuleStatus == SutRuleEngineStatus.RuleViolationIgnored)
                    continue;

                DateTime entryDate = subActionProcedure.ActionDate ?? DateTime.Now;

                if (ruleStartDate.HasValue && entryDate < ruleStartDate.Value)
                    continue;

                TTUtils.Entities.ProcedureEntryDto procedureEntry = new TTUtils.Entities.ProcedureEntryDto();
                procedureEntry.SubActionProcedureId = subActionProcedure.ObjectID;
                procedureEntry.ProcedureCode = subActionProcedure.ProcedureObject.Code;
                procedureEntry.EntryQuantity = (decimal)(subActionProcedure.Amount ?? 1);
                procedureEntry.EntryDate = entryDate;
                procedureEntries.Add(procedureEntry);

                subActionProcedureList.Add(subActionProcedure);
            }

            if (subActionProcedureList.Count == 0)
                return null;

            //string settingName = "SUTRULECHECKERSERVERIP";
            //string serverIpAddress = TTObjectClasses.SystemParameter.GetParameterValue(settingName, string.Empty);

            IRuleCheckEngine service = SutRuleServiceFactory.Instance;
            object patientId = Episode.Patient.ObjectID;
            object episodeId = Episode.ObjectID;

            TTUtils.Entities.RuleValidateResultDto validateResults = service.ValidateRules(patientId, episodeId, procedureEntries.ToArray(), null);

            bool ruleViolationExists = false;

            if (validateResults != null && validateResults.Messages.Count > 0)
            {
                ruleViolationExists = true;
            }

            foreach (SubActionProcedure subActionProcedure in subActionProcedureList)
            {
                subActionProcedure.SUTRuleStatus = SutRuleEngineStatus.Passed;

                foreach (TTUtils.Entities.RuleViolateMessage ruleViolateMessage in validateResults.Messages)
                {
                    if (ruleViolateMessage.DetailId1 != null && subActionProcedure.ObjectID != null)
                    {
                        if (subActionProcedure.ProcedureObject.SUTCode == (string)ruleViolateMessage.DetailId1)
                        {
                            subActionProcedure.SUTRuleStatus = SutRuleEngineStatus.Violated;
                        }
                    }

                    if (ruleViolateMessage.DetailId2 != null && subActionProcedure.ObjectID != null)
                    {
                        if (subActionProcedure.ProcedureObject.SUTCode == (string)ruleViolateMessage.DetailId2)
                        {
                            subActionProcedure.SUTRuleStatus = SutRuleEngineStatus.Violated;
                        }
                    }

                }
            }

            if (throwException)
            {
                if (ruleViolationExists)
                    throw new TTSutRuleEngineException(validateResults.Messages.ToArray());
            }

            return validateResults;
        }

        public void SetSutRulesIgnored(TTUtils.Entities.RuleViolateMessageDto[] validateResults)
        {

            foreach (SubActionProcedure subActionProcedure in SubactionProcedures)
            {
                if (subActionProcedure.SUTRuleStatus != SutRuleEngineStatus.Violated)
                    continue;

                foreach (TTUtils.Entities.RuleViolateMessageDto ruleViolateMessage in validateResults)
                {
                    if (ruleViolateMessage.DetailId1 != null && subActionProcedure.ObjectID != null)
                    {
                        if (subActionProcedure.ObjectID == new Guid((string)ruleViolateMessage.DetailId1))
                        {
                            subActionProcedure.SUTRuleStatus = SutRuleEngineStatus.RuleViolationIgnored;
                        }
                    }

                    if (ruleViolateMessage.DetailId2 != null && subActionProcedure.ObjectID != null)
                    {
                        if (subActionProcedure.ObjectID == new Guid((string)ruleViolateMessage.DetailId2))
                        {
                            subActionProcedure.SUTRuleStatus = SutRuleEngineStatus.RuleViolationIgnored;
                        }
                    }

                }
            }
        }




        /*public bool IgnoreEpisodeStateOnUpdate
        {
            get
            {
                return SessionExtension.GetFromSession<bool>("IgnoreEpisodeStateOnUpdate");
            }
            set
            {
                SessionExtension.AddToSession<bool>("IgnoreEpisodeStateOnUpdate",value);
            }
        } */
        /// <summary>
        /// Episode un statei Kapalı ise işlemin devam ettirilememesini sağlar.PreUpdatede kullanılmalı
        /// </summary>
        protected void CheckEpisodeStateToUpdateAction()
        {
            if ((IsEpisodeStatesIgnored() == false && IgnoreEpisodeStateOnUpdate == false))// null gelince de girmiyor yapı değişirken düzeltilmeli
            {
                if (!IsLastActionInEpisode())
                {
                    if (Episode.CurrentStateDefID == Episode.States.Closed)
                    {
                        throw new TTUtils.TTException(SystemMessage.GetMessage(164));
                        //throw new TTException("Vaka kapalı durumda. İşlem devam ettirilemez.");
                    }
                }
            }
        }

        /// <summary>
        /// true dönerse işlem Episode un state ine bakmaksızın başlatılabilir.
        /// </summary>
        /// <returns></returns>
        public bool IsEpisodeStatesIgnored()
        {
            if (IsAttributeExists(typeof(IgnoreEpisodeStatesAttribute)) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Class'a bağlanan EpisodeExclusiveAttribute varsa episodeda başlatılan tipde bir işlem aranır. EpisodeExclusiveType paremetre değeri, OnlyUncompleted ise  tamamlanmamış ;EvenComplete ise hem tamamlanmış hem tamamlanmamış  işlem aranır varise işlemin başlatılması engellenir
        /// </summary>
        protected void CheckEpisodeExclusive(Episode episode)
        {
            if (IsAttributeExists(typeof(EpisodeExclusiveAttribute)) == true)
            {
                foreach (EpisodeAction ea in episode.EpisodeActions)
                {
                    if (ea.ObjectDef == ObjectDef && !ea.IsCancelled && ea != this)
                    {
                        if (EpisodeExclusiveType() == ExclusiveTypeEnum.OnlyUncompleted)
                        {
                            if (ea.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                            {
                                string[] hataParamList = new string[] { ObjectDef.ApplicationName.ToString(), ObjectDef.ApplicationName.ToString() };
                                throw new TTUtils.TTException(SystemMessage.GetMessageV3(165, hataParamList));
                                //throw new TTException("Aynı vakada açık olan " + this.ObjectDef.Description.ToString() + " işlemi tamamlanmadan yeni bir " + this.ObjectDef.Description.ToString() + " işlemi başlatılamaz.");
                            }
                        }
                        else // ExclusiveTypeEnum.EvenComleted
                        {
                            string[] hataParamList = new string[] { ObjectDef.ApplicationName.ToString() };
                            throw new TTUtils.TTException(SystemMessage.GetMessageV3(166, hataParamList));
                            //throw new TTException("Aynı vakada birden fazla " + this.ObjectDef.Description.ToString() + " işlemi başlatılamaz.");
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Bağlı EpisodeExclusiveAttribute'unun  EpisodeExclusiveType değerini döndürür
        /// </summary>
        /// <returns>ExclusiveTypeEnum</returns>
        protected ExclusiveTypeEnum EpisodeExclusiveType()
        {
            if (IsAttributeExists(typeof(EpisodeExclusiveAttribute)) == true)
            {
                if (ObjectDef.Attributes["EPISODEEXCLUSIVEATTRIBUTE"].Parameters["EpisodeExclusiveType"].Value.ToString() == "0")
                {
                    return ExclusiveTypeEnum.OnlyUncompleted;
                }
                else
                {
                    return ExclusiveTypeEnum.EvenCompleted;
                }
            }
            else
            {
                string[] hataParamList = new string[] { "EpisodeExclusiveAttributeu", "EpisodeExclusive" };
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(167, hataParamList));
                //throw new TTException("İşlemde  EpisodeExclusiveAttributeu olmadığı halde EpisodeExclusive değeri çekilmek isteniyor.Lütfen bilgi işleme haber veriniz.");
            }
        }

        /// <summary>
        /// Class'a bağlanan EpisodeExclusiveAttribute varsa hastanın tüm episodelarında başlatılan tipde bir işlem aranır. EpisodeExclusiveType paremetre değeri, OnlyUncompleted ise  tamamlanmamış ;EvenComplete ise hem tamamlanmış hem tamamlanmamış  işlem aranır varsa işlemin başlatılması engellenir
        /// </summary>
        protected virtual void CheckPatientExclusive(Episode episode)
        {
            if (IsAttributeExists(typeof(PatientExclusiveAttribute)) == true)
            {
                foreach (Episode ep in episode.Patient.Episodes)
                {
                    foreach (EpisodeAction ea in ep.EpisodeActions)
                    {
                        if (ea.ObjectDef == ObjectDef && !ea.IsCancelled && ea != this)
                        {
                            if (PatientExclusiveType() == ExclusiveTypeEnum.OnlyUncompleted)
                            {
                                if (ea.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                                {
                                    string[] hataParamList = new string[] { ea.CurrentStateDef.DisplayText, ((DateTime)ea.ActionDate).ToShortDateString(), ObjectDef.ApplicationName.ToString(), ObjectDef.ApplicationName.ToString() };
                                    throw new TTUtils.TTException(SystemMessage.GetMessageV3(168, hataParamList));

                                    //Bu hastada,  {0} adımındaki   {1} tarihli   {2}   işlemi tamamlanmadan ya da iptal edilmeden  yeni bir  {3}  işlemi başlatılamaz.
                                }
                            }
                            else // ExclusiveTypeEnum.EvenComleted
                            {
                                string[] hataParamList = new string[] { ObjectDef.ApplicationName.ToString() };
                                throw new TTUtils.TTException(SystemMessage.GetMessageV3(169, hataParamList));
                                //throw new TTException("Aynı hastada birden fazla " + this.ObjectDef.Description.ToString() + " işlemi başlatılamaz.");
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Bağlı PatientExclusiveAttribute'unun  PatientExclusiveType değerini döndürür
        /// </summary>
        /// <returns>ExclusiveTypeEnum</returns>
        protected ExclusiveTypeEnum PatientExclusiveType()
        {
            if (IsAttributeExists(typeof(PatientExclusiveAttribute)) == true)
            {
                if (ObjectDef.Attributes["PATIENTEXCLUSIVEATTRIBUTE"].Parameters["PatientExclusiveType"].Value.ToString() == "0")
                {
                    return ExclusiveTypeEnum.OnlyUncompleted;
                }
                else
                {
                    return ExclusiveTypeEnum.EvenCompleted;
                }
            }
            else
            {
                string[] hataParamList = new string[] { "PatientExclusiveAttributeu", "PatientExclusive" };
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(167, hataParamList));
                // throw new TTException("İşlemde  PatientExclusiveAttributeu olmadığı halde PatientExclusive değeri çekilmek isteniyor.Lütfen bilgi işleme haber veriniz.");
            }
        }


        /// <summary>
        /// Hastanın durumuna göre işlemin başlatılıp başlatılamayacağı kontrol edilir.
        /// </summary>
        public void CheckRequiredPatientStatus(Episode episode)
        {
            if (IsAttributeExists(typeof(RequiredPatientStatusAttribute)) == true)
            {

                string requiredPatientStatus = ObjectDef.Attributes["REQUIREDPATIENTSTATUSATTRIBUTE"].Parameters["RequiredPatientStatus"].Value.ToString();
                switch (requiredPatientStatus)
                {
                    case "0": //Ayaktan hasta
                        if ((episode.PatientStatus == PatientStatusEnum.Inpatient) || (episode.PatientStatus == PatientStatusEnum.Discharge) || (episode.PatientStatus == PatientStatusEnum.PreDischarge))
                        {
                            string[] hataParamList = new string[] { "ayaktan" };
                            throw new TTUtils.TTException(SystemMessage.GetMessageV3(170, hataParamList));
                            //throw new TTException("Bu işlem sadece ayaktan hastalar için başlatılabilir.");
                        }
                        break;
                    case "1": //Yatan hasta
                        if ((episode.PatientStatus == PatientStatusEnum.Outpatient) || (episode.PatientStatus == PatientStatusEnum.Discharge) || (episode.PatientStatus == PatientStatusEnum.PreDischarge))
                        {
                            string[] hataParamList = new string[] { "yatan" };
                            throw new TTUtils.TTException(SystemMessage.GetMessageV3(170, hataParamList));
                            //throw new TTException("Bu işlem sadece yatan hastalar için başlatılabilir.");
                        }
                        break;
                    case "2": //Taburcu
                        if ((episode.PatientStatus == PatientStatusEnum.Outpatient) || (episode.PatientStatus == PatientStatusEnum.Inpatient))
                        {
                            string[] hataParamList = new string[] { TTUtils.CultureService.GetText("M26970", "taburcu edilmiş") };
                            throw new TTUtils.TTException(SystemMessage.GetMessageV3(170, hataParamList));
                            //throw new TTException("Bu işlem sadece taburcu edilmiş hastalar için başlatılabilir.");
                        }
                        break;
                    case "3": //Ayaktan ya da Yatan Hasta
                        if ((episode.PatientStatus == PatientStatusEnum.Discharge || episode.PatientStatus == PatientStatusEnum.PreDischarge) && episode.LastSubEpisode.PatientStatus != SubEpisodeStatusEnum.Daily)
                        {
                            string[] hataParamList = new string[] { TTUtils.CultureService.GetText("M25212", "ayaktan veya yatan") };
                            throw new TTUtils.TTException(SystemMessage.GetMessageV3(170, hataParamList));
                            //throw new TTException("Bu işlem sadece ayaktan veya yatan hastalar için başlatılabilir.");
                        }
                        break;
                    case "4": //Ayaktan ya da Taburcu
                        if (episode.PatientStatus == PatientStatusEnum.Inpatient)
                        {
                            string[] hataParamList = new string[] { TTUtils.CultureService.GetText("M26971", "taburcu edilmiş veya ayaktan") };
                            throw new TTUtils.TTException(SystemMessage.GetMessageV3(170, hataParamList));
                            //throw new TTException("Bu işlem sadece taburcu edilmiş veya ayaktan hastalar için başlatılabilir.");
                        }
                        break;
                    case "5": //Yatan ya da Taburcu
                        if (episode.PatientStatus == PatientStatusEnum.Outpatient)
                        {
                            string[] hataParamList = new string[] { TTUtils.CultureService.GetText("M26972", "taburcu edilmiş veya yatan") };
                            throw new TTUtils.TTException(SystemMessage.GetMessageV3(170, hataParamList));
                            // throw new TTException("Bu işlem sadece taburcu edilmiş veya yatan hastalar için başlatılabilir.");
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// MasterActioID'si çağıran actionun ActionID'si ile aynı olan bütün action collectionunu ArrayList veritipi için doldurur.
        /// </summary>
        public static ArrayList GetLinkedEpisodeActions(EpisodeAction episodeActionParam)
        {

            ArrayList actionList = new ArrayList();

            foreach (EpisodeAction episodeAction in episodeActionParam.Episode.EpisodeActions)
            {

                if (episodeAction.MasterAction != null)
                {
                    if (episodeAction.MasterAction.ID == episodeActionParam.ID)
                    {
                        actionList.Add(episodeAction);
                    }
                }
            }
            return actionList;
        }




        /// <summary>
        /// HospitalsUnitsGrid gridini içeren actionlara base yapılamadığı için ReasonForExamination tanımındaki departmentları
        ///  HospitalsUnitsGrid'e doldurmak için ortak metod ayazıldı metod içindeki metodlar ilgili classlarda override edildi
        /// </summary>
        public virtual void FillHospitalsUnitsGridDueToReasonForExamination()
        {
            if (MyReasonForExamination() != null)
            {
                ClearHospitalsUnits();
                AddRequesterHospitalsUnits();
                foreach (HospitalsUnitsDefinitionGrid hospitalsUnitsDefinitionGrid in MyReasonForExamination().HospitalsUnits)
                {
                    if (IsHospitalsUnitsAllowedToBeAppended(hospitalsUnitsDefinitionGrid) == true)
                    {
                        AddHospitalsUnits(hospitalsUnitsDefinitionGrid);
                    }
                }
            }
        }


        /// <summary>
        ///  ReasonForExamination'ı olan classlarda override ediliyor
        /// </summary>
        /// <returns></returns>
        protected virtual ReasonForExaminationDefinition MyReasonForExamination()
        {
            return null;
        }

        /// <summary>
        /// HospitalsUnitsGrid'i olan classlarda override ediliyor
        /// </summary>
        /// <param name="examinationDepartmentsHospitalGrid"></param>
        protected virtual void AddHospitalsUnits(HospitalsUnitsDefinitionGrid hospitalsUnitsDefinitionGrid)
        {

        }

        /// <summary>
        ///  HospitalsUnitsGrid'i olan classlarda override ediliyor.Olmayan classlarda çağırılırsa hiç bir şey yapmıyor.
        /// NOT:OrthesisProsthesisProcedure'de HospitalsUnitsGrid hiç bir zaman Clear edilmeyeceği için ovverride edilmedi değiştirilirse
        /// OrthesisProsthesisProcedure'ün metodunda boş olarak override edilmelidir.
        /// </summary>
        protected virtual void ClearHospitalsUnits()
        {

        }

        /// <summary>
        /// hospitalsUnitsDefinition'da tanımlanan kriterlere göre gride değere atanıp atanmayacağını döndürür.
        /// </summary>
        /// <param name="hospitalsUnitsDefinitionGrid"></param>
        /// <returns></returns>
        protected bool IsHospitalsUnitsAllowedToBeAppended(HospitalsUnitsDefinitionGrid hospitalsUnitsDefinitionGrid)
        {
            //YAPILACAKLAR// aşağıdaki if koşuluna && ile Hospital değeri mevcut XXXXXX ise ibaresi eklencek//YAPILDI..yilmaz
            Guid currentHospital = new Guid(SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
            if (hospitalsUnitsDefinitionGrid.Policklinic.ObjectID == MasterResource.ObjectID)
            {
                return false;
            }
            //ReasonForExamination tanım ekranında tanımlanan yaş ve cinsiyet kriteri kontrolü yapılır.
            if (hospitalsUnitsDefinitionGrid.Sex != null && hospitalsUnitsDefinitionGrid.Sex != SexEnum.Unidentified)
            {
                return true;
                /*
                if (hospitalsUnitsDefinitionGrid.Sex != this.Episode.Patient.Sex)
                {
                    return false;
                }*/
            }
            if (hospitalsUnitsDefinitionGrid.MaxOld != null)
            {
                if (hospitalsUnitsDefinitionGrid.MaxOld < Episode.Patient.Age)
                {
                    return false;
                }
            }
            if (hospitalsUnitsDefinitionGrid.MinOld != null)
            {
                if (hospitalsUnitsDefinitionGrid.MinOld > Episode.Patient.Age)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// HospitalsUnits Gridine istek yapan birimi içeren yeni bir satır ekler
        /// </summary>
        public virtual void AddRequesterHospitalsUnits()
        {
            HospitalsUnitsDefinitionGrid requesterHospitalsUnitsDefinitionGrid = new HospitalsUnitsDefinitionGrid(ObjectContext);
            //YAPILACAKLAR//requesterHospitalsUnitsDefinitionGrid.ExaminationHospital'a mevcut hastene atanacak//YAPILDI..yilmaz
            Guid currentHospitalGuid = new Guid(SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));

            if (MasterResource is ResPoliclinic)
            {
                requesterHospitalsUnitsDefinitionGrid.Policklinic = (ResPoliclinic)MasterResource;
                AddHospitalsUnits(requesterHospitalsUnitsDefinitionGrid);
            }
        }

        /// <summary>
        /// HealthCommitteeExaminationFromOtherHospitals fork eder.
        /// </summary>
        /// <param name="hospitalsUnits"></param>

        protected void ForkHealthCommitteeExaminationFromOtherHospitals(HospitalsUnitsGrid hospitalsUnits)
        {

            // Constructorun ilk parametresi, fork edilecek actionun master actionını set etmek amacıyla kullanılır.
            // HealthCommitteeExaminationFromOtherDepartments  fork ettiği actionunun master actionına kendisini değil;
            // daha önce object pre insertinde set ettiğimiz HCActionToBeLinked 'i set etmeli. Bu nedenle if ile kontrol ettik.


            if (this is HealthCommitteeExaminationFromOtherDepartments)
            {
                HealthCommitteeExaminationFromOtherDepartments healthCommitteeExaminationFromOtherDepartments = (HealthCommitteeExaminationFromOtherDepartments)this;
                HealthCommitteeExaminationFromOtherHospitals healthCommitteeExaminationFromOtherHospitals = new HealthCommitteeExaminationFromOtherHospitals(healthCommitteeExaminationFromOtherDepartments.HCActionToBeLinked, hospitalsUnits);
            }
            else
            {
                HealthCommitteeExaminationFromOtherHospitals healthCommitteeExaminationFromOtherHospitals = new HealthCommitteeExaminationFromOtherHospitals((EpisodeAction)this, hospitalsUnits);
            }
        }
        /// <summary>
        /// HealthCommitteeExamination fork eder.
        /// </summary>
        /// <param name="hospitalsUnits"></param>

        protected void ForkExaminationApproval(HospitalsUnitsGrid hospitalsUnits)
        {
            ExaminationApproval examinationApproval = new ExaminationApproval((EpisodeAction)this, hospitalsUnits);
        }
        /// <summary>
        /// Health CommitteeExamiation fork eder.
        /// </summary>
        /// <param name="hospitalsUnits"></param>
        public static void ForkHealthCommitteeExamination(HospitalsUnitsGrid hospitalsUnits, EpisodeAction episodeAction, EDisabledReport reportObj = null, EStatusNotRepCommitteeObj eStatusNotfReportObj = null)
        {

            // Constructorun ilk parametresi, fork edilecek actionun master actionını set etmek amacıyla kullanılır.
            // HealthCommitteeExaminationFromOtherDepartments  fork ettiği actionunun master actionına kendisini değil;
            // daha önce object pre insertinde set ettiğimiz HCActionToBeLinked 'i set etmeli. Bu nedenle if ile kontrol ettik.



            //Sağlık Kurulu muayenesi, normal muayene içinde bir uzmanlık olarak oluşturuldu
            // HealthCommitteeExamination healthCommitteeExamination = new HealthCommitteeExamination(episodeAction, hospitalsUnits);

            PatientExamination patientExamination = new PatientExamination(episodeAction, hospitalsUnits, reportObj, eStatusNotfReportObj);

            // Sağlık Kurulu Muayenesi Hasta Muayenesi oluştururken Sıra Numarası atılıyor
            if (patientExamination.AdmissionQueueNumber.Value == null)
                patientExamination.AdmissionQueueNumber.GetNextValue(patientExamination.MasterResource.ObjectID.ToString() + DateTime.Today.ToShortDateString());
            //patientExamination.AdmissionQueueNumber = TTSequence.GetNextSequenceValueFromDatabase(TTDefinitionManagement.TTObjectDefManager.Instance.DataTypes["AdmissionQueueSequence"], (patientExamination.MasterResource.ObjectID.ToString() + DateTime.Today.ToShortDateString()),0);


        }

        /// <summary>
        /// Herhangi bir episodeactionda iken bir başka episodeaction fire edildiğinde, Fire edilen episodeAction classı içindeki zorunlu alanları set eder.
        /// </summary>
        /// <param name="episodeAction">Gerekli property değerlerinin alınacağı episode action</param>
        /// <param name="masterResource">fire edilen EpisodeActionın yapılacağı birim</param></param>
        /// <param name="setmasterAction">'true'olduğunda fire edilen EpisodeActionın MasterActionına  episodeAction parametre değeri atanır.'false ' ise MasterAction boş kalır. </param>
        public void SetMandatoryEpisodeActionProperties(EpisodeAction episodeAction, ResSection masterResource, bool setmasterAction)
        {
            if (IsOldAction != true)
                ActionDate = Common.RecTime();

            if (setmasterAction)
            {
                // this.MasterAction = episodeAction;
                episodeAction.LinkedActions.Add(this);
            }
            MasterResource = masterResource;
            FromResource = episodeAction.MasterResource;
            Episode = episodeAction.Episode;
        }

        /// <summary>
        /// Herhangi bir episodeactionda iken bir başka episodeaction fire edildiğinde, Fire edilen episodeAction classı içindeki zorunlu alanları set eder.
        /// </summary>
        /// <param name="episodeAction"></param>
        /// <param name="masterResource"></param>
        /// <param name="fromResource"></param>
        /// <param name="setmasterAction"></param>
        public void SetMandatoryEpisodeActionProperties(EpisodeAction episodeAction, ResSection masterResource, ResSection fromResource, bool setmasterAction)
        {
            if (IsOldAction != true)
                ActionDate = Common.RecTime();
            if (setmasterAction)
            {
                // this.MasterAction = episodeAction;
                episodeAction.LinkedActions.Add(this);
            }
            MasterResource = masterResource;
            FromResource = fromResource;
            Episode = episodeAction.Episode;
            if (PatientAdmission == null && episodeAction.PatientAdmission != null)
                PatientAdmission = episodeAction.PatientAdmission;
        }
        /// <summary>
        /// İşlem için Özel Muayene Farkı Gerkip Gerekmediğine Bakar
        /// </summary>
        public bool IsSpecialExamination
        {
            get
            {
                if (SubEpisode.PatientAdmission != null)
                {
                    if (Common.IsPropertyExist(SubEpisode.PatientAdmission, "IsSpecialExamination"))
                    {
                        if (Common.PropertyValue(SubEpisode.PatientAdmission, "IsSpecialExamination") != null)
                        {
                            return (Boolean)Common.PropertyValue(SubEpisode.PatientAdmission, "IsSpecialExamination");
                        }
                    }
                }
                return false;
            }
        }

        public void CheckForDiagnosis()
        {
            if (Episode != null && Episode.Diagnosis != null && Episode.Diagnosis.Count == 0)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25310", "Bu işlem epizotunda hiçbir tanı bulunmayan hastalara başlatılamaz!"));
        }

        /// <summary>
        /// EpisodeAction in current state inde CheckPaidStateAttribute varsa, işlem ücretinin (Hasta Payının) ödenip ödenmediği kontrolünü yapar
        /// </summary>

        public void CheckPaid()
        {
            if (CurrentStateDef.Attributes.ContainsKey("CheckPaidStateAttribute"))
            {
                if (Paid() == false)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(141));
            }
        }


        public static void CheckPaid(Guid episodeActionObjectID)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            BindingList<EpisodeAction> episodeActionList = EpisodeAction.GetEpisodeActionByID(objectContext, episodeActionObjectID.ToString());
            //EpisodeAction episodeAction = (EpisodeAction)objectContext.GetObject(episodeActionObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(EpisodeAction)));
            if (episodeActionList.Count > 0)
                episodeActionList[0].CheckPaid();

        }

        /// <summary>
        /// İşlem ücretinin (Hasta Payının) ödenip ödenmediği bilgisini döndürür
        /// </summary>
        /// <returns></returns>
        public bool Paid()
        {
            // Yatan hastada ödeme kontrolü yapılmaz
            if (Episode.PatientStatus == PatientStatusEnum.Inpatient)
                return true;

            if (ObjectContext.QueryObjects<PatientOldDebt>("OLDUNIQUEREFNO = '" + Episode.Patient.UniqueRefNo + "' AND (ISREMOVED = 0 OR ISREMOVED IS NULL)").Count(x => x.OldDebtReceiptDocument == null) > 0)
                return false;

            if (Episode.Patient.APR.Count > 0)
            {
                foreach (SubActionProcedure sp in GetAccountableSubActionProcedures())
                {
                    if (sp.Paid() == false)
                        return false;
                }

                foreach (SubActionMaterial sm in GetAccountableSubActionMaterials())
                {
                    if (sm.Paid() == false)
                        return false;
                }

                if (Episode.IsUnpaidPackageSPExists())  // Episode da ödenmemiş hasta payı paket hizmet varsa false döndürülür
                    return false;
            }

            return true;
        }


        /// <summary>
        /// İşleme Bağlı Ödenmemiş Alt İŞlemleri Döndürür.
        /// </summary>
        /// <returns></returns>
        public List<string> GetUnPaidSubActions()
        {
            List<string> pmDefIDs = new List<string>();

            if (Paid() == false)
            {
                foreach (SubActionProcedure mySubAct in GetAccountableSubActionProcedures())
                {
                    foreach (AccountTransaction at in mySubAct.AccountTransactions)
                    {
                        if (at.CurrentStateDefID == AccountTransaction.States.New && at.AccountPayableReceivable == Episode.Patient.MyAPR())
                            pmDefIDs.Add(mySubAct.ProcedureObject.ObjectID.ToString());
                    }
                }
                foreach (SubActionMaterial mySubAct in GetAccountableSubActionMaterials())
                {
                    foreach (AccountTransaction at in mySubAct.AccountTransactions)
                    {
                        if (at.CurrentStateDefID == AccountTransaction.States.New && at.AccountPayableReceivable == Episode.Patient.MyAPR())
                            pmDefIDs.Add(mySubAct.Material.ObjectID.ToString());
                    }
                }
            }
            return pmDefIDs;
        }

        public bool RequiresAdvance()
        {
            var subEpisode = SubEpisode;
            if (subEpisode != null && SubEpisode.GetOpenSubEpisodeProtocol(subEpisode) != null && SubEpisode.GetOpenSubEpisodeProtocol(subEpisode).Protocol.RequiresAdvance == true)
            {
                foreach (Advance advance in Episode.Advances)
                {
                    if (advance.IsCancelled == false)
                        return false;
                }
                return true;
            }
            return false;
        }

        //public bool RequiresFinancialDepartmentControl()
        //{
        //    return EpisodeAction.RequiresFinancialDepartmentControl(this);
        //}

        //public static bool RequiresFinancialDepartmentControl(EpisodeAction episodeAction)
        //{
        //    var subepisode = episodeAction.SubEpisode;

        //    if (subepisode != null && subepisode.PatientAdmission.RequiresFinancialDepControl(subepisode.PatientAdmission.AdmissionType) == true &&
        //        subepisode.OpenSubEpisodeProtocol != null && subepisode.OpenSubEpisodeProtocol.Protocol.RequiresFinancialControl == true)
        //        return true;

        //    return false;
        //}

        /// <summary>
        /// İşleme Bağlı Malzemeleri Stokdan Düşer
        /// </summary>
        public void StockOutTreatmentMaterials()
        {
            if (IsOldAction != true)
            {
                foreach (BaseTreatmentMaterial treatmentMaterial in TreatmentMaterials)
                {
                    if (treatmentMaterial.IsCancelled == false)
                        treatmentMaterial.StockOutByEpisodeActionAttribute();
                }
            }
        }
        /// <summary>
        /// İşleme Bağlı Alt İşlemleri Ve Malzemeleri Ücretlendirir
        /// </summary>
        public void AccountOperation()
        {
            if (IsOldAction != true)
            {
                foreach (SubActionProcedure sp in GetAccountableSubActionProcedures())
                    sp.AccountOperationAttribute();

                foreach (SubActionMaterial sm in GetAccountableSubActionMaterials())
                    sm.AccountOperationAttribute();
            }
        }
        /// <summary>
        /// Attribute Kontrolü Yapmadan İşleme Bağlı Alt İşlemleri Ve Malzemeleri Ücretlendirir
        /// </summary>
        public void AccountOperationDirect(AccountOperationTimeEnum pPreAccounting, SubEpisodeProtocol sep = null)
        {
            if (IsOldAction != true)
            {
                foreach (SubActionProcedure sp in GetAccountableSubActionProcedures())
                    sp.AccountOperation(pPreAccounting, sep);

                foreach (SubActionMaterial sm in GetAccountableSubActionMaterials())
                    sm.AccountOperation(pPreAccounting);
            }
        }
        /// <summary>
        /// İşlem Hasta Kabul Tarafından mı başlatıldı
        /// </summary>
        /// <returns></returns>
        public static bool IsFiredByPatientAdmission(EpisodeAction episodeAction)
        {
            if (episodeAction.PatientAdmission != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kullanıcı Doktor ise İşlemi Yapan Doktor Olarak Atar
        /// </summary>
        public virtual void SetProcedureDoctorAsCurrentResource()
        {
            if (CurrentStateDef.Status == StateStatusEnum.Uncompleted)
            {
                if (ProcedureDoctor == null && Common.CurrentResource.TakesPerformanceScore == true)
                {
                    ProcedureDoctor = Common.CurrentResource;
                }

            }
        }

        /// <summary>
        /// İşlemi Yapan Doktoru Boşaltır
        /// </summary>
        public void EmptyProcedureDoctorAsCurrentResource()
        {
            if (ProcedureDoctor != null)
            {
                ProcedureDoctor = null;
            }
        }


        /// <summary>
        /// İşlemin açdığı Tahsisleri Döndürür.
        /// </summary>
        /// <returns></returns>
        public IList GetExistingAllocationList()
        {
            IList allocationList;
            if (MySubActionProcedure == null && ProcedureSpeciality == null)
            {
                allocationList = Allocation.GetByStateEpisodeActionAndNullSpeciality(ObjectContext, Convert.ToString(Allocation.States.Allocated), Episode.ObjectID.ToString(), MyEpisodeAction.ObjectID.ToString());
            }
            else if (MySubActionProcedure == null)
            {
                allocationList = Allocation.GetByAllocatePropertiesExceptSubActionProcedure(ObjectContext, Convert.ToString(Allocation.States.Allocated), Episode.ObjectID.ToString(), MyEpisodeAction.ObjectID.ToString(), ProcedureSpeciality.ObjectID.ToString());
            }
            else if (ProcedureSpeciality == null)
            {
                allocationList = Allocation.GetByAllocatePropertiesWithNullSpeciality(ObjectContext, Convert.ToString(Allocation.States.Allocated), Episode.ObjectID.ToString(), MyEpisodeAction.ObjectID.ToString(), MySubActionProcedure.ObjectID.ToString());
            }
            else
            {
                allocationList = Allocation.GetByAllocateProperties(ObjectContext, Convert.ToString(Allocation.States.Allocated), Episode.ObjectID.ToString(), MyEpisodeAction.ObjectID.ToString(), ProcedureSpeciality.ObjectID.ToString(), MySubActionProcedure.ObjectID.ToString());
            }
            return allocationList;
        }

        /// <summary>
        /// Eski işlemlere değer gönderme classı
        /// </summary>
        public class OldActionPropertyObject
        {
            private string _propertyCaption;
            public string PropertyCaption
            {
                get { return (string)_propertyCaption; }
                set { _propertyCaption = value; }
            }
            private string _propertyValue;
            public string PropertyValue
            {
                get { return (string)_propertyValue; }
                set { _propertyValue = value; }
            }
            public OldActionPropertyObject(string propertyCaption, string propertyValue)
            {
                PropertyCaption = propertyCaption;
                PropertyValue = propertyValue;
            }

        }

        /// <summary>
        /// Eski İşlemeler İçin Elektronik Hasta Kaydı Nesnelerinden Özellik çeker.
        /// </summary>
        /// <returns></returns>
        protected virtual List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {

            return null;
        }

        /// <summary>
        /// Eski İşlemeler İçin Elektronik Hasta Kaydı Nesnelerinden İlişki Değerleri çeker.
        /// </summary>
        /// <returns></returns>
        protected virtual List<List<List<EpisodeAction.OldActionPropertyObject>>> OldActionChildRelationList()
        {

            return null;
        }

        /// <summary>
        /// Eski İşlemeler İçin Elektronik Hasta Kaydı Nesnelerinden Alt İşlemleri Çeker
        /// </summary>
        /// <returns></returns>
        public virtual string OldActionSubactionProcedureFlowablesHtml()
        {
            string s = "";

            foreach (SubactionProcedureFlowable sf in SubactionProcedureFlowables)
            {
                bool hasRight = false;
                if (sf.CurrentStateDef != null && sf.CurrentStateDef.FormDef != null)
                {
                    //TODO: Permission kontrolü daha sonra yapılacak.
                    //TTVis ual.TTForm frm = TTVis ual.TTForm.GetEditForm(sf);
                    //hasRight = TTUser.CurrentUser.HasRight(sf.CurrentStateDef.FormDef, frm, (int)TTSecurityAuthority.RightsEnum.ReadForm,sf.CurrentStateDef);
                    hasRight = true;
                }
                if (!hasRight)
                {
                    string step = " İşlemini";
                    if (sf.CurrentStateDef != null)
                        step = " İşleminin Bulunduğu  '" + sf.CurrentStateDef.DisplayText + "' Adımını";

                    s = s + "<font color='red' face='arial' size='2'><b>'" + sf.ObjectDef.ApplicationName.ToString() + "'" + step + " Görme Yetkiniz Yoktur!</b></font>";
                    s = s + "</br>";
                }
            }
            return s;
        }

        /// <summary>
        /// Eski İşlemlerde Gözükecek İşlem Bilgilerini XML String olarak Döndürür
        /// </summary>
        /// <returns></returns>
        public virtual string OldActionReportHtml()
        {
            string report = "<html>";
            //Yetki Kontrolü
            bool hasRight = false;
            if (CurrentStateDef != null && CurrentStateDef.FormDef != null)
            {
                //TODO: Permission kontrolü daha sonra yapılacak.
                //TTVis ual.TTForm frm = TTVis ual.TTForm.GetEditForm(this);
                //hasRight = TTUser.CurrentUser.HasRight(this.CurrentStateDef.FormDef, frm, (int)TTSecurityAuthority.RightsEnum.ReadForm);
                hasRight = true;
            }
            if (hasRight)
            {
                if (OldActionPropertyList() != null)
                {
                    if (OldActionPropertyList().Count > 0)
                    {
                        report = report + "<table border=1 width='100%'>";
                        foreach (EpisodeAction.OldActionPropertyObject property in OldActionPropertyList())
                        {
                            report = report + "<tr>" + Common.FormatAsOldActionTitle(property.PropertyCaption, null) + Common.FormatAsOldActionValue(property.PropertyValue, null);
                        }
                        report = report + "</table>";
                    }
                }
                List<List<List<EpisodeAction.OldActionPropertyObject>>> oldActionChildRelationList = OldActionChildRelationList();

                if (oldActionChildRelationList != null)
                {
                    foreach (List<List<EpisodeAction.OldActionPropertyObject>> grid in oldActionChildRelationList)// her bir grid için dönüyor
                    {
                        if (grid != null)
                        {
                            if (grid.Count > 0)
                            {
                                report = report + "<table border width='100%'>";
                                report = report + "<tr>";
                                foreach (EpisodeAction.OldActionPropertyObject property in grid[0])// griddeki her bir bir obje propertysi için başlık satırı tek olacağı için gelen ilk objeninki alındı
                                {
                                    report = report + Common.FormatAsOldActionTitleV2(property.PropertyCaption, null, true);
                                }
                                report = report + "</tr>";
                                foreach (List<EpisodeAction.OldActionPropertyObject> childRelationRow in grid)
                                {
                                    if (childRelationRow.Count > 0)
                                    {
                                        report = report + "<tr>";
                                        foreach (EpisodeAction.OldActionPropertyObject property in childRelationRow)// her bir obje propertysi değerleri yazılır
                                        {
                                            report = report + Common.FormatAsOldActionValue(property.PropertyValue, null);
                                        }
                                        report = report + "</tr>";
                                    }
                                }
                                report = report + "</table>";
                            }
                        }
                    }
                }
                report = report + "</html>";
                report = report + OldActionSubactionProcedureFlowablesHtml();
            }
            else // Yetki yok
            {
                string step = " İşlemini";
                if (CurrentStateDef != null)
                    step = " İşleminin Bulunduğu  '" + CurrentStateDef.DisplayText + "' Adımını";

                report = report + "<font color='red' face='arial' size='2'><b>'" + ObjectDef.ApplicationName.ToString() + "'" + step + " Görme Yetkiniz Yoktur!</b></font>";
                report = report + "</br>";
                report = report + "</html>";
            }
            return report;
        }

        /// <summary>
        /// İşlemin Vakadaki Son Açık İşlem olup olmadığını Döndürür
        /// </summary>
        /// <returns></returns>
        public bool IsLastActionInEpisode()
        {
            IList eaList = EpisodeAction.GetUnCompletedEpisodeActionsByEpisode(Episode.ObjectID, ObjectID);
            if (eaList.Count > 0)
                return false;
            IList spfList = SubactionProcedureFlowable.GetUncompletedSPFsByEpisode(Episode.ObjectID);
            if (spfList.Count > 0)
                return false;
            return true;
        }
        /// <summary>
        /// İşlem Episodedaki Son işlemse ve Vaka Açık Devam ise Vakayı kapatır
        /// </summary>
        public void CloseCloseToOpenEpisode()
        {
            if (Episode.CurrentStateDefID == Episode.States.ClosedToNew)
            {
                if (CurrentStateDef.Status != StateStatusEnum.Uncompleted && IsLastActionInEpisode())
                    Episode.CloseEpisode();
            }
        }

        //public TreatmentDischarge MyTreatmentDischarge()
        //{
        //    if (this is PatientExamination || this is FollowUpExamination || this is DentalExamination || this is InPatientPhysicianApplication)
        //    {
        //        foreach (EpisodeAction episodeAction in this.LinkedActions)
        //        {
        //            if (episodeAction is TreatmentDischarge)
        //            {
        //                TreatmentDischarge treatmentDischarge = (TreatmentDischarge)episodeAction;
        //                if ((!treatmentDischarge.IsCancelled) && treatmentDischarge.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully)
        //                    return treatmentDischarge;
        //            }
        //        }

        //        // muayene formunda  yeni oluşturulam MTS ayrı contextde olduğu için bide veri tabanından bakılır
        //        TTObjectContext context = new TTObjectContext(true);
        //        BindingList<TTObjectClasses.TreatmentDischarge> treatmentDischargeList = TTObjectClasses.TreatmentDischarge.GetTreatmentDischargeByEpisode(context, this.Episode.ObjectID);
        //        foreach (TTObjectClasses.TreatmentDischarge trDis in treatmentDischargeList)
        //        {
        //            if ((!trDis.IsCancelled) && trDis.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully && trDis.MasterAction != null && trDis.MasterAction.ObjectID == this.ObjectID)
        //                return trDis;
        //        }
        //    }
        //    return null;
        //}

        public virtual BirthReportRequest MyBirthReportRequest()
        {
            if (this is Surgery)
            {
                foreach (EpisodeAction episodeAction in LinkedActions)
                {
                    if (episodeAction is BirthReportRequest)
                    {
                        BirthReportRequest birthReportRequest = (BirthReportRequest)episodeAction;
                        if (birthReportRequest.CurrentStateDef.Status == StateStatusEnum.CompletedUnsuccessfully || birthReportRequest.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                            return birthReportRequest;
                    }
                }

                TTObjectContext context = new TTObjectContext(true);
                BindingList<TTObjectClasses.BirthReportRequest> birthReportRequestList = TTObjectClasses.BirthReportRequest.GetBirthReportRequestByEpisode(context, Episode.ObjectID);
                foreach (TTObjectClasses.BirthReportRequest brtRep in birthReportRequestList)
                {
                    if ((!brtRep.IsCancelled) && brtRep.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully && brtRep.MasterAction != null && brtRep.MasterAction.ObjectID == ObjectID)
                        return brtRep;
                }
            }
            return null;
        }

        public virtual CreatingEpicrisis MyEpicrisisReport()
        {
            return null;
        }

        public virtual void AddSpecialProcedure(ResUser procedureDoctor)
        {
            return;
        }

        public virtual List<int> AllowedMedulaTedaviTipi()
        {
            return null;
        }



        public ISUTMaterialTotalAmount NewSUTMaterialTotalAmount(Guid materialID)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            SUTMaterialTotalAmount materialTotalAmount = new SUTMaterialTotalAmount(objectContext);
            materialTotalAmount.SetTotalAmount(0);

            IList newSubactionMaterialsList = TreatmentMaterials.Select("MATERIAL = " + ConnectionManager.GuidToString(materialID));
            if (newSubactionMaterialsList.Count > 0)
                foreach (BaseTreatmentMaterial treatmentMaterial in newSubactionMaterialsList)
                    if (((ITTObject)treatmentMaterial).IsNew)
                        if (treatmentMaterial.Amount.HasValue && treatmentMaterial.Amount.Value > 0)
                            materialTotalAmount.SetTotalAmount(materialTotalAmount.GetTotalAmount() + treatmentMaterial.Amount.Value);

            return (ISUTMaterialTotalAmount)materialTotalAmount;
        }

        public ISUTProcedureTotalAmount NewSUTProcedureTotalAmount(Guid procedureID)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            SUTProcedureTotalAmount procedureTotalAmount = new SUTProcedureTotalAmount(objectContext);
            procedureTotalAmount.SetTotalAmount(0);

            IList newSubactionProceduresList = SubactionProcedures.Select("PROCEDUREOBJECT = " + ConnectionManager.GuidToString(procedureID));
            if (newSubactionProceduresList.Count > 0)
                foreach (SubActionProcedure subActionProcedure in newSubactionProceduresList)
                    if (((ITTObject)subActionProcedure).IsNew)
                        if (subActionProcedure.Amount.HasValue && subActionProcedure.Amount.Value > 0)
                            procedureTotalAmount.SetTotalAmount(procedureTotalAmount.GetTotalAmount() + subActionProcedure.Amount.Value);

            return (ISUTProcedureTotalAmount)procedureTotalAmount;
        }


        public ISUTMaterialTotalAmount SUTMaterialTotalAmount(ISUTEpisodeAction episodeAction, Guid materialID)
        {
            ISUTMaterialTotalAmount materialTotalAmount = NewSUTMaterialTotalAmount(materialID);

            //            IList subactionMaterialsList = EpisodeAction.GetEHREpisodeActionSubactionMaterialsTotalAmount(this.ObjectID, materialID);
            //            foreach (EpisodeAction.GetEHREpisodeActionSubactionMaterialsTotalAmount_Class o in subactionMaterialsList)
            //                materialTotalAmount.TotalAmount += Convert.ToDouble(o.Totalamount);

            return materialTotalAmount;
        }

        public ISUTProcedureTotalAmount SUTProcedureTotalAmount(ISUTEpisodeAction episodeAction, Guid procedureID)
        {
            ISUTProcedureTotalAmount procedureTotalAmount = NewSUTProcedureTotalAmount(procedureID);

            //            IList subactionProceduresTotalAmountList = EpisodeAction.GetEHREpisodeActionSubactionProceduresTotalAmount(this.ObjectID, procedureID);
            //            foreach (EpisodeAction.GetEHREpisodeActionSubactionProceduresTotalAmount_Class o in subactionProceduresTotalAmountList)
            //                procedureTotalAmount.TotalAmount += Convert.ToInt64(o.Totalamount);
            //
            //            subactionProceduresTotalAmountList = EpisodeAction.GetEHREpisodeActionSubactProcFlowablesTotalAmount(procedureID, this.ObjectID);
            //            foreach (EpisodeAction.GetEHREpisodeActionSubactProcFlowablesTotalAmount_Class o in subactionProceduresTotalAmountList)
            //                procedureTotalAmount.TotalAmount += Convert.ToInt64(o.Totalamount);

            return procedureTotalAmount;
        }

        public List<ISUTInstance> SUTSubactionProcedures(Guid procedureID)
        {
            List<ISUTInstance> retValue = new List<ISUTInstance>();
            //            IList subactionProcedures = EpisodeAction.GetEHREpisodeActionSubactionProcedures(this.ObjectID, procedureID, string.Empty);
            //            if (subactionProcedures.Count > 0)
            //            {
            //                TTObjectContext objectContext = new TTObjectContext(false);
            //                foreach (EpisodeAction.GetEHREpisodeActionSubactionProcedures_Class o in subactionProcedures)
            //                {
            //                    SUTInstance sutInstance = new SUTInstance(objectContext);
            //                    sutInstance.RuleDate = o.ActionDate;
            //                    sutInstance.RuleAmount = o.Amount;
            //                    sutInstance.SUTRulableObject = (ProcedureDefinition)objectContext.GetObject((Guid)o.Procedureobjectid, typeof(ProcedureDefinition));
            //                    retValue.Add(sutInstance);
            //                }
            //            }
            return retValue;
        }


        public List<ISUTInstance> SUTDiagnosisGrid()
        {
            List<ISUTInstance> retValue = new List<ISUTInstance>();
            //            IList episodeActionDiagnosis = EpisodeAction.GetEHREpisodeActionDiagnosis(this.ObjectID, string.Empty);
            //            if (episodeActionDiagnosis.Count > 0)
            //            {
            //                TTObjectContext objectContext = new TTObjectContext(false);
            //                foreach (EpisodeAction.GetEHREpisodeActionDiagnosis_Class o in episodeActionDiagnosis)
            //                {
            //                    SUTInstance sutInstance = new SUTInstance(objectContext);
            //                    sutInstance.RuleDate = o.DiagnoseDate;
            //                    sutInstance.SUTRulableObject = (DiagnosisDefinition)objectContext.GetObject((Guid)o.Diagnosisobjectid, typeof(DiagnosisDefinition));
            //                    retValue.Add(sutInstance);
            //                }
            //            }
            return retValue;
        }

        public ISUTEpisode SUTEpisode
        {
            get
            {
                return (ISUTEpisode)Episode;
            }
        }






        public virtual EpisodeAction PrepareEpisodeActionForRemoteMethod(bool withNewObjectID)
        {
            // Çağırılan yerde savePoit konulup daha sonra o pointe dönülmeli
            if (withNewObjectID)
            {
                EpisodeAction sendingEpisodeAction = (EpisodeAction)Clone();

                sendingEpisodeAction.Episode = null;
                sendingEpisodeAction.FromResource = null;
                TTSequence.allowSetSequenceValue = true;
                sendingEpisodeAction.ID.SetSequenceValue(0);
                sendingEpisodeAction.MasterResource = null;
                sendingEpisodeAction.MasterAction = null;
                sendingEpisodeAction.MedulaHastaKabul = null;
                sendingEpisodeAction.PatientAdmission = null;
                sendingEpisodeAction.OrderObject = null;
                sendingEpisodeAction.ProcedureDoctor = null;
                sendingEpisodeAction.SecondaryMasterResource = null;
                sendingEpisodeAction.SubEpisode = null;
                return sendingEpisodeAction;
            }
            else
            {
                return this;
            }

        }


        public Appointment CreateAppointmentForNumarator()
        {
            Appointment newAppointment = null;
            if (this is INumaratorAppointment)
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("CloseNumaratorAppointment", "FALSE") != "TRUE")
                {
                    INumaratorAppointment numaretor = (INumaratorAppointment)this;
                    foreach (AppointmentCarrier appcarrier in numaretor.GetAppointmentCarrierList())
                    {
                        Resource numaretorResource = numaretor.GetNumaratorAppointmentResource();
                        if (numaretorResource != null)
                        {
                            newAppointment = new Appointment(ObjectContext);
                            newAppointment.MasterResource = numaretor.GetNumaratorAppointmentMasterResource();
                            newAppointment.Resource = numaretorResource;
                            newAppointment.Schedule = null;
                            newAppointment.BreakAppointment = true;
                            newAppointment.StartTime = Common.RecTime();
                            newAppointment.EndTime = Common.RecTime();
                            newAppointment.AppointmentType = numaretor.GetNumaratorAppointmentType();
                            newAppointment.CurrentStateDefID = Appointment.States.NotApproved;
                            newAppointment.Notes = TTUtils.CultureService.GetText("M26599", "Numaratör Randevusu");
                            newAppointment.AppDate = Common.RecTime().Date;
                            newAppointment.Patient = Episode.Patient;
                            newAppointment.AppointmentDefinition = appcarrier.AppointmentDefinition;
                            newAppointment.AppointmentCarrier = appcarrier;
                            newAppointment.GivenBy = (ResUser)Common.CurrentResource;
                            newAppointment.IsNumarator = true;
                            newAppointment.AppViewerState = "BEKLİYOR";
                            newAppointment.EpisodeAction = this;

                            break; //birden fazla appointmentcarrier(alt randevu) varsa yalnız ilki  için oluşturur
                        }
                    }
                }
            }
            return newAppointment;
        }

        public virtual bool HasPatientAdmissionStartedSP(ProcedureDefinition procedureDefinition, ResSection MasterResourceForSubactionProcedureFlowable)
        {
            string ProcedureDefinitionObjectDefName = procedureDefinition.ObjectDef.Name.ToUpperInvariant();
            foreach (TTObjectRelationSubtypeDef rSubType in ObjectDef.AllChildRelationsSubtypeDefs)
            {
                if (rSubType.RelationDef.ParentObjectDef.IsOfType(typeof(EpisodeAction).Name.ToUpperInvariant()) && rSubType.RelationDef.ChildObjectDef.IsOfType(typeof(SubActionProcedure).Name.ToUpperInvariant()))
                {
                    bool isSubactionProcedureObject = false; // SubRelation olabilir
                    if (rSubType.ChildObjectDef.AllParentRelationDefs["ProcedureObject"].ParentObjectDef.IsOfType(ProcedureDefinitionObjectDefName))
                    {
                        return true;
                    }

                    if (!isSubactionProcedureObject) // restrictionda olabilir
                    {
                        foreach (TTRelationParentRestrictions parentRestriction in rSubType.ChildObjectDef.ParentRelationRestrictions)
                        {
                            foreach (TTObjectDef restrictedObject in parentRestriction.RestrictedObjectDefs)
                            {
                                if (restrictedObject.IsOfType(ProcedureDefinitionObjectDefName))
                                {
                                    return true;
                                }
                            }
                        }
                    }

                    if (this is PatientExamination && procedureDefinition is SurgeryDefinition)
                    {
                        if (((SurgeryDefinition)procedureDefinition).IsAdditionalApplication.HasValue && ((SurgeryDefinition)procedureDefinition).IsAdditionalApplication.Value == true)
                            return true;
                    }
                }
            }
            return false;
        }

        public virtual SubActionProcedure SetSubactionProcedureOfEpisodeAction(ProcedureDefinition procedureDefinition, ResSection MasterResourceForSubactionProcedureFlowable)
        {
            string ProcedureDefinitionObjectDefName = procedureDefinition.ObjectDef.Name.ToUpperInvariant();
            foreach (TTObjectRelationSubtypeDef rSubType in ObjectDef.AllChildRelationsSubtypeDefs)
            {
                if (rSubType.RelationDef.ParentObjectDef.IsOfType(typeof(EpisodeAction).Name.ToUpperInvariant()) && rSubType.RelationDef.ChildObjectDef.IsOfType(typeof(SubActionProcedure).Name.ToUpperInvariant()))
                {
                    bool isSubactionProcedureObject = false; // SubRelation olabilir
                    if (rSubType.ChildObjectDef.AllParentRelationDefs["ProcedureObject"].ParentObjectDef.IsOfType(ProcedureDefinitionObjectDefName))
                    {
                        isSubactionProcedureObject = true;
                    }

                    if (!isSubactionProcedureObject) // restrictionda olabilir
                    {
                        foreach (TTRelationParentRestrictions parentRestriction in rSubType.ChildObjectDef.ParentRelationRestrictions)
                        {
                            foreach (TTObjectDef restrictedObject in parentRestriction.RestrictedObjectDefs)
                            {
                                if (restrictedObject.IsOfType(ProcedureDefinitionObjectDefName))
                                {
                                    isSubactionProcedureObject = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (this is PatientExamination && procedureDefinition is SurgeryDefinition)
                    {
                        if (((SurgeryDefinition)procedureDefinition).IsAdditionalApplication.HasValue && ((SurgeryDefinition)procedureDefinition).IsAdditionalApplication.Value == true)
                            isSubactionProcedureObject = true;
                    }

                    if (isSubactionProcedureObject)
                    {
                        SubActionProcedure firedSubactionProcedure = (SubActionProcedure)ObjectContext.CreateObject(rSubType.ChildObjectDef.Name.ToUpperInvariant());
                        BindingList<TTObjectStateDef> subactionProcedureStates = (BindingList<TTObjectStateDef>)((ITTObject)firedSubactionProcedure).GetNextStateDefs();
                        if (subactionProcedureStates.Count > 0)
                            firedSubactionProcedure.CurrentStateDef = (TTObjectStateDef)subactionProcedureStates[0];
                        firedSubactionProcedure.Amount = 1;
                        firedSubactionProcedure.ProcedureObject = procedureDefinition;
                        firedSubactionProcedure.Episode = Episode;
                        if (Common.IsBaseOfInheritedObject(firedSubactionProcedure.ObjectDef, TTDefinitionManagement.TTObjectDefManager.Instance.ObjectDefs[typeof(SubactionProcedureFlowable).Name.ToUpperInvariant()]))
                        {
                            if (MasterResourceForSubactionProcedureFlowable != null)
                            {
                                ((SubactionProcedureFlowable)firedSubactionProcedure).MasterResource = MasterResourceForSubactionProcedureFlowable;
                                ((SubactionProcedureFlowable)firedSubactionProcedure).FromResource = MasterResourceForSubactionProcedureFlowable;

                            }
                        }
                        SubactionProcedures.Add(firedSubactionProcedure);
                        LaboratoryProcedure laboratoryProcedure = firedSubactionProcedure as LaboratoryProcedure;
                        LaboratoryTestDefinition labTestDef = procedureDefinition as LaboratoryTestDefinition;
                        if (labTestDef != null && laboratoryProcedure != null)
                        {
                            if (labTestDef.IsPanel == true)
                                laboratoryProcedure.CreateTestsFromSelectedPanel();
                        }
                        return firedSubactionProcedure;
                        //break;
                    }
                }
            }
            return null;
        }

        public void FireEpisodeActionByTemplate(EpisodeActionTemplate template)
        {
            FireEpisodeActionByTemplate(template, null);
        }

        // Verilen Template göre EpisodeAction Başlatma
        public virtual EpisodeAction FireEpisodeActionByTemplate(EpisodeActionTemplate template, ResSection masterResource)
        {
            //if(masterResource == null) ET 24.05.2012
            masterResource = template.Resource;
            string objectDefName = template.ActionType.ToString().ToUpperInvariant();
            TTObjectDef objDef = null;
            if (TTObjectDefManager.Instance.ObjectDefs.TryGetValue(objectDefName, out objDef) == false)
                throw new Exception(SystemMessage.GetMessageV2(1013, objectDefName.ToString()));

            if (objDef.IsOfType(typeof(EpisodeAction).Name.ToUpperInvariant()) == false)
                throw new Exception(SystemMessage.GetMessageV2(1014, objectDefName.ToString()));

            EpisodeAction firedAction = (EpisodeAction)ObjectContext.CreateObject(objectDefName);
            BindingList<TTObjectStateDef> states = (BindingList<TTObjectStateDef>)((ITTObject)firedAction).GetNextStateDefs();
            if (states.Count > 0)
                firedAction.CurrentStateDef = (TTObjectStateDef)states[0];

            firedAction.MasterAction = this;
            if (IsOldAction != true)
                firedAction.ActionDate = Common.RecTime();
            firedAction.FromResource = MasterResource;
            firedAction.MasterResource = masterResource;
            firedAction.Episode = Episode;

            string RequestDoctor = Convert.ToString(TTObjectClasses.SystemParameter.GetParameterValue("REQUESTERDOCTORFORHC", ""));

            if (firedAction is Radiology)
            {
                ((Radiology)firedAction).PreDiagnosis = TTUtils.CultureService.GetText("M26795", "Sağlık Kurulu Radyoloji İsteği");

                if (!string.IsNullOrEmpty(RequestDoctor))
                    ((Radiology)firedAction).RequestDoctor = (ResUser)firedAction.ObjectContext.GetObject(new Guid(RequestDoctor), "RESUSER");
            }
            else if (firedAction is LaboratoryRequest)
            {
                if (!string.IsNullOrEmpty(RequestDoctor))
                    ((LaboratoryRequest)firedAction).RequestDoctor = (ResUser)firedAction.ObjectContext.GetObject(new Guid(RequestDoctor), "RESUSER");
            }

            if (firedAction.RequestDate == null)
            {
                firedAction.ActionDate = Common.RecTime();
            }
            bool AdvanceStateIfHasSubaction = false;

            if (template.ProcedureDefinitions.Count > 0)
            {
                //Burada Tanım ekranında girilmiş   subactionlar create ediliyor.
                foreach (EpisodeActionProcedureObjectTemplate eaProcedureObjectTemplate in template.ProcedureDefinitions)
                {
                    ProcedureDefinition procedureDef = eaProcedureObjectTemplate.ProcedureDefinition;
                    SubActionProcedure sa = firedAction.SetSubactionProcedureOfEpisodeAction(procedureDef, masterResource);
                    if (sa != null)
                    {
                        AdvanceStateIfHasSubaction = true;
                        if (sa is RadiologyTest)
                        {
                            ((RadiologyTest)sa).RequestDate = Common.RecTime();
                        }
                        else if (sa is LaboratoryProcedure)
                            ((LaboratoryProcedure)sa).RequestDate = Common.RecTime();

                        if (!string.IsNullOrEmpty(RequestDoctor))
                            sa.RequestedByUser = (ResUser)firedAction.ObjectContext.GetObject(new Guid(RequestDoctor), "RESUSER");
                    }
                }
            }
            //if (AdvanceStateIfHasSubaction)
            //{
            //    foreach (TTObjectStateTransitionDef transDef in firedAction.CurrentStateDef.SortedOutgoingTransitions.Values)
            //    {
            //        if (transDef.AllAttributes.ContainsKey("StatePrecedenceAttribute"))
            //        {
            //            firedAction.Update();
            //            firedAction.CurrentStateDefID = transDef.ToStateDefID;
            //            break;
            //        }
            //    }
            //}
            return firedAction;

        }

        public EpisodeAction CreateNewActionFromTemplate(ResSection unit, EpisodeAction parentAction)
        {
            Guid savePoint = ObjectContext.BeginSavePoint();
            String messageString = "";

            EpisodeAction firedAction = (EpisodeAction)Clone();

            firedAction.IsSpecialTemplate = true;
            TTSequence.allowSetSequenceValue = true;
            firedAction.ID.SetSequenceValue(0);
            firedAction.ID.GetNextValue();
            if (IsOldAction != true)
                firedAction.ActionDate = Common.RecTime();
            firedAction.MasterAction = parentAction;
            firedAction.Episode = parentAction.Episode;
            firedAction.MasterResource = unit;
            firedAction.FromResource = parentAction.MasterResource;

            foreach (SubActionProcedure procedure in SubactionProcedures)
            {
                if (procedure.MasterSubActionProcedure == null)
                    FillSubProceduresRecursively(procedure, firedAction, null);
            }

            return firedAction;
        }

        public void FillSubProceduresRecursively(SubActionProcedure procedure, EpisodeAction firedAction, SubActionProcedure masterProcedure)
        {
            if (procedure is SubactionProcedureFlowable)
            {
                SubactionProcedureFlowable childProc = (SubactionProcedureFlowable)procedure.Clone();

                TTSequence.allowSetSequenceValue = true;
                childProc.ID.SetSequenceValue(0);
                childProc.ID.GetNextValue();
                if (IsOldAction != true)
                    childProc.ActionDate = Common.RecTime();
                childProc.Episode = firedAction.Episode;
                childProc.EpisodeAction = firedAction;
                childProc.MasterSubActionProcedure = masterProcedure; //procedure.MasterSubActionProcedure;
                childProc.MasterResource = firedAction.MasterResource;
                childProc.FromResource = firedAction.FromResource;

                foreach (SubActionProcedure childSubProcedure in procedure.ChildSubActionProcedure)
                    FillSubProceduresRecursively(childSubProcedure, firedAction, childProc);

                SubactionProcedureFlowable flprocedure = procedure as SubactionProcedureFlowable;
                foreach (BaseTreatmentMaterial material in flprocedure.TreatmentMaterials)
                {
                    Dictionary<string, object> dictMaterials = new Dictionary<string, object>();

                    BaseTreatmentMaterial childMtr = (BaseTreatmentMaterial)material.Clone();
                    if (IsOldAction != true)
                        childMtr.ActionDate = Common.RecTime();
                    childMtr.Episode = firedAction.Episode;
                    childMtr.EpisodeAction = firedAction;
                    childMtr.SubactionProcedureFlowable = childProc;
                }
            }
            else
            {
                Dictionary<string, object> dictSubActions = new Dictionary<string, object>();
                SubActionProcedure childProc = (SubActionProcedure)procedure.Clone();

                TTSequence.allowSetSequenceValue = true;
                childProc.ID.SetSequenceValue(0);
                childProc.ID.GetNextValue();
                if (IsOldAction != true)
                    childProc.ActionDate = Common.RecTime();
                childProc.Episode = firedAction.Episode;
                childProc.EpisodeAction = firedAction;
                childProc.MasterSubActionProcedure = procedure.MasterSubActionProcedure;
            }
        }

        public bool IsForcedToStartInStarterEpisode()
        {
            if (Common.IsAttributeExistsV2(typeof(ForceToStartInStarterEpisodeAttribute), ObjectDef) == true)
                return true;
            return false;
        }


        public bool IsEpisodeActionCloseEpisode()
        {
            bool foundInpatient = false;
            IList list = InpatientAdmission.GetInpatientAdmissionByEpisode(ObjectContext, Episode.ObjectID.ToString());
            foreach (InpatientAdmission ia in list)
            {
                if (ia.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                {
                    foundInpatient = true;
                    break;
                }
            }
            if (foundInpatient) // Yatan hastayı yanlızca nakili olmayan Yatan Hasta Clinic işlemi kapatabilir
            {
                if (this is InPatientTreatmentClinicApplication)
                {
                    InPatientTreatmentClinicApplication ica = ((InPatientTreatmentClinicApplication)this);

                    if (ica.BaseInpatientAdmission is InpatientAdmission)// yatan Hasta İşlemi
                    {
                        if ((ica.GetMyActiveToInPatientTrtmentClinicApp() == null))// nakil olmamış
                            return true;
                    }
                }
                return false;
            }
            if (this is PatientExamination)// çifte Tabip muaynesinde son muayene kapanmadan kapatılmaz
            {
                //if (this.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.DoubleExamination)
                //{
                //    foreach (PatientExamination pa in this.Episode.PatientExaminations)
                //    {
                //        if (pa.ObjectID != this.ObjectID)
                //        {
                //            if (pa.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                //                return false;
                //        }
                //    }
                //}
                if (SubEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.Normal)//Sağlık Kurulu işlemi bulunanan vakalarda MTS yazılımış dahi olsa kapatılamaz
                {
                    foreach (EpisodeAction ea in Episode.EpisodeActions)
                        if (ea is HealthCommittee && (ea.CurrentStateDef.Status == StateStatusEnum.Uncompleted))
                            return false;
                }
            }
            return true;
        }

        public static void CheckAndCloseEpisode(Guid episodeActionObjectID)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            EpisodeAction episodeAction = (EpisodeAction)objectContext.GetObject(episodeActionObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(EpisodeAction)));
            if (episodeAction != null)
            {
                bool isLastActionInEpisode = episodeAction.IsLastActionInEpisode();
                if (episodeAction.Episode.CurrentStateDefID == Episode.States.Open || (isLastActionInEpisode && episodeAction.Episode.CurrentStateDefID == Episode.States.ClosedToNew))
                {
                    if (episodeAction.IsEpisodeActionCloseEpisode())
                    {
                        Guid savePointGuid = objectContext.BeginSavePoint();
                        try
                        {
                            Episode episode = (Episode)objectContext.GetObject(episodeAction.Episode.ObjectID, "Episode");
                            if (isLastActionInEpisode)
                                episode.CloseEpisode();
                            else
                                episode.CloseEpisodeToNew();
                            objectContext.Save();
                        }
                        catch (Exception ex)
                        {
                            objectContext.RollbackSavePoint(savePointGuid);
                            throw;
                        }
                        finally
                        {
                            objectContext.Dispose();
                        }
                    }
                }
            }
        }

        public void CheckAndCloseEpisode(bool postScript)
        {
            if (postScript)
            {
                bool isLastActionInEpisode = IsLastActionInEpisode();
                if (Episode.CurrentStateDefID == Episode.States.Open || (isLastActionInEpisode && Episode.CurrentStateDefID == Episode.States.ClosedToNew))
                {
                    if (IsEpisodeActionCloseEpisode())
                    {
                        if (isLastActionInEpisode)
                            Episode.CloseEpisode();
                        else
                            Episode.CloseEpisodeToNew();
                    }
                }
            }
            else
            {
                EpisodeAction.CheckAndCloseEpisode(ObjectID);
            }
        }

        //        public void CheckAndCloseEpisode()
        //        {
        //            bool isLastActionInEpisode = this.IsLastActionInEpisode();
        //            if(this.Episode.CurrentStateDefID == Episode.States.Open || (isLastActionInEpisode && this.Episode.CurrentStateDefID == Episode.States.ClosedToNew) )
        //            {
        //                if(IsEpisodeActionCloseEpisode())
        //                {
        //                    if(isLastActionInEpisode)
        //                        this.Episode.CloseEpisode();
        //                    else
        //                        this.Episode.CloseEpisodeToNew();
        //                }
        //            }
        //        }

        public void UndoCloseEpisode()
        {
            if (Episode.CurrentStateDefID == Episode.States.Closed || Episode.CurrentStateDefID == Episode.States.ClosedToNew)
                Episode.OpenEpisode();
        }


        public static Resource GetSpecialResourceForStore(EpisodeAction episodeAction)
        {
            return episodeAction.SpecialResourceForStore();
        }

        public virtual Resource SpecialResourceForStore()
        {
            return SecondaryMasterResource;
        }



        public void CancelMyExaminationQueueItems()
        {
            IList<ExaminationQueueItem> itemList = ExaminationQueueItem.GetByEpisodeAction(ObjectContext, ObjectID);
            if (itemList.Count > 0)
            {
                foreach (ExaminationQueueItem item in itemList)
                {
                    item.CurrentStateDefID = ExaminationQueueItem.States.Cancelled;
                }
            }
        }

        public void CompleteMyExaminationQueueItems()
        {
            IList<ExaminationQueueItem> itemList = ExaminationQueueItem.GetByEpisodeAction(ObjectContext, ObjectID);
            if (itemList.Count > 0)
            {
                foreach (ExaminationQueueItem item in itemList)
                {
                    if (item.CurrentStateDefID != ExaminationQueueItem.States.Completed && item.CurrentStateDefID != ExaminationQueueItem.States.Cancelled)
                    {
                        item.CurrentStateDefID = ExaminationQueueItem.States.Completed;
                        if (item.EpisodeAction.ProcedureDoctor != null)
                            item.CompletedBy = item.EpisodeAction.ProcedureDoctor;
                    }
                }
            }
        }

        public virtual double CheckIfDayLimitExceeded()
        {
            PatientGroupDefinition patientGroupDef = Episode.GetMyPatientGroupDefinition();
            double limit = (double)(patientGroupDef.EpisodeClosingDayLimit == null ? 0 : patientGroupDef.EpisodeClosingDayLimit);
            //if (limit == 0 || limit == null)
            if (limit == 0)
                limit = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("CLOSEEPISODELASTUPDATEDAYLIMIT", "10"));
            double templimit = (double)(-1 * limit);
            DateTime LimitLastUpdateDate = Convert.ToDateTime(Common.RecTime()).AddDays(templimit);

            if ((limit > 0) && RequestDate < LimitLastUpdateDate)
                return limit;
            else
                return 0;
        }

        public bool HasActiveQueueItem()
        {
            if (QueueItems.Count == 0)
                return false;
            foreach (ExaminationQueueItem queueItem in QueueItems)
            {
                if (queueItem.QueueDate.Value.Date == Common.RecTime().Date)
                {
                    if (queueItem.CurrentStateDefID == ExaminationQueueItem.States.New || queueItem.CurrentStateDefID == ExaminationQueueItem.States.Called || queueItem.CurrentStateDefID == ExaminationQueueItem.States.Diverted)
                        return true;
                }
            }
            return false;
        }

        public ExaminationQueueItem GetActiveQueueItem(bool forceToRecTime)
        {
            if (QueueItems.Count == 0)
                return null;
            foreach (ExaminationQueueItem queueItem in QueueItems)
            {
                if (queueItem.CurrentStateDefID == ExaminationQueueItem.States.New || queueItem.CurrentStateDefID == ExaminationQueueItem.States.Called || queueItem.CurrentStateDefID == ExaminationQueueItem.States.Diverted)
                {
                    if (forceToRecTime)
                    {
                        if (queueItem.QueueDate.Value.Date == Common.RecTime().Date)
                            return queueItem;
                    }
                    else
                        return queueItem;
                }
            }
            return null;
        }

        public QuotaHistory CheckIfQuotaReturn()
        {
            DateTime startDate = Convert.ToDateTime(RequestDate.Value.ToShortDateString() + " " + "00:00:00");
            DateTime endDate = Convert.ToDateTime(RequestDate.Value.ToShortDateString() + " " + "23:59:59");

            BindingList<QuotaHistory> quotaHistory = QuotaHistory.GetByPatientAndRessection(ObjectContext, Episode.Patient.ObjectID, MasterResource.ObjectID, startDate, endDate);

            if (quotaHistory.Count > 0)
                return quotaHistory[0];

            return null;
        }

        public bool IsMedulaProvisionNecessaryProcedureExists()
        {
            foreach (SubActionProcedure sp in SubactionProcedures)
            {
                if (!sp.IsCancelled && sp.ProcedureObject != null && sp.ProcedureObject.DailyMedulaProvisionNecessity == true)
                    return true;
            }
            return false;
        }

        // Tüm SubactionProcedure ve SubActionMaterial lerinin, "Tahakkuk" ve "Yeni" durumundaki "Kurum Payı" olan AccountTransaction larını,
        // "Yeni" durumunda "Hasta Payı" na çevirir
        public void TurnMySubActionsToPatientShare(bool withMedulaDontSend)
        {
            foreach (SubActionProcedure sp in GetAccountableSubActionProcedures())
                sp.TurnMyAccountTransactionsToPatientShare(withMedulaDontSend);

            foreach (SubActionMaterial sm in GetAccountableSubActionMaterials())
                sm.TurnMyAccountTransactionsToPatientShare(withMedulaDontSend);
        }

        // EpisodeAction ile Paket SP nin AltVakası aynı mı kontrolü yapar
        public bool InSameSubEpisodeWithPackageSP(SubActionProcedure packageSP)
        {
            // Sadece Alt Vaka bazında fatura kesenlerde bu kontrol yapılacak
            if (SystemParameter.GetParameterValue("INVOICEBYSUBEPISODE", "FALSE") == "TRUE")
            {
                if (SubEpisode != null && packageSP.SubEpisode != null)
                {
                    if (!SubEpisode.ObjectID.Equals(packageSP.SubEpisode.ObjectID))
                        return false;
                }
            }
            return true;
        }

        // Medula Hizmet Kayıt işleminde kullanılacak olan branş kodunu döndürür
        public string GetBranchCodeForMedula()
        {
            if (!(this is ProcedureMaterialAdding))
            {
                // Havale Edilen kaynağın uzmanlığı alınır
                if (MasterResource != null)
                {
                    foreach (ResourceSpecialityGrid resSpeciality in MasterResource.ResourceSpecialities)
                    {
                        if (resSpeciality.Speciality != null)
                            return resSpeciality.Speciality.Code;
                    }
                }
                // Havale Edilen kaynağın uzmanlığı bulunamazsa, Havale Eden kaynağın uzmanlığı alınır
                if (FromResource != null)
                {
                    foreach (ResourceSpecialityGrid resSpeciality in FromResource.ResourceSpecialities)
                    {
                        if (resSpeciality.Speciality != null)
                            return resSpeciality.Speciality.Code;
                    }
                }
            }

            if (SubEpisode != null)
            {
                if (SubEpisode.Speciality != null)
                    return SubEpisode.Speciality.Code;
                else if (SubEpisode.ResSection != null && SubEpisode.ResSection.ResourceSpecialities != null && SubEpisode.ResSection.ResourceSpecialities.Count > 0)
                {
                    if (SubEpisode.ResSection.ResourceSpecialities[0].Speciality != null)
                        return SubEpisode.ResSection.ResourceSpecialities[0].Speciality.Code;
                }

            }

            return null;
        }


        public virtual void CompleteMySubActionProcedures()
        {
            foreach (SubActionProcedure sp in SubactionProcedures)
            {
                sp.AutoComplete();
            }
        }

        public virtual void SetMySubActionProceduresPerformedDate()
        {
            foreach (SubActionProcedure subactionProcedure in SubactionProcedures.Where(x => x.CurrentStateDef.Status != StateStatusEnum.Cancelled))
            {
                if (subactionProcedure.PerformedDate == null)
                    subactionProcedure.SetPerformedDate();
            }
        }



        public virtual bool SetMyProcedureDoctorToMySubactionProcedure()
        {
            return true;
        }


        public virtual IList<Episode> LimiteEpisodesOfPatientToStartFromNewActionInPatientFolder(IList<Episode> episodes)
        {
            return episodes;
        }

        public virtual void SetPropertiesWhenStartFromNewActionInPatientFolder(Episode episode)
        {
        }

        public virtual void CheckRulesForNewEpisodeAction()
        {
        }
        public virtual void SetMyPropertiesByMasterAction(EpisodeAction masterEpisodeAction)
        {
            // Clientdan MasterEpisodeAction ile yeni Episodeacion başlatılırken set edilmesi gereken özellikler için 
            //FromResource,MasterAction,Episode alanları bu methodun çağırıldığı yerde zaten set ediliyor bunlar harici bir özellik masterActiondan alınması gerekiyorsa bu method overrideedilmeli
        }

        public class RequestedBloodBankProcedureInfo
        {
            public Guid procedureRequestFormDetailDefinitionID;
            public string externalSystemBloodProductID;  //Kan urun ID
            public Guid procedureDefinitionID;
        }

        public class AdditionalApplicationRequestInfo
        {
            public Guid ProcedureObjectID;
            public int Amount;
            public DateTime RequestDate;
            public Guid ProcedureUserId;
            public List<BaseAdditionalInfo> BaseAdditionalInfos = new List<BaseAdditionalInfo>();
            public string Description;
            //FTR Rapor bilgisi ile ilgili alanlar
            public string MedulaReportNo;
            public Guid ReportApplicationArea;
            public RightLeftEnum? RightLeftInformation;
        }


        public class RequestedProcedureRequestInfo
        {
            public ProcedureRequestFormDetailDefinition ProcedureRequestFormDetailDefinition;
            public DateTime RequestDate;
            public Guid ProcedureUserId;
            public RightLeftEnum? RightLeftInformation;
            public SKRSTekrarTetkikIstemGerekcesi ReasonForRepetition;
        }

        public class SUTRuleResult
        {
            public bool validateSutRules;
            public bool BlockRequest;
            public List<SUTRuleViolateMessage> SUTRuleViolateMessages = new List<SUTRuleViolateMessage>();
        }

        public class SUTRuleViolateMessage
        {
            public string ProcedureDate;
            public string ProcedureCode;
            public string Message;
        }

        public static SUTRuleResult ValidateSutRules(Episode episode, List<SubActionProcedure> subActionProcedureList)
        {
            SUTRuleResult resultValue = new SUTRuleResult();
            TTUtils.Entities.RuleValidateResultDto validateResult = CheckSutRules(episode, subActionProcedureList);
            // SUT kural doğrulama sonucu hiç bir mesaj dönmedi
            if (validateResult == null || !EnumerableHelper.Any(validateResult.Messages))
            {
                resultValue.validateSutRules = true;
                return resultValue;
            }

            string resultXml = SerializationHelper.XmlSerializeObject(validateResult.Messages);
            string resultText = resultXml;
            if (resultText.Length > 4000)
            {
                resultText = resultText.Substring(0, 4000);
            }

            TTObjectContext context = new TTObjectContext(false);
            SUTRuleCheckResult sutCheckResult = new SUTRuleCheckResult(context);
            sutCheckResult.ProcessDate = DateTime.Now;
            sutCheckResult.ResUser = TTUser.CurrentUser.UserObject as ResUser;
            sutCheckResult.Results = resultText;
            sutCheckResult.Status = SUTRuleCheckResultStatus.Rejected;
            sutCheckResult.Episode = episode;
            sutCheckResult.CheckResults = resultXml;
            //if (result == DialogResult.Ignore)
            //{
            //    sutCheckResult.Status = SUTRuleCheckResultStatus.Ignored;
            //}
            context.Save();
            resultValue.validateSutRules = false;
            resultValue.BlockRequest = validateResult.BlockRequest;
            //SUT mesajlarını liste ekle
            foreach (TTUtils.Entities.RuleViolateMessage ruleViolateMessage in validateResult.Messages)
            {
                SUTRuleViolateMessage sutRuleViolateMessage = new SUTRuleViolateMessage();
                sutRuleViolateMessage.ProcedureDate = ruleViolateMessage.ProcedureDate.ToString("dd.MM.yyyy");
                sutRuleViolateMessage.ProcedureCode = ruleViolateMessage.ProcedureCode;
                sutRuleViolateMessage.Message = ruleViolateMessage.Message;
                resultValue.SUTRuleViolateMessages.Add(sutRuleViolateMessage);
            }

            return resultValue;
        }

        private static TTUtils.Entities.RuleValidateResultDto CheckSutRules(Episode episode, List<SubActionProcedure> SubactionProcedures)
        {
            string sutRuleEngineEnabled = SystemParameter.GetParameterValue("SUT_RULE_ENGINE_ENABLED", string.Empty);
            if (sutRuleEngineEnabled != "TRUE")
                return null;

            List<TTUtils.Entities.ProcedureEntryDto> procedureEntries = new List<TTUtils.Entities.ProcedureEntryDto>();
            List<SubActionProcedure> subActionProcedureList = new List<SubActionProcedure>();

            DateTime? ruleStartDate = null;
            string ruleStartDateParam = SystemParameter.GetParameterValue("SUT_RULE_ENGINE_STARTDATE", null);
            if (!string.IsNullOrWhiteSpace(ruleStartDateParam))
            {
                DateTime startDate;
                if (DateTime.TryParse(ruleStartDateParam, out startDate))
                    ruleStartDate = startDate;
            }

            foreach (SubActionProcedure subActionProcedure in SubactionProcedures)
            {
                if (subActionProcedure.ProcedureObject == null)
                    continue;

                if (subActionProcedure.IsCancelled)
                    continue;

                //ITTObject subActionProcedureObject = subActionProcedure as ITTObject;
                //if (!subActionProcedureObject.IsNew)
                //    continue;

                if (subActionProcedure.SUTRuleStatus == SutRuleEngineStatus.Passed || subActionProcedure.SUTRuleStatus == SutRuleEngineStatus.RuleViolationIgnored)
                    continue;

                DateTime entryDate = subActionProcedure.ActionDate ?? DateTime.Now;

                if (ruleStartDate.HasValue && entryDate < ruleStartDate.Value)
                    continue;

                TTUtils.Entities.ProcedureEntryDto procedureEntry = new TTUtils.Entities.ProcedureEntryDto();
                procedureEntry.SubActionProcedureId = subActionProcedure.ObjectID;
                procedureEntry.ProcedureCode = subActionProcedure.ProcedureObject.Code;
                procedureEntry.EntryQuantity = (decimal)(subActionProcedure.Amount ?? 1);
                procedureEntry.EntryDate = entryDate;
                procedureEntries.Add(procedureEntry);
                subActionProcedureList.Add(subActionProcedure);
            }

            if (subActionProcedureList.Count == 0)
                return null;

            //string settingName = "SUTRULECHECKERSERVERIP";
            //string serverIpAddress = TTObjectClasses.SystemParameter.GetParameterValue(settingName, string.Empty);

            IRuleCheckEngine service = SutRuleServiceFactory.Instance;
            object patientId = episode.Patient.ObjectID;
            object episodeId = episode.ObjectID;

            TTUtils.Entities.RuleValidateResultDto validateResults = service.ValidateRules(patientId, episodeId, procedureEntries.ToArray(), null);

            bool ruleViolationExists = false;
            if (validateResults != null && validateResults.Messages.Count > 0)
            {
                ruleViolationExists = true;
            }

            foreach (SubActionProcedure subActionProcedure in subActionProcedureList)
            {
                subActionProcedure.SUTRuleStatus = SutRuleEngineStatus.Passed;
                foreach (TTUtils.Entities.RuleViolateMessage ruleViolateMessage in validateResults.Messages)
                {
                    if (ruleViolateMessage.DetailId1 != null && subActionProcedure.ObjectID != null)
                    {
                        if (subActionProcedure.ProcedureObject.SUTCode == (string)ruleViolateMessage.DetailId1)
                        {
                            subActionProcedure.SUTRuleStatus = SutRuleEngineStatus.Violated;
                        }
                    }

                    if (ruleViolateMessage.DetailId2 != null && subActionProcedure.ObjectID != null)
                    {
                        if (subActionProcedure.ProcedureObject.SUTCode == (string)ruleViolateMessage.DetailId2)
                        {
                            subActionProcedure.SUTRuleStatus = SutRuleEngineStatus.Violated;
                        }
                    }
                }
            }

            //if (throwException)
            //{
            //    if (ruleViolationExists)
            //        throw new TTSutRuleEngineException(validateResults.Messages);
            //}
            return validateResults;
        }

        public List<SubActionProcedure> ProcessMyProcedureRequests(List<EpisodeAction.RequestedProcedureRequestInfo> reqFormDetails, List<EpisodeAction.AdditionalApplicationRequestInfo> addAppDetails, List<EpisodeAction.RequestedBloodBankProcedureInfo> requestedBloodProducts, bool emergency)
        {
            List<SubActionProcedure> createdSubActProcedures = new List<SubActionProcedure>();
            if (reqFormDetails != null)
            {
                //List<ProcedureRequestFormDetailDefinition> pdetListWorkFlowStarts = new List<ProcedureRequestFormDetailDefinition>();
                //List<ProcedureRequestFormDetailDefinition> pdetListWorkFlowNotStarts = new List<ProcedureRequestFormDetailDefinition>();

                List<EpisodeAction.RequestedProcedureRequestInfo> pdetListWorkFlowStarts = new List<EpisodeAction.RequestedProcedureRequestInfo>();
                List<EpisodeAction.RequestedProcedureRequestInfo> pdetListWorkFlowNotStarts = new List<EpisodeAction.RequestedProcedureRequestInfo>();

                foreach (EpisodeAction.RequestedProcedureRequestInfo reqDet in reqFormDetails)
                {
                    IProcedureRequestDefinition procReq = (IProcedureRequestDefinition)reqDet.ProcedureRequestFormDetailDefinition.ProcedureDefinition;
                    if (procReq.GetIsProcedureFlowStarts() == true)
                        pdetListWorkFlowStarts.Add(reqDet);
                    else
                        pdetListWorkFlowNotStarts.Add(reqDet);
                }

                if (pdetListWorkFlowNotStarts.Count > 0)
                {
                    foreach (EpisodeAction.RequestedProcedureRequestInfo reqDet in pdetListWorkFlowNotStarts)
                    {
                        BaseAdditionalApplication sa = CreateBaseAdditionalApplication();
                        sa.CreationDate = reqDet.RequestDate;
                        sa.ActionDate = reqDet.RequestDate; //DateTime.Now;
                        sa.PerformedDate = reqDet.RequestDate;
                        sa.ProcedureObject = reqDet.ProcedureRequestFormDetailDefinition.ProcedureDefinition;
                        if (reqDet.ProcedureUserId != null)
                            sa.ProcedureDoctor = (ResUser)ObjectContext.GetObject(reqDet.ProcedureUserId, "ResUser");
                        else
                            sa.ProcedureDoctor = Common.CurrentResource;
                        sa.RequestedByUser = Common.CurrentResource;
                        sa.NurseNotes = "";
                        sa.Result = "";
                        sa.CurrentStateDefID = SubActionProcedure.States.Completed;
                        sa.RightLeftInformation = reqDet.RightLeftInformation;
                        SubactionProcedures.Add(sa);
                        createdSubActProcedures.Add(sa);
                    }
                }

                if (pdetListWorkFlowStarts.Count > 0)
                {
                    Dictionary<string, EpisodeAction> myEAList = new Dictionary<string, EpisodeAction>();
                    myEAList = CreateActionForMyProcedureRequests(pdetListWorkFlowStarts, emergency);

                    ForwardNextStepMyActionOfProcedureRequests(myEAList);

                    foreach (KeyValuePair<string, EpisodeAction> myEA in myEAList)
                    {
                        EpisodeAction ea = myEA.Value;
                        foreach (SubActionProcedure sp in ea.SubactionProcedures)
                        {
                            createdSubActProcedures.Add(sp);
                        }
                    }
                }
            }
            if (addAppDetails != null)
            {
                foreach (EpisodeAction.AdditionalApplicationRequestInfo addAppDet in addAppDetails)
                {
                    BaseAdditionalApplication sa = CreateBaseAdditionalApplication();
                    ProcedureDefinition addAppDef = (ProcedureDefinition)ObjectContext.GetObject(addAppDet.ProcedureObjectID, "ProcedureDefinition");
                    if (IsOldAction != true)
                    {
                        sa.ActionDate = DateTime.Now;
                    }
                    sa.CreationDate = addAppDet.RequestDate;
                    sa.ActionDate = addAppDet.RequestDate;
                    sa.PerformedDate = addAppDet.RequestDate;
                    sa.ProcedureObject = addAppDef;
                    sa.Amount = addAppDet.Amount;
                    sa.Description = addAppDet.Description;
                    sa.RightLeftInformation = addAppDet.RightLeftInformation;

                    if (addAppDet.ProcedureUserId != null)
                        sa.ProcedureDoctor = (ResUser)ObjectContext.GetObject(addAppDet.ProcedureUserId, "ResUser");
                    else
                        sa.ProcedureDoctor = Common.CurrentResource;
                    sa.RequestedByUser = Common.CurrentResource;
                    sa.NurseNotes = "";
                    sa.Result = "";
                    //BaseAdditional a raporno ve vucut bolgesi set etme
                    sa.MedulaReportNo = addAppDet.MedulaReportNo;
                    if (addAppDet.ReportApplicationArea != null && addAppDet.ReportApplicationArea != Guid.Empty)
                        sa.ReportApplicationArea = (FTRVucutBolgesi)ObjectContext.GetObject(addAppDet.ReportApplicationArea, "FTRVucutBolgesi");

                    sa.CurrentStateDefID = SubActionProcedure.States.Completed;

                    foreach (BaseAdditionalInfo baseAdditionalInfo in addAppDet.BaseAdditionalInfos)
                    {
                        baseAdditionalInfo.BaseAdditionalApplication = sa;
                    }

                    SubactionProcedures.Add(sa);
                    createdSubActProcedures.Add(sa);

                    if (addAppDef.Code == "700050" && IsOldAction != true) //Deri Prick Testi ise türetilmiş tüm işlemleri at.
                    {
                        List<BaseAdditionalApplication> skinPrickSA = new List<BaseAdditionalApplication>();
                        skinPrickSA = CreateSkinPrickTests(addAppDet, sa);
                        foreach (BaseAdditionalApplication ba in skinPrickSA)
                        {
                            SubactionProcedures.Add(ba);
                            createdSubActProcedures.Add(ba);
                        }
                    }
                }
            }

            if (requestedBloodProducts != null)
            {
                if (requestedBloodProducts.Count > 0)
                {
                    EpisodeAction ea = CreateActionForBloodBankRequest(requestedBloodProducts, emergency);

                    //this.ForwardNextStepMyActionOfProcedureRequests(myEAList);
                    if (ea != null)
                    {
                        foreach (SubActionProcedure sp in ea.SubactionProcedures)
                        {
                            createdSubActProcedures.Add(sp);
                        }
                    }
                }
            }

            return createdSubActProcedures;

        }

        public List<BaseAdditionalApplication> CreateSkinPrickTests(EpisodeAction.AdditionalApplicationRequestInfo addAppDet, BaseAdditionalApplication MasterSubactionProcedure)
        {
            List<BaseAdditionalApplication> resultList = new List<BaseAdditionalApplication>();


            string injectionSql = " WHERE SUTCODE = '700050' and CODE <> '700050' AND ISACTIVE = 1";
            BindingList<ProcedureDefinition> procedureDefList = ProcedureDefinition.GetAllProcedureDefinitions(ObjectContext, injectionSql);

            foreach (ProcedureDefinition pd in procedureDefList)
            {
                BaseAdditionalApplication sa = CreateBaseAdditionalApplication();
                ProcedureDefinition addAppDef = (ProcedureDefinition)ObjectContext.GetObject(pd.ObjectID, "ProcedureDefinition");
                if (IsOldAction != true)
                {
                    sa.ActionDate = DateTime.Now;
                }
                sa.CreationDate = addAppDet.RequestDate;
                sa.ActionDate = addAppDet.RequestDate;
                sa.PerformedDate = addAppDet.RequestDate;
                sa.ProcedureObject = addAppDef;
                sa.Amount = addAppDet.Amount;
                sa.Description = addAppDet.Description;
                if (addAppDet.ProcedureUserId != null)
                    sa.ProcedureDoctor = (ResUser)ObjectContext.GetObject(addAppDet.ProcedureUserId, "ResUser");
                else
                    sa.ProcedureDoctor = Common.CurrentResource;
                sa.RequestedByUser = Common.CurrentResource;
                sa.NurseNotes = "";
                sa.Result = "";
                //BaseAdditional a raporno ve vucut bolgesi set etme
                sa.MedulaReportNo = addAppDet.MedulaReportNo;
                if (addAppDet.ReportApplicationArea != null && addAppDet.ReportApplicationArea != Guid.Empty)
                    sa.ReportApplicationArea = (FTRVucutBolgesi)ObjectContext.GetObject(addAppDet.ReportApplicationArea, "FTRVucutBolgesi");

                sa.CurrentStateDefID = SubActionProcedure.States.Completed;
                sa.MasterSubActionProcedure = (SubActionProcedure)MasterSubactionProcedure;


                resultList.Add(sa);
            }


            return resultList;
        }
        public virtual BaseAdditionalApplication CreateBaseAdditionalApplication()
        {
            return new BaseAdditionalApplication(ObjectContext);
        }

        public void AddMyProcedureRequestsAsAdditionalProcedures(List<ProcedureRequestFormDetailDefinition> reqDetails)
        {

            foreach (ProcedureRequestFormDetailDefinition reqDet in reqDetails)
            {
                BaseAdditionalApplication sa = CreateBaseAdditionalApplication();
                if (IsOldAction != true)
                    sa.ActionDate = DateTime.Now;
                sa.ProcedureObject = reqDet.ProcedureDefinition;
                sa.ProcedureDoctor = Common.CurrentResource;
                sa.NurseNotes = "";
                sa.Result = "";
                SubactionProcedures.Add(sa);
            }

        }
        public Dictionary<string, EpisodeAction> CreateActionForMyProcedureRequests(List<EpisodeAction.RequestedProcedureRequestInfo> reqDetails, bool emergency)
        {


            Dictionary<string, EpisodeAction> EAList = new Dictionary<string, EpisodeAction>();


            foreach (EpisodeAction.RequestedProcedureRequestInfo reqDet in reqDetails)
            {
                //reqDeatil in masterres i icin action yaratılacak. 

                IProcedureRequestDefinition procReq = (IProcedureRequestDefinition)reqDet.ProcedureRequestFormDetailDefinition.ProcedureDefinition;
                EpisodeAction ea = null;

                //Psikoloji testleri icin ayni bolumde yapilsa bile herbir test icin ayri episodeAction yaratilacak.
                if (reqDet.ProcedureRequestFormDetailDefinition.ProcedureDefinition is PsychologyProcedureDefiniton)
                {
                    ea = procReq.CreateMyEpisodeAction(this, reqDet.ProcedureRequestFormDetailDefinition.ObservationUnit, MasterResource, false, emergency, reqDet.RequestDate, reqDet.ProcedureUserId, false);
                    EAList.Add(ea.ObjectID.ToString(), ea);
                }
                else
                {
                    if (EAList.TryGetValue((procReq.GetMyFiredActionDefName() + "-" + reqDet.ProcedureRequestFormDetailDefinition.ObservationUnit.ObjectID.ToString()), out ea) == false)
                    {
                        ea = procReq.CreateMyEpisodeAction(this, reqDet.ProcedureRequestFormDetailDefinition.ObservationUnit, MasterResource, false, emergency, reqDet.RequestDate, reqDet.ProcedureUserId, false);
                        EAList.Add((procReq.GetMyFiredActionDefName() + "-" + reqDet.ProcedureRequestFormDetailDefinition.ObservationUnit.ObjectID.ToString()), ea);
                    }
                }

                SubActionProcedure sp = procReq.CreateMySubactionProcedure(ea, reqDet.ProcedureRequestFormDetailDefinition.ObservationUnit, MasterResource);
                if (reqDet.RightLeftInformation != null)
                    sp.RightLeftInformation = reqDet.RightLeftInformation;
                //Radyoloji testleri için sınırlı gün süresinen önce tekrar istem girildiğinde istem gerekçesi set edilecek. 
                if (reqDet.ReasonForRepetition != null)
                    sp.ReasonForRepetition = reqDet.ReasonForRepetition;
            }

            //step atlatmadan once epısodeactıon da kontroller yapılmalı
            foreach (KeyValuePair<string, EpisodeAction> myEA in EAList)
            {
                myEA.Value.DoMyActionControlsForProcedureRequest();
            }

            return EAList;

        }

        public void CreateNewBirthReportRequest()
        {
            BirthReportRequest birthReportRequest;
            BirthReportRequest tempBirthReport = MyBirthReportRequest();
            //if (InANewContext)
            //{
            //    TTObjectContext objectContext = new TTObjectContext(false);
            //    Guid savePointGuid = objectContext.BeginSavePoint();
            //    try
            //    {
            //        if (tempBirthReport == null)
            //            birthReportRequest = new BirthReportRequest(objectContext, this);
            //        else
            //            birthReportRequest = (BirthReportRequest)objectContext.GetObject(tempBirthReport.ObjectID, "BirthReportRequest");
            //        //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            //        //TTForm frm = TTForm.GetEditForm(birthReportRequest);
            //        //this.PrapareFormToShow(frm);
            //        //if (frm.ShowEdit(this.FindForm(), birthReportRequest) == DialogResult.OK)
            //        //{
            //        //    objectContext.Save();
            //        //}
            //        //else
            //        //{
            //        //    throw new TTUtils.TTException(SystemMessage.GetMessage(155));
            //        //    //throw new Exception("Doğum Raporu Giriş İşleminden Vazgeçildi");
            //        //}
            //    }
            //    catch (Exception ex)
            //    {
            //        objectContext.RollbackSavePoint(savePointGuid);
            //        InfoBox.Show(ex);
            //    }
            //    finally
            //    {
            //        objectContext.Dispose();
            //    }
            //}
            //else
            //{
            if (tempBirthReport == null)
                birthReportRequest = new BirthReportRequest(ObjectContext, this);
            else
                birthReportRequest = (BirthReportRequest)ObjectContext.GetObject(tempBirthReport.ObjectID, "BirthReportRequest");
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            //TTForm frm = TTForm.GetEditForm(birthReportRequest);
            //this.PrapareFormToShow(frm);
            //if (frm.ShowEdit(this.FindForm(), birthReportRequest) != DialogResult.OK)
            //{
            //    throw new TTUtils.TTException(SystemMessage.GetMessage(155));
            //    //throw new Exception("Doğum Raporu Giriş İşleminden Vazgeçildi");
            //    //}

            //}
        }

        public BloodProductRequest CreateActionForBloodBankRequest(List<EpisodeAction.RequestedBloodBankProcedureInfo> reqDetails, bool emergency)
        {


            //TODO: Kan  bankası resobservatıon unıt sıstem parametresıdnen alınabılır.
            ResObservationUnit masterRes = (ResObservationUnit)ObjectContext.GetObject(new Guid("021abcc9-3fe1-4d76-ac24-478df522fb43"), "ResObservationUnit");
            string bloodRequestExternalID = "";

            //Create BloodBankRequest action
            //CreateMyEpisodeAction(EpisodeAction starterEA, ResSection masterRes, ResSection fromRes, bool setMasterAction, bool emergency)

            BloodProductRequest bloodRequestAction = (BloodProductRequest)ObjectContext.CreateObject("BloodProductRequest");
            bloodRequestAction.SetMandatoryEpisodeActionProperties(this, masterRes, MasterResource, false);
            bloodRequestAction.CurrentStateDefID = BloodProductRequest.States.BloodProductRequest;
            bloodRequestAction.SetMyActionMandatoryProperties();
            bloodRequestAction.MasterAction = (BaseAction)this;
            bloodRequestAction.BloodBankRequestExternalID = "";
            if (emergency == true)
                bloodRequestAction.Emergency = emergency;
            bloodRequestAction.Update();

            foreach (EpisodeAction.RequestedBloodBankProcedureInfo reqDet in reqDetails)
            {
                BloodBankBloodProducts bloodProduct = (BloodBankBloodProducts)ObjectContext.CreateObject("BloodBankBloodProducts");
                BloodBankTestDefinition bloodBankTestDef = (BloodBankTestDefinition)ObjectContext.GetObject(reqDet.procedureDefinitionID, "BloodBankTestDefinition");

                SubactionProcedureFlowable.SetMandatorySubactionProcedureFlowableProperties(bloodRequestAction, masterRes, MasterResource, bloodProduct);
                bloodProduct.ProcedureObject = bloodBankTestDef;
                bloodProduct.EpisodeAction = bloodRequestAction;
                if (bloodRequestAction.Emergency == true)
                    bloodProduct.Emergency = true;

                string[] bloodProductExternalIdsArr = reqDet.externalSystemBloodProductID.Split('|');
                bloodProduct.BloodProductExternalID = bloodProductExternalIdsArr[0];
                if (bloodRequestExternalID == "")
                    bloodRequestExternalID = bloodProductExternalIdsArr[1];

                bloodRequestAction.SubactionProcedures.Add((SubActionProcedure)bloodProduct);

            }
            bloodRequestAction.BloodBankRequestExternalID = bloodRequestExternalID;
            bloodRequestAction.DoMyActionControlsForProcedureRequest();
            bloodRequestAction.CurrentStateDefID = (Guid)BloodProductRequest.States.BloodProductPreparation;
            bloodRequestAction.Update();

            return bloodRequestAction;

        }

        public void ForwardNextStepMyActionOfProcedureRequests(Dictionary<string, EpisodeAction> eaList)
        {
            Guid? startedStateDefID = null;
            foreach (KeyValuePair<string, EpisodeAction> myEA in eaList)
            {
                startedStateDefID = myEA.Value.ProcedureRequestStartedStateDefID();

                if (startedStateDefID != null && startedStateDefID != Guid.Empty)
                {
                    EpisodeAction myFiredAction = myEA.Value;
                    myFiredAction.CurrentStateDefID = startedStateDefID;
                    myFiredAction.Update();
                }
            }
        }


        public virtual Guid ProcedureRequestStartedStateDefID()
        {
            return new Guid();
        }

        public virtual void DoMyActionControlsForProcedureRequest()
        {
        }

        public virtual void SetMyActionMandatoryProperties()
        { }
        /// <summary>
        /// iptal edilen SubEpisodelara ait işlemleri bir önceki sub episode atamak
        /// </summary>
        public virtual void CancelSubEpisode()
        {
            if (SubEpisode != null)
            {
                SubEpisode currentSubEpisode = SubEpisode;

                if (currentSubEpisode.StarterEpisodeAction != null && currentSubEpisode.StarterEpisodeAction.ObjectID == ObjectID)// iptal edilen EpisodeAction bu SubEpisodeu başlatan EA ise
                {
                    //İlk subEpisode iptal edilmez....
                    SubEpisode oldSubEpisode = currentSubEpisode.OldSubEpisode;
                    if (oldSubEpisode != null)// iptal edilecek işlemin öncesinde bir SubEpisode açıldı ise o SubEpisodea ait işlemler bir önceki  SubEpisodea taşınır
                    {
                        currentSubEpisode.CurrentStateDefID = SubEpisode.States.Cancelled;
                        List<EpisodeAction> chEAList = new List<EpisodeAction>();
                        foreach (EpisodeAction ea in currentSubEpisode.EpisodeActions)
                        {
                            if (ea.CurrentStateDef.Status != StateStatusEnum.Cancelled) //İşlem iptal edilmedi ise SubEpisodu değiştirilir
                                chEAList.Add(ea);
                        }
                        foreach (EpisodeAction ea in chEAList)
                        {
                            ea.SubEpisode = oldSubEpisode;
                        }

                        // iptal edilen subepisodeun old episode olduğu subepisodeların old episodeları iptal edileninki ile değiştirilir
                        List<SubEpisode> chSubEpisodeList = new List<SubEpisode>();
                        foreach (SubEpisode subepisode in Episode.SubEpisodes)
                        {
                            if (subepisode.CurrentStateDef.Status != StateStatusEnum.Cancelled)  // Cancel Objelerde Property Set edilebildiğinde silisin
                                chSubEpisodeList.Add(subepisode);
                        }
                        foreach (SubEpisode subepisode in chSubEpisodeList)
                        {
                            if (subepisode.OldSubEpisode != null && subepisode.OldSubEpisode.ObjectID == currentSubEpisode.ObjectID)
                                subepisode.OldSubEpisode = oldSubEpisode;
                        }
                        List<SubEpisode> openedSubEpisodeList = Episode.GetMyOpenedSubEpisodes();
                        if (openedSubEpisodeList.Count < 1)// eğer episodeda başka açık subEpisode Kalmadı ise eski Subepisode açılır.
                        {
                            if (oldSubEpisode.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                            {
                                oldSubEpisode.CurrentStateDefID = SubEpisode.States.Opened;
                            }
                            else
                            {
                                foreach (SubEpisode subepisode in chSubEpisodeList)// kapalı ilk subepisodeu açar...
                                {
                                    oldSubEpisode.CurrentStateDefID = SubEpisode.States.Opened;
                                    break;
                                }
                            }
                        }

                        currentSubEpisode.CancelSubEpisodeProtocols(); // SubEpisode iptal olurken, SubEpisodeProtocol lerini de iptal eder  
                        //this.Episode.MainSpeciality = oldSubEpisode.Speciality; // artık Yeni SubEpisode MainSpeciality değerini değiştirmiyor
                    }
                }

            }
        }

        //<ICreateSubEpisode Methodları

        //SubEpisodu Başlatan işlem tarafından(PatientAddmission Yada EpisodeAction) başlayan tüm işlemlerin SubEpisodunun değişmesi için .İstisna varsa overrie edilebilir Örn: Klinik İşlemleri  subepisode oluştururuken doktor işlemleri , hemşire hemşire işlemleri gibi kendi başlattığı işlerinin de Subepisodeunu değiştirmeli
        public virtual List<EpisodeAction> GetLinkedEpisodeActionsForSubEpisode()
        {
            List<EpisodeAction> eaList = new List<EpisodeAction>();
            foreach (BaseAction ea in LinkedActions)
            {
                if (ea is EpisodeAction)
                    eaList.Add((EpisodeAction)ea);
            }
            return eaList;
        }

        public virtual void SetLinkedEpisodeActionsForSubEpisode(List<EpisodeAction> value)
        {
        }

        // İşlem SubEpisodu ArrangeMeOrCreateNewSubEpisode methodunu kullanmadan  Kendi oluşturacaksa oluşturduğu SubEpisodu döndürür
        // PatientAdmissionda bu method null dönmez ArrangeMeOrCreateNewSubEpisodea girmeden önce SubEpisode yaratılıyor ki ekranda kullanılabilsin 
        // EpisodeActionlar için önce null olur, SubEpisode oluştuktan sonra dolu gelir
        public virtual SubEpisode GetSubEpisodeCreatedByMe() // ICreateSubEpisode  interfacei için  kullanılır
        {
            return Episode.SubEpisodes.Where(x => x.StarterEpisodeAction != null && x.StarterEpisodeAction.ObjectID == ObjectID).FirstOrDefault();
        }

        public virtual void SetSubEpisodeCreatedByMe(SubEpisode value) // ICreateSubEpisode  interfacei için  kullanılır
        {
        }

        public virtual SubEpisodeStatusEnum GetSubEpisodePatientStatus()
        {
            if (Episode.PatientStatus != PatientStatusEnum.Outpatient)
                return SubEpisodeStatusEnum.Inpatient;

            return SubEpisodeStatusEnum.Outpatient;
        }

        public virtual void SetSubEpisodePatientStatus(SubEpisodeStatusEnum value)
        {

        }

        //SubEpisodeu oluşturan işlemin Kaynağı işlemin SetProcedureSpecialtyBy attributuna bağlı defualtu MASTERRESOURCE
        public virtual ResSection GetSubEpisodeResSection()
        {
            return (ResSection)GetResourceOfSepeciality();
        }

        public virtual void SetSubEpisodeResSection(ResSection value)
        {

        }
        //ICreateSubEpisode için default Uzmanlık Dalı İşlemin Uzmanlık Dalı
        public virtual SpecialityDefinition GetSubEpisodeSpeciality()
        {
            return (SpecialityDefinition)ProcedureSpeciality;
        }

        public virtual void SetSubEpisodeSpeciality(SpecialityDefinition value)
        {
        }

        public ISubEpisodeStarter GetSubEpisodeStarter()
        {
            return (ISubEpisodeStarter)this;
        }

        public void SetSubEpisodeStarter(ISubEpisodeStarter value)
        {

        }

        public SubEpisodeProtocol SEP
        {
            get
            {
                return SubEpisode?.FirstSubEpisodeProtocol;
            }
        }

        public virtual bool IsNewSubEpisodeNeeded()
        {
            return true;
        }

        public virtual bool Sent101Package()
        {
            return true;
        }

        public virtual void FillLocalSEPProperties(ref SubEpisodeProtocol sep)
        {
        }


        public virtual DiagnosisCopyEnum GetDiagnosisCopyEnum()
        {
            return DiagnosisCopyEnum.CopyFromLastSubEpisode;// defaultu
        }

        //ICreateSubEpisode Methodları>


        // ISubEpisodeStarter Methodları

        public virtual DateTime SubEpisodeOpeningDate()
        {
            return Common.RecTime();
        }
        public virtual DateTime SubEpisodeClosingDate()
        {
            return Common.RecTime();
        }
        //

        // Surgery Ve SubSurgery içn Ortak kodlar
        public void CheckMandatoryFiledsForSurgeryProcedures(bool isLastControl)
        {
            List<SurgeryProcedure> surgeryProcedureList = new List<SurgeryProcedure>();
            if (this is Surgery)
            {
                surgeryProcedureList = ((Surgery)this).MainSurgeryProcedures.ToList<SurgeryProcedure>();
            }
            else if (this is SubSurgery)
            {
                surgeryProcedureList = ((SubSurgery)this).SubSurgeryProcedures.ToList<SurgeryProcedure>();
            }
            string fullErrorString = "";
            foreach (SurgeryProcedure surgeryProcedure in surgeryProcedureList)
            {
                string errorString = "";
                if (surgeryProcedure.ProcedureDoctor == null)
                    errorString = "Sorumlu Cerrah girmediniz \n ";
                if (surgeryProcedure.IncisionType == null)
                    errorString = "Kesi Bilgisi girmediniz\n ";
                if (surgeryProcedure.Position == null)
                    errorString = "Taraf girmediniz\n ";


                if (isLastControl == true)
                {
                    if (surgeryProcedure.IsNeededEuroScoreEmpty() == true)
                    {
                        errorString = "Kardiak Risk Skoru (Euroscore)  girmediniz\n ";
                    }
                }
                // Sonda kalsın
                if (!string.IsNullOrEmpty(errorString))
                {
                    errorString = surgeryProcedure.ProcedureObject.Name + " ameliyatı için: \n " + errorString;
                    fullErrorString += errorString;
                }
            }

            if (fullErrorString != "")
            {
                throw new Exception(fullErrorString);
            }
        }

        public void MakingDirectPurchaseHasUsed()
        {

            foreach (BaseTreatmentMaterial treatmentMaterials in TreatmentMaterials)
            {
                if (treatmentMaterials is SurgeryDirectPurchaseGrid)
                {
                    ((SurgeryDirectPurchaseGrid)treatmentMaterials).DPADetailFirmPriceOffer.DirectPurchaseActionDetail.HasUsed = true;
                }

                if (treatmentMaterials is CodelessMaterialDirectPurchaseGrid)
                {
                    ((CodelessMaterialDirectPurchaseGrid)treatmentMaterials).DPADetailFirmPriceOffer.DirectPurchaseActionDetail.HasUsed = true;
                }
            }
        }

        public virtual string GetDirectPurchaseListFilter()
        {
            string filterString = "";
            if (Episode.Patient != null)
                filterString = "DIRECTPURCHASEACTIONDETAIL.DIRECTPURCHASEACTION.PATIENT = '" + Episode.Patient.ObjectID.ToString() + "'";
            return filterString;
        }
        public virtual string GetTreatmentMaterialListFilter(TTObjectDef treatmentMaterialDef)
        {
            // set edilen depoya göre Malzeme listesinin filtrelenmesi
            string filterString = string.Empty;
            //            string filterString = " THIS.OBJECTDEFNAME IN ('CONSUMABLEMATERIALDEFINITION') ";
            //            if (treatmentMaterialDef.AllAttributes.ContainsKey(typeof(TreatmentMaterialsInculdeDrugDefinitionAttribute).Name.ToString()))
            //            {
            //                filterString = "THIS.OBJECTDEFNAME IN ('CONSUMABLEMATERIALDEFINITION','DRUGDEFINITION') ";
            //            }

            if (!(TTObjectClasses.SystemParameter.GetParameterValue("WORKWITHOUTSTOCK", "FALSE") == "TRUE"))// Böyle Çalışmasının sebebi True haricince ne yazılırsa yazılsın aşağıdaki kodun çalışmasının istenmesi
            {
                Store store = GetStore(treatmentMaterialDef);
                if (store == null)
                    filterString = "OBJECTID is null";
                else
                    filterString = " STOCKS.INHELD>0 AND STOCKS.STORE = '" + store.ObjectID.ToString() + "'";
            }

            return filterString;
        }

        public Store GetStore(TTObjectDef treatmentMaterialDef)
        {
            if (treatmentMaterialDef.AllAttributes.ContainsKey(typeof(StoreUsageAttribute).Name.ToString()) == false)
            {
                return MasterResource.Store;
            }
            else
            {
                string storeUsageEnum = treatmentMaterialDef.Attributes["STOREUSAGEATTRIBUTE"].Parameters["StoreUsage"].Value.ToString();
                switch (storeUsageEnum)
                {
                    case "0":
                        return null;
                    case "1":
                        return MasterResource.Store;
                    case "2":
                        return FromResource.Store;
                    case "3":
                        return SecondaryMasterResource.Store;
                    case "4":
                        return Common.CurrentResource.Store;
                    case "5":
                        return EpisodeAction.GetSpecialResourceForStore(this).Store;
                    default:
                        return MasterResource.Store;

                }
            }

        }

        public void CreateSubActionMatPricingDet()
        {
            foreach (var tm in TreatmentMaterials)
            {
                if (tm is SurgeryDirectPurchaseGrid)
                {
                    SurgeryDirectPurchaseGrid sdg = (SurgeryDirectPurchaseGrid)tm;
                    SubActionMatPricingDet titubbPrice = new SubActionMatPricingDet(ObjectContext);
                    titubbPrice.PatientPrice = 0;
                    titubbPrice.SubActionMaterial = sdg;

                    if (sdg.DPADetailFirmPriceOffer != null && sdg.DPADetailFirmPriceOffer.OfferedSUTCode != null)
                    {
                        titubbPrice.ExternalCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTCode;
                        titubbPrice.Description = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTName;
                        titubbPrice.PayerPrice = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTPrice;
                    }
                    titubbPrice.ProductDefinition = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product;
                }
            }
        }



        // <VitalSings için 

        public EpisodeAction.VitalSingsFormViewModel GetVitalSingsFormViewModel(TTObjectContext objectContext)
        {
            EpisodeAction.VitalSingsFormViewModel viewModel = new EpisodeAction.VitalSingsFormViewModel();
            viewModel.BloodPressure_Diastolik = BloodPressures.FirstOrDefault()?.Diastolik.ToString();
            viewModel.BloodPressure_Sistolik = BloodPressures.FirstOrDefault()?.Sistolik.ToString();
            viewModel.Pulse_Value = Pulses.FirstOrDefault()?.Value.ToString();
            viewModel.Respiration_Value = Respirations.FirstOrDefault()?.Value.ToString();
            viewModel.Temperature_Value = Temperatures.FirstOrDefault()?.Value.ToString();
            viewModel.SPO2_Value = SPO2s.FirstOrDefault()?.Value.ToString();
            viewModel.Weight_Value = Weights.FirstOrDefault()?.Value;
            viewModel.Height_Value = Heights.FirstOrDefault()?.Value;
            if (viewModel.Weight_Value != null && viewModel.Height_Value != null)
            {

                viewModel.BMI_Value = CalculateBMI(Convert.ToDouble(viewModel.Weight_Value), Convert.ToDouble(viewModel.Height_Value));
            }

            viewModel.VitalSignsValues = new EpisodeAction.VitalSignsValues();
            viewModel.VitalSignsValues = SetVitalSignValues(objectContext);

            return viewModel;
        }

        public EpisodeAction.VitalSignsValues SetVitalSignValues(TTObjectContext objectContext)
        {
            //Vital Bulgular Normal Değerler
            EpisodeAction.VitalSignsValues result = new EpisodeAction.VitalSignsValues();

            VitalSignValueDefinition.GetVitalSignValueDefinition_Class[] vitalSignList = VitalSignValueDefinition.GetVitalSignValueDefinition(objectContext, "").ToArray();
            foreach (var vitalSign in vitalSignList)
            {
                if (Episode.Patient.Age >= vitalSign.MinAge && Episode.Patient.Age <= vitalSign.MaxAge && Episode.Patient.Sex.ObjectID == vitalSign.Sex)
                {
                    if (vitalSign.VitalSignType == VitalSignType.BloodPressure_Diastolic)
                    {
                        result.Diastolic_MaxValue = vitalSign.MaxValue;
                        result.Diastolic_MinValue = vitalSign.MinValue;
                        result.Diastolic_MaxWarning = vitalSign.MaxValueWarning;
                        result.Diastolic_MinWarning = vitalSign.MinValueWarning;

                    }
                    else if (vitalSign.VitalSignType == VitalSignType.BloodPressure_Systolic)
                    {
                        result.Systolic_MaxValue = vitalSign.MaxValue;
                        result.Systolic_MinValue = vitalSign.MinValue;
                        result.Systolic_MaxWarning = vitalSign.MaxValueWarning;
                        result.Systolic_MinWarning = vitalSign.MinValueWarning;

                    }
                    else if (vitalSign.VitalSignType == VitalSignType.Height)
                    {
                        result.Height_MaxValue = Convert.ToInt32(vitalSign.MaxValue);
                        result.Height_MinValue = Convert.ToInt32(vitalSign.MinValue);
                        result.Height_MaxWarning = vitalSign.MaxValueWarning;
                        result.Height_MinWarning = vitalSign.MinValueWarning;

                    }
                    else if (vitalSign.VitalSignType == VitalSignType.Pulse)
                    {
                        result.Pulse_MaxValue = vitalSign.MaxValue;
                        result.Pulse_MinValue = vitalSign.MinValue;
                        result.Pulse_MaxWarning = vitalSign.MaxValueWarning;
                        result.Pulse_MinWarning = vitalSign.MinValueWarning;


                    }
                    else if (vitalSign.VitalSignType == VitalSignType.Respiration)
                    {
                        result.Respiration_MaxValue = vitalSign.MaxValue;
                        result.Respiration_MinValue = vitalSign.MinValue;
                        result.Respiration_MaxWarning = vitalSign.MaxValueWarning;
                        result.Respiration_MinWarning = vitalSign.MinValueWarning;

                    }
                    else if (vitalSign.VitalSignType == VitalSignType.SPO2)
                    {
                        result.SPO2_MaxValue = vitalSign.MaxValue;
                        result.SPO2_MinValue = vitalSign.MinValue;
                        result.SPO2_MaxWarning = vitalSign.MaxValueWarning;
                        result.SPO2_MinWarning = vitalSign.MinValueWarning;

                    }
                    else if (vitalSign.VitalSignType == VitalSignType.Temperature)
                    {
                        result.Temperature_MaxValue = vitalSign.MaxValue;
                        result.Temperature_MinValue = vitalSign.MinValue;
                        result.Temperature_MaxWarning = vitalSign.MaxValueWarning;
                        result.Temperature_MinWarning = vitalSign.MinValueWarning;

                    }
                    else if (vitalSign.VitalSignType == VitalSignType.Weight)
                    {
                        result.Weight_MaxValue = Convert.ToDouble(vitalSign.MaxValue);
                        result.Weight_MinValue = Convert.ToDouble(vitalSign.MinValue);
                        result.Weight_MaxWarning = vitalSign.MaxValueWarning;
                        result.Weight_MinWarning = vitalSign.MinValueWarning;

                    }
                }
            }

            return result;
        }




        public double CalculateBMI(double weight, double height)
        {
            //string result = "";

            double w = Convert.ToDouble(weight);
            double h = height / 100;
            double bmi = w / (h * h);
            // result = bmi.ToString();


            return bmi;

        }

        public void SetVitalSingsFormViewModel(EpisodeAction.VitalSingsFormViewModel viewModel)
        {
            if (BloodPressures.Count == 0)
            {
                if (viewModel.BloodPressure_Sistolik != null || viewModel.BloodPressure_Diastolik != null)
                {
                    var bloodPressure = new BloodPressure(ObjectContext);
                    if (!string.IsNullOrEmpty(viewModel.BloodPressure_Sistolik))
                        bloodPressure.Sistolik = Convert.ToInt32(viewModel.BloodPressure_Sistolik);
                    if (!string.IsNullOrEmpty(viewModel.BloodPressure_Diastolik))
                        bloodPressure.Diastolik = Convert.ToInt32(viewModel.BloodPressure_Diastolik);
                    bloodPressure.EpisodeAction = this;
                    bloodPressure.ExecutionDate = Common.RecTime();
                }
            }
            else
            {
                var bloodPressure = BloodPressures[0];
                if (!string.IsNullOrEmpty(viewModel.BloodPressure_Sistolik))
                    bloodPressure.Sistolik = Convert.ToInt32(viewModel.BloodPressure_Sistolik);
                else
                    bloodPressure.Sistolik = null;
                if (!string.IsNullOrEmpty(viewModel.BloodPressure_Diastolik))
                    bloodPressure.Diastolik = Convert.ToInt32(viewModel.BloodPressure_Diastolik);
                else
                    bloodPressure.Diastolik = null;
            }

            if (Pulses.Count == 0)
            {
                if (!string.IsNullOrEmpty(viewModel.Pulse_Value))
                {
                    var pulse = new Pulse(ObjectContext);
                    pulse.Value = Convert.ToInt32(viewModel.Pulse_Value);
                    pulse.EpisodeAction = this;
                    pulse.ExecutionDate = Common.RecTime();
                }
            }
            else
            {
                var pulse = Pulses[0];
                if (!string.IsNullOrEmpty(viewModel.Pulse_Value))
                    pulse.Value = Convert.ToInt32(viewModel.Pulse_Value);
                else
                    pulse.Value = null;
            }

            if (Respirations.Count == 0)
            {
                if (!string.IsNullOrEmpty(viewModel.Respiration_Value))
                {
                    var respiration = new Respiration(ObjectContext);
                    respiration.Value = Convert.ToInt32(viewModel.Respiration_Value);
                    respiration.EpisodeAction = this;
                    respiration.ExecutionDate = Common.RecTime();
                }
            }
            else
            {
                var pulse = Respirations[0];
                if (!string.IsNullOrEmpty(viewModel.Respiration_Value))
                    pulse.Value = Convert.ToInt32(viewModel.Respiration_Value);
                else
                    pulse.Value = null;
            }

            if (Temperatures.Count == 0)
            {
                if (!string.IsNullOrEmpty(viewModel.Temperature_Value) && viewModel.Temperature_Value != "  ,")
                {
                    var temperature = new Temperature(ObjectContext);
                    temperature.Value = Convert.ToDouble(viewModel.Temperature_Value);
                    temperature.EpisodeAction = this;
                    temperature.ExecutionDate = Common.RecTime();
                }
            }
            else
            {
                var temp = Temperatures[0];
                if (!string.IsNullOrEmpty(viewModel.Temperature_Value))
                    temp.Value = Convert.ToDouble(viewModel.Temperature_Value);
                else
                    temp.Value = null;
            }

            if (SPO2s.Count == 0)
            {
                if (!string.IsNullOrEmpty(viewModel.SPO2_Value))
                {
                    var spo = new SPO2(ObjectContext);
                    spo.Value = Convert.ToInt32(viewModel.SPO2_Value);
                    spo.EpisodeAction = this;
                    spo.ExecutionDate = Common.RecTime();
                }
            }
            else
            {
                var pulse = SPO2s[0];
                if (!string.IsNullOrEmpty(viewModel.SPO2_Value))
                    pulse.Value = Convert.ToInt32(viewModel.SPO2_Value);
                else
                    pulse.Value = null;
            }

            if (Heights.Count == 0)
            {
                if (viewModel.Height_Value != null && !string.IsNullOrEmpty(viewModel.Height_Value.ToString()) && viewModel.Height_Value != 0)
                {
                    var height = new Height(ObjectContext);
                    height.Value = Convert.ToInt32(viewModel.Height_Value);
                    height.EpisodeAction = this;
                    height.ExecutionDate = Common.RecTime();
                }
            }
            else
            {
                var height = Heights[0];
                if (viewModel.Height_Value != null && !string.IsNullOrEmpty(viewModel.Height_Value.ToString()) && viewModel.Height_Value != 0)
                    height.Value = Convert.ToInt32(viewModel.Height_Value);
                else
                    height.Value = null;
            }

            if (Weights.Count == 0)
            {
                if (viewModel.Weight_Value != null && !string.IsNullOrEmpty(viewModel.Weight_Value.ToString()) && viewModel.Weight_Value != 0)
                {
                    var weight = new Weight(ObjectContext);
                    weight.Value = Convert.ToDouble(viewModel.Weight_Value);
                    weight.EpisodeAction = this;
                    weight.ExecutionDate = Common.RecTime();
                }
            }
            else
            {
                var weight = Weights[0];
                if (viewModel.Weight_Value != null && !string.IsNullOrEmpty(viewModel.Weight_Value.ToString()) && viewModel.Weight_Value != 0)
                    weight.Value = Convert.ToDouble(viewModel.Weight_Value);
                else
                    weight.Value = null;
            }
        }


        public class VitalSingsFormViewModel
        {

            public string BloodPressure_Sistolik;
            public string BloodPressure_Diastolik;
            public string Pulse_Value;
            public string Respiration_Value;
            public string Temperature_Value;
            public string SPO2_Value;
            public int? Height_Value;
            public double? Weight_Value;
            public double? BMI_Value;
            public EpisodeAction.VitalSignsValues VitalSignsValues;
        }

        public class VitalSignsValues
        {
            #region Vital Bulgular Normal Değerler

            public double? Systolic_MaxValue;
            public double? Systolic_MinValue;
            public double? Diastolic_MaxValue;
            public double? Diastolic_MinValue;
            public double? Pulse_MaxValue;
            public double? Pulse_MinValue;
            public double? Respiration_MaxValue;
            public double? Respiration_MinValue;
            public double? Temperature_MaxValue;
            public double? Temperature_MinValue;
            public double? SPO2_MaxValue;
            public double? SPO2_MinValue;
            public int? Height_MaxValue;
            public int? Height_MinValue;
            public double? Weight_MaxValue;
            public double? Weight_MinValue;
            public string Systolic_MaxWarning = "";
            public string Systolic_MinWarning = "";
            public string Diastolic_MaxWarning = "";
            public string Diastolic_MinWarning = "";
            public string Pulse_MaxWarning = "";
            public string Pulse_MinWarning = "";
            public string Respiration_MaxWarning = "";
            public string Respiration_MinWarning = "";
            public string Temperature_MaxWarning = "";
            public string Temperature_MinWarning = "";
            public string SPO2_MaxWarning = "";
            public string SPO2_MinWarning = "";
            public string Height_MaxWarning = "";
            public string Height_MinWarning = "";
            public string Weight_MaxWarning = "";
            public string Weight_MinWarning = "";

            #endregion
        }

        // VitalSings için >

        public void CheckDirectPurchaseGridToComplete()
        {
            string msg = string.Empty;
            int count = 0;
            foreach (var directPurchaseGrid in DirectPurchaseGrids)
            {
                if (!directPurchaseGrid.DirectMaterialSupplyAction.CheckSupplyPurchaseStatusByDirectPurchaseGrid(directPurchaseGrid))
                {
                    msg = msg + directPurchaseGrid.Material.Name + ",";
                    count++;
                }
            }

            if (count > 0)
            {
                if (count == 1)
                    msg = msg + TTUtils.CultureService.GetText("M26411", "malzemesi");
                else
                    msg = msg + TTUtils.CultureService.GetText("M26406", "malzemeleri");

                msg = msg + " için satınalma işlemi bitmeden işlem tamamlanamaz";
                throw new TTUtils.TTException(msg);
            }
        }

        public bool IsAllowedToCancel()
        {
            foreach (SubActionProcedure sp in SubactionProcedures)
            {
                if (!sp.IsAllowedToCancel())
                    return false;
            }
            foreach (BaseTreatmentMaterial btm in TreatmentMaterials)
            {
                if (!btm.IsAllowedToCancel())
                    return false;
            }
            return true;
        }

        public bool IsPatientPaymentExists()
        {
            foreach (SubActionProcedure sp in SubactionProcedures)
            {
                if (sp.IsPatientPaymentExists())
                    return true;
            }
            foreach (BaseTreatmentMaterial btm in TreatmentMaterials)
            {
                if (btm.IsPatientPaymentExists())
                    return true;
            }
            return false;
        }
        public static bool IsAuthorizedToWriteTreatmentReport(SpecialityDefinition speciality)
        {
            String[] strings = { "1800", "1855", "2600", "2679", "4000", "600", "4300", "4200", "2700", "2781", "2796", "1062", "3050", "3000", "4200", "4300" };
            List<string> specialityList = new List<string>();
            specialityList = strings.ToList();
            if (specialityList.Find(t => t == speciality.Code) != null)
                return true;
            else
                return false;
        }

        public virtual void SetPatientNoShown()
        {
            throw new Exception("Muayeneye Gelmedi özelliği ancak geçerli bir hasta işlemi üzerinden gerçekleştirilebilir.");
        }

        public void CheckAndCancelMorgue(SKRSCikisSekli treatmentResult)
        {
            if (treatmentResult.KODU != "6") // 6 = ölüm
            {
                foreach (BaseAction action in LinkedActions)
                {
                    if (action is Morgue && !action.IsCancelled)
                    {
                        ((Morgue)action).CancelledByMasterAction = true;
                        ((ITTObject)action).Cancel();
                    }
                }
            }
        }

        #endregion Methods
    }
}