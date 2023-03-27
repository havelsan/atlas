
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
    /// Oral Diagnoz ve Radyoloji İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
    public partial class DentalExamination : BaseDentalEpisodeAction, IAppointmentDef, IAllocateSpeciality, IOAExamination, IWorkListEpisodeAction, INumaratorAppointment
    {
        public partial class OLAP_GetDentalExamination_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetCancelledDentalExamination_Class : TTReportNqlObject
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
                case "TRIAJCODE":
                    {
                        TriajCode? value = (TriajCode?)(int?)newValue;
                        #region TRIAJCODE_SetScript
                        if (value == null)
                            DescriptionForWorkList = "";
                        else
                            DescriptionForWorkList = TTUtils.CultureService.GetText("M27119", "Triaj Kodu:") + Common.GetDisplayTextOfDataTypeEnum(value);
                        #endregion TRIAJCODE_SetScript
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

            base.PreInsert();
            AddConsultationOrExaminationProcedure();
            if (MasterAction is InPatientTreatmentClinicApplication)
                SubEpisode.ArrangeMeOrCreateNewSubEpisode(this, false, true);

            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert

            base.PostInsert();

            DoExaminationAccTrxMedulaDontSend();

            //this.ObjectContext.Update();
            //this.Update();
            if (CurrentStateDefID != DentalExamination.States.Examination)
                CurrentStateDefID = DentalExamination.States.Examination;

            #endregion PostInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate
            base.PreUpdate();
            if (ProcessDate.HasValue == true && ProcessEndDate.HasValue == false)
                ProcessEndDate = Common.RecTime();

            if (TransDef == null || (TransDef != null &&
                (TransDef.ToStateDefID == DentalExamination.States.Completed
                || TransDef.ToStateDefID == DentalExamination.States.ExaminationCompleted
                || TransDef.ToStateDefID == DentalExamination.States.ProcedureRequested
                || TransDef.ToStateDefID == TTObjectClasses.DentalConsultation.States.Completed)))
            {
                if (TransDef != null)
                {
                    foreach (DentalExaminationProcedure dentalExaminationProcedure in DentalExaminationProcedures.Where(x => x.CurrentStateDef.Status != StateStatusEnum.Cancelled))
                    {
                        dentalExaminationProcedure.SetPerformedDate();
                    }

                    foreach (DentalConsultationProcedure dentalConsultationProcedure in DentalConsultationProcedures.Where(x => x.CurrentStateDef.Status != StateStatusEnum.Cancelled))
                    {
                        dentalConsultationProcedure.SetPerformedDate();
                    }
                }

                foreach (DentalConsultationRequest dentalConsRequest in DentalConsultationRequest)
                {
                    if (dentalConsRequest.CurrentStateDefID == TTObjectClasses.DentalConsultationRequest.States.Request)
                    {
                        dentalConsRequest.CurrentStateDefID = TTObjectClasses.DentalConsultationRequest.States.Completed;
                    }
                }
            }
            #endregion PreUpdate
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();

            //Transition post'ta nedense çalışmıyor. O yüzden buraya taşıdım MC
            if (TransDef != null && TransDef.ToStateDefID != null)
            {
                if (TransDef.ToStateDefID == DentalExamination.States.PatientNoShown)
                {
                    //this.Cancel();
                    //this.CancelMyExaminationQueueItems();
                    SubEpisode.CancelSubEpisodeProtocols();
                }
            }
            else
            {
                if (CurrentStateDefID == DentalExamination.States.ProcedureRequested || CurrentStateDefID == DentalExamination.States.ExaminationCompleted)
                {
                    foreach (SubActionProcedure sap in SubactionProcedures)
                    {
                        if (sap is DentalExaminationProcedure || sap is DentalConsultationProcedure || sap is DentalProcedure)
                            sap.AutoComplete();
                    }
                }
            }
            if(this.DentalProcedures.Count > 0)
                new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "203", Common.RecTime());
            #endregion PostUpdate
        }

        protected override void PostDelete()
        {
            #region PostDelete





            //YAPILACAKLAR// fire edilen Protez ve Tedavi işlemleri iptal edilince ya da bu konuda kullanıcıya uyarı verilince  silinebilir.
            NoCancel();





            #endregion PostDelete
        }

        protected void PostTransition_New2Appointment()
        {
            // From State : New   To State : Appointment
            #region PostTransition_New2Appointment
            //YAPILACAKLAR//Fire Fatura işlemi yapılacak.
            #endregion PostTransition_New2Appointment
        }

        protected void UndoTransition_New2Appointment(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Appointment
            #region UndoTransition_New2Appointment
            NoBackStateBack();
            #endregion UndoTransition_New2Appointment
        }

        protected void PreTransition_New2Examination()
        {
            // From State : New   To State : Examination
            #region PreTransition_New2Examination

            if (OlapDate == null)
                OlapDate = DateTime.Now;

            AddConsultationOrExaminationProcedure();
            #endregion PreTransition_New2Examination
        }

        protected void PostTransition_New2Examination()
        {
            // From State : New   To State : Examination
            #region PostTransition_New2Examination





            //YAPILACAKLAR//Fire Fatura işlemi yapılacak.
            //YAPILACAKLAR// Doktor Ataması Yapılmalı





            #endregion PostTransition_New2Examination
        }

        protected void PostTransition_New2PatientNoShown()
        {
            // From State : New   To State : PatientNoShown
            #region PostTransition_New2PatientNoShown

            Cancel();

            if (Episode.CurrentStateDefID == Episode.States.Open)
                Episode.CloseEpisode();

            #endregion PostTransition_New2PatientNoShown
        }

        protected void UndoTransition_New2PatientNoShown(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : PatientNoShown
            #region UndoTransition_New2PatientNoShown
            NoBackStateBack();
            #endregion UndoTransition_New2PatientNoShown
        }

        protected void PreTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
            #region PreTransition_New2Cancelled
            CheckDentalLinkActionsIsCompleted();
            #endregion PreTransition_New2Cancelled
        }

        protected void PostTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
            #region PostTransition_New2Cancelled
            Cancel();
            #endregion PostTransition_New2Cancelled
        }

        protected void UndoTransition_New2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Cancelled
            #region UndoTransition_New2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_New2Cancelled
        }

        protected void PreTransition_Examination2Cancelled()
        {
            // From State : Examination   To State : Cancelled
            #region PreTransition_Examination2Cancelled
            CheckDentalLinkActionsIsCompleted();
            #endregion PreTransition_Examination2Cancelled
        }

        protected void PostTransition_Examination2Cancelled()
        {
            // From State : Examination   To State : Cancelled
            #region PostTransition_Examination2Cancelled




            Cancel();
            CancelMyExaminationQueueItems();




            #endregion PostTransition_Examination2Cancelled
        }

        protected void UndoTransition_Examination2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Examination   To State : Cancelled
            #region UndoTransition_Examination2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_Examination2Cancelled
        }

        protected void PostTransition_Examination2PatientNoShown()
        {
            // From State : Examination   To State : PatientNoShown
            #region PostTransition_Examination2PatientNoShown

            Cancel();
            CancelMyExaminationQueueItems();

            if (Episode.CurrentStateDefID == Episode.States.Open)
                Episode.CloseEpisode();

            #endregion PostTransition_Examination2PatientNoShown
        }

        protected void UndoTransition_Examination2PatientNoShown(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Examination   To State : PatientNoShown
            #region UndoTransition_Examination2PatientNoShown
            NoBackStateBack();
            #endregion UndoTransition_Examination2PatientNoShown
        }

        protected void PostTransition_Examination2Completed()
        {
            // From State : Examination   To State : Completed
            #region PostTransition_Examination2Completed

            if (!Paid())
            {
                throw new TTUtils.TTException(SystemMessage.GetMessage(141));
            }
            //FireDentalTreatmentRequestBySuggestedTreatments();
            //FireDentalProsthesisRequestBySuggestedProsthesis();
            /* kpayi --- UpdateMedulaPatientParticipationToSentServer();*/
            CompleteMyExaminationQueueItems();





            #endregion PostTransition_Examination2Completed
        }

        protected void UndoTransition_Examination2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Examination   To State : Completed
            #region UndoTransition_Examination2Completed






            double limit = CheckIfDayLimitExceeded();
            if (limit != 0)
                throw new Exception(SystemMessage.GetMessageV3(1143, new string[] { limit.ToString() }));
            //if (this.MuayeneGiris != null)
            //{
            //    if (this.MuayeneGiris.CurrentStateDefID == MuayeneGiris.States.SentServer)
            //        this.MuayeneGiris.CurrentStateDefID = MuayeneGiris.States.New;
            //}
            //Episode un açılış tarihi 10 günden önceyse vaka açık hale gelir.
            if (SubEpisode.IsOpenedInTenDays() == true)
                UndoCloseEpisode();
            //YAPILACAKLAR// fire edilen Protez ve Tedavi işlemleri iptal edilince silinebilir
            // this.NoBackStateBack();





            #endregion UndoTransition_Examination2Completed
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PreTransition_Completed2Cancelled
            CheckDentalLinkActionsIsCompleted();
            #endregion PreTransition_Completed2Cancelled
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled
            Cancel();
            #endregion PostTransition_Completed2Cancelled
        }

        protected void UndoTransition_Completed2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
            #region UndoTransition_Completed2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_Completed2Cancelled
        }

        protected void PreTransition_Appointment2Examination()
        {
            // From State : Appointment   To State : Examination
            #region PreTransition_Appointment2Examination

            if (OlapDate == null)
                OlapDate = DateTime.Now;

            AddConsultationOrExaminationProcedure();
            #endregion PreTransition_Appointment2Examination
        }

        protected void PreTransition_Appointment2Cancelled()
        {
            // From State : Appointment   To State : Cancelled
            #region PreTransition_Appointment2Cancelled
            CheckDentalLinkActionsIsCompleted();
            #endregion PreTransition_Appointment2Cancelled
        }

        protected void PostTransition_Appointment2Cancelled()
        {
            // From State : Appointment   To State : Cancelled
            #region PostTransition_Appointment2Cancelled
            Cancel();
            #endregion PostTransition_Appointment2Cancelled
        }

        protected void UndoTransition_Appointment2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Appointment   To State : Cancelled
            #region UndoTransition_Appointment2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_Appointment2Cancelled
        }

        protected void PreTransition_OrderedPatient2Examination()
        {
            // From State : OrderedPatient   To State : Examination
            #region PreTransition_OrderedPatient2Examination

            if (OlapDate == null)
                OlapDate = DateTime.Now;

            #endregion PreTransition_OrderedPatient2Examination
        }

        #region Methods

        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.DentalExamination);
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
                    carrier.MasterResource = "ResPoliclinic";
                    carrier.SubResource = "ResUser";
                    carrier.RelationParentName = "";
                    _appointmentList.Add(carrier);
                }
                ClearAppointmentCarrierDynamicFields(_appointmentList);
                foreach (AppointmentCarrier appointmentCarrier in _appointmentList)
                {
                    if (ProcedureSpeciality != null)
                    {
                        string resources = "";
                        foreach (ResourceSpecialityGrid rSpeciality in ProcedureSpeciality.ResourceSpecialities)
                        {
                            if (resources == "")
                            {
                                resources = "'" + rSpeciality.Resource.ObjectID.ToString() + "'";
                            }
                            else
                            {
                                resources = resources + ",'" + rSpeciality.Resource.ObjectID.ToString() + "'";
                            }
                        }
                        appointmentCarrier.MasterResourceFilter = " OBJECTID IN (" + resources + ")";
                        appointmentCarrier.DefaultAppointmentDefinition = appDef;
                        appointmentCarrier.DefaultMasterResource = MasterResource;
                        appointmentCarrier.DefaultResource = ProcedureDoctor;
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

        public override List<int> AllowedMedulaTedaviTipi()
        {
            List<int> typeList = new List<int>();
            typeList.Add(9);//Ağız Protez Tedavisi
            typeList.Add(13);//Diş Tedavisi
            return typeList;
        }

        //protected override void BeforeSetEpisode(SubEpisode SubEpisode)
        //{
        //    if (this.MenuDefinition != null)
        //    {
        //        if (this.MenuDefinition.Caption_Shadow.Contains("KONTROL") == true)//Menu Definitionın Captionında "KONTROL" ifadesi varsa kontol Muayenesidir.
        //            this.IsFollowUpExam = true;
        //        else
        //            this.IsFollowUpExam = false;
        //    }
        //    //foreach (DentalExamination de in episode.DentalExaminations) // İptal veya Hasta Gelmedi durumunda olmayan bir muayane varsa diğerleri kontrol muayenesi olur
        //    //{
        //    //    if (de.CurrentStateDefID != DentalExamination.States.Cancelled && de.CurrentStateDefID != DentalExamination.States.PatientNoShown)
        //    //        this.IsFollowUpExam = true;
        //    //}
        //    base.BeforeSetEpisode(SubEpisode);
        //}

        public void AddConsultationOrExaminationProcedure()
        {
            if (IsConsultation == true)
                AddDentalConsultationProcedure();
            else
            {
                AddDentalExaminationProcedure();
                AddPatientExaminationParticipationProcedure();
            }
        }

        // Diş konsültasyon prosedürünü oluşturur
        private void AddDentalConsultationProcedure()
        {
            Guid konsultasyonGuid = ProcedureDefinition.DentalConsultationProcedureObjectId;

            foreach (SubActionProcedure sp in SubactionProcedures)
            {
                if (sp.CurrentStateDef.Status != StateStatusEnum.Cancelled && sp.ProcedureObject.ObjectID == konsultasyonGuid) // Hizmet zaten varsa tekrar oluşturulmaz
                    return;
            }

            DentalConsultationProcedure consProc = new DentalConsultationProcedure(this, konsultasyonGuid.ToString());
            consProc.AccountOperation(AccountOperationTimeEnum.PREPOST);
        }

        // Muayene katılım payı prosedürünü oluşturur
        public void AddPatientExaminationParticipationProcedure()
        {
            if (IsOldAction == true)
                return;

            if (SubEpisode.PatientAdmission.AdmissionStatus != AdmissionStatusEnum.DisKabulu) // Kontrol muayenesi için katılım payı oluşturulmaz
                return;

            if (SystemParameter.IsPatientExaminationParticipationControl)
            {
                SubEpisodeProtocol sep = SubEpisode.OpenSubEpisodeProtocol;

                if (sep == null)
                    throw new TTException(SystemMessage.GetMessage(663));

                if (sep.Payer.GetPatientParticipation == true || (sep.MedulaIstisnaiHal != null && sep.MedulaIstisnaiHal.Kodu == "9" 
                    && sep.MedulaProvizyonTipi != null && sep.MedulaProvizyonTipi.provizyonTipiKodu == "N" && !string.IsNullOrEmpty(sep.MedulaTakipNo))) // Kurum tanımındaki "Hastaya Katılım Payı Hizmeti Oluşturulur" işaretli ise
                {
                    Guid muayeneKatılımPayıGuid = ProcedureDefinition.ExaminationParticipationProcedureObjectId;

                    foreach (DentalExaminationProcedure dep in DentalExaminationProcedures)
                    {
                        if (dep.CurrentStateDef.Status != StateStatusEnum.Cancelled && dep.ProcedureObject.ObjectID == muayeneKatılımPayıGuid) // Hizmet zaten varsa tekrar oluşturulmaz
                            return;
                    }

                    DentalExaminationProcedure examProc = new DentalExaminationProcedure(this, muayeneKatılımPayıGuid.ToString());
                    examProc.AccountOperation(AccountOperationTimeEnum.PREPOST);
                }
            }
        }

        // Diş muayene prosedürünü oluşturur
        private void AddDentalExaminationProcedure()
        {
            if (IsOldAction == true)
                return;

            Guid muayeneGuid = ProcedureDefinition.DentalExaminationProcedureObjectId;

            foreach (DentalExaminationProcedure dep in DentalExaminationProcedures)
            {
                if (dep.CurrentStateDef.Status != StateStatusEnum.Cancelled && dep.ProcedureObject.ObjectID == muayeneGuid) // Hizmet zaten varsa tekrar oluşturulmaz
                    return;
            }

            DentalExaminationProcedure examProc = new DentalExaminationProcedure(this, muayeneGuid.ToString());
            examProc.AccountOperation(AccountOperationTimeEnum.PREPOST);

            if (DentalExaminationType == PatientExaminationEnum.Control || (SubEpisode.PatientAdmission != null && SubEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.DisKontrol))// yatan hastadan alınan diş kabulünde patient admission olmuyor
            {
                foreach (AccountTransaction accTrx in examProc.AccountTransactions)
                    accTrx.OzelDurum = OzelDurum.GetOzelDurum("1");
            }
        }

        /* kpayi -- public void AddMedulaPatientParticipation()
        {
            if(this.Episode.Patient.Foreign != true)
            {
                if (!this.Episode.IsMedulaPatientParticipationExists())
                {
                    this.MuayeneGiris = new MuayeneGiris(ObjectContext);
                    this.MuayeneGiris.HealthFacilityID = SystemParameter.GetSaglikTesisKodu();
                    this.MuayeneGiris.CurrentStateDefID = MuayeneGiris.States.New;

                    if (this.Episode.Patient.UniqueRefNo != null)
                        this.MuayeneGiris.muayeneGirisDVO.hastaTCKimlikNo = this.Episode.Patient.UniqueRefNo.ToString();

                    if (this.RequestDate != null)
                        this.MuayeneGiris.muayeneGirisDVO.muayeneTarihiDateTime = this.RequestDate;
                    else
                    {
                        if (this.Episode.OpeningDate != null)
                            this.MuayeneGiris.muayeneGirisDVO.muayeneTarihiDateTime = this.Episode.OpeningDate;
                    }

                    if (this.ID.Value.HasValue)
                        this.MuayeneGiris.muayeneGirisDVO.referansNo = this.ID.Value;

                    if (this.Episode.PatientGroup == PatientGroupEnum.GeneralAdmiral || this.Episode.PatientGroup == PatientGroupEnum.RetiredGeneral || this.Episode.PatientGroup == PatientGroupEnum.GeneralAdmiralFamily || this.Episode.PatientGroup == PatientGroupEnum.RetiredGeneralFamily)
                        this.MuayeneGiris.muayeneGirisDVO.gizliTutulsunmu = true;
                    else
                        this.MuayeneGiris.muayeneGirisDVO.gizliTutulsunmu = false;

                    this.MuayeneGiris.muayeneGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
                }
            }
        }

        public void CancelMedulaPatientParticipation()
        {
            if (this.MuayeneGiris != null)
            {
                this.MuayeneGiris.CurrentStateDefID = MuayeneGiris.States.Cancelled;

                // Bu muayene iptal edildiği için, episode da başka muayene varsa ona MuayeneGiris oluşturmak gerekir
                this.Episode.AddOrCancelMedulaPatientParticipation();
            }
        }

        public void UpdateMedulaPatientParticipationToSentServer()
        {
            if (this.MuayeneGiris != null)
            {
                if (this.ID.Value.HasValue)
                    this.MuayeneGiris.muayeneGirisDVO.referansNo = this.ID.Value;
                
                if(this.MuayeneGiris.CurrentStateDefID == MuayeneGiris.States.New)
                    this.MuayeneGiris.CurrentStateDefID = MuayeneGiris.States.SentServer;
            }
        }*/

        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.DentalExamination;
            }
        }
        /// <summary>
        /// Diş Muayeneden girilen Önerilen Tedavileri için  aynı bölümdekiler bir arada olacak şekilde Diş tedavi işlemi fire edilmesi sağlanır.
        /// </summary>
        private void FireDentalTreatmentRequestBySuggestedTreatments()
        {
            int sTCount = 0;
            ArrayList suggestedTreatmentArray = new ArrayList();
            //Tedavi Önerilerine girilen her bir satırdaki departmentlar(Birimler) bir ArrayListe doldurulur(bir department yalnız bir kez eklenir)
            foreach (DentalExaminationSuggestedTreatment st in SuggestedTreatments)
            {
                if (st.SuggestedTreatmentProcedure != null)
                {
                    if (suggestedTreatmentArray.Contains(st.Department) == false)
                    {
                        suggestedTreatmentArray.Add(st.Department);
                    }
                }
            }
            sTCount = suggestedTreatmentArray.Count;
            sTCount--;
            //Array lise doldurulan birimlerin her biri için bir diş tedavi fire edilir.
            for (int k = 0; k <= sTCount; k++)
            {
                DentalTreatmentRequest dentalTreatmentRequest = new DentalTreatmentRequest(ObjectContext, this, (TTObjectClasses.ResSection)suggestedTreatmentArray[k]);
                //Önarilen Tedaviler fire edilen diş tedaviye atanır.
                foreach (DentalExaminationSuggestedTreatment st in SuggestedTreatments)
                {
                    if (st.Department == (TTObjectClasses.ResSection)suggestedTreatmentArray[k])
                    {
                        DentalTreatmentRequestSuggestedTreatment dentalTreatmentRequestSuggestedTreatment = new DentalTreatmentRequestSuggestedTreatment(ObjectContext, (DentalTreatmentRequestSuggestedTreatment)st);
                        dentalTreatmentRequest.SuggestedTreatments.Add(dentalTreatmentRequestSuggestedTreatment);
                    }
                }
            }
        }
        /// <summary>
        /// Diş Muayeneden girilen Önerilen Protezler için  aynı bölümdekiler bir arada olacak şekilde Diş protez işlemi fire edilmesi sağlanır.
        /// </summary>
        private void FireDentalProsthesisRequestBySuggestedProsthesis()
        {
            int sPCount = 0;
            ArrayList suggestedProsthesistArray = new ArrayList();
            //Önerilen Proteze girilen her bir satırdaki departmentlar bir ArrayListe doldurulur(bir department yalnız bir kez eklenir)
            foreach (DentalExaminationSuggestedProsthesis sp in SuggestedProsthesis)
            {
                if (sp.SuggestedProsthesisProcedure != null)
                {
                    if (suggestedProsthesistArray.Contains(sp.Department) == false)
                    {
                        suggestedProsthesistArray.Add(sp.Department);
                    }
                }
            }
            sPCount = suggestedProsthesistArray.Count;
            sPCount--;
            //Array lise doldurulan birimlerin her biri için bir diş protez fire edilir .
            for (int k = 0; k <= sPCount; k++)
            {
                DentalProsthesisRequest dentalProsthesisRequest = new DentalProsthesisRequest(ObjectContext, this, (TTObjectClasses.ResSection)suggestedProsthesistArray[k]);
                //Önerilen Protezler fire edilen diş proteze atanır.
                foreach (DentalExaminationSuggestedProsthesis sp in SuggestedProsthesis)
                {
                    if (sp.Department == (TTObjectClasses.ResSection)suggestedProsthesistArray[k])
                    {
                        DentalProsthesisRequestSuggestedProsthesis dentalProsthesisRequestSuggestedProsthesis = new DentalProsthesisRequestSuggestedProsthesis(ObjectContext, (DentalProsthesisRequestSuggestedProsthesis)sp);
                        dentalProsthesisRequest.SuggestedProsthesis.Add(dentalProsthesisRequestSuggestedProsthesis);

                    }

                }
            }
        }

        private void CheckDentalLinkActionsIsCompleted()
        {
            if (HasUnCompletedLinkedAction())
            {
                throw new TTException(SystemMessage.GetMessage(1144));
            }
        }

        //        protected override List<OldActionPropertyObject> OldActionPropertyList()
        //        {
        //            List<OldActionPropertyObject> propertyList;
        //            if(base.OldActionPropertyList()==null)
        //                propertyList = new List<OldActionPropertyObject>();
        //            else
        //                propertyList = base.OldActionPropertyList();
        //            propertyList.Add(new OldActionPropertyObject("Protokol No",Common.ReturnObjectAsString(this.ProtocolNo)));
        //            propertyList.Add(new OldActionPropertyObject("Muayene Tarihi",Common.ReturnObjectAsString(this.ProcessTime)));
        //            propertyList.Add(new OldActionPropertyObject("Diş Tedavi Dosyası",Common.ReturnObjectAsString(DentalExaminationFile)));
        //
        //            return propertyList;
        //        }
        //        protected override List<List<List<OldActionPropertyObject>>> OldActionChildRelationList()
        //        {
        //            // Her bir gridi tutacak Liste
        //            List<List<List<OldActionPropertyObject>>> gridList;
        //            if(base.OldActionChildRelationList()==null)
        //                gridList=new List<List<List<OldActionPropertyObject>>>();
        //            else
        //                gridList=base.OldActionChildRelationList();
        //            gridList.Add(this.OldActionPreDiagnosisList());
        //            gridList.Add(this.OldActionSecDiagnosisList());
        //            return gridList;
        //        }
        public override void AddSpecialProcedure(ResUser procedureDoctor)
        {
            ProcedureDefinition specialProcedure = null;
            bool charge = true;
            bool delete = false;
            DentalExaminationProcedure sdentalExaminationProcedure = null;

            if (procedureDoctor.Title != null)
            {
                IList titleProcList = TitleParticipationProcDef.GetByTitle(ObjectContext, (UserTitleEnum)procedureDoctor.Title);
                foreach (TitleParticipationProcDef titleProcDef in titleProcList)
                {
                    specialProcedure = titleProcDef.ProcedureObject;
                    break;
                }
            }
            foreach (DentalExaminationProcedure dentalExaminationProcedure in DentalExaminationProcedures)
            {
                foreach (TitleParticipationProcDef procDef in TitleParticipationProcDef.GetTitleParticipationProcDefinitions(ObjectContext))
                {
                    if (dentalExaminationProcedure.ProcedureObject == procDef.ProcedureObject)
                    {
                        if (specialProcedure == null)
                        {
                            ((ITTObject)dentalExaminationProcedure).Cancel();
                            charge = false;
                        }
                        else
                        {
                            if (dentalExaminationProcedure.ProcedureObject != specialProcedure)
                            {
                                ((ITTObject)dentalExaminationProcedure).Cancel();
                                charge = true;
                            }
                            else
                                charge = false;
                        }
                    }
                }
            }

            if (specialProcedure != null && charge && SubEpisode != null && SubEpisode.OpenSubEpisodeProtocol != null && SubEpisode.OpenSubEpisodeProtocol.Protocol.SpecialExamination == true)
            {
                sdentalExaminationProcedure = new DentalExaminationProcedure(this, specialProcedure.ObjectID.ToString());
                sdentalExaminationProcedure.AccountOperation(AccountOperationTimeEnum.PREPOST);
            }
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

        public AppointmentTypeEnum NumaratorAppointmentType
        {
            get { return AppointmentTypeEnum.Examination; }
        }

        public override void Cancel()
        {
            base.Cancel();
            /* kpayi --- this.CancelMedulaPatientParticipation();*/
            QuotaHistory quota = CheckIfQuotaReturn();
            if (quota != null)
            {
                ((ITTObject)quota).Delete();
                MasterResource.DailyQuota++;
                MasterResource.MonthlyQuota++;
            }
        }

        public override void CompleteMyUnCompletedAppoinments()
        {
            if (TransDef != null)
            {
                foreach (Appointment app in EpisodeAction.GetMyNewAppointments(ObjectID))
                {
                    if (TransDef.ToStateDef.Status == StateStatusEnum.CompletedUnsuccessfully || TransDef.ToStateDef.Status == StateStatusEnum.Cancelled || (PrevState != null && TransDef.ToStateDefID == PrevState.StateDefID))
                    {
                        app.CurrentStateDefID = Appointment.States.Cancelled;
                    }
                    if (TransDef.ToStateDef.Status == StateStatusEnum.Uncompleted || TransDef.ToStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                    {
                        app.CurrentStateDefID = Appointment.States.Completed;
                    }
                }
                foreach (Appointment app in MyNotApprovedAppointments())
                {
                    if (TransDef.ToStateDef.Status == StateStatusEnum.CompletedUnsuccessfully || TransDef.ToStateDef.Status == StateStatusEnum.Cancelled || (PrevState != null && TransDef.ToStateDefID == PrevState.StateDefID))
                    {
                        app.CurrentStateDefID = Appointment.States.Cancelled;
                    }
                    if (TransDef.ToStateDef.Status == StateStatusEnum.Uncompleted || TransDef.ToStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                    {
                        app.CurrentStateDefID = Appointment.States.Completed;
                    }
                }
            }
            else
            {
                foreach (Appointment app in EpisodeAction.GetMyNewAppointments(ObjectID))
                    app.CurrentStateDefID = Appointment.States.Completed;
                foreach (Appointment app in MyNotApprovedAppointments())
                    app.CurrentStateDefID = Appointment.States.Completed;
            }
        }

        // SGK lı hastalar için 10 gün içinde başka Diş Muayenesi hizmeti varsa, bu işlemden oluşan Diş Muayenesi hizmetini
        // Medulaya Gönderilmeyecek durumuna alır
        public void DoExaminationAccTrxMedulaDontSend()
        {
            //if (this.Episode.IsMedulaEpisode())
            {
                Guid muayeneGuid = ProcedureDefinition.DentalExaminationProcedureObjectId;
                AccountTransaction toothExaminationAccTrx = null;

                foreach (SubActionProcedure sp in SubactionProcedures)
                {
                    if (sp.ProcedureObject != null && sp.ProcedureObject.ObjectID.Equals(muayeneGuid))
                    {
                        foreach (AccountTransaction AccTrx in sp.AccountTransactions)
                        {
                            if (AccTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER && (AccTrx.CurrentStateDefID == AccountTransaction.States.New || AccTrx.CurrentStateDefID == AccountTransaction.States.ToBeNew))
                            {
                                toothExaminationAccTrx = AccTrx;
                                break;
                            }
                        }
                    }
                }

                if (toothExaminationAccTrx != null)
                {
                    bool oldToothExaminationExists = false;
                    // İlk Muayene ayın 2 si, ikinci Muayene ayın 12 si : Medula İkinci Muayene için hizmet kaydına izin vermiyor
                    // İlk Muayene ayın 2 si, ikinci Muayene ayın 11 i  : Medula İkinci Muayene için hizmet kaydına izin veriyor
                    // Bu yüzden "dayLimit - 1" yapıldı, yani "10 - 1 = 9" gün önceye kadar bakılsın diye
                    double dayLimit = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("CLOSEEPISODELASTUPDATEDAYLIMIT", "10"));
                    DateTime startDate = Common.RecTime().Date.AddDays(-1 * (dayLimit - 1));
                    DateTime endDate = Common.RecTime();

                    /* TODO:SEP
                    BindingList<MedulaProvision> provisions = MedulaProvision.GetMedulaProvisionsOfPatient(this.ObjectContext, startDate, endDate, this.Episode.Patient.ObjectID.ToString());
                    foreach (MedulaProvision mp in provisions)
                    {
                        // 5100, 5200, 5300, 5400, 5500, 5600, 5700 : Diş Branşları
                        if (mp.CurrentStateDefID != MedulaProvision.States.Cancelled && mp.Brans != null && (mp.Brans.Code == "5100" || mp.Brans.Code == "5200" || mp.Brans.Code == "5300" || mp.Brans.Code == "5400" || mp.Brans.Code == "5500" || mp.Brans.Code == "5600" || mp.Brans.Code == "5700"))
                        {
                            if (mp.SubEpisode != null)
                            {
                                foreach (AccountTransaction AccTrx in mp.SubEpisode.AccountTransactions)
                                {
                                    if (AccTrx.CurrentStateDefID != AccountTransaction.States.Cancelled && AccTrx.SubActionProcedure != null && AccTrx.SubActionProcedure.ProcedureObject != null && AccTrx.SubActionProcedure.ProcedureObject.ObjectID.ToString() == muayeneGuid.ToString())
                                    {
                                        oldToothExaminationExists = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (oldToothExaminationExists == true)
                            break;
                    }
                    */

                    if (oldToothExaminationExists == true)
                        toothExaminationAccTrx.CurrentStateDefID = AccountTransaction.States.MedulaDontSend;
                }
            }
        }

        protected virtual void ShowAction_ObjectUpdated(TTObject ttObject, ref bool contextSaved)
        {
            ttObject.ObjectContext.Save();
            contextSaved = true;
        }

        #region IDentalExamination Members

        public void GoToExaminationState()
        {
            CurrentStateDefID = DentalExamination.States.Examination;
        }

        public void GoToCancelState()
        {
            CurrentStateDefID = DentalExamination.States.Cancelled;
        }

        #endregion

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DentalExamination).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DentalExamination.States.New && toState == DentalExamination.States.Examination)
                PreTransition_New2Examination();
            else if (fromState == DentalExamination.States.New && toState == DentalExamination.States.Cancelled)
                PreTransition_New2Cancelled();
            else if (fromState == DentalExamination.States.Examination && toState == DentalExamination.States.Cancelled)
                PreTransition_Examination2Cancelled();
            else if (fromState == DentalExamination.States.Completed && toState == DentalExamination.States.Cancelled)
                PreTransition_Completed2Cancelled();
            else if (fromState == DentalExamination.States.Appointment && toState == DentalExamination.States.Examination)
                PreTransition_Appointment2Examination();
            else if (fromState == DentalExamination.States.Appointment && toState == DentalExamination.States.Cancelled)
                PreTransition_Appointment2Cancelled();
            else if (fromState == DentalExamination.States.OrderedPatient && toState == DentalExamination.States.Examination)
                PreTransition_OrderedPatient2Examination();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DentalExamination).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DentalExamination.States.New && toState == DentalExamination.States.Appointment)
                PostTransition_New2Appointment();
            else if (fromState == DentalExamination.States.New && toState == DentalExamination.States.Examination)
                PostTransition_New2Examination();
            else if (fromState == DentalExamination.States.New && toState == DentalExamination.States.PatientNoShown)
                PostTransition_New2PatientNoShown();
            else if (fromState == DentalExamination.States.New && toState == DentalExamination.States.Cancelled)
                PostTransition_New2Cancelled();
            else if (fromState == DentalExamination.States.Examination && toState == DentalExamination.States.Completed)
                PostTransition_Examination2Completed();
            else if (fromState == DentalExamination.States.Completed && toState == DentalExamination.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == DentalExamination.States.Appointment && toState == DentalExamination.States.Cancelled)
                PostTransition_Appointment2Cancelled();

            if (fromState == DentalExamination.States.Examination)
            {
                if (toState == DentalExamination.States.Cancelled)
                    PostTransition_Examination2Cancelled();
                else if (toState == DentalExamination.States.PatientNoShown)
                    PostTransition_Examination2PatientNoShown();
                //else
                //    PostTransition_FromExamination();
            }
            if (toState == DentalExamination.States.Completed || toState == DentalExamination.States.ExaminationCompleted || toState == DentalExamination.States.ProcedureRequested)
                PostTransition_ToCompleted();
        }

        protected void PostTransition_ToCompleted()
        {
            #region PostTransition_ToCompleted
            //if (!this.Paid())
            //{
            //    throw new TTUtils.TTException(SystemMessage.GetMessage(141));
            //}
            foreach (SubActionProcedure sap in SubactionProcedures)
            {
                if (sap is DentalExaminationProcedure || sap is DentalConsultationProcedure || sap is DentalProcedure)
                    sap.AutoComplete();
            }

            CompleteMyExaminationQueueItems();

            if (SubEpisode != null && SubEpisode.PatientAdmission != null && IsConsultation != true)
            {
                if (CurrentStateDefID == DentalExamination.States.ExaminationCompleted)
                    SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.MuayenesiSonlandı;
                else if (CurrentStateDefID == DentalExamination.States.ProcedureRequested)
                    SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.TetkikIstemDevam;
                else if (CurrentStateDefID == DentalExamination.States.Completed)
                    SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.MuayenesiSonlandı;
            }

            #endregion PostTransition_ToCompleted
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DentalExamination).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DentalExamination.States.New && toState == DentalExamination.States.Appointment)
                UndoTransition_New2Appointment(transDef);
            else if (fromState == DentalExamination.States.New && toState == DentalExamination.States.PatientNoShown)
                UndoTransition_New2PatientNoShown(transDef);
            else if (fromState == DentalExamination.States.New && toState == DentalExamination.States.Cancelled)
                UndoTransition_New2Cancelled(transDef);
            else if (fromState == DentalExamination.States.Examination && toState == DentalExamination.States.Cancelled)
                UndoTransition_Examination2Cancelled(transDef);
            else if (fromState == DentalExamination.States.Examination && toState == DentalExamination.States.PatientNoShown)
                UndoTransition_Examination2PatientNoShown(transDef);
            else if (fromState == DentalExamination.States.Examination && toState == DentalExamination.States.Completed)
                UndoTransition_Examination2Completed(transDef);
            else if (fromState == DentalExamination.States.Completed && toState == DentalExamination.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
            else if (fromState == DentalExamination.States.Appointment && toState == DentalExamination.States.Cancelled)
                UndoTransition_Appointment2Cancelled(transDef);
        }

        public void AccountingOperation()
        {
            foreach (DentalProcedure dp in DentalProcedures)
                dp.AccountingOperation();

            foreach (BaseTreatmentMaterial btm in DentalExaminationTreatmentMaterials)
                btm.AccountOperation(AccountOperationTimeEnum.PREPOST);
        }

        public DentalExamination(TTObjectContext objectContext, Guid masterActionObjectID, Guid ResourceID, Guid? DoctorID)
          : this(objectContext)
        {
            EpisodeAction episodeAction = ObjectContext.GetObject(masterActionObjectID, typeof(EpisodeAction)) as EpisodeAction;

            MasterAction = episodeAction;
            FromResource = episodeAction.MasterResource;
            Episode = episodeAction.Episode;
            SubEpisode = episodeAction.SubEpisode;//yukarda
            MasterResource = ObjectContext.GetObject(ResourceID, typeof(ResSection)) as ResSection;
            ProcedureDoctor = ObjectContext.GetObject(DoctorID.Value, typeof(ResUser)) as ResUser;
            ActionDate = Common.RecTime();
            RequestDate = ActionDate;
            CurrentStateDefID = DentalExamination.States.Examination;
            DentalExaminationType = PatientExaminationEnum.Dental;


            DateTime dateLimit = Convert.ToDateTime(Common.RecTime()).AddDays(-1 * (9)).Date;
            List<System.Guid> specialityList = new List<System.Guid>();

            String[] disBransKodlari = { "5100", "5200", "5300", "5400", "5500", "5600", "5700" };
            for (int i = 0; i < disBransKodlari.Length; i++)
            {
                System.ComponentModel.BindingList<SpecialityDefinition> specialityDefList = SpecialityDefinition.GetSpecialityByCode(objectContext, disBransKodlari[i]);
                foreach (SpecialityDefinition speciality in specialityDefList)
                {
                    specialityList.Add(speciality.ObjectID);
                }
            }

            System.ComponentModel.BindingList<Episode> oldEpisodes = Episode.GetByDayLimitAndMainSpeciality(objectContext, dateLimit.Date, specialityList.ToArray(), Episode.Patient.ObjectID.ToString(), Convert.ToDateTime(Common.RecTime()).Date.AddDays(1));
            if (oldEpisodes != null && oldEpisodes.Count > 0)
            {
                foreach (Episode tempEpisode in oldEpisodes)
                {
                    //if (tempEpisode.PatientStatus != PatientStatusEnum.Inpatient)
                    //{
                    foreach (var subEpisode in tempEpisode.SubEpisodes.Where(x => x.CurrentStateDefID != SubEpisode.States.Cancelled).OrderByDescending(z => z.OpeningDate))
                    {
                        if (subEpisode.StarterEpisodeAction is DentalExamination && subEpisode.OpeningDate.Value.Date == Common.RecTime().Date)
                            throw new Exception(TTUtils.CultureService.GetText("M25824", "Hastanın aynı gün aynı branştan vakası bulunmaktadır. Lütfen önceki vakadan devam ediniz."));

                        if (subEpisode.StarterEpisodeAction is PatientExamination && ((PatientExamination)(subEpisode.StarterEpisodeAction)).PatientExaminationType == PatientExaminationEnum.Normal
                           || subEpisode.StarterEpisodeAction is DentalExamination && ((DentalExamination)(subEpisode.StarterEpisodeAction)).DentalExaminationType == PatientExaminationEnum.Dental)
                        {

                            DentalExaminationType = PatientExaminationEnum.Control;
                            ///
                            ///aynı episode da 10 gün içinde diş kabuülü varsa kabulü bir önceki dişe bağlı kontrol kabulü olarak başlatmalı
                            ///yoksa ya da farklı episode da varsa yatışa bağlanmıştı zaten yukarda :)
                            ///
                            if (SubEpisode.Episode.ObjectID == subEpisode.Episode.ObjectID)
                                SubEpisode = subEpisode;
                            break;
                        }
                        //}
                    }
                }
            }


            //dateLimit = Common.RecTime().Date;

            //System.ComponentModel.BindingList<Episode> _oldEpisodes = Episode.GetSameByDayLimitAndMainSpeciality(objectContext, dateLimit, specialityList.ToArray(), this.Episode.Patient.ObjectID.ToString());
            //if (_oldEpisodes != null && _oldEpisodes.Count > 0)
            //{
            //    foreach (Episode tempEpisode in _oldEpisodes)
            //    {
            //        if (tempEpisode.PatientStatus == PatientStatusEnum.Inpatient)
            //        {
            //            foreach (var subEpisode in tempEpisode.SubEpisodes.Where(x => x.CurrentStateDefID != SubEpisode.States.Cancelled))
            //            {
            //                if (subEpisode.StarterEpisodeAction is DentalExamination)
            //                {
            //                    throw new Exception(TTUtils.CultureService.GetText("M25824", "Hastanın aynı gün aynı branştan vakası bulunmaktadır. Lütfen önceki vakadan devam ediniz."));
            //                }
            //            }
            //        }
            //    }
            //}


        }

        public void SetDentalExaminationStatus()
        {
            if (PatientAdmission.AdmissionStatus == AdmissionStatusEnum.Acil)
                DentalExaminationType = PatientExaminationEnum.Emergency;
            else if (PatientAdmission.AdmissionStatus == AdmissionStatusEnum.DisKabulu)
                DentalExaminationType = PatientExaminationEnum.Dental;
            else if (PatientAdmission.AdmissionStatus == AdmissionStatusEnum.DisKontrol)
                DentalExaminationType = PatientExaminationEnum.Control;
        }

        #region ICreateSubEpisode metodları


        public override bool IsNewSubEpisodeNeeded()
        {
            if (MasterAction is InPatientTreatmentClinicApplication)
                return true;
            return false;
        }

        public override DateTime SubEpisodeOpeningDate()
        {
            return RequestDate.Value;
        }

        public override DiagnosisCopyEnum GetDiagnosisCopyEnum()
        {

            return DiagnosisCopyEnum.DontCopy;
        }

        public override void FillLocalSEPProperties(ref SubEpisodeProtocol sep)
        {
            if (MasterAction is InPatientTreatmentClinicApplication)
                sep.MedulaTedaviTipi = TedaviTipi.GetTedaviTipi("13");
        }

       public override SubEpisodeStatusEnum GetSubEpisodePatientStatus() {
                return SubEpisodeStatusEnum.Outpatient;
        }

        public override ResSection GetSubEpisodeResSection() {
                return MasterResource;
        }

        public override SpecialityDefinition GetSubEpisodeSpeciality() {
                if (MasterAction is InPatientTreatmentClinicApplication)
                    return SpecialityDefinition.GetBrans("5100");//yatan hastadan başlatılan diş işlemlerinin branşı bu olmalı

                return ProcedureSpeciality;

            } 

        //Episode Episode { get; set; }

        //public override List<EpisodeAction> LinkedEpisodeActionsForSubEpisode { get; set; }

        //public override ISubEpisodeStarter SubEpisodeStarter { get { return this} set { } }

        //public override SubEpisode SubEpisodeCreatedByMe { get; set; }



        #endregion

    }
}