
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
    /// Klinik İşlemleri
    /// </summary>
    public partial class InPatientTreatmentClinicApplication : EpisodeAction, IAllocateSpeciality, IOAInPatientApplication, IWorkListEpisodeAction, IWorkListInpatient
    {
        public partial class GetInpatientListReportNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetInpatientStatistics_Class : TTReportNqlObject
        {
        }

        public partial class GetInpatientStatisticsByDate_Class : TTReportNqlObject
        {
        }

        public partial class GetByEpisodeAndMasterResourceReport_Class : TTReportNqlObject
        {
        }

        public partial class GetpatientListReportByDaysNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetpatientListReportByInpatientDayNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetInpatientByPatientGroup_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_YatanHasta_Class : TTReportNqlObject
        {
        }

        public partial class GetInPatientBeds_Class : TTReportNqlObject
        {
        }

        public partial class GetpatientListReportByDateNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetInpatientBedsByResWard_Class : TTReportNqlObject
        {
        }

        public partial class GetInpatientInformation_RQ_Class : TTReportNqlObject
        {
        }

        public partial class GetJustInpatientStatistic_Class : TTReportNqlObject
        {
        }

        public partial class GetActiveInpatientTrtClinicAppByMasterResource_Class : TTReportNqlObject
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
                case "PROCEDUREDOCTOR":
                    {
                        ResUser value = (ResUser)newValue;
                        #region PROCEDUREDOCTOR_SetParentScript
                        InpatientResponsibleDoctor inpatientResponsibleDoctor = new InpatientResponsibleDoctor(ObjectContext);
                        inpatientResponsibleDoctor.Doctor = value;
                        inpatientResponsibleDoctor.SDateTime = Common.RecTime();
                        ResponsibleDoctors.Add(inpatientResponsibleDoctor);

                        //         // Responsible Doctor değiştiğinde PhysicianApplication'ın AuthorizedUsers'ını değiştirir
                        foreach (InPatientPhysicianApplication physicianApplication in InPatientPhysicianApplication)
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
                        #endregion PROCEDUREDOCTOR_SetParentScript
                    }
                    break;
                case "RESPONSIBLENURSE":
                    {
                        ResUser value = (ResUser)newValue;
                        #region RESPONSIBLENURSE_SetParentScript
                        InpatientResponsibleNurse inpatientResponsibleNurse = new InpatientResponsibleNurse(ObjectContext);
                        inpatientResponsibleNurse.Nurse = value;
                        inpatientResponsibleNurse.SDateTime = Common.RecTime();
                        ResponsibleNurses.Add(inpatientResponsibleNurse);
                        #endregion RESPONSIBLENURSE_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }



        public bool IsInpatintAdmissionDischarged()
        {
            if (BaseInpatientAdmission is InpatientAdmission)
            {
                if (BaseInpatientAdmission.CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                {
                    return true;
                }
            }
            return false;
        }
        public override SubEpisodeStatusEnum GetSubEpisodePatientStatus()
        {
            if (IsDailyOperation == true)
                return SubEpisodeStatusEnum.Daily;
            else
                return SubEpisodeStatusEnum.Inpatient;
        }

        // ICreateSubEpisode Methodları
        // Yeni SubEpisode oluşturulmasına karar veren metod
        public override bool IsNewSubEpisodeNeeded()
        {
            if (base.IsNewSubEpisodeNeeded() == false)
                return false;

            if (Episode.InPatientTreatmentClinicApplications.Count == 1)
                return true;
            else
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("MULTISUBEPISODEATTRANSFER", "TRUE").Equals("TRUE"))
                    return true;
            }

            return false;
        }


        // SEP in değiştirilmesi gereken propertyleri varsa bu metodda set edilmeli
        public override void FillLocalSEPProperties(ref SubEpisodeProtocol sep)
        {
            if (MasterResource.TedaviTipi != null)
                sep.MedulaTedaviTipi = MasterResource.TedaviTipi;
            else if (SubEpisode.PatientAdmission.SEP.MedulaTedaviTipi.tedaviTipiKodu == "14")
                sep.MedulaTedaviTipi = TedaviTipi.GetTedaviTipi("0");

            // Yoğun bakım kliniği ise Takip Tipi "Y : Yoğun Bakım" set edilir
            if (MasterResource is ResWard)
            {
                if (((ResWard)MasterResource).IsIntensiveCare == true)
                    sep.MedulaTakipTipi = TakipTipi.GetTakipTipi("Y");
            }

            // ParentSEP (Bağlı Takip)
            sep.ParentSEP = SubEpisode.LastActiveSubEpisodeProtocol; // ArrangeMeOrCreateNewSubEpisode dan bu kod çağırıldığında henüz işlemin Subepisode u set edilmemiş olduğu için this.SubEpisode eski subepisode olur

            // Günübirlik takip için provizyon tarihi, ParentSEP in (Ayaktan takibin) tarihi ile aynı olmalı, bu yüzden güncellenir
            if (sep?.MedulaTedaviTuru?.tedaviTuruKodu == "G")
            {
                if (sep.ParentSEP != null && (!sep.MedulaProvizyonTarihi.HasValue || (sep.MedulaProvizyonTarihi.HasValue && sep.MedulaProvizyonTarihi.Value.Date != sep.ParentSEP.MedulaProvizyonTarihi.Value.Date)))
                    sep.MedulaProvizyonTarihi = sep.ParentSEP.MedulaProvizyonTarihi;
            }
            else if (sep?.MedulaTedaviTuru?.tedaviTuruKodu == "Y")
            {   // Yatan takip günübirliğe bağlıysa, günübirliğin bağlı olduğu ayaktan takibe bağlanacak şekilde değiştirilir (TFS Task: 61507) 
                if (sep?.ParentSEP?.MedulaTedaviTuru?.tedaviTuruKodu == "G")
                {
                    if (sep?.ParentSEP?.ParentSEP?.MedulaTedaviTuru?.tedaviTuruKodu == "A")
                        sep.ParentSEP = sep.ParentSEP.ParentSEP;
                }
            }

        }

        public override DiagnosisCopyEnum GetDiagnosisCopyEnum()
        {
            return DiagnosisCopyEnum.CopyFromLastSubEpisodeWithSameSpeciality;
        }


        // ISubEpisodeStarter Methodları

        public override DateTime SubEpisodeOpeningDate()
        {
            return ClinicInpatientDate == null ? base.SubEpisodeOpeningDate() : (DateTime)ClinicInpatientDate;
        }
        public override DateTime SubEpisodeClosingDate()
        {
            return ClinicDischargeDate == null ? base.SubEpisodeClosingDate() : (DateTime)ClinicDischargeDate;
        }
        //

        //Yatak Servis Tipleri Kontrolü
        public void CheckBedProcedureType()
        {
            if (((InpatientAdmission)BaseInpatientAdmission).ActiveInPatientTrtmentClcApp != null && ((InpatientAdmission)BaseInpatientAdmission).ActiveInPatientTrtmentClcApp.ObjectID.Equals(this.ObjectID))//Aktif Klinik işlemleri üzerinde yatak-klinik değişimi yapılıyorsa
            {
                //if (BaseInpatientAdmission.HasMemberChanged("Bed") || HasMemberChanged("MasterResource"))//yatak ya da tedavi gördüğü klinik değişiyorsa
                //{
                if (BaseInpatientAdmission.Bed != null && BaseInpatientAdmission.Bed.BedProcedureType != null)
                {
                    if (BaseInpatientAdmission.Bed.BedProcedureType != ((ResWard)MasterResource).BedProcedureType)//yattığı yatak ile tedavi gördüğü kliniğin servis yatak tipleri aynı olmalı
                    {
                        throw new Exception("Hastanın yattığı yatak ile tedavi gördüğü kliniğin servis yatak tipleri aynı olmalıdır. Farklı servis yatak tipi seçebilmek için kurum içi sevk yapmalısınız!");
                    }
                }
                else
                {
                    if (BaseInpatientAdmission.PhysicalStateClinic != null && BaseInpatientAdmission.PhysicalStateClinic.BedProcedureType != ((ResWard)MasterResource).BedProcedureType)//Yattığı klinik ile tedavi gördüğü kliniğin servis yatak tipleri aynı olmalı
                    {
                        throw new Exception("Hastanın yattığı klinik ile tedavi gördüğü kliniğin servis yatak tipleri aynı olmalıdır. Hastanın yattığı yatağı değiştirmelisiniz ya da farklı servis yatak tipi seçebilmek için kurum içi sevk yapmalısınız!");
                    }
                }

                //}
            }
        }

        protected override void PreInsert()
        {
            #region PreInsert

            base.PreInsert();
            //CheckBedProcedureType();
            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();

            if (BaseInpatientAdmission.Emergency == true)
            {
                InpatientAcceptionType = InpatientAcceptionTypeEnum.EmergencyInpatient;//Acilden yeni yatırılan hasta
            }

            #endregion PostInsert
        }


        protected override void PreUpdate()
        {
            #region PostUpdate
            base.PreUpdate();
            if (CurrentStateDefID != InPatientTreatmentClinicApplication.States.Acception && CurrentStateDefID != InPatientTreatmentClinicApplication.States.Rejected && CurrentStateDefID != InPatientTreatmentClinicApplication.States.Cancelled)
            {
                CheckBedProcedureType();
            }

            #endregion PostUpdate
        }
        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();
            if (CurrentStateDefID != InPatientTreatmentClinicApplication.States.Rejected && CurrentStateDefID != InPatientTreatmentClinicApplication.States.Cancelled)
            {
                CheckReponsibleDoctorIsChange();
            }
            if (CurrentStateDefID != InPatientTreatmentClinicApplication.States.Acception && CurrentStateDefID != InPatientTreatmentClinicApplication.States.PreAcception)
            {
                InpatientAcceptionType = null;
            }
            #endregion PostUpdate
        }


        protected void PostTransition_Acception2Procedure()
        {
            // From State : Acception   To State : Procedure
            #region PostTransition_Acception2Procedure

            CheckRequiresAdvance();// Hastadan Alınmış Avans Olup olmadığını Kontrol eder

            FireNursingAndPhysicianApplication();
            AcceptToClinic();
            CreateEpisodeFolder();
            //WaitingClinicAcceptionPatient();

            #region Yatan Hasta SMS

            try
            {
                UserMessage userMessage = new UserMessage();

                string smsYatanHastaActive = TTObjectClasses.SystemParameter.GetParameterValue("SMSYATANHASTAACTIVE", "FALSE");

                string smsYatanHastaBrasCodes = TTObjectClasses.SystemParameter.GetParameterValue("SMSYATANHASTABRANSCODES", "");

                bool exceptBrans = false;//bu branşlar dışında mesaj atsın

                if (string.IsNullOrEmpty(smsYatanHastaBrasCodes))
                {
                    exceptBrans = smsYatanHastaBrasCodes.Split(',').ToList().Contains(MasterResource.Brans.Code);
                }

                if (smsYatanHastaActive == "TRUE" && !exceptBrans)
                {
                    string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("SMSYATANHASTAMESSAGE", "");
                    List<Patient> patients = new List<Patient> { Episode.Patient };
                    if (!string.IsNullOrEmpty(sysparam))
                        userMessage.SendSMSPatient(patients, sysparam, SMSTypeEnum.InpatientInfoSMS);
                }
            }
            catch (Exception)
            {

            }

            #endregion

            #endregion PostTransition_Acception2Procedure
        }

        protected void UndoTransition_Acception2Procedure(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Acception   To State : Procedure
            #region UndoTransition_Acception2Procedure

            //Geri alınması engellendi Çünkü Kliniğe  bi kez kabul olur bunu geri almaya gerekyok .
            //Ayrıca Kabul tarihi atılıyor geri alınırsa bu dozulu
            //Birde bu işlem NursingApplication ve InpatientPhysicianApplication fire ediyor geri aklınırsa bunlar problem olur
            NoBackStateBack();

            #endregion UndoTransition_Acception2Procedure
        }

        protected void UndoTransition_Approve2Procedure(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Acception   To State : Procedure
            #region UndoTransition_Approve2Procedure

            //Geri alınması engellendi Çünkü Kliniğe  bi kez kabul olur bunu geri almaya gerekyok .
            //Ayrıca Kabul tarihi atılıyor geri alınırsa bu dozulu
            //Birde bu işlem NursingApplication ve InpatientPhysicianApplication fire ediyor geri aklınırsa bunlar problem olur
            NoBackStateBack();

            #endregion UndoTransition_Approve2Procedure
        }

        protected void PostTransition_Acception2Rejected()
        {
            // From State : Acception   To State : Rejected
            #region PostTransition_Acception2Rejected
            Reject();
            #endregion PostTransition_Acception2Rejected
        }

        protected void UndoTransition_Acception2Rejected(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Acception   To State : Cancelled
            #region UndoTransition_Acception2Rejected
            NoBackStateBack();
            #endregion UndoTransition_Acception2Rejected
        }

        protected void PostTransition_Procedure2Discharged()
        {
            // From State : Procedure   To State : Discharged
            #region PostTransition_Procedure2Discharged
            //Sıra  Önemli 

            if (ClinicDischargeDate == null)
                throw new Exception(TTUtils.CultureService.GetText("M26979", "Taburcu Tarihi girilmeden Taburcu işlemi gerçekleşirilemez"));
            //Refakatçi İşlemleri
            // this.ClinicDischargeDate set edilmiş olmalı
            ArrangeCompanionToAccountOperation(); // Refakatçi işlemleri tamamlanır Enddateleri ayarlanır
            CreateAndArrangeCompanionApplicationAccTrxs(); // Tamamlanmış Tüm Refakatçi işlemleri ücretlendirilir ve hasta/kurum payları ayarlanır

            //ArrangeSubEpisodeOfBedProcedures(); // BaseBedProcedure ler artık InpatientTratmentClinicApplication ların altında oluştuğu için bu metoda gerek yok
            BaseInpatientAdmission.DeallocateLastBed();
            ArrangeBedProceduresByClinicDischargeDate();        // Clinic Çıkış tarihi değiştirildiyse son yatağın dischargedateini ayarlamak için
            //BaseInpatientAdmission.ArrangeDailyBedProcedures(); // Yatış ve çıkış tarihi aynı gün ise yatak hizmetini Gündüz Yatak Hizmetine çevirir, yeni ücretlendirme yapısından sonra kapatıldı )

            if (BaseInpatientAdmission is InpatientAdmission)
            {
                //((InpatientAdmission)this.BaseInpatientAdmission).AccountingOperation(AccountOperationTimeEnum.PREPOST);
                ((InpatientAdmission)BaseInpatientAdmission).EmptyCupboard();
            }

            // this.ClinicDischargeDate set edilmiş olmalı
            // SendMedulaSevkKayitSync();//  DispatchToOtherHospitalda yapılacak
            MedulaHastaCikisKayit(true);// Predischargedda çağırılır 
            #endregion PostTransition_Procedure2Discharged
        }



        protected void UndoTransition_Procedure2Discharged(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Procedure   To State : Discharged
            #region UndoTransition_Procedure2Discharged

            //if (this.BaseInpatientAdmission is InpatientAdmission)
            //{
            //    InpatientAdmission inpatientAdmission = (InpatientAdmission)this.BaseInpatientAdmission;
            //    if (inpatientAdmission.CurrentStateDefID == InpatientAdmission.States.Discharged)
            //        throw new Exception(SystemMessage.GetMessage(593));
            //}

            if (BaseInpatientAdmission is InpatientAdmission)
                ((InpatientAdmission)BaseInpatientAdmission).CancelBedProcedureAccTrxs(); // Yatak hizmetlerinin AccTrx leri iptal edilir

            // Refakatçi İşlemleri
            UndoCompanionApplications();
            BaseInpatientAdmission.AllocateNewBed(false, false);

            // CancelMedulaSevkKayitSync(); DispatchToOtherHospitalda yapılacak
            MedulaHastaCikisIptal();
            #endregion UndoTransition_Procedure2Discharged
        }

        protected void PostTransition_Procedure2Transferred()
        {
            // From State : Procedure   To State : Transferred
            #region PostTransition_Procedure2Transferred
            // Sıra  Önemli

            if (ClinicDischargeDate == null)
                throw new Exception(TTUtils.CultureService.GetText("M26978", "Taburcu Tarihi girilmeden Kurum içi Sevk işlemi gerçekleşirilemez"));
            //Refakatçi İşlemleri
            // this.ClinicDischargeDate set edilmiş olmalı
            ArrangeCompanionToAccountOperation();//Refakatçi işlemleri tamamlanır Enddateleri ayarlanır 
            BaseInpatientAdmission.AllocateNewBed(false, true); // Yeni Kliniğe nakil edilirken yatakeğişmezse bile  yeni BaseBedprocedure oluşsun diye
            #endregion PostTransition_Procedure2Transferred

        }

        public bool IsToInpatientClinicAppCancelled = false;
        protected void UndoTransition_Procedure2Transferred(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Procedure   To State : Transferred
            #region UndoTransition_Procedure2Transferred
            UndoCompanionApplications();
            if (!IsToInpatientClinicAppCancelled)
                CancelToInpatientClinicApp();
            ClinicDischargeDate = null;
            #endregion UndoTransition_Procedure2Transferred
        }



        protected void PostTransition_Acception2Cancelled()
        {
            // From State : Acception   To State : Cancelled
            #region PostTransition_Acception2Cancelled
            Cancel();
            #endregion PostTransition_Acception2Cancelled
        }

        protected void UndoTransition_Acception2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Acception   To State : Cancelled
            #region UndoTransition_Acception2Cancelled
            UndoCancel();
            #endregion UndoTransition_Acception2Cancelled
        }


        protected void PostTransition_Procedure2Cancelled()
        {
            // From State : Procedure   To State : Cancelled
            #region PostTransition_Procedure2Cancelled
            Cancel();
            #endregion PostTransition_Procedure2Cancelled
        }

        protected void UndoTransition_Procedure2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Procedure   To State : Cancelled
            #region UndoTransition_Procedure2Cancelled
            UndoCancel();
            #endregion UndoTransition_Procedure2Cancelled
        }


        protected void PostTransition_Transferred2Cancelled()
        {
            // From State : Transferred   To State : Cancelled
            #region PostTransition_Transferred2Cancelled
            Cancel();
            #endregion PostTransition_Transferred2Cancelled
        }

        protected void UndoTransition_Transferred2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Transferred   To State : Cancelled
            #region UndoTransition_Transferred2Cancelled
            UndoCancel();
            #endregion UndoTransition_Transferred2Cancelled
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

        protected void PostTransition_Discharged2Procedure()
        {
            // From State : Discharged   To State : Cancelled
            #region PostTransition_Discharged2Cancelled

            TreatmentDischarge = null;
            
            #endregion PostTransition_Discharged2Cancelled
        }
        
        #region Methods

        //public string WaitingClinicAcceptionPatient()
        //{
        //    var waitingClinicAcceptionPatientList = InPatientTreatmentClinicApplication.GetWaitingClinicAcceptionPatient(MasterResource.ObjectID).Where(x => x.InpatientAcceptionType != InpatientAcceptionType);
        //    var message = "";
        //    if (InpatientAcceptionType == null && waitingClinicAcceptionPatientList.Count() > 0)
        //    {
        //        //Yatış Bekliyor olarak işaretlenmemiş hasta yatırılırken eğer yatış bekleyen hasta var ise yatış engellenir.
        //        throw new Exception("'Yatış Bekliyor' durumunda hasta bulunmaktadır. Lütfen öncelikli olarak 'Yatış Bekliyor' durumundaki hastayı kliniğe kabul ediniz!");
        //    }
        //    else if (waitingClinicAcceptionPatientList.Count() > 0)
        //    {
        //        if (InpatientAcceptionType == InpatientAcceptionTypeEnum.EmergencyInpatient)
        //        {
        //            //Yatış bekleyen hasta acil hasta ise uyarı vermeden yatış yapılacak!
        //        }
        //        else if (InpatientAcceptionType == InpatientAcceptionTypeEnum.IntensiveCareTransfer)
        //        {
        //            if (waitingClinicAcceptionPatientList.Where(c => c.InpatientAcceptionType == InpatientAcceptionTypeEnum.EmergencyInpatient).Count() > 0)
        //            {
        //                //Yatış bekleyen hasta yoğun bakımdan transfer hasta ise sadece acil bekleyen varsa uyarı verecek! Değilse uyarı vermeden yatış yapılacak!
        //                message = "'Yatış Bekliyor' durumunda hasta bulunmaktadır. Lütfen öncelikli olarak 'Yatış Bekliyor' durumundaki hastayı kliniğe kabul ediniz!";
        //            }
        //        }
        //        else if (InpatientAcceptionType == InpatientAcceptionTypeEnum.OtherClinicTransfer)
        //        {
        //            if (waitingClinicAcceptionPatientList.Where(c => c.InpatientAcceptionType == InpatientAcceptionTypeEnum.EmergencyInpatient || c.InpatientAcceptionType == InpatientAcceptionTypeEnum.IntensiveCareTransfer).Count() > 0)
        //            {
        //                //Yatış bekleyen kurum içi transfer hasta ise acil bekleyen ve yoğun bakım transfer hastalar varsa uyarı verecek! Değilse uyarı vermeden yatış yapılacak!
        //                message = "'Yatış Bekliyor' durumunda hasta bulunmaktadır. Lütfen öncelikli olarak 'Yatış Bekliyor' durumundaki hastayı kliniğe kabul ediniz!";
        //            }
        //        }
        //        else if (InpatientAcceptionType == InpatientAcceptionTypeEnum.NewInpatient)
        //        {
        //            //Yatış Bekleyen hasta yeni yatış yapılan hasta ise ve kendi InpatientAcceptionType tipinden başka hasta var ise uyarı verecek!
        //            message = "'Yatış Bekliyor' durumunda hasta bulunmaktadır. Lütfen öncelikli olarak 'Yatış Bekliyor' durumundaki hastayı kliniğe kabul ediniz!";
        //        }
        //    }
        //    return message;
        //}
        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.InPatientTreatmentClinicApplication;
            }
        }


        public void CancelToInpatientClinicApp()
        {

            var toInPatientTrtmentClinicApp = GetMyActiveToInPatientTrtmentClinicApp();
            if (toInPatientTrtmentClinicApp != null)
            {
                toInPatientTrtmentClinicApp.CancelledByMasterAction = true;
                ((ITTObject)toInPatientTrtmentClinicApp).Cancel();
            }
        }
        public void CheckRequiresAdvance()
        {
            if (BaseInpatientAdmission is InpatientAdmission)
            {
                if (RequiresAdvance())
                    throw new Exception(SystemMessage.GetMessage(137));
            }
        }
        public InPatientTreatmentClinicApplication(BaseInpatientAdmission baseInpatientAdmission, ResSection masterResource, ResSection fromResource)
                    : this(baseInpatientAdmission.ObjectContext)
        {
            SetMandatoryEpisodeActionProperties((EpisodeAction)baseInpatientAdmission, masterResource, fromResource, false);
            SecondaryMasterResource = baseInpatientAdmission.PhysicalStateClinic;//Fiziksel Olarak Yatacağı Klinik

            //İlk State 
            if (TTObjectClasses.SystemParameter.GetParameterValue("APPROVECLINICACCEPTION", "FALSE") == "FALSE")
                CurrentStateDefID = InPatientTreatmentClinicApplication.States.Acception;
            else
                CurrentStateDefID = InPatientTreatmentClinicApplication.States.PreAcception;



            //this.CurrentStateDefID = InPatientTreatmentClinicApplication.States.Acception;
            //this.ClinicInpatientDate = Common.RecTime(); Acceptionda set edilmeli
            BaseInpatientAdmission = baseInpatientAdmission;


            if (baseInpatientAdmission is InpatientAdmission)
            {

                ((InpatientAdmission)baseInpatientAdmission).ActiveInPatientTrtmentClcApp = this;

                // Aynı uzmanlıkdan başlatıldı ise İstek yapan doktor Sorumlu doktora set edilir
                foreach (var InpatientAdmissionResSpeciality in baseInpatientAdmission.FromResource.ResourceSpecialities)
                {
                    foreach (var resSpeciality in masterResource.ResourceSpecialities)
                    {
                        if (resSpeciality.Speciality.ObjectID == InpatientAdmissionResSpeciality.Speciality.ObjectID)
                            ProcedureDoctor = baseInpatientAdmission.ProcedureDoctor;
                    }
                }
            }
        }

        public void AcceptToClinic()
        {
            if (ClinicInpatientDate == null)
                throw new Exception(TTUtils.CultureService.GetText("M26319", "Klinik kabul tarihi boş olamaz"));
            if (BaseInpatientAdmission is InpatientAdmission)
            {
                if (Episode.PatientStatus != PatientStatusEnum.Inpatient)
                {
                    Episode.PatientStatus = PatientStatusEnum.Inpatient;
                    ((InpatientAdmission)BaseInpatientAdmission).HospitalInPatientDate = ClinicInpatientDate;
                }
                bool getNewMedulaProvision = true;
                if (IsOldAction == true)
                    getNewMedulaProvision = false;
                SubEpisode.ArrangeMeOrCreateNewSubEpisode(this, true, getNewMedulaProvision); // SubEpisode ve SubEpisodeProtocol oluşturup meduladan takip alan metod
                ArrangeBedProceduresByClinicInpatientDate();

                string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("HL7ENGINEALIVE", null);
                if (sysparam == "TRUE")
                {
                    try
                    {
                        Patient.SendPatientToPACS(Episode.Patient);
                    }
                    catch (Exception ex)
                    {
                        String message = SystemMessage.GetMessage(200);
                        TTUtils.InfoMessageService.Instance.ShowMessage("Hasta bilgileri PACS'a gönderilemedi! " + message);
                    }
                }
            }
        }


        // Refakatçi İşlemleri 
        public void ArrangeCompanionToAccountOperation()
        {
            ArrangeCompanionSubEpisodes(); // CompanionApplication ların SubEpisode larını düzenler
            CompleteCompanionApplications(); // CompanionApplication ları tamamlar 
        }

        public void ArrangeCompanionSubEpisodes()
        {
            foreach (CompanionApplication compApp in Episode.CompanionApplications)
            {
                compApp.SetMySubEpisodeByMasterAction();
            }
        }
        public void CompleteCompanionApplications()
        {

            foreach (var compApp in LinkedActions)
            {
                if (compApp is CompanionApplication)
                {
                    if (compApp.CurrentStateDefID == CompanionApplication.States.Active)
                    {
                        ((CompanionApplication)compApp).CheckRulesToCompleteCompanion();
                        compApp.CurrentStateDefID = CompanionApplication.States.ExCompanion;
                    }
                }
            }
        }



        // Refakatçi hizmetlerinin ücretlendirmesini ve oluşan AccTrx lerin iptal veya hasta/kurum payı ayarlamalarını yapar
        public void CreateAndArrangeCompanionApplicationAccTrxs()
        {
            //if (this.IsOldAction != true)
            //{
            //    foreach (CompanionApplication compApp in this.Episode.CompanionApplications)
            //    {
            //        if (compApp.CurrentStateDefID == CompanionApplication.States.ExCompanion)
            //            compApp.AddingAccountOperation();
            //    }

            //    InpatientAdmission inpatientAdmission = this.BaseInpatientAdmission as InpatientAdmission;
            //    if (inpatientAdmission != null)
            //    {
            //        List<DateTime> companionTrxDateList = new List<DateTime>();
            //        foreach (CompanionProcedure compProc in this.Episode.CompanionProcedures)
            //        {
            //            if (!compProc.IsCancelled)
            //            {
            //                foreach (AccountTransaction accTrx in compProc.AccountTransactions)
            //                {
            //                    if (accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER && accTrx.IsAllowedToCancel)
            //                    {
            //                        if (inpatientAdmission.NeedCompanion != true)
            //                            accTrx.TurnToPatientShare(true);
            //                        else
            //                        {
            //                            DateTime trxDate = accTrx.TransactionDate.Value.Date;
            //                            if (companionTrxDateList.Contains(trxDate))
            //                                accTrx.TurnToPatientShare(true);
            //                            else
            //                                companionTrxDateList.Add(trxDate);
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            if (IsOldAction != true)
            {
                InpatientAdmission inpatientAdmission = BaseInpatientAdmission as InpatientAdmission;
                if (inpatientAdmission != null)
                {
                    List<DateTime> companionTrxDateList = new List<DateTime>();
                    foreach (InPatientTreatmentClinicApplication tcapp in inpatientAdmission.InPatientTreatmentClinicApplications)
                    {

                        foreach (CompanionApplication compApp in tcapp.CompanionApplications)
                        {
                            if (compApp.CurrentStateDefID == CompanionApplication.States.ExCompanion)
                                compApp.AddingAccountOperation();

                            foreach (CompanionProcedure compProc in compApp.CompanionProcedures)
                            {
                                if (!compProc.IsCancelled)
                                {
                                    foreach (AccountTransaction accTrx in compProc.AccountTransactions)
                                    {
                                        if (accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER && accTrx.IsAllowedToCancel)
                                        {
                                            if (inpatientAdmission.NeedCompanion != true)
                                                accTrx.TurnToPatientShare(true);
                                            else
                                            {
                                                DateTime trxDate = accTrx.TransactionDate.Value.Date;
                                                if (companionTrxDateList.Contains(trxDate))
                                                    accTrx.TurnToPatientShare(true);
                                                else
                                                    companionTrxDateList.Add(trxDate);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        public void UndoCompanionApplications()
        {
            foreach (var compApp in LinkedActions)
            {
                if (compApp is CompanionApplication)
                {
                    if (compApp.CurrentStateDefID == CompanionApplication.States.ExCompanion)
                    {
                        ((ITTObject)compApp).UndoLastTransition();
                        ((CompanionApplication)compApp).CancelMySubactionProcedures();
                        ((CompanionApplication)compApp).ClearEndDate();
                    }
                }
            }
        }



        // Refakatçi İşlemleri 

        protected void FireNursingAndPhysicianApplication()
        {
            //foreach (EmergencyIntervention emergencyIntervention in this.Episode.EmergencyInterventions)
            //{
            //    if (emergencyIntervention.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
            //        throw new Exception(SystemMessage.GetMessage(594));
            //}
            InPatientPhysicianApplication inPatientPhysicianApplication = new InPatientPhysicianApplication(this);
            NursingApplication nursingApplication = new NursingApplication(this);
            SetAuthorizedUserOfInPatientPhysicianApplication();

            // Hasta transfer edilirken seçilen orderlarında yeni yatışa taşınması için yapıldı. SS 20.04.2020 Task No:63994
            if (this.FromInPatientTrtmentClinicApp != null)
            {
                List<DrugOrder> transferedOrders = this.FromInPatientTrtmentClinicApp.InPatientPhysicianApplication[0].DrugOrders.Where(x => x.IsTransfered == true).ToList();
                foreach (DrugOrder order in transferedOrders)
                {
                    order.Episode = inPatientPhysicianApplication.Episode;
                    order.SubEpisode = inPatientPhysicianApplication.SubEpisode;
                    order.MasterResource = inPatientPhysicianApplication.MasterResource;
                    order.SecondaryMasterResource = inPatientPhysicianApplication.SecondaryMasterResource;
                    order.InPatientPhysicianApplication = inPatientPhysicianApplication;
                    order.IsTransfered = false;
                    foreach (DrugOrderDetail drugOrderDetail in order.DrugOrderDetails)
                    {
                        if (drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.Cancel)
                        {
                            drugOrderDetail.Episode = inPatientPhysicianApplication.Episode;
                            drugOrderDetail.SubEpisode = inPatientPhysicianApplication.SubEpisode;
                            drugOrderDetail.MasterResource = inPatientPhysicianApplication.MasterResource;
                            drugOrderDetail.FromResource = inPatientPhysicianApplication.FromResource;
                            drugOrderDetail.SecondaryMasterResource = inPatientPhysicianApplication.SecondaryMasterResource;
                            drugOrderDetail.NursingApplication = nursingApplication;
                        }
                    }
                }
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
                string msg = "Klinik tek başına geri alınamaz ";
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


        public void CancelMyStarterObjects()
        {
            if (FromInPatientTrtmentClinicApp != null)// Kurum içi sevkle geldi ise sevkin gerçekleştiği Taburcu işlemini iptal eder ve Doktor işlemleri Ve klinik işlemlerini geri alır
            {
                if (FromInPatientTrtmentClinicApp.TreatmentDischarge != null)
                {

                    FromInPatientTrtmentClinicApp.TreatmentDischarge.UndoNursingAndPhysicianApplications = true; // True set eiliğinde direct iptal edilir
                    if (CurrentStateDef.Status != StateStatusEnum.Cancelled)
                    {
                        if (string.IsNullOrEmpty(FromInPatientTrtmentClinicApp.TreatmentDischarge.ReasonOfCancel))
                        {
                            FromInPatientTrtmentClinicApp.TreatmentDischarge.ReasonOfCancel = ReasonOfCancel;
                        }
                        FromInPatientTrtmentClinicApp.TreatmentDischarge.IsToInpatientClinicAppCancelled = true; // ToClinik işlemi iptal ediliyorsa kendi Taburcu işlemini de iptal etsin diye
                        ((ITTObject)FromInPatientTrtmentClinicApp.TreatmentDischarge).Cancel();
                        BaseInpatientAdmission.AllocateNewBed(false, true); // Eski Kliniğine geri giderken  eski klinği için  yeni BaseBedprocedure oluşsun diye
                    }
                }

                if (BaseInpatientAdmission is InpatientAdmission)
                {

                    ((InpatientAdmission)BaseInpatientAdmission).ActiveInPatientTrtmentClcApp = FromInPatientTrtmentClinicApp;

                }
                if (FromInPatientTrtmentClinicApp.InPatientPhysicianApplication.Count > 0)
                {
                    foreach (DrugOrder order in FromInPatientTrtmentClinicApp.InPatientPhysicianApplication[0].DrugOrders)
                    {
                        if (order.IsTransfered == true)
                            order.IsTransfered = false;
                    }
                }
            }
            else //ilk Klinik işlemi iptal edilirken InpatientAdmissionı da iptal eder
            {
                if (BaseInpatientAdmission is InpatientAdmission)
                {

                    ((InpatientAdmission)BaseInpatientAdmission).CancelledByMasterAction = true;
                    if (string.IsNullOrEmpty(BaseInpatientAdmission.ReasonOfCancel))
                    {
                        BaseInpatientAdmission.ReasonOfCancel = ReasonOfCancel;
                    }
                     ((ITTObject)BaseInpatientAdmission).Cancel();
                }
            }

        }

        public void CancelMyCompanionApplications()
        {
            foreach (var comp in LinkedActions)
            {
                if (comp is CompanionApplication)
                {
                    if (comp.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                    {
                        ((ITTObject)comp).Cancel();
                    }
                }
            }
        }


        public void Reject()
        {
            CancelMyStarterObjects();
            CancelMyCompanionApplications();


        }

        public void CheckToCancel()
        {
            string msg = string.Empty;
            foreach (var episodeAction in SubEpisode.EpisodeActions)
            {
                if (episodeAction.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    if (!(episodeAction is BaseInpatientAdmission || episodeAction is CompanionApplication || episodeAction is InPatientTreatmentClinicApplication || episodeAction is InPatientPhysicianApplication || episodeAction is NursingApplication))
                    {
                        msg = msg + "\n" + episodeAction.RequestDate.ToString() + "- " + episodeAction.ObjectDef.ApplicationName;
                    }
                    else
                    {
                        foreach (var subactionprocedure in episodeAction.SubactionProcedures)
                        {
                            if (subactionprocedure.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                            {
                                msg = msg + "\n" + subactionprocedure.CreationDate.ToString() + "- " + subactionprocedure.ProcedureObject.Name;
                            }
                        }

                        foreach (var treatmentMaterial in episodeAction.TreatmentMaterials)
                        {
                            if (treatmentMaterial.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                            {
                                msg = msg + "\n" + treatmentMaterial.ActionDate.ToString() + "- " + treatmentMaterial.Material.Name;
                            }
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(msg))
            {
                throw new Exception(TTUtils.CultureService.GetText("M25196", "Aşağıdaki işlemler iptal edilmeden .Yatış işlemi iptal edilemez\n") + msg);
            }


        }

        public override void Cancel()
        {
            CheckToCancel();
            if (CancelledByMasterAction == false)
            {
                CancelMyStarterObjects();
            }

            CancelMyCompanionApplications();

            BaseInpatientAdmission.DeallocateLastBed();
            foreach (InPatientPhysicianApplication inPatientPhysApp in InPatientPhysicianApplication)
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
            if (TreatmentDischarge != null)
            {
                TreatmentDischarge.UndoNursingAndPhysicianApplications = false;
                if (string.IsNullOrEmpty(TreatmentDischarge.ReasonOfCancel))
                {
                    TreatmentDischarge.ReasonOfCancel = ReasonOfCancel;
                }
               ((ITTObject)TreatmentDischarge).Cancel();
            }
            base.Cancel();
            // this.MasterResource.DeleteUsedInpatientQuota(this);

        }

        public override void UndoCancel()
        {
            NoBackStateBack();
        }


        public void CheckReponsibleDoctorIsChange()
        {
            if (((ITTObject)this).IsNew == false)
            {
                if (((ITTObject)this).HasOriginal)
                {
                    ResUser OldDoctor = ((InPatientTreatmentClinicApplication)((ITTObject)this).Original).ProcedureDoctor;

                    bool IsChanged = true;
                    if (OldDoctor == null && ProcedureDoctor == null)
                    {
                        IsChanged = false;
                    }
                    else if (OldDoctor != null && ProcedureDoctor != null)
                    {
                        if (OldDoctor.ObjectID == ProcedureDoctor.ObjectID)
                        {
                            IsChanged = false;
                        }
                    }

                    if (IsChanged)
                    {
                        InpatientResponsibleDoctor inpatientResponsibleDoctor = new InpatientResponsibleDoctor(ObjectContext);
                        inpatientResponsibleDoctor.Doctor = ProcedureDoctor;
                        inpatientResponsibleDoctor.SDateTime = Common.RecTime();
                        ResponsibleDoctors.Add(inpatientResponsibleDoctor);
                        //Allocation kapatıldı
                        //SetAuthorizedUserOfInPatientPhysicianApplication();

                    }
                }
            }
        }
        public void SetAuthorizedUserOfInPatientPhysicianApplication()
        {
            if (((ITTObject)this).IsNew == false)
            {
                //ResUser OldDoctor=((InPatientTreatmentClinicApplication)((ITTObject)this).Original).ResponsibleDoctor;
                foreach (InPatientPhysicianApplication physicianApplication in InPatientPhysicianApplication)
                {
                    if (!physicianApplication.IsCancelled)
                    {
                        physicianApplication.ProcedureDoctor = ProcedureDoctor;
                        //                        bool addNewAuthorizedUser=true;
                        //                        if (OldDoctor!=null)
                        //                        {
                        //                            if (physicianApplication.AuthorizedUsers.Count>0)
                        //                            {
                        //                                foreach(AuthorizedUser authorizedUser in physicianApplication.AuthorizedUsers)
                        //                                {
                        //                                    if(authorizedUser.User.ObjectID==OldDoctor.ObjectID)
                        //                                    {
                        //                                        if(this.ResponsibleDoctor!=null)
                        //                                        {
                        //                                            authorizedUser.User=this.ResponsibleDoctor;
                        //                                        }
                        //                                        else
                        //                                        {
                        //                                            //YAPILACAKLAR// İnstance silme gelince eski autorizedUser instance'ı silinmeli
                        //                                            physicianApplication.AuthorizedUsers.Remove(authorizedUser);
                        //                                        }
                        //                                        addNewAuthorizedUser=false;
                        //                                        break;
                        //                                    }
                        //                                }
                        //
                        //                            }
                        //                        }
                        //                        if(addNewAuthorizedUser)
                        //                        {
                        //                            if (this.ResponsibleDoctor!=null)
                        //                            {
                        //                                AuthorizedUser newAuthorizedUser = new AuthorizedUser(this.ObjectContext);
                        //                                newAuthorizedUser.User=(ResUser)this.ResponsibleDoctor;
                        //                                physicianApplication.AuthorizedUsers.Add(newAuthorizedUser);
                        //                            }
                        //                        }
                    }
                }
            }
        }


        public void ControlBedProcedureCount()
        {
            if (BaseInpatientAdmission is InpatientAdmission)
            {
                int yatisGunuFazlaligi = InpatientAdmission.GetExcessOfRealBedDayToBedProcedure((InpatientAdmission)BaseInpatientAdmission);//bedDay - bedProcedureCount;
                if (yatisGunuFazlaligi != 0)
                {
                    string message = string.Empty;
                    if (yatisGunuFazlaligi > 0)
                        message = "Hastanın yattığı gün sayısı " + yatisGunuFazlaligi.ToString() + " gün fazla.";
                    else
                        message = "Yatak hizmeti sayısı  " + ((-1) * yatisGunuFazlaligi).ToString() + " gün fazla.";

                    TTUtils.InfoMessageService.Instance.ShowMessage("Hastanın yattığı gün sayısı ile oluşan yatak hizmeti sayısı arasında uyumsuzluk vardır!\r\n " + message);
                    //string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Hastanın yattığı gün sayısı ile oluşan yatak hizmeti sayısı arasında uyumsuzluk vardır!\r\n " + message + "\r\nDevam etmek istiyor musunuz?", 1);
                    //if (result == "H")
                    //    throw new Exception(SystemMessage.GetMessage(80));
                }
            }

        }


        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList = base.OldActionPropertyList();
            if (propertyList == null)
                propertyList = new List<EpisodeAction.OldActionPropertyObject>();

            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M17649", "Klinik Protokol No"), Common.ReturnObjectAsString(ProtocolNo)));
            //            propertyList.Add(new OldActionPropertyObject("Klinik Yatış Tarihi",Common.ReturnObjectAsString(ClinicInpatientDate)));
            //            propertyList.Add(new OldActionPropertyObject("Klinik Çıkış Tarihi",Common.ReturnObjectAsString(ClinicDischargeDate)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M22986", "Tedavi Gördüğü Klinik"), Common.ReturnObjectAsString(MasterResource.Name)));
            if (ProcedureDoctor != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M22142", "Sorumlu Doktor"), Common.ReturnObjectAsString(ProcedureDoctor.Name)));
            if (ResponsibleNurse != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M22151", "Sorumlu Hemşire"), Common.ReturnObjectAsString(ResponsibleNurse.Name)));
            return propertyList;
        }

        public override List<EpisodeAction> GetLinkedEpisodeActionsForSubEpisode()
        {

            List<EpisodeAction> eaList = base.GetLinkedEpisodeActionsForSubEpisode();
            if (BaseInpatientAdmission != null && BaseInpatientAdmission is InpatientAdmission)
                eaList.Add((EpisodeAction)BaseInpatientAdmission);

            //Yatışın bağlı işlemlerine episode daki Ameliyat,Ek Ameliyat,Ameliyat Derleme,Anestezi Konsültasyonu ve Anestezi ve reanimasyon işlemleri de eklenir.(Subepisode ları aynı olsun diye.)

            if (SubEpisode.PatientStatus != SubEpisodeStatusEnum.Inpatient)// Yatan Hasta SubEpisodeunda başlatılan  Ameliyatlar yeni subepisodea taşınmaz (örneğin   yatan hastalar birimler arasın transfer edilirken ameliyatları yeni subepisoda taşınmaz)
            {
                BindingList<Surgery> surgeryList = Surgery.GetByEpisode(ObjectContext, Episode.ObjectID);
                foreach (Surgery surgery in surgeryList)
                {
                    eaList.Add((EpisodeAction)surgery);
                    foreach (SubSurgery subSurgery in surgery.SubSurgeries)
                    {
                        eaList.Add((EpisodeAction)subSurgery);
                    }
                    if (surgery.AnesthesiaAndReanimation != null)
                    {
                        eaList.Add((EpisodeAction)surgery.AnesthesiaAndReanimation);
                    }

                    if (surgery.SurgeryExtension != null)
                    {
                        eaList.Add((EpisodeAction)surgery.SurgeryExtension);
                    }

                }
            }

            //BindingList<IntensiveCareAfterSurgery> intensiveCareAfterSurgeryList = IntensiveCareAfterSurgery.GetByEpisode(this.ObjectContext, this.Episode.ObjectID);
            //foreach (IntensiveCareAfterSurgery intensiveCareAfterSurgery in intensiveCareAfterSurgeryList)
            //{
            //    eaList.Add((EpisodeAction)intensiveCareAfterSurgery);
            //}

            //BindingList<AnesthesiaConsultation> anesthesiaConsultationList = AnesthesiaConsultation.GetByEpisode(this.ObjectContext, this.Episode.ObjectID);
            //foreach (AnesthesiaConsultation anesthesiaConsultation in anesthesiaConsultationList)
            //{
            //    eaList.Add((EpisodeAction)anesthesiaConsultation);
            //}



            return eaList;
        }

        // MCA






        // Birimlerarası nakil olduğunda yatak hizmetleri son subepisode a aktarılıyor, bu yatak hizmetlerini
        // olması gereken subepisode ların altına atan metoddur
        public void ArrangeSubEpisodeOfBedProcedures()
        {
            //Artık patientTransfer yok düzenlenmeli
            // Vakada Birimlerarası Nakil işlemi varsa
            if (PatientTransfer.GetTransferredByEpisode(ObjectContext, Episode.ObjectID.ToString()).Count > 0)
            {
                bool isFirstSE = true;
                SubEpisode tempSE = null;
                IList subEpisodes;
                IList bedProcedures = BaseBedProcedure.GetByEpisodeOrderByFirstBed(ObjectContext, Episode.ObjectID.ToString());
                foreach (BaseBedProcedure bedProcedure in bedProcedures)
                {
                    if (bedProcedure.CurrentStateDef != null && bedProcedure.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                    {
                        if (bedProcedure.Eligible == false)
                        {
                            if (isFirstSE) // ilk yatan veya taburcu durumundaki subepisode alınır
                            {
                                subEpisodes = SubEpisode.GetInpatientAndDischargeByEpisode(ObjectContext, Episode.ObjectID.ToString());
                                if (subEpisodes.Count > 0)
                                    tempSE = (SubEpisode)subEpisodes[0];
                                isFirstSE = false;
                            }
                            else // Klinik İşlemlerinin oluşturduğu subepisode a ulaşılır
                            {
                                if (bedProcedure.EpisodeAction is PatientTransfer)
                                {
                                    if (((PatientTransfer)bedProcedure.EpisodeAction).NewInPatientTrtmentClinicApp != null)
                                    {
                                        subEpisodes = SubEpisode.GetByEpisodeAndStarterEpisodeAction(ObjectContext, Episode.ObjectID.ToString(), ((PatientTransfer)bedProcedure.EpisodeAction).NewInPatientTrtmentClinicApp.ObjectID.ToString());
                                        foreach (SubEpisode se in subEpisodes)
                                        {
                                            if (se.CurrentStateDefID == SubEpisode.States.Opened || se.CurrentStateDefID == SubEpisode.States.Closed)
                                                tempSE = se;
                                        }
                                    }
                                }
                            }
                        }
                        else if (bedProcedure.Eligible == true)
                        {
                            if (tempSE != null)
                                bedProcedure.SubEpisode = tempSE;
                        }
                    }
                }
            }
        }

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

                        if (ProcedureDoctor == null || ProcedureDoctor.ObjectID != Common.CurrentResource.ObjectID)
                            ProcedureDoctor = Common.CurrentResource;
                    }
                }
            }
        }


        public InPatientTreatmentClinicApplication GetMyActiveToInPatientTrtmentClinicApp()
        {
            foreach (var toInPatientTrtmentClinicApp in ToInPatientTrtmentClinicApp)
            {
                if (toInPatientTrtmentClinicApp.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                    return toInPatientTrtmentClinicApp;
            }
            return null;
        }


        public void ArrangeBedProceduresByClinicDischargeDate()
        {
            // Klinik Çıkış tarihi geri alındıysa o tarihten sonra girilmiş olabilecek yatakların iptali yada dischagre dateinin düzeltilmesi için 
            var basebedprocedures = BaseBedProcedures.OrderByDescending(dr => dr.BedDischargeDate);
            foreach (var baseBedprocedure in basebedprocedures)
            {
                if (baseBedprocedure.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    if (ClinicDischargeDate.Value.Date < baseBedprocedure.BedDischargeDate.Value.Date)
                    {
                        if (ClinicDischargeDate.Value.Date < baseBedprocedure.BedInPatientDate.Value.Date) // eğer yatak yatış tarihi de klinik çıkış traihinden küçükse o bedprocedure iptal edilir
                            ((ITTObject)baseBedprocedure).Cancel();
                        else // eğer yatak yatış tarihi  klinik çıkış tarihinden büyükse yanlızca yatak çıkış tarihi  olarak ClinicDischargeDate set edilir
                        {
                            baseBedprocedure.BedDischargeDate = ClinicDischargeDate;
                        }
                    }
                    else
                        break; // Dischargedatedan küçük olan bed procedurelere gelince bişey yapılmadan çıkılır
                }
            }

            var bedprocedures = Bedprocedures.Where(dr => dr.PricingDate.Value.Date > ClinicDischargeDate.Value.Date && dr.CurrentStateDef.Status != StateStatusEnum.Cancelled);
            foreach (var bedprocedure in bedprocedures)
            {
                ((ITTObject)bedprocedure).Cancel();
            }
        }

        public void ArrangeBedProceduresByClinicInpatientDate()
        {
            // Klinik Yatış tarihi geri alındıysa ilk yatağın tarihininde geri alınması için 
            var bedprocedures = BaseBedProcedures.OrderBy(dr => dr.BedInPatientDate);
            if (bedprocedures.Count() > 0)
            {
                foreach (var bedprocedure in bedprocedures)
                {
                    bedprocedure.BedInPatientDate = ClinicInpatientDate;
                    bedprocedure.CreationDate = ClinicInpatientDate;
                    if (bedprocedure.UsedStatus == UsedStatusEnum.Used || bedprocedure.UsedStatus == UsedStatusEnum.NotUsed)
                        break;// Dolu yada boşalmış olan ilk yatağı ve ondan önce  girilmiş rezerve yatakların başlangıç tarihini değiştiri
                }
            }

        }



        public void MedulaHastaCikisKayit(bool isPreDischarge)
        {
            if (IsOldAction != true) // Aktarımla gelen işlemlerde medulaya gitmesi gerekmiyor
            {
                if (BaseInpatientAdmission is InpatientAdmission)
                {
                    if (isPreDischarge || MedulaHastaCikisKayitFailed == true)
                    {
                        if (SubEpisode.IsSGK)
                        {
                            if (IsDailyOperation == true) // Günübirlik yatış için Medulaya hasta çıkış kayıt bildirilmesin.
                                return;

                            string basvuruNo = string.Empty;
                            var sep = SubEpisode.SGKSEPWithProvisionNo;
                            if (sep != null && !string.IsNullOrEmpty(sep.MedulaBasvuruNo))
                            {
                                basvuruNo = sep.MedulaBasvuruNo;
                            }

                            if (string.IsNullOrEmpty(basvuruNo))
                                return; //Arafta kalmış hasta

                            HastaKabulIslemleri.hastaCikisDVO hastaCikisDVO = new HastaKabulIslemleri.hastaCikisDVO();
                            hastaCikisDVO.hastaBasvuruNo = basvuruNo;

                            String ayrilisTarihi = Common.RecTime().ToString("dd.MM.yyyy");
                            if (ClinicDischargeDate.HasValue)
                                ayrilisTarihi = ClinicDischargeDate.Value.ToString("dd.MM.yyyy");

                            if (string.IsNullOrEmpty(ayrilisTarihi) == false)
                                hastaCikisDVO.hastaCikisTarihi = ayrilisTarihi;
                            else
                                throw new Exception("Medulaya çıkış kaydı için çıkış tarihi  belli olmalıdır!");

                            hastaCikisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                            try
                            {
                                HastaKabulIslemleri.hastaCikisCevapDVO response = HastaKabulIslemleri.WebMethods.hastaCikisKayitSync(TTObjectClasses.Sites.SiteLocalHost, hastaCikisDVO);
                                if (response.sonucKodu == "0000")
                                {
                                    InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25830", "Hastanın çıkış kaydı MEDULA'ya bildirildi."));
                                    //InfoBox.Alert("Hastanın çıkış kaydı MEDULA'ya bildirildi.", MessageIconEnum.InformationMessage);
                                    MedulaHastaCikisKayitFailed = false;
                                }
                                else if (response.sonucKodu == "1160") //meduladan zeten taburcu olmuş hasta için tekrar hata vermesin diye
                                {
                                    MedulaHastaCikisKayitFailed = false;
                                }
                                else
                                {
                                    throw new TTUtils.TTException(response.sonucMesaji);
                                }

                            }
                            catch (Exception ex)
                            {
                                if (isPreDischarge)
                                {
                                    if (InfoMessageService.Instance != null) // Modbilden çağırılınca bu Null geliyor
                                        InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25831", "Hastanın çıkış kaydı MEDULA'ya BİLDİRİLEMEDİ.") + ex);
                                    //InfoBox.Alert("Hastanın çıkış kaydı MEDULA'ya BİLDİRİLEMEDİ." + response.sonucMesaji, MessageIconEnum.WarningMessage);
                                    MedulaHastaCikisKayitFailed = true;
                                }
                                else
                                    throw ex;
                            }
                        }
                    }
                }
            }
        }


        public void CreateEpisodeFolder()// iptalini de düşün
        {
            //Yoksa hastanın Hasta dosyasını ve Vaka dosyasını oluşturur
            if (IsOldAction != true)
            {
                bool isNewEpisodeFolder = false;
                if (BaseInpatientAdmission.EpisodeFolder == null)
                {
                    EpisodeFolder episodeFolder = (EpisodeFolder)ObjectContext.CreateObject("EpisodeFolder");
                    episodeFolder.MyEpisode = Episode;
                    BaseInpatientAdmission.EpisodeFolder = episodeFolder;
                    isNewEpisodeFolder = true;
                }

                if (isNewEpisodeFolder)
                {
                    BaseInpatientAdmission.EpisodeFolder.AddEpisodeFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.FileCreated, MasterResource);
                    BaseInpatientAdmission.EpisodeFolder.AddEpisodeFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.AcknowledgedByDepartment, MasterResource);
                }
                else
                    BaseInpatientAdmission.EpisodeFolder.AddEpisodeFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.AcknowledgedByDepartment, MasterResource);

                BaseInpatientAdmission.EpisodeFolder.LastInPatientTreatment = this;
            }
        }



        /*
         * MEDULA HASTA ÇIKIŞ IPTAL
         * */
        public void MedulaHastaCikisIptal()
        {
            if (IsOldAction != true) // Aktarımla gelen işlemlerde medulaya gitmesi gerekmiyor
            {
                if (BaseInpatientAdmission is InpatientAdmission)
                {
                    if (SubEpisode.IsSGK)
                    {
                        if (IsDailyOperation == true) // Günübirlik yatış için Medulaya hasta çıkış iptali bildirilmez. (Günübirlik yatış, normal yatışa çevrilirken buraya giriyor)
                            return;

                        string basvuruNo = string.Empty;
                        foreach (SubEpisodeProtocol sep in Episode.AllSGKSubEpisodeProtocols())
                        {
                            if (!string.IsNullOrEmpty(sep.MedulaBasvuruNo))
                            {
                                basvuruNo = sep.MedulaBasvuruNo;
                                break;
                            }
                        }

                        if (string.IsNullOrEmpty(basvuruNo))
                        {
                            // throw new TTUtils.TTException("Hastanın geçerli bir başvurusu numarası yok. Medulaya çıkış iptal bildirimi için hastaya ait bir başvuru yapılmış olmalıdır.");
                            InfoMessageService.Instance.ShowMessage("Hastanın geçerli bir başvurusu numarası yok. Medulaya çıkış iptal bildirimi yapılmadı");
                        }
                        else
                        {
                            HastaKabulIslemleri.hastaCikisIptalDVO hastaCikisIptalDVO = new HastaKabulIslemleri.hastaCikisIptalDVO();
                            hastaCikisIptalDVO.hastaBasvuruNo = basvuruNo;

                            String ayrilisTarihi = ((InpatientAdmission)BaseInpatientAdmission).GetLatestDischargeDate();
                            if (string.IsNullOrEmpty(ayrilisTarihi) == false)
                                hastaCikisIptalDVO.hastaCikisTarihi = ayrilisTarihi;
                            else
                                throw new Exception("Medulaya çıkış iptal bildirimi için çıkış tarihi belli olmalıdır!");

                            hastaCikisIptalDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

                            HastaKabulIslemleri.hastaCikisCevapDVO response = HastaKabulIslemleri.WebMethods.hastaCikisIptalSync(TTObjectClasses.Sites.SiteLocalHost, hastaCikisIptalDVO);

                            if (response.sonucKodu == "1164") //Gönderdiğiniz hasta başvuru no ve hasta çıkış tarihine göre yatış kaydı bulunamamıştır.
                            {
                                InfoMessageService.Instance.ShowMessage(response.sonucMesaji);
                            }
                            else if (response.sonucKodu != "0000")
                                throw new TTUtils.TTException(response.sonucMesaji);
                            else
                            {
                                // InfoBox.Alert("Medulaya bildirilen çıkış kayıt işlemi iptal edidi", MessageIconEnum.InformationMessage)
                                InfoMessageService.Instance.ShowMessage("Medulaya bildirilen çıkış kayıt işlemi iptal edildi");

                            }
                        }
                    }
                }
            }
        }

        // Günübirlik yatıştan normal yatışa çeviren metod
        public void TurnFromDailyToInpatient()
        {
            if (CurrentStateDefID == InPatientTreatmentClinicApplication.States.Discharged)
            {
                UndoByMasterAction = true;
                ((ITTObject)this).UndoLastTransition(); // Procedure'a gider
            }

            IsDailyOperation = false; // Yeri burası olmalı, yukarıdaki UndoLastTransition dan sonra false yapılmalı, değiştirmeyin!

            if (SubEpisode.PatientStatus == SubEpisodeStatusEnum.Daily)
                SubEpisode.PatientStatus = SubEpisodeStatusEnum.Inpatient;

            SubEpisode.ResSection = GetSubEpisodeResSection();

            SubEpisodeProtocol sep = SubEpisode.SGKSEP;
            if (sep != null) // SGK takibi ise
            {
                if (sep.MedulaTedaviTuru.tedaviTuruKodu == "G")
                {
                    if (!string.IsNullOrEmpty(sep.MedulaTakipNo))
                    {
                        SubEpisodeProtocol.MedulaResult result = sep.DeleteProvisionFromMedula(); // Günübirlik takip silinir
                        if (!result.Succes)
                            throw new TTException("Günübirlik takip silinemedi. " + result.SonucKodu + " " + result.SonucMesaji);
                    }

                    sep.MedulaTedaviTuru = TedaviTuru.GetTedaviTuru("Y");

                    try
                    {
                        SubEpisodeProtocol.MedulaResult result = sep.GetProvisionFromMedula(); // Yatan takip alınır
                        if (!result.Succes)
                            InfoMessageService.Instance.ShowMessage("Yatış takibi alınamadı. " + result.SonucKodu + " " + result.SonucMesaji);
                    }
                    catch (Exception ex)
                    {
                        InfoMessageService.Instance.ShowMessage(ex.Message);
                    }
                }
            }
            else // SGK takibi değilse
            {
                sep = SubEpisode.FirstSubEpisodeProtocol; // İlk SEP alınır (SubEpisode oluşurken yaratılan SEP)

                if (sep != null && sep.MedulaTedaviTuru.tedaviTuruKodu == "G")
                    sep.MedulaTedaviTuru = TedaviTuru.GetTedaviTuru("Y");
            }

            // TODO : Gündüz yatak hizmeti iptal ediliyor mu ? Kontrol et !
            // TODO : Yatışa dönünce BaseBedProcedure oluşuyor mu ve bundan kaynaklı 1 tane BedProcedure oluşuyor mu ? Kontrol et !
        }

        // başka XXXXXXden sevkli gelen hastanın işlemi bitti diye >Medulaya bildirir
        //protected void SendMedulaSevkKayitSync()
        //{
        //    if (this.IsOldAction != true) // Aktarımla gelen işlemlerde medulaya gitmesi gerekmiyor
        //    {
        //        if (!(this.BaseInpatientAdmission is InpatientAdmission))
        //        {
        //            if (this.SubEpisode.IsSGK == true)
        //            {

        //                if (this.Episode != null && this.SubEpisode.PatientAdmission != null && this.SubEpisode.PatientAdmission.Sevkli != null && this.SubEpisode.PatientAdmission.Sevkli == true)
        //                {

        //                    // şimdilik kapatıldı Mutatnd dışı araç ayarlanınca açılacak
        //                    //if (this.MutatDisiAracRaporId.Value == null)
        //                    //    this.MutatDisiAracRaporId.GetNextValueFromDatabase(null, 0);
        //                    if (MedulaSevkKayitSync())
        //                        InfoBox.Alert("Sevkli hastanın kaydi medulaya bildirildi.", MessageIconEnum.InformationMessage);
        //                    else
        //                        throw new Exception("Sevkli hastanın bilgilerinin medulaya kaydı sırasında hata oluştu!");
        //                }
        //            }
        //        }
        //    }
        //}


        //protected void CancelMedulaSevkKayitSync()
        //{
        //    if (this.IsOldAction != true) // Aktarımla gelen işlemlerde allocate edilmesi gerekmiyor
        //    {
        //        if (!(this.BaseInpatientAdmission is InpatientAdmission))
        //        {
        //            if (this.SubEpisode.IsSGK == true)
        //            {
        //                if (this.Episode != null && this.SubEpisode.PatientAdmission != null && this.SubEpisode.PatientAdmission.Sevkli != null && this.SubEpisode.PatientAdmission.Sevkli == true)
        //                {
        //                    InpatientAdmission inpatientAdmission = this.BaseInpatientAdmission as InpatientAdmission;
        //                    InfoBox.Alert("Medulaya bildirilen sevk kaydı iptal edilecektir", MessageIconEnum.InformationMessage);
        //                    if (inpatientAdmission.MedulaESevkNo != null)
        //                        inpatientAdmission.MedulaESevkKayitIptalSync();
        //                    //MutatDisiAra yapılınca açılacak
        //                    //if (string.IsNullOrEmpty(inpatientAdmission.MedulaMutatDisiAracRaporNo) == false && !inpatientAdmission.MedulaMutatDisiAracRaporNo.Equals("0"))
        //                    //    MutatDisiAracRaporSilSync();
        //                }
        //            }
        //        }
        //    }
        //}
        ///*
        //* MEDULA SEVK KAYIT METODU
        //* */
        //public bool MedulaSevkKayitSync()
        //{

        //    try
        //        {
        //        if (this.IsOldAction != true) // Aktarımla gelen işlemlerde medulaya gitmesi gerekmiyor
        //            return true;
        //        if (!(this.BaseInpatientAdmission is InpatientAdmission))
        //                return true;
        //            var inpatientAdmission = this.BaseInpatientAdmission as InpatientAdmission;
        //            SevkIslemleri.sevkCevapDVO sevkCevapDVO = SevkIslemleri.WebMethods.sevkKayitSync(TTObjectClasses.Sites.SiteLocalHost, GetSevkKayitDVO());
        //            if (sevkCevapDVO != null)
        //            {
        //                if (string.IsNullOrEmpty(sevkCevapDVO.sonucKodu) == false)
        //                {
        //                    if (sevkCevapDVO.sonucKodu.Equals("0000"))
        //                    {
        //                        InfoBox.Alert("E-sevk kayıt işlemi başarı ile sonuçlandı.  Sevk Takip No: " + sevkCevapDVO.sevkTakipNo + "  E-Sevk No: " + sevkCevapDVO.esevkNo.ToString(), MessageIconEnum.InformationMessage);
        //                        inpatientAdmission.MedulaESevkNo = sevkCevapDVO.esevkNo.ToString();
        //                        return true;
        //                    }
        //                    else
        //                    {
        //                        if (string.IsNullOrEmpty(sevkCevapDVO.sonucMesaji) == false)
        //                            throw new Exception("E-sevk kayıt işleminde hata var: Sonuç Mesajı :" + sevkCevapDVO.sonucMesaji);
        //                        else
        //                            throw new Exception("E-sevk kayıt işleminde hata var");
        //                    }
        //                }
        //                else
        //                {
        //                    if (string.IsNullOrEmpty(sevkCevapDVO.sonucMesaji) == false)
        //                        throw new Exception("E-sevk kayıt işleminde hata var:Sonuç Mesajı :" + sevkCevapDVO.sonucMesaji);
        //                    else
        //                        throw new Exception("E-sevk kayıt işleminde hata var");
        //                }
        //            }
        //            else
        //                throw new Exception("Medulaya e-sevk kayıt işlemi yapılamadı!");

        //        }
        //        catch (Exception e)
        //        {
        //            throw new Exception("Medulaya e-sevk kayıt işlemi sırasında sistem hatası oluştu! Hata: " + e.Message);
        //        }
        //        //return false;

        //}


        ///*
        // * MEDULA SEVK KAYIT DVO HAZIRLANMASI
        // * */

        //public SevkIslemleri.sevkKayitDVO GetSevkKayitDVO()
        //{
        //    InpatientAdmission inpatientAdmission = this.BaseInpatientAdmission as InpatientAdmission;

        //    SevkIslemleri.sevkKayitDVO sevkKayitDVO = new SevkIslemleri.sevkKayitDVO();

        //    // *kabulTakipNo : Sevkin kabulünün yapıldığı takip numarası

        //    if (inpatientAdmission.Episode != null && inpatientAdmission.SubEpisode.PatientAdmission != null && inpatientAdmission.SubEpisode.SGKSEP.MedulaTakipNo != null && inpatientAdmission.SubEpisode.SGKSEP.MedulaTakipNo != null)
        //        sevkKayitDVO.kabulTakipNo = inpatientAdmission.SubEpisode.SGKSEP.MedulaTakipNo;
        //    else
        //        throw new Exception("Medulaya e-sevk  kayıt işleminde kabul takip no alanı dolu olmalıdır!");

        //    // donusVasitasi
        //    if (inpatientAdmission.MedulaSevkDonusVasitasi != null && inpatientAdmission.MedulaSevkDonusVasitasi.sevkVasitasiKodu != null)
        //        sevkKayitDVO.donusVasitasi = Convert.ToInt32(inpatientAdmission.MedulaSevkDonusVasitasi.sevkVasitasiKodu);
        //    else
        //        throw new Exception("Medulaya e-sevk kayıt işleminde dönüş vasıtası alanı dolu olmalıdır!");

        //    if (inpatientAdmission.MedulaRefakatciDurumu != null)
        //    {
        //        if (inpatientAdmission.MedulaRefakatciDurumu.Value == true)
        //            sevkKayitDVO.refakatci = "E";
        //        else
        //            sevkKayitDVO.refakatci = "H";
        //    }
        //    else
        //        throw new Exception("Medulaya e-sevk kayıt işleminde refakatçi durumu alanı dolu olmalıdır!");

        //    //* ayrilisTarihi
        //    String ayrilisTarihi = InpatientAdmission.GetLatestDischargeDate(inpatientAdmission);
        //    if (string.IsNullOrEmpty(ayrilisTarihi) == false)
        //        sevkKayitDVO.ayrilisTarihi = ayrilisTarihi;
        //    else
        //        throw new Exception("Medulaya e-sevk kaydı yapılabilmesi için; XXXXXXden ayrılış tarihi dolu olmalıdır!");

        //    //raporId : Mutat dışı araç rapor numarası. Mutat dışı araç değilse 0 yollanacaktır.
        //    if (inpatientAdmission.MedulaSevkDonusVasitasi != null && inpatientAdmission.MedulaSevkDonusVasitasi.sevkVasitasiKodu != null)
        //    {
        //        if (!inpatientAdmission.MedulaSevkDonusVasitasi.sevkVasitasiKodu.Equals("1") && !inpatientAdmission.MedulaSevkDonusVasitasi.sevkVasitasiKodu.Equals("12"))
        //        {
        //            if (MutatDisiAracRaporKaydetSync())
        //            {
        //                if (inpatientAdmission.MedulaMutatDisiAracRaporNo != null)
        //                    sevkKayitDVO.raporId = Convert.ToInt64(inpatientAdmission.MedulaMutatDisiAracRaporNo);
        //                else
        //                    throw new Exception("Medulaya e-sevk kaydında öncelikle mutat dışı araç rapor kaydının yapılması gerekmektedir!");
        //            }
        //            else
        //            {
        //                throw new Exception("Medulaya e-sevk kaydında öncelikle mutat dışı araç rapor kaydının yapılması gerekmektedir!");
        //            }
        //        }
        //        else
        //        {
        //            inpatientAdmission.MedulaMutatDisiAracRaporNo = "0";
        //            sevkKayitDVO.raporId = Convert.ToInt64(inpatientAdmission.MedulaMutatDisiAracRaporNo);
        //        }
        //    }

        //    //*tedaviTani -> SevkTaniDVO[]
        //    SevkIslemleri.sevkTaniDVO[] sevkTaniList = GetSevkTaniDVOList("Medulaya e-sevk kaydında");
        //    if (sevkTaniList != null)
        //        sevkKayitDVO.tedaviTani = sevkTaniList;
        //    else
        //        throw new Exception("Medulaya e-sevk kaydında hastaya ait tanı girilmiş olmalıdır!");

        //    // *sevkEdenDoktor   -> SevkDoktorDVO[]
        //    SevkIslemleri.sevkDoktorDVO[] sevkDoktorList = GetSevkMutatDisiDoktorDVOList("Medulaya e-sevk kaydında");
        //    if (sevkDoktorList != null)
        //        sevkKayitDVO.tedaviEdenDoktor = sevkDoktorList;
        //    else
        //        throw new Exception("Medulaya e-sevk kaydında tedavi eden doktorların bilgileri girilmiş olmalıdır!");

        //    // *sevkTedavi: SevkTedaviDVO[]
        //    SevkIslemleri.sevkTedaviDVO[] sevkTedaviList = GetSevkTedaviDVOList();
        //    if (sevkTedaviList != null)
        //        sevkKayitDVO.sevkTedavi = sevkTedaviList;
        //    else
        //        throw new Exception("Medulaya e-sevk kaydında sevk tedavi bilgileri girilmiş olmalıdır!");


        //    // *kullaniciTesisKodu
        //    sevkKayitDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

        //    return sevkKayitDVO;
        //}

        //public SevkIslemleri.sevkTaniDVO[] GetSevkTaniDVOList(string type)
        //{
        //    var inpatientAdmission = this.BaseInpatientAdmission as InpatientAdmission;
        //    List<SevkIslemleri.sevkTaniDVO> sevkTaniDVOList = null;
        //    if (inpatientAdmission.Episode != null)
        //    {
        //        sevkTaniDVOList = new List<SevkIslemleri.sevkTaniDVO>();

        //        foreach (String diagnose in Episode.GetMyMedulaDiagnosisDefinitionICDCodes(inpatientAdmission.Episode))
        //        {
        //            SevkIslemleri.sevkTaniDVO sevkTaniDVO = new SevkIslemleri.sevkTaniDVO();
        //            sevkTaniDVO.sevkTaniKodu = diagnose;
        //            sevkTaniDVOList.Add(sevkTaniDVO);
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception(type + " hastaya ait tanı girilmiş olmalıdır!");
        //    }
        //    return sevkTaniDVOList.ToArray();
        //}

        //public SevkIslemleri.sevkTedaviDVO[] GetSevkTedaviDVOList()
        //{
        //    var inpatientAdmission = this.BaseInpatientAdmission as InpatientAdmission;
        //    List<SevkIslemleri.sevkTedaviDVO> sevkTedaviDVOList = null;

        //    if (inpatientAdmission.InPatientTreatmentClinicApplications != null)
        //    {
        //        sevkTedaviDVOList = new List<SevkIslemleri.sevkTedaviDVO>();
        //        foreach (InPatientTreatmentClinicApplication inPtntTrtmntClncApp in inpatientAdmission.InPatientTreatmentClinicApplications)
        //        {
        //            if (inPtntTrtmntClncApp != null)
        //            {
        //                SevkIslemleri.sevkTedaviDVO sevkTedaviDVO = new SevkIslemleri.sevkTedaviDVO();

        //                //baslangicTarihi
        //                if (inPtntTrtmntClncApp.ClinicInpatientDate != null && inPtntTrtmntClncApp.ClinicInpatientDate.Value != null)
        //                    sevkTedaviDVO.baslangicTarihi = inPtntTrtmntClncApp.ClinicInpatientDate.Value.ToShortDateString();

        //                //bitisTarihi
        //                if (inPtntTrtmntClncApp.ClinicDischargeDate != null && inPtntTrtmntClncApp.ClinicDischargeDate.Value != null)
        //                    sevkTedaviDVO.bitisTarihi = inPtntTrtmntClncApp.ClinicDischargeDate.Value.ToShortDateString();

        //                //tedavi türü
        //                // her klinikte farklı bir tedavi türü olabilir mi? Ayaktan yada yatan olarak?????
        //                if (inpatientAdmission.Episode != null && inpatientAdmission.Episode.PatientStatus != null)
        //                {

        //                    if (inpatientAdmission.Episode.PatientStatus.Value == PatientStatusEnum.Inpatient)
        //                        sevkTedaviDVO.tedaviTuru = "Y";
        //                    else if (inpatientAdmission.Episode.PatientStatus.Value == PatientStatusEnum.Outpatient)
        //                        sevkTedaviDVO.tedaviTuru = "A";
        //                    else if (inpatientAdmission.Episode.PatientStatus.Value == PatientStatusEnum.Discharge|| inpatientAdmission.Episode.PatientStatus.Value == PatientStatusEnum.PreDischarge)
        //                        sevkTedaviDVO.tedaviTuru = "S";
        //                    else
        //                        throw new Exception("Sevkte yapılan tedavi türü dolu olmalıdır!");

        //                }
        //                sevkTedaviDVOList.Add(sevkTedaviDVO);
        //            }

        //        }
        //    }
        //    else
        //        throw new Exception("Sevkte yapılan tedaviler dolu olmalıdır!");

        //    if (sevkTedaviDVOList.Count <= 0)
        //        throw new Exception("Sevkte yapılan tedaviler dolu olmalıdır!");

        //    return sevkTedaviDVOList.ToArray();
        //}


        //public SevkIslemleri.sevkDoktorDVO[] GetSevkDoktorDVOList(string type)
        //{
        //    var inpatientAdmission = this.BaseInpatientAdmission as InpatientAdmission;
        //    List<SevkIslemleri.sevkDoktorDVO> sevkDoktorDVOList = null;
        //    if (inpatientAdmission.InPatientTreatmentClinicApplications != null)
        //    {
        //        sevkDoktorDVOList = new List<SevkIslemleri.sevkDoktorDVO>();
        //        foreach (InPatientTreatmentClinicApplication inPtntTrtmntClncApp in inpatientAdmission.InPatientTreatmentClinicApplications)
        //        {
        //            if (inPtntTrtmntClncApp != null && inPtntTrtmntClncApp.ProcedureDoctor != null)
        //            {

        //                SevkIslemleri.sevkDoktorDVO sevkDoktorDVO = new SevkIslemleri.sevkDoktorDVO();
        //                // *doktorTescilNo
        //                if (inPtntTrtmntClncApp.ProcedureDoctor.DiplomaRegisterNo != null)
        //                    sevkDoktorDVO.doktorTescilNo = inPtntTrtmntClncApp.ProcedureDoctor.DiplomaRegisterNo;
        //                else
        //                    throw new Exception(type + " hastaya tedavi yapan doktorun tescil numarası dolu olmalıdır!");

        //                // *doktorTipi
        //                if (inPtntTrtmntClncApp.ProcedureDoctor.Title != null)
        //                {
        //                    if (inPtntTrtmntClncApp.ProcedureDoctor.Title.Value.Equals(UserTitleEnum.DisDoctor) || inPtntTrtmntClncApp.ProcedureDoctor.Title.Value.Equals(UserTitleEnum.DocDisDoctor) || inPtntTrtmntClncApp.ProcedureDoctor.Title.Value.Equals(UserTitleEnum.ProfDisTabip) || inPtntTrtmntClncApp.ProcedureDoctor.Title.Value.Equals(UserTitleEnum.YrdDocDisDoctor))
        //                        sevkDoktorDVO.doktorTipi = "2";
        //                    else
        //                        sevkDoktorDVO.doktorTipi = "1";
        //                }
        //                else
        //                {
        //                    throw new Exception(type + " sevk eden doktorun tipi dolu olmalıdır!");

        //                }

        //                // *bransKodu
        //                if (inPtntTrtmntClncApp.ProcedureDoctor.ResourceSpecialities != null)
        //                {
        //                    String brans = ResUser.GetAnaUzmanlikBrans(inPtntTrtmntClncApp.ProcedureDoctor, type);
        //                    if (brans != null)
        //                        sevkDoktorDVO.bransKodu = brans;
        //                }
        //                else
        //                    throw new Exception(type + " sevkli hastaya tedavi yapan doktor'un ana uzmanlık dalı olan branş bilgisi girilmiş olmalıdır!");

        //                sevkDoktorDVOList.Add(sevkDoktorDVO);
        //            }
        //            else
        //                throw new Exception("Sevkli hastayı tedavi eden doktorlar dolu olmalıdır!");

        //        }
        //    }
        //    else
        //        throw new Exception("Sevkli hastayı tedavi eden doktorlar dolu olmalıdır!");

        //    if (sevkDoktorDVOList.Count <= 0)
        //        throw new Exception("Sevkli hastayı tedavi eden doktorlar dolu olmalıdır!");

        //    return sevkDoktorDVOList.ToArray();
        //}

        //public SevkIslemleri.sevkDoktorDVO[] GetSevkMutatDisiDoktorDVOList(string type)
        //{
        //    var inpatientAdmission = this.BaseInpatientAdmission as InpatientAdmission;
        //    List<SevkIslemleri.sevkDoktorDVO> sevkDoktorDVOList = null;
        //    if (inpatientAdmission.InPatientTreatmentClinicApplications != null)
        //    {
        //        sevkDoktorDVOList = new List<SevkIslemleri.sevkDoktorDVO>();
        //        foreach (DoctorGrid doctorGrid in inpatientAdmission.DoctorsGrid)
        //        {
        //            SevkIslemleri.sevkDoktorDVO sevkDoktorDVO = new SevkIslemleri.sevkDoktorDVO();
        //            // *doktorTescilNo
        //            if (doctorGrid.ResUser.DiplomaRegisterNo != null)
        //                sevkDoktorDVO.doktorTescilNo = doctorGrid.ResUser.DiplomaRegisterNo;
        //            else
        //                throw new Exception(type + " hastaya tedavi yapan doktorun tescil numarası dolu olmalıdır!");

        //            // *doktorTipi
        //            if (doctorGrid.ResUser.Title != null)
        //            {
        //                if (doctorGrid.ResUser.Title.Value.Equals(UserTitleEnum.DisDoctor) || doctorGrid.ResUser.Title.Value.Equals(UserTitleEnum.DocDisDoctor) || doctorGrid.ResUser.Title.Value.Equals(UserTitleEnum.ProfDisTabip) || doctorGrid.ResUser.Title.Value.Equals(UserTitleEnum.YrdDocDisDoctor))
        //                    sevkDoktorDVO.doktorTipi = "2";
        //                else
        //                    sevkDoktorDVO.doktorTipi = "1";
        //            }
        //            else
        //            {
        //                throw new Exception(type + " sevk eden doktorun tipi dolu olmalıdır!");

        //            }

        //            // *bransKodu
        //            if (doctorGrid.ResUser.ResourceSpecialities != null)
        //            {
        //                String brans = ResUser.GetAnaUzmanlikBrans(doctorGrid.ResUser, type);
        //                if (brans != null)
        //                    sevkDoktorDVO.bransKodu = brans;
        //            }
        //            else
        //                throw new Exception(type + " sevkli hastaya tedavi yapan doktor'un ana uzmanlık dalı olan branş bilgisi girilmiş olmalıdır!");

        //            sevkDoktorDVOList.Add(sevkDoktorDVO);
        //        }
        //    }
        //    else
        //        throw new Exception("Sevkli hastayı tedavi eden doktorlar dolu olmalıdır!");

        //    if (sevkDoktorDVOList.Count <= 0)
        //        throw new Exception("Sevkli hastayı tedavi eden doktorlar dolu olmalıdır!");

        //    return sevkDoktorDVOList.ToArray();
        //}



        ///*
        // * MEDULA MUTAT DIŞI ARAÇ RAPOR KAYDET METODU
        // * */

        //public bool MutatDisiAracRaporKaydetSync()
        //{

        //    try
        //    {
        //        if (this.IsOldAction != true) // Aktarımla gelen işlemlerde medulaya gitmesi gerekmiyor
        //            return true;
        //        var inpatientAdmission = this.BaseInpatientAdmission as InpatientAdmission;
        //        SevkIslemleri.mutatDisiRaporCevapDVO mutatDisiRaporCevapDVO = SevkIslemleri.WebMethods.mutatDisiAracRaporKaydetSync(TTObjectClasses.Sites.SiteLocalHost, GetMutatDisiRaporDVO());
        //        if (mutatDisiRaporCevapDVO != null)
        //        {
        //            if (string.IsNullOrEmpty(mutatDisiRaporCevapDVO.sonucKodu) == false)
        //            {
        //                if (mutatDisiRaporCevapDVO.sonucKodu.Equals("0000"))
        //                {
        //                    InfoBox.Alert("Mutat dışı araç rapor bildirim işlemi başarı ile sonuçlandı. Rapor id: " + mutatDisiRaporCevapDVO.raporId, MessageIconEnum.InformationMessage);
        //                    inpatientAdmission.MedulaMutatDisiAracRaporNo = mutatDisiRaporCevapDVO.raporId.ToString();
        //                    return true;
        //                }
        //                else
        //                {
        //                    if (string.IsNullOrEmpty(mutatDisiRaporCevapDVO.sonucMesaji) == false)
        //                        throw new Exception("Mutat dışı araç rapor bildiriminde hata var. Sonuç Mesajı :" + mutatDisiRaporCevapDVO.sonucMesaji);
        //                    else
        //                        throw new Exception("Mutat dışı araç rapor bildiriminde hata var.Sonuç mesajı alanı boş.Sonuç Kodu: " + mutatDisiRaporCevapDVO.sonucKodu);
        //                }
        //            }
        //            else
        //            {
        //                if (string.IsNullOrEmpty(mutatDisiRaporCevapDVO.sonucMesaji) == false)
        //                    throw new Exception("Mutat dışı araç rapor bildiriminde hata var. Sonuç Mesajı :" + mutatDisiRaporCevapDVO.sonucMesaji);
        //                else
        //                    throw new Exception("Medulaya mutat dışı araç rapor bildirimi yapılması sırasında hata oluştu! Sonuç Kodu alanı boş!");
        //            }

        //        }
        //        else
        //            throw new Exception("Medulaya mutat dışı araç rapor bildirimi yapılamadı.Cevap dönmedi!");

        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    //return false;
        //}



        ///*
        // * MEDULA MUTAT DIŞI RAPOR DVO HAZIRLANMASI
        // * */

        //public SevkIslemleri.mutatDisiRaporDVO GetMutatDisiRaporDVO()
        //{

        //    var inpatientAdmission = this.BaseInpatientAdmission as InpatientAdmission;
        //    SevkIslemleri.mutatDisiRaporDVO mutatDisiRaporDVO = new SevkIslemleri.mutatDisiRaporDVO();
        //    // *haksahibiTCNO
        //    if (inpatientAdmission.Episode != null && inpatientAdmission.Episode.Patient != null && inpatientAdmission.Episode.Patient.UniqueRefNo != null)
        //        mutatDisiRaporDVO.haksahibiTCNO = Convert.ToInt64(inpatientAdmission.Episode.Patient.UniqueRefNo);
        //    else
        //        throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken sevk edilen hasta TC kimlik no alanı dolu olmalıdır!");

        //    // XXXXXX tarafından verilen rapor no
        //    // *raporNo
        //    //            TTObjectContext context= new TTObjectContext(true);
        //    //            InpatientAdmission inpAdd = (InpatientAdmission)context.GetObject(inpatientAdmission.ObjectID, typeof(InpatientAdmission).Name);
        //    if (inpatientAdmission.MutatDisiAracRaporId.Value != null)
        //        mutatDisiRaporDVO.raporNo = inpatientAdmission.MutatDisiAracRaporId.Value.ToString();
        //    else
        //        throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken XXXXXX tarafından üretilen rapor ID gönderilmelidir!");


        //    // *protokolNo
        //    if (inpatientAdmission.Episode != null && inpatientAdmission.Episode.HospitalProtocolNo != null && inpatientAdmission.Episode.HospitalProtocolNo.Value != null)
        //        mutatDisiRaporDVO.protokolNo = inpatientAdmission.Episode.HospitalProtocolNo.Value.ToString();
        //    else
        //        throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken protokol numarası alanı dolu olmalıdır!");

        //    // *sevkVasitasi
        //    if (inpatientAdmission.MedulaSevkDonusVasitasi != null && inpatientAdmission.MedulaSevkDonusVasitasi.sevkVasitasiKodu != null)
        //        mutatDisiRaporDVO.sevkVasitasi = Convert.ToInt32(inpatientAdmission.MedulaSevkDonusVasitasi.sevkVasitasiKodu);
        //    else
        //        throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken sevk vasıtası alanı dolu olmalıdır!");

        //    // raporTarihi
        //    if (inpatientAdmission.MutatDisiAracRaporTarihi != null)
        //        mutatDisiRaporDVO.raporTarihi = inpatientAdmission.MutatDisiAracRaporTarihi.Value.ToShortDateString().ToString();
        //    else
        //        throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken rapor tarihi alanı dolu olmalıdır!");

        //    // baslangicTarihi
        //    if (inpatientAdmission.MutatDisiAracBaslangicTarihi != null)
        //        mutatDisiRaporDVO.baslangicTarihi = inpatientAdmission.MutatDisiAracBaslangicTarihi.Value.ToShortDateString().ToString();
        //    else
        //        throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken başlangıç tarihi alanı dolu olmalıdır!");

        //    // bitisTarihi
        //    if (inpatientAdmission.MutatDisiAracBitisTarihi != null)
        //        mutatDisiRaporDVO.bitisTarihi = inpatientAdmission.MutatDisiAracBitisTarihi.Value.ToShortDateString().ToString();
        //    else
        //        throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken bitiş tarihi alanı dolu olmalıdır!");

        //    // refakatciGerekcesi
        //    if (inpatientAdmission.MedulaRefakatciGerekcesi != null)
        //        mutatDisiRaporDVO.refakatciGerekcesi = inpatientAdmission.MedulaRefakatciGerekcesi;

        //    //Mutat Dışı Araç Rapor Gerekçesi
        //    // mutatDisiGerekcesi
        //    if (inpatientAdmission.MutatDisiGerekcesi != null)
        //        mutatDisiRaporDVO.mutatDisiGerekcesi = inpatientAdmission.MutatDisiGerekcesi;

        //    // *sevkTani
        //    SevkIslemleri.sevkTaniDVO[] sevkTaniList = GetSevkTaniDVOList("Medulaya mutat dışı araç rapor bildiriminde");
        //    if (sevkTaniList != null)
        //        mutatDisiRaporDVO.sevkTani = sevkTaniList;
        //    else
        //        throw new Exception("Medulaya mutat dışı araç rapor bildiriminde hastaya ait tanı girilmiş olmalıdır!");

        //    // sevkEdenDoktor
        //    SevkIslemleri.sevkDoktorDVO[] sevkDoktorList = GetSevkMutatDisiDoktorDVOList("Medulaya mutat dışı araç rapor bildiriminde");
        //    if (sevkDoktorList != null)
        //        mutatDisiRaporDVO.sevkEdenDoktor = sevkDoktorList;
        //    else
        //        throw new Exception("Medulaya mutat dışı araç rapor bildiriminde sevk eden doktorların bilgileri girilmiş olmalıdır!");

        //    // *kullaniciTesisKodu
        //    mutatDisiRaporDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

        //    return mutatDisiRaporDVO;
        //}
        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InPatientTreatmentClinicApplication).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == InPatientTreatmentClinicApplication.States.Discharged && toState == InPatientTreatmentClinicApplication.States.Cancelled)
                PostTransition_Discharged2Cancelled();
            if (fromState == InPatientTreatmentClinicApplication.States.Discharged && toState == InPatientTreatmentClinicApplication.States.Procedure)
                PostTransition_Discharged2Procedure();
            else if (fromState == InPatientTreatmentClinicApplication.States.Acception && toState == InPatientTreatmentClinicApplication.States.Cancelled)
                PostTransition_Acception2Cancelled();
            else if (fromState == InPatientTreatmentClinicApplication.States.Acception && toState == InPatientTreatmentClinicApplication.States.Procedure)
                PostTransition_Acception2Procedure();
            else if (fromState == InPatientTreatmentClinicApplication.States.Acception && toState == InPatientTreatmentClinicApplication.States.Rejected)
                PostTransition_Acception2Rejected();
            else if (fromState == InPatientTreatmentClinicApplication.States.Procedure && toState == InPatientTreatmentClinicApplication.States.Discharged)
                PostTransition_Procedure2Discharged();
            else if (fromState == InPatientTreatmentClinicApplication.States.Procedure && toState == InPatientTreatmentClinicApplication.States.Transferred)
                PostTransition_Procedure2Transferred();
            else if (fromState == InPatientTreatmentClinicApplication.States.Procedure && toState == InPatientTreatmentClinicApplication.States.Cancelled)
                PostTransition_Procedure2Cancelled();
            else if (fromState == InPatientTreatmentClinicApplication.States.Transferred && toState == InPatientTreatmentClinicApplication.States.Cancelled)
                PostTransition_Transferred2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InPatientTreatmentClinicApplication).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            CheckUndo();
            if (fromState == InPatientTreatmentClinicApplication.States.Discharged && toState == InPatientTreatmentClinicApplication.States.Cancelled)
                UndoTransition_Discharged2Cancelled(transDef);
            else if (fromState == InPatientTreatmentClinicApplication.States.Acception && toState == InPatientTreatmentClinicApplication.States.Cancelled)
                UndoTransition_Acception2Cancelled(transDef);
            else if (fromState == InPatientTreatmentClinicApplication.States.Acception && toState == InPatientTreatmentClinicApplication.States.Procedure)
                UndoTransition_Acception2Procedure(transDef);
            else if (fromState == InPatientTreatmentClinicApplication.States.Acception && toState == InPatientTreatmentClinicApplication.States.Rejected)
                UndoTransition_Acception2Rejected(transDef);
            else if (fromState == InPatientTreatmentClinicApplication.States.Procedure && toState == InPatientTreatmentClinicApplication.States.Discharged)
                UndoTransition_Procedure2Discharged(transDef);
            else if (fromState == InPatientTreatmentClinicApplication.States.Procedure && toState == InPatientTreatmentClinicApplication.States.Transferred)
                UndoTransition_Procedure2Transferred(transDef);
            else if (fromState == InPatientTreatmentClinicApplication.States.Procedure && toState == InPatientTreatmentClinicApplication.States.Cancelled)
                UndoTransition_Procedure2Cancelled(transDef);
            else if (fromState == InPatientTreatmentClinicApplication.States.Transferred && toState == InPatientTreatmentClinicApplication.States.Cancelled)
                UndoTransition_Transferred2Cancelled(transDef);
        }

    }
}