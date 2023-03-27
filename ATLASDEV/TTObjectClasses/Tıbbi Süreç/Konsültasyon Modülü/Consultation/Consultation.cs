
using System;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using TTDefinitionManagement;
using Newtonsoft.Json;

namespace TTObjectClasses
{
    public partial class Consultation : PhysicianApplication, IAllocateSpeciality, IAppointmentDef, INumaratorAppointment, IReasonOfReject, ITreatmentMaterialCollection, IWorkListEpisodeAction
    {
        public partial class GetByMasterActionNQL_Class : TTReportNqlObject
        {
        }

        #region INumaratorAppointment Members

        public AppointmentTypeEnum GetNumaratorAppointmentType()
        {
            return NumaratorAppointmentType;
        }

        public Resource GetNumaratorAppointmentMasterResource()
        {
            return NumaratorAppointmentMasterResource;
        }

        public Resource GetNumaratorAppointmentResource()
        {
            return NumaratorAppointmentResource;
        }
        #endregion

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "PHYSICIANAPPLICATION":
                    {
                        PhysicianApplication value = (PhysicianApplication)newValue;
                        #region PHYSICIANAPPLICATION_SetParentScript
                        Episode = value.Episode;
                        FromResource = value.MasterResource;
                        RequesterResource = value.MasterResource;
                        if (Common.CurrentDoctor != null)
                            RequesterDoctor = Common.CurrentDoctor;
                        else
                            RequesterDoctor = value.ProcedureDoctor;
                        //this.ProcedureSpeciality = value.ProcedureSpeciality;
                        MasterAction = value;
                        CurrentStateDefID = Consultation.States.RequestAcception;
                        #endregion PHYSICIANAPPLICATION_SetParentScript
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

        protected override void PreInsert()
        {
            #region PreInsert
            //Önce speciality set olmalı sonra base.PreInsert() çalışmalı. Çünkü base.PreInsert() de specialitybasedobject procedurespeciality ye göre oluşturuluyor.
            //this.SetProcedureSpeciality();
            base.PreInsert();
            AddConsultationProcedure();
            FromResource = RequesterResource;
            OlapLastUpdate = DateTime.Now;

            if (AdmissionQueueNumber.Value == null)
                AdmissionQueueNumber.GetNextValue(MasterResource.ObjectID.ToString() + DateTime.Today.ToShortDateString());

            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();

            if (HasActiveQueueItem() == false)
            {
                IList<ExaminationQueueDefinition> myQueue = ExaminationQueueDefinition.GetQueueByResource(ObjectContext, MasterResource.ObjectID.ToString());
                if (myQueue.Count > 0)
                    CreateExaminationQueueItem(SubEpisode.PatientAdmission, myQueue[0], false);
            }

            if (ProcedureDoctor != null)
            {
                #region Konsultasyon İstek SMS
                if (ProcedureDoctor.PhoneNumber != null)
                {
                    try
                    {
                        if (ProcedureDoctor.PhoneNumber != null)
                        {
                            UserMessage userMessage = new UserMessage();
                            string hospitalShortName = SystemParameter.GetParameterValue("HOSPITALSHORTNAME", "");
                            string messageText = "";
                            if (this.SubEpisode.PatientStatus == SubEpisodeStatusEnum.Outpatient)
                            {
                                messageText += ProcedureDoctor != null ? ("Sayın " + ProcedureDoctor.Name + " , ") : "";
                                messageText += RequestDate != null ? (RequestDate.Value.ToString("dd MMMM yyyy") + " tarihi " + RequestDate.Value.ToString("HH:mm") + " saatinde ") : "";
                                messageText += RequesterResource != null ? (RequesterResource.Name + " ") : "";
                                messageText += RequesterDoctor != null ? (RequesterDoctor.Name + " tarafından ") : "";
                                messageText += Episode.Patient != null ? ("'" + Episode.Patient.FullName + "' adlı hasta için ") : "";
                                messageText += SubEpisode != null ? "(işlem no: " + SubEpisode.ProtocolNo + ") " : "";
                                messageText += "konsültasyon talebi vardır, tarafınızdan değerlendirilmesi ve sistem üzerinden sonuçlandırılması rica olunur. " + (RequesterResource != null ? (RequesterResource.Name + " ") : "") + (String.IsNullOrEmpty(hospitalShortName) ? "" : hospitalShortName);
                            }
                            else
                            {
                                messageText += ProcedureDoctor != null ? ("Sayın " + ProcedureDoctor.Name + " , ") : "";
                                messageText += RequestDate != null ? (RequestDate.Value.ToString("dd MMMM yyyy") + " tarihi " + RequestDate.Value.ToString("HH:mm") + " saatinde ") : "";
                                messageText += RequesterDoctor != null ? (RequesterDoctor.Name + " tarafından ") : "";
                                messageText += RequesterResource != null ? (RequesterResource.Name + " servisinde yatan ") : "";
                                messageText += Episode.Patient != null ? ("'" + Episode.Patient.FullName + "' adlı hasta için ") : "";
                                messageText += SubEpisode != null ? "(işlem no: " + SubEpisode.ProtocolNo + ") " : "";
                                messageText += "konsültasyon talebi vardır, tarafınızdan değerlendirilmesi ve sistem üzerinden sonuçlandırılması rica olunur. " + (RequesterResource != null ? (RequesterResource.Name + " ") : "") + (String.IsNullOrEmpty(hospitalShortName) ? "" : hospitalShortName);
                            }
                            if (!string.IsNullOrEmpty(messageText))
                            {
                                List<ResUser> users = new List<ResUser> { ProcedureDoctor };
                                userMessage.SendSMSPerson(users, messageText, SMSTypeEnum.ConsultationRequestSMS);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                #endregion

                #region Konsultasyon İstek Notification
                try
                {

                    //TTUtils.AtlasNotificationContainer atlasNotification = new TTUtils.AtlasNotificationContainer();
                    //atlasNotification.users = new List<string>();
                    //atlasNotification.users.Add(this.ProcedureDoctor.ObjectID.ToString());
                    //atlasNotification.notificationType = TTUtils.AtlasNotificationType.Info;
                    //atlasNotification.contentType = TTUtils.AtlasContentType.Notification;
                    //atlasNotification.actionData = ProcedureDoctor.ObjectID;


                    //string messageText = "";
                    //messageText += this.ProcedureDoctor != null ? ("Sayın " + this.ProcedureDoctor.Name + " , ") : "";
                    //messageText += this.RequestDate != null ? (this.RequestDate.Value.ToString("dd MMMM yyyy") + " tarihi " + this.RequestDate.Value.ToString("HH:mm") + " saatinde ") : "";
                    //messageText += this.RequesterResource != null ? (this.RequesterResource.Name + " ") : "";
                    //messageText += this.RequesterDoctor != null ? (this.RequesterDoctor.Name + " tarafından ") : "";
                    //messageText += this.Episode.Patient != null ? ("'" + this.Episode.Patient.FullName + "' hastası için ") : "";
                    //messageText += "tarafınıza konsultasyon istemi yapılmıştır.";

                    //atlasNotification.content = messageText;
                    //string notificationStr = JsonConvert.SerializeObject(atlasNotification);

                    //TTUtils.AtlasSignalRHubFactory.Instance.HandleUserNotification(notificationStr);
                    NotifyDoctors();

                }
                catch (Exception e)
                {
                    throw e;
                }
                #endregion

            }

            #endregion PostInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate
            base.PreUpdate();
            OlapLastUpdate = DateTime.Now;
            if (ProcessEndDate.HasValue == false && ConsultationResultAndOffers != null)
                ProcessEndDate = Common.RecTime();

            if (SubEpisode.StarterEpisodeAction != null && SubEpisode.StarterEpisodeAction is InPatientTreatmentClinicApplication)
            {
                InPatientTreatmentClinicApplication tca = (InPatientTreatmentClinicApplication)SubEpisode.StarterEpisodeAction;
                if (tca.ClinicDischargeDate != null && ProcessEndDate > tca.ClinicDischargeDate)
                    throw new Exception("Konsültasyon bitiş tarihi, taburcu tarihinden sonra olamaz. Taburcu Tarihi : " + tca.ClinicDischargeDate.ToString());
            }
            if (((TransDef != null) && (TransDef.ToStateDefID == Consultation.States.Completed)))
            {
                if (ConsultationResultAndOffers == null)
                    throw new Exception(TTUtils.CultureService.GetText("M17784", "Konsültasyon Sonucunu Girmeden İşlemi Tamamlayamazsınız."));

                if (ProcedureDoctor == null)
                    throw new Exception(TTUtils.CultureService.GetText("M17798", "Konsültasyonu Yapan Doktoru Seçmeden İşlemi Tamamlayamazsınız."));

                foreach (ConsultationProcedure consultationProcedure in ConsultationProcedures.Where(x => x.CurrentStateDef.Status != StateStatusEnum.Cancelled))
                {
                    consultationProcedure.SetPerformedDate();
                }

                foreach (AnesthesiaConsultationProcedure anesthesiaConsultationProcedure in AnesthesiaConsultationProcedures.Where(x => x.CurrentStateDef.Status != StateStatusEnum.Cancelled))
                {
                    anesthesiaConsultationProcedure.SetPerformedDate();
                }
            }
            if ((CurrentStateDefID == Consultation.States.RequestAcception || CurrentStateDefID == Consultation.States.InsertedIntoQueue || CurrentStateDefID == Consultation.States.Appointment) && ConsultationResultAndOffers != null)
                CurrentStateDefID = Consultation.States.Consultation;
            #endregion PreUpdate
        }

        protected override void PostUpdate()
        {
            #region PostUpdate

            base.PostUpdate();

            if (PatientAdmission != null && PatientAdmission.PAStatus == PAStatusEnum.Sirada)
                PatientAdmission.PAStatus = PAStatusEnum.Muayenede;
            if (IsOldAction != true)
            {
                if (CurrentStateDefID == ConsultationProcedure.States.Completed)
                {
                    if (SubEpisode != null && SendToENabiz())
                        new SendToENabiz(ObjectContext, SubEpisode, SubEpisode.ObjectID, SubEpisode.ObjectDef.Name, "252", Common.RecTime());
                }

                if (this.ProcessEndDate.HasValue && this.ConsultationResultAndOffers != null)
                    this.CompleteMySubActionProcedures();
                NotifyDoctors();
            }

            #endregion PostUpdate
        }

        private void CompleteConsultationProcedures()
        {
            if (this.ProcessEndDate.HasValue && this.ConsultationResultAndOffers != null)
            {
                foreach (ConsultationProcedure consultationProcedure in this.ConsultationProcedures)
                {
                    if (consultationProcedure.CurrentStateDefID == SubActionProcedure.States.New)
                        consultationProcedure.CurrentStateDefID = SubActionProcedure.States.Completed;
                }
                foreach (AnesthesiaConsultationProcedure anesthesiaConsultationProcedure in this.AnesthesiaConsultationProcedures)
                {
                    if (anesthesiaConsultationProcedure.CurrentStateDefID == SubActionProcedure.States.New)
                        anesthesiaConsultationProcedure.CurrentStateDefID = SubActionProcedure.States.Completed;
                }
            }
        }

        private void NotifyDoctors()
        {
            if (IsOldAction != true)
            {
                List<string> doctorlist = new List<string>();
                string messageText = "";
                if (CurrentStateDefID == Consultation.States.RequestAcception || HasMemberChanged("ProcedureDoctor"))
                {
                    if (ProcedureDoctor != null)
                    {
                        doctorlist.Add(ProcedureDoctor.ObjectID.ToString());

                        messageText += ProcedureDoctor != null ? "Sayın " + ProcedureDoctor.Name + ", " : ("Sayın Doktor, ");
                        messageText += RequestDate != null ? (RequestDate.Value.ToString("dd MMMM yyyy") + " tarihi " + RequestDate.Value.ToString("HH:mm") + " saatinde ") : "";
                        messageText += Episode.Patient != null ? ("'" + Episode.Patient.FullName + "' hastası için ") : "";
                        messageText += RequesterResource != null ? (RequesterResource.Name + " ") : "";
                        messageText += RequesterDoctor != null ? (RequesterDoctor.Name + " tarafından ") : "";
                        messageText += "tarafınıza konsültasyon istemi yapılmıştır.";
                    }
                }
                else if (TransDef != null && TransDef.ToStateDefID == Consultation.States.Completed)
                {
                    if (RequesterDoctor != null)
                    {
                        doctorlist.Add(RequesterDoctor.ObjectID.ToString());

                        messageText += RequesterDoctor != null ? "Sayın " + RequesterDoctor.Name + ", " : ("Sayın Doktor, ");
                        messageText += RequestDate != null ? (RequestDate.Value.ToString("dd MMMM yyyy") + " tarihi " + RequestDate.Value.ToString("HH:mm") + " saatinde ") : "";
                        messageText += Episode.Patient != null ? ("'" + Episode.Patient.FullName + "' hastası için ") : "";
                        messageText += MasterResource != null ? ("'" + MasterResource.Name + "' biriminden ") : "";
                        messageText += "istediğiniz konsültasyon sonuçlanmıştır.";
                    }
                }

                if (doctorlist.Count > 0)
                {
                    TTUtils.AtlasNotificationContainer atlasNotification = new TTUtils.AtlasNotificationContainer();
                    atlasNotification.users = doctorlist;
                    atlasNotification.notificationType = TTUtils.AtlasNotificationType.Info;
                    atlasNotification.contentType = TTUtils.AtlasContentType.Action;

                    atlasNotification.content = messageText;
                    var actionData = new { objectDefName = ObjectDef.Name, objectID = ObjectID, episodeObjectID = Episode.ObjectID, patientObjectID = Episode.Patient.ObjectID, formDefId = CurrentStateDef.FormDefID, inputparam = "" };
                    //ActionData actionData = new ActionData(this.ObjectDef.Name, this.ObjectID, this.CurrentStateDef.FormDefID, "");
                    atlasNotification.actionData = actionData;
                    string notificationStr = JsonConvert.SerializeObject(atlasNotification);
                    try
                    {
                        TTUtils.AtlasSignalRHubFactory.Instance.HandleUserNotification(notificationStr);

                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        //public class ActionData 
        //{
        //    public object objectDefName { get; set; }
        //    public object objectID { get; set; }
        //    public object formDefId { get; set; }
        //    public object inputparam{ get; set; }
        //    public ActionData(object _objectDefName, object _objectID, object _formDefId, object _inputparam)
        //    {
        //        objectDefName = _objectDefName;
        //        objectID = _objectID;
        //        formDefId = _formDefId;
        //        inputparam = _inputparam;
        //    }
        //}

        protected void PreTransition_RequestAcception2Consultation()
        {
            // From State : RequestAcception   To State : Consultation
            #region PreTransition_RequestAcception2Consultation

            if (Episode.PatientStatus != PatientStatusEnum.Inpatient && RequestDate < DateTime.Now.AddDays(-10))
                throw new Exception(TTUtils.CultureService.GetText("M26332", "Konsültasyon İstek Tarihi 10 Günü Geçmiş !"));

            if (OlapDate == null)
                OlapDate = DateTime.Now;

            //this.AddConsultationProcedure();
            #endregion PreTransition_RequestAcception2Consultation
        }

        protected void PreTransition_RequestAcception2Completed()
        {
            // From State : RequestAcception   To State : Consultation
            #region PreTransition_RequestAcception2Completed

            if (IsOldAction != true)
            {
                if (Episode.PatientStatus != PatientStatusEnum.Inpatient && RequestDate < DateTime.Now.AddDays(-10))
                    throw new Exception(TTUtils.CultureService.GetText("M26332", "Konsültasyon İstek Tarihi 10 Günü Geçmiş !"));

                if (OlapDate == null)
                    OlapDate = DateTime.Now;

                //this.AddConsultationProcedure();
            }
            #endregion PreTransition_RequestAcception2Completed
        }

        protected void PostTransition_RequestAcception2Consultation()
        {
            // From State : RequestAcception   To State : Consultation
            #region PostTransition_RequestAcception2Consultation
            AddConsultationProcedure();
            CompleteMyExaminationQueueItems();
            if (Common.CurrentDoctor != null && ProcedureDoctor == null)
            {
                ProcedureDoctor = Common.CurrentDoctor;
            }

            if (SubEpisode != null && SubEpisode.PatientAdmission != null)
                SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.Muayenede;

            #endregion PostTransition_RequestAcception2Consultation
        }

        protected void PostTransition_RequestAcception2Completed()
        {
            // From State : RequestAcception   To State : Consultation
            #region PostTransition_RequestAcception2Completed
            AddConsultationProcedure();
            CompleteMyExaminationQueueItems();
            if (Common.CurrentDoctor != null && ProcedureDoctor == null)
            {
                ProcedureDoctor = Common.CurrentDoctor;
            }
            if (Episode.EmergencyPatientStatusInfo != null)
                Episode.EmergencyPatientStatusInfo.PatientStatus = EmergencyPatientStatusInfoEnum.ConsultationCompleted;

            if (SubEpisode != null && SubEpisode.PatientAdmission != null)
                SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.MuayenesiSonlandı;

            #endregion PostTransition_RequestAcception2Completed
        }

        protected void PostTransition_RequestAcception2PatientNoShown()
        {
            // From State : RequestAcception   To State : PatientNoShown
            #region PostTransition_RequestAcception2PatientNoShown

            CancelMyExaminationQueueItems();
            //if (this.SubEpisode.PatientAdmission.AdmissionStatus != AdmissionStatusEnum.SaglikKurulu)
            //{
            //    if (this.SubEpisode != null && this.SubEpisode.PatientAdmission != null)
            //        this.SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.MuayeneyeGelmedi;
            //}
            #endregion PostTransition_RequestAcception2PatientNoShown
        }

        protected void PostTransition_InsertedIntoQueue2PatientNoShown()
        {
            // From State : InsertedIntoQueue   To State : PatientNoShown
            #region PostTransition_InsertedIntoQueue2PatientNoShown
            CancelMyExaminationQueueItems();
            //if (this.SubEpisode.PatientAdmission.AdmissionStatus != AdmissionStatusEnum.SaglikKurulu)
            //{
            //    if (this.SubEpisode != null && this.SubEpisode.PatientAdmission != null)
            //        this.SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.MuayeneyeGelmedi;
            //}
            #endregion PostTransition_InsertedIntoQueue2PatientNoShown
        }

        protected void PreTransition_InsertedIntoQueue2Consultation()
        {
            // From State : InsertedIntoQueue   To State : Consultation
            #region PreTransition_InsertedIntoQueue2Consultation

            if (OlapDate == null)
                OlapDate = DateTime.Now;
            //this.AddConsultationProcedure();

            #endregion PreTransition_InsertedIntoQueue2Consultation
        }

        protected void PostTransition_InsertedIntoQueue2Consultation()
        {
            // From State : InsertedIntoQueue   To State : Consultation
            #region PostTransition_InsertedIntoQueue2Consultation
            AddConsultationProcedure();
            CompleteMyExaminationQueueItems();


            if (SubEpisode != null && SubEpisode.PatientAdmission != null)
                SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.Muayenede;

            #endregion PostTransition_InsertedIntoQueue2Consultation
        }

        protected void PreTransition_Consultation2Completed()
        {
            // From State : Consultation   To State : Completed
            #region PreTransition_Consultation2Completed
            //this.ProcessDate = Common.RecTime();
            #endregion PreTransition_Consultation2Completed
        }

        protected void PostTransition_Consultation2Completed()
        {
            // From State : Consultation   To State : Completed
            #region PostTransition_Consultation2Completed
            if (Episode.EmergencyPatientStatusInfo != null)
                Episode.EmergencyPatientStatusInfo.PatientStatus = EmergencyPatientStatusInfoEnum.ConsultationCompleted;

            if (SubEpisode != null && SubEpisode.PatientAdmission != null)
                SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.MuayenesiSonlandı;


            #endregion PostTransition_Consultation2Completed
        }

        protected void PostTransition_Appointment2PatientNoShown()
        {
            // From State : Appointment   To State : PatientNoShown
            #region PostTransition_Appointment2PatientNoShown

            CancelMyExaminationQueueItems();
            //if (this.SubEpisode.PatientAdmission.AdmissionStatus != AdmissionStatusEnum.SaglikKurulu)
            //{
            //    if (this.SubEpisode != null && this.SubEpisode.PatientAdmission != null)
            //        this.SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.MuayeneyeGelmedi;
            //}
            #endregion PostTransition_Appointment2PatientNoShown
        }

        protected void PreTransition_Appointment2Consultation()
        {
            // From State : Appointment   To State : Consultation
            #region PreTransition_Appointment2Consultation

            if (OlapDate == null)
                OlapDate = DateTime.Now;
            //this.AddConsultationProcedure();
            #endregion PreTransition_Appointment2Consultation
        }

        protected void PostTransition_Appointment2Consultation()
        {
            // From State : Appointment   To State : Consultation
            #region PostTransition_Appointment2Consultation
            AddConsultationProcedure();
            CompleteMyExaminationQueueItems();


            if (SubEpisode != null && SubEpisode.PatientAdmission != null)
                SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.Muayenede;

            #endregion PostTransition_Appointment2Consultation
        }
        protected void PostTransition_ToCancelled()
        {
            // From State : Appointment   To State : Consultation
            #region PostTransition_ToCancelled
            Cancel();
            CancelMyExaminationQueueItems();

            #endregion PostTransition_ToCancelled
        }

        #region Methods

        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.Consultation);
                if (appDefList.Count > 0)
                {
                    appDef = (AppointmentDefinition)appDefList[0];
                    foreach (AppointmentCarrier appCarrier in appDef.AppointmentCarriers)
                    {
                        _appointmentList.Add(appCarrier);
                    }
                }

                if (_appointmentList.Count == 0)
                {
                    AppointmentCarrier carrier = new AppointmentCarrier(context);
                    carrier.MasterResource = "ResSection";
                    carrier.SubResource = "ResUser";
                    carrier.RelationParentName = "";
                    carrier.UserTypes.Add(UserTypeEnum.Doctor);
                    carrier.UserTypes.Add(UserTypeEnum.Dentist);
                    carrier.UserTypes.Add(UserTypeEnum.Dietician);
                    carrier.UserTypes.Add(UserTypeEnum.Psychologist);
                    carrier.AppointmentDefinition = appDef;
                    _appointmentList.Add(carrier);
                }
                //her app carrier listenin başında çağırılmalı.
                ClearAppointmentCarrierDynamicFields(_appointmentList);
                foreach (AppointmentCarrier appointmentCarrier in _appointmentList)
                {
                    if (MasterResource != null)
                    {
                        appointmentCarrier.MasterResourceFilter = " OBJECTID = '" + MasterResource.ObjectID.ToString() + "'";
                    }
                    else
                    {
                        appointmentCarrier.MasterResourceFilter = "";
                    }
                    break;
                }
                return _appointmentList;
            }
        }

        #region IAppointmentDef Members
        public List<AppointmentCarrier> GetAppointmentCarrierList()
        {
            return AppointmentCarrierList;
        }
        #endregion

        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew == true)
            {
                CurrentStateDefID = Consultation.States.RequestAcception;
                if (RequestDate == null)
                    RequestDate = Common.RecTime();
                if (ActionDate == null)
                    ActionDate = Common.RecTime();
            }
        }


        public Consultation(TTObjectContext objectContext, EpisodeAction episodeAction) : this(objectContext)
        {

            ActionDate = Common.RecTime();
            if (RequestDate == null)
                RequestDate = Common.RecTime();
            // this.MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            //Episodeun AfterSetinde  this.InPatientPhysicianApplication==null kontrolü olduğu için SetMandatoryEpisodeActionProperties()kullanılmadı.
            //this.SetMandatoryEpisodeActionProperties((EpisodeAction)inPatientPhysicianApplication,inPatientPhysicianApplication.MasterResource,inPatientPhysicianApplication.MasterResource,false);
            CurrentStateDefID = Consultation.States.RequestAcception;
            //this.InPatientPhysicianApplication=inPatientPhysicianApplication;
            Episode = episodeAction.Episode;
            ProcedureSpeciality = episodeAction.ProcedureSpeciality;
            MasterAction = episodeAction;
        }
        public Consultation(TTObjectContext objectContext, PatientAdmission patientAdmission) : this(objectContext)
        {

            ActionDate = Common.RecTime();
            if (RequestDate == null)
                RequestDate = Common.RecTime();
            // this.MasterResource = episodeAction.MasterResource;
            FromResource = patientAdmission.Policlinic;
            //Episodeun AfterSetinde  this.InPatientPhysicianApplication==null kontrolü olduğu için SetMandatoryEpisodeActionProperties()kullanılmadı.
            //this.SetMandatoryEpisodeActionProperties((EpisodeAction)inPatientPhysicianApplication,inPatientPhysicianApplication.MasterResource,inPatientPhysicianApplication.MasterResource,false);
            CurrentStateDefID = Consultation.States.RequestAcception;
            //this.InPatientPhysicianApplication=inPatientPhysicianApplication;
            Episode = patientAdmission.Episode;
            // this.ProcedureSpeciality = patientAdmission.Speciality;//todo bg
            MasterAction = patientAdmission;
        }

        public Consultation(TTObjectContext objectContext, SubactionProcedureFlowable subactionProcedureFlowable) : this(objectContext)
        {

            ActionDate = Common.RecTime();
            if (RequestDate == null)
                RequestDate = Common.RecTime();
            //this.MasterResource = subactionProcedureFlowable.MasterResource;
            FromResource = subactionProcedureFlowable.MasterResource;
            //Episodeun AfterSetinde  this.InPatientPhysicianApplication==null kontrolü olduğu için SetMandatoryEpisodeActionProperties()kullanılmadı.
            //this.SetMandatoryEpisodeActionProperties((EpisodeAction)inPatientPhysicianApplication,inPatientPhysicianApplication.MasterResource,inPatientPhysicianApplication.MasterResource,false);
            CurrentStateDefID = Consultation.States.RequestAcception;
            //this.InPatientPhysicianApplication=inPatientPhysicianApplication;
            Episode = subactionProcedureFlowable.Episode;
            ProcedureSpeciality = subactionProcedureFlowable.ProcedureSpeciality;
            MasterAction = subactionProcedureFlowable.EpisodeAction;
        }

        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.Consultation;
            }
        }

        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList = base.OldActionPropertyList();
            if (propertyList == null)
                propertyList = new List<EpisodeAction.OldActionPropertyObject>();


            //-------------------------------------
            // propertyList.Add(new OldActionPropertyObject("İstek Tarihi",Common.ReturnObjectAsString(RequestDate)));
            // propertyList.Add(new OldActionPropertyObject("Acil",Common.ReturnObjectAsString(Emergency)));
            //            propertyList.Add(new OldActionPropertyObject("Yatağında",Common.ReturnObjectAsString(InPatientBed)));
            //            if(ConsultedSubject != null)
            //                propertyList.Add(new OldActionPropertyObject("Danışılan Konu",Common.ReturnObjectAsString(ConsultedSubject.ConsultedSubject)));
            if (MasterResource != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M16657", "İstek Yapan Birim"), Common.ReturnObjectAsString(RequesterResource.Name)));
            if (ProcedureDoctor != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M26144", "İsteği Yapan Doktor"), Common.ReturnObjectAsString(RequesterDoctor.Name)));
            //            propertyList.Add(new OldActionPropertyObject("İstek Açıklaması",Common.ReturnObjectAsString(RequestDescription)));
            //---------------------------------------
            return propertyList;
        }

        public override bool SetMyProcedureDoctorToMySubactionProcedure()
        {
            return true;
        }

        public void AddConsultationProcedure()
        {
            if (IsOldAction == true)
                return;

            foreach (ResourceSpecialityGrid resourceSpecialityGrid in MasterResource.ResourceSpecialities)
            {
                //if (resourceSpecialityGrid.Speciality.Code == "5100" || resourceSpecialityGrid.Speciality.Code == "5200" || resourceSpecialityGrid.Speciality.Code == "5300" || resourceSpecialityGrid.Speciality.Code == "5400" || resourceSpecialityGrid.Speciality.Code == "5500" || resourceSpecialityGrid.Speciality.Code == "5600" || resourceSpecialityGrid.Speciality.Code == "5700")
                //{
                //    AddDentalConsultationProcedure();
                //    break;
                //}
                //else 
                if (resourceSpecialityGrid.Speciality.Code == "3100")
                {
                    AddAnesthesiaConsultationProcedure();
                    return;
                }
            }

            AddNormalConsultationProcedure();
        }
        public void AddNormalConsultationProcedure()
        {
            // Konsültasyon ücreti oluşması için konsültasyon prosedürü atar
            bool konsultasyonEkle = true;
            Guid konsultasyonGuid = ProcedureDefinition.ConsultationProcedureObjectId;
            Guid yatanKonsultasyonGuid = ProcedureDefinition.InpatientConsultationProcedureObjectId;
            Guid acilKonsultasyonGuid = ProcedureDefinition.EmergencyConsultationProcedureObjectId;
            Guid disXXXXXXdenKonsultasyonGuid = ProcedureDefinition.ExternalConsultationProcedureObjectId;
            ConsultationProcedure consultationProcedure = null;

            foreach (ConsultationProcedure consProcedure in ConsultationProcedures)
            {
                if (consProcedure.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    if (consProcedure.ProcedureObject.ObjectID.Equals(konsultasyonGuid) ||
                        consProcedure.ProcedureObject.ObjectID.Equals(yatanKonsultasyonGuid) ||
                        consProcedure.ProcedureObject.ObjectID.Equals(acilKonsultasyonGuid) ||
                        consProcedure.ProcedureObject.ObjectID.Equals(disXXXXXXdenKonsultasyonGuid))
                    {
                        konsultasyonEkle = false;
                        break;
                    }
                }
            }

            //Acilden başlatılmış ise ConsultationProcedure ın oluşmaması için
            //            if(this.ConsultationRequest.EmergencyIntervention != null)
            //                konsultasyonEkle = false;

            if (konsultasyonEkle)
            {
                if (SubEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.Acil)
                    consultationProcedure = new ConsultationProcedure(this, acilKonsultasyonGuid.ToString());
                else if (SubEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.DisaridanGelenKonsultasyon)
                    consultationProcedure = new ConsultationProcedure(this, disXXXXXXdenKonsultasyonGuid.ToString());
                else if (SubEpisode.PatientStatus == SubEpisodeStatusEnum.Inpatient)
                    consultationProcedure = new ConsultationProcedure(this, yatanKonsultasyonGuid.ToString());
                else
                    consultationProcedure = new ConsultationProcedure(this, konsultasyonGuid.ToString());

                // Konsültasyon hizmetinin ücretlenme tarihi SubEpisode.OpeningDate olmamalı, istendiği tarih olmalı şeklinde istendiği için kapatıldı )
                //if (SubEpisode.OpeningDate != null)
                //    consultationProcedure.PricingDate = SubEpisode.OpeningDate;
            }
        }

        /*private void AddDentalConsultationProcedure()
        {
            // Normal muayene ücreti oluşması için normal muayene procedürü atar
            bool konsultasyonEkle = true;
            Guid konsultasyonGuid = ProcedureDefinition.DentalConsultationProcedureObjectId;
            RelationshipDefinition relationshipDefinition = null;

            foreach (SubActionProcedure sp in this.SubactionProcedures)
            {
                if (sp.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    if (sp.ProcedureObject.ObjectID == konsultasyonGuid)
                    {
                        konsultasyonEkle = false;
                        break;
                    }
                }
            }

            if (konsultasyonEkle)
            {
                DentalConsultationProcedure dentalConsultationProcedure = null;
                dentalConsultationProcedure = new DentalConsultationProcedure(this, konsultasyonGuid.ToString());
                dentalConsultationProcedure.AccountOperation(AccountOperationTimeEnum.PREPOST);
            }
        }*/

        public void AddAnesthesiaConsultationProcedure()
        {
            // Konsültasyon hizmeti oluşması için
            bool hizmetEkle = true;
            Guid procedureGuid = ProcedureDefinition.ConsultationProcedureObjectId;
            AnesthesiaConsultationProcedure _anesthesiaConsultationProcedure = null;

            foreach (AnesthesiaConsultationProcedure anesthesiaConsultationProcedure in AnesthesiaConsultationProcedures)
            {
                if (anesthesiaConsultationProcedure.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    if (anesthesiaConsultationProcedure.ProcedureObject.ObjectID.Equals(procedureGuid))
                    {
                        hizmetEkle = false;
                        break;
                    }
                }
            }

            if (hizmetEkle)
                _anesthesiaConsultationProcedure = new AnesthesiaConsultationProcedure(this, procedureGuid.ToString());
        }

        public AppointmentTypeEnum NumaratorAppointmentType
        {
            get { return AppointmentTypeEnum.Consultation; }
        }

        public Resource NumaratorAppointmentMasterResource
        {
            get { return MasterResource; }// İşlemin yapıuldığı Poliklinik aynı zamanada randevu verilecek üst kaynakdır
        }

        public Resource NumaratorAppointmentResource
        {
            get
            {
                if (ProcedureDoctor == null)
                {
                    TTObjectContext roContext = new TTObjectContext(true);
                    BindingList<TTObjectClasses.Appointment.GetMinNumaratorAppointmentResource_Class> minAppResource = Appointment.GetMinNumaratorAppointmentResource(roContext, MasterResource.ObjectID, Common.RecTime().Date, Common.RecTime().Date.AddDays(1));
                    if (minAppResource.Count > 0)
                    {
                        foreach (TTObjectClasses.Appointment.GetMinNumaratorAppointmentResource_Class minNumApp in minAppResource)
                        {
                            Resource resource = (Resource)roContext.GetObject(minNumApp.Resource.Value, typeof(Resource));
                            if (resource is ResUser)
                            {
                                ProcedureDoctor = (ResUser)resource;
                                break;
                            }
                        }
                    }

                    if (ProcedureDoctor == null)
                    {
                        IList<ResUser> userList = (IList<ResUser>)ResUser.GetByUserResourceAndUserType(roContext, UserTypeEnum.Doctor, MasterResource.ObjectID.ToString());
                        foreach (ResUser resUser in userList)
                        {
                            ProcedureDoctor = (ResUser)resUser;
                            break;
                        }
                    }
                }
                return ProcedureDoctor;
            }
            // işlemi yapan doktor aynı zamanda randevu verilecek kişidir
        }



        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Consultation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Consultation.States.RequestAcception && toState == Consultation.States.Consultation)
                PreTransition_RequestAcception2Consultation();
            if (fromState == Consultation.States.RequestAcception && toState == Consultation.States.Completed)
                PreTransition_RequestAcception2Completed();
            else if (fromState == Consultation.States.InsertedIntoQueue && toState == Consultation.States.Consultation)
                PreTransition_InsertedIntoQueue2Consultation();
            else if (fromState == Consultation.States.Consultation && toState == Consultation.States.Completed)
                PreTransition_Consultation2Completed();
            else if (fromState == Consultation.States.Appointment && toState == Consultation.States.Consultation)
                PreTransition_Appointment2Consultation();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Consultation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Consultation.States.RequestAcception && toState == Consultation.States.Consultation)
                PostTransition_RequestAcception2Consultation();
            if (fromState == Consultation.States.RequestAcception && toState == Consultation.States.Completed)
                PostTransition_RequestAcception2Completed();
            else if (fromState == Consultation.States.RequestAcception && toState == Consultation.States.PatientNoShown)
                PostTransition_RequestAcception2PatientNoShown();
            else if (fromState == Consultation.States.InsertedIntoQueue && toState == Consultation.States.PatientNoShown)
                PostTransition_InsertedIntoQueue2PatientNoShown();
            else if (fromState == Consultation.States.InsertedIntoQueue && toState == Consultation.States.Consultation)
                PostTransition_InsertedIntoQueue2Consultation();
            else if (fromState == Consultation.States.Consultation && toState == Consultation.States.Completed)
                PostTransition_Consultation2Completed();
            else if (fromState == Consultation.States.Appointment && toState == Consultation.States.PatientNoShown)
                PostTransition_Appointment2PatientNoShown();
            else if (fromState == Consultation.States.Appointment && toState == Consultation.States.Consultation)
                PostTransition_Appointment2Consultation();
            else if (toState == Consultation.States.Cancelled)
                PostTransition_ToCancelled();
        }

    }
}