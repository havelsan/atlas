
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

namespace TTObjectClasses
{
    /// <summary>
    /// Hasta
    /// </summary>
    public partial class Patient : Person, ISUTPatient, IOldActions
    {
        public partial class OLAP_deneme_Class : TTReportNqlObject
        {
        }

        public partial class GetPatientByInjection_Class : TTReportNqlObject
        {
        }

        public partial class GetPatientExistsByUniqueRefNO_RQ_Class : TTReportNqlObject
        {
        }

        public partial class GetPatientInformation_RQ_Class : TTReportNqlObject
        {
        }

        public partial class VEM_HASTA_Class : TTReportNqlObject
        {
        }

        public partial class VEM_HASTA_ARSIV_Class : TTReportNqlObject
        {
        }


        public partial class MernisPatientModel
        {
            public string KPSName
            {
                get;
                set;
            }

            public string KPSSurname
            {
                get;
                set;
            }

            public string KPSMotherName
            {
                get;
                set;
            }

            public string KPSFatherName
            {
                get;
                set;
            }

            public string KPSBirthPlace
            { set; get; }

            public bool KPSAlive
            {
                get;
                set;
            }

            public bool KPSForeign
            {
                get;
                set;
            }

            public long? KPsForeignUniqueRefNo
            {
                get;
                set;
            }

            public long? KPSUniqueRefNo
            {
                get;
                set;
            }

            public SKRSUlkeKodlari KPSNationality;
            public SKRSCinsiyet KPSSex;
            public DateTime? KPSBirthDate;
            public DateTime? KPSExDate;
            public SKRSMedeniHali SKRSMaritalStatus;

            public string KPSNationalityName;
            public string SKRSMaritalStatusName;
            public string KPSSexName;
            public string HomeAddress { get; set; }
        }
        /// <summary>
        /// Hastanın Doğum Tarihinden İtibaren Geçen Gün Sayısı
        /// </summary>
        public int? GetAgeDay()
        {
            try
            {
                #region AgeDay_GetScript                    
                if (BirthDate.HasValue)
                {
                    DateTime now = TTObjectDefManager.ServerTime;
                    DateTime birthDate = BirthDate.Value;
                    return (int?)Common.DateDiff(Common.DateIntervalEnum.Day, now, birthDate);
                }
                return (int?)0;
                #endregion AgeDay_GetScript
            }
            catch (Exception ex)
            {
                throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", TTUtils.CultureService.GetText("M25130", "AgeDay")) + " : " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Hastanın Doğum Tarihinden İtibaren Geçen Ay Sayısı
        /// </summary>
        public int? GetAgeMonth()
        {
            try
            {
                #region AgeMonth_GetScript                    
                if (BirthDate.HasValue)
                {
                    DateTime now = TTObjectDefManager.ServerTime;
                    DateTime birthDate = BirthDate.Value;
                    return (int?)Common.DateDiff(Common.DateIntervalEnum.Month, now, birthDate);
                }
                return (int?)0;
                #endregion AgeMonth_GetScript
            }
            catch (Exception ex)
            {
                throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "AgeMonth") + " : " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Hasta Numarası ve Adı Soyadı Bilgisini Birleştirir
        /// </summary>
        public string PatientIDandFullName
        {
            get
            {
                try
                {
                    #region PatientIDandFullName_GetScript                    
                    return RefNo.ToString() + " " + Name + " " + Surname;
                    #endregion PatientIDandFullName_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "PatientIDandFullName") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Hastanın Doğum Tarihinden Hesaplanan Yaş Bilgisi
        /// </summary>

        private int? _age = null;
        [TTStorageManager.Attributes.TTSerializeProperty]
        public int? Age
        {
            get
            {
                try
                {
                    if (_age.HasValue)
                        return _age.Value;

                    #region StoreStock_GetScript              

                    if (((ITTObject)this).IsDeleted == false)
                    {
                        if (BirthDate.HasValue)
                        {
                            DateTime now = TTObjectDefManager.ServerTime;
                            DateTime birthDate = BirthDate.Value;
                            return (int?)Common.DateDiff(Common.DateIntervalEnum.Year, now, birthDate);
                        }
                    }
                    return (int?)0;
                    #endregion StoreStock_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "Age") + " : " + ex.Message, ex);
                }
            }
        }
        /// <summary>
        /// Hastanın Adı Soyadı Bilgisini Birleştirir
        /// </summary>
        public string FullName
        {
            get
            {
                try
                {
                    #region FullName_GetScript                    
                    return Name + " " + Surname;
                    #endregion FullName_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "FullName") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
                    #region FullName_SetScript                    
                    //this["FullName"] = value;
                    #endregion FullName_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "FullName") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Yabancı Hastaların Yabancı Sigorta Nosunu;Yerli Hastaların TC. Kimlik Nosunu Döndürür.
        /// </summary>
        public string RefNo
        {
            get
            {
                try
                {
                    #region RefNo_GetScript                    
                    if (Foreign == true)
                        return "(*) " + Convert.ToString(UniqueRefNo);//.ToString();
                    else
                        return Convert.ToString(UniqueRefNo);//.ToString();
                    #endregion RefNo_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "RefNo") + " : " + ex.Message, ex);
                }
            }
        }


        /// <summary>
        /// Hastanın Ölü Olduğu yada Önemli Tıbbi Bilgilerinin Dolu olduğu Durumlarda Hasta İsmini Başında Çıkacak Uyarı İkonu
        /// </summary>
        public string SubStringOfName
        {
            get
            {
                try
                {
                    #region SubStringOfName_GetScript                    
                    string subString = "";
                    if (Alive == false)
                    {
                        subString += "- EX ";
                    }

                    return (string)subString;
                    #endregion SubStringOfName_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "SubStringOfName") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Hastanın Doğum Tarihinden Hesaplanan Tamamlanmış Yaş Bilgisi
        /// </summary>
        public int? AgeCompleted
        {
            get
            {
                try
                {
                    #region AgeCompleted_GetScript                    
                    if (BirthDate.HasValue)
                    {
                        DateTime now = TTObjectDefManager.ServerTime;
                        DateTime birthDate = BirthDate.Value;
                        return (int?)Common.DateDiff(Common.DateIntervalEnum.YearCompleted, now, birthDate);
                    }
                    return (int?)0;
                    #endregion AgeCompleted_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "AgeCompleted") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Gizli hasta ise true döner.
        /// </summary>
        public bool? IsPatientPrivacy
        {
            get
            {
                try
                {
                    #region IsPatientPrivacy_GetScript                    
                    if (Privacy.HasValue == true && Privacy.Value == true)//&& this.PrivacyEndDate.Value.Date >= Common.RecTime().Date
                        return true;
                    return false;
                    #endregion IsPatientPrivacy_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "IsPatientPrivacy") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// 9Y 10A 2G Formatında Yaş Bilgisini Döner
        /// </summary>
        public string CalculatedAge
        {
            get
            {
                try
                {
                    #region CalculatedAge_GetScript                    
                    string calculatedAge = "";
                    if (BirthDate.HasValue)
                    {
                        DateTime now = TTObjectDefManager.ServerTime;
                        DateTime birthDate = BirthDate.Value;

                        int year = Common.DateDiff(Common.DateIntervalEnum.YearCompleted, now, birthDate);
                        int monthLeftOver = Common.DateDiff(Common.DateIntervalEnum.MonthLeftOver, now, birthDate);
                        int dayLeftOver = Common.DateDiff(Common.DateIntervalEnum.DayLeftOver, now, birthDate);

                        if (year != 0)
                            calculatedAge += Convert.ToString(year) + "Y ";
                        if (monthLeftOver != 0)
                            calculatedAge += Convert.ToString(monthLeftOver) + "A ";
                        if (dayLeftOver != 0)
                            calculatedAge += Convert.ToString(dayLeftOver) + "G";

                    }

                    return calculatedAge;
                    #endregion CalculatedAge_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "CalculatedAge") + " : " + ex.Message, ex);
                }
            }
        }

        public bool hasMedicalInformation()
        {
            if (MedicalInformation != null)
            {
                if (MedicalInformation.ChronicDiseases != null || MedicalInformation.Transplantation != null || MedicalInformation.Hemodialysis != null
                    || MedicalInformation.OncologicFollowUp != null || MedicalInformation.Implant != null || MedicalInformation.OtherInformation != null
                    || MedicalInformation.HeartFailure == true || MedicalInformation.Broken == true || MedicalInformation.Pregnancy == true
                    || MedicalInformation.Diabetes == true || MedicalInformation.Malignancy == true || MedicalInformation.MetalImplant == true
                    || MedicalInformation.VascularDisorder == true || MedicalInformation.CardiacPacemaker == true
                    || MedicalInformation.Infection == true || MedicalInformation.Stent == true || MedicalInformation.Other == true
                    || MedicalInformation.HasAllergy == VarYokGarantiEnum.V || MedicalInformation.HasContagiousDisease == VarYokGarantiEnum.V
                    || MedicalInformation.Pandemic == true)
                    return true;
                else if (MedicalInformation.MedicalInfoDisabledGroup != null)
                {
                    if (MedicalInformation.MedicalInfoDisabledGroup.Chronic == true
                    || MedicalInformation.MedicalInfoDisabledGroup.Vision == true || MedicalInformation.MedicalInfoDisabledGroup.Hearing == true
                    || MedicalInformation.MedicalInfoDisabledGroup.Mental == true || MedicalInformation.MedicalInfoDisabledGroup.SpeechAndLanguage == true
                    || MedicalInformation.MedicalInfoDisabledGroup.Orthopedic == true || MedicalInformation.MedicalInfoDisabledGroup.PsychicAndEmotional == true
                    || MedicalInformation.MedicalInfoDisabledGroup.Unclassified == true)
                        return true;
                }
                //else if (this.MedicalInformation.MedicalInfoHabits != null) //Task 56550
                //{
                //    if (this.MedicalInformation.MedicalInfoHabits.Cigarette == true || this.MedicalInformation.MedicalInfoHabits.Alcohol == true
                //    || this.MedicalInformation.MedicalInfoHabits.Other == true || this.MedicalInformation.MedicalInfoHabits.Description != null
                //    || this.MedicalInformation.MedicalInfoHabits.Tea == true || this.MedicalInformation.MedicalInfoHabits.Coffee == true)
                //        return true;
                //}

                if (MedicalInformation.HasAllergy == VarYokGarantiEnum.V ||
                    (MedicalInformation.MedicalInfoAllergies != null && MedicalInformation.MedicalInfoAllergies.MedicalInfoFoodAllergies.Count() > 0) ||
                    (MedicalInformation.MedicalInfoAllergies != null && MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies.Count() > 0))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsPatientAllergic()
        {
            if (MedicalInformation != null)
            {
                if (MedicalInformation.HasAllergy == VarYokGarantiEnum.V ||
                   (MedicalInformation.MedicalInfoAllergies != null && MedicalInformation.MedicalInfoAllergies.MedicalInfoFoodAllergies.Count() > 0) ||
                   (MedicalInformation.MedicalInfoAllergies != null && MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies.Count() > 0))
                {
                    return true;
                }
            }
            return false;
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "PATIENTGROUP":
                    {
                        PatientGroupEnum? value = (PatientGroupEnum?)(int?)newValue;
                        #region PATIENTGROUP_SetScript
                        bool setEmpty = true;
                        if (value != null)
                        {
                            TTObjectContext readOnlyContext = new TTObjectContext(true);
                            PatientGroupDefinition pGroupDefinition = Common.PatientGroupDefinitionByEnum(readOnlyContext, value.Value);
                            if (pGroupDefinition != null)
                            {
                                if (pGroupDefinition.Beneficiary != null)
                                {
                                    if (pGroupDefinition.Beneficiary.Value != BeneficiaryEnum.Empty)
                                    {
                                        Beneficiary = pGroupDefinition.Beneficiary.Value;
                                        setEmpty = false;
                                    }
                                }
                            }
                        }
                        if (setEmpty)
                            Beneficiary = BeneficiaryEnum.NotBeneficiary;// Defaultu Hak Sahibi Değil
                        #endregion PATIENTGROUP_SetScript
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


            if (BirthDate != null)
                BirthDate = (Convert.ToDateTime(BirthDate)).Date;

            if (UnIdentified == true)
            {
                if (Name == null)
                    Name = TTUtils.CultureService.GetText("M26306", "Kimliği");
                if (Surname == null)
                    Surname = TTUtils.CultureService.GetText("M25275", "Bilinmiyor");
            }
            else
            {
                if (Surname == null)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25791", "Hasta kaydı ile ilgili bir sorun oluştu. Lütfen ATLAS çözüm merkezine başvurunuz."));
            }

            if (Privacy != true)
            {
                if (Foreign != null && Foreign == false && Mother == null)
                {
                    if (UniqueRefNo == null && UnIdentified != null && UnIdentified == false)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26307", "Kimliği bilinmeyen veya yabancı olmayan hastalarda TC Kimlik No zorunludur!"));

                    //                IBindingList list = Patient.GetPatientExistsByUniqueRefNO_RQ((Int32)this.UniqueRefNo);
                    //                if(list.Count > 1)
                    //                    throw new TTUtils.TTException("Hasta kaydı ile ilgili bir sorun oluştu. Lütfen XXXXXX çözüm merkezine başvurunuz.");
                }
            }
            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert

            ControlAndCreateAPR();

            CreatePatientTokens();
            if (SendPatientToSitesAllowed)
            {
                SendPatientToSites();
                //SendPatientToSPTS();
            }
            #endregion PostInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate
            base.PreUpdate();

            #endregion PreUpdate
        }

        protected override void PostUpdate()
        {
            #region PostUpdate









            base.PostUpdate();
            CreatePatientTokens();










            #endregion PostUpdate
        }

        #region Methods

        public MedulaYardimciIslemler.kurumSevkTalepNoSorguCevapDVO kurumSevkTalepNoSorgu()
        {
            try
            {
                MedulaYardimciIslemler.kurumSevkTalepNoSorguCevapDVO result = null;
                MedulaYardimciIslemler.kurumSevkTalepNoSorguGirisDVO girisDVO = new MedulaYardimciIslemler.kurumSevkTalepNoSorguGirisDVO();
                girisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                if (UniqueRefNo.HasValue)
                    girisDVO.tcKimlikNo = UniqueRefNo.Value;
                result = MedulaYardimciIslemler.WebMethods.kurumSevkTalepNoSorguSync(Sites.SiteLocalHost, girisDVO);

                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// TC Kimlik Numarasının Mernis standartlarına uygunluğunu test eder
        /// </summary>
        /// <returns>bool</returns>
        public bool CheckMernisNumber()
        {
            String uniqueRefNo = Convert.ToString(UniqueRefNo);
            if (uniqueRefNo.Substring(0, 2) == "99") //Yabancı olan ve TC'si 99 ile başlayan hastalarda problem olmaması için MC
                return true;

            while (uniqueRefNo.Length < 11)
                uniqueRefNo = "0" + uniqueRefNo;
            bool retVal = false;
            Int32 checkSum = Convert.ToInt32(uniqueRefNo.Substring(9, 2));
            Int32 oddDigSum = Convert.ToInt32(uniqueRefNo.Substring(8, 1)) + Convert.ToInt32(uniqueRefNo.Substring(6, 1)) + Convert.ToInt32(uniqueRefNo.Substring(4, 1)) + Convert.ToInt32(uniqueRefNo.Substring(2, 1)) + Convert.ToInt32(uniqueRefNo.Substring(0, 1));
            Int32 oddDigSum_temp = oddDigSum;
            Int32 evenDigSum = Convert.ToInt32(uniqueRefNo.Substring(7, 1)) + Convert.ToInt32(uniqueRefNo.Substring(5, 1)) + Convert.ToInt32(uniqueRefNo.Substring(3, 1)) + Convert.ToInt32(uniqueRefNo.Substring(1, 1));
            Int32 total = oddDigSum * 3 + evenDigSum;
            Int32 addTo1 = (10 - (total % 10)) % 10;
            oddDigSum = addTo1 + evenDigSum;
            evenDigSum = oddDigSum_temp;
            total = oddDigSum * 3 + evenDigSum;
            Int32 addTo2 = (10 - (total % 10)) % 10;
            total = addTo1 * 10 + addTo2;
            if (total == checkSum)
                retVal = true;
            return retVal;
        }
        public bool SendPatientToSitesAllowed = false;

        protected override void OnConstruct()
        {
            base.OnConstruct();
            //ITTObject thePatient = (ITTObject)this;
            //if (thePatient.IsNew)
            //{
            //    this.ID.GetNextValue();
            //}
        }

        public override string ToString()
        {
            return FullName;
        }

        private bool _openPatientInfoForm = false;
        public bool OpenPatientInfoForm
        {
            get
            {
                return _openPatientInfoForm;
            }
            set
            {
                _openPatientInfoForm = value;
            }
        }

        private bool _isSmartCardActive = false;
        public bool IsSmartCardActive
        {
            get
            {
                return _isSmartCardActive;
            }
            set
            {
                _isSmartCardActive = value;
            }
        }

        public AccountPayableReceivable MyAPR()
        {
            if (APR.Count == 0)
                ControlAndCreateAPR();

            return APR[0];
        }

        public void ControlAndCreateAPR()
        {
            if (APR.Count > 0)
                return;

            AccountPayableReceivable apr = new AccountPayableReceivable(ObjectContext);
            apr.Type = APRTypeEnum.PATIENT;
            apr.Name = FullName;
            apr.Balance = 0;
            apr.Patient = this;
        }

        public static string PatientHasDebt(Patient patient, TTObjectContext objectContext)
        {
            if (patient.ObjectContext.QueryObjects<PatientOldDebt>("OLDUNIQUEREFNO = '" + patient.UniqueRefNo + "' AND (ISREMOVED = 0 OR ISREMOVED IS NULL)").Count(x => x.OldDebtReceiptDocument == null) > 0)
                return TTUtils.CultureService.GetText("M25836", "Hastanın önceki HBYS sisteminden borcu bulunmaktadır. Lütfen vezneye yönlendiriniz.");

            string result = Patient.PatientHasAccTrxDebt(patient, objectContext);

            if (result == string.Empty)
                result = Patient.PatientHasBondDebt(patient, objectContext);

            return result;
        }

        // Ödenmemiş hasta payı hizmet/malzeme var mı kontrolünü yapar
        public static string PatientHasAccTrxDebt(Patient patient, TTObjectContext objectContext)
        {
            StringBuilder queryParams = new StringBuilder();
            queryParams.Append(" AND SUBEPISODES(SUBEPISODEPROTOCOLS(ACCOUNTTRANSACTIONS(CURRENTSTATE = STATES.NEW AND PACKAGEDEFINITION IS NULL AND INVOICEINCLUSION = 1 AND ACCOUNTPAYABLERECEIVABLE.TYPE = 0).EXISTS).EXISTS).EXISTS");

            PatientEpisodePaymentDetail ppd = null;
            Currency remainingDebt = 0;
            BindingList<Episode> episodeList = Episode.GetEpisodesByPatient(objectContext, patient.ObjectID.ToString(), queryParams.ToString());

            foreach (Episode episode in episodeList)
            {
                ppd = Episode.CalculatePatientDebt(episode, null, null);
                remainingDebt += ppd.RemainingDebt;
            }

            if (remainingDebt > 0)
                return TTUtils.CultureService.GetText("M25826", "Hastanın borcu bulunmaktadır. Lütfen vezneye yönlendiriniz.");

            return string.Empty;
        }

        // Vadesi geçmiş ve ödenmemiş senedi var mı kontrolünü yapar
        public static string PatientHasBondDebt(Patient patient, TTObjectContext objectContext)
        {
            DateTime lastDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
            StringBuilder queryParams = new StringBuilder();
            queryParams.Append(" AND BONDS(CURRENTSTATE NOT IN (STATES.CANCELLED, STATES.RESTRUCTURED, STATES.PAID) AND BONDDETAILS(CURRENTSTATE = STATES.NEW AND DATE < TODATE('" + lastDate.ToString("yyyy-MM-dd HH:mm:ss") + "')).EXISTS).EXISTS");

            BindingList<Episode> episodeList = Episode.GetEpisodesByPatient(objectContext, patient.ObjectID.ToString(), queryParams.ToString());
            if (episodeList.Count() > 0)
                return TTUtils.CultureService.GetText("M25859", "Hastanın vade tarihi geçmiş ve ödenmemiş senedi bulunmaktadır. Lütfen vezneye veya senet birimine yönlendiriniz.");

            return string.Empty;
        }

        /// <summary>
        /// Hastanın yaşını gün,ay,yıl olarak döndürür.hgtnshr
        /// </summary>
        /// <returns></returns>
        public string AgeByYearByMonthByDay()
        {
            if (BirthDate.HasValue)
            {
                DateTime _now = Common.RecTime().Date;
                DateTime _birthDate = BirthDate.Value;
                int _year = Common.DateDiff(Common.DateIntervalEnum.YearCompleted, _now, _birthDate);
                int _month = Common.DateDiff(Common.DateIntervalEnum.MonthLeftOver, _now, _birthDate);
                int _day = Common.DateDiff(Common.DateIntervalEnum.DayLeftOver, _now, _birthDate);
                string _result = Convert.ToString(_year) + " Yıl " + Convert.ToString(_month) + " Ay " + Convert.ToString(_day) + " Gün";
                return _result;
            }
            return null;
        }

        /// <summary>
        /// Hastanın belirli bir tarihteki yaşını yıl olarak döndürür
        /// </summary>
        /// <returns></returns>
        public int AgeBySpecificDate(DateTime specificDate)
        {
            if (BirthDate.HasValue)
            {
                DateTime birthDate = BirthDate.Value;
                return (int)Common.DateDiff(Common.DateIntervalEnum.Year, specificDate, birthDate);
            }
            return (int)0;
        }

        /// <summary>
        /// Hastanın yaşını ay olarak döndürür.
        /// </summary>
        /// <returns></returns>
        public int AgeByMonth
        {
            get
            {
                if (BirthDate.HasValue)
                {
                    DateTime _now = Common.RecTime().Date;
                    DateTime _birthDate = BirthDate.Value;
                    return Common.DateDiff(Common.DateIntervalEnum.Month, _now, _birthDate);
                }
                return 0;
            }
        }

        /// <summary>
        /// Hastanın yaşını gün olarak döndürür.
        /// </summary>
        /// <returns></returns>
        public int AgeByDay
        {
            get
            {
                if (BirthDate.HasValue)
                {
                    DateTime _now = Common.RecTime().Date;
                    DateTime _birthDate = BirthDate.Value;
                    return Common.DateDiff(Common.DateIntervalEnum.Day, _now, _birthDate);
                }
                return 0;
            }
        }

        /// <summary>
        /// Hastanın yaşını gün olarak döndürür.
        /// </summary>
        /// <returns></returns>
        public int AgeByDayBySpecificDate(DateTime specificDate)
        {
            if (BirthDate.HasValue)
            {
                DateTime _birthDate = BirthDate.Value;
                return Common.DateDiff(Common.DateIntervalEnum.Day, specificDate, _birthDate);
            }
            return 0;
        }

        /// <summary>
        /// Hastanın vakalarında açık işlem varsa "true" döner.
        /// </summary>
        /// <returns>bool</returns>
        public bool HasUnCompletedEpisodeAction()
        {
            foreach (Episode episode in Episodes)
            {
                foreach (EpisodeAction episodeAction in episode.EpisodeActions)
                {
                    if (episodeAction.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Hastanın ismi üzerinden arama verileri (PatientTokens) oluşturur
        /// </summary>
        public void CreatePatientTokens()
        {
            if (HasMemberChanged("NAME") || HasMemberChanged("SURNAME") || (NameIsUpdated.HasValue && NameIsUpdated.Value == true) || (SurnameIsUpdated.HasValue && SurnameIsUpdated.Value == true))
            {
                string patientName = Name;
                string patientSurname = Surname;
                char[] charSeparators = new char[] { ' ' };
                //string[] patientNameArray = patientName.Split(charSeparators,StringSplitOptions.RemoveEmptyEntries);
                //string[] patientSurnameArray = patientSurname.Split(charSeparators,StringSplitOptions.RemoveEmptyEntries);

                ArrayList deletedObjects = new ArrayList();

                BindingList<PatientToken> patientTokens = PatientTokens.Select(null);

                foreach (PatientToken patientToken in patientTokens)
                {
                    ITTObject o = (ITTObject)patientToken;
                    deletedObjects.Add(o);
                }

                foreach (ITTObject o in deletedObjects)
                {
                    o.Delete();
                }

                ArrayList NameTokens = new ArrayList();
                NameTokens = Common.Tokenize(patientName, false);
                patientName = "";
                foreach (string s in NameTokens)
                {
                    PatientToken patientToken = new PatientToken(ObjectContext);
                    patientToken.Patient = this;
                    patientToken.TokenType = PatientTokenTypeEnum.Name;
                    patientToken.Token = s;
                    PatientTokens.Add(patientToken);
                    patientName += s + " ";
                }
                if (Name != null)
                    Name = Name.TrimEnd(charSeparators);

                NameTokens = Common.Tokenize(patientSurname, false);
                patientSurname = "";
                foreach (string s in NameTokens)
                {
                    PatientToken patientToken = new PatientToken(ObjectContext);
                    patientToken.Patient = this;
                    patientToken.TokenType = PatientTokenTypeEnum.Surname;
                    patientToken.Token = s;
                    PatientTokens.Add(patientToken);
                    patientSurname += s + " ";
                }
                if (Surname != null)
                    Surname = Surname.TrimEnd(charSeparators);
                NameIsUpdated = false;
                SurnameIsUpdated = false;
            }
        }



        /// <summary>
        /// Eski işlemlerde gözükecek hasta bilgilerini hazırlar
        /// </summary>
        /// <returns>Eski işlemlerde gözükecek hasta bilgileri</returns>
        public string OldActionReportHtml()
        {
            string report = "";
            report = report + "<html><table border=1 width='100%'>";
            if (ForeignUniqueRefNo == null)
                report = report + "<tr>" + Common.FormatAsOldActionTitle(TTUtils.CultureService.GetText("M27071", "TC.Kimlik No"), null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(UniqueRefNo), " colspan=3") + "</tr>";
            else
                report = report + "<tr>" + Common.FormatAsOldActionTitle(TTUtils.CultureService.GetText("M26308", "Kimlik/Sigorta No(Yabancı Hastalar)"), null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(ForeignUniqueRefNo), " colspan=3") + "</tr>";
            report = report + "<tr>" + Common.FormatAsOldActionTitle(TTUtils.CultureService.GetText("M15131", "Hasta Adı"), null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(FullName), " colspan=3") + "</tr>";
            report = report + "<tr>" + Common.FormatAsOldActionTitle("Cinsiyeti", null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(Sex), " colspan=3") + "</tr>";
            report = report + "<tr>" + Common.FormatAsOldActionTitle(TTUtils.CultureService.GetText("M11390", "Baba Adı"), null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(FatherName), " colspan=3") + "</tr>";
            report = report + "<tr>" + Common.FormatAsOldActionTitle(TTUtils.CultureService.GetText("M25169", "Ana Adı"), null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(MotherName), " colspan=3") + "</tr>";
            report = report + "<tr>" + Common.FormatAsOldActionTitle(TTUtils.CultureService.GetText("M13132", "Doğum Tarihi"), null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(BirthDate), null);
            report = report + Common.FormatAsOldActionTitle(TTUtils.CultureService.GetText("M24349", "Yaşı"), null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(Age), null) + "</tr>";
            report = report + "<tr>" + Common.FormatAsOldActionTitle(TTUtils.CultureService.GetText("M27162", "Ülke"), null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(CountryOfBirth), " colspan=3") + "</tr>";
            if (CityOfBirth != null)
                report = report + "<tr>" + Common.FormatAsOldActionTitle(TTUtils.CultureService.GetText("M25511", "Doğum ili"), null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(CityOfBirth), " colspan=3") + "</tr>";
            if (TownOfBirth != null)
                report = report + "<tr>" + Common.FormatAsOldActionTitle(TTUtils.CultureService.GetText("M25509", "Doğum ilçesi"), null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(TownOfBirth), " colspan=3") + "</tr>";
            //  report = report + "<tr>" + Common.FormatAsOldActionTitle("Medeni Durumu", null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(MaritalStatus), null);
            //   report = report + Common.FormatAsOldActionTitle("Kan Grubu", null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(BloodGroup), null) + "</tr>";
            report = report + "<tr>" + Common.FormatAsOldActionTitle(TTUtils.CultureService.GetText("M19476", "Not"), null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(Note), " colspan=3") + "</tr>";
            report = report + "</table></html>";


            if (ImportantMedicalInformation != null)
            {
                report = report + "<html><table border=1 width='100%'>";
                report = report + "<tr>" + "  ÖNEMLİ TIBBİ BİLGİLER " + "</tr>";
                report = report + "</table></html>";
                report = report + ImportantMedicalInformation.OldActionReportHtml();
            }

            return report;
        }

        /// <summary>
        /// Eski işlemlerde gözükecek özet hasta bilgilerini döndürür.
        /// </summary>
        /// <returns>Eski işlemlerde gözükecek özet hasta bilgileri</returns>
        public string OldActionSummaryReportHtml()
        {
            string report = "";
            report = report + "<html><table border=1 width='100%'>";
            report = report + "<tr>" + Common.FormatAsOldActionTitle(TTUtils.CultureService.GetText("M15133", "Hasta Adı Soyadı"), null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(FullName), " colspan=3") + "</tr>";
            report = report + "<tr>" + Common.FormatAsOldActionTitle(TTUtils.CultureService.GetText("M13132", "Doğum Tarihi"), null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(BirthDate), null);
            report = report + Common.FormatAsOldActionTitle(TTUtils.CultureService.GetText("M24349", "Yaşı"), null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(Age), null) + "</tr>";
            report = report + "</table></html>";
            return report;
        }


        /// <summary>
        /// Hastayı tüm sahalara gönder.
        /// </summary>
        public void SendPatientToSites()
        {
            //AfterCommitte Taşınmak isterse LastUpdateSiteGuid mantığı çalışmaz...
            Guid mySiteGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            List<Patient> pList = new List<Patient>();

            // Hasta gönderilirken lokal bilgileri null'lanır;
            Episode tempInpatientEpisode = InpatientEpisode;
            ImportantMedicalInformation tempImportantMedicalInformation = ImportantMedicalInformation;
            InpatientEpisode = null;
            ImportantMedicalInformation = null;
            //--
            pList.Add(this);
            //Hasta dosyası birleştirilmiş ise birleşilen hasta da gönderilir.
            Patient mergedToPatient = null;
            Episode tempMergedInpatientEpisode = null;
            ImportantMedicalInformation tempMergedImportantMedicalInformation = null;

            ITTObject iTTObject = (ITTObject)this;
            if (iTTObject.IsNew == false)
            {
                Patient originalPatient = ((ITTObject)this).Original as Patient;
                if (originalPatient != null)
                {
                    //MergedPatient property'si dolu olan ama merged patient nesnesinin pakete girmediği durumu engellemek için comment'lendi.
                    //                    if (originalPatient.MergedToPatient != this.MergedToPatient)
                    //                    {
                    if (MergedToPatient != null)
                    {
                        mergedToPatient = MergedToPatient;
                        tempMergedInpatientEpisode = mergedToPatient.InpatientEpisode;
                        tempMergedImportantMedicalInformation = mergedToPatient.ImportantMedicalInformation;
                        mergedToPatient.InpatientEpisode = null;
                        mergedToPatient.ImportantMedicalInformation = null;
                        pList.Add(mergedToPatient);
                    }
                    //                    }
                }
            }

            if (mergedToPatient != null)
            {
                mergedToPatient.InpatientEpisode = tempMergedInpatientEpisode;
                mergedToPatient.ImportantMedicalInformation = tempMergedImportantMedicalInformation;
                //  mergedToPatient.LastUpdateSiteGuid = Guid.Empty;
            }
        }


        public static bool IsAdmittingAllPatientGroupFromSiteAllowed()
        {
            return true;
        }

        /// <summary>
        /// Hasta MPVT Hastası ise MPVT'den gelen özellik XXXXXX tarafından değiştirilememesini sağlar.
        /// </summary>
        /// <param name="propDef">TTObjectPropertyDef tipinde değiştirilen özellik</param>
        /// <returns>Bool olarak değiştirilip değiştirilemeyeceği bilgisi </returns>
        public override bool IsPropertyReadonly(TTObjectPropertyDef propDef)
        {
            return false;
        }

        /// <summary>
        /// Hasta MPVT Hastası ise MPVT'den gelen ilişki XXXXXX tarafından değiştirilememesini sağlar.
        /// </summary>
        /// <param name="propDef">TTObjectRelationDef tipinde değiştirilen ilişki</param>
        /// <returns>Bool olarak değiştirilip değiştirilemeyeceği bilgisi </returns>
        public override bool IsParentRelationReadonly(TTObjectRelationDef relDef)
        {
            return false;
        }


        public static string GetFilterExpression(string uniqueRefNo = null, string name = null, string surname = null, string fathername = null, string mothername = null, DateTime? birthdate = null, string cityOfBirth = null, int? patientID = null, SKRSCinsiyet sex = null,string pasaportNo = null)
        {
            string filterExpression = null;
            string opr = null;
            string injection = null;
            TTObjectContext objectContext = new TTObjectContext(true);
            //TC Kimlik No
            if (uniqueRefNo != null)
            {
                if (uniqueRefNo.Length > 0 && Common.IsNumeric(uniqueRefNo))
                {
                    filterExpression = "WHERE (UNIQUEREFNO = " + uniqueRefNo.ToString() + " )";
                    return filterExpression;
                }
            }

            if (patientID.HasValue && patientID.Value > 0)
            {
                filterExpression = "WHERE (ID = " + patientID.Value + ")";
                return filterExpression;
            }

            List<Guid> PatientObjectIDs = new List<Guid>();
            //ArrayList PatientObjectIDs = new ArrayList();
            // Name ve Surname arama
            if ((name != null && name.Trim().Length > 0) && (surname != null && surname.Trim().Length > 0))
            {
                filterExpression = Patient.GetPatientFullNameExpression(name + " " + surname);
            }
            else if (name != null && name.Trim().Length > 0)
            {
                //Name
                name = name.Trim();
                injection = null;
                ArrayList NameTokens = new ArrayList();
                NameTokens = Common.Tokenize(name, true);
                for (int i = 0; i <= NameTokens.Count - 1; i++)
                {
                    if (i > 0)
                        injection += " OR ";
                    else
                        injection += " AND (";
                    string s = NameTokens[i].ToString();
                    if (name.Length > 2)
                        opr = "LIKE";
                    else
                        opr = "=";
                    injection += "TOKEN " + opr + " '" + s + "%' ";
                }

                if (injection != null)
                {
                    injection += ") AND TOKENTYPE = 0";
                    //                    dd
                    BindingList<PatientToken.GetByInjection_Class> tokenList = PatientToken.GetByInjection(injection);
                    foreach (PatientToken.GetByInjection_Class t in tokenList)
                    {
                        if (t.Patientobjectid != null)
                        {
                            if (!PatientObjectIDs.Contains(t.Patientobjectid.Value))
                                PatientObjectIDs.Add(t.Patientobjectid.Value);
                        }
                    }
                }
            }
            else if (surname != null && surname.Trim().Length > 0) //Soyadı
            {
                surname = surname.Trim();
                injection = null;
                ArrayList NameTokens = new ArrayList();
                //
                NameTokens = Common.Tokenize(surname, true);
                for (int i = 0; i <= NameTokens.Count - 1; i++)
                {
                    if (i > 0)
                        injection += " OR ";
                    else
                        injection += " AND (";
                    string s = NameTokens[i].ToString();
                    if (surname.Length > 2)
                        opr = "LIKE";
                    else
                        opr = "=";
                    injection += "TOKEN " + opr + " '" + s + "%' ";
                }

                if (injection != null)
                {
                    injection += ") AND TOKENTYPE = 1";
                    //                    dd
                    BindingList<PatientToken.GetByInjection_Class> tokenList = PatientToken.GetByInjection(injection);
                    foreach (PatientToken.GetByInjection_Class t in tokenList)
                    {
                        if (t.Patientobjectid != null)
                        {
                            if (!PatientObjectIDs.Contains(t.Patientobjectid.Value))
                                PatientObjectIDs.Add(t.Patientobjectid.Value);
                        }
                    }
                }
            }

            if (PatientObjectIDs.Count > 0)
            {
                filterExpression = Common.CreateFilterExpressionOfGuidList(filterExpression, String.Empty, PatientObjectIDs);
            }

            //Baba Adı
            if (fathername != null && fathername.Length > 0)
            {
                if (filterExpression != null)
                {
                    filterExpression += " AND ";
                }

                if (fathername.Length > 2)
                    filterExpression += "(FATHERNAME LIKE '" + fathername.ToUpper() + "%')";
                else
                    filterExpression += "(FATHERNAME = '" + fathername.ToUpper() + "')";
            }

            //Anne Adı
            if (mothername != null && mothername.Length > 0)
            {
                if (filterExpression != null)
                {
                    filterExpression += " AND ";
                }

                if (mothername.Length > 2)
                    filterExpression += "(MOTHERNAME LIKE '" + mothername.ToUpper() + "%')";
                else
                    filterExpression += "(MOTHERNAME = '" + mothername.ToUpper() + "')";
            }

            //  Doğum Tarihi
            if (birthdate.HasValue == true && DateTime.MinValue != birthdate.Value)
            {
                string firstDate = "01.01." + (Convert.ToDateTime(birthdate).Date).ToString("yyyy") + " 00:00:00";
                string lastDate = "31.12." + (Convert.ToDateTime(birthdate).Date).ToString("yyyy") + " 23:59:59";
                //                    string filter = "(BIRTHDATE >= '" + (Convert.ToDateTime(firstDate).Date).ToString("yyyy-MM-dd HH:mm") + "' AND";
                //                    filter += " BIRTHDATE <= '" + (Convert.ToDateTime(lastDate).Date).ToString("yyyy-MM-dd HH:mm") + "')";
                string filter = "(BIRTHDATE >= '" + (Convert.ToDateTime(firstDate).Date.ToShortDateString()) + "' AND";
                filter += " BIRTHDATE <= '" + (Convert.ToDateTime(lastDate).Date.ToShortDateString()) + "')";
                if (filterExpression == null)
                    filterExpression = "(" + filter + ")";
                else
                    filterExpression += " AND (" + filter + ")";
            }

            //İl
            if (!string.IsNullOrEmpty(cityOfBirth))
            {
                string filter = "(BirthPlace = '" + cityOfBirth.ToUpper() + "')";
                if (filterExpression == null)
                    filterExpression = "(" + filter + ")";
                else
                    filterExpression += " AND (" + filter + ")";
            }

            if (sex != null)
            {
                if (filterExpression != null)
                {
                    filterExpression += " AND ";
                }
                filterExpression += "(sex.KODU = '" + sex.KODU + "')";
               
            }

            if (!string.IsNullOrEmpty(pasaportNo))
            {
                string filter = "(passportno = '" + pasaportNo.ToUpper() + "')";
                if (filterExpression == null)
                    filterExpression = "(" + filter + ")";
                else
                    filterExpression += " AND (" + filter + ")";
            }



            if (filterExpression == null)
                filterExpression = "1=0";
            return "Where " + filterExpression;
        }

        /// <summary>
        /// TC Kimlik Noyu sorgulayan SQL parçasını oluşturur
        /// </summary>
        /// <param name="searchString">Sorgulanacak TC Kimlik No</param>
        /// <returns>TC Kimlik Noyu sorgulayan string SQL parçası</returns>
        private static string GetUniqueRefNoExpression(string searchString)
        {
            string filterExpression = null;
            if (filterExpression != null)
            {
                filterExpression += " AND ";
            }
            filterExpression += "(UNIQUEREFNO = " + searchString + " )";
            return filterExpression;
        }

        /// <summary>
        /// Yabancı Hasta Kimlik Noyu sorgulayan SQL parçasını oluşturur
        /// </summary>
        /// <param name="searchString">Sorgulanacak Kimlik No</param>
        /// <returns>Yabancı Hasta Kimlik Noyu sorgulayan string SQL parçası</returns>
        private static string GetForeignUniqueRefNoExpression(string searchString)
        {
            string filterExpression = null;
            if (filterExpression != null)
                filterExpression += " AND ";
            filterExpression += "(UNIQUEREFNO = " + searchString + " )";
            return filterExpression;
        }

        /// <summary>
        /// YUPASS Noyu sorgulayan SQL parçasını oluşturur
        /// </summary>
        /// <param name="searchString">Sorgulanacak Kimlik No</param>
        /// <returns>Yabancı Hasta Kimlik Noyu sorgulayan string SQL parçası</returns>
        private static string GetYuPassNoExpression(string searchString)
        {
            string filterExpression = null;
            if (Common.IsNumeric(searchString))
                filterExpression = "(YUPASSNO = " + searchString + " )";
            return filterExpression;
        }

        /// <summary>
        /// Hasta Numarasını sorgulayan SQL parçasını oluşturur
        /// </summary>
        /// <param name="searchString">Sorgulanacak Hasta Numarası</param>
        /// <returns>Hasta Numarasını sorgulayan string SQL parçası</returns>
        private static string GetPatientObjectIDExpression(string searchString)
        {
            string filterExpression = null;
            if (Common.IsNumeric(searchString))
            {
                filterExpression = "(ID = " + searchString + ")";
            }
            return filterExpression;
        }

        /// <summary>
        /// Hastanın adını soyadını sorgulayan SQL parçasını oluşturur
        /// </summary>
        /// <param name="searchString">Sorgulanacak Hasta Adı</param>
        /// <returns>Hastanın adını soyadını sorgulayan string SQL parçası</returns>
        public static string GetPatientFullNameExpression(string searchString)
        {
            List<Guid> PatientObjectIDs = new List<Guid>();
            Dictionary<Guid, int> Duplicates = new Dictionary<Guid, int>();
            List<Guid> MatchedIDs = new List<Guid>();
            string filterExpression = null;
            string opr = null;
            string injection = null;
            ArrayList NameTokens = new ArrayList();
            NameTokens = Common.Tokenize(searchString, true);

            PaginationInfo pi = new PaginationInfo();
            pi.Skip = 0;
            pi.PageSize = 600;

            if (NameTokens.Count == 1)
            {
                injection += " AND (";
                string s = NameTokens[0].ToString();
                if (s.Length > 1)
                {
                    if (s.IndexOf('%') != -1)
                    {
                        injection += "TOKEN LIKE '" + s + "' ";
                        injection += ")AND TOKENTYPE IN (0,1)";
                    }
                    else
                    {
                        injection += "TOKEN = '" + s + "' ";
                        injection += ")AND TOKENTYPE IN (0,1)";
                    }
                    if (injection != null)
                    {
                        BindingList<PatientToken.GetByInjectionInternal_Class> tokenList = PatientToken.GetByInjectionInternal(injection, pi);
                        foreach (PatientToken.GetByInjectionInternal_Class t in tokenList)
                        {
                            if (t.Patient.HasValue)
                            {
                                if (!PatientObjectIDs.Contains(t.Patient.Value))
                                    PatientObjectIDs.Add(t.Patient.Value);
                            }
                        }

                        if (PatientObjectIDs.Count > 0)
                            filterExpression = Common.CreateFilterExpressionOfGuidList(filterExpression, String.Empty, PatientObjectIDs);

                    }
                }
            }

            if (NameTokens.Count > 1)
            {
                for (int i = 0; i <= NameTokens.Count - 1; i++)
                {
                    string s = NameTokens[i].ToString();

                    if (i > 0)
                    {
                        injection += @"
UNION 
SELECT

    OT" + i + @".PATIENT," + i + @" A
FROM
    PATIENTTOKEN OT" + i + @"
WHERE ";

                        if (s.IndexOf('%') != -1 || (TTObjectClasses.SystemParameter.GetParameterValue("PatientSearchWithAmpersand", "True").ToUpper() == "TRUE"))
                        {
                            opr = "LIKE";
                            s += "%";
                        }
                        else
                            opr = "=";

                        injection += "OT" + i + @".TOKEN " + opr + " '" + s.Replace("'", "''") + "' ";
                        if (NameTokens.Count != 2) //Mehmet Z  , yazdığında Mehmet Zeki Samna  ı aramadığından eklendi.
                        {
                            if (i == NameTokens.Count - 1)
                                injection += "AND OT" + i + @".TOKENTYPE = 1
";
                            else
                                injection += "AND OT" + i + @".TOKENTYPE = 0
";
                        }
                    }
                    else
                    {
                        injection += @" SELECT
    OT" + i + @".PATIENT," + i + @" A
FROM
    PATIENTTOKEN OT" + i + @"
WHERE ";
                        if (s.IndexOf('%') != -1 || (TTObjectClasses.SystemParameter.GetParameterValue("PatientSearchWithAmpersand", "True").ToUpper() == "TRUE"))
                        {
                            opr = "LIKE";
                            s += "%";
                        }
                        else
                            opr = "=";

                        injection += "OT" + i + @".TOKEN " + opr + " '" + s.Replace("'", "''") + @"'
";
                        injection += "AND OT" + i + @".TOKENTYPE = 0
";
                    }
                }

                if (injection != null)
                {
                    BindingList<PatientToken.GetByInjectionInternal_Class> tokenList = PatientToken.GetSpecial(NameTokens.Count, injection, pi);

                    if (tokenList != null)
                    {
                        var q = tokenList.Where(x => x.Patient.HasValue).ToList();
                        if (q.Count > 0)
                            filterExpression = Common.CreateFilterExpressionOfGuidList(filterExpression, String.Empty, q.Select(x => x.Patient.Value).ToList());
                    }
                }
            }

            //Old version

            //if (NameTokens.Count > 1)
            //{
            //    for (int i = 0; i <= NameTokens.Count - 1; i++)
            //    {
            //        string s = NameTokens[i].ToString();

            //        if (i > 0)
            //        {
            //            injection += " OR (";
            //            if (s.IndexOf('%') != -1 || (TTObjectClasses.SystemParameter.GetParameterValue("PatientSearchWithAmpersand", "True").ToUpper() == "TRUE"))
            //            {
            //                opr = "LIKE";
            //                s += "%";
            //            }
            //            else
            //                opr = "=";
            //            injection += "TOKEN " + opr + " '" + s + "' ";
            //            if (i == NameTokens.Count - 1)
            //                injection += "AND TOKENTYPE = 1";
            //            else
            //                injection += "AND TOKENTYPE = 0";
            //            injection += ")";
            //        }
            //        else
            //        {
            //            injection += " AND ((";
            //            if (s.IndexOf('%') != -1 || (TTObjectClasses.SystemParameter.GetParameterValue("PatientSearchWithAmpersand", "True").ToUpper() == "TRUE"))
            //            {
            //                opr = "LIKE";
            //                s += "%";
            //            }
            //            else
            //                opr = "=";
            //            injection += "TOKEN " + opr + " '" + s + "' ";
            //            injection += "AND TOKENTYPE = 0";
            //            injection += ")";
            //        }
            //    }
            //    injection += ")";

            //    if (injection != null)
            //    {
            //        BindingList<PatientToken.GetByInjectionInternal_Class> tokenList = PatientToken.GetByInjectionInternal(injection);

            //        foreach (PatientToken.GetByInjectionInternal_Class t in tokenList)
            //        {
            //            if (t.Patient.HasValue)
            //            {
            //                PatientObjectIDs.Add(t.Patient.Value);

            //                if (!Duplicates.ContainsKey(t.Patient.Value))
            //                    Duplicates.Add(t.Patient.Value, 1);
            //                else
            //                {
            //                    int count = 0;
            //                    Duplicates.TryGetValue(t.Patient.Value, out count);
            //                    Duplicates.Remove(t.Patient.Value);
            //                    Duplicates.Add(t.Patient.Value, count + 1);
            //                }
            //            }
            //        }

            //        foreach (KeyValuePair<Guid, int> pair in Duplicates)
            //            if (pair.Value == NameTokens.Count)
            //                if (!MatchedIDs.Contains(pair.Key))
            //                    MatchedIDs.Add(pair.Key);

            //        if (MatchedIDs.Count > 0)
            //            filterExpression = Common.CreateFilterExpressionOfGuidList(filterExpression, String.Empty, MatchedIDs);
            //    }
            //}

            return filterExpression;
        }
        public static IList PrivacySearch(string privacyUniqueRefNo)
        {
            TTObjectContext context = new TTObjectContext(true);
            return Patient.GetByPrivacyPatient(context, Convert.ToInt64(privacyUniqueRefNo));
        }
        /// <summary>
        /// Verilen SQL parşasına göre Hasta arar
        /// </summary>
        /// <param name="searchString">Aranacak string SQL parçası</param>
        /// <returns>Balunan Hasta Listesi</returns>
        public static TTList Search(string searchString)
        {
            TTList _ttList = TTList.NewList("PatientSearchList", null);

            IList list = null;
            bool dontSearchByPatientID = TTObjectClasses.SystemParameter.GetParameterValue("SEARCHPATIENBYPATIENTID", "TRUE").Trim() == "FALSE";
            if (searchString.Length == 11 && Common.IsNumeric(searchString))
            {
                if (dontSearchByPatientID)
                    _ttList = NestedSearch(_ttList, list, GetUniqueRefNoExpression(searchString), GetForeignUniqueRefNoExpression(searchString), GetYuPassNoExpression(searchString));
                else
                    _ttList = NestedSearch(_ttList, list, GetUniqueRefNoExpression(searchString), GetPatientObjectIDExpression(searchString), GetForeignUniqueRefNoExpression(searchString));
            }
            else if (searchString.Length != 11 && Common.IsNumeric(searchString))
            {
                if (dontSearchByPatientID)
                    _ttList = NestedSearch(_ttList, list, GetForeignUniqueRefNoExpression(searchString), GetYuPassNoExpression(searchString), null);
                else
                    _ttList = NestedSearch(_ttList, list, GetPatientObjectIDExpression(searchString), GetForeignUniqueRefNoExpression(searchString), GetYuPassNoExpression(searchString));
            }
            else
            {
                if (searchString.Length == 0)
                {
                    //DisplayErrorLabel();
                    return null;
                }
                if (Common.IsNumeric(searchString))
                    if (dontSearchByPatientID)
                        _ttList = NestedSearch(_ttList, list, GetPatientFullNameExpression(searchString), GetUniqueRefNoExpression(searchString), GetForeignUniqueRefNoExpression(searchString));
                    else
                        _ttList = NestedSearch(_ttList, list, GetPatientFullNameExpression(searchString), GetPatientObjectIDExpression(searchString), GetUniqueRefNoExpression(searchString));
                else
                    if (dontSearchByPatientID)
                    _ttList = NestedSearch(_ttList, list, GetPatientFullNameExpression(searchString), null, null);
                else
                    _ttList = NestedSearch(_ttList, list, GetPatientFullNameExpression(searchString), GetPatientObjectIDExpression(searchString), null);
            }
            return _ttList;

        }


        public static TTList SearchByPatientID(string searchString)
        {
            TTList _ttList = TTList.NewList("PatientSearchList", null);

            IList list = null;

            if (Common.IsNumeric(searchString))
            {
                _ttList = NestedSearch(_ttList, list, GetPatientObjectIDExpression(searchString), null, null);
            }

            return _ttList;

        }

        /// <summary>
        /// Veri bulana kadar sıra ile SQL parçasına göre  verilen listeyi sorgular.
        /// </summary>
        /// <param name="ttList">Sorgulnanacak TTList</param>
        /// <param name="list">Temp List</param>
        /// <param name="exp1">1.SQL parçası</param>
        /// <param name="exp2">2.SQL parçası</param>
        /// <param name="exp3">3.SQL parçası</param>
        /// <returns>Sorgu sonucu bulunan verileri içeren  TTList</returns>
        private static TTList NestedSearch(TTList ttList, IList list, string exp1, string exp2, string exp3)
        {
            PaginationInfo pi = new PaginationInfo();
            pi.Skip = 0;
            pi.PageSize = 500;

            if (exp1 != null)
                list = ttList.GetObjectListByExpression(exp1, pi);
            if (list == null || list.Count < 1)
            {
                if (exp2 != null)
                    list = ttList.GetObjectListByExpression(exp2, pi);
                if (list == null || list.Count < 1)
                {
                    if (exp3 != null)
                        list = ttList.GetObjectListByExpression(exp3, pi);
                    if (list == null || list.Count < 1)
                    {
                        //DisplayErrorLabel();
                        return null;
                    }

                    return ttList;
                }
                return ttList;
            }
            return ttList;
        }

        //        private static string searchString;
        //        public static string SearchString
        //        {
        //            get { return searchString; }
        //            set { searchString = value; }
        //        }

        /// <summary>
        /// Verilen stringin Guid olup olmadığını bulur
        /// </summary>
        /// <param name="str"></param>
        /// <returns>bool</returns>
        public static bool IsGuid(string str)
        {
            try
            {
                new Guid(str);
                return true;
            }
            catch (ArgumentNullException) { }
            catch (FormatException) { }
            catch (OverflowException) { }
            return false;
        }
        /// <summary>
        /// Hastayı PACS'a gönderir
        /// </summary>
        public static void SendPatientToPACS(Patient patient)
        {
            /*
            if (this.Episodes.Count > 0)
            {
                string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("HL7ENGINEALIVE", null);
                if (sysparam == "TRUE")
                {
                    List<Guid> pIDs = new List<Guid>();
                    pIDs.Add(this.ObjectID);
                    try
                    {
                        TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.MediumPriority, "InternalTCPClient", "HL7Remoting", "SendHospitalMessageToEngine", null, pIDs, "A08", "PACS");
                    }
                    catch (Exception ex)
                    {
                        String message = SystemMessage.GetMessage(89);
                        TTVisual.InfoBox.Alert("Hasta bilgileri PACS'a gönderilemedi! " + message, ex);
                    }
                }
            }*/
        }

        /// <summary>
        /// Web servisi için Kullanılacak cinsiyet Enumu
        /// </summary>
        public enum sexEnum
        {
            Male = 0,
            Female = 1,
            Unidentified = 2
        }

        /// <summary>
        /// Web servisi için Kullanılacak Hasta Listesi Classı
        /// </summary>
        public class InPatientListItem
        {
            public Patient.InPatientInfo Hasta;
            public Guid? YattigiKlinik;
            public Guid? TedaviGorduguKlinik;
            public string Odasi;
            public string Yatagi;
            public string XXXXXXProtokolNo;
            public Guid? DiyetTuru;
            public string DiyetAdi;
            public DateTime? DiyetGirisTarihi;
            public Guid? YemeYeriKodu;
            public string YemeYeriAdi;
            public string Companion;
        }

        /// <summary>
        /// Web servisi için Kullanılacak Hasta Bilgileri Classı
        /// </summary>
        public class InPatientInfo
        {
            public Guid ObjectID;
            public string Adi;
            public string Soyadi;
            public DateTime? DogumTarihi;
            public sexEnum? Cinsiyet;
            public string BabaAdi;
            public int HastaGrubuKodu;
            public String HastaGrubuAdi;
        }

        /// <summary>
        /// Verilen Klinikde Fiziksel olarak Yatan Hasta Listesini Döndürür
        /// </summary>
        /// <param name="PhysicalStateClinicGuid">Hastanın fiziksel olarak yattığı Klinik</param>
        /// <returns>List<InPatientListItem></returns>
        public static List<Patient.InPatientListItem> GetInpatientList(Guid? PhysicalStateClinicGuid)
        {
            TTObjectContext context = new TTObjectContext(true);
            List<Patient.InPatientListItem> l = new List<Patient.InPatientListItem>();
            BindingList<InPatientTreatmentClinicApplication> IPTreatmentClinicAppList;
            if (PhysicalStateClinicGuid == null)
            {
                IPTreatmentClinicAppList = InPatientTreatmentClinicApplication.GetAllActiveInPatientTreatmentClinicApp(context);
            }
            else
            {
                IPTreatmentClinicAppList = InPatientTreatmentClinicApplication.GetActiveByPhysicalStateClinic(context, (Guid)PhysicalStateClinicGuid);
            }

            foreach (InPatientTreatmentClinicApplication inPTCA in IPTreatmentClinicAppList)
            {
                Patient.InPatientListItem i = new Patient.InPatientListItem();
                Patient.InPatientInfo Hasta = new Patient.InPatientInfo();
                Hasta.ObjectID = inPTCA.Episode.Patient.ObjectID;
                Hasta.Adi = inPTCA.Episode.Patient.Name;
                Hasta.Soyadi = inPTCA.Episode.Patient.Surname;
                Hasta.BabaAdi = inPTCA.Episode.Patient.FatherName;
                //  Hasta.Cinsiyet = (sexEnum?)inPTCA.Episode.Patient.Sex;

                i.XXXXXXProtokolNo = inPTCA.Episode.HospitalProtocolNo.ToString();
                i.Hasta = Hasta;
                if (inPTCA.BaseInpatientAdmission.Bed != null)
                {
                    i.Yatagi = inPTCA.BaseInpatientAdmission.Bed.Name.ToString();
                    i.Odasi = inPTCA.BaseInpatientAdmission.Bed.Room == null ? "" : inPTCA.BaseInpatientAdmission.Bed.Room.Name.ToString();
                }

                foreach (InPatientPhysicianApplication inPPA in inPTCA.InPatientPhysicianApplication)
                {
                    if (inPPA.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                    {
                        bool first = true;
                        foreach (NutritionDietOrder nutritionDiets in inPPA.NutritionDiets)
                        {
                            if (first || i.DiyetGirisTarihi < nutritionDiets.ActionDate)
                            {
                                if (nutritionDiets.ProcedureObject != null && nutritionDiets.ActionDate != null)
                                {
                                    i.DiyetTuru = nutritionDiets.ProcedureObject.ObjectID;
                                    i.DiyetGirisTarihi = Convert.ToDateTime(nutritionDiets.ActionDate);
                                    i.DiyetAdi = nutritionDiets.ProcedureObject.Name;
                                    if (nutritionDiets.Place != null)
                                    {
                                        i.YemeYeriKodu = nutritionDiets.Place.ObjectID;
                                        i.YemeYeriAdi = nutritionDiets.Place.Place.ToString();
                                    }
                                    else
                                    {
                                        i.YemeYeriKodu = null;
                                        i.YemeYeriAdi = null;
                                    }
                                    first = false;
                                }
                            }
                        }
                        break;
                    }
                }

                i.TedaviGorduguKlinik = inPTCA.MasterResource.ObjectID;
                if (inPTCA.BaseInpatientAdmission.PhysicalStateClinic != null)
                    i.YattigiKlinik = inPTCA.BaseInpatientAdmission.PhysicalStateClinic.ObjectID;
                if (inPTCA.Episode.CompanionApplications.Count > 0)
                {
                    var Companion = inPTCA.Episode.CompanionApplications.FirstOrDefault(dr => dr.CurrentStateDefID == CompanionApplication.States.Active);
                    if (Companion != null)
                        i.Companion = Companion.CompanionName;
                }

                l.Add(i);
            }
            return l;
        }
        /// <summary>
        /// Verilen ObjectID'li hastayı InPatientInfo cinsinden  döndürür
        /// </summary>
        /// <param name="ObjectId">Aranan Hastanın ObjectId'si</param>
        /// <returns>InPatientInfo</returns>
        public static Patient.InPatientInfo GetPatient(Guid ObjectId)
        {
            Patient.InPatientInfo Hasta = new Patient.InPatientInfo();
            TTObjectContext context = new TTObjectContext(true);
            //Hasta bulunamazsa hata verir
            Patient p = (Patient)context.GetObject(ObjectId, typeof(Patient).Name);
            Hasta = new Patient.InPatientInfo();
            Hasta.ObjectID = p.ObjectID;
            Hasta.Adi = p.Name;
            Hasta.Soyadi = p.Surname;
            Hasta.BabaAdi = p.FatherName;
            // Hasta.Cinsiyet = (sexEnum?)p.Sex;
            //EnumValueDef patientGroupEnum = Common.GetEnumValueDefOfEnumValue(p.PatientGroup);
            //Hasta.HastaGrubuKodu = patientGroupEnum.Value;
            //Hasta.HastaGrubuAdi = patientGroupEnum.DisplayText;
            return Hasta;
        }
        /// <summary>
        /// Verilen parametrelere göre  SUTMalzemeleri Toplam Miktarını getirir.
        /// </summary>
        /// <param name="episodeAction"></param>
        /// <param name="materialID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public ISUTMaterialTotalAmount SUTMaterialTotalAmount(ISUTEpisodeAction episodeAction, Guid materialID, DateTime startDate, DateTime endDate)
        {
            ISUTMaterialTotalAmount materialTotalAmount = episodeAction.NewSUTMaterialTotalAmount(materialID);
            //
            //            IList subactionMaterialsTotalAmountList = Patient.GetEHRPatientSubactionMaterialsTotalAmount(this.ObjectID, materialID, startDate, endDate);
            //            foreach (Patient.GetEHRPatientSubactionMaterialsTotalAmount_Class o in subactionMaterialsTotalAmountList)
            //                materialTotalAmount.TotalAmount += Convert.ToDouble(o.Totalamount);
            return materialTotalAmount;
        }

        /// <summary>
        /// Verilen parametrelere göre  SUTİşlemleri Toplam Miktarını getirir.
        /// </summary>
        /// <param name="episodeAction"></param>
        /// <param name="materialID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public ISUTProcedureTotalAmount SUTProcedureTotalAmount(ISUTEpisodeAction episodeAction, Guid procedureID, DateTime startDate, DateTime endDate)
        {
            ISUTProcedureTotalAmount procedureTotalAmount = episodeAction.NewSUTProcedureTotalAmount(procedureID);

            //            IList subactionProceduresTotalAmountList = Patient.GetEHRPatientSubactionProceduresTotalAmount(this.ObjectID, procedureID, startDate, endDate);
            //            foreach (Patient.GetEHRPatientSubactionProceduresTotalAmount_Class o in subactionProceduresTotalAmountList)
            //                procedureTotalAmount.TotalAmount += Convert.ToInt64(o.Totalamount);
            //
            //            subactionProceduresTotalAmountList = Patient.GetEHRPatientSubactProcedureFlowablesTotalAmount(endDate, startDate, this.ObjectID, procedureID);
            //            foreach (Patient.GetEHRPatientSubactProcedureFlowablesTotalAmount_Class o in subactionProceduresTotalAmountList)
            //                procedureTotalAmount.TotalAmount += Convert.ToInt64(o.Totalamount);
            return procedureTotalAmount;
        }

        /// <summary>
        /// Verilen İşlem ID'ye ve SQL parçasına göre Hastaya uygulanan İşlemleri getirir
        /// </summary>
        /// <param name="procedureID"></param>
        /// <param name="injectionSQL"></param>
        /// <returns>"List<ISUTInstance>"</returns>
        private List<ISUTInstance> GetSubactionProcedures(Guid procedureID, string injectionSQL)
        {
            List<ISUTInstance> retValue = new List<ISUTInstance>();
            //            IList subactionProcedures = Patient.GetEHRPatientSubactionProcedures(this.ObjectID, procedureID, injectionSQL);
            //            if (subactionProcedures.Count > 0)
            //            {
            //                TTObjectContext objectContext = new TTObjectContext(false);
            //                foreach (Patient.GetEHRPatientSubactionProcedures_Class o in subactionProcedures)
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
        /// <summary>
        /// Verilen İşlem ID'ye  göre Hastaya uygulanan İşlemleri getirir
        /// </summary>
        /// <param name="procedureID"></param>
        /// <returns></returns>
        public List<ISUTInstance> SUTSubactionProcedures(Guid procedureID)
        {
            return GetSubactionProcedures(procedureID, string.Empty);
        }

        /// <summary>
        /// Verilen İşlem ID'ye ve tarih aralığına göre Hastaya uygulanan İşlemleri getirir
        /// </summary>
        /// <param name="procedureID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<ISUTInstance> SUTSubactionProcedures(Guid procedureID, DateTime startDate, DateTime endDate)
        {
            //string injectionSQL = "AND EHREPISODES.EHRACTIONS.EHRSUBACTIONPROCEDURES.ACTIONDATE  BETWEEN TODATE('" + startDate.ToString("yyyy-MM-dd HH:mm:ss") + "') AND TODATE('" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            string injectionSQL = "";
            return GetSubactionProcedures(procedureID, injectionSQL); ;
        }

        /// <summary>
        /// Hastanın Geçerli Medıla Kabulü varmı döndürür
        /// </summary>
        /// <returns>bool</returns>
        public bool HasValidMedulaHastaKabul()
        {
            IList patientMedulaHastaKabulleri = PatientMedulaHastaKabulleri.Select("CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(PatientMedulaHastaKabul.States.Valid));
            if (patientMedulaHastaKabulleri.Count > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Hastanın Tüm Tanılarını getirir
        /// </summary>
        /// <returns>"List<ISUTInstance>"</returns>
        public List<ISUTInstance> SUTDiagnosisGrid()
        {
            List<ISUTInstance> retValue = new List<ISUTInstance>();
            //            IList patientDiagnosis = Patient.GetEHRPatientDiagnosis(this.ObjectID, string.Empty);
            //            if (patientDiagnosis.Count > 0)
            //            {
            //                TTObjectContext objectContext = new TTObjectContext(false);
            //                foreach (Patient.GetEHRPatientDiagnosis_Class o in patientDiagnosis)
            //                {
            //                    SUTInstance sutInstance = new SUTInstance(objectContext);
            //                    sutInstance.RuleDate = o.DiagnoseDate;
            //                    sutInstance.SUTRulableObject = (DiagnosisDefinition)objectContext.GetObject((Guid)o.Diagnosisobjectid, typeof(DiagnosisDefinition));
            //                    retValue.Add(sutInstance);
            //                }
            //            }
            return retValue;
        }

        /// <summary>
        /// Verilen hasta grubu için hastaya kontenjan uygulanıp uygulanamyacağını döndürür
        /// </summary>
        /// <param name="activePatientGroupEnum"></param>
        /// <returns>bool</returns>
        public bool? IsRequiredQuota(PatientGroupEnum activePatientGroupEnum)
        {

            PatientGroupDefinition patientGroup = Common.PatientGroupDefinitionByEnum(ObjectContext, activePatientGroupEnum);
            if (patientGroup != null)
            {
                return IsRequiredQuota(patientGroup);
            }
            else
            {
                string[] hataParamList = new string[] { activePatientGroupEnum.ToString() };
                String message = SystemMessage.GetMessageV3(90, hataParamList);
                throw new TTUtils.TTException(message);
                // throw new TTException("Hasta Grup Tanımı ekranından " + activePatientGroupEnum.ToString() + " hasta grubu için tanımlama yapılması gerekmektedir!");
            }
            //return (bool?)false;
        }

        /// <summary>
        /// Verilen hasta grubu için hastaya kontenjan uygulanıp uygulanamyacağını döndürür
        /// </summary>
        /// <param name="activePatientGroupEnum"></param>
        /// <returns>bool</returns>

        public bool? IsRequiredQuota(PatientGroupDefinition patientGroup)
        {
            bool? required = false;
            if (patientGroup != null)
            {
                //if (patientGroup.RequiredQuota == true &&
                //  this.NotRequiredQuota != true &&
                //   this.Disabled != true &&
                // this.DisabledWarVetera != true &&
                //  this.WarVetera != true )// Başhekimlik tarafından hasta bazlı Kontenjana girmeden kabule izin verilebilir Ayrıca XXXXXX yakınları kontenjan oldurmaz.
                //                    required = true;
            }
            else
            {
                throw new TTUtils.TTException(SystemMessage.GetMessage(981));
                // throw new TTException("Hasta Grup Tanımı ekranından " + activePatientGroupEnum.ToString() + " hasta grubu için tanımlama yapılması gerekmektedir!");
            }
            return (bool?)required;
        }
        public enum SrcTableType : int
        {
            Personel = 1,
            Yakin = 2,
            XXXXXXOgrenci = 3,
            ErErbas = 4,
            Emekli = 5,
            Isci = 6
        }

        public static SrcTableType? GetSrcTableType(string srctable)
        {
            if (!String.IsNullOrEmpty(srctable))
            {
                switch (srctable.Trim())
                {
                    case "DZK_PERSONEL":
                    case "GNK_PERSONEL":
                    case "HVK_PERSONEL":
                    case "JGK_PERSONEL":
                    case "KKK_PERSONEL":
                    case "KKK_YEDEKSUBAY":
                    case "MSB_PERSONEL":
                    case "SGK_PERSONEL":
                        return SrcTableType.Personel;

                    case "DZK_YAKIN":
                    case "GNK_AILE":
                    case "HVK_AILE":
                    case "JGK_YAKIN":
                    case "KKK_YAKIN":
                    case "KKK_YEDEKSUBAY_YAKIN":
                    case "MSB_BAK_YUK":
                    case "SGK_YAKIN":
                    case "KKK_MEMUR_AILE":
                        return SrcTableType.Yakin;


                    case "DZK_ASKOGRENCI":
                    case "HVK_ASKOGRENCI":
                    case "JGK_ASKOGRENCI":
                    case "KKK_ASKOGRENCI":
                    case "SGK_ASKOGRENCI":
                        return SrcTableType.XXXXXXOgrenci;


                    case "DZK_ERERBAS":
                    case "HVK_ERERBAS":
                    case "JGK_ERERBAS":
                    case "KKK_ER":
                    case "SGK_ERERBAS":
                        return SrcTableType.ErErbas;


                    case "DZK_EMEKLI":
                    case "GNK_EMEKLI":
                    case "HVK_EMEKLI":
                    case "JGK_EMEKLI":
                    case "KKK_EMEKLI":
                    case "MSB_EMEKLI":
                    case "SGK_EMEKLI":
                        return SrcTableType.Emekli;

                    case "DZK_ISCI":
                    case "MSB_ISCI":
                        return SrcTableType.Isci;
                }
            }
            return null;
        }

        private PatientGroupEnum? GetPatientGroupAccordingToRank(string RankGuid)
        {
            switch (RankGuid)
            {
                // --->General-Amiral
                case "d58f980d-bc7a-4071-8f76-f955c8a2cb30": //	Büyük Amiral
                case "687ec611-da0d-47b3-a884-fba762f811fd": //	Koramiral
                case "e97680cf-17a5-4769-959c-5787fa3bec97": //	Korgeneral
                case "a1991c3e-31a9-40a5-bb0a-b49efdbee644": //	Mareşal
                case "0c461acb-d780-4247-b1a0-baa31fdd5ca1": //	Oramiral
                case "1b647f48-2cfb-4860-bc22-d4b62e75388c": //	Orgeneral
                case "634a5831-4ba5-492f-9171-b35bab7d56bb": //	Tuğamiral
                case "1d41bd5e-58f9-4f5a-9179-ab2cb97c1844": //	Tuğgeneral
                case "e62e83de-3a16-4ddb-a4f4-45eb2bbee81c": //	Tümamiral
                case "066be5b8-73e7-4b30-b851-acd7ece73377": //	Tümgeneral
                    return PatientGroupEnum.GeneralAdmiral;
                //	--->Subay
                case "d3dca186-60c8-4fc1-8383-ba1aed940f28"://	Yüzbaşı
                case "11bbd304-3576-48e8-9586-96540f3a8728": //	Albay
                case "30a6e033-83c2-41a7-acc4-1298558e8e38": //	Asteğmen
                case "e407b4d6-1f2e-4949-8cff-5fe4cf3c2afb": //	Binbaşı
                case "d9b9ee89-49ad-4fab-bf24-b97a044da13c": //	Kıdemli Binbaşı
                case "ec92ad6b-2a80-459b-a6ea-cb735d9188a0": //	Kıdemli Yüzbaşı
                case "967dfbd4-6594-463c-9fe0-756f86c8d314": //	Teğmens
                case "b8f04cb1-c119-4899-ba6d-821d00bde7a4": //	ÜsteğmenS
                case "40b5948a-81f2-4fdc-8a38-77c39a59c2bc": //	YarbayS
                    return PatientGroupEnum.Officer;
                //	--->Astsubay
                case "320630aa-a14b-4767-b107-04f9ffadddb0": //	Astsubay Başçavuş
                case "238632b3-b79a-4277-a4ff-97acd3b27dc0": //	Astsubay Çavuş
                case "b264d850-2d01-4550-923a-584321d8a52e": //	Astsubay Kıdemli Başçavuş
                case "4e091224-cb57-4bc3-9fc8-e3fb556e70d9": //	Astsubay Kıdemli Çavuş
                case "ea4238b1-4e82-49dc-abf5-275aa499abd2": //	Astsubay Kıdemli Üstçavuş
                case "7705eb2e-b138-49cf-be74-ece048c1a504": //	Astsubay Üstçavuş
                    return PatientGroupEnum.NoncommissionedOfficer;
                //	--->Uzman Jandarma
                case "f7da5d10-14a5-4a1e-88a3-31b802feef47": //	Uzman Jandarma Çavuş
                case "5ff08d8a-be65-45f7-964a-a68a004e7613": //	Uzman Jandarma I Kademeli Çavuş
                case "65da3501-f2c2-4806-8b0e-d93a810c11bd": //	Uzman Jandarma II Kademeli Çavuş
                case "d1548d5f-d3e8-4323-bc3d-0d98601cdeae": //	Uzman Jandarma III Kademeli Çavuş
                case "33d0fbdb-4783-4b23-be09-774886953792": //	Uzman Jandarma IV Kademeli Çavuş
                case "7088ce86-c90a-42aa-950c-09efbb150cdf": //	Uzman Jandarma V Kademeli Çavuş
                case "2b07624e-b5dc-48a0-8ac3-64beb5b00d26": //	Uzman Jandarma VI Kademeli Çavuş
                case "a5957bb4-9d2b-4e71-a7e3-2ec06d7082e7": //	Uzman Jandarma VII Kademeli Çavuş
                case "4b3bf872-532d-41ff-8ab7-c9db36ba09a0": //	Uzman Jandarma VIII Kademeli Çavuş
                    return PatientGroupEnum.ExpertGendarme;
                //	--->Sivil Memur
                case "f7e33d07-81fe-4693-b958-ed9566ad7e6b": //	Sivil
                    return PatientGroupEnum.MilitaryCivilOfficial;//XXXXXX Sivil Memur
                                                                  //	--->Uzman Erbaş
                case "dcf12a65-5cd1-409b-a653-9fbdcafd2f1a": //	Uzman Onbaşı
                case "03e0a81a-4d64-4181-a528-75700989210a": //	Uzman Çavuş
                    return PatientGroupEnum.ExpertNonCom;
            }
            return null;
        }

        public void SetPatientGroup()
        {
            SetPatientGroup(true);
        }

        public void SetPatientGroup(bool yakindahil)
        {
            return;
        }
        protected override void OnBeforeImportFromObject(DataRow dataRow)
        {
            base.OnBeforeImportFromObject(dataRow);

            dataRow["INPATIENTEPISODE"] = null;
            dataRow["IMPORTANTMEDICALINFORMATION"] = null;

            TTObjectContext context = new TTObjectContext(false);
            TTObjectDef objDefPatient = TTObjectDefManager.Instance.GetObjectDef(typeof(Patient));
            TTObjectDef objDefImpMedInfo = TTObjectDefManager.Instance.GetObjectDef(typeof(ImportantMedicalInformation));
            Patient patient = (Patient)context.GetObject(new Guid(dataRow["OBJECTID"].ToString()), objDefPatient, false);
            if (patient != null)
            {
                if (patient["IMPORTANTMEDICALINFORMATION"] != null)
                {
                    ImportantMedicalInformation impMedInfo = (ImportantMedicalInformation)context.GetObject(new Guid(patient["IMPORTANTMEDICALINFORMATION"].ToString()), objDefImpMedInfo, false);
                    if (impMedInfo == null)
                    {
                        patient["IMPORTANTMEDICALINFORMATION"] = null;
                        context.Save();
                    }
                }
            }
            context.Dispose();

        }



        public static Patient AddOrUpdatePatientWithLocalID(TTObjectContext objectContext, Patient sourcePatient)
        {
            TTObjectContext tempContext = new TTObjectContext(false);// kaydedilmez
            if (sourcePatient.ObjectContext == null)
                tempContext.AddObject(sourcePatient);
            Patient sourcePatient2 = (Patient)tempContext.GetObject(sourcePatient.ObjectID, sourcePatient.ObjectDef);
            Patient patient = null;
            if (((ITTObject)sourcePatient2).IsNew)
            {
                objectContext.AddObject(sourcePatient);

                patient = (Patient)objectContext.GetObject(sourcePatient.ObjectID, sourcePatient.ObjectDef);
                patient.NameIsUpdated = true;
                patient.SurnameIsUpdated = true;

                TTSequence.allowSetSequenceValue = true;
                patient.ID.SetSequenceValue(0);
                patient.ID.GetNextValue();
            }
            else
            {
                patient = (Patient)objectContext.GetObject(sourcePatient.ObjectID, sourcePatient.ObjectDef);
                patient.UniqueRefNo = sourcePatient2.UniqueRefNo;

                //Yapılan değişiklikler,MPVTUpdatePatientsAutoScpt GetPatientFromMPVT metodunda da eklenmeli
                patient.UniqueRefNo = sourcePatient2.UniqueRefNo;      // Int64? TcNo;

                patient.Foreign = sourcePatient2.Foreign;
                patient.Name = sourcePatient2.Name;
                patient.Surname = sourcePatient2.Surname;

                //   patient.PatientGroup = sourcePatient2.PatientGroup;

                //  patient.Sex = sourcePatient2.Sex;
                patient.BirthDate = sourcePatient2.BirthDate;
                patient.BirthPlace = sourcePatient2.BirthPlace;
                patient.TownOfBirth = sourcePatient2.TownOfBirth;// string dogumyerilce;
                patient.Relationship = sourcePatient2.Relationship;// string yakinlikderecesi;

                patient.MotherName = string.IsNullOrEmpty(sourcePatient2.MotherName) ? sourcePatient2.MotherName : sourcePatient2.MotherName.Trim(); // sourcePatient2.MotherName          // string anaadi;
                patient.FatherName = string.IsNullOrEmpty(sourcePatient2.FatherName) ? sourcePatient2.FatherName : sourcePatient2.FatherName.Trim(); //sourcePatient2.FatherName;         // string babaadi;
                                                                                                                                                     // patient.ForcesCommand = sourcePatient2.ForcesCommand;// string kuvvet;
                                                                                                                                                     //  patient.MaritalStatus = sourcePatient2.MaritalStatus;// string medenihal;
                                                                                                                                                     // patient.EmploymentRecordid = string.IsNullOrEmpty(sourcePatient2.EmploymentRecordid) ? sourcePatient2.EmploymentRecordid : sourcePatient2.EmploymentRecordid.Trim(); //sourcePatient.EmploymentRecordid;   // string sicilno;
                                                                                                                                                     //    patient.RetirementFundID = string.IsNullOrEmpty(sourcePatient2.RetirementFundID) ? sourcePatient2.RetirementFundID : sourcePatient2.RetirementFundID.Trim(); // sourcePatient2.RetirementFundID;    // string emeklino;
                                                                                                                                                     //patient.SskNo = string.IsNullOrEmpty(sourcePatient2.SskNo) ? sourcePatient2.SskNo : sourcePatient2.SskNo.Trim(); // sourcePatient2.SskNo;                  // string sskno;
                                                                                                                                                     //patient.HealtSlipNumber = string.IsNullOrEmpty(sourcePatient2.HealtSlipNumber) ? sourcePatient2.HealtSlipNumber : sourcePatient2.HealtSlipNumber.Trim(); //sourcePatient2.HealtSlipNumber;     // string saglikkarnefisno;
                                                                                                                                                     //   patient.BeneficiaryDate = sourcePatient2.BeneficiaryDate;     // DateTime? haksahipgecerliliktarihi;
                                                                                                                                                     // patient.Beneficiary = sourcePatient2.Beneficiary;

                patient.CountryOfBirth = sourcePatient2.CountryOfBirth;// string dogumyerulke;
                                                                       //  patient.MilitaryUnit = sourcePatient2.MilitaryUnit;// string birlik;
                                                                       //patient.MilitaryAcceptanceTime = sourcePatient2.MilitaryAcceptanceTime;     // DateTime? XXXXXXegiristarihi;
                                                                       // patient.BagKurNo = string.IsNullOrEmpty(sourcePatient2.BagKurNo) ? sourcePatient2.BagKurNo : sourcePatient2.BagKurNo.Trim(); //sourcePatient2.BagKurNo;// string bagkurno;
                                                                       // patient.WarVetera = sourcePatient2.WarVetera; // string gazi;
                patient.SpecialStatus = string.IsNullOrEmpty(sourcePatient2.SpecialStatus) ? sourcePatient2.SpecialStatus : sourcePatient2.SpecialStatus.Trim(); //sourcePatient2.SpecialStatus;//string ozeldurumu;


                patient.PatientAddress.HomeAddress = string.IsNullOrEmpty(sourcePatient2.PatientAddress.HomeAddress) ? sourcePatient2.PatientAddress.HomeAddress : sourcePatient2.PatientAddress.HomeAddress.Trim(); //sourcePatient2.HomeAddress;               // string adres;
                patient.PatientAddress.HomeCity = sourcePatient2.PatientAddress.HomeCity; //sourcePatient2.HomeCity;// string adresil;
                patient.PatientAddress.HomeTown = sourcePatient2.PatientAddress.HomeTown; //sourcePatient2.HomeTown;// string adresilce;
                                                                                          //   patient.FamilyNo = string.IsNullOrEmpty(sourcePatient2.FamilyNo) ? sourcePatient2.FamilyNo : sourcePatient2.FamilyNo.Trim(); //sourcePatient2.FamilyNo;                // string aileno;
                                                                                          // patient.Length = string.IsNullOrEmpty(sourcePatient2.Length) ? sourcePatient2.Length : sourcePatient2.Length.Trim(); //sourcePatient2.Length;               // string boy;
                                                                                          //  patient.IdentificationVolumeNo = string.IsNullOrEmpty(sourcePatient2.IdentificationVolumeNo) ? sourcePatient2.IdentificationVolumeNo : sourcePatient2.IdentificationVolumeNo.Trim(); //sourcePatient2.IdentificationVolumeNo;       // string ciltno;

                patient.OtherBirthPlace = string.IsNullOrEmpty(sourcePatient2.OtherBirthPlace) ? sourcePatient2.OtherBirthPlace : sourcePatient2.OtherBirthPlace.Trim(); //sourcePatient2.OtherBirthPlace;       // string dogumyerdiger;
                patient.EyeColor = sourcePatient2.EyeColor;// string gozrengi;
                                                           //   patient.BloodGroup = sourcePatient2.BloodGroup;// string kangurubu;
                patient.CityOfRegistry = sourcePatient2.CityOfRegistry;// string nufusakayitliolduguil;
                patient.TownOfRegistry = sourcePatient2.TownOfRegistry;// string nufusakayitliolduguilce;
                patient.VillageOfRegistry = sourcePatient2.VillageOfRegistry;     // string nufusakayitlioldugukoy;

                if (sourcePatient2["MERGEDTOPATIENT"] != null)
                {
                    bool doIt = false;
                    if (patient.MergedToPatient == null)
                        doIt = true;
                    else if (patient.MergedToPatient.ObjectID != (Guid)sourcePatient2["MERGEDTOPATIENT"])
                        doIt = true;

                    if (doIt)
                    {
                        Patient mergedToPatient = (Patient)objectContext.GetObject((Guid)sourcePatient2["MERGEDTOPATIENT"], typeof(Patient));
                        MergePatients(patient, mergedToPatient);
                    }
                }
                // Yeni eklenecek property IsMVPTPropertiesUpdated() methoduna da eklenmeli
            }
            return patient;
        }

        /// <summary>
        /// Zorunlu Hasta bilgilerini kontrol eder
        /// </summary>
        public static bool IsAllRequiredPropertiesExists(bool throwException, Patient patient)
        {
            if (patient.UnIdentified != true)
            {
                if (!(patient.Foreign == true))
                {
                    if (patient.UniqueRefNo == null)
                    {
                        if (throwException)
                        {
                            String message = SystemMessage.GetMessage(92);
                            throw new TTUtils.TTException(message);
                            //throw new Exception("T.C Kimlik Numarasını girmediniz. Lütfen T.C Kimlik Numarasını giriniz.");
                        }
                        else
                            return false;
                    }
                    if (patient.UniqueRefNo.ToString().Trim().Length != 11)
                    {
                        if (throwException)
                        {
                            String message = SystemMessage.GetMessage(93);
                            throw new TTUtils.TTException(message);
                            //throw new Exception("T.C Kimlik No alanı 11 karakterden oluşmalıdır.");
                        }
                        else
                            return false;
                    }
                    if (!patient.CheckMernisNumber())
                    {
                        //                        if (throwException)
                        //                        {
                        string[] hataParamList = new string[] { patient.UniqueRefNo.ToString() };
                        String message = SystemMessage.GetMessageV3(94, hataParamList);
                        throw new TTUtils.TTException(message);
                        // throw new Exception(this.UniqueRefNo.Text.ToString() + " geçerli bir T.C Kimlik No değildir.");
                        //                        }
                        //                        else
                        //                            return false;

                    }
                }
                else if (patient.Foreign == true)
                {
                    if (patient.UniqueRefNo == null)
                    {
                        if (throwException)
                        {
                            string[] hataParamList = new string[] { TTUtils.CultureService.GetText("M27202", "Yabancı hastalar için 'Kimlik Sigorta No'") };
                            String message = SystemMessage.GetMessageV3(95, hataParamList);
                            throw new TTUtils.TTException(message);
                            //throw new Exception("Yabancı hastalar için 'Kimlik Sigorta No' alanı boş geçilemez");
                        }
                        else
                            return false;
                    }
                }
                if (patient.Name == null)
                {
                    if (throwException)
                    {
                        string[] hataParamList = new string[] { "'Adı'" };
                        String message = SystemMessage.GetMessageV3(95, hataParamList);
                        throw new TTUtils.TTException(message);
                        //throw new Exception("'Adı' alanı boş geçilemez");
                    }
                    else
                        return false;
                }
                if (patient.Surname == null)
                {
                    if (throwException)
                    {
                        string[] hataParamList = new string[] { "'Soyadı'" };
                        String message = SystemMessage.GetMessageV3(95, hataParamList);
                        throw new TTUtils.TTException(message);
                        //throw new Exception("'Soyadı' alanı boş geçilemez");
                    }
                    else
                        return false;

                }

                if (patient.FatherName == null)
                {
                    if (throwException)
                    {
                        string[] hataParamList = new string[] { "'Baba Adı'" };
                        String message = SystemMessage.GetMessageV3(95, hataParamList);
                        throw new TTUtils.TTException(message);
                        //throw new Exception("'Baba Adı' alanı boş geçilemez");
                    }
                    else
                        return false;

                }

                if (patient.BirthDate == null || (patient.BirthDate + "").ToString().Trim() == ".  ." || (patient.BirthDate + "").ToString().Trim() == "")
                {
                    if (throwException)
                    {
                        string[] hataParamList = new string[] { "'Doğum Tarihi'" };
                        String message = SystemMessage.GetMessageV3(95, hataParamList);
                        throw new TTUtils.TTException(message);
                        //throw new Exception("'Doğum Tarihi' alanı boş geçilemez");
                    }
                    else
                        return false;
                }

                if (Convert.ToDateTime(patient.BirthDate) < Convert.ToDateTime("02.01.1800"))
                {
                    if (throwException)
                    {
                        throw new TTException(SystemMessage.GetMessage(982));
                    }
                    else
                        return false;
                }

                if (Common.DateDiffV2(0, Convert.ToDateTime(Common.RecTime()), Convert.ToDateTime(patient.BirthDate), false) < 0)
                {
                    if (throwException)
                    {
                        String message = SystemMessage.GetMessage(96);
                        throw new TTUtils.TTException(message);
                        //throw new TTException("Hastanın doğum tarihi bugünden sonra olamaz.");
                    }
                    else
                        return false;
                }
                if (patient.CountryOfBirth == null)
                {
                    if (throwException)
                    {
                        string[] hataParamList = new string[] { "'Ülke'" };
                        String message = SystemMessage.GetMessageV3(95, hataParamList);
                        throw new TTUtils.TTException(message);
                        //throw new Exception("'Ülke' alanı boş geçilemez");
                    }
                    else
                        return false;
                }

                if (patient.Nationality == null)
                {
                    if (throwException)
                    {
                        string[] hataParamList = new string[] { "'Uyruk'" };
                        String message = SystemMessage.GetMessageV3(95, hataParamList);
                        throw new TTUtils.TTException(message);
                        //throw new Exception("'Ülke' alanı boş geçilemez");
                    }
                    else
                        return false;
                }

                string turkey = TTObjectClasses.SystemParameter.GetParameterValue("TURKEYCOUNTRYOBJECTID", "27ff15c1-c50d-4b9a-bff8-b010939c39d6");
                Guid turkeyID = new Guid(turkey);
                if (patient.CountryOfBirth.ObjectID.Equals(turkeyID))
                {
                    if (patient.BirthPlace == null)
                    {
                        if (throwException)
                        {
                            string[] hataParamList = new string[] { "'Doğum İli'" };
                            String message = SystemMessage.GetMessageV3(95, hataParamList);
                            throw new TTUtils.TTException(message);
                            //throw new Exception("'Doğum İli' alanı boş geçilemez");
                        }
                        else
                            return false;

                    }
                    if (patient.TownOfBirth == null)
                    {

                        if (throwException)
                        {
                            string[] hataParamList = new string[] { "'Doğum İlçesi'" };
                            String message = SystemMessage.GetMessageV3(95, hataParamList);
                            throw new TTUtils.TTException(message);
                            //throw new Exception("'Doğum İlçesi' alanı boş geçilemez");
                        }
                        else
                            return false;
                    }
                }
                if (patient.BirthDate == null || (patient.BirthDate + "").ToString().Trim() == ".  ." || (patient.BirthDate + "").ToString().Trim() == "")
                {
                    if (throwException)
                    {
                        string[] hataParamList = new string[] { "'Doğum Tarihi'" };
                        String message = SystemMessage.GetMessageV3(95, hataParamList);
                        throw new TTUtils.TTException(message);
                        //throw new Exception("'Doğum Tarihi' alanı boş geçilemez");
                    }
                    else
                        return false;
                }

                if (Convert.ToDateTime(patient.BirthDate) < Convert.ToDateTime("02.01.1800"))
                {
                    if (throwException)
                    {
                        throw new TTException(SystemMessage.GetMessage(982));
                    }
                    else
                        return false;
                }
            }

            if (patient.Privacy != null)
            {
                if (patient.Privacy == true)
                {
                    if (throwException && (patient.PrivacyName == null || patient.PrivacySurname == null))
                    {
                        string[] hataParamList = new string[] { "'Rumuz Ad ya da Rumuz Soyad'" };
                        String message = SystemMessage.GetMessageV3(95, hataParamList);
                        throw new TTUtils.TTException(message);
                    }
                    else
                        return false;
                }
            }

            return true;
        }

        private static void MergePatients(Patient sourcePatient, Patient targetPatient)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            Guid savePoint = objectContext.BeginSavePoint();
            bool merge = false;
            if (targetPatient.MergedToPatient == null)
            {
                ArrayList sourcePatientEpisodes;

                if (sourcePatient.ObjectID != targetPatient.ObjectID)
                {
                    if (sourcePatient.MergedToPatient == null)
                    {
                        merge = true;
                        sourcePatientEpisodes = new ArrayList();
                        foreach (Episode e in sourcePatient.Episodes)
                        {
                            sourcePatientEpisodes.Add(e);
                        }
                        foreach (Episode e in sourcePatientEpisodes)
                        {
                            e.OldPatient = e.Patient; //To save old patient for dismerge.
                            e.Patient = targetPatient;
                        }
                        sourcePatient.MergedToPatient = targetPatient;
                        sourcePatient.UniqueRefNo = null;
                        sourcePatient.Note = "Hastanın dosyası, " + Common.RecTime().ToShortDateString() + " tarihinde " + targetPatient.ID.ToString() + " " + targetPatient.Name + " " + targetPatient.Surname + " hastası ile birleştirilmiştir.";

                        // SITEID parametresine gore PACS a mergeinfo gonderiliyordu, istenirse sistem parametresine bagli olarak gonderilebilir. 
                        SendMergeInfoToPACS(sourcePatient.ObjectID.ToString());
                    }
                }
                if (merge)
                {
                    objectContext.Save();
                }
            }
        }

        /// <summary>
        /// Hasta birleştirme bilgilerini Pacs'a gönder...
        /// </summary>
        /// <param name="patientID"></param>
        private static void SendMergeInfoToPACS(string patientID)
        {
            string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("HL7ENGINEALIVE", null);
            if (sysparam == "TRUE")
            {
                //List<Guid> patientIDs = new List<Guid>();
                //patientIDs.Add(new Guid(patientID));
                //TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.MediumPriority, "InternalTCPClient", "HL7Remoting", "SendHospitalMessageToEngine", null, patientIDs, "A40", "PACS");
            }
        }

        public ExaminationQueueItem HasActiveQueueItemInQueue(ExaminationQueueDefinition queue, Resource procedureDoctor)
        {
            IList<Resource> doctors = queue.GetWorkingResources(ObjectContext);
            List<Guid> doctorGUIDs = new List<Guid>();

            Guid procedureDoctorGUID = Guid.Empty;
            if (procedureDoctor != null)
            {
                procedureDoctorGUID = procedureDoctor.ObjectID;
                doctorGUIDs.Add(procedureDoctorGUID);
            }
            foreach (ResUser doctor in doctors)
            {
                if (doctor.ObjectID != procedureDoctorGUID)
                {
                    doctorGUIDs.Add(doctor.ObjectID);
                }
            }
            if (doctorGUIDs.Count == 0)
                doctorGUIDs.Add(Guid.Empty);
            BindingList<ExaminationQueueItem> queueItems = ExaminationQueueItem.GetActiveQueueItemsOfPatientByQueueByDate(ObjectContext, doctorGUIDs, queue.ObjectID, Common.RecTime().Date.AddDays(1).AddSeconds(-1), Common.RecTime().Date, ObjectID);
            foreach (ExaminationQueueItem queueItem in queueItems)
            {
                return queueItem;
            }
            return null;
        }



        //TODO Tuğba : Provizyon İşlemleri



        public class ASyncBase
        {
            protected TTObjectContext objectcontext;

            private string _medulaProvisionObjectID;

            private string _messageObjectID;

            private string _subEpisodeObjectID;

            private string _provisionRequestObjectID;

            public string MessageObjectID
            {
                get { return _messageObjectID; }
                set { _messageObjectID = value; }
            }

            public string MedulaProvisionObjectID
            {
                get { return _medulaProvisionObjectID; }
                set { _medulaProvisionObjectID = value; }
            }

            public string SubEpisodeObjectID
            {
                get { return _subEpisodeObjectID; }
                set { _subEpisodeObjectID = value; }
            }


            public ASyncBase()
            {
                MessageObjectID = Guid.NewGuid().ToString();
            }
        }

        [Serializable]
        public class PatientAdmissionWebCaller : Patient.ASyncBase, IWebMethodCallback
        {

            private Guid _objectID;
            public Guid ObjectID
            {
                get { return _objectID; }
                set { _objectID = value; }
            }

            public PatientAdmissionWebCaller() { }

            public PatientAdmissionWebCaller(TTObjectClasses.HastaKabulIslemleri.provizyonGirisDVO provizyonGirisDVO, string medulaProvisionObjectID)
            {
                _provizyonGirisDVO = provizyonGirisDVO;
                MedulaProvisionObjectID = medulaProvisionObjectID;
            }

            public PatientAdmissionWebCaller(TTObjectClasses.HastaKabulIslemleri.takipSilGirisDVO takipSilGirisDVO, string subEpisodeObjectID, string type)
            {
                _takipSilGirisDVO = takipSilGirisDVO;
                SubEpisodeObjectID = subEpisodeObjectID;
            }

            public TTObjectClasses.HastaKabulIslemleri.provizyonGirisDVO _provizyonGirisDVO;

            public TTObjectClasses.HastaKabulIslemleri.takipSilGirisDVO _takipSilGirisDVO;



            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {
                if (returnValue != null)
                {
                    if (returnValue is HastaKabulIslemleri.provizyonCevapDVO)
                    {

                        TTObjectClasses.HastaKabulIslemleri.provizyonCevapDVO result = (TTObjectClasses.HastaKabulIslemleri.provizyonCevapDVO)returnValue;
                        TTObjectContext _context = new TTObjectContext(false);
                        string medulaProvisionObjectID = MedulaProvisionObjectID;
                        HastaKabulCompletedInternal(result, _provizyonGirisDVO, medulaProvisionObjectID, _context);
                        _context.Save();
                        _context.Dispose();
                    }
                }
                return true;

            }

            public TTObjectContext ObjectContext { get { return new TTObjectContext(false); } }

            public void HastaKabulCompletedInternal(TTObjectClasses.HastaKabulIslemleri.provizyonCevapDVO result, TTObjectClasses.HastaKabulIslemleri.provizyonGirisDVO provizyonGirisDVO,
                                                    string medulaProvisionObjectID, TTObjectContext _context)
            {
                MedulaProvision md = (MedulaProvision)_context.GetObject(new Guid(medulaProvisionObjectID), typeof(MedulaProvision));
                md.ProvisionNo = result.takipNo;
                md.RelatedProvisionNo = provizyonGirisDVO.takipNo;

                md.CurrentStateDefID = MedulaProvision.States.New;
                md.ProvisionDate = Convert.ToDateTime(provizyonGirisDVO.provizyonTarihi);
                md.DevredilenKurum = DevredilenKurum.GetDevredilenKurum(provizyonGirisDVO.devredilenKurum);
                md.ProvizyonTipi = ProvizyonTipi.GetProvizyonTipi(provizyonGirisDVO.provizyonTipi);
                md.SigortaliTuru = SigortaliTuru.GetSigortaliTuru(provizyonGirisDVO.sigortaliTuru);
                md.TakipTipi = TakipTipi.GetTakipTipi(provizyonGirisDVO.takipTipi);
                md.TedaviTipi = TedaviTipi.GetTedaviTipi(provizyonGirisDVO.tedaviTipi);
                md.TedaviTuru = TedaviTuru.GetTedaviTuru(provizyonGirisDVO.tedaviTuru);
                md.Brans = SpecialityDefinition.GetBrans(provizyonGirisDVO.bransKodu);
                md.GreenCardSendingFacilityCode = provizyonGirisDVO.yesilKartSevkEdenTakipTipi;
                md.DonorUniqueRefno = (long)Convert.ToInt64(provizyonGirisDVO.donorTCKimlikNo);

                md.ResultCode = result.sonucKodu;
                md.ResultMessage = result.sonucMesaji;

                if (result.sonucKodu.Equals("0000"))
                {
                    md.Status = MedulaSubEpisodeStatusEnum.ProcedureEntryNotCompleted;
                    md.ProvisionNo = result.takipNo;
                    md.ApplicationNo = result.hastaBasvuruNo;
                }
                else
                {
                    md.Status = MedulaSubEpisodeStatusEnum.ProvisionNoNotExists;
                }
            }
        }

        public List<SubEpisodeProtocol> GetSGKSEPs(DateTime? startDate, DateTime? endDate)
        {
            return Patient.GetSGKSEPs(this, startDate, endDate);
        }

        // Formlarda kullanmak için 
        public static List<SubEpisodeProtocol> GetSGKSEPs(Patient patient, DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null)
                startDate = DateTime.MinValue;
            if (endDate == null)
                endDate = DateTime.MaxValue;

            List<SubEpisodeProtocol> retList = new List<SubEpisodeProtocol>();
            BindingList<SubEpisodeProtocol> sepList = SubEpisodeProtocol.GetSEPByPatient(patient.ObjectContext, (DateTime)startDate, (DateTime)endDate, patient.ObjectID, string.Empty);

            foreach (SubEpisodeProtocol sep in sepList)
            {
                if (sep.IsSGK)
                    retList.Add(sep);
            }

            return retList;
        }

        public List<SubEpisodeProtocol> GetActiveSGKSEPs(DateTime? startDate, DateTime? endDate)
        {
            return Patient.GetActiveSGKSEPs(this, startDate, endDate);
        }

        // Formlarda kullanmak için 
        public static List<SubEpisodeProtocol> GetActiveSGKSEPs(Patient patient, DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null)
                startDate = DateTime.MinValue;
            if (endDate == null)
                endDate = DateTime.MaxValue;

            List<SubEpisodeProtocol> retList = new List<SubEpisodeProtocol>();
            List<SubEpisodeProtocol> sepList = patient.GetSGKSEPs(startDate, endDate);

            foreach (SubEpisodeProtocol sep in sepList)
            {
                if (sep.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled)
                    retList.Add(sep);
            }

            return retList;
        }

        // Aynı gün aynı branşa ikinci günübirlik takibi almasını kontrol eder
        public bool SuitableToCreateNewDailySubEpisode(SpecialityDefinition brans)  // Branş kontrolüne gerek yoksa speciality parametresi kaldırılabilir (MDZ)
        {
            if (brans == null)
                throw new TTException(TTUtils.CultureService.GetText("M25760", "Günübirlik takip kontrolü için branş boş olmamalıdır."));

            DateTime startDate = Common.RecTime().Date;
            DateTime endDate = startDate.AddDays(1);

            List<SubEpisodeProtocol> sepList = GetActiveSGKSEPs(startDate, endDate);
            foreach (SubEpisodeProtocol sep in sepList)
            {
                if (!string.IsNullOrEmpty(sep.MedulaTakipNo) && sep.MedulaTedaviTuru.tedaviTuruKodu.Equals("G") && brans.ObjectID == sep.Brans.ObjectID)
                    return false;
            }

            return true;
        }

        //Doğrudan temin işlemi ile alınmış ama hastaya kullanılmamış olan ürün varsa true döner.
        public bool HasNotUsedDirectPurchaseProducts()
        {
            foreach (DirectPurchaseAction directPurchaseAction in DirectPurchaseActions)
            {
                if (directPurchaseAction.CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                {
                    foreach (DirectPurchaseActionDetail directPurchaseActionDetail in directPurchaseAction.DirectPurchaseActionDetails)
                    {
                        if (directPurchaseActionDetail.Cancelled.HasValue == false || (directPurchaseActionDetail.Cancelled.HasValue == true && directPurchaseActionDetail.Cancelled.Value != true))
                            if (directPurchaseActionDetail.HasUsed != true)
                                return true;
                    }
                }
            }
            return false;
        }

        //Doğrudan temin işlemi ile alınmış ama hastaya kullanılmamış olan ürün varsa döndürür
        public List<DirectPurchaseActionDetail> GetNotUsedDirectPurchaseProducts()
        {
            List<DirectPurchaseActionDetail> directPurchaseActionDetailList = new List<DirectPurchaseActionDetail>();
            foreach (DirectPurchaseAction directPurchaseAction in DirectPurchaseActions)
            {
                if (directPurchaseAction.CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                {
                    foreach (DirectPurchaseActionDetail directPurchaseActionDetail in directPurchaseAction.DirectPurchaseActionDetails)
                    {
                        if (directPurchaseActionDetail.Cancelled.HasValue == false || (directPurchaseActionDetail.Cancelled.HasValue == true && directPurchaseActionDetail.Cancelled.Value != true))
                            if (directPurchaseActionDetail.HasUsed != true)
                                directPurchaseActionDetailList.Add(directPurchaseActionDetail);
                    }
                }
            }
            return directPurchaseActionDetailList;
        }

        /// <summary>
        /// Hasta kabul bilgilerini gizle ya da gizliliği kaldır
        /// </summary>
        /// <param name="patientID"></param>
        public static void CoverPatientInformation(bool? isPrivacy, Patient patient)
        {

        }
        public static DateTime GetBirthDate(DateTime? birthDate)
        {
            return Convert.ToDateTime(birthDate);
        }
        public static Patient MatchMother(Patient patient, Patient mother)
        {
            if (mother.Sex != null && mother.Sex.KODU == "2")
            {
                if (patient.BirthDate == null)
                    throw new Exception(TTUtils.CultureService.GetText("M27235", "Yeni doğanın doğum tarihini giriniz."));

                int bDay = Common.DateDiff(Common.DateIntervalEnum.Day, DateTime.Now, patient.BirthDate.Value);
                if (bDay < 31)
                {
                    return mother;
                }
                else
                {
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25087", "30 günden büyük bebeklere anne-bebek eşleştirmesi yapılmaz."));

                }
            }
            else
                throw new Exception(TTUtils.CultureService.GetText("M25604", "Erkek hastalarda 'Anne-bebek' eşleştirmesi yapamazsınız."));

        }

        #region KPSV2
        public static Patient.MernisPatientModel GetPatientandAdresInfoFromKPS(Patient _patient, bool _newPatient, TTObjectContext ctx)
        {
            #region PatientAdmissionForm_AdresBilgisisorgula
            //try
            //{
                if (_patient.UniqueRefNo != null)
                {
                    KPSV2.KpsServisSonucuBilesikKisiBilgisi response = KPSV2.WebMethods.BilesikKisiveAdresSorgulaSync(Sites.SiteLocalHost, Convert.ToInt64(_patient.UniqueRefNo));

                    if (response.HataBilgisi == null)
                    {
                        if (response.Sonuc.HataBilgisi == null)
                        {
                            if (response.Sonuc.MaviKartliKisiKutukleri != null)
                                return GetMaviKartliKisiKutukleriFromKPS(response.Sonuc.MaviKartliKisiKutukleri, _patient, _newPatient, ctx);
                            else if (response.Sonuc.TCVatandasiKisiKutukleri != null) //3.sıraya al
                                return GetTCVatandasiKisiKutukleriFromKPS(response.Sonuc.TCVatandasiKisiKutukleri, _patient, _newPatient, ctx);
                            else if (response.Sonuc.YabanciKisiKutukleri != null)
                                return GetYabanciKisiKutukleriFromKPS(response.Sonuc.YabanciKisiKutukleri, _patient, _newPatient, ctx);

                        }
                        else
                        {
                            TTUtils.InfoMessageService.Instance.ShowMessage(response.Sonuc.HataBilgisi.Aciklama);
                            return null;
                        }
                    }
                    else
                    {
                        TTUtils.InfoMessageService.Instance.ShowMessage(response.HataBilgisi.Aciklama);
                        return null;
                    }
                }

                return null;
            //}
            //catch (Exception ex)
            //{
            //    throw new TTUtils.TTException(ex.Message);
            //}
            #endregion PatientAdmissionForm_AdresBilgisisorgula_Click
        }
        public static Patient.MernisPatientModel GetPatientandAdresInfoFromKPS_OLD(KPSServis.KPSServisSonucuKisiTemelBilgisi response, Patient _patient, bool _newPatient, TTObjectContext ctx)
        {
            try
            {
                Patient.MernisPatientModel mpm = new Patient.MernisPatientModel();

                if (_patient.UniqueRefNo != null)
                {
                    if (_newPatient)
                    {
                        _patient.Name = response.Sonuc.Ad;
                        _patient.Surname = response.Sonuc.Soyad;
                        _patient.MotherName = response.Sonuc.AnaAd;
                        _patient.FatherName = response.Sonuc.BabaAd;
                        string _otp = response.Sonuc.OlumTarih;
                        if (_otp != "0.0.0")
                        {
                            _patient.ExDate = Convert.ToDateTime(_otp);
                            //_patient.Death = true;
                            _patient.Alive = false;
                        }
                        else
                            _patient.Alive = true;

                        _patient.BirthDate = Convert.ToDateTime(response.Sonuc.DogumTarihi);
                        _patient.BirthPlace = response.Sonuc.DogumYer;

                        var _medeniHalP = response.Sonuc.MedeniHal;
                        if (_medeniHalP != null)
                        {
                            var code = "99";
                            if (_medeniHalP.ToString().Contains("Bek") == true)
                                code = "1";
                            else if (_medeniHalP.ToString().Contains(TTUtils.CultureService.GetText("M25624", "Evli")) == true)
                                code = "2";
                            else if (_medeniHalP.ToString().Contains(TTUtils.CultureService.GetText("M25548", "Dul")) == true || _medeniHalP.ToString().Contains(TTUtils.CultureService.GetText("M25289", "Boş")) == true || _medeniHalP.ToString().Contains(TTUtils.CultureService.GetText("M25217", "Ayrı")) == true)//Boşanmış/Dul
                                code = "3";

                            BindingList<SKRSMedeniHali> medeniHalList = SKRSMedeniHali.GetSKRSMaritalStatusByCode(_patient.ObjectContext, Convert.ToString(code));

                            if (medeniHalList.Count > 0)
                                _patient.SKRSMaritalStatus = medeniHalList[0];

                        }
                        else
                            _patient.SKRSMaritalStatus = null;// new SKRSCinsiyet(ctx);

                        var _sexP = response.Sonuc.Cinsiyet;
                        BindingList<SKRSCinsiyet> cinsiyetKodlariP = null;
                        if (_sexP != null)
                        {
                            int sexKodu = 1;
                            if (_sexP == TTUtils.CultureService.GetText("M17061", "Kadın"))
                                sexKodu = 2;

                            cinsiyetKodlariP = SKRSCinsiyet.GetSKRSCinsiyetByKodu(_patient.ObjectContext, Convert.ToString(sexKodu));
                            if (cinsiyetKodlariP.Count > 0)
                                _patient.Sex = cinsiyetKodlariP[0];
                            else
                                _patient.Sex = null;// new SKRSCinsiyet(ctx);
                        }
                        else
                            _patient.Sex = null;// new SKRSCinsiyet(ctx);

                        BindingList<SKRSUlkeKodlari> ulkeKodlariP = null;
                        ulkeKodlariP = SKRSUlkeKodlari.GetByMernisKodu(ctx, "9980");
                        if (ulkeKodlariP.Count > 0)
                            _patient.Nationality = ulkeKodlariP[0];
                        else
                            _patient.Nationality = null;

                        //return null;
                    }
                    //else
                    //{

                    mpm.KPSName = response.Sonuc.Ad;
                    mpm.KPSSurname = response.Sonuc.Soyad;
                    mpm.KPSMotherName = response.Sonuc.AnaAd;
                    mpm.KPSFatherName = response.Sonuc.BabaAd;
                    mpm.KPSUniqueRefNo = _patient.UniqueRefNo;
                    mpm.KPSForeign = false;
                    mpm.KPsForeignUniqueRefNo = null;
                    string _ot = response.Sonuc.OlumTarih;
                    if (_ot != "0.0.0")
                    {
                        mpm.KPSExDate = Convert.ToDateTime(_ot);
                        //_patient.Death = true;
                        mpm.KPSAlive = false;
                    }
                    else
                        mpm.KPSAlive = true;

                    mpm.KPSBirthDate = Convert.ToDateTime(response.Sonuc.DogumTarihi);
                    mpm.KPSBirthPlace = response.Sonuc.DogumYer;

                    var _medeniHal = response.Sonuc.MedeniHal;
                    if (_medeniHal != null)
                    {
                        var code = "99";
                        if (_medeniHal.ToString().Contains("Bek") == true)
                            code = "1";
                        else if (_medeniHal.ToString().Contains(TTUtils.CultureService.GetText("M25624", "Evli")) == true)
                            code = "2";
                        else if (_medeniHal.ToString().Contains(TTUtils.CultureService.GetText("M25548", "Dul")) == true || _medeniHal.ToString().Contains(TTUtils.CultureService.GetText("M25289", "Boş")) == true || _medeniHal.ToString().Contains(TTUtils.CultureService.GetText("M25217", "Ayrı")) == true)//Boşanmış/Dul
                            code = "3";

                        BindingList<SKRSMedeniHali> medeniHalList = SKRSMedeniHali.GetSKRSMaritalStatusByCode(_patient.ObjectContext, Convert.ToString(code));

                        if (medeniHalList.Count > 0)
                        {
                            mpm.SKRSMaritalStatus = medeniHalList[0];
                            mpm.SKRSMaritalStatusName = medeniHalList[0].ADI;
                        }

                    }
                    else
                        mpm.SKRSMaritalStatus = null;// new SKRSCinsiyet(ctx);

                    var _sex = response.Sonuc.Cinsiyet;
                    BindingList<SKRSCinsiyet> cinsiyetKodlari = null;
                    if (_sex != null)
                    {
                        int sexKodu = 1;
                        if (_sex == TTUtils.CultureService.GetText("M17061", "Kadın"))
                            sexKodu = 2;

                        cinsiyetKodlari = SKRSCinsiyet.GetSKRSCinsiyetByKodu(_patient.ObjectContext, Convert.ToString(sexKodu));
                        if (cinsiyetKodlari.Count > 0)
                        {
                            mpm.KPSSex = cinsiyetKodlari[0];
                            mpm.KPSSexName = cinsiyetKodlari[0].ADI;
                        }
                        else
                            mpm.KPSSex = null;// new SKRSCinsiyet(ctx);
                    }
                    else
                        mpm.KPSSex = null;// new SKRSCinsiyet(ctx);

                    BindingList<SKRSUlkeKodlari> ulkeKodlari = null;
                    ulkeKodlari = SKRSUlkeKodlari.GetByMernisKodu(ctx, "9980");
                    if (ulkeKodlari.Count > 0)
                    {
                        mpm.KPSNationality = ulkeKodlari[0];
                        mpm.KPSNationalityName = ulkeKodlari[0].Adi;
                    }
                    else
                        mpm.KPSNationality = null;
                    return mpm;
                    //}
                }
                return mpm;
            }
            catch (Exception ex)
            {
                throw new TTUtils.TTException(ex.Message);
            }
        }

        public static Patient.MernisPatientModel GetForeignPatientandAdresInfoFromKPS_OLD(KPSServis.KPSServisSonucuYabanciKisiBilgisi response, Patient _patient, bool _newPatient, TTObjectContext ctx)
        {
            try
            {
                if (_patient.UniqueRefNo != null)
                {
                    if (_newPatient)
                    {
                        _patient.Name = response.Sonuc.Ad;
                        _patient.Surname = response.Sonuc.Soyad;
                        _patient.MotherName = response.Sonuc.AnneAd;
                        _patient.FatherName = response.Sonuc.BabaAd;
                        _patient.Alive = true;
                        _patient.Foreign = true;
                        _patient.ForeignUniqueRefNo = _patient.UniqueRefNo; //UniqueRefNo nulllanabilir
                        _patient.UniqueRefNo = null;
                        var _nationalityP = response.Sonuc.Ulke;
                        BindingList<SKRSUlkeKodlari> ulkeKodlariP = null;
                        if (_nationalityP != null)
                        {
                            ulkeKodlariP = SKRSUlkeKodlari.GetByMernisKodu(ctx, response.Sonuc.UlkeKod);
                            if (ulkeKodlariP.Count > 0)
                                _patient.Nationality = ulkeKodlariP[0];
                            else
                                _patient.Nationality = null;
                        }
                        else
                            _patient.Nationality = null;
                        string _otP = response.Sonuc.OlumTarihi;
                        if (_otP != "0.0.0" && _otP != "")
                        {
                            _patient.ExDate = Convert.ToDateTime(response.Sonuc.OlumTarihi);
                            _patient.Alive = false;
                            _patient.Death = true;
                        }


                        _patient.BirthDate = Convert.ToDateTime(response.Sonuc.DogumTarih);
                        _patient.BirthPlace = response.Sonuc.DogumYer;


                        var _medeniHalP = response.Sonuc.MedeniHal;
                        if (_medeniHalP != null)
                        {
                            var code = "99";
                            if (_medeniHalP.ToString().Contains("Bek") == true)
                                code = "1";
                            else if (_medeniHalP.ToString().Contains(TTUtils.CultureService.GetText("M25624", "Evli")) == true)
                                code = "2";
                            else if (_medeniHalP.ToString().Contains(TTUtils.CultureService.GetText("M25548", "Dul")) == true || _medeniHalP.ToString().Contains(TTUtils.CultureService.GetText("M25289", "Boş")) == true || _medeniHalP.ToString().Contains(TTUtils.CultureService.GetText("M25217", "Ayrı")) == true)//Boşanmış/Dul
                                code = "3";

                            BindingList<SKRSMedeniHali> medeniHalList = SKRSMedeniHali.GetSKRSMaritalStatusByCode(_patient.ObjectContext, Convert.ToString(code));

                            if (medeniHalList.Count > 0)
                                _patient.SKRSMaritalStatus = medeniHalList[0];

                        }
                        else
                            _patient.SKRSMaritalStatus = null;// new SKRSCinsiyet(ctx);

                        var _sexP = response.Sonuc.Cinsiyet;
                        BindingList<SKRSCinsiyet> cinsiyetKodlariP = null;
                        if (_sexP != null)
                        {
                            int sexKodu = 1;
                            if (_sexP == TTUtils.CultureService.GetText("M17061", "Kadın"))
                                sexKodu = 2;

                            cinsiyetKodlariP = SKRSCinsiyet.GetSKRSCinsiyetByKodu(_patient.ObjectContext, Convert.ToString(sexKodu));
                            if (cinsiyetKodlariP.Count > 0)
                                _patient.Sex = cinsiyetKodlariP[0];
                            else
                                _patient.Sex = null;
                        }
                        else
                            _patient.Sex = null;
                        //return null;
                    }
                    //else
                    //{
                    Patient.MernisPatientModel mpm = new Patient.MernisPatientModel();
                    mpm.KPSName = response.Sonuc.Ad;
                    mpm.KPSSurname = response.Sonuc.Soyad;
                    mpm.KPSMotherName = response.Sonuc.AnneAd;
                    mpm.KPSFatherName = response.Sonuc.BabaAd;
                    mpm.KPSAlive = true;
                    mpm.KPSForeign = true;
                    mpm.KPsForeignUniqueRefNo = _patient.UniqueRefNo; //UniqueRefNo nulllanabilir
                    mpm.KPSUniqueRefNo = null;
                    var _nationality = response.Sonuc.Ulke;
                    BindingList<SKRSUlkeKodlari> ulkeKodlari = null;
                    if (_nationality != null)
                    {
                        ulkeKodlari = SKRSUlkeKodlari.GetByMernisKodu(ctx, response.Sonuc.UlkeKod);
                        if (ulkeKodlari.Count > 0)
                        {
                            mpm.KPSNationality = ulkeKodlari[0];
                            mpm.KPSNationalityName = ulkeKodlari[0].Adi;
                        }
                        else
                            mpm.KPSNationality = null;
                    }
                    else
                        mpm.KPSNationality = null;

                    string _ot = response.Sonuc.OlumTarihi;
                    if (_ot != "0.0.0")
                    {
                        mpm.KPSExDate = Convert.ToDateTime(_ot);
                        //_patient.Death = true;
                        mpm.KPSAlive = false;
                    }
                    else
                        mpm.KPSAlive = true;

                    mpm.KPSBirthDate = Convert.ToDateTime(response.Sonuc.DogumTarih);
                    mpm.KPSBirthPlace = response.Sonuc.DogumYer;

                    var _medeniHal = response.Sonuc.MedeniHal;
                    if (_medeniHal != null)
                    {
                        var code = "99";
                        if (_medeniHal.ToString().Contains("Bek") == true)
                            code = "1";
                        else if (_medeniHal.ToString().Contains(TTUtils.CultureService.GetText("M25624", "Evli")) == true)
                            code = "2";
                        else if (_medeniHal.ToString().Contains(TTUtils.CultureService.GetText("M25548", "Dul")) == true || _medeniHal.ToString().Contains(TTUtils.CultureService.GetText("M25289", "Boş")) == true || _medeniHal.ToString().Contains(TTUtils.CultureService.GetText("M25217", "Ayrı")) == true)//Boşanmış/Dul
                            code = "3";

                        BindingList<SKRSMedeniHali> medeniHalList = SKRSMedeniHali.GetSKRSMaritalStatusByCode(_patient.ObjectContext, Convert.ToString(code));

                        if (medeniHalList.Count > 0)
                        {
                            mpm.SKRSMaritalStatus = medeniHalList[0];
                            mpm.SKRSMaritalStatusName = medeniHalList[0].ADI;
                        }
                        else
                            mpm.SKRSMaritalStatus = null;

                    }
                    else
                        mpm.SKRSMaritalStatus = null;// new SKRSCinsiyet(ctx);

                    var _sex = response.Sonuc.Cinsiyet;
                    BindingList<SKRSCinsiyet> cinsiyetKodlari = null;
                    if (_sex != null)
                    {
                        int sexKodu = 1;
                        if (_sex == TTUtils.CultureService.GetText("M17061", "Kadın"))
                            sexKodu = 2;

                        cinsiyetKodlari = SKRSCinsiyet.GetSKRSCinsiyetByKodu(_patient.ObjectContext, Convert.ToString(sexKodu));
                        if (cinsiyetKodlari.Count > 0)
                        {
                            mpm.KPSSex = cinsiyetKodlari[0];
                            mpm.KPSSexName = cinsiyetKodlari[0].ADI;
                        }
                        else
                            mpm.KPSSex = null;
                    }
                    else
                        mpm.KPSSex = null;

                    return mpm;
                    //}
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new TTUtils.TTException(ex.Message);
            }
        }
        public static Patient.MernisPatientModel GetTCVatandasiKisiKutukleriFromKPS(KPSV2.TCVatandasiKisiKutukleri _TCVatandas, Patient _patient, bool _newPatient, TTObjectContext ctx)
        {
            if (_TCVatandas.HataBilgisi == null /*&& _TCVatandas.AdresBilgisi != null*/)
            {
                var _adresBilgisi = _TCVatandas.AdresBilgisi;
                //switch (_TCVatandas.AdresBilgisi.AdresTip.Kod)
                //{
                //    case 1:
                //        _adresBilgisi = _TCVatandas.AdresBilgisi.IlIlceMerkezAdresi;
                //        break;
                //    case 2:
                //    default:
                //        break;
                //}
                //_patient.PatientAddress.SKRSBucakKodu.KODU = _adresBilgisi.IlIlceMerkezAdresi.CsbmKodu.HasValue ? _adresBilgisi.IlIlceMerkezAdresi.CsbmKodu.Value.ToString() : null;
                //_patient.PatientAddress.SKRSBucakKodu.ADI = _adresBilgisi.IlIlceMerkezAdresi.Csbm;
                if (_patient.PatientAddress == null)
                    _patient.PatientAddress = new PatientIdentityAndAddress(ctx);
                GetKisiAdresBilgisi(_adresBilgisi, _patient, ctx);
            }

            if (_TCVatandas.HataBilgisi == null)
            {
                _patient.IsTrusted = true;//Mernisten bilgiler alındı
                _patient.KPSUpdateDate = DateTime.Now;
                return FillTCPatientInfoFromKPS(_patient, _TCVatandas, _newPatient, ctx);
            }
            else
                return null;
        }

        public static Patient.MernisPatientModel FillTCPatientInfoFromKPS(Patient _patient, KPSV2.TCVatandasiKisiKutukleri kisiBilgisi, bool _newPatient, TTObjectContext ctx)
        {
            if (_newPatient) //layıtşı oşamyan hasta ise mutlaka mernisten gelsin
            {
                _patient.Name = kisiBilgisi.KisiBilgisi.TemelBilgisi.Ad;
                _patient.Surname = kisiBilgisi.KisiBilgisi.TemelBilgisi.Soyad;
                _patient.MotherName = kisiBilgisi.KisiBilgisi.TemelBilgisi.AnneAd;
                _patient.FatherName = kisiBilgisi.KisiBilgisi.TemelBilgisi.BabaAd;
                _patient.Alive = kisiBilgisi.KisiBilgisi.DurumBilgisi.Durum.Kod == 1 ? true : false;
                KPSV2.TarihBilgisi _ot = kisiBilgisi.KisiBilgisi.DurumBilgisi.OlumTarih;
                if (_ot.Yil != null)
                {
                    _patient.ExDate = new DateTime(_ot.Yil.Value, _ot.Ay.Value, _ot.Gun.Value);
                    _patient.Death = true;
                }
                KPSV2.TarihBilgisi dt = kisiBilgisi.KisiBilgisi.TemelBilgisi.DogumTarih;
                if (dt.Yil != null)
                    _patient.BirthDate = new DateTime(dt.Yil.Value, dt.Ay.Value, dt.Gun.Value);
                _patient.BirthPlace = kisiBilgisi.KisiBilgisi.TemelBilgisi.DogumYer;


                var _sex = kisiBilgisi.KisiBilgisi.TemelBilgisi.Cinsiyet;
                BindingList<SKRSCinsiyet> cinsiyetKodlari = null;
                if (_sex.Kod != null)
                {
                    cinsiyetKodlari = SKRSCinsiyet.GetSKRSCinsiyetByKodu(_patient.ObjectContext, Convert.ToString(_sex.Kod));
                    if (cinsiyetKodlari.Count > 0)
                        _patient.Sex = cinsiyetKodlari[0];
                    else
                        _patient.Sex = null;// new SKRSCinsiyet(ctx);
                }
                else
                    _patient.Sex = null;// new SKRSCinsiyet(ctx);

                BindingList<SKRSUlkeKodlari> ulkeKodlari = null;
                ulkeKodlari = SKRSUlkeKodlari.GetByMernisKodu(ctx, "9980");
                if (ulkeKodlari.Count > 0)
                    _patient.Nationality = ulkeKodlari[0];
                else
                    _patient.Nationality = null;

                return null; //karşılaştırma yağmasına gerek yok
            }
            else
            {
                Patient.MernisPatientModel mpm = new Patient.MernisPatientModel();
                mpm.KPSName = kisiBilgisi.KisiBilgisi.TemelBilgisi.Ad;
                mpm.KPSSurname = kisiBilgisi.KisiBilgisi.TemelBilgisi.Soyad;
                mpm.KPSMotherName = kisiBilgisi.KisiBilgisi.TemelBilgisi.AnneAd;
                mpm.KPSFatherName = kisiBilgisi.KisiBilgisi.TemelBilgisi.BabaAd;
                mpm.KPSAlive = kisiBilgisi.KisiBilgisi.DurumBilgisi.Durum.Kod == 1 ? true : false;
                mpm.KPSUniqueRefNo = _patient.UniqueRefNo;
                mpm.KPSForeign = false;
                mpm.KPsForeignUniqueRefNo = null;
                KPSV2.TarihBilgisi _ot = kisiBilgisi.KisiBilgisi.DurumBilgisi.OlumTarih;
                if (_ot.Yil != null)
                {
                    mpm.KPSExDate = new DateTime(_ot.Yil.Value, _ot.Ay.Value, _ot.Gun.Value);
                    mpm.KPSAlive = false;
                }
                KPSV2.TarihBilgisi dt = kisiBilgisi.KisiBilgisi.TemelBilgisi.DogumTarih;
                if (dt.Yil != null)
                    mpm.KPSBirthDate = new DateTime(dt.Yil.Value, dt.Ay.Value, dt.Gun.Value);

                mpm.KPSBirthPlace = kisiBilgisi.KisiBilgisi.TemelBilgisi.DogumYer;

                var _sex = kisiBilgisi.KisiBilgisi.TemelBilgisi.Cinsiyet;
                BindingList<SKRSCinsiyet> cinsiyetKodlari = null;
                if (_sex.Kod != null)
                {
                    cinsiyetKodlari = SKRSCinsiyet.GetSKRSCinsiyetByKodu(_patient.ObjectContext, Convert.ToString(_sex.Kod));
                    if (cinsiyetKodlari.Count > 0)
                    {
                        mpm.KPSSex = cinsiyetKodlari[0];
                        mpm.KPSSexName = cinsiyetKodlari[0].ADI;
                    }
                    else
                        mpm.KPSSex = null;// new SKRSCinsiyet(ctx);
                }
                else
                    mpm.KPSSex = null;
                BindingList<SKRSUlkeKodlari> ulkeKodlari = null;
                ulkeKodlari = SKRSUlkeKodlari.GetByMernisKodu(ctx, "9980");

                if (ulkeKodlari.Count > 0)
                {
                    mpm.KPSNationality = ulkeKodlari[0];
                    mpm.KPSNationalityName = ulkeKodlari[0].Adi;
                }
                else
                    mpm.KPSNationality = null;

                mpm.HomeAddress = _patient.PatientAddress.HomeAddress;
                return mpm;
            }
        }

        public static Patient.MernisPatientModel GetYabanciKisiKutukleriFromKPS(KPSV2.YabanciKisiKutukleri _YabanciKisi, Patient _patient, bool _newPatient, TTObjectContext ctx)
        {
            if (_YabanciKisi.HataBilgisi == null /*&& _YabanciKisi.AdresBilgisi != null*/)
            {
                var _adresBilgisi = _YabanciKisi.AdresBilgisi;
                if (_patient.PatientAddress == null)
                    _patient.PatientAddress = new PatientIdentityAndAddress(ctx);
                GetKisiAdresBilgisi(_adresBilgisi, _patient, ctx);
            }

            if (_YabanciKisi.HataBilgisi == null)
            {
                _patient.IsTrusted = true;//Mernisten bilgiler alındı
                _patient.KPSUpdateDate = DateTime.Now;
                return FillForeignPatientInfoFromKPS(_patient, _YabanciKisi, _newPatient, ctx);
            }
            else
                return null;
        }

        public static Patient.MernisPatientModel FillForeignPatientInfoFromKPS(Patient _patient, KPSV2.YabanciKisiKutukleri kisiBilgisi, bool _newPatient, TTObjectContext ctx)
        {
            if (_newPatient)
            {
                _patient.Name = kisiBilgisi.KisiBilgisi.TemelBilgisi.Ad;
                _patient.Surname = kisiBilgisi.KisiBilgisi.TemelBilgisi.Soyad;
                _patient.MotherName = kisiBilgisi.KisiBilgisi.TemelBilgisi.AnneAd;
                _patient.FatherName = kisiBilgisi.KisiBilgisi.TemelBilgisi.BabaAd;
                _patient.Alive = true;
                _patient.Foreign = true;
                _patient.UniqueRefNo = kisiBilgisi.KisiBilgisi.KimlikNo; //UniqueRefNo nulllanabilir
                //_patient.UniqueRefNo = null;
                var _nationality = kisiBilgisi.KisiBilgisi.Uyruk;
                BindingList<SKRSUlkeKodlari> ulkeKodlari = null;
                if (_nationality != null)
                {
                    ulkeKodlari = SKRSUlkeKodlari.GetByMernisKodu(ctx, _nationality.Kod.ToString());
                    if (ulkeKodlari.Count > 0)
                        _patient.Nationality = ulkeKodlari[0];
                    else
                        _patient.Nationality = null;
                }
                else
                    _patient.Nationality = null;
                KPSV2.TarihBilgisi _ot = kisiBilgisi.KisiBilgisi.OlumTarih;
                if (_ot.Yil != null)
                {
                    _patient.ExDate = new DateTime(_ot.Yil.Value, _ot.Ay.Value, _ot.Gun.Value);
                    _patient.Alive = false;
                    _patient.Death = true;
                }

                KPSV2.TarihBilgisi dt = kisiBilgisi.KisiBilgisi.DogumTarih;
                if (dt.Yil != null)
                    _patient.BirthDate = new DateTime(dt.Yil.Value, dt.Ay.Value, dt.Gun.Value);
                //_patient.BirthPlace = kisiBilgisi.KisiBilgisi.TemelBilgisi.DogumYer;
                _patient.OtherBirthPlace = kisiBilgisi.KisiBilgisi.TemelBilgisi.DogumYer;

                //TODO: Kodundan değil isminden çek isim geliyor
                //BindingList<SKRSILKodlari> cityofBirthList = SKRSILKodlari.GetSKRSIlKodlariByAdi(_patient.ObjectContext, kisiBilgisi.KisiBilgisi.TemelBilgisi.DogumYer);
                //if (cityofBirthList.Count > 0)
                //    _patient.CityOfBirth = cityofBirthList[0];
                //else
                //    _patient.CityOfBirth = null;
                var _sex = kisiBilgisi.KisiBilgisi.TemelBilgisi.Cinsiyet;
                BindingList<SKRSCinsiyet> cinsiyetKodlari = null;
                if (_sex.Kod != null)
                {
                    cinsiyetKodlari = SKRSCinsiyet.GetSKRSCinsiyetByKodu(_patient.ObjectContext, Convert.ToString(_sex.Kod));
                    if (cinsiyetKodlari.Count > 0)
                        _patient.Sex = cinsiyetKodlari[0];
                    else
                        _patient.Sex = null;// new SKRSCinsiyet(ctx);
                }
                else
                    _patient.Sex = null;// new SKRSCinsiyet(ctx);
                return null;
            }
            else
            {
                Patient.MernisPatientModel mpm = new Patient.MernisPatientModel();
                mpm.KPSName = kisiBilgisi.KisiBilgisi.TemelBilgisi.Ad;
                mpm.KPSSurname = kisiBilgisi.KisiBilgisi.TemelBilgisi.Soyad;
                mpm.KPSMotherName = kisiBilgisi.KisiBilgisi.TemelBilgisi.AnneAd;
                mpm.KPSFatherName = kisiBilgisi.KisiBilgisi.TemelBilgisi.BabaAd;
                mpm.KPSAlive = true;
                mpm.KPSForeign = true;
                mpm.KPsForeignUniqueRefNo = _patient.UniqueRefNo; //UniqueRefNo nulllanabilir
                mpm.KPSUniqueRefNo = _patient.UniqueRefNo;
                var _nationality = kisiBilgisi.KisiBilgisi.Uyruk;
                BindingList<SKRSUlkeKodlari> ulkeKodlari = null;
                if (_nationality != null)
                {
                    ulkeKodlari = SKRSUlkeKodlari.GetByMernisKodu(ctx, _nationality.Kod.ToString());
                    if (ulkeKodlari.Count > 0)
                    {
                        mpm.KPSNationality = ulkeKodlari[0];
                        mpm.KPSNationalityName = ulkeKodlari[0].Adi;
                    }
                    else
                        mpm.KPSNationality = null;
                }
                else
                    mpm.KPSNationality = null;
                KPSV2.TarihBilgisi _ot = kisiBilgisi.KisiBilgisi.OlumTarih;
                if (_ot.Yil != null)
                {
                    mpm.KPSExDate = new DateTime(_ot.Yil.Value, _ot.Ay.Value, _ot.Gun.Value);
                    mpm.KPSAlive = false;
                }

                KPSV2.TarihBilgisi dt = kisiBilgisi.KisiBilgisi.DogumTarih;
                if (dt.Yil != null)
                    mpm.KPSBirthDate = new DateTime(dt.Yil.Value, dt.Ay.Value, dt.Gun.Value);

                mpm.KPSBirthPlace = kisiBilgisi.KisiBilgisi.TemelBilgisi.DogumYer;
                //TODO: Kodundan değil isminden çek isim geliyor
                //BindingList<SKRSILKodlari> cityofBirthList = SKRSILKodlari.GetSKRSIlKodlariByAdi(_patient.ObjectContext, kisiBilgisi.KisiBilgisi.TemelBilgisi.DogumYer);
                //if (cityofBirthList.Count > 0)
                //    mpm.KPSCityOfBirth = cityofBirthList[0];
                //else
                //    mpm.KPSCityOfBirth = null;
                var _sex = kisiBilgisi.KisiBilgisi.TemelBilgisi.Cinsiyet;
                BindingList<SKRSCinsiyet> cinsiyetKodlari = null;
                if (_sex.Kod != null)
                {
                    cinsiyetKodlari = SKRSCinsiyet.GetSKRSCinsiyetByKodu(_patient.ObjectContext, Convert.ToString(_sex.Kod));
                    if (cinsiyetKodlari.Count > 0)
                    {
                        mpm.KPSSex = cinsiyetKodlari[0];
                        mpm.KPSSexName = cinsiyetKodlari[0].ADI;
                    }
                    else
                        mpm.KPSSex = null;// new SKRSCinsiyet(ctx);
                }
                else
                    mpm.KPSSex = null;// new SKRSCinsiyet(ctx);

                mpm.HomeAddress = _patient.PatientAddress.HomeAddress;

                return mpm;
            }
        }

        public static Patient.MernisPatientModel GetMaviKartliKisiKutukleriFromKPS(KPSV2.MaviKartliKisiKutukleri _MaviKisi, Patient _patient, bool _newPatient, TTObjectContext ctx)
        {
            if (_MaviKisi.HataBilgisi == null /*&& _MaviKisi.AdresBilgisi != null*/)
            {
                var _adresBilgisi = _MaviKisi.AdresBilgisi;
                if (_patient.PatientAddress == null)
                    _patient.PatientAddress = new PatientIdentityAndAddress(ctx);
                GetKisiAdresBilgisi(_adresBilgisi, _patient, ctx);
            }

            if (_MaviKisi.HataBilgisi == null)
            {
                _patient.IsTrusted = true;//Mernisten bilgiler alındı
                _patient.KPSUpdateDate = DateTime.Now;
                return FillMaviKartliPatientInfoFromKPS(_patient, _MaviKisi, _newPatient, ctx);
            }
            else
                return null;
        }

        public static Patient.MernisPatientModel FillMaviKartliPatientInfoFromKPS(Patient _patient, KPSV2.MaviKartliKisiKutukleri kisiBilgisi, bool _newPatient, TTObjectContext ctx)
        {
            if (_newPatient)
            {
                _patient.Name = kisiBilgisi.KisiBilgisi.TemelBilgisi.Ad;
                _patient.Surname = kisiBilgisi.KisiBilgisi.TemelBilgisi.Soyad;
                _patient.MotherName = kisiBilgisi.KisiBilgisi.TemelBilgisi.AnneAd;
                _patient.FatherName = kisiBilgisi.KisiBilgisi.TemelBilgisi.BabaAd;
                _patient.Alive = kisiBilgisi.KisiBilgisi.DurumBilgisi.Durum.Kod == 1 ? true : false;
                var _nationality = kisiBilgisi.MaviKartBilgisi.Uyruk;
                BindingList<SKRSUlkeKodlari> ulkeKodlari = null;
                if (_nationality != null)
                {
                    ulkeKodlari = SKRSUlkeKodlari.GetByMernisKodu(ctx, _nationality.Kod.ToString());
                    if (ulkeKodlari.Count > 0)
                        _patient.Nationality = ulkeKodlari[0];
                    else
                        _patient.Nationality = null;
                }
                else
                    _patient.Nationality = null;
                KPSV2.TarihBilgisi _ot = kisiBilgisi.KisiBilgisi.DurumBilgisi.OlumTarih;
                if (_ot.Yil != null)
                    _patient.ExDate = new DateTime(_ot.Yil.Value, _ot.Ay.Value, _ot.Gun.Value);
                KPSV2.TarihBilgisi dt = kisiBilgisi.KisiBilgisi.TemelBilgisi.DogumTarih;
                if (dt.Yil != null)
                    _patient.BirthDate = new DateTime(dt.Yil.Value, dt.Ay.Value, dt.Gun.Value);

                _patient.OtherBirthPlace = kisiBilgisi.KisiBilgisi.TemelBilgisi.DogumYer;


                //TODO: Kodundan değil isminden çek isim geliyor
                //BindingList<SKRSILKodlari> cityofBirthList = SKRSILKodlari.GetSKRSIlKodlariByAdi(_patient.ObjectContext, kisiBilgisi.KisiBilgisi.TemelBilgisi.DogumYer);
                //if (cityofBirthList.Count > 0)
                //    _patient.CityOfBirth = cityofBirthList[0];
                //else
                //    _patient.CityOfBirth = null;
                var _sex = kisiBilgisi.KisiBilgisi.TemelBilgisi.Cinsiyet;
                BindingList<SKRSCinsiyet> cinsiyetKodlari = null;
                if (_sex.Kod != null)
                {
                    cinsiyetKodlari = SKRSCinsiyet.GetSKRSCinsiyetByKodu(_patient.ObjectContext, Convert.ToString(_sex.Kod));
                    if (cinsiyetKodlari.Count > 0)
                        _patient.Sex = cinsiyetKodlari[0];
                    else
                        _patient.Sex = null;// new SKRSCinsiyet(ctx);
                }
                else
                    _patient.Sex = null;// new SKRSCinsiyet(ctx);
                return null;
            }
            else
            {
                Patient.MernisPatientModel mpm = new Patient.MernisPatientModel();
                mpm.KPSName = kisiBilgisi.KisiBilgisi.TemelBilgisi.Ad;
                mpm.KPSSurname = kisiBilgisi.KisiBilgisi.TemelBilgisi.Soyad;
                mpm.KPSMotherName = kisiBilgisi.KisiBilgisi.TemelBilgisi.AnneAd;
                mpm.KPSFatherName = kisiBilgisi.KisiBilgisi.TemelBilgisi.BabaAd;
                mpm.KPSAlive = kisiBilgisi.KisiBilgisi.DurumBilgisi.Durum.Kod == 1 ? true : false;
                mpm.KPSUniqueRefNo = _patient.UniqueRefNo;
                
                var _nationality = kisiBilgisi.MaviKartBilgisi.Uyruk;
                BindingList<SKRSUlkeKodlari> ulkeKodlari = null;
                if (_nationality != null)
                {
                    ulkeKodlari = SKRSUlkeKodlari.GetByMernisKodu(ctx, _nationality.Kod.ToString());
                    if (ulkeKodlari.Count > 0)
                    {
                        mpm.KPSNationality = ulkeKodlari[0];
                        mpm.KPSNationalityName = ulkeKodlari[0].Adi;
                    }
                    else
                        mpm.KPSNationality = null;
                }
                else
                    mpm.KPSNationality = null;

                if (mpm.KPSNationality == null || mpm.KPSNationality.Kodu != "TR")
                {
                    mpm.KPSForeign = true;
                    mpm.KPsForeignUniqueRefNo = _patient.UniqueRefNo;
                }
                else
                {
                    mpm.KPSForeign = false;
                    mpm.KPsForeignUniqueRefNo = null;
                }

                KPSV2.TarihBilgisi _ot = kisiBilgisi.KisiBilgisi.DurumBilgisi.OlumTarih;
                if (_ot.Yil != null)
                {
                    mpm.KPSExDate = new DateTime(_ot.Yil.Value, _ot.Ay.Value, _ot.Gun.Value);
                    mpm.KPSAlive = false;
                }
                KPSV2.TarihBilgisi dt = kisiBilgisi.KisiBilgisi.TemelBilgisi.DogumTarih;
                if (dt.Yil != null)
                    mpm.KPSBirthDate = new DateTime(dt.Yil.Value, dt.Ay.Value, dt.Gun.Value);

                mpm.KPSBirthPlace = kisiBilgisi.KisiBilgisi.TemelBilgisi.DogumYer;

                var _sex = kisiBilgisi.KisiBilgisi.TemelBilgisi.Cinsiyet;
                BindingList<SKRSCinsiyet> cinsiyetKodlari = null;
                if (_sex.Kod != null)
                {
                    cinsiyetKodlari = SKRSCinsiyet.GetSKRSCinsiyetByKodu(_patient.ObjectContext, Convert.ToString(_sex.Kod));
                    if (cinsiyetKodlari.Count > 0)
                    {
                        mpm.KPSSex = cinsiyetKodlari[0];
                        mpm.KPSSexName = cinsiyetKodlari[0].ADI;
                    }
                    else
                        mpm.KPSSex = null;// new SKRSCinsiyet(ctx);
                }
                else
                    mpm.KPSSex = null;// new SKRSCinsiyet(ctx);

                mpm.HomeAddress = _patient.PatientAddress.HomeAddress;
                return mpm;
            }
        }

        public static void GetKisiAdresBilgisi(KPSV2.KisiAdresBilgisi _kisiAdresbilgisi2, Patient _patient, TTObjectContext ctx)
        {
            //TODO ismail: mailden gelecek cevaba göre burası düzenlenecek şu anda üstteki servisten adres gelmiyor ve tekrar çekiyoruz
            KPSV2.KpsServisSonucuKisiAdresBilgisi _kisiAdresbilgisi3 = KPSV2.WebMethods.KimlikNoIleAdresBilgisiSorgulaSync(Sites.SiteLocalHost, Convert.ToInt64(_patient.UniqueRefNo));

            KPSV2.KisiAdresBilgisi _kisiAdresbilgisi = _kisiAdresbilgisi3.Sonuc;
            if (_kisiAdresbilgisi != null)
            {
                _patient.PatientAddress.AddressNo = _kisiAdresbilgisi.AdresNo.HasValue ? _kisiAdresbilgisi.AdresNo.Value.ToString() : null;

                Patient.KPSAdresSonucuTumDegiskenler lokmanAdresSonucu = new Patient.KPSAdresSonucuTumDegiskenler();
                if (_kisiAdresbilgisi.AdresTip != null)
                {
                    switch (_kisiAdresbilgisi.AdresTip.Aciklama)
                    {
                        case "Bilinmiyor":
                            break;
                        case "İl/İlçe Merkezi":
                            lokmanAdresSonucu = getKPSAdresSonucuFromServisResult(_kisiAdresbilgisi.IlIlceMerkezAdresi);
                            break;
                        case "Belediye Adresi":
                            lokmanAdresSonucu = getKPSAdresSonucuFromServisResult(_kisiAdresbilgisi.BeldeAdresi);
                            break;
                        case "Köy Adresi":
                            lokmanAdresSonucu = getKPSAdresSonucuFromServisResult(_kisiAdresbilgisi.KoyAdresi);
                            break;
                        default:
                            break;
                    }
                }

                if (lokmanAdresSonucu != null)
                {
                    _patient.PatientAddress.BuildingBlockName = lokmanAdresSonucu.BinaBlokAdi;
                    _patient.PatientAddress.BuildingCode = lokmanAdresSonucu.BinaKodu.HasValue ? lokmanAdresSonucu.BinaKodu.ToString() : null;
                    _patient.PatientAddress.BuildingNo = lokmanAdresSonucu.BinaNo.HasValue ? lokmanAdresSonucu.BinaNo.ToString() : null;
                    _patient.PatientAddress.BuildingParcel = lokmanAdresSonucu.BinaParsel;
                    _patient.PatientAddress.BuildingSheet = lokmanAdresSonucu.BinaPafta;
                    _patient.PatientAddress.DisKapi = lokmanAdresSonucu.DisKapiNo;
                    _patient.PatientAddress.ForeignAddress = _kisiAdresbilgisi.YurtDisiAdresi != null && _kisiAdresbilgisi.YurtDisiAdresi.YabanciAdres  != null ? _kisiAdresbilgisi.YurtDisiAdresi.YabanciAdres.ToString() : null;
                    _patient.PatientAddress.SiteName = lokmanAdresSonucu.BinaSiteAdi;
                    _patient.PatientAddress.IcKapi = lokmanAdresSonucu.IcKapiNo;
                    _patient.PatientAddress.SKRSAcikAdresIlce = lokmanAdresSonucu.Ilce;
                    //BindingList<SKRSBucakKodlari.GetSKRSBucakKodlari_Class> bucakKodlari = SKRSBucakKodlari.GetSKRSBucakKodlari(_patient.ObjectContext, "SELECT * FROM SKRSBUCAKKODLARI WHERE KODU = '" +_kisiAdresbilgisi.IlIlceMerkezAdresi.CsbmKodu + "'");
                    //if (bucakKodlari.Count > 0)
                    //{
                    //    _patient.PatientAddress.SKRSBucakKodu = new SKRSBucakKodlari();
                    //    _patient.PatientAddress.SKRSBucakKodu.KODU = bucakKodlari[0].KODU;
                    //    _patient.PatientAddress.SKRSBucakKodu.ADI = bucakKodlari[0].ADI;
                    //}
                    //else
                    _patient.PatientAddress.SKRSBucakKodu = null;
                    BindingList<SKRSCSBMTipi> csbmKodlari = null;
                    if (lokmanAdresSonucu.CsbmKodu != null)
                    {
                        csbmKodlari = SKRSCSBMTipi.GetSKRSCSBMTipiByKodu(_patient.ObjectContext, lokmanAdresSonucu.CsbmKodu.Value);
                        if (csbmKodlari.Count > 0)
                            _patient.PatientAddress.SKRSCsbmKodu = csbmKodlari[0];
                        else
                            _patient.PatientAddress.SKRSCsbmKodu = null;
                    }
                    else
                        _patient.PatientAddress.SKRSCsbmKodu = null;
                }
                else
                {
                    _patient.PatientAddress.SKRSCsbmKodu = null;
                }
                BindingList<SKRSKoyKodlari> koyKodlari = null;
                if (_kisiAdresbilgisi.KoyAdresi != null)
                {
                    koyKodlari = SKRSKoyKodlari.GetSKRSKoyKodlariByKodu(_patient.ObjectContext, Convert.ToInt32(_kisiAdresbilgisi.KoyAdresi.KoyKodu));
                    if (koyKodlari.Count > 0)
                        _patient.PatientAddress.SKRSKoyKodlari = koyKodlari[0];
                    else
                        _patient.PatientAddress.SKRSKoyKodlari = null;
                }
                else
                    _patient.PatientAddress.SKRSKoyKodlari = null;
                BindingList<SKRSMahalleKodlari> mahalleKodlari = SKRSMahalleKodlari.GetSKRSMahalleKodlariByKodu(_patient.ObjectContext, Convert.ToInt32(lokmanAdresSonucu.MahalleKodu));
                if (mahalleKodlari.Count > 0)
                    _patient.PatientAddress.SKRSMahalleKodlari = mahalleKodlari[0];
                else
                    _patient.PatientAddress.SKRSMahalleKodlari = null;
                BindingList<SKRSILKodlari> ilKodlariList = SKRSILKodlari.GetSKRSIlKodlariByKodu(_patient.ObjectContext, Convert.ToInt32(lokmanAdresSonucu.IlKodu));
                if (ilKodlariList.Count > 0)
                    _patient.PatientAddress.SKRSILKodlari = ilKodlariList[0];
                else
                    _patient.PatientAddress.SKRSILKodlari = null;
                BindingList<SKRSIlceKodlari> ilceKodlariList = SKRSIlceKodlari.GetSKRSIlceKodlariByKodu(_patient.ObjectContext, Convert.ToInt32(lokmanAdresSonucu.IlceKodu));
                if (ilceKodlariList.Count > 0)
                    _patient.PatientAddress.SKRSIlceKodlari = ilceKodlariList[0];
                else
                    _patient.PatientAddress.SKRSIlceKodlari = null;
                _patient.PatientAddress.SKRSAcikAdresIlce = lokmanAdresSonucu.Ilce;
                var adresKodu = (lokmanAdresSonucu.IcKapiNo != null ? "8" : (lokmanAdresSonucu.Csbm != null ? "6" : (lokmanAdresSonucu.MahalleKodu != null ? "5" : (lokmanAdresSonucu.KoyKodu != null ? "4" : (lokmanAdresSonucu.DisKapiNo != null ? "7" : (""))))));
                _patient.PatientAddress.SKRSAdresKodu = adresKodu;
                BindingList<SKRSAdresKoduSeviyesi> adreskoduSeviyesiList = SKRSAdresKoduSeviyesi.GetSKRSAdresKoduSByKodu(_patient.ObjectContext, adresKodu);
                if (adreskoduSeviyesiList.Count > 0)
                    _patient.PatientAddress.SKRSAdresKoduSeviyesi = adreskoduSeviyesiList[0];
                else
                    _patient.PatientAddress.SKRSAdresKoduSeviyesi = null;
                var acikAdres = "";
                if (_kisiAdresbilgisi.YurtDisiAdresi != null && !string.IsNullOrEmpty(_kisiAdresbilgisi.YurtDisiAdresi.YabanciAdres))
                {
                    acikAdres = _kisiAdresbilgisi.YurtDisiAdresi.YabanciAdres;
                }
                else
                {
                    acikAdres = _kisiAdresbilgisi.AcikAdres;
                    //acikAdres = response.Sonuc.Mahalle + " " + response.Sonuc.BinaSiteAdi + " " + response.Sonuc.BinaBlokAdi + " " + response.Sonuc.Csbm + " Dış Kapı no : "
                    //    + response.Sonuc.DisKapiNo + " İç Kapı no : " + response.Sonuc.IcKapiNo + " " + response.Sonuc.Ilce + " " + response.Sonuc.Il;
                    //var sKRSUlkeKodlariList = SKRSUlkeKodlari.GetByMernisKodu(_patient.ObjectContext, "9980");
                    //if (sKRSUlkeKodlariList.Count > 0)
                    //{
                    //    _patient.Nationality = sKRSUlkeKodlariList[0];
                    //}
                }

                _patient.PatientAddress.HomeAddress = acikAdres;
                if (lokmanAdresSonucu.IlceKodu.HasValue)
                {
                    ilceKodlariList = SKRSIlceKodlari.GetSKRSIlceKodlariByKodu(_patient.ObjectContext, Convert.ToInt32(lokmanAdresSonucu.IlceKodu));
                    if (ilceKodlariList.Count == 1)
                    {
                        //_patient.PatientAddress.HomeTown = ilceKodlariList[0]; 
                        if (lokmanAdresSonucu.IlKodu.HasValue)
                        {
                            //IBindingList homeCity = _patient.ObjectContext.QueryObjects(typeof (City).Name, "MERNISCODE = " + lokmanAdresSonucu.IlKodu);
                            IBindingList homeCity = _patient.ObjectContext.QueryObjects(typeof(City).Name, "CODE = " + lokmanAdresSonucu.IlKodu);
                            if (homeCity.Count == 1)
                                _patient.PatientAddress.HomeCity = (City)homeCity[0];
                            else if (homeCity.Count == 0)
                                TTUtils.InfoMessageService.Instance.ShowMessage("Bu MERNİS koduna sahip bir şehir tanımı bulunamadı.\r\n" + lokmanAdresSonucu.IlKodu);
                            else
                                TTUtils.InfoMessageService.Instance.ShowMessage("Bu MERNİS koduna sahip mükerrer şehir tanımları bulundu.\r\n" + lokmanAdresSonucu.IlKodu);
                        }
                    }
                    else if (ilceKodlariList.Count == 0)
                        TTUtils.InfoMessageService.Instance.ShowMessage("Bu MERNİS koduna sahip bir ilçe tanımı bulunamadı.\r\n" + lokmanAdresSonucu.IlceKodu);
                    else
                        TTUtils.InfoMessageService.Instance.ShowMessage("Bu MERNİS koduna sahip mükerrer ilçe tanımları bulundu.\r\n" + lokmanAdresSonucu.IlceKodu);
                }
            }
        }

        private static Patient.KPSAdresSonucuTumDegiskenler getKPSAdresSonucuFromServisResult(object adresObj)
        {
            Patient.KPSAdresSonucuTumDegiskenler lokmanAdresSonucu = new Patient.KPSAdresSonucuTumDegiskenler();
            foreach (PropertyInfo item in adresObj.GetType().GetProperties())
            {
                foreach (PropertyInfo innerItem in lokmanAdresSonucu.GetType().GetProperties())
                {
                    if (item.Name.Equals(innerItem.Name))
                    {
                        if (item.PropertyType.Name == typeof(KPSV2.Parametre).Name)
                            innerItem.SetValue(lokmanAdresSonucu, (KPSV2.Parametre)item.GetValue(adresObj, null));
                        else
                            innerItem.SetValue(lokmanAdresSonucu, item.GetValue(adresObj, null));
                    }
                }
            }
            return lokmanAdresSonucu;
        }

        public static PatientIdentityAndAddress GetKisiAdresBilgisi_OLD(Patient _patient, TTObjectContext ctx)
        {
            //TODO ismail: mailden gelecek cevaba göre burası düzenlenecek şu anda üstteki servisten adres gelmiyor ve tekrar çekiyoruz
            KPSServis.KPSServisSonucuKisiAdresBilgisi _kisiAdresbilgisi = KPSServis.WebMethods.TcKimlikNoIleAdresBilgisiSorgulaSync(Sites.SiteLocalHost, Convert.ToInt64(_patient.UniqueRefNo.Value));

            if (_kisiAdresbilgisi != null)
            {
                _patient.PatientAddress.AddressNo = _kisiAdresbilgisi.Sonuc.AdresNo.HasValue ? _kisiAdresbilgisi.Sonuc.AdresNo.Value.ToString() : null;
                _patient.PatientAddress.BuildingBlockName = _kisiAdresbilgisi.Sonuc.BinaBlokAdi;
                _patient.PatientAddress.BuildingCode = _kisiAdresbilgisi.Sonuc.BinaKodu != null ? _kisiAdresbilgisi.Sonuc.BinaKodu.ToString() : null;
                _patient.PatientAddress.BuildingNo = _kisiAdresbilgisi.Sonuc.BinaNo != null ? _kisiAdresbilgisi.Sonuc.BinaNo.ToString() : null;
                _patient.PatientAddress.BuildingParcel = _kisiAdresbilgisi.Sonuc.BinaParsel;
                _patient.PatientAddress.BuildingSheet = _kisiAdresbilgisi.Sonuc.BinaPafta;
                _patient.PatientAddress.DisKapi = _kisiAdresbilgisi.Sonuc.DisKapiNo;
                _patient.PatientAddress.ForeignAddress = _kisiAdresbilgisi.Sonuc.YabanciAdres != null ? _kisiAdresbilgisi.Sonuc.YabanciAdres.ToString() : null;
                _patient.PatientAddress.SiteName = _kisiAdresbilgisi.Sonuc.BinaSiteAdi;
                _patient.PatientAddress.IcKapi = _kisiAdresbilgisi.Sonuc.IcKapiNo;
                _patient.PatientAddress.SKRSAcikAdresIlce = _kisiAdresbilgisi.Sonuc.Ilce;

                _patient.PatientAddress.SKRSBucakKodu = null;
                BindingList<SKRSCSBMTipi> csbmKodlari = null;
                if (_kisiAdresbilgisi.Sonuc.CsbmKodu != null)
                {
                    csbmKodlari = SKRSCSBMTipi.GetSKRSCSBMTipiByKodu(_patient.ObjectContext, Convert.ToInt32(_kisiAdresbilgisi.Sonuc.CsbmKodu));
                    if (csbmKodlari.Count > 0)
                        _patient.PatientAddress.SKRSCsbmKodu = csbmKodlari[0];
                    else
                        _patient.PatientAddress.SKRSCsbmKodu = null;
                }
                else
                    _patient.PatientAddress.SKRSCsbmKodu = null;
                BindingList<SKRSKoyKodlari> koyKodlari = null;
                if (_kisiAdresbilgisi.Sonuc.KoyKodu != null)
                {
                    koyKodlari = SKRSKoyKodlari.GetSKRSKoyKodlariByKodu(_patient.ObjectContext, Convert.ToInt32(_kisiAdresbilgisi.Sonuc.KoyKodu));
                    if (koyKodlari.Count > 0)
                        _patient.PatientAddress.SKRSKoyKodlari = koyKodlari[0];
                    else
                        _patient.PatientAddress.SKRSKoyKodlari = null;
                }
                else
                    _patient.PatientAddress.SKRSKoyKodlari = null;
                BindingList<SKRSMahalleKodlari> mahalleKodlari = SKRSMahalleKodlari.GetSKRSMahalleKodlariByKodu(_patient.ObjectContext, Convert.ToInt32(_kisiAdresbilgisi.Sonuc.MahalleKodu));
                if (mahalleKodlari.Count > 0)
                    _patient.PatientAddress.SKRSMahalleKodlari = mahalleKodlari[0];
                else
                    _patient.PatientAddress.SKRSMahalleKodlari = null;
                BindingList<SKRSILKodlari> ilKodlariList = SKRSILKodlari.GetSKRSIlKodlariByKodu(_patient.ObjectContext, Convert.ToInt32(_kisiAdresbilgisi.Sonuc.IlKodu));
                if (ilKodlariList.Count > 0)
                    _patient.PatientAddress.SKRSILKodlari = ilKodlariList[0];
                else
                    _patient.PatientAddress.SKRSILKodlari = null;
                BindingList<SKRSIlceKodlari> ilceKodlariList = SKRSIlceKodlari.GetSKRSIlceKodlariByKodu(_patient.ObjectContext, Convert.ToInt32(_kisiAdresbilgisi.Sonuc.IlceKodu));
                if (ilceKodlariList.Count > 0)
                    _patient.PatientAddress.SKRSIlceKodlari = ilceKodlariList[0];
                else
                    _patient.PatientAddress.SKRSIlceKodlari = null;
                _patient.PatientAddress.SKRSAcikAdresIlce = _kisiAdresbilgisi.Sonuc.Ilce;
                var adresKodu = (_kisiAdresbilgisi.Sonuc.IcKapiNo != null ? "8" : (_kisiAdresbilgisi.Sonuc.Csbm != null ? "6" : (_kisiAdresbilgisi.Sonuc.MahalleKodu != null ? "5" : (_kisiAdresbilgisi.Sonuc.KoyKodu != null ? "4" : (_kisiAdresbilgisi.Sonuc.DisKapiNo != null ? "7" : (""))))));
                _patient.PatientAddress.SKRSAdresKodu = adresKodu;
                BindingList<SKRSAdresKoduSeviyesi> adreskoduSeviyesiList = SKRSAdresKoduSeviyesi.GetSKRSAdresKoduSByKodu(_patient.ObjectContext, adresKodu);
                if (adreskoduSeviyesiList.Count > 0)
                    _patient.PatientAddress.SKRSAdresKoduSeviyesi = adreskoduSeviyesiList[0];
                else
                    _patient.PatientAddress.SKRSAdresKoduSeviyesi = null;

                var acikAdres = _kisiAdresbilgisi.Sonuc.BinaBlokAdi + " " + _kisiAdresbilgisi.Sonuc.DisKapiNo + " " + _kisiAdresbilgisi.Sonuc.IcKapiNo + " " + _kisiAdresbilgisi.Sonuc.Csbm + " " + _kisiAdresbilgisi.Sonuc.Mahalle + " " + _kisiAdresbilgisi.Sonuc.Ilce + " " + _kisiAdresbilgisi.Sonuc.Il;

                if (!string.IsNullOrEmpty(_kisiAdresbilgisi.Sonuc.YabanciAdres))
                {
                    acikAdres = _kisiAdresbilgisi.Sonuc.YabanciAdres;
                }

                _patient.PatientAddress.HomeAddress = acikAdres;

                if (_kisiAdresbilgisi.Sonuc.IlceKodu != null)
                {
                    ilceKodlariList = SKRSIlceKodlari.GetSKRSIlceKodlariByKodu(_patient.ObjectContext, Convert.ToInt32(_kisiAdresbilgisi.Sonuc.IlceKodu));
                    if (ilceKodlariList.Count == 1)
                    {
                        //_patient.PatientAddress.HomeTown = ilceKodlariList[0]; 
                        if (_kisiAdresbilgisi.Sonuc.IlKodu != null)
                        {
                            //IBindingList homeCity = _patient.ObjectContext.QueryObjects(typeof (City).Name, "MERNISCODE = " + _kisiAdresbilgisi.IlIlceMerkezAdresi.IlKodu);
                            IBindingList homeCity = _patient.ObjectContext.QueryObjects(typeof(City).Name, "CODE = " + _kisiAdresbilgisi.Sonuc.IlKodu);
                            if (homeCity.Count == 1)
                                _patient.PatientAddress.HomeCity = (City)homeCity[0];
                            else if (homeCity.Count == 0)
                                TTUtils.InfoMessageService.Instance.ShowMessage("Bu MERNİS koduna sahip bir şehir tanımı bulunamadı.\r\n" + _kisiAdresbilgisi.Sonuc.IlKodu);
                            else
                                TTUtils.InfoMessageService.Instance.ShowMessage("Bu MERNİS koduna sahip mükerrer şehir tanımları bulundu.\r\n" + _kisiAdresbilgisi.Sonuc.IlKodu);
                        }
                    }
                    else if (ilceKodlariList.Count == 0)
                        TTUtils.InfoMessageService.Instance.ShowMessage("Bu MERNİS koduna sahip bir ilçe tanımı bulunamadı.\r\n" + _kisiAdresbilgisi.Sonuc.IlceKodu);
                    else
                        TTUtils.InfoMessageService.Instance.ShowMessage("Bu MERNİS koduna sahip mükerrer ilçe tanımları bulundu.\r\n" + _kisiAdresbilgisi.Sonuc.IlceKodu);
                }
            }
            return _patient.PatientAddress;
        }

        public static Patient.MernisPatientModel FillTCPatientInfoFromKPS_Temp(Patient _patient, TTObjectContext ctx)
        {
            Patient.MernisPatientModel mpm = new Patient.MernisPatientModel();
            mpm.KPSName = "ismail";
            mpm.KPSSurname = "tatlı";
            mpm.KPSMotherName = "hacer";
            mpm.KPSFatherName = "süleyman hilmi";
            mpm.KPSAlive = true;
            mpm.KPSUniqueRefNo = 10000000000;
            mpm.KPSForeign = false;
            mpm.KPsForeignUniqueRefNo = null;
            mpm.KPSBirthDate = new DateTime(1984, 09, 16);
            mpm.KPSBirthPlace = "";

            BindingList<SKRSCinsiyet> cinsiyetKodlari = null;
            cinsiyetKodlari = SKRSCinsiyet.GetSKRSCinsiyetByKodu(_patient.ObjectContext, Convert.ToString(1));
            if (cinsiyetKodlari.Count > 0)
            {
                mpm.KPSSex = cinsiyetKodlari[0];
                mpm.KPSSexName = cinsiyetKodlari[0].ADI;
            }
            else
                mpm.KPSSex = null;
            BindingList<SKRSUlkeKodlari> ulkeKodlari = null;
            ulkeKodlari = SKRSUlkeKodlari.GetByMernisKodu(ctx, "9980");
            if (ulkeKodlari.Count > 0)
            {
                mpm.KPSNationality = ulkeKodlari[0];
                mpm.KPSNationalityName = ulkeKodlari[0].Adi;
            }
            else
                mpm.KPSNationality = null;
            mpm.KPSExDate = null;

            _patient.IsTrusted = true;
            _patient.KPSUpdateDate = DateTime.Now;
            return mpm;
            //(Patient)objectContext.AddObject(p)
        }

        #endregion

        public static BindingList<SKRSUlkeKodlari> SetDefaultNationality()
        {
            return SKRSUlkeKodlari.GetByMernisKodu(new TTObjectContext(true), "9980");
        }

        public static Patient SavePatient(Patient p)
        {
            RequirementResultCode requirementResultCode = ControlRequiredProperties(p);
            if (requirementResultCode.resultCode > 0)
                throw new TTUtils.TTException(requirementResultCode.resultMessage);

            if (p.PassportNo == null && p.Nationality.Kodu != "TR" && p.UniqueRefNo == null)
            {
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26684", "Pasaport No alanı boş bırakılamaz."));
            }
            if (p.Nationality.Kodu != "TR" && p.SKRSYabanciHasta == null)
            {
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27201", "Yabancı Hasta Türü alanı boş bırakılamaz."));
            }
            if (p.BeneficiaryName != null && (p.BeneficiaryUniqueRefNo == null || p.BeneficiaryUniqueRefNo == 0))
            {
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25765", "Hak sahibi kimlik numarası bilgisi giriniz."));
            }
            else if (p.BeneficiaryName == null && p.BeneficiaryUniqueRefNo != null && p.BeneficiaryUniqueRefNo != 0)
            {
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25764", "Hak sahibi ad bilgisi giriniz."));
            }

            return p;
        }
        public static Patient SetPrivacyInfo(Patient p)
        {
            if (p.HasMemberChanged("PRIVACY"))
            {
                if (p.Privacy == true)
                {

                    p.UniqueRefNo = null;

                    p.PatientAddress.HomeAddress = "*************";
                    p.PatientAddress.MobilePhone = "*************";

                }
                else
                {
                    //New modda ve gizli hasta işaretli değilse alttaki kodun calışması gerekmiyor
                    if (!(((ITTObject)p).IsNew))
                    {
                        var oldPrivacyNameValue = ((TTObjectClasses.Patient)((((TTInstanceManagement.ITTObject)p).Original))).PrivacyName;
                        var oldPrivacySurnameValue = ((TTObjectClasses.Patient)((((TTInstanceManagement.ITTObject)p).Original))).PrivacySurname;

                        p.Name = oldPrivacyNameValue;
                        p.Surname = oldPrivacySurnameValue;
                        p.UniqueRefNo = p.PrivacyUniqueRefNo;
                        p.PatientAddress.HomeAddress = p.PrivacyHomeAddress;
                        p.PatientAddress.MobilePhone = p.PrivacyMobilePhone;

                        p.PrivacyName = null;
                        p.PrivacySurname = null;
                        p.PrivacyUniqueRefNo = null;
                        p.PrivacyHomeAddress = null;
                        p.PrivacyMobilePhone = null;
                        p.PrivacyReason = null;
                    }
                }
            }

            return p;
        }
        private static RequirementResultCode ControlRequiredProperties(Patient p)
        {

            RequirementResultCode requirementResultCode = new RequirementResultCode();
            RequirementExecutor reqExecutor = new RequirementExecutor();


            PatientInfoRequirements patientInfoRequirements = new PatientInfoRequirements(p);
            reqExecutor.addRequirement(patientInfoRequirements);

            if (p.UnIdentified != true)
            {
                PatientAddressRequirements patientAddressRequirements = new PatientAddressRequirements(p.PatientAddress);
                reqExecutor.addRequirement(patientAddressRequirements);
            }

            requirementResultCode = reqExecutor.Execute();
            reqExecutor.clearAllRequirements();

            return requirementResultCode;
        }

        public MedulaYardimciIslemler.takipAraCevapDVO ReadExtraProvision(string ilkTarih, string sonTarih)
        {
            MedulaYardimciIslemler.takipAraGirisDVO takipAraGirisDVO = new MedulaYardimciIslemler.takipAraGirisDVO();
            takipAraGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
            takipAraGirisDVO.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();
            takipAraGirisDVO.baslangicTarihi = ilkTarih;
            takipAraGirisDVO.bitisTarihi = sonTarih;
            takipAraGirisDVO.hastaTCK = UniqueRefNo.HasValue ? UniqueRefNo.Value.ToString() : "";
            takipAraGirisDVO.sevkDurumu = "H";

            MedulaYardimciIslemler.takipAraCevapDVO takipAraCevapDVO = MedulaYardimciIslemler.WebMethods.takipAraSync(TTObjectClasses.Sites.SiteLocalHost, takipAraGirisDVO);

            return takipAraCevapDVO;
        }
        #endregion Methods

        private class KPSAdresSonucuTumDegiskenler
        {
            public KPSV2.Parametre BagimsizBolumDurum { get; set; }
            public KPSV2.Parametre BagimsizBolumTipi { get; set; }
            public string BinaAda { get; set; }
            public string BinaBlokAdi { get; set; }
            public KPSV2.Parametre BinaDurum { get; set; }
            public System.Nullable<long> BinaKodu { get; set; }
            public System.Nullable<int> BinaNo { get; set; }
            public KPSV2.Parametre BinaNumaratajTipi { get; set; }
            public string BinaPafta { get; set; }
            public string BinaParsel { get; set; }
            public string BinaSiteAdi { get; set; }
            public KPSV2.Parametre BinaYapiTipi { get; set; }
            public string Csbm { get; set; }
            public System.Nullable<int> CsbmKodu { get; set; }
            public string DisKapiNo { get; set; }
            public KPSV2.Parametre HataBilgisi { get; set; }
            public string IcKapiNo { get; set; }
            public string Il { get; set; }
            public System.Nullable<int> IlKodu { get; set; }
            public string Ilce { get; set; }
            public System.Nullable<int> IlceKodu { get; set; }
            public string KatNo { get; set; }
            public string Koy { get; set; }
            public System.Nullable<long> KoyKayitNo { get; set; }
            public System.Nullable<long> KoyKodu { get; set; }
            public string Mahalle { get; set; }
            public System.Nullable<int> MahalleKodu { get; set; }
            public string TapuBagimsizBolumNo { get; set; }
            public KPSV2.Parametre YapiKullanimAmac { get; set; }
            public System.Nullable<int> YolAltiKatSayisi { get; set; }
            public System.Nullable<int> YolUstuKatSayisi { get; set; }

        }

        private class Parametre
        {
            private string AciklamaField;
            private System.Nullable<int> KodField;
            public string Aciklama
            {
                get { return AciklamaField; }
                set { AciklamaField = value; }
            }
            public System.Nullable<int> Kod
            {
                get { return KodField; }
                set { KodField = value; }
            }
        }

        public PatientMedulaHastaKabul.ChildPatientMedulaHastaKabulCollection GetPatientMedulaHastaKabulleri()
        {
            return PatientMedulaHastaKabulleri;
        }

        public SKRSCinsiyet GetSex()
        {
            return Sex;
        }

        public int? GetAge()
        {
            return Age;
        }
    }
}
