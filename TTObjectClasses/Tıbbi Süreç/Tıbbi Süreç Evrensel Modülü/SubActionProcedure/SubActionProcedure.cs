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
    public partial class SubActionProcedure : TTObject, IMedulaChildOfEpisodeAction, ISUTInstance, ISetWorkListDate, ISubEpisodeStarter
    {
        public partial class GetExaminationTestListNQL_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_SGKStatisticQuery1_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_SGKStatisticQuery1_SECount_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_SGKStatisticQuery1_PatientCount_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_SGKStatisticQuery2_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_SGKStatisticQuery2_PatientCount_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetDentalTreatments_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_SGKStatisticQuery2_SECount_Class : TTReportNqlObject
        {
        }

        public partial class GetProcedureNameAndCode_Class : TTReportNqlObject
        {
        }

        public TTSequence GetID()
        {
            return ID;
        }

        public SpecialityDefinition GetProcedureSpeciality()
        {
            return ProcedureSpeciality;
        }

        public void SetProcedureSpeciality(SpecialityDefinition value)
        {
            ProcedureSpeciality = value;
        }

        public Episode GetEpisode()
        {
            return Episode;
        }

        public void SetEpisode(Episode value)
        {
            Episode = value;
        }

        public SubEpisode GetSubEpisode()
        {
            return SubEpisode;
        }

        public void SetSubEpisode(SubEpisode value)
        {
            SubEpisode = value;
        }

        public void SetCurrentStateDef(TTObjectStateDef value)
        {
            CurrentStateDef = value;
        }

        public string PrescriptionColorType
        {
            get
            {
                try
                {
                    #region PrescriptionColorType_GetScript                    
                    return null;
                    #endregion PrescriptionColorType_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "PrescriptionColorType") + " : " + ex.Message, ex);
                }
            }
        }

        public long? GetDoctorSpecialityCode()
        {
            try
            {
                #region DoctorSpecialityCode_GetScript                    
                if (EpisodeAction != null)
                {
                    if (EpisodeAction.ProcedureSpeciality != null)
                        return EpisodeAction.ProcedureSpeciality.ExternalCode;
                }

                return null;
                #endregion DoctorSpecialityCode_GetScript
            }
            catch (Exception ex)
            {
                throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "DoctorSpecialityCode") + " : " + ex.Message, ex);
            }
        }

        #region IMedulaChildOfEpisodeAction Members
        public PatientMedulaHastaKabul GetMedulaHastaKabul()
        {
            return MedulaHastaKabul;
        }

        public void SetMedulaHastaKabul(PatientMedulaHastaKabul value)
        {
            MedulaHastaKabul = value;
        }

        public IEpisodeAction GetEpisodeActionObject()
        {
            return EpisodeActionObject;
        }

        public void SetEpisodeActionObject(IEpisodeAction value)
        {
            EpisodeActionObject = value;
        }
        #endregion

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

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "PRICINGDATE":
                    {
                        DateTime? value = (DateTime?)newValue;
                        #region PRICINGDATE_SetScript
                        if (SetMyPricingDateToPerformedDate())
                        {
                            if (value != null && PerformedDate == null)
                            {
                                PerformedDate = value;
                            }
                        }
                        #endregion PRICINGDATE_SetScript
                    }

                    break;
                case "EPISODEACTION":
                    {
                        EpisodeAction value = (EpisodeAction)newValue;
                        #region EPISODEACTION_SetParentScript
                        if (value != null)
                        {
                            // SubEpisode Set etme
                            SubEpisode = value.SubEpisode;
                            //
                            if (Episode == null)
                                Episode = value.Episode;
                            SetEntryState();
                            if (value is NursingApplication && this is NursingOrderDetail)
                            {
                                ((NursingOrderDetail)this).SecondaryMasterResource = value.SecondaryMasterResource;
                            }
                            //else if (value is DentalExamination && this is DentalProcedure)
                            //{
                            //    ((DentalProcedure)this).MasterResource = ((DentalExamination)value).MasterResource;
                            //    ((DentalProcedure)this).FromResource = ((DentalExamination)value).FromResource;
                            //}
                            //else if (value is BaseDentalEpisodeAction && this is BaseDentalSubactionProcedure)
                            //{
                            //    ((BaseDentalSubactionProcedure)this).MasterResource = ((BaseDentalEpisodeAction)value).MasterResource;
                            //    ((BaseDentalSubactionProcedure)this).FromResource = ((BaseDentalEpisodeAction)value).FromResource;
                            //}
                            //else if (value is Surgery && this is SurgeryPreOpApplications)
                            //{
                            //    ((SurgeryPreOpApplications)this).MasterResource = ((Surgery)value).MasterResource;
                            //    ((SurgeryPreOpApplications)this).FromResource = ((Surgery)value).FromResource;
                            //}
                            else if (value is BloodProductRequest && this is BloodBankBloodProducts)
                            {
                                ((BloodBankBloodProducts)this).MasterResource = ((BloodProductRequest)value).MasterResource;
                                ((BloodBankBloodProducts)this).FromResource = ((BloodProductRequest)value).FromResource;
                            }
                            else if (value is ExternalProcedureRequest && this is ExternalSubActionProcedure)
                            {
                                ((ExternalSubActionProcedure)this).MasterResource = ((ExternalProcedureRequest)value).MasterResource;
                                ((ExternalSubActionProcedure)this).FromResource = ((ExternalProcedureRequest)value).FromResource;
                            }

                            if (EmergencyPropertySetWithAction())
                                Emergency = value.Emergency;
                            // Episodeaction'ın ProcedureDoctor'unu kendi ProcedureDoctor alanına set eder
                            if (GetProcedureDoctorFromMyEpisodeAction())
                            {
                                if (value != null && value.SetMyProcedureDoctorToMySubactionProcedure())
                                {
                                    if (value.ProcedureDoctor != null)
                                        ProcedureDoctor = value.ProcedureDoctor;
                                }
                            }

                            //Description
                            string StrDescriptionForWorklist = "";
                            if (value.DescriptionForWorkList != null)
                                StrDescriptionForWorklist = value.DescriptionForWorkList;
                            if (ProcedureObject != null)
                            {
                                string StrValue = "";
                                if (ProcedureObject.Code != null)
                                    StrValue += ProcedureObject.Code + " ";
                                StrValue += ProcedureObject.Name;
                                if (StrDescriptionForWorklist == null)
                                    StrDescriptionForWorklist = StrValue;
                                else
                                    StrDescriptionForWorklist += "," + StrValue;
                                if (StrDescriptionForWorklist.Length > 2000)
                                    value.DescriptionForWorkList = StrDescriptionForWorklist.Substring(0, 1999);
                                else
                                    value.DescriptionForWorkList = StrDescriptionForWorklist;
                            }
                        }
                        #endregion EPISODEACTION_SetParentScript
                    }

                    break;
                case "MASTERSUBACTIONPROCEDURE":
                    {
                        SubActionProcedure value = (SubActionProcedure)newValue;
                        #region MASTERSUBACTIONPROCEDURE_SetParentScript
                        if (value != null)
                        {
                            EpisodeAction = value.EpisodeAction;
                        }
                        #endregion MASTERSUBACTIONPROCEDURE_SetParentScript
                    }

                    break;
                case "SUBEPISODE":
                    {
                        // Aşağıdaki kod PostUpdate ten çağırılan AccountOperationAfterUpdate metoduna taşındı
                        //SubEpisode value = (SubEpisode)newValue;
                        //if (SubEpisode != null && value != null)
                        //{
                        //    SubEpisodeProtocol newSEP = value.OpenSubEpisodeProtocol;
                        //    if (newSEP == null)
                        //        throw new TTException(SystemMessage.GetMessage(663));
                        //    ChangeMyProtocol(newSEP);
                        //}
                    }

                    break;
                case "PROCEDUREOBJECT":
                    {
                        ProcedureDefinition value = (ProcedureDefinition)newValue;
                        #region PROCEDUREOBJECT_SetParentScript
                        string StrValue = "";
                        if (value != null) // Fixed By Murat, Should Check soruce code by Mustafa Dönmez
                        {
                            if (value.Code != null)
                                StrValue += value.Code + " ";
                            StrValue += value.Name;
                        }
                        //Description
                        string StrDescriptionForWorklist = "";
                        if (EpisodeAction != null)
                        {
                            if (EpisodeAction.DescriptionForWorkList != null)
                                StrDescriptionForWorklist = EpisodeAction.DescriptionForWorkList;
                            if (ProcedureObject == null)
                            {
                                StrDescriptionForWorklist += StrValue + " , ";
                            }
                            else
                            {
                                if (ProcedureObject != value)
                                {
                                    if (EpisodeAction.DescriptionForWorkList == null)
                                        StrDescriptionForWorklist = StrValue;
                                    else
                                        StrDescriptionForWorklist.Replace(ProcedureObject.Code == null ? ProcedureObject.Name : (ProcedureObject.Code + " " + ProcedureObject.Name), StrValue);
                                }
                            }

                            //if(this.EpisodeAction.DescriptionForWorkList == null && StrDescriptionForWorklist > 2000)
                            if (StrDescriptionForWorklist.Length > 2000)
                                EpisodeAction.DescriptionForWorkList = StrDescriptionForWorklist.Substring(0, 1999);
                            else
                                EpisodeAction.DescriptionForWorkList = StrDescriptionForWorklist;
                        }
                        #endregion PROCEDUREOBJECT_SetParentScript
                    }

                    break;
                case "PROCEDUREDOCTOR":
                    {
                        ResUser value = (ResUser)newValue;
                        #region PROCEDUREDOCTOR_SetParentScript
                        //Artık Allocationlar yok
                        //if (value != null)
                        //{
                        //    bool IsAssignable;
                        //    IsAssignable = value.IsAssignablePatientGroup(this.Episode);
                        //    if (IsAssignable == false)
                        //    {
                        //        throw new Exception(SystemMessage.GetMessage(1010));
                        //    }
                        //}
                        //if (this is ConsultationProcedure)// Doktorun Eski ve Yeni Tüm İşlemleri görebilmesi için
                        //{
                        //    if (this.ProcedureDoctor != null && value != null)
                        //    {
                        //        if (this.ProcedureDoctor.ObjectID != value.ObjectID)
                        //        {
                        //            if (this.Episode.Patient.SecurePerson != null && this.Episode.Patient.SecurePerson.Value == true)
                        //            {
                        //                if (!(Common.CurrentUser.IsSuperUser || Common.CurrentUser.IsPowerUser || Common.CurrentResource.ObjectID == this.ProcedureDoctor.ObjectID))
                        //                    throw new Exception(SystemMessage.GetMessage(1011));
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
                        //    SubactionProcedureFlowable spf = this as SubactionProcedureFlowable;
                        //    if (spf != null)
                        //    {
                        //        bool addNewAuthorizedUser = true;
                        //        if (spf.ProcedureDoctor != null && spf.AuthorizedUsers.Count > 0)
                        //        {
                        //            foreach (AuthorizedUser authorizedUser in spf.AuthorizedUsers)
                        //            {
                        //                if (authorizedUser.User.ObjectID == spf.ProcedureDoctor.ObjectID)
                        //                {
                        //                    if (value != null)
                        //                    {
                        //                        authorizedUser.User = (ResUser)value;
                        //                    }
                        //                    else
                        //                    {
                        //                        spf.AuthorizedUsers.Remove(authorizedUser);
                        //                        ((ITTObject)authorizedUser).Delete();
                        //                    }
                        //                    addNewAuthorizedUser = false;
                        //                    break;
                        //                }
                        //            }
                        //        }
                        //        if (addNewAuthorizedUser)
                        //        {
                        //            AuthorizedUser newAuthorizedUser = new AuthorizedUser(this.ObjectContext);
                        //            newAuthorizedUser.User = (ResUser)value;
                        //            spf.AuthorizedUsers.Add(newAuthorizedUser);
                        //        }
                        //    }
                        //}
                        #endregion PROCEDUREDOCTOR_SetParentScript
                    }

                    break;
            }
        }

        protected override void PreInsert()
        {
            #region PreInsert
            OlapLastUpdate = DateTime.Now;

            if (!Amount.HasValue)
                Amount = 1;

            if (!Eligible.HasValue)
                Eligible = true;

            if (IsOldAction != true)
            {
                if (!CreationDate.HasValue || this?.ProcedureObject?.RepetitionQueryNeeded == true)
                    CreationDate = Common.RecTime();

                if (SubEpisode != null && SubEpisode.PatientStatus == SubEpisodeStatusEnum.Inpatient && CheckSubepisodeClosingDate())
                {
                    DateTime procedureDate = CreationDate.Value.Date;
                    if (PricingDate.HasValue) // Ücretlenme tarihi dolu ise bu tarih kullanılsın
                        procedureDate = PricingDate.Value.Date;

                    if (SubEpisode.OpeningDate.HasValue && SubEpisode.OpeningDate.Value.Date > procedureDate)
                        throw new Exception(TTUtils.CultureService.GetText("M27800", "Yatış başlangıç tarihi öncesine hizmet girişi yapılamaz!"));

                    if (SubEpisode.ClosingDate.HasValue && SubEpisode.ClosingDate.Value.Date < procedureDate)
                        throw new Exception(TTUtils.CultureService.GetText("M25860", "Yatış bitiş tarihi sonrasına hizmet girişi yapılamaz!"));
                }

                // Yeşil Alan Muayenesi ise başka hizmet girilemesin kontrolü
                if (Episode != null && Eligible == true && ProcedureObject != null && ProcedureObject.Chargable == true && !ProcedureObject.ObjectID.Equals(ProcedureDefinition.GreenAreaExaminationProcedureObjectId))
                {
                    //foreach (EmergencyIntervention ei in Episode.EmergencyInterventions)
                    //{
                    //    if (!ei.IsCancelled && ei.IsGreenAreaExamination)
                    //        throw new Exception(TTUtils.CultureService.GetText("M27249", "Yeşil Alan Muayenesi olan vakalarda başka hizmet/malzeme girişi yapılamaz!"));
                    //}

                    #region yeşil alan kontrolü muayene client'ına taşındı
                    //Artık actionlar kendi işlemini giriyor. birden fazla Muayene işlemi var
                    //if (this.EpisodeAction is PatientExamination)
                    //{
                    //    if (((PatientExamination)this.EpisodeAction).EmergencyIntervention != null)
                    //    {
                    //        if (!((PatientExamination)this.EpisodeAction).EmergencyIntervention.IsCancelled && ((PatientExamination)this.EpisodeAction).EmergencyIntervention.IsGreenAreaExamination)
                    //            throw new Exception(TTUtils.CultureService.GetText("M27249", "Yeşil Alan Muayenesi olan vakalarda başka hizmet/malzeme girişi yapılamaz!"));
                    //    }
                    //}
                    #endregion

                    //foreach (EmergencyIntervention ei in Episode.EmergencyInterventions)
                    //{
                    //    if (!ei.IsCancelled && ei.IsGreenAreaExamination)
                    //        throw new Exception(TTUtils.CultureService.GetText("M27249", "Yeşil Alan Muayenesi olan vakalarda başka hizmet/malzeme girişi yapılamaz!"));
                    //}
                }
            }

            if (CurrentStateDefID == null)
                SetEntryState();

            SetRequestedByUserAsCurrentResource();

            CreatePackageProcedure();

            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();
            if (IsOldAction != true)
            {
                string message = string.Empty;
                if (!(this is BaseBedProcedure))
                {
                    message = PatientOnVacation.HasActiveVacation(this.CreationDate.Value, this.Episode.Patient.ObjectID);

                    if (!string.IsNullOrEmpty(message))
                    {
                        throw new Exception(message + "\n Bu tarihe işlem giremezsiniz");
                    }
                }

                AccountOperation();

                //if (this.EpisodeAction != null && this.EpisodeAction.Episode != null)
                //     EpisodeAction.CheckSutRules();

                CheckPerformedAndCreationDate();
                //ENabiz a Islem bilgisi gondermek icin paket bilgisi yaziliyor.
                if (SubEpisode != null)
                {
                    if (SendToENabiz(true))
                        new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "102", Common.RecTime());
                }
                else
                {
                    if (Episode.SubEpisodes.Count > 0 && SendToENabiz(true))
                        new SendToENabiz(ObjectContext, Episode.SubEpisodes[0], ObjectID, ObjectDef.Name, "102", Common.RecTime());
                }

                AddRowToSendToDoctorPerformace(DPInternalObjectStatus.Inserted);

                if (EpisodeAction.ActionType == ActionTypeEnum.LaboratoryRequest && (EpisodeAction as LaboratoryRequest).MasterAction is PatientExamination && ProcedureObject.Code == "908115" && CurrentStateDefID!=LaboratoryRequest.States.Cancelled)
                {
                    UserMessage userMessage = new UserMessage();
                    string messageText = "Sayın " + Episode.Patient.FullName + ", izolasyonda kalacağınız yere " + Common.RecTime().AddHours(4).ToString("MM/dd/yyyy HH:mm") + " saatine kadar gitmeniz gerekmektedir.";
                    List<Patient> patients = new List<Patient> { Episode.Patient };
                    userMessage.SendSMSPatient(patients, messageText, SMSTypeEnum.RadTestReportSMSForPatient);
                }

            }
            #endregion PostInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate
            base.PreUpdate();
            OlapLastUpdate = DateTime.Now;
            #endregion PreUpdate
        }

        protected void CheckPerformedAndCreationDate()
        {
            if (TTObjectClasses.SystemParameter.GetParameterValue("SETPERFORMEDDATE_BOZULMASIN", "FALSE") != "TRUE")
            {
                if (CreationDate != null && PerformedDate != null && CreationDate > PerformedDate)
                {
                    throw new Exception(TTUtils.CultureService.GetText("M26234", "İşlemin  İstek Zamanı  Gerçekleşme Zamanından sonra olamaz"));
                }
            }
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();
            if (IsOldAction != true)
            {
                string message = string.Empty;
                if (!(this is BaseBedProcedure))
                {
                    message = PatientOnVacation.HasActiveVacation(this.CreationDate.Value, this.SubEpisode.ObjectID);

                    if (!string.IsNullOrEmpty(message))
                    {
                        throw new Exception(message + "\n Bu tarihe işlem giremezsiniz");
                    }
                }

                AccountOperationAfterUpdate();

                if (TransDef != null && TransDef.ToStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                {
                    SetPerformedDate();
                    CheckProceduerDoctorForPerformans();
                }

                CheckPerformedAndCreationDate();
                if (CurrentStateDef.Status == StateStatusEnum.Cancelled)
                    AddRowToSendToDoctorPerformace(DPInternalObjectStatus.Cancelled);
                else
                    AddRowToSendToDoctorPerformace(DPInternalObjectStatus.Updated);
                SendToENabizForSubactionProcedure(false);
            }
            #endregion PostUpdate
        }

        protected override void PreDelete()
        {
            #region PreDelete
            base.PreDelete();
            if (((ITTObject)this).IsNew != true)
                AddRowToSendToDoctorPerformace(DPInternalObjectStatus.Cancelled);
            CancelMyAccountTransactions();
            #endregion PreDelete
        }

        protected override void PostDelete()
        {
            #region PostDelete
            base.PostDelete();
            #endregion PostDelete
        }

        protected void PostTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
            #region PostTransition_New2Cancelled
            Cancel();
            #endregion PostTransition_New2Cancelled
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled
            Cancel();
            #endregion PostTransition_Completed2Cancelled
        }

        public virtual void AccountOperationAfterUpdate()
        {
            TTObjectContext objContext = new TTObjectContext(true);
            SubActionProcedure originalSP = objContext.GetObject(ObjectID, ObjectDef, false) as SubActionProcedure;
            if (originalSP != null)
            {
                if (Eligible != true || CurrentStateDef.Status == StateStatusEnum.Cancelled) // Eligible false ise veya iptal durumunda bir adımda ise ücretler iptal edilip çıkılır
                {
                    CancelMyAccountTransactions();
                    return;
                }

                if (AccountTransactions.Count == 0) // Insert sırasında ücretlenmemişse burada ücretlensin
                    AccountOperation();

                else if ((PricingDate.HasValue && originalSP.PricingDate.HasValue && PricingDate.Value.Date != originalSP.PricingDate.Value.Date) || // PricingDate değişmiş
                    (Amount.HasValue && originalSP.Amount.HasValue && Amount.Value != originalSP.Amount.Value) || // Amount değişmiş
                    (Eligible == true && originalSP.Eligible != true) || // Eligible true yapılmış
                    (ProcedureObject != null && originalSP.ProcedureObject != null && ProcedureObject.ObjectID != originalSP.ProcedureObject.ObjectID) || // ProcedureObject değişmiş
                    (SubEpisode != null && originalSP.SubEpisode != null && SubEpisode.ObjectID != originalSP.SubEpisode.ObjectID)) // SubEpisode değişmiş

                    ChangeMyProtocol(SubEpisode.OpenSubEpisodeProtocol);
            }
        }

        #region Methods

        public virtual bool CheckSubepisodeClosingDate() // True ise Hizmet Bağlı olduğu SubEpisode un Opening ve Closing  tarihleri arasında uygulanmak zorundadır.
        {
            return true;
        }

        public void SendToENabizForSubactionProcedure(bool isNewInserted)
        {

            //ENabiz a Islem bilgisi gondermek icin paket bilgisi yaziliyor.
            if (SendToENabiz(isNewInserted))
            {
                if (SubEpisode != null)
                {

                    new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "102", Common.RecTime());
                }
                else
                {
                    if (Episode.SubEpisodes.Count > 0)
                        new SendToENabiz(ObjectContext, Episode.SubEpisodes[0], ObjectID, ObjectDef.Name, "102", Common.RecTime());
                }
            }
        }

        #region GetDVO Bloğu
        public object GetDVO(AccountTransaction accTrx)
        {
            int adet = Convert.ToInt32(accTrx.Amount);
            string hizmetSunucuRefNo = accTrx.MedulaReferenceNumber;
            string sutKodu = accTrx.MedulaProcedureCode;
            string islemTarihi = accTrx.MedulaTransactionDate;
            string bransKodu = GetDVOBransKodu(accTrx);
            string drTescilNo = GetDVODrTescilNo(bransKodu);
            string ozelDurum = GetDVOOzelDurum(accTrx);
            string[] cokluOzelDurum = GetDVOCokluOzelDurum();
            string istemYapanDrTescilNo = null;
            string istemYapanDrBrans = null;

            DVOBransDrTescilKontrol(ref bransKodu, drTescilNo);

            switch (ProcedureObject.MedulaProcedureType)
            {
                case MedulaSUTGroupEnum.ameliyatveGirisimBilgileri:
                    {
                        HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO ameliyatveGirisimBilgisiDVO = new HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO();
                        ameliyatveGirisimBilgisiDVO.hizmetSunucuRefNo = hizmetSunucuRefNo;
                        ameliyatveGirisimBilgisiDVO.sutKodu = sutKodu;
                        ameliyatveGirisimBilgisiDVO.islemTarihi = islemTarihi;
                        ameliyatveGirisimBilgisiDVO.adet = adet;
                        //ameliyatveGirisimBilgisiDVO.adetSpecified = true;
                        ameliyatveGirisimBilgisiDVO.bransKodu = bransKodu;
                        ameliyatveGirisimBilgisiDVO.drTescilNo = drTescilNo;
                        ameliyatveGirisimBilgisiDVO.aciklama = GetDVOAciklama(accTrx);
                        ameliyatveGirisimBilgisiDVO.ayniFarkliKesi = GetDVOAyniFarkliKesi(ameliyatveGirisimBilgisiDVO);
                        ameliyatveGirisimBilgisiDVO.sagSol = GetDVOSagSol();
                        ameliyatveGirisimBilgisiDVO.euroscore = GetDVOEuroscore();
                        ameliyatveGirisimBilgisiDVO.ozelDurum = ozelDurum;
                        ameliyatveGirisimBilgisiDVO.cokluOzelDurum = cokluOzelDurum;
                        return ameliyatveGirisimBilgisiDVO;
                    }
                case MedulaSUTGroupEnum.disBilgileri:
                    {
                        HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO = new HizmetKayitIslemleri.disBilgisiDVO();
                        disBilgisiDVO.hizmetSunucuRefNo = hizmetSunucuRefNo;
                        disBilgisiDVO.sutKodu = sutKodu;
                        disBilgisiDVO.islemTarihi = islemTarihi;
                        disBilgisiDVO.adet = adet;
                        //disBilgisiDVO.adetSpecified = true;
                        disBilgisiDVO.bransKodu = bransKodu;
                        disBilgisiDVO.drTescilNo = drTescilNo;
                        disBilgisiDVO.anomali = GetDVOAnomali();
                        disBilgisiDVO.ayniFarkliKesi = GetDVOAyniFarkliKesi(disBilgisiDVO);
                        disBilgisiDVO.disTaahhutNo = GetDVODisTaahhutNo();
                        //disBilgisiDVO.disTaahhutNoSpecified = true;
                        GetDVOSetCeneBilgisi(disBilgisiDVO); // Çene, Süt Çene ve Anomali Diş bilgilerini set edecek metod. Kontrol etmek lazım bunu, DİKKAT !!!
                        disBilgisiDVO.ozelDurum = ozelDurum;
                        disBilgisiDVO.cokluOzelDurum = cokluOzelDurum;
                        return disBilgisiDVO;
                    }
                case MedulaSUTGroupEnum.konsultasyonBilgileri:
                    {
                        HizmetKayitIslemleri.konsultasyonBilgisiDVO konsultasyonBilgisiDVO = new HizmetKayitIslemleri.konsultasyonBilgisiDVO();
                        konsultasyonBilgisiDVO.hizmetSunucuRefNo = hizmetSunucuRefNo;
                        konsultasyonBilgisiDVO.sutKodu = sutKodu;
                        konsultasyonBilgisiDVO.islemTarihi = islemTarihi;
                        konsultasyonBilgisiDVO.bransKodu = bransKodu;
                        konsultasyonBilgisiDVO.drTescilNo = drTescilNo;
                        konsultasyonBilgisiDVO.ozelDurum = ozelDurum;
                        konsultasyonBilgisiDVO.cokluOzelDurum = cokluOzelDurum;
                        return konsultasyonBilgisiDVO;
                    }
                case MedulaSUTGroupEnum.muayeneBilgisi:
                    {
                        HizmetKayitIslemleri.muayeneBilgisiDVO muayeneBilgisiDVO = new HizmetKayitIslemleri.muayeneBilgisiDVO();
                        muayeneBilgisiDVO.hizmetSunucuRefNo = hizmetSunucuRefNo;
                        muayeneBilgisiDVO.sutKodu = sutKodu;
                        muayeneBilgisiDVO.muayeneTarihi = GetDVOMuayeneTarihi(accTrx);
                        muayeneBilgisiDVO.bransKodu = bransKodu;
                        muayeneBilgisiDVO.drTescilNo = drTescilNo;
                        muayeneBilgisiDVO.ozelDurum = ozelDurum;
                        muayeneBilgisiDVO.cokluOzelDurum = cokluOzelDurum;
                        return muayeneBilgisiDVO;
                    }
                case MedulaSUTGroupEnum.tahlilBilgileri:
                    {
                        HizmetKayitIslemleri.tahlilBilgisiDVO tahlilBilgisiDVO = new HizmetKayitIslemleri.tahlilBilgisiDVO();
                        tahlilBilgisiDVO.hizmetSunucuRefNo = hizmetSunucuRefNo;
                        tahlilBilgisiDVO.sutKodu = sutKodu;
                        tahlilBilgisiDVO.islemTarihi = islemTarihi;
                        tahlilBilgisiDVO.adet = adet;
                        //tahlilBilgisiDVO.adetSpecified = true;
                        tahlilBilgisiDVO.bransKodu = bransKodu;
                        tahlilBilgisiDVO.drTescilNo = drTescilNo;
                        tahlilBilgisiDVO.tahlilSonuclari = GetDVOTahlilSonuclari();
                        tahlilBilgisiDVO.ozelDurum = ozelDurum;
                        tahlilBilgisiDVO.cokluOzelDurum = cokluOzelDurum;

                        // İstem yapan Dr. un Tescil No ve Branşı
                        ResUser requestDoctor = GetDVOIstemYapanDr();
                        if (requestDoctor != null)
                        {
                            istemYapanDrTescilNo = requestDoctor.DiplomaRegisterNo;

                            SpecialityDefinition requestDoctorSpeciality = requestDoctor.GetSpeciality();
                            if (requestDoctorSpeciality != null)
                                istemYapanDrBrans = requestDoctorSpeciality.Code;
                        }

                        // istemYapanDrTescilNo boş ise drTescilNo set edilir
                        if (string.IsNullOrWhiteSpace(istemYapanDrTescilNo))
                            istemYapanDrTescilNo = tahlilBilgisiDVO.drTescilNo;

                        // istemYapanDrBrans boş ise bransKodu set edilir
                        if (string.IsNullOrWhiteSpace(istemYapanDrBrans))
                            istemYapanDrBrans = tahlilBilgisiDVO.bransKodu;

                        DVOBransDrTescilKontrol(ref istemYapanDrBrans, istemYapanDrTescilNo);

                        tahlilBilgisiDVO.istemYapanDrTescilNo = istemYapanDrTescilNo;
                        tahlilBilgisiDVO.istemYapanDrBrans = istemYapanDrBrans;

                        // Dış tetkik ise drTescilNo boş, ozelDurum "f" gönderilir
                        if (IsExternal())
                        {
                            tahlilBilgisiDVO.drTescilNo = null;
                            tahlilBilgisiDVO.ozelDurum = "f";
                        }

                        return tahlilBilgisiDVO;
                    }
                case MedulaSUTGroupEnum.tetkikveRadyolojiBilgileri:
                    {
                        HizmetKayitIslemleri.tetkikveRadyolojiBilgisiDVO tetkikveRadyolojiBilgisiDVO = new HizmetKayitIslemleri.tetkikveRadyolojiBilgisiDVO();
                        tetkikveRadyolojiBilgisiDVO.hizmetSunucuRefNo = hizmetSunucuRefNo;
                        tetkikveRadyolojiBilgisiDVO.sutKodu = sutKodu;
                        tetkikveRadyolojiBilgisiDVO.islemTarihi = islemTarihi;
                        tetkikveRadyolojiBilgisiDVO.adet = adet;
                        //tetkikveRadyolojiBilgisiDVO.adetSpecified = true;
                        tetkikveRadyolojiBilgisiDVO.bransKodu = bransKodu;
                        tetkikveRadyolojiBilgisiDVO.drTescilNo = drTescilNo;
                        tetkikveRadyolojiBilgisiDVO.birim = GetDVOBirim();
                        tetkikveRadyolojiBilgisiDVO.sonuc = GetDVOSonuc();
                        tetkikveRadyolojiBilgisiDVO.ayniFarkliKesi = GetDVOAyniFarkliKesi(tetkikveRadyolojiBilgisiDVO);
                        tetkikveRadyolojiBilgisiDVO.sagSol = GetDVOSagSol();
                        tetkikveRadyolojiBilgisiDVO.accession = GetDVOAccession();
                        tetkikveRadyolojiBilgisiDVO.modality = GetDVOModality();
                        tetkikveRadyolojiBilgisiDVO.aciklama = GetDVOAciklama(accTrx);
                        tetkikveRadyolojiBilgisiDVO.ozelDurum = ozelDurum;
                        tetkikveRadyolojiBilgisiDVO.cokluOzelDurum = cokluOzelDurum;

                        // İstem yapan Dr. un Tescil No ve Branşı
                        ResUser requestDoctor = GetDVOIstemYapanDr();
                        if (requestDoctor != null)
                        {
                            istemYapanDrTescilNo = requestDoctor.DiplomaRegisterNo;

                            SpecialityDefinition requestDoctorSpeciality = requestDoctor.GetSpeciality();
                            if (requestDoctorSpeciality != null)
                                istemYapanDrBrans = requestDoctorSpeciality.Code;
                        }

                        // istemYapanDrTescilNo boş ise drTescilNo set edilir
                        if (string.IsNullOrWhiteSpace(istemYapanDrTescilNo))
                            istemYapanDrTescilNo = tetkikveRadyolojiBilgisiDVO.drTescilNo;

                        // istemYapanDrBrans boş ise bransKodu set edilir
                        if (string.IsNullOrWhiteSpace(istemYapanDrBrans))
                            istemYapanDrBrans = tetkikveRadyolojiBilgisiDVO.bransKodu;

                        DVOBransDrTescilKontrol(ref istemYapanDrBrans, istemYapanDrTescilNo);

                        tetkikveRadyolojiBilgisiDVO.istemYapanDrTescilNo = istemYapanDrTescilNo;
                        tetkikveRadyolojiBilgisiDVO.istemYapanDrBrans = istemYapanDrBrans;

                        // Dış tetkik ise drTescilNo boş, ozelDurum "f" gönderilir
                        if (IsExternal())
                        {
                            tetkikveRadyolojiBilgisiDVO.drTescilNo = null;
                            tetkikveRadyolojiBilgisiDVO.ozelDurum = "f";
                        }

                        return tetkikveRadyolojiBilgisiDVO;
                    }
                case MedulaSUTGroupEnum.hastaYatisBilgileri:
                    {
                        HizmetKayitIslemleri.hastaYatisBilgisiDVO hastaYatisBilgisiDVO = new HizmetKayitIslemleri.hastaYatisBilgisiDVO();
                        hastaYatisBilgisiDVO.hizmetSunucuRefNo = hizmetSunucuRefNo;
                        hastaYatisBilgisiDVO.sutKodu = sutKodu;
                        hastaYatisBilgisiDVO.bransKodu = bransKodu;
                        hastaYatisBilgisiDVO.drTescilNo = drTescilNo;
                        hastaYatisBilgisiDVO.yatisBaslangicTarihi = GetDVOYatisBaslangicTarihi(accTrx);
                        hastaYatisBilgisiDVO.yatisBitisTarihi = GetDVOYatisBitisTarihi(accTrx, hastaYatisBilgisiDVO.yatisBaslangicTarihi);
                        hastaYatisBilgisiDVO.refakatciGunSayisi = GetDVORefakatciGunSayisi(accTrx, hastaYatisBilgisiDVO.yatisBaslangicTarihi, hastaYatisBilgisiDVO.yatisBitisTarihi);
                        hastaYatisBilgisiDVO.aciklama = GetDVOAciklama(accTrx);
                        hastaYatisBilgisiDVO.yatakKodu = GetDVOYatakKodu();
                        hastaYatisBilgisiDVO.ozelDurum = ozelDurum;
                        hastaYatisBilgisiDVO.cokluOzelDurum = cokluOzelDurum;
                        return hastaYatisBilgisiDVO;
                    }
                case MedulaSUTGroupEnum.kanBilgileri:
                    {
                        HizmetKayitIslemleri.kanBilgisiDVO kanBilgisiDVO = new HizmetKayitIslemleri.kanBilgisiDVO();
                        kanBilgisiDVO.hizmetSunucuRefNo = hizmetSunucuRefNo;
                        kanBilgisiDVO.sutKodu = sutKodu;
                        kanBilgisiDVO.islemTarihi = islemTarihi;
                        kanBilgisiDVO.adet = adet;
                        //kanBilgisiDVO.adetSpecified = true;
                        kanBilgisiDVO.bransKodu = bransKodu;
                        kanBilgisiDVO.drTescilNo = drTescilNo;
                        kanBilgisiDVO.isbtUniteNo = GetDVOIsbtUniteNo();
                        kanBilgisiDVO.isbtBilesenNo = GetDVOIsbtBilesenNo();
                        kanBilgisiDVO.ozelDurum = ozelDurum;
                        kanBilgisiDVO.cokluOzelDurum = cokluOzelDurum;
                        return kanBilgisiDVO;
                    }
                default:
                    {
                        HizmetKayitIslemleri.digerIslemBilgisiDVO digerIslemBilgisiDVO = new HizmetKayitIslemleri.digerIslemBilgisiDVO();
                        digerIslemBilgisiDVO.hizmetSunucuRefNo = hizmetSunucuRefNo;
                        digerIslemBilgisiDVO.sutKodu = sutKodu;
                        digerIslemBilgisiDVO.islemTarihi = islemTarihi;
                        digerIslemBilgisiDVO.adet = adet;
                        //digerIslemBilgisiDVO.adetSpecified = true;
                        digerIslemBilgisiDVO.bransKodu = bransKodu;
                        digerIslemBilgisiDVO.drTescilNo = drTescilNo;
                        digerIslemBilgisiDVO.raporTakipNo = GetDVORaporTakipNo();
                        digerIslemBilgisiDVO.ayniFarkliKesi = GetDVOAyniFarkliKesi(digerIslemBilgisiDVO);
                        digerIslemBilgisiDVO.sagSol = GetDVOSagSol();
                        digerIslemBilgisiDVO.ozelDurum = ozelDurum;
                        digerIslemBilgisiDVO.cokluOzelDurum = cokluOzelDurum;

                        // İstem yapan Dr. un Tescil No ve Branşı
                        ResUser requestDoctor = GetDVOIstemYapanDr();
                        if (requestDoctor != null)
                        {
                            istemYapanDrTescilNo = requestDoctor.DiplomaRegisterNo;

                            SpecialityDefinition requestDoctorSpeciality = requestDoctor.GetSpeciality();
                            if (requestDoctorSpeciality != null)
                                istemYapanDrBrans = requestDoctorSpeciality.Code;
                        }

                        // istemYapanDrTescilNo boş ise drTescilNo set edilir
                        if (string.IsNullOrWhiteSpace(istemYapanDrTescilNo))
                            istemYapanDrTescilNo = digerIslemBilgisiDVO.drTescilNo;

                        // istemYapanDrBrans boş ise bransKodu set edilir
                        if (string.IsNullOrWhiteSpace(istemYapanDrBrans))
                            istemYapanDrBrans = digerIslemBilgisiDVO.bransKodu;

                        DVOBransDrTescilKontrol(ref istemYapanDrBrans, istemYapanDrTescilNo);

                        digerIslemBilgisiDVO.istemYapanDrTescilNo = istemYapanDrTescilNo;
                        digerIslemBilgisiDVO.istemYapanDrBrans = istemYapanDrBrans;

                        return digerIslemBilgisiDVO;
                    }
            }
        }

        public virtual string GetDVOBransKodu(AccountTransaction accTrx)
        {
            string bransKodu = EpisodeAction.GetBranchCodeForMedula();
            if (!string.IsNullOrEmpty(bransKodu))
                return bransKodu;

            if (accTrx.SubEpisodeProtocol.Brans != null)
                return accTrx.SubEpisodeProtocol.Brans.Code;

            return null;
        }

        public virtual string GetDVODrTescilNo(string branchCode)
        {
            if (ProcedureDoctor != null && !string.IsNullOrEmpty(ProcedureDoctor.DiplomaRegisterNo))
                return ProcedureDoctor.DiplomaRegisterNo;

            if (EpisodeAction != null && EpisodeAction.ProcedureDoctor != null && !string.IsNullOrEmpty(EpisodeAction.ProcedureDoctor.DiplomaRegisterNo))
                return EpisodeAction.ProcedureDoctor.DiplomaRegisterNo;

            return Common.GetDoctorRegisterNoByBranchCode(branchCode);
        }

        public virtual ResUser GetDVOIstemYapanDr()
        {
            return RequestedByUser;
        }

        public virtual string GetDVOAciklama(AccountTransaction accTrx)
        {
            return null;
        }
        public virtual string GetDVOAyniFarkliKesi(object DVO)
        {
            // ameliyatveGirisimBilgisiDVO için default kesi bilgisinin "2 : Ana Ameliyat" gitmesi istendi (SurgeryProcedure, SurgeryPackageProcedure gibi override edilenler hariç)
            if (DVO is HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO)
                return "2";

            return null;
        }
        public virtual string GetDVOSagSol()
        {
            if (RightLeftInformation.HasValue)
            {
                if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.ameliyatveGirisimBilgileri)
                    return MedulaSagSol(RightLeftInformation);

                return MedulaSagSol_LR(RightLeftInformation);
            }

            return null;
        }
        public virtual string GetDVOEuroscore()
        {
            return null;
        }
        public virtual string GetDVOAnomali()
        {
            return null;
        }
        public virtual int? GetDVODisTaahhutNo()
        {
            return null;
        }
        public virtual string GetDVOMuayeneTarihi(AccountTransaction accTrx)
        {
            if (accTrx.SubEpisodeProtocol.MedulaProvizyonTarihi.HasValue)
                return accTrx.SubEpisodeProtocol.MedulaProvizyonTarihi.Value.ToString("dd.MM.yyyy");

            return accTrx.MedulaTransactionDate;
        }
        public virtual HizmetKayitIslemleri.tahlilSonucDVO[] GetDVOTahlilSonuclari()
        {
            HizmetKayitIslemleri.tahlilSonucDVO tahlilSonucDVO = new HizmetKayitIslemleri.tahlilSonucDVO();

            if (ProcedureObject is LaboratoryTestDefinition)
                tahlilSonucDVO.tahlilTipi = ((LaboratoryTestDefinition)ProcedureObject).TahlilTipi != null ? ((LaboratoryTestDefinition)ProcedureObject).TahlilTipi.tahlilTipKodu : "0";
            else
                tahlilSonucDVO.tahlilTipi = "0";

            tahlilSonucDVO.sonuc = ".";
            tahlilSonucDVO.birim = ".";

            List<HizmetKayitIslemleri.tahlilSonucDVO> tahlilSonucDVOList = new List<HizmetKayitIslemleri.tahlilSonucDVO> { tahlilSonucDVO };
            return tahlilSonucDVOList.ToArray();
        }
        public virtual string GetDVOBirim()
        {
            return null;
        }
        public virtual string GetDVOSonuc()
        {
            return null;
        }
        public virtual string GetDVOAccession()
        {
            return null;
        }
        public virtual string GetDVOModality()
        {
            return null;
        }
        public virtual string GetDVOYatisBaslangicTarihi(AccountTransaction accTrx)
        {
            if (accTrx.ExternalCode == "510120" && accTrx.SubEpisodeProtocol.MedulaProvizyonTarihi.HasValue) // Gündüz Yatak Tarifesi ise takip tarihi döndürülür
                return accTrx.SubEpisodeProtocol.MedulaProvizyonTarihi.Value.ToString("dd.MM.yyyy");

            return accTrx.MedulaTransactionDate;
        }
        public virtual string GetDVOYatisBitisTarihi(AccountTransaction accTrx, string yatisBaslangicTarihi = null)
        {
            if (accTrx.ExternalCode == "510120")  // Gündüz Yatak Tarifesi için yatış ve çıkış tarihleri aynı gün olmalı
            {
                if (!string.IsNullOrEmpty(yatisBaslangicTarihi))
                    return yatisBaslangicTarihi;

                return GetDVOYatisBaslangicTarihi(accTrx);
            }

            if (accTrx.TransactionDate.HasValue && accTrx.Amount != null)
                return accTrx.TransactionDate.Value.AddDays(accTrx.Amount.Value).ToString("dd.MM.yyyy");

            return null;
        }
        public virtual string GetDVORefakatciGunSayisi(AccountTransaction accTrx, string yatisBaslangicTarihi = null, string yatisBitisTarihi = null)
        {
            return null;
        }
        public virtual string GetDVOYatakKodu()
        {
            return null;
        }
        public virtual string GetDVOIsbtUniteNo()
        {
            return null;
        }
        public virtual string GetDVOIsbtBilesenNo()
        {
            return null;
        }
        public virtual string GetDVORaporTakipNo()
        {
            return null;
        }
        public virtual void GetDVOSetCeneBilgisi(HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
        }
        public virtual string GetDVOOzelDurum(AccountTransaction accTrx)
        {
            return null;
        }
        public virtual string[] GetDVOCokluOzelDurum()
        {
            return null;
        }

        // Hizmet alımı yapılan SubactionProcedure mü ?
        public virtual bool IsExternal()
        {
            if (EpisodeAction.MasterResource != null && EpisodeAction.MasterResource is ResObservationUnit && ((ResObservationUnit)EpisodeAction.MasterResource).IsExternalObservationUnit == true)
                return true;

            return false;
        }

        public static string MedulaSagSol_LR(SurgeryLeftRight? Position)
        {
            if (Position == SurgeryLeftRight.Right)
                return "R";
            else if (Position == SurgeryLeftRight.Left)
                return "L";

            return null;
        }

        public static string MedulaSagSol_LR(RightLeftEnum? Position)
        {
            if (Position == RightLeftEnum.Right)
                return "R";
            else if (Position == RightLeftEnum.Left)
                return "L";

            return null;
        }

        public static string MedulaSagSol(RightLeftEnum? Position)
        {
            if (Position == RightLeftEnum.Right)
                return "1";
            else if (Position == RightLeftEnum.Left)
                return "2";

            return null;
        }

        // Branş Kodu doktorun branşlarından biri değilse, doktorun branşı olarak değiştirilir
        public void DVOBransDrTescilKontrol(ref string bransKodu, string drTescilNo)
        {
            if (!string.IsNullOrWhiteSpace(drTescilNo))
            {
                ResUser resUser = ObjectContext.QueryObjects<ResUser>("DIPLOMAREGISTERNO = '" + drTescilNo + "'").FirstOrDefault();

                if (resUser != null)
                {
                    foreach (ResourceSpecialityGrid rsg in resUser.ResourceSpecialities)
                    {
                        if (!string.IsNullOrWhiteSpace(rsg?.Speciality?.Code))
                            if (bransKodu == rsg.Speciality.Code)
                                return;
                    }

                    SpecialityDefinition speciality = resUser.GetSpeciality();
                    if (!string.IsNullOrWhiteSpace(speciality?.Code))
                        bransKodu = speciality.Code;
                }
            }
        }

        #endregion

        public override string ToString()
        {
            return ObjectID.ToString();
        }

        public virtual bool NotSetWorklist
        {
            get
            {
                return false;
            }

            set
            {
            }
        }

        //IAllocateSpeciality ve ISetWorkListDate için kullanılacak
        public SubActionProcedure MySubActionProcedure
        {
            get
            {
                return (SubActionProcedure)this;
            }

            set
            {
            }
        }

        //IAllocateSpeciality için kullanılacak
        public EpisodeAction MyEpisodeAction
        {
            get
            {
                return (EpisodeAction)EpisodeAction;
            }

            set
            {
            }
        }

        /// <summary>
        /// State back virtual metodu
        /// </summary>
        protected virtual void NoBackStateBack()
        {
            throw new Exception(SystemMessage.GetMessage(992));
        }

        /// <summary>
        /// Cancel virtual metodu.
        /// </summary>
        /// 
        public virtual void SetEntryState()
        {
            if (CurrentStateDefID == null)
            {
                if (ObjectDef.StateDefs.Count > 0)
                {
                    foreach (TTDefinitionManagement.TTObjectStateDef stateDef in ObjectDef.StateDefs)
                    {
                        if (stateDef.IsEntry && stateDef.Status == StateStatusEnum.Uncompleted)
                        {
                            CurrentStateDefID = stateDef.StateDefID;
                            return;
                        }
                    }
                }
                else
                {
                    CurrentStateDefID = SubActionProcedure.States.New;
                }
            }
        }

        //ICheckPaid için kullanılacak, GNL
        public virtual EpisodeAction GetCurrentAction()
        {
            return MyEpisodeAction;
        }

        //ISetWorkListDate için kullanılacak
        public BaseAction MyAction
        {
            get
            {
                return null;
            }

            set
            {
            }
        }

        protected override void OnConstruct()
        {
            if (((ITTObject)this).IsNew == true)
            {
                ID.GetNextValue();
                SetEntryState();
                if (IsOldAction != true)
                    CreationDate = Common.RecTime();
            }
        }

        public virtual void Cancel()
        {
            foreach (SubActionProcedure subActionProcedure in ChildSubActionProcedure)
            {
                if (subActionProcedure.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                    ((ITTObject)subActionProcedure).Cancel();
            }

            if (this is IBaseAppointmentDef)
                CancelMyNewAppoinments();
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

            CancelMyAccountTransactions();
            //CancelDoctorPerformanceDetail();
            DeleteSubactionFromENabiz();
        }

        public void ProcedureSpecialityIsRequired()
        {
            if (ProcedureSpeciality == null)
            {
                throw new Exception(SystemMessage.GetMessage(993));
            }
        }

        public void ProcedureDoctorIsRequired()
        {
            if (ProcedureDoctor == null)
            {
                throw new Exception(SystemMessage.GetMessage(994));
            }
        }

        public virtual BindingList<Appointment> GetMyNewAppointments()
        {
            BindingList<Appointment> retList = (BindingList<Appointment>)ObjectContext.QueryObjects<Appointment>("SUBACTIONPROCEDURE = " + ConnectionManager.GuidToString(ObjectID) + " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.New), "APPDATE");
            foreach (Appointment app in ObjectContext.LocalQuery("APPOINTMENT", "SUBACTIONPROCEDURE = " + ConnectionManager.GuidToString(ObjectID) + " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.New), "APPDATE"))
                if (retList.Contains(app) == false)
                    retList.Add(app);
            return retList;
        }

        public virtual BindingList<Appointment> MyCompletedAppointments
        {
            get
            {
                BindingList<Appointment> retList = (BindingList<Appointment>)ObjectContext.QueryObjects<Appointment>("SUBACTIONPROCEDURE = " + ConnectionManager.GuidToString(ObjectID) + " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.Completed), "APPDATE");
                foreach (Appointment app in ObjectContext.LocalQuery("APPOINTMENT", "SUBACTIONPROCEDURE = " + ConnectionManager.GuidToString(ObjectID) + " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.Completed), "APPDATE"))
                    if (retList.Contains(app) == false)
                        retList.Add(app);
                return retList;
            }
        }

        public virtual BindingList<Appointment> MyCancelledAppointments
        {
            get
            {
                BindingList<Appointment> retList = (BindingList<Appointment>)ObjectContext.QueryObjects<Appointment>("SUBACTIONPROCEDURE = " + ConnectionManager.GuidToString(ObjectID) + " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.Cancelled), "APPDATE");
                foreach (Appointment app in ObjectContext.LocalQuery("APPOINTMENT", "SUBACTIONPROCEDURE = " + ConnectionManager.GuidToString(ObjectID) + " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.Cancelled), "APPDATE"))
                    if (retList.Contains(app) == false)
                        retList.Add(app);
                return retList;
            }
        }

        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Radyoloji_Test_Randevu, TTRoleNames.Radyoloji_Test_R)]
        public static BindingList<Appointment> GetMyNewAppointments(Guid objectID)
        {
            TTObjectContext objContext = new TTObjectContext(true);
            BindingList<Appointment> retList = (BindingList<Appointment>)objContext.QueryObjects<Appointment>("SUBACTIONPROCEDURE = " + ConnectionManager.GuidToString(objectID) + " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.New), "APPDATE");
            foreach (Appointment app in objContext.LocalQuery("APPOINTMENT", "SUBACTIONPROCEDURE = " + ConnectionManager.GuidToString(objectID) + " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.New), "APPDATE"))
                if (retList.Contains(app) == false)
                    retList.Add(app);
            return retList;
        }

        public static BindingList<Appointment> GetMyCompletedAppointments(Guid objectID)
        {
            TTObjectContext objContext = new TTObjectContext(true);
            BindingList<Appointment> retList = (BindingList<Appointment>)objContext.QueryObjects<Appointment>("SUBACTIONPROCEDURE = " + ConnectionManager.GuidToString(objectID) + " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.Completed), "APPDATE");
            foreach (Appointment app in objContext.LocalQuery("APPOINTMENT", "SUBACTIONPROCEDURE = " + ConnectionManager.GuidToString(objectID) + " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.Completed), "APPDATE"))
                if (retList.Contains(app) == false)
                    retList.Add(app);
            return retList;
        }

        public static BindingList<Appointment> GetMyCancelledAppointments(Guid objectID)
        {
            TTObjectContext objContext = new TTObjectContext(true);
            BindingList<Appointment> retList = (BindingList<Appointment>)objContext.QueryObjects<Appointment>("SUBACTIONPROCEDURE = " + ConnectionManager.GuidToString(objectID) + " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.Cancelled), "APPDATE");
            foreach (Appointment app in objContext.LocalQuery("APPOINTMENT", "SUBACTIONPROCEDURE = " + ConnectionManager.GuidToString(objectID) + " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.Cancelled), "APPDATE"))
                if (retList.Contains(app) == false)
                    retList.Add(app);
            return retList;
        }

        public static BindingList<Appointment> MyNotApprovedAppointments(Guid objectID)
        {
            TTObjectContext objContext = new TTObjectContext(true);
            BindingList<Appointment> retList = (BindingList<Appointment>)objContext.QueryObjects<Appointment>("SUBACTIONPROCEDURE = " + ConnectionManager.GuidToString(objectID) + " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.NotApproved), "APPDATE");
            foreach (Appointment app in objContext.LocalQuery("APPOINTMENT", "SUBACTIONPROCEDURE = " + ConnectionManager.GuidToString(objectID) + " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.NotApproved), "APPDATE"))
                if (retList.Contains(app) == false)
                    retList.Add(app);
            return retList;
        }

        public virtual void CheckAndCompleteMyNewAppoinments()
        {
            if (TransDef != null)
            {
                foreach (Appointment app in GetMyNewAppointments())
                {
                    if (TransDef.ToStateDef.Status == StateStatusEnum.CompletedUnsuccessfully || TransDef.ToStateDef.Status == StateStatusEnum.Cancelled)
                    {
                        app.CurrentStateDefID = Appointment.States.Cancelled;
                    }

                    if (TransDef.ToStateDef.Status == StateStatusEnum.Uncompleted || TransDef.ToStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                    {
                        app.CurrentStateDefID = Appointment.States.Completed;
                    }
                }
            }
        }

        public virtual void CompleteMyNewAppoinments()
        {
            foreach (Appointment app in GetMyNewAppointments())
            {
                app.CurrentStateDefID = Appointment.States.Completed;
            }
        }

        public virtual void CancelMyNewAppoinments()
        {
            foreach (Appointment app in GetMyNewAppointments())
            {
                app.CurrentStateDefID = Appointment.States.Cancelled;
            }
        }

        public virtual void CancelMyUnCompletedAppoinments()
        {
            foreach (Appointment app in GetMyNewAppointments())
            {
                app.CurrentStateDefID = Appointment.States.Cancelled;
            }

            foreach (Appointment app in MyNotApprovedAppointments(ObjectID))
            {
                app.CurrentStateDefID = Appointment.States.Cancelled;
            }
        }

        public static string GetFullAppointmentDescription(SubActionProcedure subactionProcedure)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Appointment app in subactionProcedure.GetMyNewAppointments())
            {
                builder.Append("Açıklama : " + app.Notes + "\r\n");
                if (app.BreakAppointment == true)
                    builder.Append(TTUtils.CultureService.GetText("M27267", "Zaman  : Saatsiz Randevu \r\n"));
                else
                    builder.Append("Zaman  : " + app.AppDate.Value.ToLongDateString() + " " + app.StartTime.Value.ToShortTimeString() + " - " + app.EndTime.Value.ToShortTimeString() + "\r\n");
                if (app.Resource.ObjectDef.Description == null)
                {
                    builder.Append(app.Resource.ObjectDef.Name.ToString() + " : " + app.Resource.Name + "\r\n");
                }
                else
                {
                    builder.Append(app.Resource.ObjectDef.Description.ToString() + " : " + app.Resource.Name + "\r\n");
                }

                builder.Append(app.ObjectDef.Description + " : " + (app.MasterResource != null ? app.MasterResource.Name : "") + "\r\n");
                builder.Append("Durum  : " + app.CurrentStateDef.ToString() + "\r\n");
                TimeSpan dtDiff = app.AppDate.Value.Subtract(DateTime.Now.Date);
                if (dtDiff.TotalDays > -1) // Randevu aynı günde yada ilerdeyse
                {
                    if (dtDiff.TotalDays == 0) //aynı gündeyse
                    {
                        dtDiff = app.StartTime.Value.TimeOfDay.Subtract(DateTime.Now.TimeOfDay);
                        if (dtDiff.TotalMinutes > -1) // aynı günde ilerde ise
                        {
                            if (dtDiff.TotalMinutes < 60)
                                builder.Append("Zamanlama : Randevu " + Math.Round(dtDiff.TotalMinutes) + " dakika sonra.\r\n");
                            else
                                builder.Append("Zamanlama : Randevu " + Math.Round(dtDiff.TotalHours) + " saat sonra.\r\n");
                        }
                        else
                        {
                            //double nDuration = app.EndTime.Value.Subtract(app.StartTime.Value).TotalHours;
                            //if(nDuration < Math.Abs(dtDiff.TotalHours))
                            if (app.EndTime.Value.TimeOfDay.Subtract(DateTime.Now.TimeOfDay).TotalMinutes > 0)
                                builder.Append(TTUtils.CultureService.GetText("M27271", "Zamanlama : süresi geçiyor\r\n"));
                            else
                                builder.Append(TTUtils.CultureService.GetText("M27272", "Zamanlama : süresi geçmiş\r\n"));
                        }
                    }
                    else
                        builder.Append("Zamanlama : Randevu " + Math.Round(dtDiff.TotalDays) + " gün sonra.\r\n");
                }
                else
                {
                    builder.Append(TTUtils.CultureService.GetText("M27272", "Zamanlama : süresi geçmiş\r\n"));
                }

                builder.Append(TTUtils.CultureService.GetText("M26764", "Referans No :") + (app.AppointmentID == null ? "" : (app.AppointmentID.Value == null ? "" : app.AppointmentID.Value.ToString())));
                builder.Append("\r\n");
                builder.Append("\r\n");
            }

            return builder.ToString();
        }

        public List<AccountTransaction> CancelMyAccountTransactions(bool exceptPaidPatientShare = false)
        {
            List<AccountTransaction> returnList = new List<AccountTransaction>();

            foreach (AccountTransaction at in AccountTransactions)
            {
                if (at.CurrentStateDefID != AccountTransaction.States.Cancelled)
                {
                    if (at.IsAllowedToCancel == false)
                    {
                        if (!exceptPaidPatientShare || (exceptPaidPatientShare && !at.IsPaidPatientShare()))
                            throw new TTException(TTUtils.CultureService.GetText("M26178", "İşlem hareketi '") + at.CurrentStateDef.DisplayText + "' durumunda olduğu için iptal edilemez. Öncelikle ödeme/faturalama işleminin iptal edilmesi gerekmektedir!\r\n" + "Hizmet : " + at.ExternalCode + " " + at.Description);
                    }

                    at.CurrentStateDefID = AccountTransaction.States.Cancelled;
                    returnList.Add(at);
                }
            }
            return returnList;
        }

        public void MedulaProcedureEntry()
        {
            List<SubActionProcedure> spList = new List<SubActionProcedure>() { this };
            AccountTransaction.MedulaProcedureEntry(spList);
        }

        public void MedulaProcedureEntryCancel()
        {
            List<SubActionProcedure> spList = new List<SubActionProcedure>() { this };
            AccountTransaction.MedulaProcedureEntryCancel(spList);
        }

        // Ödenmiş hasta payları için "Faturalanmış işlem iptal edilemez" hatası vermeden iptal eder
        //public void CancelMyAccountTransactionsExceptPaid()
        //{
        //    foreach (AccountTransaction at in this.AccountTransactions)
        //    {
        //        if (at.CurrentStateDefID != AccountTransaction.States.Cancelled)
        //        {
        //            if (at.IsAllowedToCancel == false)
        //            {
        //                if (at.IsPaidPatientShare())
        //                    InfoBox.Alert("Hastanın yapmış olduğu ödeme mevcuttur.\r\n" + "Hizmet : " + at.ExternalCode + " " + at.Description);
        //                else
        //                    throw new TTException("İşlem hareketi '" + at.CurrentStateDef.DisplayText + "' durumunda olduğu için iptal edilemez. Öncelikle ödeme/faturalama işleminin iptal edilmesi gerekmektedir!\r\n" + "Hizmet : " + at.ExternalCode + " " + at.Description);
        //            }
        //            else
        //                at.CurrentStateDefID = AccountTransaction.States.Cancelled;
        //        }
        //    }
        //}

        public bool IsPatientPaymentExists()
        {
            foreach (AccountTransaction at in AccountTransactions)
            {
                if (at.IsPaidPatientShare())
                    return true;
            }

            return false;
        }

        public Currency? GetProcedurePrice()
        {
            try
            {
                if (SubEpisode != null && SubEpisode.Episode != null)
                {
                    SubEpisodeProtocol sep = SubEpisode.OpenSubEpisodeProtocol;
                    if (sep != null)
                    {
                        DateTime? date;

                        if (PricingDate != null)
                            date = PricingDate;
                        else if (ActionDate != null)
                            date = ActionDate;
                        else
                            date = Common.RecTime();
                        ArrayList col = new ArrayList();
                        col = sep.Protocol.CalculatePrice(ProcedureObject, SubEpisode.Episode.PatientStatus, null, date, SubEpisode.Episode.Patient.AgeCompleted);
                        foreach (ManipulatedPrice mpd in col)
                            return mpd.Price;
                    }
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public virtual void ChangeMyProtocol(SubEpisodeProtocol pSEP)
        {
            if (pSEP == null)
                throw new TTException(TTUtils.CultureService.GetText("M27247", "Yeniden fiyatlandırma yapılacak takip boş olamaz."));

            if (AccountTransactions.Count == 0) // Henüz ücretlenmemiş bir SubactionProcedure için metod çalışırsa ücretlendirme yapmasın diye eklendi
                return;

            List<AccountTransaction> cancelledAtList = CancelMyAccountTransactions();   // CancelMyAccountTransactionsExceptPaid();

            DateTime pricingDate = Common.RecTime();
            if (PricingDate.HasValue) // PricingDate dolu ise fiyat hesaplamada bu tarih kullanılır
                pricingDate = PricingDate.Value;
            else if (ActionDate.HasValue) // PricingDate boş ActionDate dolu ise fiyat hesaplamada bu tarih kullanılır
                pricingDate = ActionDate.Value;

            ArrayList col = new ArrayList();
            if (SubActionProcPricingDet.Count == 0)
                col = pSEP.Protocol.CalculatePrice(ProcedureObject, EpisodeAction.Episode.PatientStatus, null, pricingDate, EpisodeAction.Episode.Patient.AgeCompleted);
            else
            {
                TTObjectContext context = new TTObjectContext(false);
                foreach (SubActionProcPricingDet subActProcPrice in SubActionProcPricingDet)
                {
                    double patientPrice = 0;
                    double payerPrice = 0;
                    ManipulatedPrice mypd = new ManipulatedPrice(context);
                    mypd.ExternalCode = subActProcPrice.ExternalCode;
                    mypd.Description = subActProcPrice.Description;
                    if (subActProcPrice.PatientPrice != null)
                        patientPrice = (double)subActProcPrice.PatientPrice;
                    if (subActProcPrice.PayerPrice != null)
                        payerPrice = (double)subActProcPrice.PayerPrice;
                    mypd.Price = patientPrice + payerPrice;
                    mypd.PatientPrice = patientPrice;
                    mypd.PayerPrice = payerPrice;
                    col.Add(mypd);
                }
            }

            if (col.Count == 0)
                throw new TTException(SystemMessage.GetMessageV3(950, new string[] { ProcedureObject.Name }));

            foreach (ManipulatedPrice mpd in col)
            {
                if (mpd.PatientPrice == 0 && mpd.PayerPrice == 0)
                    pSEP.AddAccountTransaction(AccountOwnerType.PAYER, this, mpd, null, AccountOperationTimeEnum.PRE);

                if (mpd.PayerPrice > 0)
                    pSEP.AddAccountTransaction(AccountOwnerType.PAYER, this, mpd, null, AccountOperationTimeEnum.PRE);

                if (mpd.PatientPrice > 0 && !IsPatientPaymentExists()) // Ödenmiş hasta payı yoksa oluşturulur
                    pSEP.AddAccountTransaction(AccountOwnerType.PATIENT, this, mpd, null, AccountOperationTimeEnum.PRE);
            }

            List<AccountTransaction> newAtList = AccountTransactions.Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled).ToList();
            AccountTransaction.ControlAndCopyAfterChangeMyProtocol(cancelledAtList, newAtList); // İptal edilen AccTrx ler üzerindeki bilgileri, yeni oluşturulan AccTrx lere kopyalar

            ApplyDiscountPercent();
        }

        // İndirim ve Artırım yeni acctrx lere uygulanır
        public void ApplyDiscountPercent()
        {
            if (DiscountPercent.HasValue == true && DiscountPercent.Value > 0)
            {
                foreach (AccountTransaction at in AccountTransactions)
                {
                    if (at.CurrentStateDefID == AccountTransaction.States.New || at.CurrentStateDefID == AccountTransaction.States.MedulaDontSend)
                    {
                        if (DiscountPercent > 100)
                        {
                            at.UnitPriceOrg = Math.Round((double)(at.UnitPriceOrg * (DiscountPercent / 100)), 8);
                            at.UnitPrice = Math.Round((double)(at.UnitPrice * (DiscountPercent / 100)), 2);
                            at.Description = at.Description + " (%" + (DiscountPercent - 100).ToString() + " ARTIRIM)";
                        }
                        else
                        {
                            at.UnitPriceOrg = Math.Round((double)(at.UnitPriceOrg * (1 - (DiscountPercent / 100))), 8);
                            at.UnitPrice = Math.Round((double)(at.UnitPrice * (1 - (DiscountPercent / 100))), 2);
                            at.Description = at.Description + " (%" + DiscountPercent.ToString() + " İNDİRİM)";
                        }
                    }
                }
            }
        }

        public bool IsAttributeExists(System.Type AttributeType)
        {
            bool found = false;
            foreach (TTObjectDefAttribute attribute in ObjectDef.AllAttributes)
            {
                if (attribute.AttributeDef.CodeName == AttributeType.Name)
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        protected static void ClearAppointmentCarrierDynamicFields(List<AppointmentCarrier> appointmentCarrierList)
        {
            foreach (AppointmentCarrier appointmentCarrier in appointmentCarrierList)
            {
                appointmentCarrier.AppointmentCount = 1;
                appointmentCarrier.AppointmentDuration = 15;
                appointmentCarrier.AppointmentType = null;
                appointmentCarrier.MasterResourceFilter = "";
            }
        }

        public virtual bool IsCashOfficeBlock(List<InvoiceBlockingDefinition> blockingStateDefList = null, bool? cashOfficeBlockingActive = null)
        {
            if (cashOfficeBlockingActive.HasValue == false)
                cashOfficeBlockingActive = SystemParameter.GetParameterValue("CASHOFFICEBLOCKINGACTIVE", "FALSE") == "TRUE" ? true : false;

            if (cashOfficeBlockingActive == false)
                return false;

            if (CurrentStateDefID.HasValue == false && EpisodeAction.CurrentStateDefID.HasValue == false)
                return false;

            if (blockingStateDefList == null)
                blockingStateDefList = new List<InvoiceBlockingDefinition>();

            if (blockingStateDefList.Count == 0)
                blockingStateDefList = ObjectContext.QueryObjects<InvoiceBlockingDefinition>("ISACTIVE = 1 AND CASHOFFICEBLOCK = 1").ToList();

            if (CurrentStateDefID.HasValue && blockingStateDefList.Any(x => x.StateDefId == CurrentStateDefID && x.Type == EAorSPEnum.SubActionProcedure))
                return true;

            if (EpisodeAction.CurrentStateDefID.HasValue && blockingStateDefList.Any(x => x.StateDefId == EpisodeAction.CurrentStateDefID && x.Type == EAorSPEnum.EpisodeAction))
                return true;

            return false;
        }

        //public void AccountOperation(AccountOperationTimeEnum pPreAccounting, SubEpisodeProtocol sep = null)
        //{
        //    AccountOperation(pPreAccounting, null, null, null, sep);
        //}

        //public void AccountOperation(AccountOperationTimeEnum pPreAccounting, DateTime? packageStartDate, DateTime? packageEndDate)
        //{
        //    AccountOperation(pPreAccounting, packageStartDate, packageEndDate, null);
        //}

        public virtual void AccountOperation(AccountOperationTimeEnum pPreAccounting = AccountOperationTimeEnum.PREPOST, SubEpisodeProtocol outSEP = null)
        {
            if (AccountTransactions.Any(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled)) // İptalden farklı AccTrx i varsa çıkılır
                return;

            if (!Eligible.HasValue) // Eligible null ise true yapılır
                Eligible = true;

            // Ücretlenmemesi gereken durumlar
            if (IsOldAction == true || IsCancelled == true || Eligible != true || ProcedureObject == null || ProcedureObject.Chargable != true)
                return;

            if (SubEpisode == null)
                throw new TTException("Ücretlendirilecek hizmetin altvaka bilgisine ulaşılamıyor. (Hizmet: " + ProcedureObject.Code + " " + ProcedureObject.Name + ")");

            SubEpisodeProtocol sep = null;
            if (outSEP != null)
                sep = outSEP;
            else
                sep = SubEpisode.OpenSubEpisodeProtocol;

            if (sep == null)
                throw new TTException(SystemMessage.GetMessage(663));

            // Günübirlik takip gerektiren hizmetler için artık yatış action ı başlatılıp SubEpisode ve SEP oradan oluşturulacağı için kapatıldı )
            //if (AccountTransactions.Count == 0) // Takip oluşturması gereken hizmetler için, sadece bu metod ilk kez çağırıldığında takip oluşturması için. 
            //    CreateSEPForNewProcedure(ref sep);

            DateTime pricingDate = Common.RecTime();
            if (PricingDate.HasValue) // PricingDate dolu ise fiyat hesaplamada bu tarih kullanılır
                pricingDate = PricingDate.Value;
            else if (ActionDate.HasValue) // PricingDate boş ActionDate dolu ise fiyat hesaplamada bu tarih kullanılır
                pricingDate = ActionDate.Value;

            ArrayList col = new ArrayList();
            if (SubActionProcPricingDet.Count == 0)
                col = sep.Protocol.CalculatePrice(ProcedureObject, EpisodeAction.Episode.PatientStatus, null, pricingDate, EpisodeAction.Episode.Patient.AgeCompleted);
            else
            {
                TTObjectContext context = new TTObjectContext(false);
                foreach (SubActionProcPricingDet subActProcPrice in SubActionProcPricingDet)
                {
                    double patientPrice = 0;
                    double payerPrice = 0;
                    ManipulatedPrice mypd = new ManipulatedPrice(context);
                    mypd.ExternalCode = subActProcPrice.ExternalCode;
                    mypd.Description = subActProcPrice.Description;
                    if (subActProcPrice.PatientPrice != null)
                        patientPrice = (double)subActProcPrice.PatientPrice;
                    if (subActProcPrice.PayerPrice != null)
                        payerPrice = (double)subActProcPrice.PayerPrice;
                    mypd.Price = patientPrice + payerPrice;
                    mypd.PatientPrice = patientPrice;
                    mypd.PayerPrice = payerPrice;
                    col.Add(mypd);
                }
            }

            if (col.Count == 0)
                throw new TTException(SystemMessage.GetMessageV3(950, new string[] { ProcedureObject.Name }));

            foreach (ManipulatedPrice mpd in col)
            {
                if (mpd.PatientPrice == 0 && mpd.PayerPrice == 0)
                    sep.AddAccountTransaction(AccountOwnerType.PAYER, this, mpd, null, AccountOperationTimeEnum.PRE);

                if (mpd.PayerPrice > 0)
                    sep.AddAccountTransaction(AccountOwnerType.PAYER, this, mpd, null, AccountOperationTimeEnum.PRE);

                if (mpd.PatientPrice > 0)
                    sep.AddAccountTransaction(AccountOwnerType.PATIENT, this, mpd, null, AccountOperationTimeEnum.PRE);
            }

            ApplyDiscountPercent();
        }

        public void AccountOperationAttribute()
        {
            if (IsOldAction != true && Eligible == true && ProcedureObject.Chargable == true)
            {
                // Normal EpisodeAction a sahip SubActionProcedure lerin paralandirilmasinda alltaki if bloguna girecek.
                if (EpisodeAction != null)
                {
                    if (EpisodeAction.TransDef != null)
                    {
                        if (Common.IsTransitionAttributeExists(typeof(AccountOperationAttribute), EpisodeAction.TransDef))
                        {
                            if (CurrentStateDef.Status != StateStatusEnum.Cancelled)
                            {
                                AccountOperationTimeEnum pPreAccounting = (AccountOperationTimeEnum)EpisodeAction.TransDef.AllAttributes["AccountOperationAttribute"].Parameters["PreAccounting"].Value;
                                AccountOperation(pPreAccounting);
                            }
                        }
                    }

                    if (EpisodeAction.CurrentStateDef != null)
                    {
                        if (Common.IsStateAttributeExists(typeof(AccountOperationStateAttribute), EpisodeAction.CurrentStateDef))
                        {
                            if (CurrentStateDef.Status != StateStatusEnum.Cancelled)
                            {
                                AccountOperationTimeEnum pPreAccounting = (AccountOperationTimeEnum)EpisodeAction.CurrentStateDef.AllAttributes["AccountOperationStateAttribute"].Parameters["PreAccounting"].Value;
                                AccountOperation(pPreAccounting);
                            }
                        }
                    }
                }

                // SubActıonProcedureFlowable in ChildSubactionProcedure u paralandirtilmak istendiginde alltaki if bloguna girecek.
                if (MasterSubActionProcedure != null)
                {
                    if (MasterSubActionProcedure.TransDef != null)
                    {
                        if (Common.IsTransitionAttributeExists(typeof(AccountOperationAttribute), MasterSubActionProcedure.TransDef))
                        {
                            if (CurrentStateDef.Status != StateStatusEnum.Cancelled)
                            {
                                AccountOperationTimeEnum pPreAccounting = (AccountOperationTimeEnum)MasterSubActionProcedure.TransDef.AllAttributes["AccountOperationAttribute"].Parameters["PreAccounting"].Value;
                                AccountOperation(pPreAccounting);
                            }
                        }
                    }

                    if (MasterSubActionProcedure.CurrentStateDef != null)
                    {
                        if (Common.IsStateAttributeExists(typeof(AccountOperationStateAttribute), MasterSubActionProcedure.CurrentStateDef))
                        {
                            if (CurrentStateDef.Status != StateStatusEnum.Cancelled)
                            {
                                AccountOperationTimeEnum pPreAccounting = (AccountOperationTimeEnum)MasterSubActionProcedure.CurrentStateDef.AllAttributes["AccountOperationStateAttribute"].Parameters["PreAccounting"].Value;
                                AccountOperation(pPreAccounting);
                            }
                        }
                    }
                }

                //SubActionProcedureFlowable ın kendisini paralandirmak icin asagidaki if blogu calisacak.
                if (this is SubactionProcedureFlowable)
                {
                    if (TransDef != null)
                    {
                        if (Common.IsTransitionAttributeExists(typeof(AccountOperationAttribute), TransDef))
                        {
                            if (CurrentStateDef.Status != StateStatusEnum.Cancelled)
                            {
                                AccountOperationTimeEnum pPreAccounting = (AccountOperationTimeEnum)TransDef.AllAttributes["AccountOperationAttribute"].Parameters["PreAccounting"].Value;
                                AccountOperation(pPreAccounting);
                            }
                        }
                    }

                    if (CurrentStateDef != null)
                    {
                        if (Common.IsStateAttributeExists(typeof(AccountOperationStateAttribute), CurrentStateDef))
                        {
                            if (CurrentStateDef.Status != StateStatusEnum.Cancelled)
                            {
                                AccountOperationTimeEnum pPreAccounting = (AccountOperationTimeEnum)CurrentStateDef.AllAttributes["AccountOperationStateAttribute"].Parameters["PreAccounting"].Value;
                                AccountOperation(pPreAccounting);
                            }
                        }
                    }
                }
            }
        }

        public List<DPDetailedErrorTypes> CreateNewSendDoctorPerformanceLog(SendToDoctorPerformance sendToDP, string methodName)
        {
            bool errorOccured = false;
            List<DPDetailedErrorTypes> errors = new List<DPDetailedErrorTypes>();
            SendDoctorPerformanceLog performanceLog = new SendDoctorPerformanceLog();
            if (Episode == null)
            {
                performanceLog.CreateNewSendDoctorPerformanceLog(sendToDP.ObjectContext, sendToDP, DPDetailedErrorTypes.EPISODENULL, "EPISODE null.", methodName);
                //errorOccured = true;
                errors.Add(DPDetailedErrorTypes.EPISODENULL);
            }
            else if (Episode.Patient == null)
            {
                performanceLog.CreateNewSendDoctorPerformanceLog(sendToDP.ObjectContext, sendToDP, DPDetailedErrorTypes.EPISODE_PATIENTNULL, "EPISODE.PATIENT null.", methodName);
                //errorOccured = true;
                errors.Add(DPDetailedErrorTypes.EPISODE_PATIENTNULL);
            }

            var _procedureDoctor = GetPerformanceDoctor();
            if (_procedureDoctor == null)
            {
                performanceLog.CreateNewSendDoctorPerformanceLog(sendToDP.ObjectContext, sendToDP, DPDetailedErrorTypes.PROCEDUREDOCTORNULL, "_procedureDoctor null.", methodName);
                //errorOccured = true;
                errors.Add(DPDetailedErrorTypes.PROCEDUREDOCTORNULL);
            }
            else if (_procedureDoctor.Person == null)
            {
                performanceLog.CreateNewSendDoctorPerformanceLog(sendToDP.ObjectContext, sendToDP, DPDetailedErrorTypes.PROCEDUREDOCTOR_PERSONNULL, "_procedureDoctor.Person null", methodName);
                //errorOccured = true;
                errors.Add(DPDetailedErrorTypes.PROCEDUREDOCTOR_PERSONNULL);
            }
            else if (_procedureDoctor.Person.UniqueRefNo.HasValue == false)
            {
                performanceLog.CreateNewSendDoctorPerformanceLog(sendToDP.ObjectContext, sendToDP, DPDetailedErrorTypes.PROCEDUREDOCTOR_PERSON_UNIQUEREFNONULL, "_procedureDoctor.Person.UniqueRefNo null (PhysiciaonCode)", methodName);
                //errorOccured = true;
                errors.Add(DPDetailedErrorTypes.PROCEDUREDOCTOR_PERSON_UNIQUEREFNONULL);
            }

            if (ProcedureObject == null)
            {
                performanceLog.CreateNewSendDoctorPerformanceLog(sendToDP.ObjectContext, sendToDP, DPDetailedErrorTypes.PROCEDUREOBJECTNULL, "ProcedureObject null", methodName);
                errors.Add(DPDetailedErrorTypes.PROCEDUREOBJECTNULL);
            }
            else if (string.IsNullOrEmpty(ProcedureObject.GILCode))
            {
                performanceLog.CreateNewSendDoctorPerformanceLog(sendToDP.ObjectContext, sendToDP, DPDetailedErrorTypes.PROCEDUREOBJECT_GILCODENULLOREMPTY, "ProcedureObject.GILCode null ya da empty", methodName);
                errors.Add(DPDetailedErrorTypes.PROCEDUREOBJECT_GILCODENULLOREMPTY);
            }

            if (Amount.HasValue == false)
            {
                performanceLog.CreateNewSendDoctorPerformanceLog(sendToDP.ObjectContext, sendToDP, DPDetailedErrorTypes.AMOUNTNULL, "Amount null", methodName);
                //errorOccured = true;
                errors.Add(DPDetailedErrorTypes.AMOUNTNULL);
            }

            if (PerformedDate.HasValue == false)
            {
                performanceLog.CreateNewSendDoctorPerformanceLog(sendToDP.ObjectContext, sendToDP, DPDetailedErrorTypes.PERFORMEDDATENULL, "PerformedDate null", methodName);
                //errorOccured = true;
                errors.Add(DPDetailedErrorTypes.PERFORMEDDATENULL);
            }

            if (SubEpisode == null)
            {
                performanceLog.CreateNewSendDoctorPerformanceLog(sendToDP.ObjectContext, sendToDP, DPDetailedErrorTypes.SUBEPISODENULL, "SubEpisode null", methodName);
                //errorOccured = true;
                errors.Add(DPDetailedErrorTypes.SUBEPISODENULL);
            }
            else if (SubEpisode.Speciality == null)
            {
                performanceLog.CreateNewSendDoctorPerformanceLog(sendToDP.ObjectContext, sendToDP, DPDetailedErrorTypes.SUBEPISODE_SPECIALITYNULL, "SubEpisode.Speciality null", methodName);
                //errorOccured = true;
                errors.Add(DPDetailedErrorTypes.SUBEPISODE_SPECIALITYNULL);
            }
            else if (string.IsNullOrEmpty(SubEpisode.Speciality.Code))
            {
                performanceLog.CreateNewSendDoctorPerformanceLog(sendToDP.ObjectContext, sendToDP, DPDetailedErrorTypes.SUBEPISODE_SPECIALITY_CODENULLOREMPTY, "SubEpisode.Speciality.Code null ya da empty", methodName);
                //errorOccured = true;
                errors.Add(DPDetailedErrorTypes.SUBEPISODE_SPECIALITY_CODENULLOREMPTY);
            }
            return errors;
            //return errorOccured;
        }

        public PerfRuleCheckerResult<IList<PerformanceDetailNoteDto>> SendDoctorPerformanceDetail(SendToDoctorPerformance sendToDP)
        {
            try
            {
                if (string.IsNullOrEmpty(ProcedureObject.GILCode))
                {
                    sendToDP.Status = DPStatus.DontSend;
                    return new PerfRuleCheckerResult<IList<PerformanceDetailNoteDto>>() { IsSuccess = true };
                }
                List<DPDetailedErrorTypes> errors = CreateNewSendDoctorPerformanceLog(sendToDP, "SendDoctorPerformanceDetail");
                if (errors.Count > 0)
                {
                    PerfRuleCheckerResult<IList<PerformanceDetailNoteDto>> cathResult = new PerfRuleCheckerResult<IList<PerformanceDetailNoteDto>>();
                    cathResult.IsSuccess = false;
                    cathResult.ErrorMessage = "Doktor Performans için gerekli bir property eksik. Detaylı log için SENDTODOCTORPERFORMANCELOG tablosuna bakın.";
                    if (errors.Contains(DPDetailedErrorTypes.PERFORMEDDATENULL))
                        sendToDP.Status = DPStatus.DontSend;
                    return cathResult;
                }

                var detailDto = new TTUtils.PerformanceDetailDto();
                detailDto.PatientId = Episode.Patient.ObjectID;
                detailDto.EpisodeId = Episode.ObjectID;
                detailDto.ProcedureId = ObjectID;

                // Başvuru No şimdilik boş geçildi, Medula Başvuru No veya SEPMaster ın ObjectID si gönderilebilir daha sonra. 
                // Ama Başvuru No değiştiği veya yeni SEPMaster oluştuğu durumlarda sorun olacak, önceden giden performans kayıtları için güncelleme gerekecek ??? )
                //detailDto.ApplicationNo = "";   
                var _procedureDoctor = GetPerformanceDoctor();
                if (_procedureDoctor != null && _procedureDoctor.Person != null && _procedureDoctor.Person.UniqueRefNo.HasValue)
                    detailDto.PhysicianCode = _procedureDoctor.Person.UniqueRefNo.Value.ToString();

                detailDto.ProcedureCode = ProcedureObject.GILCode;
                detailDto.ProcedureAmount = Convert.ToDecimal(Amount);
                detailDto.ProcedureDate = PerformedDate.Value;

                // TODO : AyniFarkliKesi nin child ı olan BaseSurgeryAndManipulationProcedure gibi diğer objelerin de aşağıya eklenmesi gerekebilir
                if (this is BaseSurgeryAndManipulationProcedure && ((BaseSurgeryAndManipulationProcedure)this).AyniFarkliKesi != null)
                    detailDto.Incision = ((BaseSurgeryAndManipulationProcedure)this).AyniFarkliKesi.ayniFarkliKesiKodu;

                if (SubEpisode != null && SubEpisode.Speciality != null)
                    detailDto.BranchCode = SubEpisode.Speciality.Code;
                else if (AccountTransactions.Count > 0)
                {
                    object dvo = GetDVO(AccountTransactions[0]);
                    if (dvo != null)
                    {
                        object branchCode = dvo.GetType().GetProperty("bransKodu").GetValue(dvo, null);
                        if (branchCode != null)
                            detailDto.BranchCode = branchCode.ToString();
                    }
                }

                if (SubEpisode != null && SubEpisode.ResSection != null)
                    detailDto.SectionId = SubEpisode.ResSection.ObjectID;
                else if (this is SubactionProcedureFlowable)
                    detailDto.SectionId = ((SubactionProcedureFlowable)this).MasterResource.ObjectID;
                else
                    detailDto.SectionId = EpisodeAction.MasterResource.ObjectID;

                var ruleEngineService = TTUtils.PerfRuleEngineServiceFactory.Instance;
                PerfRuleCheckerResult<IList<PerformanceDetailNoteDto>> result;
                if (ruleEngineService != null)
                    result = ruleEngineService.Performance(detailDto);
                else
                {
                    result = new PerfRuleCheckerResult<IList<PerformanceDetailNoteDto>>();
                    result.IsSuccess = false;
                    result.ErrorMessage = "PerfRuleEngineServiceFactory.Instace null. PerfRuleEngineService.cs yi ilgili projeye ekleyip Instance oluşturun.";
                }

                if (result.IsSuccess)
                    sendToDP.Status = DPStatus.Sent;
                if (result.ErrorMessage == TTUtils.CultureService.GetText("M26688", "Performans işlemi hatalı.İlgili performans dönemi kapatılmış."))
                    sendToDP.Status = DPStatus.DpTermClosed;

                return result;
            }
            catch (Exception ex)
            {
                PerfRuleCheckerResult<IList<PerformanceDetailNoteDto>> cathResult = new PerfRuleCheckerResult<IList<PerformanceDetailNoteDto>>();
                cathResult.IsSuccess = false;
                cathResult.ErrorMessage = ex.ToString();
                return cathResult;
            }
        }


        public void CreateSEPForNewProcedure(ref SubEpisodeProtocol parentSEP)
        {
            // Kendi action ı SubEpisode ve SEP oluşturduğu için burada tekrar SEP oluşturmaması gereken objeler
            if (this is PhysiotherapyOrderDetail || this is FTRPackageProcedure)
                return;

            if (ProcedureObject != null && (ProcedureObject.DailyMedulaProvisionNecessity == true || ProcedureObject.MedulaProvisionTedaviTipi != null))
            {
                if (parentSEP != null && parentSEP.MedulaTedaviTuru.tedaviTuruKodu == "A") // Hizmet ayaktan bir takip içindeyse günübirlik takip eklensin
                {
                    SubEpisodeProtocol.SEPProperty SEPProperty = new SubEpisodeProtocol.SEPProperty();

                    if (ProcedureObject.DailyMedulaProvisionNecessity == true)
                        SEPProperty.tedaviTuru = TedaviTuru.GetTedaviTuru("G");
                    else
                        SEPProperty.tedaviTuru = TedaviTuru.GetTedaviTuru("A");

                    SEPProperty.tedaviTipi = ProcedureObject.MedulaProvisionTedaviTipi;

                    SubEpisodeProtocol sep = parentSEP.CloneForNewSEP(SEPCloneTypeEnum.NewDailyProcedure, SEPProperty);
                    if (sep.IsSGK)
                        sep.GetProvisionFromMedula(parentSEP.MedulaTakipNo);

                    parentSEP = sep;
                }
            }
        }

        // Toplu Faturaya Hazır veya Toplu Faturalandı durumunda Kurum Faturası varsa yeni bir hizmet charge edilemesin kontrolü
        public void ControlSGKPayerInvoiceStatus()
        {
            if (!(EpisodeAction is ProcedureMaterialAdding || EpisodeAction is PackageAdding))
            {
                if (SystemParameter.GetParameterValue("INVOICEBYSUBEPISODE", "FALSE") == "TRUE")
                {
                    if (SubEpisode != null)
                    {
                        if (PayerInvoice.GetReadyAndColInvByEpisodeAndPISubEpisode(ObjectContext, EpisodeAction.Episode.ObjectID.ToString(), SubEpisode.ObjectID.ToString()).Count > 0)
                        {
                            string message = "İçinde bulunduğu altvaka Toplu Faturaya Hazır veya Toplu Faturalandı durumunda olduğu için hizmet ücretlendirilemez.\r\nHizmet girişi yapmak istiyorsanız öncelikle Toplu Faturaya Hazır veya Toplu Faturalandı durumundaki kurum faturası işlemini iptal ediniz.\r\n(Altvaka: " + SubEpisode.ProtocolNo.ToString();
                            if (SubEpisode.ResSection != null)
                                message += " " + SubEpisode.ResSection.Name;
                            message += ")";
                            throw new TTException(message);
                        }
                    }
                }
                else // Kurum Faturasını altvaka bazında kesmeyen XXXXXXlerde
                {
                    // Ayaktan hasta ise, 1 yada daha fazla kurum faturası varsa hata verilir
                    if (EpisodeAction.Episode.PatientStatus == PatientStatusEnum.Outpatient)
                    {
                        if (PayerInvoice.GetReadyAndColInvByEpisode(ObjectContext, EpisodeAction.Episode.ObjectID.ToString()).Count > 0)
                            throw new TTException(SystemMessage.GetMessage(995));
                    }
                    else // Yatan hasta ise, 2 yada daha fazla kurum faturası varsa hata verilir
                    {
                        if (PayerInvoice.GetReadyAndColInvByEpisode(ObjectContext, EpisodeAction.Episode.ObjectID.ToString()).Count > 1)
                            throw new TTException(SystemMessage.GetMessage(996));
                    }
                }
            }
        }

        // SP ile Paket SP nin AltVakası aynı mı kontrolü yapar
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

        public virtual void SetProcedureDoctorAsCurrentResource()
        {
            if (ProcedureDoctor == null && Common.CurrentResource.TakesPerformanceScore == true)
            {
                ProcedureDoctor = Common.CurrentResource;
            }
        }

        public void SetRequestedByUserAsCurrentResource()
        {
            if (CurrentStateDef.Status == StateStatusEnum.Uncompleted)
            {
                if (RequestedByUser == null)
                {
                    RequestedByUser = Common.CurrentResource;
                }
            }
        }

        public bool IsAccountOperationDone()
        {
            return AccountTransactions.Any(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled);
        }

        public bool IsAllowedToCancel()
        {
            foreach (AccountTransaction at in AccountTransactions)
            {
                if (at.CurrentStateDefID != AccountTransaction.States.Cancelled && at.IsAllowedToCancel == false)
                    return false;
            }

            return true;
        }

        override public bool IsParentRelationReadonly(TTObjectRelationDef relDef)
        {
            if (relDef.ParentObjectDefID == new Guid("f18cbf08-9ee2-40de-8029-c3f7e739c3a4")) // SubEpisode
                return false;
            if (relDef.ParentObjectDef.IsOfType(typeof(ProcedureDefinition).Name.ToUpperInvariant())) //ProcedureObject
                return IsAccountOperationDone();
            else
                return false;
        }

        override public bool IsPropertyReadonly(TTObjectPropertyDef propDef)
        {
            //if (propDef.PropertyDefID == new Guid("6b793fd3-ac25-46cd-a28a-89d23f0daab5")) //Amount
            //    return IsAccountOperationDone();
            //else
            return false;
        }

        public IEpisodeAction EpisodeActionObject
        {
            get
            {
                if (EpisodeAction != null)
                    return (IEpisodeAction)EpisodeAction;
                // bu property silindiği için kapatıldı
                //                if (this.SubactionProcedureFlowable != null)
                //                    return (IEpisodeAction)this.SubactionProcedureFlowable;
                return null;
            }

            set
            {
                if (value is EpisodeAction)
                    EpisodeAction = (EpisodeAction)value;
                // bu property silindiği için kapatıldı
                //                if (value is SubactionProcedureFlowable)
                //                    this.SubactionProcedureFlowable = (SubactionProcedureFlowable)value;
            }
        }

        public ISUTEpisodeAction GetSUTEpisodeAction()
        {
            return EpisodeAction;
        }

        public ISUTRulableObject GetSUTRulableObject()
        {
            return ProcedureObject;
        }

        public DateTime? GetRuleDate()
        {
            return ActionDate;
        }

        public double? GetRuleAmount()
        {
            if (Amount.HasValue)
                return Convert.ToDouble(Amount.Value);

            return null;
        }

        public virtual SubActionProcedure PrepareSubActionProcedureForRemoteMethod(bool withNewObjectID)
        {
            // Çağırılan yerde savePoit konulup daha sonra o pointe dönülmeli
            if (withNewObjectID)
            {
                SubActionProcedure sendingSubActionProcedure = (SubActionProcedure)Clone();
                sendingSubActionProcedure.Episode = null;
                sendingSubActionProcedure.EpisodeAction = null;
                TTSequence.allowSetSequenceValue = true;
                sendingSubActionProcedure.ID.SetSequenceValue(0);
                sendingSubActionProcedure.MasterPackgSubActionProcedure = null;
                sendingSubActionProcedure.MasterSubActionProcedure = null;
                sendingSubActionProcedure.MedulaHastaKabul = null;
                sendingSubActionProcedure.MyAction = null;
                sendingSubActionProcedure.ProcedureDoctor = null;
                sendingSubActionProcedure.SubEpisode = null;
                sendingSubActionProcedure.RequestedByUser = null;
                return sendingSubActionProcedure;
            }
            else
            {
                return this;
            }
        }

        // Hizmet tanımındaki Paket Hizmeti alanı dolu ise Paket için SubActionPackageProcedure oluşturulur
        public virtual void CreatePackageProcedure(double? discountPercent = null, bool applyDiscountPercentChange = false)
        {
            if (IsOldAction == true)
                return;

            if (this is SubActionPackageProcedure || ProcedureObject is PackageProcedureDefinition) // Zaten paket hizmet ise paket oluşturulmaz
                return;

            if (this is SurgeryProcedure || this is PhysiotherapyOrderDetail) // Ameliyat ve Fizik Tedavi paketleri kendi işlemlerinde oluşturulduğu için burada tekrar oluşmaması lazım
                return;

            ProcedureDefinition packageProcedure = ProcedureObject.MyPackageProcedure();
            if (packageProcedure != null)
            {
                SubActionPackageProcedure SPProcedure = new SubActionPackageProcedure(ObjectContext);
                SPProcedure.Amount = Amount;
                SPProcedure.CurrentStateDefID = SubActionPackageProcedure.States.Completed;
                SPProcedure.ProcedureObject = packageProcedure;
                SPProcedure.MasterSubActionProcedure = this;
                SPProcedure.EpisodeAction = EpisodeAction;
                SPProcedure.ActionDate = ActionDate;
                SPProcedure.PricingDate = PricingDate;
                SPProcedure.CreationDate = CreationDate;
                SPProcedure.PerformedDate = PerformedDate;
                SPProcedure.Eligible = Eligible;
                SPProcedure.RequestedByUser = RequestedByUser;
                SPProcedure.ProcedureDoctor = ProcedureDoctor;
                SPProcedure.SubEpisode = SubEpisode; // Paket hizmetin SubEpisode unun this.SubEpisode olarak set edilmesi lazım, yoksa episodeaction ın subepisode u set ediliyor bu da fatura ekranından farklı SEP lere hizmet eklenince sorun oluyor. 
                SPProcedure.RightLeftInformation = RightLeftInformation;
                AccountOperation(AccountOperationTimeEnum.PREPOST);
            }
        }

        protected virtual double CheckIfDayLimitExceeded()
        {
            PatientGroupDefinition patientGroupDef = Episode.GetMyPatientGroupDefinition();
            double limit = (double)(patientGroupDef.EpisodeClosingDayLimit == null ? 0 : patientGroupDef.EpisodeClosingDayLimit);
            //if (limit == 0 || limit == null)
            if (limit == 0)
                limit = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("CLOSEEPISODELASTUPDATEDAYLIMIT", "10"));
            double templimit = (double)(-1 * limit);
            DateTime LimitLastUpdateDate = Convert.ToDateTime(Common.RecTime()).AddDays(templimit);
            if ((limit > 0) && ActionDate < LimitLastUpdateDate)
                return limit;
            else
                return 0;
        }

        public bool IsProcedureExistsAtMeOrMyParents(ProcedureDefinition procedure)
        {
            if (ProcedureObject == procedure)
                return true;
            if (MasterSubActionProcedure != null)
                return MasterSubActionProcedure.IsProcedureExistsAtMeOrMyParents(procedure);
            return false;
        }

        // Yeni paket içine alma metodu
        public void AddIntoPackage(PackageDefinition pPackageDefinition, SubActionPackageProcedure pMasterPackSubActProcedure)
        {
            if (!IsCancelled)
                MasterPackgSubActionProcedure = pMasterPackSubActProcedure;
            foreach (AccountTransaction accTrx in AccountTransactions)
            {
                if (accTrx.IsAllowedToCancel == true)
                    accTrx.PackageDefinition = pPackageDefinition;
            }
        }

        // Yeni paket dışına çıkarma metodu
        public void RemoveFromPackage()
        {
            if (!IsCancelled)
                MasterPackgSubActionProcedure = null;
            foreach (AccountTransaction accTrx in AccountTransactions)
            {
                if (accTrx.IsAllowedToCancel == true)
                    accTrx.PackageDefinition = null;
            }
        }

        // "Tahakkuk", "Yeni" ve "Medulaya Gönderilmeyecek" durumundaki "Kurum Payı" olan AccountTransaction ları
        // "Yeni" durumunda "Hasta Payı" na çevirir
        public void TurnMyAccountTransactionsToPatientShare(bool withMedulaDontSend)
        {
            if (Episode.Patient.APR.Count > 0)
            {
                foreach (AccountTransaction at in AccountTransactions)
                {
                    if (at.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                    {
                        if (at.CurrentStateDefID == AccountTransaction.States.ToBeNew || at.CurrentStateDefID == AccountTransaction.States.New || (withMedulaDontSend && at.CurrentStateDefID == AccountTransaction.States.MedulaDontSend))
                        {
                            at.CurrentStateDefID = AccountTransaction.States.New;
                            at.TurnToPatientShare();
                        }
                    }
                }
            }
        }

        // İşlem ücretinin (Hasta Payının) ödenip ödenmediği bilgisini döndürür
        public bool Paid()
        {
            // Yatan hastada ödeme kontrolü yapılmaz
            if (Episode.PatientStatus == PatientStatusEnum.Inpatient)
                return true;

            if (Episode.Patient.APR.Count > 0)
            {
                foreach (AccountTransaction at in AccountTransactions)
                {
                    if (at.SubEpisodeProtocol != null && at.SubEpisodeProtocol.CheckPaid == true)
                    {
                        if (at.InvoiceInclusion == true &&
                            at.CurrentStateDefID == AccountTransaction.States.New &&
                            at.UnitPrice > 0 &&
                            at.AccountPayableReceivable == Episode.Patient.MyAPR() &&
                            at.SubEpisodeProtocol.Brans.Code != "4400" && at.SubEpisodeProtocol.Brans.Code != "1596") // Acil branşları için ödeme kontrolü yapılmaz
                        {
                            if (at.SubActionProcedure.IsCashOfficeBlock() == false)
                                return false;
                        }
                    }
                }
            }

            return true;
        }

        // Sağlık kurulu için mi istenmiş veya vakada paket sağlık kurulu işlemi var mı ?
        public bool IsRelatedWithPatientPaysHealthCommittee()
        {
            if (EpisodeAction.MasterAction is HealthCommittee)
            {
                HealthCommittee healthCommittee = (HealthCommittee)EpisodeAction.MasterAction;
                if (healthCommittee.WhoPays == WhoPaysEnum.PatientPays)
                    return true;
            }
            else if (EpisodeAction.MasterAction is HealthCommitteeExaminationFromOtherDepartments)
            {
                HealthCommitteeExaminationFromOtherDepartments hceFromOtherDepartments = (HealthCommitteeExaminationFromOtherDepartments)EpisodeAction.MasterAction;
                if (hceFromOtherDepartments.HCActionToBeLinked != null && hceFromOtherDepartments.HCActionToBeLinked.WhoPays == WhoPaysEnum.PatientPays)
                    return true;
            }

            foreach (HealthCommittee hc in EpisodeAction.Episode.HealthCommittees)
            {
                if (hc.CurrentStateDefID != HealthCommittee.States.Cancelled)
                {
                    Guid procedureCode = ProcedureDefinition.HCPackageProcedureObjectId; // Sağlık Kurulu Raporu hizmeti
                    Guid procedureCodeGunLicense = ProcedureDefinition.HCGunLicensePackageProcedureObjectId; // Silah Ruhsatı için Sağlık Raporu hizmeti
                    Guid procedureCodeOneDoctor = ProcedureDefinition.HCOneDoctorPackageProcedureObjectId; // Tek Hekim Sağlık Raporu hizmeti
                    foreach (HealthCommitteeProcedure HCProc in hc.HealthCommitteeProcedures)
                    {
                        if (HCProc.CurrentStateDefID != SubActionProcedure.States.Cancelled)
                        {
                            Guid procedureObjectID = HCProc.ProcedureObject.ObjectID;
                            if (procedureObjectID.Equals(procedureCode) || procedureObjectID.Equals(procedureCodeGunLicense) || procedureObjectID.Equals(procedureCodeOneDoctor))
                            {
                                foreach (AccountTransaction accTrx in HCProc.AccountTransactions)
                                {
                                    if (accTrx.AccountPayableReceivable.Type == APRTypeEnum.PATIENT && accTrx.CurrentStateDefID != AccountTransaction.States.Cancelled)
                                        return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        // Ücretini hastanın ödeyeceği bir Sağlık Kurulu için istenmiş ise hasta payına çevrilir ve iptal edilir
        public void CancelPatientAccTrxsIfHealthCommittee()
        {
            foreach (AccountTransaction at in AccountTransactions)
            {
                if (at.CurrentStateDefID == AccountTransaction.States.New || at.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                {
                    if (IsRelatedWithPatientPaysHealthCommittee())
                    {
                        if (at.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                            at.TurnToPatientShare();
                        at.InvoiceInclusion = false;
                    }
                }
            }
        }

        public void AccountOperationIfPaidPatient()
        {
            SubEpisodeProtocol subEpisodeProtocol = SubEpisode.OpenSubEpisodeProtocol;
            if (subEpisodeProtocol == null)
                throw new TTException(SystemMessage.GetMessage(663));
            if (subEpisodeProtocol.Protocol != null && subEpisodeProtocol.Protocol.Type == ProtocolTypeEnum.Paid)
                AccountOperation(AccountOperationTimeEnum.PREPOST);
        }

        public JointPricingProcedure AddJointPricingProcedure(SubProcedureDefinition subProcedure)
        {
            JointPricingProcedure jointProcedure = new JointPricingProcedure(ObjectContext);
            jointProcedure.ProcedureObject = subProcedure.ChildProcedureDefinition;
            jointProcedure.Amount = subProcedure.Amount;
            jointProcedure.CurrentStateDefID = JointPricingProcedure.States.Completed;
            jointProcedure.MasterSubActionProcedure = this;
            jointProcedure.PricingDate = PricingDate;
            EpisodeAction.SubactionProcedures.Add(jointProcedure);
            jointProcedure.AccountOperation(AccountOperationTimeEnum.PREPOST);
            return jointProcedure;
        }

        public HastaKabulIslemleri.yeniDoganBilgisiDVO GetYeniDoganBilgisiDVO(Patient patient)
        {
            HastaKabulIslemleri.yeniDoganBilgisiDVO yeniDoganBilgisiDVO = new HastaKabulIslemleri.yeniDoganBilgisiDVO();
            yeniDoganBilgisiDVO.dogumTarihi = (patient.BirthDate == null) ? null : patient.BirthDate.ToString();
            //TODO  doğum sırası alanı patient içerisine eklenecek.
            yeniDoganBilgisiDVO.cocukSira = 1;
            return yeniDoganBilgisiDVO;
        }

        //ICreateSubEpisode için
        public virtual ResSection GetSubEpisodeResSection()
        {
            return EpisodeAction != null ? EpisodeAction.MasterResource : null;
        }

        public virtual void SetSubEpisodeResSection(ResSection value)
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

        public virtual List<EpisodeAction> GetLinkedEpisodeActionsForSubEpisode()
        {
            List<EpisodeAction> eaList = new List<EpisodeAction>();
            return eaList;
        }

        public virtual void SetLinkedEpisodeActionsForSubEpisode(List<EpisodeAction> value)
        {
        }

        public virtual bool IsNewSubEpisodeNeeded()
        {
            return true;
        }

        public virtual void FillLocalSEPProperties(ref SubEpisodeProtocol sep)
        {
        }

        public virtual SubEpisode GetSubEpisodeCreatedByMe() // ICreateSubEpisode  interfacei için  kullanılır
        {
            return Episode.SubEpisodes.Where(x => x.StarterSubActionProcedure.ObjectID == ObjectID).FirstOrDefault();
        }

        public virtual void SetSubEpisodeCreatedByMe(SubEpisode value) // ICreateSubEpisode  interfacei için  kullanılır
        {
        }

        //
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
        /*
        public void SetAmountAndDateListForAddAccountTransaction(ref List<EpisodeProtocol.AddAccountTransactionParameter> addAccountTransactionParameterList)
        {
            if (Amount <= 1)
                return;
            
            if (this is PMAddingPSProcedure)
                return;

            bool isConsecutiveDateRequired = false;
            DateTime transactionDate = TTObjectDefManager.ServerTime;
            
            // Yatak hizmetlerinde tarihler ardışık olmalı
            if (this is BaseBedProcedure || (ProcedureObject != null && ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.hastaYatisBilgileri))
            {
                isConsecutiveDateRequired = true;
                if (PricingDate.HasValue)
                    transactionDate = PricingDate.Value;
                else if (ActionDate.HasValue)
                    transactionDate = ActionDate.Value;
            }

            for (long i = 0; i < Amount; i++)
            {
                EpisodeProtocol.AddAccountTransactionParameter addAccountTransactionParameter = new EpisodeProtocol.AddAccountTransactionParameter();
                if (isConsecutiveDateRequired)
                    addAccountTransactionParameter.TransactionDate = transactionDate.AddDays(i);
                addAccountTransactionParameterList.Add(addAccountTransactionParameter);
            }
            
        }
         */
        public void SetAmountAndDateListForSEPAddAccTrx(ref List<SubEpisodeProtocol.AddAccountTransactionParameter> addAccountTransactionParameterList)
        {
            if (Amount <= 1)
                return;

            bool isConsecutiveDateRequired = false;
            DateTime transactionDate = TTObjectDefManager.ServerTime;

            // Yatak hizmetlerinde tarihler ardışık olmalı
            if (this is BaseBedProcedure || (ProcedureObject != null && ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.hastaYatisBilgileri))
            {
                isConsecutiveDateRequired = true;
                if (PricingDate.HasValue)
                    transactionDate = PricingDate.Value;
                else if (ActionDate.HasValue)
                    transactionDate = ActionDate.Value;
            }

            for (long i = 0; i < Amount; i++)
            {
                SubEpisodeProtocol.AddAccountTransactionParameter addAccountTransactionParameter = new SubEpisodeProtocol.AddAccountTransactionParameter();
                if (isConsecutiveDateRequired)
                    addAccountTransactionParameter.TransactionDate = transactionDate.AddDays(i);
                addAccountTransactionParameterList.Add(addAccountTransactionParameter);
            }
        }

        public virtual bool SendToENabiz(bool isNewInserted)
        {
            if (IsOldAction == true)
                return false;
            if (this is RadiologyTest && ((RadiologyTest)this).ExternalServiceRequests.Count > 0)//Çubuk gibi dışardan gelen işlemler için nabıza gitmeyecek
                return false;
            return isNewInserted;
        }

        public virtual void SetPerformedDate() // İşlemin yapıldığı tarihi set edecek şekilde override edilmeli
        {
            if (TTObjectClasses.SystemParameter.GetParameterValue("SETPERFORMEDDATE_BOZULMASIN", "FALSE") != "TRUE")
            {
                throw new Exception(_objectDef.ApplicationName + "'deki SetPerformedDate() methodunu override etmediniz");
                // InfoMessageService.Instance.ShowMessage(this._objectDef.ApplicationName + "'deki SetPerformedDate() methodunu override etmediniz");
            }
        }


        public virtual bool SetMyPricingDateToPerformedDate()
        {
            return false;
        }
        public virtual bool IsUsedForDoctorPerformans() // Tamamlandığında ProcedureDoctoru zorunlu tutup tutmayacağını döner
        {
            //            if(ProcedureObject != null && !string.IsNullOrEmpty(ProcedureObject.GILCode)) // şimdilik gil kontrolu yok
            //                return true;
            //            return false;
            return true;
        }

        public virtual void AutoComplete() // Eğer Açık ise kapatır
        {
            if (CurrentStateDefID == SubActionProcedure.States.New)
                CurrentStateDefID = SubActionProcedure.States.Completed;
        }



        public virtual void CheckProceduerDoctorForPerformans()
        {
            if (IsUsedForDoctorPerformans() && ProcedureDoctor == null)
            {
                //throw new TTUtils.TTException(SystemMessage.GetMessage(994));//ESKİ VERİLER HATA ALMASIN DİYE COMMENTLENDI AÇILACAK TODO DOKTORPERFOMANS
                // throw new Exception("'İşlemi yapan Doktor' alanın boş olamaz");
            }
        }

        public virtual bool GetProcedureDoctorFromMyEpisodeAction()
        {
            return true;
        }

        public virtual void AddRowToSendToDoctorPerformace(DPInternalObjectStatus internalObjectStatus)
        {
            // Fatura ekranından girilen ve fatura ekranından girilen hizmetlerden dolayı oluşan hizmetler için (paket gibi) doktor performans oluşmamalı
            if (this is PMAddingProcedure || MasterSubActionProcedure is PMAddingProcedure)
                return;

            if (PerformedDate == null && ((ITTObject)this).IsNew == false)
            {
                TTObjectContext objectContext = new TTObjectContext(true);
                SubActionProcedure originalSp = objectContext.GetObject(ObjectID, "SubActionProcedure", false) as SubActionProcedure;
                //if (((ITTObject)this).HasOriginal)//New ve Delete iken Original yok
                //    sp = ((ITTObject)this).Original as SubActionProcedure;

                if (originalSp != null && originalSp.PerformedDate != null)
                {
                    List<SendToDoctorPerformance> sdpList = ObjectContext.QueryObjects<SendToDoctorPerformance>(" INTERNALOBJECTID = '" + ObjectID + "'").ToList();

                    foreach (SendToDoctorPerformance sdp in sdpList.Where(x => x.InternalObjectStatus != DPInternalObjectStatus.Cancelled && x.Status == DPStatus.ToBeSent))
                    {
                        sdp.Status = DPStatus.DontSend;
                    }

                    if (sdpList.Count(x => x.InternalObjectStatus != DPInternalObjectStatus.Cancelled && x.Status == DPStatus.Sent) > 0)
                    {
                        SendToDoctorPerformance sendToDP = new SendToDoctorPerformance(ObjectContext, ObjectID, ObjectDef.Name, DPInternalObjectStatus.Cancelled, Common.RecTime());

                        if (SystemParameter.GetParameterValue("SENDDOCTORPERFORMANCENOW", "FALSE").Equals("TRUE"))
                            sendToDP.CancelDoctorPerformanceDetail();
                    }
                }
                objectContext.Dispose();
            }

            ResUser performanceDoctor = GetPerformanceDoctor();

            if (PerformedDate != null && performanceDoctor != null && performanceDoctor.TakesPerformanceScore == true)
            {
                if (internalObjectStatus == DPInternalObjectStatus.Cancelled || IsPerformanceDoctorChanged() || HasMemberChanged("PerformedDate") || HasMemberChanged("ProcedureObject") || HasMemberChanged("Amount") || HasChangedToSendToDoctorPerformance())
                {
                    SendToDoctorPerformance sendToDP = new SendToDoctorPerformance(ObjectContext, ObjectID, ObjectDef.Name, internalObjectStatus, Common.RecTime());

                    if (SystemParameter.GetParameterValue("SENDDOCTORPERFORMANCENOW", "FALSE").Equals("TRUE"))
                    {
                        if (internalObjectStatus == DPInternalObjectStatus.Inserted || internalObjectStatus == DPInternalObjectStatus.Updated)
                            SendDoctorPerformanceDetail(sendToDP);
                        else if (internalObjectStatus == DPInternalObjectStatus.Cancelled)
                            sendToDP.CancelDoctorPerformanceDetail();
                    }
                }
            }
        }

        public virtual ResUser GetPerformanceDoctor()
        {
            return ProcedureDoctor;
        }

        public virtual bool IsPerformanceDoctorChanged()
        {
            return HasMemberChanged("ProcedureDoctor");
        }

        public virtual bool HasChangedToSendToDoctorPerformance()
        {
            return false;
        }

        public string GetGILCode()
        {
            if (ProcedureObject != null)
                return ProcedureObject.GILCode;
            return null;
        }

        public int GetGILPoint()
        {
            if (ProcedureObject != null && ProcedureObject.GILPoint.HasValue)
                return ProcedureObject.GILPoint.Value;
            return 0;
        }

        #endregion Methods
        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SubActionProcedure).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == SubActionProcedure.States.New && toState == SubActionProcedure.States.Cancelled)
                PostTransition_New2Cancelled();
            else if (fromState == SubActionProcedure.States.Completed && toState == SubActionProcedure.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

        public SubEpisodeProtocol SEP
        {
            get
            {
                return SubEpisode?.FirstSubEpisodeProtocol;
            }
        }

        public void DeleteSubactionFromENabiz()
        {
            //Eğer hizmet nabız tablosuna atıldıysa ama gönderim henüz yapılmadıysa statusu updatelenecek(3)
            //Nabıza kaydı yapılmış bir işlem ise nabızdan silinecek
            bool hasSendFlag = false;
            TTObjectClasses.SendToENabiz[] nabizArray = TTObjectClasses.SendToENabiz.GetByObjectID(ObjectContext, ObjectID, "102").ToArray();
            for (int i = 0; i < nabizArray.Length; i++)
            {
                if (nabizArray[i].Status == SendToENabizEnum.Successful)
                {
                    hasSendFlag = true;
                    break;
                }
            }

            if (hasSendFlag)
            {
                if (SubEpisode != null)
                {
                    new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "302", Common.RecTime());
                }
            }
            else
            {
                foreach (SendToENabiz item in nabizArray)
                {
                    TTObjectClasses.SendToENabiz nabizImported = (TTObjectClasses.SendToENabiz)ObjectContext.GetObject(item.ObjectID, "SendToENabiz");
                    nabizImported.Status = SendToENabizEnum.NotToBeSent;
                }

            }
        }

        public virtual bool EmergencyPropertySetWithAction() // True ise hizmet bağlı olduğu EpisodeAction'ın emergency özelliğini alır
        {
            return true;
        }


        #region ISetWorkListDate Members
        public bool? GetIsOldAction()
        {
            return IsOldAction;
        }

        public void SetIsOldAction(bool? value)
        {
            IsOldAction = value;
        }

        public AppointmentWithoutResource.ChildAppointmentWithoutResourceCollection GetAppointmentWithoutResources()
        {
            return AppointmentWithoutResources;
        }

        public DateTime? GetWorkListDate()
        {
            return WorkListDate;
        }

        public void SetWorkListDate(DateTime? value)
        {
            WorkListDate = value;
        }

        public bool GetNotSetWorklist()
        {
            return NotSetWorklist;
        }

        public void SetNotSetWorklist(bool value)
        {
            NotSetWorklist = value;
        }

        public Guid? GetCurrentStateDefID()
        {
            return CurrentStateDefID;
        }

        public void SetCurrentStateDefID(Guid? value)
        {
            CurrentStateDefID = value;
        }
        #endregion
    }
}