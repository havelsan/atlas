
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
using TTUtils.RequirementManager;
using TTObjectClasses.Tıbbi_Süreç.Kayıt___Kabul_Modülü.Requirements;
using static TTObjectClasses.SubEpisodeProtocol;

namespace TTObjectClasses
{
    public partial class PatientAdmission : BaseAction, IWorkListPatientAdmission, IEpisodeCreation, IOAPatientAdmission, IOldActions, ICreateSubEpisode
    {
        public partial class GetAdressInfoNotExists_Class : TTReportNqlObject
        {
        }

        public partial class GetProvisionNumberNotExists_Class : TTReportNqlObject
        {
        }

        public partial class GetPatientAdmissionsCount_Class : TTReportNqlObject
        {
        }

        public partial class GetMedulaProvisionsByPAtient_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_AdliVaka_Class : TTReportNqlObject
        {
        }

        public partial class GetOutPatientEtiquette_Class : TTReportNqlObject
        {
        }

        public partial class GetForeignPatientsNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetMAPByCountryAndDate_Class : TTReportNqlObject
        {
        }

        public partial class VEM_HASTA_ILETISIM_Class : TTReportNqlObject
        {
        }

        #region IEpisodeCreation Members
        public BaseAction GetMasterAction()
        {
            return MasterAction;
        }

        public PatientAdmission GetMyPatientAdmission()
        {
            return MyPatientAdmission;
        }

        public void SetMyPatientAdmission(PatientAdmission value)
        {
            MyPatientAdmission = value;
        }

        public PayerDefinition GetPayer()
        {
            return Payer;
        }
        public void SetPayer(PayerDefinition value)
        {
            Payer = value;
        }

        public ProtocolDefinition GetProtocol()
        {
            return Protocol;
        }
        public void SetProtocol(ProtocolDefinition value)
        {
            Protocol = value;
        }
        #endregion

        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = null;
                if (AdmissionStatus == AdmissionStatusEnum.DisKabulu || AdmissionStatus == AdmissionStatusEnum.DisKontrol)
                    appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.DentalExamination);
                else
                    appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.PatientExamination);
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
                    carrier.UserTypes.Add(UserTypeEnum.Nurse);

                    _appointmentList.Add(carrier);
                }
                ClearAppointmentCarrierDynamicFields(_appointmentList);
                foreach (AppointmentCarrier appointmentCarrier in _appointmentList)
                {
                    appointmentCarrier.DefaultAppointmentDefinition = appDef;
                    appointmentCarrier.DefaultMasterResource = Policlinic;
                    appointmentCarrier.DefaultResource = ProcedureDoctor;
                    //if (this.Policlinic != null)
                    //{
                    //    appointmentCarrier.MasterResourceFilter = " OBJECTID = '" + this.Policlinic.ObjectID.ToString() + "'";
                    //}
                    //else
                    //{
                    //    appointmentCarrier.MasterResourceFilter = "";
                    //}
                    break;
                }
                return _appointmentList;
            }
        }

        public bool? RequiredQuota
        {
            get
            {
                try
                {
                    #region RequiredQuota_GetScript                    

                    if (AdmissionType != null)
                    {
                        if (AdmissionStatus == AdmissionStatusEnum.Acil)
                            return false;
                        /*IList reasonForAdmissionList = ReasonForAdmission.GetByReasonAdmissionType(this.ObjectContext, (AdmissionTypeEnum)this.AdmissionType);
                        foreach (ReasonForAdmission ra in reasonForAdmissionList)
                        {
                            if (ra.IgnoreQuota == true)// Kabul sebebinde IgnoreQuota ise 
                                return false;
                            break;
                        }*/
                    }

                    if (AdmissionAppointment != null)
                    {
                        foreach (Appointment app in AdmissionAppointment.Appointments)
                        {
                            if (app.InitialObjectID != null)
                                return false;
                        }
                    }

                    return (bool?)true;
                    #endregion RequiredQuota_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "RequiredQuota") + " : " + ex.Message, ex);
                }
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "PATIENT":
                    {
                        Patient value = (Patient)newValue;
                        #region PATIENT_SetParentScript

                        if (IsFiresFromPACorrection != true)
                        {
                            if (value.InpatientEpisode != null && Donor == true)
                            {
                                throw new Exception(SystemMessage.GetMessage(87));
                            }
                        }
                        #endregion PATIENT_SetParentScript
                    }
                    break;
                case "ADMISSIONTYPE":
                    {
                        ProvizyonTipi value = (ProvizyonTipi)newValue;
                        #region ADMISSIONTYPE_SetParentScript
                        /*if(this.AdmissionType != null)
               this.SKRSVakaTuru.KODU = this.AdmissionType;
                this.SKRSVakaTuru.ADI = this.AdmissionType;*/
                        #endregion ADMISSIONTYPE_SetParentScript
                    }
                    break;
                case "PATIENTMEDULAHASTAKABUL":
                    {
                        PatientMedulaHastaKabul value = (PatientMedulaHastaKabul)newValue;
                        #region PATIENTMEDULAHASTAKABUL_SetParentScript
                        if (PatientMedulaHastaKabul != null)
                            throw new TTException(SystemMessage.GetMessage(690));

                        if (value != null)
                        {
                            if (Episode == null)
                                throw new TTException(SystemMessage.GetMessage(691));
                            value.Episode = Episode;
                        }
                        #endregion PATIENTMEDULAHASTAKABUL_SetParentScript
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

            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert

            #endregion PostInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate

            base.PostUpdate();

            #endregion PostUpdate
        }

        #region Methods
        public static void FillEpisode(PatientAdmission patientAdmission)
        {
            if (patientAdmission.MasterAction == null)
            {
                if (((ITTObject)patientAdmission.Episode).IsNew)
                {
                    patientAdmission.Episode.CurrentStateDefID = Episode.States.Open;
                    if (patientAdmission.Episode.OpeningDate.HasValue == false)
                        patientAdmission.Episode.OpeningDate = Common.RecTime();
                    patientAdmission.Episode.PatientStatus = PatientStatusEnum.Outpatient;
                    patientAdmission.Episode.ID.GetNextValue();
                    patientAdmission.Episode.HospitalProtocolNo.GetNextValue(patientAdmission.Episode.OpeningDate.Value.Year);
                    if (patientAdmission.FirstSubEpisode != null)
                        patientAdmission.FirstSubEpisode.Episode = patientAdmission.Episode;

                    if (patientAdmission.IsNewBorn == true)
                        patientAdmission.Episode.IsNewBorn = true;
                }

            }
        }

        //ICreateSubEpisode için kullanılacak
        public ISubEpisodeStarter GetSubEpisodeStarter()
        {
            foreach (EpisodeAction ea in FiredEpisodeActions)
            {
                return (ISubEpisodeStarter)ea;
            }
            return null;
        }

        public void SetSubEpisodeStarter(ISubEpisodeStarter value)
        {

        }

        public Episode GetEpisode()
        {
            return Episode;
        }

        public void SetEpisode(Episode value)
        {
            Episode = value;
        }

        //ICreateSubEpisode için default Uzmanlık Dalı İşlemin Uzmanlık Dalı
        public virtual SpecialityDefinition GetSubEpisodeSpeciality()
        {
            SpecialityDefinition speciality = null;
            if (GetSubEpisodeStarter() != null)
            {
                if (GetSubEpisodeStarter().GetProcedureSpeciality() == null)
                {
                    if (GetSubEpisodeStarter() is SubactionProcedureFlowable)
                        ((SubactionProcedureFlowable)GetSubEpisodeStarter()).SetProcedureSpeciality();
                    else
                        ((EpisodeAction)GetSubEpisodeStarter()).SetProcedureSpeciality();
                }
                speciality = (SpecialityDefinition)GetSubEpisodeStarter().GetProcedureSpeciality();
            }
            if (speciality == null)
            {
                if (Policlinic != null && Policlinic.ResourceSpecialities.Count > 0)
                    speciality = Policlinic.ResourceSpecialities.First().Speciality;
            }

            return speciality;
        }

        public virtual void SetSubEpisodeSpeciality(SpecialityDefinition value)
        {
        }

        public DiagnosisCopyEnum GetDiagnosisCopyEnum()
        {
            return DiagnosisCopyEnum.DontCopy;
        }

        //SubEpisodeu oluşturan işlemin Kaynağı işlemin SetProcedureSpecialtyBy attributuna bağlı defualtu MASTERRESOURCE
        public virtual ResSection GetSubEpisodeResSection()
        {
            if (GetSubEpisodeStarter() != null)
                return (ResSection)((EpisodeAction)GetSubEpisodeStarter()).GetResourceOfSepeciality();
            else if (Policlinic != null)
                return (ResSection)Policlinic;
            return null;
        }

        public virtual void SetSubEpisodeResSection(ResSection value)
        {

        }

        public static string PatientHasDebt(PatientAdmission pa)
        {
            if (pa.ObjectContext.QueryObjects<PatientOldDebt>("OLDUNIQUEREFNO = '" + pa.Episode.Patient.UniqueRefNo + "' AND (ISREMOVED = 0 OR ISREMOVED IS NULL)").Count(x => x.OldDebtReceiptDocument == null) > 0)
                return TTUtils.CultureService.GetText("M25836", "Hastanın önceki HBYS sisteminden borcu bulunmaktadır. Lütfen vezneye yönlendiriniz.");

            foreach (EpisodeAction episodeAction in pa.FiredEpisodeActions)
            {
                if (episodeAction.Paid() == false)
                    return TTUtils.CultureService.GetText("M25826", "Hastanın borcu bulunmaktadır. Lütfen vezneye yönlendiriniz.");
            }

            return "";
        }

        public virtual SubEpisodeStatusEnum GetSubEpisodePatientStatus()
        {
            if (SEP.MedulaTedaviTuru.tedaviTuruKodu.Equals("G") == true)
                return SubEpisodeStatusEnum.Daily; // Günübirlik hasta kabuü için ne olursa olsun günü birlik oluşturur

            return SubEpisodeStatusEnum.Outpatient;
        }

        public virtual void SetSubEpisodePatientStatus(SubEpisodeStatusEnum value)
        {
        }

        public virtual List<EpisodeAction> GetLinkedEpisodeActionsForSubEpisode()
        {
            List<EpisodeAction> eaList = new List<EpisodeAction>();
            foreach (EpisodeAction ea in FiredEpisodeActions)
            {
                eaList.Add(ea);
            }
            return eaList;
        }

        public virtual void SetLinkedEpisodeActionsForSubEpisode(List<EpisodeAction> value)
        {

        }

        public bool? CreateSubEpisode
        {
            get
            {
                if (IsFiresFromPACorrection == true)
                    return false;
                return true;
            }
            set { }
        }


        public virtual SubEpisode GetSubEpisodeCreatedByMe()
        {
            return SubEpisodes.OrderBy(x => x.OpeningDate).FirstOrDefault();
        }

        public virtual void SetSubEpisodeCreatedByMe(SubEpisode value) // ICreateSubEpisode  interfacei için  kullanılır
        {
        }


        public PatientAdmission MyPatientAdmission
        {
            get { return (PatientAdmission)this; }
            set
            {
            }
        }

        private PatientGroupEnum? _myOldPatientGroup;
        public PatientGroupEnum? MyOldPatientGroup
        {
            get { return _myOldPatientGroup; }
            set
            {
                _myOldPatientGroup = (PatientGroupEnum?)value;
            }
        }

        protected virtual void SetPatientGroup()
        { }

        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew == true)
            {
                SetPatientGroup();
            }
        }

        public override void Cancel()
        {
            if (CurrentStateDefID == PatientAdmission.States.Cancelled)
                return;

            if (AdmissionStatus != AdmissionStatusEnum.HizmetProtokol && AdmissionStatus != AdmissionStatusEnum.DisaridanGelenKonsultasyon && AdmissionStatus != AdmissionStatusEnum.SaglikKurulu)
            {
                //Counter değerini bir azalt
                PatientAdmission.UpdatePatientAdmissionCounter(ProcedureDoctor.ObjectID, Policlinic.ObjectID, Convert.ToDateTime(ActionDate), false, ObjectContext);
            }

            CurrentStateDefID = PatientAdmission.States.Cancelled;
        }

        /*
        public void CreateEpisodeProtocol()
        {

            if (this.Episode != null)
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("CHECKPAIDFORPAIDCIVILIANEMERGENCY", "FALSE") == "TRUE")
                {
                    if (this.Payer.Type.PayerType == PayerTypeEnum.Paid && this.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.Emergency)
                        this.Episode.AddEpisodeProtocol(this.Payer, this.Protocol, false, true);
                    else
                        this.Episode.AddEpisodeProtocol(this.Payer, this.Protocol, true, true);

                }
                else
                {

                    if (this.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.Emergency)
                        this.Episode.AddEpisodeProtocol(this.Payer, this.Protocol, false, true);
                    else
                        this.Episode.AddEpisodeProtocol(this.Payer, this.Protocol, true, true);
                }
            }
        }
        */

        public static void ControlAndCreateEpisodeProtocol(List<ResSection> resList, PatientAdmission patientAdmission)
        {
            // Önceden oluşmuş Muayene Katılım Payı ve Vakabaşı hizmeti iptal edilir
            //if ((bool)patientAdmission.IsFiresFromPACorrection)
            //{

            //    //this.Episode.CancelPatientParticipationProcedure();
            //    patientAdmission.Episode.CancelBulletinProcedure();
            //}


            // Muayene Katılım Payı oluşturulur
            /* kpayi --- if ((bool)this.IsFiresFromPACorrection)
            {
                //this.Episode.AddPatientParticipationProcedureNew();
                //this.Episode.AddPatientParticipationProcedure();
                this.Episode.AddOrCancelMedulaPatientParticipation(); //Duruma göre katılım payını oluşturur veya önceden olşmuşu iptal eder
            }*/
        }

        // Acil kabul mü ?
        public bool IsEmergency
        {
            get
            {
                if (AdmissionType != null && AdmissionType.provizyonTipiKodu.Equals("A"))
                    return true;

                return false;
            }
        }
        public bool IsCancellable
        {
            get
            {
                if (Episode.EpisodeActions != null && AdmissionStatus != AdmissionStatusEnum.Kontrol)
                {
                    var count = (Episode.PatientAdmissions.Where(x => x.CurrentStateDefID != PatientAdmission.States.Cancelled && x.AdmissionStatus == AdmissionStatusEnum.Kontrol)).ToList();
                    if (count != null && count.Count > 0)
                        return true;
                }

                return false;
            }
        }
        public static void FillSEPProperties(PatientAdmission patientAdmission)
        {
            SubEpisodeProtocol sep = null;
            if (patientAdmission.FirstSubEpisode != null)
            {
                foreach (var innerSep in patientAdmission.FirstSubEpisode.SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled))
                {
                    if (innerSep.PatientAdmission == patientAdmission)
                    {
                        sep = innerSep;
                        break;
                    }
                }

                if (sep == null)
                    sep = patientAdmission.SEP;


                sep.Payer = patientAdmission.Payer;
                sep.MedulaSigortaliTuru = patientAdmission.MedulaSigortaliTuru;
                sep.MedulaIstisnaiHal = patientAdmission.MedulaIstisnaiHal;
                sep.MedulaVakaTarihi = patientAdmission.MedulaVakaTarihi;

                if (patientAdmission.Episode != null && patientAdmission.Episode.Patient != null && patientAdmission.Episode.Patient.DonorUniqueRefNo != null)
                    sep.MedulaDonorTCKimlikNo = patientAdmission.Episode.Patient.DonorUniqueRefNo;

                sep.SetProtocol();
                if (patientAdmission.AdmissionStatus == AdmissionStatusEnum.SaglikKurulu || patientAdmission.AdmissionStatus == AdmissionStatusEnum.OluKabul || patientAdmission.AdmissionStatus == AdmissionStatusEnum.DisaridanGelenKonsultasyon || patientAdmission.AdmissionStatus == AdmissionStatusEnum.HizmetProtokol)
                {
                    sep.Brans = SpecialityDefinition.GetBrans("9999");
                    sep.MedulaTedaviTuru = TedaviTuru.GetTedaviTuru("A");
                    sep.MedulaTedaviTipi = TedaviTipi.GetTedaviTipi("0");
                }
                else
                {
                    if (patientAdmission.Policlinic.ResourceSpecialities.Count > 0)
                        sep.Brans = patientAdmission.Policlinic.ResourceSpecialities[0].Speciality;
                    else
                        sep.Brans = patientAdmission.Policlinic.Department.Brans;

                    if (patientAdmission.Policlinic.TedaviTuru != null)
                        sep.MedulaTedaviTuru = patientAdmission.Policlinic.TedaviTuru;

                    if (patientAdmission.Policlinic.TedaviTipi != null)
                        sep.MedulaTedaviTipi = patientAdmission.Policlinic.TedaviTipi;
                }

                if (patientAdmission.SEP.MedulaIstisnaiHal != null && patientAdmission.SEP.MedulaIstisnaiHal.Kodu.Equals("B"))
                {
                    sep.MedulaTedaviTipi = TedaviTipi.GetTedaviTipi("21");
                }


                if (sep.PatientAdmission == null)
                    sep.PatientAdmission = patientAdmission;

                patientAdmission.Episode.MedulaSigortaliTuru = sep.MedulaSigortaliTuru;
                patientAdmission.Episode.Payer = sep.Payer;
                patientAdmission.Episode.Protocol = sep.Protocol;

                if (patientAdmission.AdmissionType != null)
                    sep.MedulaProvizyonTipi = (ProvizyonTipi)patientAdmission.AdmissionType;

                // Acil kabullerinde ücret ödeme kontrolüne takılmaması için checkpaid false yapılır 
                if (patientAdmission.IsEmergency)
                    sep.CheckPaid = false;

                if (patientAdmission.ActionDate != null && patientAdmission.SEP != null
                    && patientAdmission.ActionDate != patientAdmission.SEP.MedulaProvizyonTarihi)
                    patientAdmission.SEP.MedulaProvizyonTarihi = patientAdmission.ActionDate;
            }
        }


        public static Patient GetPatientBySearch(string searchString)
        {
            Patient patient = null;
            if (searchString != "")
            {
                TTList patientList = Patient.Search(searchString);
                if (patientList == null || patientList.FoundList == null || patientList.FoundList.Count == 0)
                {// yanlızca yeni hastalar için Ara butonu çıktığından 0 yoksa aşağıdaki gibi 1 de olabilir
                    TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25782", "Hasta bulunamadı"));
                }
                else if (patientList.FoundList.Count == 1)
                {
                    patient = (Patient)patientList.FoundList[0];
                }
                else
                {
                    /*PatientSearchForm patientSearchForm = new PatientSearchForm(patientList);
                    patient = (Patient)patientSearchForm.GetSelectedObject();*/
                }
            }
            return patient;
        }

        public bool IsSGKPatientAdmission
        {
            get
            {
                return Payer.IsSGK;
            }
        }

        public bool IsCompletedPatientAdmissionExistsInEpisode()
        {
            //            if (this is PA_CivilianConsignment )
            //            {
            //                foreach (PatientAdmission pa in this.SubEpisode.PatientAdmissions)
            //                {
            //                    if (!pa.ObjectID.Equals(this.ObjectID) && pa.Cancelled == false)  // Diğer hasta kabuller kontrol edilmeli
            //                    {
            //                        if (pa is PA_CivilianConsignment )
            //                        {
            //                            foreach (TTObjectState objectState in pa.GetStateHistory())
            //                            {
            //                                if (objectState.StateDef.Status == StateStatusEnum.CompletedSuccessfully)
            //                                    return true;
            //                            }
            //                        }
            //                    }
            //                }
            //                return false;
            //            }
            //            else
            return true;
        }

        public void ResourcesToBeReferredClear()
        {
            int count = ResourcesToBeReferred.Count;
            for (int i = 0; i < count; i++)
            {
                ((ITTObject)ResourcesToBeReferred[0]).Delete();
            }
        }

        /* Bu metod kullanılmadığı için kapatıldı (MDZ)
        public void CheckPatientAdmissionRules(EpisodeAction firedAction)
        {
            //SGKlı bir hasta 10 gün içinde aynı uzmanlık dalına birden fazla kabul edilemez.
            //if (firedAction is PatientExamination || firedAction is DentalExamination)
            if (firedAction is PatientExamination)
            {
                if (IsSGKPatientAdmission)
                {
                    //int limit = Convert.ToInt32(SystemParameter.GetParameterValue("AdmittingSameSpecialityDayLimit", "10")); sitem parametresini kapatmasınlar diye devre dışı bırakıldı
                    int limit = 10;
                    DateTime dateLimit = Convert.ToDateTime(Common.RecTime()).AddDays(-1 * (limit)).Date;
                    List<System.Guid> specialityList = new List<System.Guid>();
                    if (firedAction.ProcedureSpeciality != null)
                    {
                        specialityList.Add(firedAction.ProcedureSpeciality.ObjectID);
                        TTObjectContext context = new TTObjectContext(true);
                        BindingList<Episode> episodeList = Episode.GetByDayLimitAndMainSpeciality(context, dateLimit, specialityList.ToArray(), this.Episode.Patient.ObjectID.ToString(), Convert.ToDateTime(this.ActionDate));
                        foreach (Episode episode in episodeList)
                        {
                            if (episode.ObjectID != this.Episode.ObjectID)
                            {
                                if (episode.PatientStatus == PatientStatusEnum.Outpatient)
                                    throw new Exception(SystemMessage.GetMessageV3(693, new string[] { limit.ToString(), firedAction.ProcedureSpeciality.Name.ToString(), Convert.ToDateTime(((Episode)episodeList[0]).OpeningDate).ToShortDateString() }));
                            }
                        }
                    }
                }
            }
        }

        
        public void ControlSEPsForPAUpdate()
        {
            this.Episode.CancelBulletinProcedure();

            TTObjectContext context = new TTObjectContext(true);
            PatientAdmission originalPA = context.GetObject(ObjectID, typeof(PatientAdmission)) as PatientAdmission;

            if (originalPA.Payer != Payer)
            {
                ProtocolDefinition protocol = null;

                foreach (SubEpisodeProtocol sep in Episode.AllSubEpisodeProtocols())
                {
                    if (sep.CurrentStateDefID == SubEpisodeProtocol.States.Open)
                    {
                        if (protocol == null)
                            protocol = Payer.GetProtocol(this.Episode.Patient, sep.MedulaSigortaliTuru);  // TODO : Mustafa Bu MedulaSigortaliTuru nun güncel olan olması lazım ayrıca bunu sep. diye değil pa üzerinden almamız lazım.

                        SubEpisodeProtocol.SEPProperty SEPProperty = new SubEpisodeProtocol.SEPProperty();
                        SEPProperty.payer = Payer;
                        SEPProperty.protocol = protocol;
                        SEPProperty.cancelOldSEP = true;

                        // Kurum bilgisi ile birlikte başka bilgiler de değişmişse aşağıdaki değişikliklerin de yapılması lazım
                        // Policlinic değişmişse
                        
                        //if (originalPA.Policlinic != Policlinic)
                        //{
                        //    SEPProperty.brans = Speciality;
                        //    SEPProperty.tedaviTuru = Policlinic.TedaviTuru;
                        //    SEPProperty.tedaviTipi = Policlinic.TedaviTipi;
                        //}
                        
                        // Sigortali Turu değişmişse
                        //SEPProperty.sigortaliTuru = sep.MedulaSigortaliTuru;  // TODO : Mustafa  Bu MedulaSigortaliTuru nun güncel olan olması lazım ayrıca bunu sep. diye değil pa üzerinden almamız lazım.
                        
                        //if (originalPA.AdmissionType != AdmissionType)
                        //    SEPProperty.provizyonTipi = (ProvizyonTipi)AdmissionType;
                        
                        sep.CloneForNewSEP(SEPCloneTypeEnum.PatientAdmissionChange, SEPProperty);
                    }
                }
            }
            
            // Geliş Sebebi (Provizyon Tipi) nin değiştiği durumda ne yapmalıyız ?
            if (originalPA.AdmissionType != AdmissionType)
            {

            }

            // Sigortalı Türü nün değiştiği durumda SEP ler güncellenmeli, SGK hastası ise anlaşması değişmeli ve Takipler silinip tekrar alınmalı mı ?

            // PatientAdmission.Policlinic.ResourceSpecialities[0].Speciality -> BRANŞ ya da Policlinic değiştiğinde SEP ler güncellenmeli

            PatientAdmission.ControlBulletinProtocol(this);
        }
        */

        public string OldActionReportHtml()
        {
            string report = "";
            report = report + "<html><table border=1 width='100%'>";



            report = report + "</table></html>";

            return report;

        }


        public override bool IsPropertyReadonly(TTObjectPropertyDef propDef)
        {
            return false;
        }
        public override bool IsParentRelationReadonly(TTObjectRelationDef relDef)
        {
            return false;
        }

        private bool? isSettingEpisode = false;
        //Episode Set edilirken IsParentRelationReadonly ve IsPropertyReadonly
        //kodlarının false dönmesini Böylece Episode'dan gelen Propogation(CopyToların) ReadOnly'ye takılmadan set edilmesini sağlar
        public bool? IsSettingEpisode
        {
            get
            {
                try
                {
                    return (bool?)isSettingEpisode;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            set
            {
                try
                {
                    isSettingEpisode = value;
                }
                catch (Exception ex)
                {
                    throw new TTException("Özelliik 'IsSettingEpisode' ın değeri yazılamıyor.: " + ex.Message, ex);
                }
            }
        }

        public static void SetEpisodeDetails(PatientAdmission pa, bool skipFiredActions = false)
        {
            if (pa.Episode != null)
            {
                string admissionSpecOrRes = "";

                if (skipFiredActions == false)
                {
                    foreach (EpisodeAction ep in pa.FiredEpisodeActions)
                    {
                        if (ep.MasterResource != null)
                        {
                            if (admissionSpecOrRes != "")
                                //admissionSpecOrRes += "-";
                                admissionSpecOrRes += ep.MasterResource.Name;
                        }
                    }
                }
                pa.Episode.AdmissionResource = admissionSpecOrRes;

                if (pa.AdmissionStatus == AdmissionStatusEnum.OluKabul || pa.AdmissionStatus == AdmissionStatusEnum.DisaridanGelenKonsultasyon || pa.AdmissionStatus == AdmissionStatusEnum.HizmetProtokol)
                {
                    pa.Episode.MainSpeciality = null;
                }
                else if (pa.AdmissionStatus == AdmissionStatusEnum.SaglikKurulu)
                {
                    BindingList<ResPoliclinic> hcPoliklinikList = new BindingList<ResPoliclinic>();
                    hcPoliklinikList = ResPoliclinic.GetHCPoliclinicList();
                    if (hcPoliklinikList.Count > 0 && (hcPoliklinikList[0].ResourceSpecialities != null || hcPoliklinikList[0].ResourceSpecialities.Count > 0))
                        pa.Episode.MainSpeciality = hcPoliklinikList[0].ResourceSpecialities[0].Speciality;
                    else
                        throw new TTException(TTUtils.CultureService.GetText("M26791", "Sağlık Kurulu için tanımlanmış bir poliklinik bulunamadı!"));
                }
                else
                    pa.Episode.MainSpeciality = (pa.Policlinic?.ResourceSpecialities.Count > 0) ? pa.Policlinic?.ResourceSpecialities[0]?.Speciality : pa.Policlinic?.Department?.Brans;//pa.Policlinic.ResourceSpecialities[0].Speciality;
            }
        }

        //public static string GetAdmissionSpecOrResOfCurrentDayEpisodes(Patient patient)
        //{
        //    string admissionSpeciality = "";
        //    DateTime dateLimit = Common.RecTime().Date;
        //    TTObjectContext roContext = new TTObjectContext(true);
        //    BindingList<Episode.GetByPatientAndDayLimitNQL_Class> episodes = Episode.GetByPatientAndDayLimitNQL(roContext, dateLimit, patient.ObjectID);
        //    foreach (Episode.GetByPatientAndDayLimitNQL_Class episode in episodes)
        //    {
        //        //TODO NE
        //        //if (this._PatientAdmission.Episode == null || episode.ObjectID != this._PatientAdmission.Episode.ObjectID)
        //        //  {
        //        if (((DateTime)episode.OpeningDate).Date == Common.RecTime().Date)
        //        {
        //            Episode episodeObject = (Episode)roContext.GetObject((System.Guid)episode.ObjectID, typeof(Episode).Name);
        //            if (episodeObject.PatientAdmission.CurrentStateDef.Status != StateStatusEnum.Cancelled)
        //            {
        //                if (!string.IsNullOrEmpty(admissionSpeciality))
        //                    admissionSpeciality += ",";
        //                admissionSpeciality += episodeObject.AdmissionSpecOrRes + " ";
        //            }
        //        }
        //        // }
        //    }
        //    return admissionSpeciality;
        //}

        public void CheckAndSetQuato(ResSection resSection)
        {

        }
        public void SetEpisodeIsQuotaUsed(ResSection resSection)
        {
            if (Episode.IsQuotaUsed != true)// Kontenjanla kabül işaretlenmediyse  u günün kontenjan tarihçesine bakılıp işaretlenir
            {
                TTObjectContext orContext = new TTObjectContext(true);
                BindingList<TTObjectClasses.QuotaHistory.GetByStartEndDateAndPatient_Class> patientQuota = QuotaHistory.GetByPatientDailyQuota(ObjectContext, Common.RecTime(), resSection, Episode.Patient);
                if (patientQuota.Count > 0)// o gün için  daha önce kontenjan harcandıysa işaretlenemlidir.
                {
                    Episode.IsQuotaUsed = true;
                }
            }
        }

        public SubEpisode FirstSubEpisode
        {
            get
            {
                return SubEpisodes.Where(x => x.CurrentStateDefID != SubEpisode.States.Cancelled).OrderBy(x => x.OpeningDate).FirstOrDefault();
            }
        }

        public SubEpisode LastSubEpisode
        {
            get
            {
                return SubEpisodes.Where(x => x.CurrentStateDefID != SubEpisode.States.Cancelled).OrderByDescending(x => x.OpeningDate).FirstOrDefault();
            }
        }

        public SubEpisodeProtocol SEP
        {
            get
            {
                return FirstSubEpisode?.FirstSubEpisodeProtocol;
            }
        }

        public SpecialityDefinition Speciality
        {
            get
            {
                return (Policlinic?.ResourceSpecialities.Count > 0) ? Policlinic?.ResourceSpecialities[0]?.Speciality : Policlinic?.Department?.Brans;
            }
        }

        public void CancelBulletinProcedure()
        {
            foreach (EpisodeAction ea in FiredEpisodeActions)
            {
                if (ea is PatientExamination)
                {
                    foreach (SubActionProcedure sp in ea.SubactionProcedures)
                    {
                        if (sp is PatientExaminationProcedure && sp.ProcedureObject is BulletinProcedureDefinition)
                            sp.Cancel();
                    }
                }
            }
        }

        public DentalExamination GetDentalExaminationFiredByMe()
        {
            foreach (EpisodeAction ea in FiredEpisodeActions)
            {
                if (ea is DentalExamination)
                    return ea as DentalExamination;
            }
            return null;
        }

        public PatientExamination GetPatientExaminationFiredByMe()
        {
            foreach (EpisodeAction ea in FiredEpisodeActions)
            {
                if (ea is PatientExamination)
                    return ea as PatientExamination;
            }
            return null;
        }

        // Vakabaşı hizmetini düzenleyen metod
        public static void ControlBulletinProtocol(PatientAdmission patientAdmission)
        {
            // Buna gerek kalmadı CancelRelatedObjects() metodunda önceki PA dan fire edilen episodeaction lar Cancel ediliyor zaten.
            // oldPatientAdmission ın oluşturduğu Vakabaşı hizmeti varsa iptal edilir 
            //if (oldPatientAdmission != null)
            //    oldPatientAdmission.CancelBulletinProcedure();

            // Vakabaşı hizmeti oluşturulur
            if (patientAdmission.Payer.IsSGKAll && (patientAdmission.AdmissionStatus == AdmissionStatusEnum.Normal || patientAdmission.AdmissionStatus == AdmissionStatusEnum.Yenidogan || patientAdmission.AdmissionStatus == AdmissionStatusEnum.Kontrol))
            {
                SubEpisodeProtocol sep = patientAdmission.SEP;
                if (sep != null && sep.MedulaTedaviTuru != null && sep.MedulaTedaviTuru.tedaviTuruKodu == "A" && sep.MedulaProvizyonTipi.provizyonTipiKodu != "A")
                {
                    PatientExamination pEx = patientAdmission.GetPatientExaminationFiredByMe();

                    if (pEx == null)
                        throw new TTException(SystemMessage.GetMessage(232));

                    if (patientAdmission.Speciality == null)
                        throw new TTException("Hasta kabul işleminin branşı bilinmediği için 'Vakabaşı Hizmeti Gerektirir' bilgisine ulaşılamıyor.");

                    if (patientAdmission.Speciality.IsBulletin == true)
                    {
                        //if (!patientAdmission.Episode.IsInvoicedBulletinProcedureExists())
                        //{
                        PatientExaminationProcedure bulletinprocedure = new PatientExaminationProcedure(patientAdmission.ObjectContext);
                        bulletinprocedure.ProcedureObject = patientAdmission.Speciality.BulletinProcedure;
                        bulletinprocedure.CurrentStateDefID = PatientExaminationProcedure.States.Completed;
                        bulletinprocedure.PerformedDate = Common.RecTime();
                        bulletinprocedure.PatientExamination = pEx;

                        if (patientAdmission.Episode.OpeningDate != null)
                            bulletinprocedure.PricingDate = patientAdmission.Episode.OpeningDate;

                        bulletinprocedure.AccountOperation(AccountOperationTimeEnum.PREPOST);

                        if (patientAdmission.AdmissionStatus == AdmissionStatusEnum.Kontrol)
                        {
                            foreach (AccountTransaction accTrx in bulletinprocedure.AccountTransactions)
                                accTrx.OzelDurum = OzelDurum.GetOzelDurum("1");
                        }
                        //}
                    }
                }
            }
        }

        //TODO BG
        //// Aynı branştan bağlı takip alınmışsa, oluşan vakabaşı ve muayene hizmetlerini iptal eder
        //public void ControlExaminationProcedures()
        //{
        //    if (this.SubEpisodeProtocol != null && !string.IsNullOrEmpty(this.SubEpisodeProtocol.MedulaTakipNo) && this.SubEpisodeProtocol.ParentSEP != null && !string.IsNullOrEmpty(this.SubEpisodeProtocol.ParentSEP.MedulaTakipNo))
        //    {
        //        if (this.SubEpisodeProtocol.Brans != null && !string.IsNullOrEmpty(this.SubEpisodeProtocol.Brans.Code))
        //        {
        //            MedulaProvision relatedProvision = MedulaHelper.GetMedulaProvisionByProvisionNo(this.SubEpisodeProtocol.ParentSEP.MedulaTakipNo, this.ObjectContext);
        //            if (relatedProvision != null && relatedProvision.Brans != null && !string.IsNullOrEmpty(relatedProvision.Brans.Code))
        //            {
        //                if (this.SEP.Brans.Code.Equals(relatedProvision.Brans.Code))
        //                {
        //                    foreach (PatientExamination pe in this.Episode.PatientExaminations)
        //                    {
        //                        foreach (PatientExaminationProcedure peProcedure in pe.PatientExaminationProcedures)
        //                        {
        //                            foreach (AccountTransaction accTrx in peProcedure.AccountTransactions)
        //                            {
        //                                if (accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
        //                                    accTrx.CurrentStateDefID = AccountTransaction.States.Cancelled;
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        public bool HaveRelationshipProperty()
        {
            System.Reflection.PropertyInfo propInfo = GetType().GetProperty("Relationship");
            if (propInfo != null)
                return true;
            else
                return false;
        }

        public PatientAdmission PreparePatientAdmissionForRemoteMethod(bool withNewObjectID)
        {
            // Çağırılan yerde savePoit konulup daha sonra o pointe dönülmeli
            if (withNewObjectID)
            {
                PatientAdmission sendingPatientAdmission = (PatientAdmission)Clone();
                //Episode Set edilirken IsParentRelationReadonly ve IsPropertyReadonly
                //kodlarının false dönmesini Böylece Episode'dan gelen Propogation(CopyToların) ReadOnly'ye takılmadan set edilmesini sağlar
                sendingPatientAdmission.IsSettingEpisode = true;
                sendingPatientAdmission.Episode = null;
                sendingPatientAdmission.IsSettingEpisode = false;
                sendingPatientAdmission.PatientMedulaHastaKabul = null;
                sendingPatientAdmission.AdmissionAppointment = null;
                sendingPatientAdmission.IsCorrected = false;
                sendingPatientAdmission.IsFiresFromPACorrection = false;
                sendingPatientAdmission.MasterAction = null;
                return sendingPatientAdmission;
            }
            else
            {
                return this;
            }

        }



        //public bool DontCreateNewSubEpisodeUseOld(SubEpisode oldSubEpisode)
        //{
        //    return false;
        //}



        /**
         *  Sync olarak takip alınması için Patient.PatientAdmissionWebCaller nesnesindeki metodların çağrımı yapılıyor.
         * */

        public HastaKabulIslemleri.provizyonCevapDVO HastaKabulSync(TTObjectClasses.HastaKabulIslemleri.provizyonGirisDVO provizyonGirisDVO)
        {
            HastaKabulIslemleri.provizyonCevapDVO result = null;
            /*
            TTObjectContext _context = this.ObjectContext;
            MedulaProvision _medulaProvision = GetObjectMedulaProvision();

            TTObjectClasses.XXXXXXMedulaServices.HastaKabulParam inputParam = new TTObjectClasses.XXXXXXMedulaServices.HastaKabulParam(provizyonGirisDVO, _medulaProvision.ObjectID.ToString());
            result = HastaKabulIslemleri.WebMethods.hastaKabulSync(TTObjectClasses.Sites.SiteLocalHost, provizyonGirisDVO);
            inputParam.HastaKabulCompletedInternal(result, provizyonGirisDVO, _medulaProvision.ObjectID.ToString(), _context);
            */
            return result;
        }

        /** 
         * ASync olarak takip alınması için Patient.PatientAdmissionWebCaller nesnesindeki metodların çağrımı yapılıyor.
         * */

        public void HastaKabulASync(TTObjectClasses.HastaKabulIslemleri.provizyonGirisDVO provizyonGirisDVO)
        {
            /*
            MedulaProvision _medulaProvision = GetObjectMedulaProvision();
            TTObjectClasses.XXXXXXMedulaServices.HastaKabulParam inputParam = new TTObjectClasses.XXXXXXMedulaServices.HastaKabulParam(provizyonGirisDVO, _medulaProvision.ObjectID.ToString());
            HastaKabulIslemleri.WebMethods.hastaKabulASync(TTObjectClasses.Sites.SiteLocalHost, inputParam, provizyonGirisDVO);
            */
        }

        /**
         * Formdaki Textbox alanların Visible ve Text özelliklerini düzenlemeye yarayan fonksiyonlar
         * */

        public void SetTakipAlAreaTextMessage(string message)
        {
            if (message != null)
                takipAlCevap = message;
        }

        public void SetTakipAlHataMesajiAreaTextMessage(HastaKabulIslemleri.provizyonCevapDVO response, string message)
        {

            if (response != null)
            {
                if (!string.IsNullOrEmpty(response.sonucMesaji))
                    takipAlHataMesaji = response.sonucMesaji;
                else
                    takipAlHataMesaji = message;
            }
            else
                takipAlHataMesaji = message;
        }

        //public void SetSEPInitalProperties()
        //{
        //    if (SubEpisodeProtocol != null)
        //    {
        //        SubEpisodeProtocol.CurrentStateDefID = SubEpisodeProtocol.States.Open;
        //        SubEpisodeProtocol.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProvisionNoNotExists;
        //        SubEpisodeProtocol.CreationDate = Common.RecTime();
        //        SubEpisodeProtocol.MedulaProvizyonTarihi = Common.RecTime();
        //    }
        //}

        /*
        public MedulaProvision GetObjectMedulaProvision()
        {
            MedulaProvision _medulaProvision;
            if (this.IsFiresFromPACorrection != true)
            {
                if (this.Episode.EpisodeActions[0].SubEpisode.MdlProvision == null)
                {
                    _medulaProvision = new MedulaProvision(this.ObjectContext);
                    this.SetMedulaProvisionInitalProperties(_medulaProvision);
                }
                else
                    _medulaProvision = this.MedulaProvision;
            }
            else
                _medulaProvision = this.MedulaProvision;

            return _medulaProvision;
        }
        */

        // Eskiden Medula çağrımını başlatan fonksiyon, artık SEP.GetProvisionFromMedula() metodu kullanılacağı için kapatıldı
        //    public void GetMedulaProvision()
        //    {
        //        string uKey;
        //        bool asenkronCalis = false;
        //        bool responseIsNull = false;
        //        if (this.Episode.IsMedulaEpisode() == false)
        //            return;

        //        HastaKabulIslemleri.provizyonGirisDVO provizyonGirisDVO = (HastaKabulIslemleri.provizyonGirisDVO)GetProvizyonGirisDVO();
        //        try
        //        {
        //            //Sync Provizyon alma
        //            if (TTObjectClasses.SystemParameter.GetParameterValue("MEDULATAKIPALMAMETODU", "") == "S")
        //            {

        //                HastaKabulIslemleri.provizyonCevapDVO response = HastaKabulSync(provizyonGirisDVO);
        //                DateTime firstTry = TTObjectClasses.Common.RecTime();
        //                if (response != null)
        //                {
        //                    if (!string.IsNullOrEmpty(response.sonucKodu))
        //                    {
        //                        if (response.sonucKodu.Equals("0000") || response.sonucKodu.Equals("9000") || response.sonucKodu.Equals("0008"))
        //                        {
        //                            TempProvisionNo = response.takipNo;
        //                            //InfoBox.Alert("Takip No : " + response.takipNo + " olacak şekilde hasta başvurusu yapılmıştır.", MessageIconEnum.InformationMessage);
        //                            SetTakipAlAreaTextMessage("Başarılı");
        //                        }
        //                        else if (response.sonucKodu.Equals("0541") || response.sonucKodu.Equals("0542") || response.sonucKodu.Equals("0549") || response.sonucKodu.Equals("1129"))
        //                        {
        //                            //TODO MUSTAFA-ATALAY

        //                            throw new Exception("Medula sisteminden yanıt alınamıyor!");
        //                            /*
        //                            string oldProvision = response.sonucMesaji.Substring(response.sonucMesaji.IndexOf("[") + 1, 7);
        //                            //                            MedulaProvision medulaProv = MedulaProvision.GetMedulaProvisionByProvisionNo(oldProvision);
        //                            //                            if (medulaProv != null && medulaProv.TedaviTuru != null) {
        //                            //                                if ("A".Equals(medulaProv.TedaviTuru.tedaviTuruKodu))
        //                            //                                    throw new TTUtils.TTException("10 gün içerisinde aynı branştan "+ oldProvision +" takibi bulunmaktadır.Bu branştan yeni takip alamazsınız!");
        //                            //                            }
        //                            uKey = ShowBox.Show(ShowBoxTypeEnum.Message, "Evet,Hayır", "E,H", "Uyarı", "Medula Provizyon", "Bu takip '" + oldProvision + "' no.lu takibe bağlı alınmalıdır. Bağlı takip alarak devam etmek istiyor musunuz?", 2);
        //                            if (String.IsNullOrEmpty(uKey) || uKey == "H")
        //                                throw new TTUtils.TTException("İşlemden vazgeçildi");

        //                            while (firstTry.AddSeconds(4) > TTObjectClasses.Common.RecTime())
        //                            {
        //                                System.Threading.Thread.Sleep(100);
        //                            }

        //                            provizyonGirisDVO.takipNo = oldProvision;
        //                            response = HastaKabulSync(provizyonGirisDVO);
        //                            if (response.sonucKodu.Equals("0000") || response.sonucKodu.Equals("9000") || response.sonucKodu.Equals("0008"))
        //                            {
        //                                TempProvisionNo = response.takipNo;
        //                                InfoBox.Alert("Takip No : " + response.takipNo + " olacak şekilde hasta başvurusu yapılmıştır.", MessageIconEnum.InformationMessage);
        //                                SetTakipAlAreaTextMessage(oldProvision + "'a bağlı takip");
        //                            }
        //                            else
        //                            {
        //                                if (!string.IsNullOrEmpty(response.sonucMesaji))
        //                                    throw new Exception(response.sonucKodu + " " + response.sonucMesaji);
        //                                else
        //                                    throw new Exception("Medula sisteminden yanıt alınamıyor!");
        //                            }*/
        //}
        //                        else if (response.sonucKodu.Equals("1163"))
        //                        {
        //                            string oldProvision = response.sonucMesaji.Substring(response.sonucMesaji.IndexOf("[") + 1, 7);

        //                            MedulaProvision mp = MedulaProvision.GetMedulaProvisionByProvisionNo(oldProvision);
        //                            if (mp == null)
        //                            {
        //                                //InfoBox.Alert("Takip No : " + response.takipNo + " olacak şekilde hasta başvurusu yapılmıştır.", MessageIconEnum.InformationMessage);
        //                                TempProvisionNo = response.takipNo;
        //                                SetTakipAlAreaTextMessage("Başarılı");
        //                                if (response.hastaBasvuruNo != null)
        //                                    this.SEP.MedulaBasvuruNo = response.hastaBasvuruNo;

        //                            }
        //                            else
        //                            {
        //                                SetTakipAlAreaTextMessage("Başarısız");
        //                                throw new TTUtils.TTException("Hastanın aynı gün aynı branştan vakası bulunmaktadır. Yeni medula provizyon alamazsınız. Lütfen önceki vakadan devam ediniz.");
        //                            }
        //                        }

        //                        else
        //                        {
        //                            //Medula dan dönen response.sonucKodu MedulaErrorCodeDefinition tablosunda tanımlı ve Asenkron çalışabilir olarak işaretliyse, Asenkron çalışsın mı diye soruyor. BB
        //                            IList AsyncMedulaCodes = MedulaErrorCodeDefinition.GetAsyncIsTrueByErrorCode(this.ObjectContext, response.sonucKodu);
        //                            if (AsyncMedulaCodes.Count > 0)
        //                            {
        //                                //TODO MUSTAFA-ATALAY
        //                                SetTakipAlAreaTextMessage("Başarısız");
        //                                /*
        //                                asenkronCalis = false;
        //                                if (TTObjectClasses.SystemParameter.GetParameterValue("WORKASASYNCINMEDULAERROR", "TRUE") == "TRUE")
        //                                {
        //                                    if (response != null && !string.IsNullOrEmpty(response.sonucMesaji))
        //                                        uKey = ShowBox.Show(ShowBoxTypeEnum.Message, "Evet,Hayır", "E,H", "Uyarı", "Medula Provizyon", "Provizyon Alınamadı.\r\nHata Mesajı : " + response.sonucKodu + " " + response.sonucMesaji + "\r\nProvizyon almadan devam etmek ister misiniz?", 1);
        //                                    else
        //                                        uKey = ShowBox.Show(ShowBoxTypeEnum.Message, "Evet,Hayır", "E,H", "Uyarı", "Medula Provizyon", "Provizyon Alınamadı.Provizyon almadan devam etmek ister misiniz?", 1);
        //                                    if (uKey == "E")
        //                                        asenkronCalis = true;
        //                                    else
        //                                        asenkronCalis = false;
        //                                }
        //                                else
        //                                    asenkronCalis = false;
        //                                if (asenkronCalis)
        //                                {
        //                                    HastaKabulASync(provizyonGirisDVO);
        //                                    SetTakipAlAreaTextMessage("Provizyon alınması bekleniyor.");
        //                                    if (response != null && !string.IsNullOrEmpty(response.sonucMesaji))
        //                                    {
        //                                        SetTakipAlHataMesajiAreaTextMessage(response, "");
        //                                        InfoBox.Alert("Medula'dan '" + response.sonucKodu + " " + response.sonucMesaji + "' hatası dönmüştür. Provizyon alımı daha sonra otomatik olarak tekrar denenecektir. İşlemlerinize devam edebilirsiniz.");
        //                                    }
        //                                    else
        //                                        InfoBox.Alert("Provizyon alımı daha sonra otomatik olarak tekrar denenecektir. İşlemlerinize devam edebilirsiniz.");
        //                                }
        //                                else
        //                                {
        //                                    SetTakipAlAreaTextMessage("Başarısız");
        //                                    SetTakipAlHataMesajiAreaTextMessage(response, "Medula sisteminden yanıt alınamıyor!");
        //                                    throw new Exception(response.sonucKodu + " " + response.sonucMesaji);

        //                                }*/
        //                            }
        //                            else
        //                            {
        //                                SetTakipAlAreaTextMessage("Başarısız");
        //                                SetTakipAlHataMesajiAreaTextMessage(response, "");
        //                                throw new Exception(response.sonucKodu + " " + response.sonucMesaji);
        //                            }
        //                        }
        //                    }
        //                    else if (string.IsNullOrEmpty(response.sonucKodu) && !string.IsNullOrEmpty(response.sonucMesaji))
        //                    {
        //                        if (response.sonucMesaji == "SPAS Müstehaklık Servisi ile bağlantı sağlanamadı." ||
        //                            response.sonucMesaji == "SPAS Servisi ile bağlantı sağlanamadı." ||
        //                            response.sonucMesaji == "SPAS hata : 0503 : Veri Kaynağı hatası!" ||
        //                            response.sonucMesaji == "SPAS hata : 0001 : İşlem başarısız." ||
        //                            response.sonucMesaji == "SPAS hata : 0500 : Sistem hatası.")
        //                        {
        //                            string asynchOnSPASSError = TTObjectClasses.SystemParameter.GetParameterValue("ASYNCHONSPASSERROR", "FALSE");
        //                            if (asynchOnSPASSError.ToUpper() == "TRUE")
        //                            {
        //                                MedulaSPASError medulaSPASError = new MedulaSPASError(this.ObjectContext);
        //                                medulaSPASError.PatientAdmission = this;
        //                                medulaSPASError.ErrorDate = Common.RecTime();
        //                                medulaSPASError.ErrorMessage = response.sonucMesaji;

        //                                HastaKabulASync(provizyonGirisDVO);
        //                                SetTakipAlAreaTextMessage("Provizyon alınması bekleniyor.");
        //                                //InfoBox.Alert("Meduladan SPAS hatası dönmüştür. Provizyon alımı daha sonra otomatik olarak tekrar denenecektir. İşlemlerinize devam edebilirsiniz.");
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        responseIsNull = true;
        //                        throw new Exception("Medula sisteminden yanıt alınamıyor!");
        //                    }
        //                }
        //                else
        //                {
        //                    responseIsNull = true;
        //                    throw new Exception("Medula sisteminden yanıt alınamıyor!");
        //                }
        //            }
        //            //Async Provizyon alma
        //            else if (TTObjectClasses.SystemParameter.GetParameterValue("MEDULATAKIPALMAMETODU", "") == "A")
        //            {
        //                HastaKabulASync(provizyonGirisDVO);
        //                SetTakipAlAreaTextMessage("Provizyon alınması bekleniyor.");
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            //TODO MUSTAFA-ATALAY
        //            //Orchestrator servisine ulaşamazsa ya da Medula dan dönen response null ise, Asenkron çalışsın mı diye soruyor. BB
        //            /* if (ex.InnerException is System.Net.Sockets.SocketException || responseIsNull == true)
        //            {
        //                if (TTObjectClasses.SystemParameter.GetParameterValue("MEDULATAKIPALMAMETODU", "") == "S")
        //                {
        //                    asenkronCalis = false;
        //                    if (TTObjectClasses.SystemParameter.GetParameterValue("WORKASASYNCINMEDULAERROR", "TRUE") == "TRUE")
        //                    {
        //                        uKey = ShowBox.Show(ShowBoxTypeEnum.Message, "Evet,Hayır", "E,H", "Uyarı", "Medula Provizyon", "Provizyon Alınamadı.\r\nHata Mesajı : " + ex.Message.ToString() + (ex.InnerException != null ? " " + ex.InnerException.Message : String.Empty) + "\r\nProvizyon almadan devam etmek ister misiniz?", 1);
        //                        if (uKey == "E")
        //                            asenkronCalis = true;
        //                        else
        //                            asenkronCalis = false;
        //                    }
        //                    else
        //                        asenkronCalis = false;
        //                    if (asenkronCalis)
        //                    {
        //                        HastaKabulASync(provizyonGirisDVO);
        //                        SetTakipAlAreaTextMessage("Provizyon alınması bekleniyor.");
        //                        InfoBox.Alert("Medula'dan '" + ex.Message.ToString() + (ex.InnerException != null ? " " + ex.InnerException.Message : String.Empty) + "' hatası dönmüştür. Provizyon alımı daha sonra otomatik olarak tekrar denenecektir. İşlemlerinize devam edebilirsiniz.");
        //                    }
        //                    else
        //                        throw ex;
        //                }
        //            }
        //            else*/
        //            // Medula.MedulaLog.AddException(string.Format("Takip Almaya Çalışırken Exception Oluştu Exception Message :{0} ", ex.Message), _medulaProvision.ObjectID.Value.ToString());
        //            throw ex;
        //        }
        //    }

        public HastaKabulIslemleri.yeniDoganBilgisiDVO GetYeniDoganBilgisiDVO(Patient patient)
        {

            HastaKabulIslemleri.yeniDoganBilgisiDVO yeniDoganBilgisiDVO = new HastaKabulIslemleri.yeniDoganBilgisiDVO();
            yeniDoganBilgisiDVO.dogumTarihi = (patient.BirthDate == null) ? null : patient.BirthDate.Value.ToShortDateString().ToString();
            yeniDoganBilgisiDVO.cocukSira = patient.BirthOrder.GetHashCode();
            return yeniDoganBilgisiDVO;
        }

        public bool GetYenidenTakipAl()
        {
            //todo bg
            /*
            TTObjectContext _context = new TTObjectContext(false);
            MedulaProvision medulaProvision = null;
            if (this.MedulaProvision != null)
                medulaProvision = (MedulaProvision)_context.GetObject(this.MedulaProvision.ObjectID, TTObjectDefManager.Instance.ObjectDefs[typeof(MedulaProvision).Name], false);

            bool retValue = false;

            if (medulaProvision != null)
            {
                System.Reflection.PropertyInfo[] propertyInfos;
                propertyInfos = typeof(MedulaProvision).GetProperties();
                foreach (System.Reflection.PropertyInfo propInfo in propertyInfos)
                {
                    if (propInfo.Name == "ProvizyonTipi" || propInfo.Name == "LicensePlateNo" || propInfo.Name == "ProvisionDate" || propInfo.Name == "GreenCardSendingFacilityCode" || propInfo.Name == "DonorUniqueRefno" || propInfo.Name == "TedaviTuru" || propInfo.Name == "TedaviTipi" || propInfo.Name == "TakipTipi" || propInfo.Name == "SigortaliTuru" || propInfo.Name == "DevredilenKurum" || propInfo.Name == "Brans")
                    {
                        object current = MedulaProvision.GetType().GetProperty(propInfo.Name).GetValue(MedulaProvision, null);
                        object last = medulaProvision.GetType().GetProperty(propInfo.Name).GetValue(medulaProvision, null);
                        if (Convert.ToString(current) != Convert.ToString(last))
                        {
                            retValue = true;
                            break;
                        }
                    }
                }
            }
            else
                retValue = true;*/

            return true;
        }

        /*
        public void CreateMedulaProvision()
        {
            //Randevulu hastalarda Reasonforadmission set edildiğinde problem oluyor MC
            if (this.Episode == null)
                return;

            if (this.MedulaProvision == null)
            {
                MedulaProvision _medulaProvision = new MedulaProvision(this.ObjectContext);
                this.SetMedulaProvisionInitalProperties(_medulaProvision);
                this.MedulaProvision = _medulaProvision;

                if (this.Donor == true)
                    this.MedulaProvision.DonorUniqueRefno = this.Patient.UniqueRefNo;
            }
        }
        */


        //
        //        public void GetPatientInformationFromProvizyonCevapDVO(HastaKabulIslemleri.provizyonCevapDVO result)
        //        {
        //            if(result.hastaBilgileri != null)
        //            {
        //                HastaKabulIslemleri.hastaBilgileriDVO _hastaBilgileriDVO = result.hastaBilgileri;
        //                if(_hastaBilgileriDVO.devredilenKurum != null)
        //                {
        //                    DevredilenKurum _devredilenKurum = DevredilenKurum.GetDevredilenKurum(_hastaBilgileriDVO.devredilenKurum);
        //                    this.MedulaProvision.DevredilenKurum = (_devredilenKurum != null) ? _devredilenKurum : this.MedulaProvision.DevredilenKurum;
        //                }
        //                if(_hastaBilgileriDVO.sigortaliTuru != null)
        //                {
        //                    SigortaliTuru _sigortaliTuru = SigortaliTuru.GetSigortaliTuru(_hastaBilgileriDVO.sigortaliTuru);
        //                    this.MedulaProvision.SigortaliTuru = (_sigortaliTuru != null)? _sigortaliTuru : this.MedulaProvision.SigortaliTuru;
        //                }
        //            }
        //        }



        //YUPASS
        public int? YurtDisiYardimHakkiSorgula(string provizyonTarihi)
        {
            try
            {
                MedulaYardimciIslemler.yurtDisiYardimHakkiGetirGirisDVO yurtDisiYardimHakkiGetirGirisDVO = new MedulaYardimciIslemler.yurtDisiYardimHakkiGetirGirisDVO();
                yurtDisiYardimHakkiGetirGirisDVO.kisiNo = Episode.Patient.YUPASSNO.ToString();
                yurtDisiYardimHakkiGetirGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                yurtDisiYardimHakkiGetirGirisDVO.provizyonTarihi = provizyonTarihi;
                bool haveFullProvision = false;
                List<MedulaYardimciIslemler.yurtDisiYardimHakkiGetirCevapDetayDVO> partialProvision = new List<MedulaYardimciIslemler.yurtDisiYardimHakkiGetirCevapDetayDVO>();
                int? retValue = null;
                if (TTObjectClasses.SystemParameter.GetParameterValue("MEDULATAKIPALMAMETODU", "") == "S")
                {
                    MedulaYardimciIslemler.yurtDisiYardimHakkiGetirCevapDVO response = MedulaYardimciIslemler.WebMethods.yurtDisiYardimHakkiGetirSync(TTObjectClasses.Sites.SiteLocalHost, yurtDisiYardimHakkiGetirGirisDVO);
                    if (response.sonucKodu == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27263", "YUPASS Hatası. Medula'dan cevap alınamıyor!"));
                    else if (response.sonucKodu == "0000")
                    {
                        foreach (MedulaYardimciIslemler.yurtDisiYardimHakkiGetirCevapDetayDVO detayDVO in response.yurtDisiDetay)
                        {
                            if (detayDVO.tedaviKapsami == "T")
                            {
                                retValue = detayDVO.id;
                                haveFullProvision = true;
                                break;
                            }
                            else if (detayDVO.tedaviKapsami == "K")
                                partialProvision.Add(detayDVO);
                        }
                        /*if (!haveFullProvision)
                        {
                            MultiSelectForm msItem = new MultiSelectForm();
                            foreach (MedulaYardimciIslemler.yurtDisiYardimHakkiGetirCevapDetayDVO cevapDetay in partialProvision)
                            {
                                msItem.AddMSItem(cevapDetay.aciklama, cevapDetay.id.ToString(), cevapDetay);
                            }
                            string key = msItem.GetMSItem(null, "Hastanın tam kapsamlı provizyonu yok. Kısmı kapsamlardan birini seçiniz.", true, false, false, false, true, false);
                            if (!string.IsNullOrEmpty(key))
                                retValue = Convert.ToInt32(key);
                            else
                                throw new TTUtils.TTException("İşlemden vazgeçildi!");
                        }
                        else*/
                        return retValue;
                    }
                    else
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27262", "YUPASS hatası \r\n") + response.sonucMesaji);
                }
                //Webmetodu yok. Şimdilik es geçelim MC
                //else if (TTObjectClasses.SystemParameter.GetParameterValue("MEDULATAKIPALMAMETODU", "") == "A")
                //{
                //MedulaYardimciIslemler.yurtDisiYardimHakkiGetirCevapDVO response = MedulaYardimciIslemler.WebMethods.yurtDisiYardimHakkiGetirSync
                //}
                return null;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Hasta kabulde çağrı sisteminin tabının doldurulması için.
        public void SetPCSObjects()
        {
            /*if (this.PA_PCSGridObjects != null && this.PA_PCSGridObjects.Count > 0)
                return;

            IBindingList queuePriorityDefs = this.ObjectContext.QueryObjects(typeof(QueuePriorityDefinition).Name);
            foreach (QueuePriorityDefinition qpd in queuePriorityDefs)
            {
                PA_PCSGridObject gridObj = new PA_PCSGridObject(this.ObjectContext);
                gridObj.PatientAdmission = this;
                gridObj.Checked = false;
                gridObj.QueuePriorityDefinition = qpd;
                gridObj.PriorityText = qpd.PriorityName;
            }

            Array enumValues = Enum.GetValues(typeof(QueuePrioritySystemEnum));

            foreach (QueuePrioritySystemEnum queuePrioritySystemEnum in enumValues)
            {
                PA_PCSGridObject gridObj = new PA_PCSGridObject(this.ObjectContext);
                gridObj.PatientAdmission = this;

                if (queuePrioritySystemEnum == QueuePrioritySystemEnum.Above65)
                {
                    if (this.Patient.BirthDate!= null && (((Common.RecTime().Date - (DateTime)this.Patient.BirthDate).Days / 365) >= 65))
                        gridObj.Checked = true;
                    else
                        gridObj.Checked = false;
                }
                else if (queuePrioritySystemEnum == QueuePrioritySystemEnum.Below7)
                {
                    if (this.Patient.BirthDate!= null && (((Common.RecTime().Date - (DateTime)this.Patient.BirthDate).Days / 365) < 8))
                        gridObj.Checked = true;
                    else
                        gridObj.Checked = false;
                }
                else if (queuePrioritySystemEnum == QueuePrioritySystemEnum.Disabled)
                {
                    if (this.RealDisabled != null && (bool)this.RealDisabled)
                        gridObj.Checked = true;
                }
                else if (queuePrioritySystemEnum == QueuePrioritySystemEnum.Veteran)
                {
                    //                    if ((this.DisabledWarVetera != null && (bool)this.DisabledWarVetera) ||
                    //                        (this.WarVetera != null && (bool)this.WarVetera))
                    gridObj.Checked = true;
                }
                else
                    gridObj.Checked = false;

                gridObj.QueuePriorityDefinition = null;
                gridObj.QueuePrioritySystem = queuePrioritySystemEnum;
                gridObj.PriorityText = (Common.GetEnumValueDefOfEnumValue((Enum)queuePrioritySystemEnum)).DisplayText;
            }*/
        }


        public static Episode ReturnEpisodeWithSameSpecialityInTenDays(PatientAdmission patientAdmission, Patient patient)
        {
            if (patientAdmission.Department != null && patientAdmission.Department.Brans != null && patientAdmission.Department.Brans.Code != null
                && (patientAdmission.AdmissionStatus == AdmissionStatusEnum.Normal || patientAdmission.AdmissionStatus == AdmissionStatusEnum.DisKabulu))
            {
                TTObjectContext roContext = new TTObjectContext(true);
                int limit = 9;//Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("SGKSPECIALITYCONTROLDAYLIMIT", "10"));
                              /*  if (patientAdmission.AdmissionStatus == AdmissionStatusEnum.DisKabulu)
                                    limit = 6;*/
                DateTime dateLimit = Convert.ToDateTime(Common.RecTime()).AddDays(-1 * (limit)).Date;
                List<System.Guid> specialityList = new List<System.Guid>();

                if (Common.IsDental(patientAdmission.Department.Brans.Code))
                {
                    String[] disBransKodlari = { "5100", "5200", "5300", "5400", "5500", "5600", "5700" };
                    for (int i = 0; i < disBransKodlari.Length; i++)
                    {
                        System.ComponentModel.BindingList<SpecialityDefinition> specialityDefList = SpecialityDefinition.GetSpecialityByCode(roContext, disBransKodlari[i]);
                        foreach (SpecialityDefinition speciality in specialityDefList)
                        {
                            specialityList.Add(speciality.ObjectID);
                        }
                    }
                }
                else
                {
                    System.ComponentModel.BindingList<SpecialityDefinition> specialityDefList = SpecialityDefinition.GetSpecialityByCode(roContext, patientAdmission.Department.Brans.Code);
                    foreach (SpecialityDefinition speciality in specialityDefList)
                    {
                        specialityList.Add(speciality.ObjectID);
                    }
                }

                System.ComponentModel.BindingList<Episode> oldEpisodes = Episode.GetByDayLimitAndMainSpeciality(roContext, dateLimit.Date, specialityList.ToArray(), patient.ObjectID.ToString(), Convert.ToDateTime(patientAdmission.ActionDate).Date);
                if (oldEpisodes != null && oldEpisodes.Count > 0)
                {
                    foreach (Episode tempEpisode in oldEpisodes)
                    {
                        if (patientAdmission.Episode == null || (patientAdmission.Episode != null && patientAdmission.Episode.ObjectID != tempEpisode.ObjectID))
                        {
                            //if (tempEpisode.PatientStatus != PatientStatusEnum.Inpatient)
                            //{
                            foreach (var subEpisode in tempEpisode.SubEpisodes.Where(x => x.CurrentStateDefID != SubEpisode.States.Cancelled))
                            {
                                if (subEpisode.StarterEpisodeAction is PatientExamination && ((PatientExamination)(subEpisode.StarterEpisodeAction)).PatientExaminationType == PatientExaminationEnum.Normal
                                   || subEpisode.StarterEpisodeAction is DentalExamination && ((DentalExamination)(subEpisode.StarterEpisodeAction)).DentalExaminationType == PatientExaminationEnum.Dental)
                                {
                                    if (subEpisode.OpeningDate >= dateLimit.Date) // Yukardaki NQL üzerinden 10 gün içinde kontrol muayenesi varsa da geliyor oysa yanlızca ilk muayeneden 10 gün sonrasına kadar kontrol başlatılır
                                    {
                                        if (patientAdmission.Payer == null)
                                            throw new TTException(TTUtils.CultureService.GetText("M26367", "Kurum seçiniz."));

                                        if (patientAdmission.Payer.ObjectID == subEpisode.PatientAdmission.Payer.ObjectID) // Aynı kurum ise
                                            return tempEpisode;

                                        if (patientAdmission.Payer.IsSGK && subEpisode.PatientAdmission.Payer.IsSGK)       // ikisi de SGK tipinde kurum ise
                                            return tempEpisode;
                                    }
                                }
                            }
                            //}
                        }
                    }
                }
                //System.ComponentModel.BindingList<SubEpisode> oldSubEpisodes = SubEpisode.GetByDayLimitAndSpeciality(roContext, dateLimit.Date, specialityList.ToArray(), patient.ObjectID.ToString(), Convert.ToDateTime(patientAdmission.ActionDate).Date);
                //if (oldSubEpisodes != null && oldSubEpisodes.Count > 0)
                //{
                //    foreach (SubEpisode subEpisode in oldSubEpisodes)
                //    {
                //        if (subEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.Normal || subEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.DisKabulu)
                //        {
                //            if (patientAdmission.Payer == null)
                //                throw new TTException(TTUtils.CultureService.GetText("M26367", "Kurum seçiniz."));

                //            if (patientAdmission.Payer.ObjectID == subEpisode.PatientAdmission.Payer.ObjectID) // Aynı kurum ise
                //                return roContext.GetObject(subEpisode.Episode.ObjectID, typeof(Episode)) as Episode;

                //            if (patientAdmission.Payer.IsSGK && subEpisode.PatientAdmission.Payer.IsSGK)       // ikisi de SGK tipinde kurum ise
                //                return roContext.GetObject(subEpisode.Episode.ObjectID, typeof(Episode)) as Episode;
                //        }
                //    }
                //}

            }
            return null;
        }




        //public void SetSaglikNetProtokolInitalProperties(SaglikNetProtokol _saglikNetProtokol)
        //{

        //    if (_saglikNetProtokol != null)
        //    {
        //        _saglikNetProtokol.CurrentStateDefID = SaglikNetProtokol.States.New;
        //        _saglikNetProtokol.Episode = this.Episode;
        //     //   _saglikNetProtokol.Status = MedulaSubEpisodeStatusEnum.ProvisionNoNotExists;
        //        _saglikNetProtokol.islemTarihi = Common.RecTime();
        //       // _saglikNetProtokol.GetAndSetNextOrderNo();
        //    }
        //}

        //public ProtokolIslemleri.protokol GetProtokol()
        //{
        //    ProtokolIslemleri.protokol protokol = new ProtokolIslemleri.protokol();

        //    // Sağlık Tesis Kodu (Zorunlu)
        //    protokol.kurumKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu().ToString();
        //    BindingList<SKRSCodeDefinition> sKRSCodeDefinition;

        //    //HastaTCKimlikNo  (Zorunlu*)
        //    //Hasta YeniDoğan değil ise Hastanın Kendi TC'si gönderilir.
        //    if(this.Patient != null)
        //    {
        //        Guid hastaTipiSistemKodu;
        //        hastaTipiSistemKodu = new Guid("4f4fd85e-6f52-4c38-a302-6d5e3d6dc1c4");   //hastatipi sistem kodu

        //        Guid protokolTipiSistemKodu;
        //        protokolTipiSistemKodu = new Guid("225213ef-6aed-49ee-a6fe-0f18172fbf0e");   //hastatipi sistem kodu

        //        //Genel
        //        sKRSCodeDefinition = SKRSCodeDefinitions(hastaTipiSistemKodu, 1);
        //        this.SaglikNetProtokol.HastaTipi = sKRSCodeDefinition.Count > 0 ? sKRSCodeDefinition[0] : null;
        //        // protokol.hastaTipi = sKRSCodeDefinition.Count > 0 ? (sKRSCodeDefinition[0].Code != null ? Convert.ToInt32(sKRSCodeDefinition[0].Code) : 0) : 0;

        //        if (this.Patient.IsNewBorn != null && this.Patient.IsNewBorn.Equals(false))
        //        {
        //            if (this.PatientGroup == TTObjectClasses.PatientGroupEnum.Donor)
        //                protokol.vatandasTCK = (((PA_Donor)this).DonorPatient.UniqueRefNo == null) ? null : (((PA_Donor)this).DonorPatient.UniqueRefNo.ToString());
        //            else
        //                protokol.vatandasTCK = (this.Patient.UniqueRefNo == null) ? null : (this.Patient.UniqueRefNo.ToString());
        //        }
        //        if (this.Patient.IsNewBorn != null && this.Patient.IsNewBorn.Equals(true))
        //        {
        //            //Hasta YeniDoğan ise HastaTcKimlikNo alanına AnneTCKimlikNo alanı gönderilir.
        //            if (this.Patient.Mother != null && this.Patient.Mother.UniqueRefNo != null)
        //                protokol.vatandasTCK = this.Patient.Mother.UniqueRefNo.ToString();
        //            else
        //                throw new Exception("Provizyon alınacak yenidoğan hastasının anne TC Kimlik numarası dolu olmalıdır!");

        //            //Yeni Doğan
        //            sKRSCodeDefinition = SKRSCodeDefinitions(hastaTipiSistemKodu, 4);
        //            this.SaglikNetProtokol.HastaTipi = sKRSCodeDefinition.Count > 0 ? sKRSCodeDefinition[0] : null;
        //            //protokol.hastaTipi = sKRSCodeDefinition.Count > 0 ? (sKRSCodeDefinition[0].Code != null ? Convert.ToInt32(sKRSCodeDefinition[0].Code) : 0) : 0;

        //        }
        //        if (this.Patient != null && this.Patient.Foreign != null && this.Patient.Foreign.Equals(true))
        //        {
        //            //protokol.vatandasTCK = (this.Patient.ForeignUniqueRefNo == null) ? null : (this.Patient.ForeignUniqueRefNo.ToString());
        //            //Yabancı
        //            sKRSCodeDefinition = SKRSCodeDefinitions(hastaTipiSistemKodu, 2);
        //            this.SaglikNetProtokol.HastaTipi = sKRSCodeDefinition.Count > 0 ? sKRSCodeDefinition[0] : null;
        //            //protokol.hastaTipi = sKRSCodeDefinition.Count > 0 ? (sKRSCodeDefinition[0].Code != null ? Convert.ToInt32(sKRSCodeDefinition[0].Code) : 0) : 0;

        //        }
        //        if (this.Patient.SecurePerson != null && this.Patient.SecurePerson.Equals(true))
        //        {
        //            //Gizli
        //            sKRSCodeDefinition = SKRSCodeDefinitions(hastaTipiSistemKodu, 5);
        //            this.SaglikNetProtokol.HastaTipi = sKRSCodeDefinition.Count > 0 ? sKRSCodeDefinition[0] : null;
        //            // protokol.hastaTipi = _saglikNetProtokol.HastaTipi != null ? (_saglikNetProtokol.HastaTipi.Code != null ? Convert.ToInt32(sKRSCodeDefinition[0].Code) : 0) : 0;

        //        }

        //        protokol.hastaTipi = this.SaglikNetProtokol.HastaTipi != null ? (this.SaglikNetProtokol.HastaTipi.Code != null ? Convert.ToInt32(this.SaglikNetProtokol.HastaTipi.Code) : 0) : 0;



        //        this.SaglikNetProtokol.ProtokolTipi = sKRSCodeDefinition.Count > 0 ? sKRSCodeDefinition[0] : null;
        //        protokol.protokolTipi = this.SaglikNetProtokol.ProtokolTipi != null ? (this.SaglikNetProtokol.ProtokolTipi.Code != null ? Convert.ToInt32(this.SaglikNetProtokol.ProtokolTipi.Code) : 0) : 0;

        //        this.SaglikNetProtokol.MHRS = "0"; //MHRS kullanmıyoruz o yüzden 0
        //        protokol.MHRS = this.SaglikNetProtokol.MHRS;

        //        protokol.islemTarihi = this.ActionDate != null ? this.ActionDate.ToString() : null;

        //        protokol.otomasyonKayitId = this.Episode.HospitalProtocolNo.ToString();

        //        if(this.FiredEpisodeActions.Count > 0)
        //        {
        //            protokol.hekimTCK = this.FiredEpisodeActions[this.FiredEpisodeActions.Count - 1].ProcedureDoctor != null ? this.FiredEpisodeActions[this.FiredEpisodeActions.Count - 1].ProcedureDoctor.UniqueNo : null;

        //        }

        //        this.SaglikNetProtokol.KlinikKodu = this.FiredEpisodeActions[this.FiredEpisodeActions.Count - 1].MasterResource != null ? this.FiredEpisodeActions[this.FiredEpisodeActions.Count - 1].MasterResource.SaglikNetKlinikleri : null;
        //    }
        //    protokol.klinikKodu = this.SaglikNetProtokol.KlinikKodu != null ? (this.SaglikNetProtokol.KlinikKodu.Code != null ? Convert.ToInt32(this.SaglikNetProtokol.KlinikKodu.Code) : 0) : 0;

        //    return protokol;
        //}
        public BindingList<SKRSCodeDefinition> SKRSCodeDefinitions(Guid systemCode, int code)
        {
            BindingList<SKRSCodeDefinition> sKRSCodeDefinitionList = SKRSCodeDefinition.GetSKRSDefinitions(ObjectContext, systemCode, code);
            return sKRSCodeDefinitionList;
        }

        public static Episode ReturnEpisodeWithSameSpecialityInSameDay(PatientAdmission patientAdmission, Patient patient)
        {

            if (patientAdmission.Department != null && patientAdmission.Department.Brans != null && patientAdmission.Department.Brans.Code != null
                && (patientAdmission.AdmissionStatus == AdmissionStatusEnum.Normal || patientAdmission.AdmissionStatus == AdmissionStatusEnum.DisKabulu || patientAdmission.AdmissionStatus == AdmissionStatusEnum.Kontrol
                || (patientAdmission.AdmissionStatus == AdmissionStatusEnum.Acil && patient.Death != true)))
            {
                TTObjectContext roContext = new TTObjectContext(true);
                // int limit = 1;//Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("SGKSPECIALITYCONTROLDAYLIMIT", "10"));
                DateTime dateLimit = Common.RecTime().Date;
                List<System.Guid> specialityList = new List<System.Guid>();

                if (Common.IsDental(patientAdmission.Department.Brans.Code))
                {
                    String[] disBransKodlari = { "5100", "5200", "5300", "5400", "5500", "5600", "5700" };
                    for (int i = 0; i < disBransKodlari.Length; i++)
                    {
                        System.ComponentModel.BindingList<SpecialityDefinition> specialityDefList = SpecialityDefinition.GetSpecialityByCode(roContext, disBransKodlari[i]);
                        foreach (SpecialityDefinition speciality in specialityDefList)
                        {
                            specialityList.Add(speciality.ObjectID);
                        }
                    }
                }
                else
                {
                    System.ComponentModel.BindingList<SpecialityDefinition> specialityDefList = SpecialityDefinition.GetSpecialityByCode(roContext, patientAdmission.Department.Brans.Code);
                    foreach (SpecialityDefinition speciality in specialityDefList)
                    {
                        specialityList.Add(speciality.ObjectID);
                    }
                }

                System.ComponentModel.BindingList<Episode> oldEpisodes = Episode.GetSameByDayLimitAndMainSpeciality(roContext, dateLimit, specialityList.ToArray(), patient.ObjectID.ToString());
                if (oldEpisodes != null && oldEpisodes.Count > 0)
                {
                    foreach (Episode tempEpisode in oldEpisodes)
                    {
                        if (patientAdmission.Episode == null || (patientAdmission.Episode != null && patientAdmission.Episode.ObjectID != tempEpisode.ObjectID) || patientAdmission.AdmissionStatus == AdmissionStatusEnum.Kontrol)
                        {
                            //if (tempEpisode.PatientStatus == PatientStatusEnum.Outpatient)
                            //{
                            foreach (var subEpisode in tempEpisode.SubEpisodes.Where(x => x.CurrentStateDefID != SubEpisode.States.Cancelled))
                            {
                                if (tempEpisode.PatientStatus == PatientStatusEnum.Outpatient && subEpisode.PatientAdmission.Department != null && subEpisode.PatientAdmission.Department.Brans != null && subEpisode.PatientAdmission.Department.Brans.Code != "4400" && patientAdmission.Department.Brans.Code != "4400")//herm VT'den gelen hem yeni alınan Acil değil ise
                                {
                                    if (subEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.Normal || subEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.DisKabulu || subEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.Kontrol)
                                    {
                                        if (patientAdmission.Payer == null)
                                            throw new TTException(TTUtils.CultureService.GetText("M26367", "Kurum seçiniz."));

                                        if (patientAdmission.Payer.ObjectID == subEpisode.PatientAdmission.Payer.ObjectID) // Aynı kurum ise
                                            return tempEpisode;

                                        if (patientAdmission.Payer.IsSGK && subEpisode.PatientAdmission.Payer.IsSGK)       // İkisi de SGK tipinde kurum ise
                                            return tempEpisode;
                                    }
                                }
                                else if (subEpisode.PatientAdmission.Department != null && subEpisode.PatientAdmission.Department.Brans != null && subEpisode.PatientAdmission.Department.Brans.Code == "4400" && patientAdmission.Department.Brans.Code == "4400")// ikisi de acil ise
                                {
                                    if (((ITTObject)patientAdmission).IsNew && subEpisode.PatientAdmission.AdmissionType.provizyonTipiKodu == patientAdmission.AdmissionType.provizyonTipiKodu)//geliş sebebi aynı ise
                                    {
                                        throw new Exception("Gün içerisinde hastanın aynı geliş sebebi ile " + subEpisode.ProtocolNo + " numaralı Acil Kabulü mevcuttur.Lütfen yardımcı menüler altından Acil kabul birleştirme yapınız.");
                                    }

                                }
                            }
                            //}
                        }
                    }
                }
            }

            return null;
        }

        public bool IsIgnoredTenDaysRule(ProvizyonTipi admissionType)
        {
            if (!(String.IsNullOrEmpty(admissionType.ToString())))
            {
                string param = Convert.ToString(TTObjectClasses.SystemParameter.GetParameterValue("IGNORETENDAYSRULE", ""));
                if (!(String.IsNullOrEmpty(param)))
                {
                    string[] values = param.Split(',');
                    foreach (string ID in values)
                    {
                        if (admissionType.Equals(ID))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            return false;

        }

        public bool RequiresFinancialDepControl(ProvizyonTipi admissionType)
        {
            if (!(String.IsNullOrEmpty(admissionType.ToString())))
            {
                string param = Convert.ToString(TTObjectClasses.SystemParameter.GetParameterValue("REQUIRESFINANCIALDEPCONTROL", ""));
                if (!(String.IsNullOrEmpty(param)))
                {
                    string[] values = param.Split(',');
                    foreach (string ID in values)
                    {
                        if (admissionType.Equals(ID))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            return false;
        }

        public static MostSuitableDoctorInfo GetMostSuitableDoctor(PatientAdmission pa, int type)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                MostSuitableDoctorInfo mostSuitableDoctor = new MostSuitableDoctorInfo();
                mostSuitableDoctor.MostsuitableDoctorSet = false;
                List<Guid> poList = new List<Guid>();

                if (type == 1)
                    poList = pa.Department.Policlinics.Select(x => x.ObjectID).ToList();
                else if (type == 2)//Poliklinik zaten seçili geliyor Aciller için
                    poList.Add(pa.Policlinic.ObjectID);

                string _whereClause = " AND AutomaticReception=1";

                List<DoctorQuotaDefinition> quotaList = DoctorQuotaDefinition.GetDoctorQuotaByPoliclinicList(objectContext, poList, _whereClause).ToList();

                if (type == 1)
                {
                    List<ExaminationQueueItem.GetActiveQueueItemByPolID_Class> _queList = ExaminationQueueItem.GetActiveQueueItemByPolID(objectContext, poList, DateTime.Now.Date, DateTime.Now.AddDays(1).Date).ToList();

                    if (quotaList.Count > 0)
                    {
                        //kota listesinde otomatik kabul alınır işaretlenip daha queueitem oluşmamış doktorlar ve birimler için ilk o birim ve doktora atar.
                        foreach (DoctorQuotaDefinition item in quotaList)
                        {
                            ExaminationQueueItem.GetActiveQueueItemByPolID_Class isExist = _queList.Where(x => x.Doctor == item.ProcedureDoctor.ObjectID && x.ResSection.Value == item.Policlinic.ObjectID).FirstOrDefault();

                            if (isExist == null && !Common.PersonelIzinKontrol(item.ProcedureDoctor.ObjectID.ToString(), pa.ActionDate.Value, objectContext))
                            {
                                mostSuitableDoctor.ProcedureDoctor = item.ProcedureDoctor;
                                mostSuitableDoctor.Policlinic = item.Policlinic;
                                mostSuitableDoctor.MostsuitableDoctorSet = true;
                                break;
                            }
                        }

                        // otomatik kabul alınır işaretlenen doktor ve birimlerden hiç kuyruk oluşmamış kayıt kalmadı ise
                        if (!mostSuitableDoctor.MostsuitableDoctorSet)
                        {
                            foreach (ExaminationQueueItem.GetActiveQueueItemByPolID_Class pol in _queList)
                            {

                                if (!Common.PersonelIzinKontrol(pol.Doctor.ToString(), pa.ActionDate.Value, objectContext))//kabul tarihinde izinli değil ise
                                {
                                    ResUser ru = (ResUser)pa.ObjectContext.GetObject(pol.Doctor.Value, "RESUSER");
                                    if (ru.DoctorQuota != null && ru.DoctorQuota.AutomaticReception.HasValue && ru.DoctorQuota.AutomaticReception.Value)//otomatik kabul al işaretli ise
                                    {
                                        mostSuitableDoctor.ProcedureDoctor = ru;
                                        mostSuitableDoctor.Policlinic = (ResPoliclinic)pa.ObjectContext.GetObject(pol.ResSection.Value, "RESPOLICLINIC");
                                        mostSuitableDoctor.MostsuitableDoctorSet = true;
                                        break;
                                    }
                                }

                            }
                        }
                    }
                }
                else if (type == 2)
                {
                    int timeLimit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("ACILPOLIKLINIKDOKTORSURESI", "12"));

                    List<PatientExamination.GetExaminationsQueCount_Class> _queList = PatientExamination.GetExaminationsQueCount(objectContext, poList, DateTime.Now.AddHours((timeLimit * (-1))), DateTime.Now).ToList();

                    if (quotaList.Count > 0)
                    {
                        //kota listesinde otomatik kabul alınır işaretlenip daha queueitem oluşmamış doktorlar ve birimler için ilk o birim ve doktora atar.
                        foreach (DoctorQuotaDefinition item in quotaList)
                        {
                            PatientExamination.GetExaminationsQueCount_Class isExist = _queList.Where(x => x.ProcedureDoctor.Value == item.ProcedureDoctor.ObjectID && x.MasterResource.Value == item.Policlinic.ObjectID).FirstOrDefault();

                            if (isExist == null && !Common.PersonelIzinKontrol(item.ProcedureDoctor.ObjectID.ToString(), pa.ActionDate.Value, objectContext))
                            {
                                mostSuitableDoctor.ProcedureDoctor = item.ProcedureDoctor;
                                mostSuitableDoctor.Policlinic = item.Policlinic;
                                mostSuitableDoctor.MostsuitableDoctorSet = true;
                                break;
                            }
                        }

                        // otomatik kabul alınır işaretlenen doktor ve birimlerden hiç kuyruk oluşmamış kayıt kalmadı ise
                        if (!mostSuitableDoctor.MostsuitableDoctorSet)
                        {
                            foreach (PatientExamination.GetExaminationsQueCount_Class pol in _queList)
                            {

                                if (!Common.PersonelIzinKontrol(pol.ProcedureDoctor.ToString(), pa.ActionDate.Value, objectContext))//kabul tarihinde izinli değil ise
                                {
                                    ResUser ru = (ResUser)pa.ObjectContext.GetObject(pol.ProcedureDoctor.Value, "RESUSER");
                                    if (ru.DoctorQuota != null && ru.DoctorQuota.AutomaticReception.HasValue && ru.DoctorQuota.AutomaticReception.Value)//otomatik kabul al işaretli ise
                                    {
                                        mostSuitableDoctor.ProcedureDoctor = ru;
                                        mostSuitableDoctor.Policlinic = (ResPoliclinic)pa.ObjectContext.GetObject(pol.MasterResource.Value, "RESPOLICLINIC");
                                        mostSuitableDoctor.MostsuitableDoctorSet = true;
                                        break;
                                    }
                                }

                            }
                        }
                    }

                }
                return mostSuitableDoctor;
            }

        }
        public static void SetEmptyResources(PatientAdmission pa)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                MostSuitableDoctorInfo mostSuitableDoctor = new MostSuitableDoctorInfo();
                mostSuitableDoctor.MostsuitableDoctorSet = false;

                if (pa.Department != null && pa.ProcedureDoctor == null && pa.Policlinic == null)//havuz kaydı
                {
                    //o branşa ait birimler arasında en az sıra olan kuyruktaki birim ve doktoru seçer.
                    if (Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("GETMOSTSUITABLEDOCTOR", "FALSE")) && pa.Department.IsEmergencyDepartment != true)
                    {
                        mostSuitableDoctor = GetMostSuitableDoctor(pa, 1);
                    }

                    if (mostSuitableDoctor.MostsuitableDoctorSet)
                    {
                        pa.ProcedureDoctor = mostSuitableDoctor.ProcedureDoctor;
                        pa.Policlinic = mostSuitableDoctor.Policlinic;
                    }
                    else  //En uygun birim ve doktora seçim yapmadıysa
                    {
                        foreach (ResPoliclinic pol in pa.Department.Policlinics)
                        {
                            if (pol.ResourceUsers.Count > 0)
                            {
                                foreach (UserResource ur in pol.ResourceUsers.OrderBy(t => t.User.Name))
                                {
                                    if (ur.User.UserType == UserTypeEnum.Doctor || ur.User.UserType == UserTypeEnum.Dentist)
                                    {
                                        if (ur.User != null && ur.User.IsActive.HasValue && ur.User.IsActive.Value && !Common.PersonelIzinKontrol(ur.User.ObjectID.ToString(), pa.ActionDate.Value, objectContext))//kabul tarihinde izinli değil ise
                                        {
                                            pa.ProcedureDoctor = ur.User;
                                            pa.Policlinic = pol;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (pa.Department != null && pa.ProcedureDoctor != null && pa.Policlinic == null)//havuz kaydı
                {
                    foreach (var UserResource in pa.ProcedureDoctor.UserResources)
                    {
                        if (UserResource.Resource is ResPoliclinic)
                        {
                            if (UserResource.Resource.Brans.Code == pa.Department.Brans.Code)
                            {
                                pa.Policlinic = (ResPoliclinic)UserResource.Resource;
                                break;
                            }
                        }
                    }
                }

                else if (pa.Department == null && pa.ProcedureDoctor != null && pa.Policlinic == null)//doktor seçili
                {
                    foreach (var UserResource in pa.ProcedureDoctor.UserResources)
                    {
                        if (UserResource.Resource is ResPoliclinic)
                        {
                            pa.Policlinic = (ResPoliclinic)UserResource.Resource;
                            pa.Department = pa.Policlinic.Department;
                            break;
                        }
                    }
                }
                else if (pa.Department != null && pa.ProcedureDoctor == null && pa.Policlinic != null)//sadece doktor seçili değil
                {
                    //o branşa ait birimler arasında en az sıra olan kuyruktaki birim ve doktoru seçer.
                    if (Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("GETMOSTSUITABLEDOCTOR", "FALSE")) && pa.Department.IsEmergencyDepartment == true)
                    {
                        mostSuitableDoctor = GetMostSuitableDoctor(pa, 2);
                    }

                    if (mostSuitableDoctor.MostsuitableDoctorSet)
                    {
                        pa.ProcedureDoctor = mostSuitableDoctor.ProcedureDoctor;
                    }
                    else  //En uygun birim ve doktora seçim yapmadıysa
                    {
                        foreach (UserResource ur in pa.Policlinic.ResourceUsers.OrderBy(t => t.User.Name))
                        {
                            if ((ur.User.UserType == UserTypeEnum.Doctor || ur.User.UserType == UserTypeEnum.Dentist) && ur.User.IsActive.HasValue && ur.User.IsActive.Value && !Common.PersonelIzinKontrol(ur.User.ObjectID.ToString(), pa.ActionDate.Value, objectContext))
                            {
                                if (ur.User != null)
                                {
                                    pa.ProcedureDoctor = ur.User;
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (pa.Policlinic != null && pa.Department == null)//sadece poliklinik seçili
                {
                    pa.Department = pa.Policlinic.Department;
                    //o branşa ait birimler arasında en az sıra olan kuyruktaki birim ve doktoru seçer.
                    if (Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("GETMOSTSUITABLEDOCTOR", "FALSE")) && pa.Department.IsEmergencyDepartment == true)
                    {
                        mostSuitableDoctor = GetMostSuitableDoctor(pa, 2);
                    }

                    if (mostSuitableDoctor.MostsuitableDoctorSet)
                    {
                        pa.ProcedureDoctor = mostSuitableDoctor.ProcedureDoctor;
                    }
                    else  //En uygun birim ve doktora seçim yapmadıysa
                    {

                        foreach (UserResource ur in pa.Policlinic.ResourceUsers.OrderBy(t => t.User.Name))
                        {
                            if ((ur.User.UserType == UserTypeEnum.Doctor || ur.User.UserType == UserTypeEnum.Dentist) && ur.User.IsActive.HasValue && ur.User.IsActive.Value && !Common.PersonelIzinKontrol(ur.User.ObjectID.ToString(), pa.ActionDate.Value, objectContext))
                            {
                                if (ur.User != null)
                                {
                                    pa.ProcedureDoctor = ur.User;
                                    break;
                                }
                            }
                        }
                    }
                }

                if (pa.Building == null && pa.Department != null)
                {
                    pa.Building = pa.Department.Building;
                }

                if (pa.IsOldAction != true && (pa.DispatchType == null && pa.HCModeOfPayment == null))
                {
                    if (pa.Department == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25296", "Branş seçimi yapınız."));
                    if (pa.ProcedureDoctor == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26808", "Seçilen branşta çalışan doktor bulunmamaktadır."));
                    if (pa.Department != null && pa.Department.Policlinics.Count == 0)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26807", "Seçilen branşa ait poliklinik tanımlı değildir."));
                    if (pa.Policlinic != null && pa.Policlinic.ResourceUsers.Count == 0)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26819", "Seçilen poliklinikte doktor çalışmamaktadır."));
                    if (pa.ProcedureDoctor.UserResources.Count == 0)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25531", "Doktorun ilişkili olduğu poliklinik bulunmamaktadır."));
                }

                if (pa.FiredEpisodeActions.Count > 0)
                {
                    foreach (var firedAction in pa.FiredEpisodeActions)
                    {
                        if (firedAction is PatientExamination)
                        {
                            if (firedAction.ProcedureDoctor == null)
                                firedAction.ProcedureDoctor = (ResUser)pa.ProcedureDoctor;
                        }
                    }
                }
            }

        }

        public static void SetNewAdmissionStatus(PatientAdmission pa, Patient patient)
        {
            var admissionStatus = AdmissionStatusEnum.Normal;

            if (pa.HCRequestReason != null)//Sağlık kurulu kabulü
                admissionStatus = AdmissionStatusEnum.SaglikKurulu;
            else if (pa.DispatchType != null && pa.DispatchType == DispatchTypeEnum.DispatchedProcedure)//Hizmet protokol sevk türü : sekvli tetkik 
                admissionStatus = AdmissionStatusEnum.HizmetProtokol;
            else if (pa.DispatchType != null && pa.DispatchType == DispatchTypeEnum.Consultation)//Hizmet sevk türü : sekvli tetkik  
                admissionStatus = AdmissionStatusEnum.DisaridanGelenKonsultasyon;
            else if (patient.Death == true && patient.DeathReportNo != null)//Ölü kabul
                admissionStatus = AdmissionStatusEnum.OluKabul;
            else if (patient.Death == true)
                admissionStatus = AdmissionStatusEnum.Acil;
            else if (pa.Department != null && pa.Department.Brans != null && pa.Department.Brans.Code == "4400")//Acil kabulü, Yeni doğandan önce olmak zorunda, hem acil hem yeni doğan için acil başlatmalı
                admissionStatus = AdmissionStatusEnum.Acil;
            else if (pa.IsNewBorn == true)//Yeni doğan
                admissionStatus = AdmissionStatusEnum.Yenidogan;
            else if (pa.Policlinic != null && pa.Policlinic.TedaviTuru != null && pa.Policlinic.TedaviTuru.tedaviTuruKodu == "G")//Günübirlik kabul
                admissionStatus = AdmissionStatusEnum.Gunubirlik;
            else if (pa.Policlinic != null && pa.Policlinic.PoliclinicType == PoliclinicTypeEnum.Portor)//Portör kabulü
                admissionStatus = AdmissionStatusEnum.Portor;
            else if (pa.Policlinic != null && pa.Policlinic.PoliclinicType == PoliclinicTypeEnum.DentalPoliclinic)//Diş kabulü
                admissionStatus = AdmissionStatusEnum.DisKabulu;


            pa.AdmissionStatus = admissionStatus;


            if (pa.AdmissionType.provizyonTipiAdi != TTUtils.CultureService.GetText("M25093", "Acil"))
            {
                var e = ReturnEpisodeWithSameSpecialityInTenDays(pa, patient); //Kontrol Kabulü 
                if (e != null)
                {
                    pa.Episode = e;

                    if (admissionStatus == AdmissionStatusEnum.DisKabulu)
                        pa.AdmissionStatus = AdmissionStatusEnum.DisKontrol;
                    else
                        pa.AdmissionStatus = AdmissionStatusEnum.Kontrol;

                    if (pa.Episode.CurrentStateDefID == Episode.States.ClosedToNew || pa.Episode.CurrentStateDefID == Episode.States.Closed)
                        pa.Episode.CurrentStateDefID = Episode.States.Open;

                    if (pa.Episode.PatientStatus == PatientStatusEnum.PreDischarge || pa.Episode.PatientStatus == PatientStatusEnum.Discharge)
                    {
                        pa.Episode.PatientStatus = PatientStatusEnum.Outpatient;
                    }
                }
            }


        }

        public static bool CheckMemberChanged(PatientAdmission pa)
        {
            if (((ITTObject)pa).IsNew == false)
            {
                bool sigortaliTuruEmekli = false;
                if ((pa.MedulaSigortaliTuru.sigortaliTuruKodu == "2" || ((TTObjectClasses.PatientAdmission)((((TTInstanceManagement.ITTObject)pa).Original))).MedulaSigortaliTuru.sigortaliTuruKodu == "2")
                    && (pa.MedulaSigortaliTuru.sigortaliTuruKodu != ((TTObjectClasses.PatientAdmission)((((TTInstanceManagement.ITTObject)pa).Original))).MedulaSigortaliTuru.sigortaliTuruKodu))
                    sigortaliTuruEmekli = true;

                if (pa.IsSGKPatientAdmission == true && sigortaliTuruEmekli == true && pa.HasMemberChanged("MedulaSigortaliTuru"))
                    return true;
            }


            return pa.HasMemberChanged("AdmissionStatus") || pa.HasMemberChanged("Department") || pa.HasMemberChanged("Building") || pa.HasMemberChanged("Payer") || pa.HasMemberChanged("DispatchType");

        }

        public static void PreparePatientAdmission(PatientAdmission pa)
        {
            FillEpisode(pa);

            pa.PAStatus = PAStatusEnum.Sirada;
            pa.CurrentStateDefID = PatientAdmission.States.Open;
            pa.RecordUserID = Common.CurrentResource;

            //sağlık kurulu kabulünde ForkHealthCommitteeExamination da yaratılan her bir Mauyenenin  AdmissionQueueNumber değeri dolduruluyor
            //MHRS hastaları için sequence artmalı mı yine de? tartışılmalı.
            if (pa.Policlinic != null && pa.AdmissionQueueNumber.Value == null && pa.AdmissionStatus != AdmissionStatusEnum.SaglikKurulu)
                pa.AdmissionQueueNumber.GetNextValue(pa.Policlinic.ObjectID.ToString() + DateTime.Today.ToShortDateString());

            if (pa.EmergencyIntervention != null)
            {
                if (pa.Emergency112RefNo != null && pa.Sevkli112 == null)
                {
                    pa.Sevkli112 = true;
                }
            }
        }

        public static void SetDeathPatientResources(PatientAdmission pa, Patient p, TTObjectContext objectContext)
        {
            pa.Building = null;
            pa.Department = null;
            pa.Policlinic = null;
            pa.ProcedureDoctor = null;

            if (p.DeathReportNo == null)//Ölüm belgesi yazılıp doktor onayı alınması için Acil kabulü alınır ve acilden morga yönlendirilir
            {
                BindingList<ResDepartment> emergencyDepartment = ResDepartment.GetDepartmentByID(objectContext, 14);
                pa.Department = emergencyDepartment[0];
                pa.Building = pa.Department.Building;

                foreach (ResPoliclinic pol in pa.Department.Policlinics)
                {
                    if (pol.ResourceUsers.Count > 0)
                    {
                        foreach (UserResource ur in pol.ResourceUsers)
                        {
                            if (ur.User.UserType == UserTypeEnum.Doctor)
                            {
                                if (ur.User != null)
                                {
                                    pa.ProcedureDoctor = ur.User;
                                    pa.Policlinic = pol;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        public static string CanFirePatientAdmission(PatientAdmission patientAdmission, Patient patient, TTObjectContext objectContext)
        {
            if (((ITTObject)patientAdmission).IsNew)
            {
                foreach (var ep in patient.Episodes.Where(x => x.CurrentStateDefID != Episode.States.Closed))
                {
                    if (ep.PatientStatus != null && ep.PatientStatus == PatientStatusEnum.Inpatient)//Yatan hasta ise yeni kabul başlatılamaz
                        return TTUtils.CultureService.GetText("M27217", "Yatan hastalarda yeni kayıt kabul başlatılamaz.");
                }
            }

            //erkek hastaların Kadın Hastalıkları Ve Doğum branşına kabul alması engellendi
            if (patientAdmission.Department != null)
            {
                /*if (patient.Sex != null && patient.Sex.KODU == "1" && patientAdmission.Department.Brans.Code == "3000")
                {
                    return TTUtils.CultureService.GetText("M25603", "Erkek hastalara 'Kadın Hastalıkları Ve Doğum' branşına kayıt kabul başlatılamaz.");
                }

                if (patient.Age != null && patient.Age > 18 && patientAdmission.Department.Brans.Name.IndexOf("Çocuk") > -1)
                {
                    return "'18 Yaşından Büyük' hastalara 'Çocuk Branşına' kabul alınamaz.";
                }*/

                if (patient.Sex != null && patientAdmission.Policlinic != null && patientAdmission.Policlinic.SexException != null)
                {
                    if (patient.Sex.KODU == "1" && patientAdmission.Policlinic.SexException == SexEnum.Female)
                    {
                        return "Erkek hastalar için  bu polikliniğe kabul alınamaz.";
                    }
                    else if (patient.Sex.KODU == "2" && patientAdmission.Policlinic.SexException == SexEnum.Male)
                    {
                        return "Kadın hastalar için  bu polikliniğe kabul alınamaz.";
                    }

                }

                if (patient.Age != null && patientAdmission.Policlinic != null)
                {
                    if (patientAdmission.Policlinic.MaxAge != null && patient.Age > patientAdmission.Policlinic.MaxAge)
                        return "'" + patientAdmission.Policlinic.MaxAge + " Yaşından Büyük' hastalar için bu polikliniğe kabul alınamaz.";

                    if (patientAdmission.Policlinic.MinAge != null && patient.Age < patientAdmission.Policlinic.MinAge)
                        return "'" + patientAdmission.Policlinic.MinAge + " Yaşından Küçük' hastalar için bu polikliniğe kabul alınamaz.";
                }

                if (patient.UnIdentified.HasValue && patient.UnIdentified.Value && patientAdmission.Department.Brans != null && patientAdmission.Department.Brans.Code != "4400")
                {
                    return "'Kimliği Belirsiz' hastalar için sadece acil birimine kabul alınabilir.";
                }
            }
            #region PriorityStatus Cafer'in isteği üzerine kaldırıldı 47376

            if (patient.Age != null && patient.Age > 7 && patientAdmission.PriorityStatus != null && patientAdmission.PriorityStatus.Code == "C")
            {
                return "'7 Yaşından Büyük' hastalara, öncelik durumu '7 Yaşından Küçük Çocuklar' seçilemez.";
            }

            if (patient.Age != null && patient.Age < 65 && patientAdmission.PriorityStatus != null && patientAdmission.PriorityStatus.Code == "Y")
            {
                return "'65 Yaşından Küçük' hastalara, öncelik durumu '65 Yaş Üstü Hastalar' seçilemez.";
            }
            /*
            if (patientAdmission.PriorityStatus != null)
            {
                if (patient.Sex != null && patient.Sex.KODU == "1" && patientAdmission.PriorityStatus.Code == "H")
                {
                    return "Erkek hastalara öncelik durumu 'Hamileler' seçilemez.";
                }
                if (patient.Age != null && patient.Age <= 7 && patientAdmission.PriorityStatus.Code != "C")
                {
                    return "Öncelik durumu '7 Yaşından Küçük Çocuklar' olmalıdır.";
                }
                if (patient.Age != null && patient.Age >= 65 && patientAdmission.PriorityStatus.Code != "Y" && patientAdmission.Payer != null && patientAdmission.Payer.Code != 28)
                {
                    return "Öncelik durumu '65 Yaş Üstü Yaşlılar' olmalıdır.";
                }
                if (patientAdmission.AdmissionStatus != null && patientAdmission.AdmissionStatus == AdmissionStatusEnum.Acil && patientAdmission.PriorityStatus.Code != "A")
                {
                    return "Öncelik durumu 'Acil Vakalar' olmalıdır.";
                }
                if (patientAdmission.Payer != null && patientAdmission.Payer.Code == 28 && patientAdmission.PriorityStatus.Code != "G")
                {
                    return "Öncelik durumu 'Harp ve vazife şehitlerinin dul ve yetimleri ile malül ve gaziler' olmalıdır.";
                }
            }
            else if (patientAdmission.AdmissionStatus != AdmissionStatusEnum.DisaridanGelenKonsultasyon && patientAdmission.AdmissionStatus != AdmissionStatusEnum.HizmetProtokol)
            {
                if (patientAdmission.Payer != null && patientAdmission.Payer.Code == 28)
                {
                    return "Öncelik durumu 'Harp ve vazife şehitlerinin dul ve yetimleri ile malül ve gaziler' olmalıdır.";
                }
                if (patient.Age != null && patient.Age <= 7 && patient.Age > 0)
                {
                    return "Öncelik durumu '7 Yaşından Küçük Çocuklar' olmalıdır.";
                }
                if (patient.Age != null && patient.Age >= 65 && patientAdmission.Payer != null && patientAdmission.Payer.Code == 28)
                {
                    return "Öncelik durumu '65 Yaş Üstü Yaşlılar' olmalıdır.";
                }
                if (patientAdmission.AdmissionStatus != null && patientAdmission.AdmissionStatus == AdmissionStatusEnum.Acil)
                {
                    return "Öncelik durumu 'Acil Vakalar' olmalıdır.";
                }
            }*/
            #endregion

            if (patient.Alive != null && patient.Alive == false)
            {
                return TTUtils.CultureService.GetText("M26662", "Ölü kişilere kayıt kabul başlatılamaz.");
            }

            if (patientAdmission.Policlinic != null && patientAdmission.Department != null)
            {
                if (patientAdmission.Department.Brans.Code != patientAdmission.Policlinic.Department.Brans.Code)
                {
                    return "Seçilen poliklinik " + patientAdmission.Department.Brans.Name + " branşına ait değildir.";
                }
            }

            if (patientAdmission.ProcedureDoctor != null)
            {
                bool relatedPoliclinic = false;
                bool relatedDepartment = false;
                if (patientAdmission.Policlinic != null)
                {
                    foreach (var userResource in patientAdmission.ProcedureDoctor.UserResources)
                    {
                        if (userResource.Resource.Brans != null && userResource.Resource.Brans.Code == patientAdmission.Policlinic.Brans.Code)
                        {
                            relatedPoliclinic = true;
                            break;
                        }

                    }

                    if (relatedPoliclinic == false)
                        return "Seçilen doktor " + patientAdmission.Policlinic.Brans.Name + " polikliniği ile ilişkili değildir.";
                }
                else if (patientAdmission.Department != null)
                {
                    foreach (var userResource in patientAdmission.ProcedureDoctor.UserResources)
                    {
                        if (userResource.Resource.Brans != null && userResource.Resource.Brans.Code == patientAdmission.Department.Brans.Code)
                        {
                            relatedDepartment = true;
                            break;
                        }

                    }

                    if (relatedDepartment == false)
                        return "Seçilen doktor " + patientAdmission.Department.Brans.Name + " polikliniği ile ilişkili değildir.";
                }
            }
            if (patientAdmission.IsNewBorn == true)
            {
                DateTime birthDate = patient.BirthDate.Value;
                if (Common.DateDiff(Common.DateIntervalEnum.Day, DateTime.Now, birthDate) > 31)
                    return TTUtils.CultureService.GetText("M25088", "30 günden büyük bebeklere yeni doğan kaydı yapılamaz.");
                /*if (p.Mother.UniqueRefNo == null)
                    return "Yeni doğan kayıtlarında 'Anne TC Kimlik Numarası' girilmelidir.";*/

            }
            return "";
        }

        public static PatientAdmission SavePatientAdmission(PatientAdmission pa, int activeTab, bool AddProcedureToHC, EDisabledReport reportObj = null, EStatusNotRepCommitteeObj eStatusNotRepCommitteeObj = null)
        {
            // activeTab ==> 1:mainScreen 2:dispatchingAdmission 3:boardOfHealth 
            if (pa.ObjectContext == null)
                throw new TTUtils.TTException("ObjectContext is null.");

            var e = pa.Episode;
            var p = pa.Episode.Patient;

            pa.Episode = null;

            //Geçmiş tarihli kabul alınabilmesi için Common.RecTime() Set edildi,clienttaki değer readonly
            if ((((ITTObject)pa).IsNew) == true)
            {
                pa.CreationDate = Common.RecTime();
                pa.ActionDate = pa.CreationDate;
            }
            //Control required properties
            RequirementResultCode requirementResultCode = ControlRequiredProperties(pa, p, activeTab);
            if (requirementResultCode.resultCode > 0)
                throw new TTUtils.TTException(requirementResultCode.resultMessage);

            string canFirePatientAdmission = CanFirePatientAdmission(pa, p, pa.ObjectContext);
            if (canFirePatientAdmission != "")
                throw new TTUtils.TTException(canFirePatientAdmission);

            //Ölüm belgesi ile gelen kişi Morg birimine,ölü kabul işaretlenmiş belgesi bulunmayan kişi Acil birimine yönlendirilmeli
            if (p.Death == true)
            {
                SetDeathPatientResources(pa, p, pa.ObjectContext);
            }
            else if (pa.AdmissionStatus != AdmissionStatusEnum.SaglikKurulu && pa.AdmissionStatus != AdmissionStatusEnum.DisaridanGelenKonsultasyon && pa.AdmissionStatus != AdmissionStatusEnum.HizmetProtokol && pa.HCRequestReason == null)
                SetEmptyResources(pa);

            //Başlatılacak işlem AdmissionStatus değerine dayanır
            SetNewAdmissionStatus(pa, p);

            //if (pa.AdmissionStatus != AdmissionStatusEnum.Acil && p.UnIdentified == true)
            //    throw new TTUtils.TTException("Kimliği belirsiz hastalara sadece 'Acil kabulü' yapılabilir.");

            //Aynı gün aynı branş kontrolü
            var ep = ReturnEpisodeWithSameSpecialityInSameDay(pa, p);
            if (ep != null && ((ITTObject)pa).IsNew)
            {
                throw new Exception(TTUtils.CultureService.GetText("M25824", "Hastanın aynı gün aynı branştan vakası bulunmaktadır. Lütfen önceki vakadan devam ediniz."));
            }

            if (pa.Episode == null)
                pa.Episode = e;
            else
            {
                if (((ITTObject)e).IsNew)
                    ((IEditableObject)e).CancelEdit();
            }

            //True döner ise Pa-SEP-SE ve prosedürler iptal edilir yenileri oluşturulur
            bool checkMemberChanged = CheckMemberChanged(pa);

            bool isNewPatientAdmission = (((ITTObject)pa).IsNew);
            if (isNewPatientAdmission)
            {
                PreparePatientAdmission(pa);

                if (pa?.Payer?.IsActive == false)
                    throw new Exception("Kabul alınmaya çalışılan kurumun durumu 'Pasif' tir. Lütfen kontrol ediniz.");

                if (pa.AdmissionStatus != AdmissionStatusEnum.SaglikKurulu)
                {
                    FireEpisodeActionAndSubActionProcedure(pa, p);

                }
            }
            else
            {
                if (checkMemberChanged)
                {
                    pa = CancelEpisodeActionAndSubActionProcedure(pa);

                    isNewPatientAdmission = true;
                    PreparePatientAdmission(pa);
                    FireEpisodeActionAndSubActionProcedure(pa, p);



                }
                bool hasPolChanged = false;//HasMemberChanged sanki 2. kez çağırınca çalışmıyor
                if ((pa.HasMemberChanged("Policlinic") || pa.HasMemberChanged("ProcedureDoctor")) && pa.PAStatus.Value != PAStatusEnum.Sirada)
                    throw new Exception(TTUtils.CultureService.GetText("M25797", "Hasta statüsü '") + (Common.GetEnumValueDefOfEnumValue((Enum)pa.PAStatus)).DisplayText + "' olan hastalarda hasta kabul düzeltme yapılamaz.");
                else if (pa.HasMemberChanged("Policlinic"))
                {
                    hasPolChanged = true;

                    if (pa.Policlinic != null && pa.AdmissionStatus != AdmissionStatusEnum.SaglikKurulu)
                    {
                        bool tempSeqStatus = TTSequence.allowSetSequenceValue;
                        TTSequence.allowSetSequenceValue = true;

                        pa.AdmissionQueueNumber.SetSequenceValue(0);                        
                        pa.AdmissionQueueNumber.GetNextValue(pa.Policlinic.ObjectID.ToString() + DateTime.Today.ToShortDateString());

                        TTSequence.allowSetSequenceValue = tempSeqStatus;
                    }
                    foreach (EpisodeAction firedAction in pa.FiredEpisodeActions)
                    {
                        #region OTOMATİK ATILAN İŞLEM SİL
                        // birim değiştirir ise otomatik silmeyecek aynı branş altında tüm polikliniklerde aynı işlemi atar dedikleri için task:16053
                        //Poliklink değiştirilir ise otomatik atılacak işlemleri sil. Acil işlemleri hariç onu aşağıda hallediyor
                        //if (!(firedAction is EmergencyIntervention))
                        //{
                        //    foreach (var innerItem in firedAction.SubactionProcedures.Where(x => x.CurrentStateDefID != SubActionProcedure.States.Cancelled))
                        //    {
                        //        innerItem.ReasonOfCancel = "Poliklinik bilgisi değiştirildi.";
                        //        ((ITTObject)innerItem).Cancel();
                        //    }

                        //}
                        #endregion
                        firedAction.MasterResource = pa.Policlinic;
                        firedAction.FromResource = pa.Policlinic;
                        try
                        {
                            firedAction.SubEpisode.ResSection = pa.Policlinic;
                        }
                        catch (Exception)
                        {
                            //
                        }

                        IList<ExaminationQueueDefinition> myQueue = ExaminationQueueDefinition.GetQueueByResource(pa.ObjectContext, pa.Policlinic.ObjectID.ToString());
                        if (myQueue.Count > 0)
                        {
                            foreach (ExaminationQueueItem queueItem in firedAction.QueueItems)
                            {
                                if (queueItem.QueueDate.Value.Date == Common.RecTime().Date)
                                {
                                    if (queueItem.CurrentStateDefID == ExaminationQueueItem.States.New || queueItem.CurrentStateDefID == ExaminationQueueItem.States.Called || queueItem.CurrentStateDefID == ExaminationQueueItem.States.Diverted)
                                        queueItem.ExaminationQueueDefinition = myQueue[0];
                                }
                            }
                        }
                    }
                }
                else if (pa.HasMemberChanged("ProcedureDoctor"))
                {
                    foreach (EpisodeAction firedAction in pa.FiredEpisodeActions)
                    {
                        firedAction.ProcedureDoctor = pa.ProcedureDoctor;

                        foreach (ExaminationQueueItem queueItem in firedAction.QueueItems)
                        {
                            if (queueItem.QueueDate.Value.Date == Common.RecTime().Date)
                            {
                                if (queueItem.CurrentStateDefID == ExaminationQueueItem.States.New || queueItem.CurrentStateDefID == ExaminationQueueItem.States.Called || queueItem.CurrentStateDefID == ExaminationQueueItem.States.Diverted)
                                    queueItem.Doctor = pa.ProcedureDoctor;
                            }
                        }

                        if (firedAction is PatientExamination)
                        {
                            ((PatientExamination)firedAction).SetResponsibleDoctorAsProcedureDoctor();
                        }
                        else if (firedAction is EmergencyIntervention)
                        {
                            ((EmergencyIntervention)firedAction).SetResponsibleDoctorAsProcedureDoctor();
                        }

                        AuthorizedUser authorizedUser = new AuthorizedUser(firedAction.ObjectContext);
                        authorizedUser.User = (ResUser)pa.ProcedureDoctor;
                        firedAction.AuthorizedUsers.Add(authorizedUser);
                    }
                }
                else if (pa.HasMemberChanged("PriorityStatus"))
                {
                    foreach (EpisodeAction firedAction in pa.FiredEpisodeActions)
                    {
                        if (firedAction.QueueItems != null)
                        {
                            foreach (var examinationQueueItem in firedAction.QueueItems)
                            {
                                examinationQueueItem.Priority = (pa.PriorityStatus == null) ? 0 : pa.PriorityStatus.Order;
                                examinationQueueItem.PriorityReason = (pa.PriorityStatus == null) ? "" : pa.PriorityStatus.Name;
                            }
                        }
                    }
                }
                else if (pa.HasMemberChanged("DispatchEmergencyCons"))
                {
                    foreach (EpisodeAction firedAction in pa.FiredEpisodeActions)
                    {
                        ((Consultation)firedAction).Emergency = pa.DispatchEmergencyCons;
                    }
                }
                else if (pa.HasMemberChanged("DispatchedConsultationDef"))
                {
                    foreach (EpisodeAction firedAction in pa.FiredEpisodeActions)
                    {
                        ((Consultation)firedAction).RequestDescription = pa.DispatchedConsultationDef;
                    }
                }
                if (pa.HasMemberChanged("MedulaIstisnaiHal"))
                {
                    pa.SEP.MedulaIstisnaiHal = pa.MedulaIstisnaiHal;
                }
                if (pa.HasMemberChanged("MedulaVakaTarihi"))
                {
                    pa.SEP.MedulaVakaTarihi = pa.MedulaVakaTarihi;
                }
                if (pa.HasMemberChanged("AdmissionType"))
                {
                    pa.SEP.MedulaProvizyonTipi = (ProvizyonTipi)pa.AdmissionType;
                }
                if (pa.Episode.Patient.HasMemberChanged("DonorUniqueRefNo"))
                {
                    pa.SEP.MedulaDonorTCKimlikNo = pa.Episode.Patient.DonorUniqueRefNo;
                }

                if (!pa.HasMemberChanged("Department") && (pa.HasMemberChanged("Triage") || hasPolChanged)) /*&& pa.AdmissionType.provizyonTipiAdi == TTUtils.CultureService.GetText("M25093", "Acil"))*///Yeşil alan muayene değişti ise cancel et
                {
                    //yeni değer yeşil alan seçili ise ya da eskisi yeşil alan ise 
                    if ((pa.Triage != null && pa.Triage.KODU == "1") || (((TTObjectClasses.PatientAdmission)((((TTInstanceManagement.ITTObject)pa).Original))).Triage != null) &&
                        ((TTObjectClasses.PatientAdmission)((((TTInstanceManagement.ITTObject)pa).Original))).Triage.KODU == "1")
                    {
                        foreach (var item in pa.FiredEpisodeActions)
                        {
                            if (item is EmergencyIntervention)
                            {
                                foreach (var innerItem in item.SubactionProcedures.Where(x => x.CurrentStateDefID != SubActionProcedure.States.Cancelled))
                                {
                                    if (innerItem is EmergencyInterventionProcedure)
                                    {
                                        innerItem.ReasonOfCancel = "Triaj kod alanı değiştirildi.";
                                        ((ITTObject)innerItem).Cancel();
                                    }
                                }


                                ((EmergencyIntervention)item).Triage = pa.Triage;

                                ((EmergencyIntervention)item).AddEmergencyInterventionProcedure();

                            }
                        }
                    }

                }
            }



            if (pa.AdmissionType != null && pa.AdmissionType.provizyonTipiKodu != null)
            {
                if (pa.AdmissionType.provizyonTipiKodu != "S")
                {
                    pa.SEP.MedulaIstisnaiHal = null;
                    pa.MedulaIstisnaiHal = null;
                }
                if (pa.AdmissionType.provizyonTipiKodu != "T")
                {
                    pa.SEP.MedulaPlakaNo = null;
                    if (pa.AdmissionType.provizyonTipiKodu != "V" && pa.AdmissionType.provizyonTipiKodu != "I")
                    {
                        pa.MedulaVakaTarihi = null;
                        pa.SEP.MedulaVakaTarihi = null;
                    }
                }
                if (pa.AdmissionType.provizyonTipiKodu != "V")
                {
                    pa.SKRSAdliVaka = null;
                    if (pa.AdmissionType.provizyonTipiKodu != "T" && pa.AdmissionType.provizyonTipiKodu != "I")
                    {
                        pa.MedulaVakaTarihi = null;
                        pa.SEP.MedulaVakaTarihi = null;
                    }
                }
                if (pa.AdmissionType.provizyonTipiKodu != "I" && pa.AdmissionType.provizyonTipiKodu != "T" && pa.AdmissionType.provizyonTipiKodu != "V")
                {
                    pa.MedulaVakaTarihi = null;
                    pa.SEP.MedulaVakaTarihi = null;

                }
            }

            if (pa.MedulaIstisnaiHal != null && pa.MedulaIstisnaiHal.Kodu.Equals("B"))
                pa.SEP.MedulaTedaviTipi = TedaviTipi.GetTedaviTipi("21");
            else
                pa.SEP.MedulaTedaviTipi = (pa.Policlinic == null || pa.Policlinic.TedaviTipi == null) ? TedaviTipi.GetTedaviTipi("0") : pa.Policlinic.TedaviTipi;

            if (isNewPatientAdmission)
            {
                FillSEPProperties(pa);

                if (pa.AdmissionStatus == AdmissionStatusEnum.SaglikKurulu)
                {
                    if (pa.HCRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true && pa.HCModeOfPayment != null && pa.HCModeOfPayment != WhoPaysEnum.PatientPays)
                        pa.HCModeOfPayment = WhoPaysEnum.Free;

                    //todo set SEP
                    HealthCommittee healthCommittee = new HealthCommittee(pa.ObjectContext, pa, AddProcedureToHC, reportObj, eStatusNotRepCommitteeObj);
                }
                var se = pa.FirstSubEpisode;
                se.ArrangeMeOrCreateNewSubEpisode(pa, false, true);
                if (pa.SEP != null)
                    pa.SEP.SetSEPMaster();
                ControlBulletinProtocol(pa);

            }
            else
            {//daha önce alınmış sağlık kurulu kabulüne yeni bir poliklinik ekleniyor
                if (pa.AdmissionStatus == AdmissionStatusEnum.SaglikKurulu)
                {
                    using (var objectContext = new TTObjectContext(false))
                    {
                        HealthCommittee healthCommittee = HealthCommittee.GetHCByAdmissionID(pa.ObjectContext, pa.ObjectID)[0];

                        foreach (PatientAdmissionResourcesToBeReferred pAResourcesToBeReferred in pa.ResourcesToBeReferred)
                        {
                            if (((ITTObject)pAResourcesToBeReferred).IsNew)
                            {
                                BaseHealthCommittee_HospitalsUnitsGrid hospitalsUnitsGrid = new BaseHealthCommittee_HospitalsUnitsGrid(healthCommittee.ObjectContext);
                                hospitalsUnitsGrid.Unit = pAResourcesToBeReferred.Resource;
                                hospitalsUnitsGrid.Speciality = pAResourcesToBeReferred.Speciality;
                                hospitalsUnitsGrid.Doctor = pAResourcesToBeReferred.ProcedureDoctorToBeReferred;

                                healthCommittee.HospitalsUnits.Add(hospitalsUnitsGrid);

                                EpisodeAction.ForkHealthCommitteeExamination((HospitalsUnitsGrid)hospitalsUnitsGrid, healthCommittee);
                            }
                            //healthCommittee.HospitalsUnits.Add(hospitalsUnitsGrid);
                        }

                        //if (healthCommittee.HospitalsUnits != null || healthCommittee.HospitalsUnits.Count > 0)
                        //{
                        //    healthCommittee.CheckHospitalsUnitsGridForFork();
                        //}
                    }
                }
            }


            SetEpisodeDetails(pa);
            SetPatientDetails(pa);






            if (pa.AdmissionStatus == AdmissionStatusEnum.HizmetProtokol)
            {
                foreach (EpisodeAction ea in pa.FiredEpisodeActions)
                {
                    if (ea is DispatchExamination)
                    {
                        ((DispatchExamination)ea).SetDispatchEpisodeActionProperties(pa);
                    }
                }
            }

            if (pa.HasMemberChanged("AdmissionType") && !String.IsNullOrEmpty(pa.SEP.MedulaTakipNo))
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25853", "Hastanın takip numarası bulunmaktadır.Geliş sebebini değiştirmek için önce Takip siliniz."));

            if (pa.HasMemberChanged("MedulaIstisnaiHal") && !String.IsNullOrEmpty(pa.SEP.MedulaTakipNo))
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25853", "Hastanın takip numarası bulunmaktadır.İstisnai Hal sebebini değiştirmek için önce Takip siliniz."));

            //Bu exception sonda kalmalı:pa.Episode.Payer set edilmiş olmalı
            string debtMessage = Patient.PatientHasDebt(p, pa.ObjectContext);
            if (debtMessage == TTUtils.CultureService.GetText("M25836", "Hastanın önceki HBYS sisteminden borcu bulunmaktadır. Lütfen vezneye yönlendiriniz.") && (pa.Department.Brans.Code != "4400" || pa.Policlinic.Brans.Code != "4400"))
                throw new TTUtils.TTException(debtMessage + " \nBorcu bulunan hastalara sadece 'Acil kabulü' yapılabilir.");
            if (isNewPatientAdmission == true && pa.Episode.Payer != null && pa.Episode.Payer.Type != null && pa.Episode.Payer.Type.PayerType == PayerTypeEnum.Paid && debtMessage != "" && (pa.Department.Brans.Code != "4400" || pa.Policlinic.Brans.Code != "4400"))
            {
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25827", "Hastanın borcu bulunmaktadır. Lütfen vezneye yönlendiriniz. \nBorcu bulunan hastalara sadece 'Acil kabulü' yapılabilir."));
            }

            //Kayıt kabul sayısını birim - doktor bazlı olarak bir arttır
            if (isNewPatientAdmission == true && pa.Episode.Patient.DeathReportNo == null && pa.AdmissionStatus != AdmissionStatusEnum.SaglikKurulu && pa.AdmissionStatus != AdmissionStatusEnum.DisaridanGelenKonsultasyon && pa.AdmissionStatus != AdmissionStatusEnum.HizmetProtokol)
            {
                PatientAdmissionCount pac = PatientAdmission.UpdatePatientAdmissionCounter(pa.ProcedureDoctor.ObjectID, pa.Policlinic.ObjectID, Convert.ToDateTime(pa.ActionDate), true, pa.ObjectContext);
                pa.ProcedureDoctor.PACount = pac;
            }

            return pa;
        }

        public static void SetPatientDetails(PatientAdmission pa)
        {
            if (pa.Episode.Patient.ID.Value == null)
                pa.Episode.Patient.ID.GetNextValue();

            if (pa.Episode.Patient != null && pa.Episode.Patient.Nationality != null && pa.Episode.Patient.Nationality.Kodu != "TR")
                pa.Episode.Patient.Foreign = true;

            if (pa.PA_Address != null)
            {
                if (pa.Episode.Patient.PatientAddress == null)
                    pa.Episode.Patient.PatientAddress = pa.PA_Address;
                else if (pa.Episode.Patient.PatientAddress.ObjectID != pa.PA_Address.ObjectID)
                {
                    CopyProperties(pa.Episode.Patient.PatientAddress, pa.PA_Address);
                }
            }

            pa.Episode.Patient.RecordUserID = Common.CurrentResource;

            if (pa.Episode.Patient.Death == true)
            {
                pa.Episode.Patient.Alive = false;

                if (pa.Episode.Patient.DeathReportNo != null)
                    pa.DeathApplication = true;
            }

            if (pa.BeneficiaryName != null)
                pa.Episode.Patient.BeneficiaryName = pa.BeneficiaryName;

            if (pa.BeneficiaryUniqueRefNo != null)
                pa.Episode.Patient.BeneficiaryUniqueRefNo = pa.BeneficiaryUniqueRefNo;

            if (pa.Episode.Patient.ImportantPatientInfo != null)
                pa.Episode.ImportantPatientInfo = pa.Episode.Patient.ImportantPatientInfo;

            if (pa.IsNewBorn == true)
                Patient.MatchMother(pa.Episode.Patient, pa.Episode.Patient.Mother);

        }

        private static void CopyProperties(object targetObject, object sourceObject)
        {
            var querySourceProps = from p in sourceObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                   where p.CanWrite
                                   select p;

            var sourcePropertyList = querySourceProps.ToDictionary(p => p.Name);

            var targetPropertyList = targetObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).ToDictionary(p => p.Name);

            foreach (var sourcePropertyInfo in sourcePropertyList.Values)
            {
                if (targetPropertyList.ContainsKey(sourcePropertyInfo.Name))
                {
                    if (sourcePropertyInfo.Name != "Item")
                    {
                        var targetPropertyInfo = targetPropertyList[sourcePropertyInfo.Name];
                        targetPropertyInfo.SetValue(targetObject, sourcePropertyInfo.GetValue(sourceObject, null), null);
                    }
                }
            }
        }

        public static RequirementResultCode ControlRequiredProperties(PatientAdmission pa, Patient p, int activeTab)
        {

            RequirementResultCode requirementResultCode = new RequirementResultCode();
            RequirementExecutor reqExecutor = new RequirementExecutor();


            PatientInfoRequirements patientInfoRequirements = new PatientInfoRequirements(p);
            reqExecutor.addRequirement(patientInfoRequirements);

            if (p.UnIdentified != true && p.Privacy != true && p.Death != true)
            {
                PatientAddressRequirements patientAddressRequirements = new PatientAddressRequirements(pa.PA_Address);
                reqExecutor.addRequirement(patientAddressRequirements);
            }

            PatientAdmissionRequirements patientAdmissionRequirements = new PatientAdmissionRequirements(pa, p, activeTab);
            reqExecutor.addRequirement(patientAdmissionRequirements);

            requirementResultCode = reqExecutor.Execute();
            reqExecutor.clearAllRequirements();

            return requirementResultCode;
        }

        public static void CancelRelatedObjects(PatientAdmission pa, bool? isCancelled = true)
        {
            if (isCancelled == true)
                pa.PAStatus = PAStatusEnum.IptalEdildi;
            else
                pa.PAStatus = PAStatusEnum.KabulSilindi;

            var _firedActions = pa.FiredEpisodeActions.OrderByDescending(dr => (int)dr.ActionType);

            foreach (var item in _firedActions)
            {
                if (((ITTObject)item).IsCancelled == false)
                {
                    foreach (var innerItem in item.SubactionProcedures)
                    {
                        innerItem.Cancel();
                    }
                    ((ITTObject)item).Cancel();
                }
            }

            if (pa.SEP != null)
                pa.SEP.Cancel();

            if (pa.FirstSubEpisode != null)
                pa.FirstSubEpisode.CurrentStateDefID = SubEpisode.States.Cancelled;

            if (pa.DeathApplication != null && pa.DeathApplication == true)//Ölü kabul siliniyor ise hasta üzerindeki death property false set edilmeli
            {
                pa.Episode.Patient.Alive = true;
                pa.Episode.Patient.Death = false;
                pa.DeathApplication = false;
            }

            pa.Cancel();

            if (pa.AdmissionAppointment != null)
            {
                foreach (Appointment app in pa.AdmissionAppointment.Appointments)
                {
                    if (app.CurrentStateDefID == Appointment.States.New || app.CurrentStateDefID == Appointment.States.NotApproved)
                    {
                        app.CurrentStateDefID = Appointment.States.Cancelled;
                    }
                }
            }
        }

        public static PatientAdmission CancelEpisodeActionAndSubActionProcedure(PatientAdmission pa)
        {
            if (TTUser.CurrentUser.HasRole(Common.PatientAdmissionCorrectionRoleID) == true)
            {
                // Guid savePointGuid = pa.ObjectContext.BeginSavePoint();
                try
                {
                    if (pa.PAStatus.Value == PAStatusEnum.Sirada)
                    {
                        if (!string.IsNullOrEmpty(pa.SEP.MedulaTakipNo))
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26225", "İşlemi gerçekleştirebilmek için Medula takip numarasını silmelisiniz."));
                        else if (SubEpisodeProtocol.GetChildSEP(pa.SEP, true) != null)
                        {
                            throw new TTUtils.TTException("İşlemi gerçekleştirebilmek için Bağlı medula takip numarasını silmelisiniz.");
                        }
                        else
                        {
                            PatientAdmission newPa = (PatientAdmission)pa.Clone();
                            SubEpisodeProtocol newSep = (SubEpisodeProtocol)pa.SEP.CloneMe(SEPCloneTypeEnum.PatientAdmissionChange);
                            SubEpisode newSe = (SubEpisode)pa.FirstSubEpisode.Clone();

                            newPa.ActionDate = pa.ActionDate;
                            newPa.CreationDate = pa.CreationDate;

                            newPa.Episode = pa.Episode;
                            newSe.Episode = null;// Episodu Nulla set etmeden direk Episodu  set edersek değer değişmediği için  Contextdeki Episode yeniden yüklenmiyor ve Episode.Subepisodes da newSe gözükmüyor 
                            newSe.Episode = pa.Episode;
                            pa.Episode.SubEpisodes.Add(newSe);
                            newSe.PatientAdmission = newPa;
                            newSe.SYSTakipNo = null; //yeni clonelanan subepisodeda sys takip tekrar alınacağı için nullandı

                            //PatientAdmission.FillClonedSEPPoperties(pa,ref newSep);
                            newSep.SubEpisode = newSe;
                            newSep.PatientAdmission = newPa;
                            newSep.MedulaProvizyonTarihi = pa.SEP.MedulaProvizyonTarihi;

                            ((IEditableObject)pa.SEP).CancelEdit();
                            ((IEditableObject)pa.FirstSubEpisode).CancelEdit();
                            ((IEditableObject)pa).CancelEdit();

                            CancelRelatedObjects(pa, true);


                            return newPa;
                        }
                    }
                    else
                        throw new Exception(TTUtils.CultureService.GetText("M25797", "Hasta statüsü '") + (Common.GetEnumValueDefOfEnumValue((Enum)pa.PAStatus)).DisplayText + "' olan hastalarda hasta kabul düzeltme yapılamaz.");

                }
                catch (Exception ex)
                {
                    //if (pa.ObjectContext.HasSavePoint(savePointGuid))
                    //    pa.ObjectContext.RollbackSavePoint(savePointGuid);
                    throw;
                }
            }
            else
                throw new Exception(TTUtils.CultureService.GetText("M25786", "Hasta kabul düzeltme yetkiniz bulunmamaktadır."));
        }

        public static void FireEpisodeActionAndSubActionProcedure(PatientAdmission pa, Patient p, bool fromHelpMenu = false, ResUser resUser = null, ResPoliclinic resPoliclinic = null, SKRSTRIAJKODU skrsTriajKodu = null)
        {
            Guid savePointGuid = pa.ObjectContext.BeginSavePoint();

            try
            {
                if (pa.CurrentStateDefID == PatientAdmission.States.Cancelled)
                    throw new Exception(TTUtils.CultureService.GetText("M25797", "Hasta statüsü '") + PatientAdmission.States.Cancelled + "' olan hastalarda hasta kabul düzeltme yapılamaz.");


                EpisodeAction firedAction = null;
                PatientAdmissionStartedActions oaStartedAct = null;
                ResSection _selectedPoliclinic = fromHelpMenu ? (ResSection)resPoliclinic : (ResSection)pa.Policlinic;
                ResUser _selectedDoctor = fromHelpMenu ? (ResUser)resUser : (ResUser)pa.ProcedureDoctor;

                if (p.Death == true && p.DeathReportNo != null)//Ölüm belge numarası varsa Morg işlemi başlatılacak
                {
                    oaStartedAct = PatientAdmissionStartedActions.GetFiredActionsandProcedures(null, AdmissionStatusEnum.OluKabul);
                }
                else
                {
                    if (fromHelpMenu)//burdan geliyor ise zaten acil alması lazım.günübirlik yatış yapılınca tip değişiyor
                        oaStartedAct = PatientAdmissionStartedActions.GetFiredActionsandProcedures((ResPoliclinic)_selectedPoliclinic, AdmissionStatusEnum.Acil);
                    //else if (pa.Department != null && pa.Department.Brans != null && pa.Department.Brans.Code == "4400" && pa.IsNewBorn.HasValue && pa.IsNewBorn.Value)//hem yeni doğan hem acil ise acil başlatasın
                    //    oaStartedAct = PatientAdmissionStartedActions.GetFiredActionsandProcedures((ResPoliclinic)_selectedPoliclinic, AdmissionStatusEnum.Acil);
                    else
                        oaStartedAct = PatientAdmissionStartedActions.GetFiredActionsandProcedures((ResPoliclinic)_selectedPoliclinic, pa.AdmissionStatus);

                }


                if (oaStartedAct == null)
                    throw new Exception(TTUtils.CultureService.GetText("M25254", "Başlatılacak işlem tanımı eksik.Otomatik başlatılacak işlem tanımlarından birim - kabul durum eşleştirmesini kontrol ediniz:") + _selectedPoliclinic.Name + " - " + pa.AdmissionStatus);

                string objectDefName = (Common.GetEnumValueDefOfEnumValue((Enum)oaStartedAct.PAActionTypeObject[0].ActionType)).Name;
                firedAction = (EpisodeAction)pa.ObjectContext.CreateObject(objectDefName);

                if (firedAction == null)
                    throw new Exception(TTUtils.CultureService.GetText("M25253", "Başlatılacak işlem tanımı eksik."));


                BindingList<TTObjectStateDef> states = (BindingList<TTObjectStateDef>)((ITTObject)firedAction).GetNextStateDefs();
                if (states.Count > 0)
                {
                    firedAction.CurrentStateDef = (TTObjectStateDef)states[0];
                }

                firedAction.ActionDate = Common.RecTime();

                pa.FiredEpisodeActions.Add(firedAction);

                if (p.Death == true && p.DeathReportNo != null)
                {
                    string morgueIDObjectID = SystemParameter.GetParameterValue("MORGUEOBJECTID", "");

                    if (morgueIDObjectID == "")
                        throw new Exception(TTUtils.CultureService.GetText("M26539", "Morg işlemi tanımlı olmadığı için başlatılamamıştır."));

                    BindingList<ResSection> morgue = ResSection.GetMorgueDepartment(pa.ObjectContext, new Guid(morgueIDObjectID));

                    firedAction.MasterResource = (ResSection)morgue[0];//Morg
                }
                else
                    firedAction.MasterResource = _selectedPoliclinic;

                firedAction.Episode = pa.Episode;

                // if (fromHelpMenu || firedAction.SubEpisode == null || firedAction.SubEpisode.CurrentStateDef.Status == StateStatusEnum.Cancelled)// Hasta Kabul düzeltme yapıldığında yeni bir ilk ayaktan subepisodea bağlasın
                if (fromHelpMenu)
                    firedAction.SubEpisode = pa.FirstSubEpisode;

                if (p.DeathReportNo == null)//MORG işlemi başlamayacak ise
                {
                    firedAction.ProcedureDoctor = _selectedDoctor;
                    bool AdvanceStateIfHasSubaction = false;
                    BindingList<PAProcedureObject> procedureObj = oaStartedAct.PAProcedureObject;
                    if (procedureObj.Count > 0)
                    {
                        //Burada Tanım ekranında girilmiş procedureobjects create ediliyor.
                        foreach (PAProcedureObject procedureObjDef in procedureObj)
                        {
                            ProcedureDefinition procedureDef = procedureObjDef.ProcedureObject;
                            SubActionProcedure sa = firedAction.SetSubactionProcedureOfEpisodeAction(procedureDef, _selectedPoliclinic); // Hasta Kabulde Başlatılan işlemin altına atılacak tipde bir hizmet tanımlarsa Hizmeti İşlemin altına atar
                            if (sa != null)
                            {
                                AdvanceStateIfHasSubaction = true;
                                sa.ProcedureByUser = _selectedDoctor;
                                sa.RequestedByUser = Common.CurrentResource;

                            }
                            else if (procedureDef is IProcedureRequestDefinition)// Hasta Kabulde Başlatılan işlemin altına atılacak tipde bir hizmet değilse IProcedureRequestDefinition mı diye bakılır . IProcedureRequestDefinition ise kendisi işlem başlatabilecek bir hizmettir 
                            {
                                if (pa.AdmissionStatus != AdmissionStatusEnum.Acil)
                                {
                                    procedureDef = (ProcedureDefinition)pa.ObjectContext.GetObject(procedureObjDef.ProcedureObject.ObjectID, procedureObjDef.ProcedureObject.ObjectDef);// procedureObjDef.ProcedureObject in ObjectContexi readonly olduğu için IProcedureRequestDefinition olduğu durumda işlem başlatılamıyordu 
                                    if (procedureObjDef.Resource is null || procedureObjDef.Resource.ObjectID.Equals(firedAction.MasterResource.ObjectID))
                                    {
                                        if (procedureObjDef.MainResource == null)
                                        {
                                            throw new Exception("Otomatik başlatılacak işlem/hizmet tanımları ekranında 'Hizmetin/tetkiğin Yapılacağı Birim' Alanı boş geçilemez Lütfen Bilgi işleme Başvurunuz");
                                        }
                                        EpisodeAction createdEAByProcedureRequestDefinition = ((IProcedureRequestDefinition)procedureDef).CreateMyEpisodeAction(firedAction, procedureObjDef.MainResource, procedureObjDef.Resource, true, false, Common.RecTime(), pa.ProcedureDoctor != null ? pa.ProcedureDoctor.ObjectID : Common.CurrentResource.ObjectID, true);
                                        sa = ((IProcedureRequestDefinition)procedureDef).CreateMySubactionProcedure(createdEAByProcedureRequestDefinition, procedureObjDef.MainResource, procedureObjDef.Resource);
                                        if (sa.EpisodeAction != createdEAByProcedureRequestDefinition)// CreateMySubactionProcedure Overrid edilebilen bir method Ea ile subepisodeu eşleştirme unutulursa diye eklendi
                                            sa.EpisodeAction = createdEAByProcedureRequestDefinition;
                                        pa.FiredEpisodeActions.Add(createdEAByProcedureRequestDefinition);
                                    }
                                }

                            }
                        }
                    }

                    if (AdvanceStateIfHasSubaction)
                    {
                        foreach (TTObjectStateTransitionDef transDef in firedAction.CurrentStateDef.SortedOutgoingTransitions.Values)
                        {
                            if (transDef.AllAttributes.ContainsKey("StatePrecedenceAttribute"))
                            {
                                firedAction.Update();
                                firedAction.CurrentStateDefID = transDef.ToStateDefID;
                                break;
                            }
                        }
                    }
                }




                if (firedAction is PatientExamination)
                {
                    //bg PE postinsert tarafında yapıldığı için kapatıldı         
                    //((PatientExamination)firedAction).AddPatientExaminationProcedure();

                    ((PatientExamination)firedAction).SetPatientExaminationStatus();
                    ((PatientExamination)firedAction).SetResponsibleDoctorAsProcedureDoctor();

                }
                else if (firedAction is DentalExamination)
                {
                    //bg PE postinsert tarafında yapıldığı için kapatıldı         
                    //((PatientExamination)firedAction).AddPatientExaminationProcedure();

                    ((DentalExamination)firedAction).SetDentalExaminationStatus();

                }
                else if (firedAction is EmergencyIntervention)
                {
                    ((EmergencyIntervention)firedAction).SetResponsibleDoctorAsProcedureDoctor();
                    pa.EmergencyIntervention = (EmergencyIntervention)firedAction;

                    if (fromHelpMenu)//acil kabul birleştirden geliyor ise ekrandan girilen triaj bilgisini al
                    {
                        pa.Triage = skrsTriajKodu;
                        pa.EmergencyIntervention.Triage = skrsTriajKodu;
                    }
                    else if (pa.Triage != null)
                    {
                        pa.EmergencyIntervention.Triage = pa.Triage;

                    }
                }
                else if (firedAction is Consultation)
                {
                    ((Consultation)firedAction).RequesterResource = firedAction.MasterResource;
                    ((Consultation)firedAction).Emergency = pa.DispatchEmergencyCons;
                    ((Consultation)firedAction).RequestDescription = pa.DispatchedConsultationDef;

                }
                else if (firedAction is Morgue)
                {
                    ((Morgue)firedAction).CurrentStateDefID = Morgue.States.OutRequest;
                    ((Morgue)firedAction).DeathReportNo = p.DeathReportNo;

                }
                else if (firedAction is DispatchExamination)
                {
                    ((DispatchExamination)firedAction).CurrentStateDefID = DispatchExamination.States.New;
                }

                AuthorizedUser authorizedUser = new AuthorizedUser(firedAction.ObjectContext);
                authorizedUser.User = (ResUser)_selectedDoctor;
                firedAction.AuthorizedUsers.Add(authorizedUser);

                if (TTObjectClasses.SystemParameter.IsMedulaIntegration)
                    firedAction.MedulaHastaKabul = SelectMedulaHastaKabul(pa);

                bool isEntryState = false;
                if (pa.CurrentStateDef == null || pa.CurrentStateDef.IsEntry == true)
                    isEntryState = true;

                if (pa.AdmissionAppointment != null)
                {
                    if (String.IsNullOrEmpty(firedAction.GotoStateDefID) == false)
                    {
                        Guid toStateDefID = new Guid(firedAction.GotoStateDefID);
                        foreach (TTObjectStateTransitionDef std in firedAction.CurrentStateDef.OutgoingTransitions)
                        {
                            if (std.ToStateDefID == toStateDefID)
                            {
                                firedAction.ObjectContext.Update();
                                firedAction.CurrentStateDefID = toStateDefID;
                                break;
                            }
                        }
                    }

                    foreach (Appointment app in pa.AdmissionAppointment.Appointments)
                    {
                        if (firedAction.MasterResource.Brans.Code == app.MasterResource.Brans.Code)
                        {
                            if (app.CurrentStateDefID == Appointment.States.New || app.CurrentStateDefID == Appointment.States.NotApproved)
                            {
                                if (app.InitialObjectID != null || app.EpisodeAction == null) //Süreç Randevusundan Kabul Randevusuna dönmüş ise aşağıdaki kod çalışmaz
                                {
                                    if (app.Resource is ResUser)
                                        firedAction.ProcedureDoctor = (ResUser)app.Resource;
                                    app.EpisodeAction = firedAction;
                                    app.Patient = pa.Episode.Patient;
                                }

                                if (app.Action != null)
                                {
                                    if (((AdmissionAppointment)app.Action).CurrentStateDefID == AdmissionAppointment.States.New)
                                        ((AdmissionAppointment)app.Action).CurrentStateDefID = AdmissionAppointment.States.Appointment;
                                    ((AdmissionAppointment)app.Action).CurrentStateDefID = AdmissionAppointment.States.Completed;
                                }
                                app.CurrentStateDefID = Appointment.States.Completed;


                                firedAction.WorkListDate = app.StartTime;
                                firedAction.ActionDate = app.StartTime;
                                pa.ActionDate = app.StartTime;

                                break;


                            }
                        }
                    }
                }

                pa.Episode.Patient.NotRequiredQuota = false;


                if (p.DeathReportNo == null)//MORG işlemi başlamayacak ise
                {
                    if (pa != null)
                    {

                        IList<ExaminationQueueDefinition> myQueue = ExaminationQueueDefinition.GetQueueByResource(pa.ObjectContext, firedAction.MasterResource.ObjectID.ToString());
                        if (myQueue.Count > 0)
                            firedAction.CreateExaminationQueueItem(pa, myQueue[0], (Boolean)firedAction.Emergency);
                    }
                }
            }
            catch (Exception ex)
            {
                if (pa.ObjectContext.HasSavePoint(savePointGuid))
                    pa.ObjectContext.RollbackSavePoint(savePointGuid);
                throw;
            }
        }

        public static PatientMedulaHastaKabul SelectMedulaHastaKabul(PatientAdmission pa)
        {
            PatientMedulaHastaKabul pm = new PatientMedulaHastaKabul();
            if (TTObjectClasses.SystemParameter.IsMedulaIntegration)
            {
                if (pa.PatientMedulaHastaKabul == null)
                {
                    if (pa.IsSGKPatientAdmission)
                    {
                        IList patientMedulaHastaKabulleri = pa.Episode.EpisodeMedulaHastaKabulleri.Select("CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(PatientMedulaHastaKabul.States.Valid));
                        BindingList<PatientMedulaHastaKabul> activePatientMedulaHastaKabulleri = new BindingList<PatientMedulaHastaKabul>();

                        // MedulaHastaKabuller arasından ilgili hasta grubuna uygun olmayanlar Listeden çıkarılır.
                        foreach (PatientMedulaHastaKabul patientMedulaHastaKabul in patientMedulaHastaKabulleri)
                        {
                            activePatientMedulaHastaKabulleri.Add(patientMedulaHastaKabul);
                        }

                        if (activePatientMedulaHastaKabulleri.Count == 1)
                        {
                            PatientMedulaHastaKabul patientMedulaHastaKabul = (PatientMedulaHastaKabul)activePatientMedulaHastaKabulleri[0];
                            pm = pa.PatientMedulaHastaKabul = patientMedulaHastaKabul;

                        }
                    }
                }
            }
            return pm;
        }
        static bool CheckUnpaidDebt(PatientAdmission _PatientAdmission)
        {
            if (_PatientAdmission.Episode.Payer != null && _PatientAdmission.Episode.Payer.Type.PayerType == PayerTypeEnum.Paid)
            {
                if (_PatientAdmission.Episode.Patient.APR != null)
                {
                    BindingList<AccountTransaction.GetPatientTotalNotPaid_Class> getPatientAtrs = AccountTransaction.GetPatientTotalNotPaid(_PatientAdmission.Episode.Patient.MyAPR().ObjectID);
                    if (getPatientAtrs.Count > 0)
                        return true;
                }
            }
            return false;
        }

        public static PatientAdmission LoadPatientAdmission(Patient patient, TTObjectContext ctx)
        {
            PatientAdmission pa = new PatientAdmission(ctx);
            Episode e = new Episode(ctx);
            pa.Episode = e;
            pa.Episode.Patient = patient;

            if (pa.Episode.Patient.PatientAddress != null)
                pa.PA_Address = (PatientIdentityAndAddress)pa.Episode.Patient.PatientAddress.Clone();
            else if (pa.PA_Address == null)
            {
                pa.PA_Address = new PatientIdentityAndAddress(ctx);
                //pa.Episode.Patient.PatientAddress = new PatientIdentityAndAddress(ctx);
            }
            SubEpisode se = new SubEpisode(ctx);
            se.PatientAdmission = pa;

            se.AddSubEpisodeProtocol();

            //SE'nin ctx içerisine eklenmemesi için yeni context yaratıldı
            TTObjectContext roContext = new TTObjectContext(true);
            Patient p = roContext.GetObject(patient.ObjectID, patient.ObjectDef, false) as Patient;
            if (p != null)
            {
                Episode lastEpisode = p.Episodes.Where(x => x.ObjectID != e.ObjectID).OrderByDescending(x => x.OpeningDate).FirstOrDefault();
                SubEpisodeProtocol lastSEP = null;
                if (lastEpisode != null)
                {
                    List<SubEpisodeProtocol> sepList = lastEpisode.AllSubEpisodeProtocols();

                    if (sepList.Count > 0)
                        lastSEP = sepList.Where(x => x.PatientAdmission != null && x.Payer.Type.PayerType.Value != PayerTypeEnum.Hospital).OrderByDescending(x => x.CreationDate).FirstOrDefault();
                }

                if (lastSEP != null && lastSEP.Payer != null && lastSEP.Payer.SelectInPatientAdmission != true)//kurumun yeniden seçilmesi istenmiyor ise
                {
                    pa.Payer = lastSEP.Payer;
                    pa.Protocol = lastSEP.Protocol;
                    pa.MedulaSigortaliTuru = lastSEP.MedulaSigortaliTuru;
                    pa.MedulaIstisnaiHal = lastSEP.MedulaIstisnaiHal;
                    pa.MedulaVakaTarihi = lastSEP.MedulaVakaTarihi;
                }
                else
                {
                    PatientAdmission lastPA = PatientAdmission.GetLastPatientAdmission(roContext, pa.ObjectID, p.ObjectID).FirstOrDefault();
                    if (lastPA != null && lastPA.Payer != null && lastPA.Payer.SelectInPatientAdmission != true)
                    {
                        pa.Payer = lastPA.Payer;
                        pa.Protocol = lastPA.Protocol;
                        pa.MedulaSigortaliTuru = lastPA.MedulaSigortaliTuru;
                        pa.MedulaIstisnaiHal = lastPA.MedulaIstisnaiHal;
                        pa.MedulaVakaTarihi = lastPA.MedulaVakaTarihi;
                    }
                }
            }

            if (pa.Episode.Patient.BeneficiaryName != null)
                pa.BeneficiaryName = pa.Episode.Patient.BeneficiaryName;

            if (pa.Episode.Patient.BeneficiaryUniqueRefNo != null)
                pa.BeneficiaryUniqueRefNo = pa.Episode.Patient.BeneficiaryUniqueRefNo;

            return pa;
        }

        public virtual bool IsNewSubEpisodeNeeded()
        {
            return true;
        }

        public virtual bool Sent101Package()
        {
            return true;
        }

        public virtual DateTime SubEpisodeOpeningDate()
        {
            return ActionDate.Value;
        }
        public virtual void FillLocalSEPProperties(ref SubEpisodeProtocol sep)
        {
        }
        public static void FillClonedSEPPoperties(PatientAdmission pa, ref SubEpisodeProtocol sep)
        {
            //sep.CreationDate = Common.RecTime();
            //sep.MedulaProvizyonTarihi = Common.RecTime();
            //sep.ClonedFrom = pa.SEP;

            if (pa.SEP.Payer.Type.PayerType == PayerTypeEnum.Paid)
                sep.LastIIM = pa.SEP.LastIIM;

            SEPMaster sepMaster = new SEPMaster(pa.SEP.ObjectContext);
            sep.SEPMaster = sepMaster;
            sep.Payer = pa.SEP.Payer;
            sep.Protocol = pa.SEP.Protocol;

            SubEpisodeProtocol.SEPProperty SEPProperty = new SubEpisodeProtocol.SEPProperty();
            SEPProperty.payer = sep.Payer;
            SEPProperty.protocol = sep.Protocol;
            SEPProperty.cancelOldSEP = true;


        }

        public static void DeletePatientAdmission(PatientAdmission pa)
        {
            if (TTUser.CurrentUser.HasRole(Common.PatientAdmissionCorrectionRoleID) == true)
            {
                if (pa.PAStatus == PAStatusEnum.Sirada)
                {
                    if (!string.IsNullOrEmpty(pa.SEP.MedulaTakipNo))
                    {
                        //  throw new TTUtils.TTException("İşlemi gerçekleştirebilmek için Medula takip numarasını silmelisiniz.");
                        MedulaResult mr = pa.SEP.DeleteProvisionFromMedula();
                        if (mr != null)
                        {
                            if (mr.SonucKodu == "0000")
                            {
                                ((IEditableObject)pa).CancelEdit();

                                CancelRelatedObjects(pa, false);
                            }
                            else
                                throw new TTUtils.TTException(mr.SonucMesaji);
                        }
                        else
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27018", "Takip silerken hata oluştu,kabul silinemedi."));
                    }
                    else if (SubEpisodeProtocol.GetChildSEP(pa.SEP, true) != null)
                    {
                        throw new TTUtils.TTException("İşlemi gerçekleştirebilmek için Bağlı medula takip numarasını silmelisiniz.");
                    }
                    else if (pa.IsCancellable)
                    {
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26252", "Kabulü silemezsiniz.Bu muayeneye bağlı açılmış Kontrol Muayenesi bulunmaktadır."));
                    }
                    else
                    {
                        ((IEditableObject)pa).CancelEdit();

                        CancelRelatedObjects(pa, false);
                    }
                }
                else
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25797", "Hasta statüsü '") + (Common.GetEnumValueDefOfEnumValue((Enum)pa.PAStatus)).DisplayText + "' olan hastaların kabulleri silinemez.");
            }
            else
                throw new Exception(TTUtils.CultureService.GetText("M25313", "Bu işlem için yetkiniz bulunmamaktadır."));
        }

        public static BindingList<Appointment> CheckAppointmentList(Guid patientID, long uniqueRefNo, TTObjectContext ctx)
        {
            BindingList<Appointment> appList = null;

            appList = Appointment.GetAppointmentByDatePatient(ctx, Common.RecTime().AddDays(1).Date.AddMinutes(-1), Common.RecTime().Date, patientID);
            if (appList.Count > 0)
            {
                return appList;
            }
            else
            {
                var admissionAppList = AdmissionAppointment.GetAdmissionAppByUniqueRefNo(ctx, uniqueRefNo);
                if (admissionAppList.Count > 0)
                {
                    foreach (var addmission in admissionAppList)
                    {
                        var app = Appointment.GetByMHRSApp(ctx, addmission.ObjectID, Common.RecTime().Date, Common.RecTime().AddDays(1).Date.AddMinutes(-1)).FirstOrDefault();
                        if (app != null)
                        {
                            appList.Add(app);
                        }
                    }
                    return appList;
                }
            }

            return null;
        }

        public static PatientAdmissionCount UpdatePatientAdmissionCounter(Guid doctorID, Guid policlinicID, DateTime actionDate, bool increase, TTObjectContext ctx)
        {
            int count = 0, _tempCount = 0;
            //Doktroun seçili birime ait counter değerini getir

            DoctorQuotaDefinition dod = null;//kota pasife çekilmiş veya silinmiş ise kontrol etmesin

            BindingList<PatientAdmissionCount> counterList = PatientAdmissionCount.GetByDoctorPoliclinic(ctx, doctorID, policlinicID, Common.RecTime().Date, Common.RecTime().AddDays(1).Date.AddMinutes(-1));
            if (counterList.Count > 0)
            {
                count = Convert.ToInt32(counterList[0].Counter);
            }

            PatientAdmissionCount pac = null;
            if (counterList.Count == 0)
            {
                pac = new PatientAdmissionCount(ctx);
                pac.Doctor = (ResUser)ctx.GetObject(doctorID, typeof(ResUser));
                pac.Doctor.DoctorQuota = DoctorQuotaDefinition.GetDoctorQuotaByPoliclinic(ctx, policlinicID, doctorID).FirstOrDefault();
                _tempCount = (pac.Doctor.DoctorQuota != null && !String.IsNullOrEmpty(pac.Doctor.DoctorQuota.Quota)) ? Convert.ToInt32(pac.Doctor.DoctorQuota.Quota) : 0;
                pac.Policlinic = (ResPoliclinic)ctx.GetObject(policlinicID, typeof(ResPoliclinic));
                pac.PatientAdmissionDate = actionDate;
            }
            else
            {
                pac = (PatientAdmissionCount)ctx.GetObject(counterList[0].ObjectID, typeof(PatientAdmissionCount));
                _tempCount = count;
            }

            if (increase == true)
                count++;
            else
                count--;

            if (count < 0)
                count = 0;

            pac.Counter = count;

            dod = DoctorQuotaDefinition.GetDoctorQuotaByPoliclinic(ctx, policlinicID, doctorID).FirstOrDefault();

            string activeCotaCount = dod == null ? "0" : dod.Quota;

            if (Convert.ToInt32(activeCotaCount) > 0 && _tempCount != 0 && count > Convert.ToInt32(activeCotaCount))
            {
                throw new Exception(TTUtils.CultureService.GetText("M00000", "Doktorun günlük kotası aşıldığı için bu doktora kabul alamazsınız."));//alert no değiştirilmeli
            }
            return pac;
        }

        public static PatientAdmission LoadAppointmentInfo(PatientAdmission pa, TTObjectContext ctx, Guid? appointmentID = null)
        {
            BindingList<Appointment> appList = null;
            if (appointmentID != null)

                appList = Appointment.GetPatientAdmissionAppointmentsByID(ctx, Common.RecTime().AddDays(1).Date.AddMinutes(-1), Common.RecTime().Date, appointmentID.Value);
            else if (pa != null)
                appList = Appointment.GetPatientAdmissionAppointmentsByDate(ctx, pa.Episode.Patient.ObjectID, Common.RecTime().Date, Common.RecTime().AddDays(1).Date.AddMinutes(-1));

            if (appList != null && appList.Count == 1)
            {
                pa.AdmissionAppointment = (AdmissionAppointment)appList[0].Action;
                pa.ProcedureDoctor = (ResUser)appList[0].Resource;
                pa.Policlinic = (ResPoliclinic)appList[0].MasterResource;
                if (pa.Policlinic != null)
                    pa.Department = pa.Policlinic.Department;
                if (pa.Department != null)
                    pa.Building = pa.Department.Building;
                pa.CurrentStateDefID = PatientAdmission.States.Open;

                return pa;
            }
            else
                throw new Exception(TTUtils.CultureService.GetText("M26722", "Randevu bilgilerinde hata vardır."));

        }
        #endregion Methods

        #region CLASSES
        public class MostSuitableDoctorInfo
        {
            public ResUser ProcedureDoctor { get; set; }
            public ResPoliclinic Policlinic { get; set; }
            public bool MostsuitableDoctorSet { get; set; }
        }

        public class MHRS_PA_InputDTO
        {
            public long UniquerefNo { get; set; }
            public Guid? DepartmentID { get; set; }
            public Guid? PoliclinicID { get; set; }

            public Guid? DoctorID { get; set; }
            public Guid AppointmentID { get; set; }

            public string PoliclinicName { get; set; }
            public string DoctorName { get; set; }

        }
        #endregion
    }
}
