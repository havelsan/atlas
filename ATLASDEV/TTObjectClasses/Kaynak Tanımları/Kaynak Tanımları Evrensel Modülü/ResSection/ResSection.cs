
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
    /// Birim
    /// </summary>
    public  partial class ResSection : Resource
    {
        public partial class ConsultationRequestResourceListNql_Class : TTReportNqlObject 
        {
        }

        public partial class EnableResSectionListNQL_Class : TTReportNqlObject 
        {
        }

        public partial class PoliclinicClinicDepartmentListNQL_Class : TTReportNqlObject 
        {
        }

        public partial class SendToResourceListNQL_Class : TTReportNqlObject 
        {
        }

        public partial class PoliclinicClinicListNQL_Class : TTReportNqlObject 
        {
        }

        public partial class PoliclinicClinicTreatmentUnitListNQL_Class : TTReportNqlObject 
        {
        }

        public partial class PolClinTreatLabUnitListNql_Class : TTReportNqlObject 
        {
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
            base.PostInsert();

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
#endregion PostUpdate
        }

#region Methods
        //        public void CheckResourceSpecialities(){
        //            if(this.EnabledType!=ResourceEnableType.UnEnable){
        //                if(this.ResourceSpecialities.Count<1){
        //                    throw new TTException("En az bir adet 'Kullanıldığı Uzmanlık Dalı' seçilmesi zorunludur");
        //                }
        //            }
        //        }

        public bool IsBaseOfInheritedObject(TTObjectDef inheritedObjectDef, TTObjectDef baseObjectDef)
        {
            if (inheritedObjectDef.ID == baseObjectDef.ID)
                return true;
            if (inheritedObjectDef.BaseObjectDef == null)
                return false;
            return IsBaseOfInheritedObject((TTObjectDef)inheritedObjectDef.BaseObjectDef, baseObjectDef);
        }
        
        public void SetActionCancelledTimeToChildResSections(int? actionCancelledTime)
        {
            ActionCancelledTime=actionCancelledTime;
            foreach (TTObjectRelationDef relationDef in ObjectDef.AllChildRelationDefs)
            {
                if (relationDef.ChildObjectDef != null && IsBaseOfInheritedObject(relationDef.ChildObjectDef, TTDefinitionManagement.TTObjectDefManager.Instance.ObjectDefs["RESSECTION"]))
                {
                    foreach (ResSection childRessection in GetChildren(relationDef))
                    {
                        childRessection.SetActionCancelledTimeToChildResSections(actionCancelledTime);
                    }
                }
            }
        }

        public int GetQuatoOfMonth(DateTime? newAdmissionDate)
        {
            DateTime newQuotaDate = Convert.ToDateTime(newAdmissionDate);
            switch (newQuotaDate.Month)
            {
                case 1:
                    return (int)(JanuaryQuota == null ? 0 : JanuaryQuota);
                case 2:
                    return (int)(FebruaryQuota == null ? 0 : FebruaryQuota);
                case 3:
                    return (int)(MarchQuota == null ? 0 : MarchQuota);
                case 4:
                    return (int)(AprilQuota == null ? 0 : AprilQuota);
                case 5:
                    return (int)(MayQuota == null ? 0 : MayQuota);
                case 6:
                    return (int)(JuneQuata == null ? 0 : JuneQuata);
                case 7:
                    return (int)(JulyQuota == null ? 0 : JulyQuota);
                case 8:
                    return (int)(AugustQuota == null ? 0 : AugustQuota);
                case 9:
                    return (int)(SeptemberQuota == null ? 0 : SeptemberQuota);
                case 10:
                    return (int)(OctoberQuota == null ? 0 : OctoberQuota);
                case 11:
                    return (int)(NovemberQuota == null ? 0 : NovemberQuota);
                case 12:
                    return (int)(DecemberQuota == null ? 0 : DecemberQuota);
                default:
                    return 0;
            }
        }
        private int GetRemainingWorkDayCountOfMonth(DateTime date)
        {
            int dayCount=0;
            int mount = date.Month;
            while (mount == date.Month)
            {
                if(date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    dayCount++;
                date=date.AddDays(1);
            }
            return dayCount;
        }
        /// Önceki günlerden hasta aktarımların olmadığı var sayılarak kalan günlük Kota
        public int GetRemainingStaticDailyQuota(DateTime date)
        {
            BindingList<TTObjectClasses.QuotaHistory> quotaHistoryList = QuotaHistory.GetByDateOfQuota(ObjectContext, date, this);
            int femainingQuotaCount=GetStaticDailyQuota(date)-quotaHistoryList.Count;
            if(femainingQuotaCount<0)
                femainingQuotaCount=0;
            return femainingQuotaCount;
        }
        
        /// Önceki günlerden hasta aktarımların olmadığı var sayılarak belirlenen Günlük Kota
        private int GetStaticDailyQuota(DateTime date)
        {
            int dailyQuota=0;
            date=Convert.ToDateTime("01."+ date.Month + "." + date.Year);
            int? monthlyQuota = GetQuatoOfMonth(date);// Böylece Kontenjan atırılırsa hemen yansıyacak.Bu kod olmazsa yanlızca ay dönümlerinde aylık kontenjan güncellenir.
            if (monthlyQuota == null || monthlyQuota == 0)
            {
                return 0;
            }
            int workDayCountOfMonth = GetRemainingWorkDayCountOfMonth(date);
            dailyQuota = (int)((double)monthlyQuota / workDayCountOfMonth);// Aşağıya yuvarlar
            return dailyQuota;
        }

        private QuotaHistory CreateQuotaHistory(PatientAdmission patientAdmission)
        {
            QuotaHistory quotaHistory=null;
            if(patientAdmission!=null)// Kabul sırasında çalıştırılmış
            {
                if (patientAdmission.AdmissionAppointment != null)// Daha önce randevu alınmış bir
                {
                    BindingList<TTObjectClasses.QuotaHistory> quotaHistorybyAdmissionApp = QuotaHistory.GetByAdmissionAppointment(ObjectContext, patientAdmission.AdmissionAppointment.ObjectID);
                    if (quotaHistorybyAdmissionApp.Count > 0)
                    {
                        quotaHistory = quotaHistorybyAdmissionApp[0];
                        quotaHistory.PatientAdmission = patientAdmission;
                    }
                }
                if (quotaHistory == null)// Daha önce randevusu olmayan
                {
                    quotaHistory = new QuotaHistory(ObjectContext);
                    quotaHistory.Patient = patientAdmission.Episode.Patient;
                    quotaHistory.PatientAdmission = patientAdmission;
                    quotaHistory.DateOfQuota = Common.RecTime();
                }
                quotaHistory.ResSectionOfQuota = this;
            }
            return quotaHistory;
        }

        private QuotaHistory CreateQuotaHistory(AdmissionAppointment admissionAppointment)
        {
            QuotaHistory quotaHistory = null;
            if (admissionAppointment != null)// Kabul sırasında çalıştırılmış
            {
                quotaHistory = new QuotaHistory(ObjectContext);
                quotaHistory.Patient = admissionAppointment.SelectedPatient;
                quotaHistory.AdmissionAppointment = admissionAppointment;
                quotaHistory.ResSectionOfQuota = this;
                quotaHistory.DateOfQuota = admissionAppointment.WorkListDate;
            }
            return quotaHistory;
        }
        
        private QuotaHistory CreateQuotaHistory(EpisodeAction episodeAction)
        {
            QuotaHistory quotaHistory=null;
            if(episodeAction != null)// Hasta yatış sırasında kullanılan kota
            {
                BindingList<TTObjectClasses.QuotaHistory> quotaHistorybyEpisodeAndResSection = QuotaHistory.GetByEpisodeAndResSection(ObjectContext, episodeAction.Episode.ObjectID,ObjectID);
                if (quotaHistorybyEpisodeAndResSection.Count > 0)
                {
                    quotaHistory = quotaHistorybyEpisodeAndResSection[0];
                    quotaHistory.EpisodeAction = episodeAction;
                }
                
                if (quotaHistory == null)// Daha önce randevusu olmayan
                {
                    quotaHistory = new QuotaHistory(ObjectContext);
                    quotaHistory.Patient = episodeAction.Episode.Patient;
                    quotaHistory.EpisodeAction = episodeAction;
                    quotaHistory.DateOfQuota = Common.RecTime();
                }
                quotaHistory.ResSectionOfQuota = this;
            }
            return quotaHistory;
        }

        public int GetRemainingDailyQuota()
        {
            return GetRemainingDailyQuota(false,null,null);
        }
        // Kafa randevularında kotadan düşmek için
        public void DecreaseRemainingDailyQuota(AdmissionAppointment admissionAppointment)
        {
            //if (admissionAppointment.SelectedPatient != null)// randevu verilen hasta belirli ise
            if(this is ResPoliclinic)
            {
                if(admissionAppointment.NotRequiredQuota.HasValue == false ||(admissionAppointment.NotRequiredQuota.HasValue == true && admissionAppointment.NotRequiredQuota.Value == false))
                {
                    //if (admissionAppointment.SelectedPatient.PatientGroup == null || admissionAppointment.SelectedPatient.IsRequiredQuota(admissionAppointment.SelectedPatient.PatientGroup.Value)==true)// randevu verilen hastanın son hasta kabulünde Require ise
                    if(admissionAppointment.IsQuotaUsedInTenDays() == false) //10 gün içinde aynı birimden kota kullanmadıysa
                        GetRemainingDailyQuota(true, null, admissionAppointment);
                }
            }
        }
        // Hasta Kasbullerde Kotadan düşmek için
        public void DecreaseRemainingDailyQuota(PatientAdmission patientAdmission)
        {
            if(this is ResPoliclinic)
            {
                if (patientAdmission.RequiredQuota == true)
                    GetRemainingDailyQuota(true, patientAdmission, null);
            }
            
        }
        
        // Hasta Yatışta Kotadan düşmek için
        public void DecreaseRemainingInpatientQuota(EpisodeAction episodeAction)
        {
            if(TTObjectClasses.SystemParameter.GetParameterValue("IGNOREINPATIENTQUOTACONTROL","TRUE") != "TRUE")
            {
                if(IgnoreQuotaControl != true)
                    if (episodeAction != null && episodeAction.SubEpisode.PatientAdmission.RequiredQuota == true)
                    GetRemainingInpatientQuota(true, episodeAction);
            }
        }

        //hastanın klinikten nakili veya taburcusu durumunda kotayı arttırır ama history den silmez. aynı kliniğe nakilde kontrol etmek için kota history XXXXXXden taburcu olana kadar silinmez.
        public void IncreaseInpatientQuota(EpisodeAction episodeAction)
        {
            if (TTObjectClasses.SystemParameter.GetParameterValue("IGNOREINPATIENTQUOTACONTROL", "TRUE") != "TRUE")
            {
                if (IgnoreQuotaControl != true)
                {
                    if (episodeAction != null && episodeAction.SubEpisode.PatientAdmission.RequiredQuota == true)
                    {
                        BindingList<TTObjectClasses.QuotaHistory> quotaHistorybyEpisodeAndResSection = QuotaHistory.GetByEpisodeAndResSection(ObjectContext, episodeAction.Episode.ObjectID, ObjectID);
                        if (quotaHistorybyEpisodeAndResSection.Count > 0)
                            InpatientQuota++;
                    }
                }
            }
        }

        ///Günlük Kalan kota Aynı güne randevu verilirken kullanılacak ileri tarihli randevular için Kullanılmaz.
        private int GetRemainingDailyQuota(bool decreaseQuota,PatientAdmission patientAdmission,AdmissionAppointment admissionAppointment)
        {
            TTObjectContext roContext = new TTObjectContext(true);
            bool isDailyQuotaStatic= (TTObjectClasses.SystemParameter.GetParameterValue("IsDailyQuotaStatic", "TRUE")=="TRUE");
            int dailyQuota = 0;
            int? monthlyQuota =null;
            DateTime date = Common.RecTime();
            DateTime firstDateOfMonth=Convert.ToDateTime("01."+ date.Month + "." + date.Year);

            DateTime lastQuotaDate=Convert.ToDateTime(LastQuotaDate==null ? date : LastQuotaDate);
            if (DailyQuota != null && LastQuotaDate != null && Convert.ToDateTime(LastQuotaDate).Day == date.Day && Convert.ToDateTime(LastQuotaDate).Month == date.Month && Convert.ToDateTime(LastQuotaDate).Year == date.Year)// gün değişmediyse
            {
                dailyQuota = (int)DailyQuota;
            }
            else// gün değiştiyse
            {
                if (isDailyQuotaStatic || LastQuotaDate == null || (lastQuotaDate.Month != date.Month && lastQuotaDate.Year != date.Year))// // Günlük artan Kontenjan aktarılmayacaksa yada ,Ay değişdiyse yeni ayın kontenjan değeri alınır.Eski aydan yeni aya aktarım yapılamaz
                {
                    monthlyQuota = GetQuatoOfMonth(date);
                }
                else//Günlük kullanılmayan kontenjan sonraki günlere aktarılıyorsa kalan aylık kontenjanla işlem yapılır
                {
                    if(MonthlyQuota == null)
                    {
                        if(decreaseQuota)
                        {
                            MonthlyQuota = GetQuatoOfMonth(date);
                            monthlyQuota = MonthlyQuota;
                        }
                        else
                            monthlyQuota = GetQuatoOfMonth(date);
                    }
                    else
                        monthlyQuota = MonthlyQuota;
                }
                if (monthlyQuota == null || monthlyQuota == 0)
                {
                    dailyQuota = 0;
                }
                else
                {
                    int getRemainingWorkDayCountOfMonth = 0;
                    if (isDailyQuotaStatic)
                        getRemainingWorkDayCountOfMonth=GetRemainingWorkDayCountOfMonth(firstDateOfMonth);// Kontenjan aktarılmayacaksa ayın iş günü sayısı direk alınır
                    else
                        getRemainingWorkDayCountOfMonth=GetRemainingWorkDayCountOfMonth(date);
                    if (getRemainingWorkDayCountOfMonth == 0)
                    {
                        dailyQuota = 0;
                    }
                    else
                    {
                        double dailyQuotadbl = (double)monthlyQuota / getRemainingWorkDayCountOfMonth;
                        //
                        //                        if (dailyQuotadbl > ((int)dailyQuotadbl + 0.5))
                        //                            dailyQuota = (int)dailyQuotadbl + 1;
                        //                        else
                        dailyQuota = (int)dailyQuotadbl;// Hep aşağıya yuvarlar
                    }
                }

                // Hergün yapılan ilk işlemde Daha önce bu güne verilen Randevulu Kontenjan hastası sayısınca hasta kontenjandan düşürülür.
                BindingList<TTObjectClasses.QuotaHistory> quotaHistoryList = QuotaHistory.GetByDateOfQuota(roContext, date, this);
                if (dailyQuota > 0)
                    dailyQuota -= quotaHistoryList.Count;
                if (monthlyQuota > 0)
                    monthlyQuota -= quotaHistoryList.Count;
                //
            }
            if (decreaseQuota)
            {
                bool decreaseDailyQuota = false;
                bool hasNoQuotaExists = false;
                Patient patient = null;
                if (patientAdmission != null)
                {
                    patient=patientAdmission.Episode.Patient;
                }
                else if (admissionAppointment != null)
                {
                    patient=admissionAppointment.SelectedPatient;
                }
                else
                    throw new Exception(SystemMessage.GetMessage(567));
                if(patient == null && admissionAppointment != null)
                {
                    BindingList<QuotaHistory> admissionQuota = QuotaHistory.GetByAdmissionAppointment(roContext,admissionAppointment.ObjectID);
                    if(admissionQuota.Count == 0)
                        hasNoQuotaExists = true;
                }
                else
                {
                    //Hasta kafa randevusundan kabul edildiyse ve kafa randevusunun selectedPatient ı boş ise hasta kabul ün admissionapp sine bakılır.
                    if(patientAdmission != null && patientAdmission.AdmissionAppointment != null)
                    {
                        BindingList<QuotaHistory> admissionQuota = QuotaHistory.GetByAdmissionAppointment(roContext,patientAdmission.AdmissionAppointment.ObjectID);
                        if(admissionQuota.Count == 0)
                            hasNoQuotaExists = true;
                    }
                    else
                    {
                        //Hastanın o gün içinde bu birimden kota kullanıp kullanmadığına bakılır
                        BindingList<TTObjectClasses.QuotaHistory.GetByStartEndDateAndPatient_Class> patientQuota = QuotaHistory.GetByPatientDailyQuota(roContext, date, this, patient);
                        if(patientQuota.Count == 0)
                            hasNoQuotaExists = true;
                    }
                    
                }
                if(hasNoQuotaExists==true)// o gün için  daha önce kontenjan harcamadıysa kontenjandan düşülür
                {
                    if (patientAdmission != null)// Kontenjan hasta kabulden azaltılıyor demek.Günlük kontenjan düşürülür QuotaHistory' kişi eklenir
                    {
                        QuotaHistory paQuotaHistory=CreateQuotaHistory(patientAdmission);
                        if(paQuotaHistory==null)// boşsa randevusuz kabul yapılmışdır
                        {
                            decreaseDailyQuota=true;
                        }
                        else if(paQuotaHistory.AdmissionAppointment==null)// Randevusuz kabul yapıldıysa yada randevu sırasında kontenjana dahil olmadıysa, günlük kontenjan azaltılır
                        {
                            decreaseDailyQuota=true;
                        }
                    }
                    else if (admissionAppointment != null)
                    {
                        if(Convert.ToDateTime(admissionAppointment.WorkListDate).Date!=date.Date) // Randevu aynı güne veriliyorsa günlük kontenjandan düşülür
                        {
                            int remainingStaticDailyQuota = GetRemainingStaticDailyQuota(Convert.ToDateTime(admissionAppointment.WorkListDate).Date);
                            if(remainingStaticDailyQuota <= 0)
                                throw new Exception(SystemMessage.GetMessageV2(568, Name.ToString() ));
                            dailyQuota = remainingStaticDailyQuota;
                        }
                        decreaseDailyQuota=true;
                        CreateQuotaHistory(admissionAppointment);
                    }
                }
                else// o gün içinde bir kez kontenjan harcadı ise(Randevu ile) o gün açılan tüm vakaları kontenjanlı Kabul olarak işaretlenir
                {
                    if(patientAdmission != null && patientAdmission.Episode != null)
                        patientAdmission.Episode.IsQuotaUsed=true;
                }
                
                if(decreaseDailyQuota)
                {
                    if(patientAdmission != null && patientAdmission.Episode != null)
                        patientAdmission.Episode.IsQuotaUsed=true;
                    
                    if (dailyQuota < 1)
                    {
                        if (patientAdmission != null)
                            throw new Exception(SystemMessage.GetMessageV2(570, Name.ToString() ));
                        else
                            throw new Exception(SystemMessage.GetMessageV2(568, Name.ToString() ));
                    }
                    dailyQuota--;
                    monthlyQuota--;
                    MonthlyQuota = monthlyQuota;
                    DailyQuota = dailyQuota;
                    LastQuotaDate = date;
                }
                
            }
            return dailyQuota;
        }
        
        public int GetRemainingInpatientQuota()
        {
            return GetRemainingInpatientQuota(false,null);
        }
        
        //Hasta yatış veya birimler arası nakil işlemi iptal edildiğinde, veya hasta yatış taburcu olduğunda kullandığı tüm kotalar silinmeli.
        public void DeleteUsedInpatientQuota(EpisodeAction episodeAction)
        {
            if(episodeAction != null)
            {
                BindingList<TTObjectClasses.QuotaHistory> quotaHistorybyEpisodeAndResSection = QuotaHistory.GetByEpisodeAndResSection(ObjectContext, episodeAction.Episode.ObjectID,ObjectID);
                foreach(TTObjectClasses.QuotaHistory quotaHistory in quotaHistorybyEpisodeAndResSection)
                {
                    ((ITTObject)quotaHistory).Delete();
                    InpatientQuota++;
                }
            }
        }
        
        //Hasta yatışta kota düşürür ya da kalan kotayı döndürür.
        private int GetRemainingInpatientQuota(bool decreaseQuota,EpisodeAction episodeAction)
        {
            TTObjectContext roContext = new TTObjectContext(true);
            bool isDailyQuotaStatic= (TTObjectClasses.SystemParameter.GetParameterValue("IsDailyQuotaStatic", "TRUE")=="TRUE");
            double percentageOfCivillianBeds = ((double)Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("PercentageOfCivillianBeds", "20"))) / 100;
            int inPatientQuota = 0;
            int monthlyQuota = 0;
            int civillianInpatientCount = (int)((ResWard)this).CivillianInpatientCount;
            DateTime date = Common.RecTime();
            DateTime firstDateOfMonth = Convert.ToDateTime("01."+ date.Month + "." + date.Year);

            DateTime lastQuotaDate=Convert.ToDateTime(LastQuotaDate==null ? date : LastQuotaDate);
            if(LastQuotaDate == null) // Daha önce kotadan düşme yapılmadıysa
            {
                monthlyQuota = (int)((ResWard)this).BedCount;
                //if (monthlyQuota == null || monthlyQuota == 0)
                if (monthlyQuota == 0)
                {
                    inPatientQuota = 0;
                }
                else
                {
                    if(InpatientQuota != null)
                    {
                        //if(civillianInpatientCount == null || civillianInpatientCount == 0)
                        if(civillianInpatientCount == 0)
                            inPatientQuota = (int)InpatientQuota;
                        else
                            inPatientQuota = (int)InpatientQuota - civillianInpatientCount;
                    }
                    else
                    {
                        //Yatan sivil hasta kotası belirlenmemişse yatak sayısının %20 si alınır. Ve yatan sivil hasta sayısı bundan çıkarılır.
                        double inPatientQuotadbl = (double)monthlyQuota * percentageOfCivillianBeds;
                        inPatientQuota = (int)inPatientQuotadbl;// Hep aşağıya yuvarlar
                        //if(civillianInpatientCount != null && civillianInpatientCount != 0)
                        if(civillianInpatientCount != 0)
                            inPatientQuota = inPatientQuota - civillianInpatientCount;
                    }
                }
            }
            else
            {
                if (InpatientQuota != null)
                {
                    inPatientQuota = (int)InpatientQuota;
                }
                else
                {
                    double inPatientQuotadbl = (double)monthlyQuota * percentageOfCivillianBeds;
                    inPatientQuota = (int)inPatientQuotadbl;// Hep aşağıya yuvarlar
                    //if(civillianInpatientCount != null && civillianInpatientCount != 0)
                    if (civillianInpatientCount != 0)
                        inPatientQuota = inPatientQuota - civillianInpatientCount;
                }
            }
            
            if (decreaseQuota)
            {
                bool decreaseInPatientQuota = false;
                bool hasQuotaExists = false;
                Patient patient = null;
                if (episodeAction != null)
                    patient = episodeAction.Episode.Patient;
                else
                    throw new Exception(SystemMessage.GetMessage(567));
                if(patient != null)
                {
                    BindingList<TTObjectClasses.QuotaHistory> quotaHistorybyEpisodeAndResSection = QuotaHistory.GetByEpisodeAndResSection(ObjectContext, episodeAction.Episode.ObjectID,ObjectID);
                    if(quotaHistorybyEpisodeAndResSection.Count > 0)
                        hasQuotaExists = true;
                }
                else
                    throw new Exception(SystemMessage.GetMessage(569));
                if(hasQuotaExists==false)// o gün için  daha önce kontenjan harcamadıysa kontenjandan düşülür
                {
                    decreaseInPatientQuota=true;
                    CreateQuotaHistory(episodeAction);
                }
                else// o gün içinde bir kez kontenjan harcadı ise kontenjanlı yatış yapılır                {
                    episodeAction.Episode.IsQuotaUsed=true;
                
                
                if(decreaseInPatientQuota)
                {
                    episodeAction.Episode.IsQuotaUsed=true;
                    if (inPatientQuota < 1)
                        throw new Exception(SystemMessage.GetMessageV2(571, Name.ToString() ));
                    inPatientQuota--;
                    InpatientQuota = inPatientQuota;
                    LastQuotaDate = date;
                }
                
            }
            return inPatientQuota;
        }
        
        public SKRSKlinikler GetMySKRSKlinikler()
        {
            if(ResourceSpecialities != null && ResourceSpecialities.Count>0)
            {
                if(ResourceSpecialities[0].Speciality.SKRSKlinik!= null)
                    return  ResourceSpecialities[0].Speciality.SKRSKlinik;
            }
            
            return null;
        }
        
#endregion Methods

    }
}