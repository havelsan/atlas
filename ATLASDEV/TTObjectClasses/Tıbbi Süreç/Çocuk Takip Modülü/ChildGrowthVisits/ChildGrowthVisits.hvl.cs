
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ChildGrowthVisits")] 

    /// <summary>
    /// Vizitlerin Bilgileri
    /// </summary>
    public  partial class ChildGrowthVisits : TTObject
    {
        public class ChildGrowthVisitsList : TTObjectCollection<ChildGrowthVisits> { }
                    
        public class ChildChildGrowthVisitsCollection : TTObject.TTChildObjectCollection<ChildGrowthVisits>
        {
            public ChildChildGrowthVisitsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChildGrowthVisitsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PatientVisitsList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? VisitDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VISITDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHILDGROWTHVISITS"].AllPropertyDefs["VISITDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHILDGROWTHVISITS"].AllPropertyDefs["DATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? Weight
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHILDGROWTHVISITS"].AllPropertyDefs["WEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public int? Height
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHILDGROWTHVISITS"].AllPropertyDefs["HEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public double? BMI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHILDGROWTHVISITS"].AllPropertyDefs["BMI"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public PatientVisitsList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PatientVisitsList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PatientVisitsList_Class() : base() { }
        }

        public static BindingList<ChildGrowthVisits> GetPatientVisits(TTObjectContext objectContext, string PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHILDGROWTHVISITS"].QueryDefs["GetPatientVisits"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<ChildGrowthVisits>(queryDef, paramList);
        }

        public static BindingList<ChildGrowthVisits.PatientVisitsList_Class> PatientVisitsList(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHILDGROWTHVISITS"].QueryDefs["PatientVisitsList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<ChildGrowthVisits.PatientVisitsList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ChildGrowthVisits.PatientVisitsList_Class> PatientVisitsList(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHILDGROWTHVISITS"].QueryDefs["PatientVisitsList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<ChildGrowthVisits.PatientVisitsList_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Vizit Tarihi
    /// </summary>
        public DateTime? VisitDate
        {
            get { return (DateTime?)this["VISITDATE"]; }
            set { this["VISITDATE"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

    /// <summary>
    /// Kilo(kg)
    /// </summary>
        public double? Weight
        {
            get { return (double?)this["WEIGHT"]; }
            set { this["WEIGHT"] = value; }
        }

    /// <summary>
    /// Boy(cm)
    /// </summary>
        public int? Height
        {
            get { return (int?)this["HEIGHT"]; }
            set { this["HEIGHT"] = value; }
        }

    /// <summary>
    /// Vücut Kitle İndeksi
    /// </summary>
        public double? BMI
        {
            get { return (double?)this["BMI"]; }
            set { this["BMI"] = value; }
        }

    /// <summary>
    /// Ödem Bilgisi
    /// </summary>
        public OedemaEnum? Oedema
        {
            get { return (OedemaEnum?)(int?)this["OEDEMA"]; }
            set { this["OEDEMA"] = value; }
        }

    /// <summary>
    /// Deri Kıvrımı(mm)
    /// </summary>
        public double? Subscapular
        {
            get { return (double?)this["SUBSCAPULAR"]; }
            set { this["SUBSCAPULAR"] = value; }
        }

    /// <summary>
    /// Kıvrım Kalınlığı(mm)
    /// </summary>
        public double? TricepsSkinfold
        {
            get { return (double?)this["TRICEPSSKINFOLD"]; }
            set { this["TRICEPSSKINFOLD"] = value; }
        }

    /// <summary>
    /// Notlar
    /// </summary>
        public string Notes
        {
            get { return (string)this["NOTES"]; }
            set { this["NOTES"] = value; }
        }

    /// <summary>
    /// Değerlendirme
    /// </summary>
        public string Assessments
        {
            get { return (string)this["ASSESSMENTS"]; }
            set { this["ASSESSMENTS"] = value; }
        }

    /// <summary>
    /// Bebek en az beş adım atabilmektedir.
    /// </summary>
        public bool? WalkingWAssistance4
        {
            get { return (bool?)this["WALKINGWASSISTANCE4"]; }
            set { this["WALKINGWASSISTANCE4"] = value; }
        }

    /// <summary>
    /// Bebek tek ayağını hareket ettirirken diğer ayağından destek almaktadır.
    /// </summary>
        public bool? WalkingWAssistance3
        {
            get { return (bool?)this["WALKINGWASSISTANCE3"]; }
            set { this["WALKINGWASSISTANCE3"] = value; }
        }

    /// <summary>
    /// Geç konuşma ile ilgili bir sorunu olduğu düşünülüyor mu?
    /// </summary>
        public string NurseObservationQ3
        {
            get { return (string)this["NURSEOBSERVATIONQ3"]; }
            set { this["NURSEOBSERVATIONQ3"] = value; }
        }

    /// <summary>
    /// Bir ayda herhangi bir sebepten ikiden fazla ilaç alıyor mu?
    /// </summary>
        public string NurseObservationQ1
        {
            get { return (string)this["NURSEOBSERVATIONQ1"]; }
            set { this["NURSEOBSERVATIONQ1"] = value; }
        }

    /// <summary>
    /// Duyma ile ilgili herhangi bir sorunu olduğu düşünülüyor mu?
    /// </summary>
        public string NurseObservationQ2
        {
            get { return (string)this["NURSEOBSERVATIONQ2"]; }
            set { this["NURSEOBSERVATIONQ2"] = value; }
        }

    /// <summary>
    /// Şaşılık ile ilgili bir sorun olduğu düşünülüyor mu?
    /// </summary>
        public string NurseObservationQ4
        {
            get { return (string)this["NURSEOBSERVATIONQ4"]; }
            set { this["NURSEOBSERVATIONQ4"] = value; }
        }

    /// <summary>
    /// Zekayla ilgili bir sorun olduğu düşünülüyor mu?
    /// </summary>
        public string NurseObservationQ5
        {
            get { return (string)this["NURSEOBSERVATIONQ5"]; }
            set { this["NURSEOBSERVATIONQ5"] = value; }
        }

    /// <summary>
    /// Evde hemşire ziyaretine ihtiyacı var mı?
    /// </summary>
        public string NurseObservationQ6
        {
            get { return (string)this["NURSEOBSERVATIONQ6"]; }
            set { this["NURSEOBSERVATIONQ6"] = value; }
        }

    /// <summary>
    /// Ölçüm Şekli
    /// </summary>
        public MeasurementTypeEnum? MeasurementType
        {
            get { return (MeasurementTypeEnum?)(int?)this["MEASUREMENTTYPE"]; }
            set { this["MEASUREMENTTYPE"] = value; }
        }

    /// <summary>
    /// Kafa Çevresi(cm)
    /// </summary>
        public double? HeadCircle
        {
            get { return (double?)this["HEADCIRCLE"]; }
            set { this["HEADCIRCLE"] = value; }
        }

    /// <summary>
    /// Kol Çevresi(cm)
    /// </summary>
        public double? ArmCircle
        {
            get { return (double?)this["ARMCIRCLE"]; }
            set { this["ARMCIRCLE"] = value; }
        }

    /// <summary>
    /// Bebek ayakta dururken vücudu tutunduğu objeye temas etmeden, ağırlığını sadece bacaklarına vererek ayakta durabilmektedir.
    /// </summary>
        public bool? StandingWAssistance2
        {
            get { return (bool?)this["STANDINGWASSISTANCE2"]; }
            set { this["STANDINGWASSISTANCE2"] = value; }
        }

    /// <summary>
    /// Bebek tutunarak en az 10 saniye ayakta durabilmektedir.
    /// </summary>
        public bool? StandingWAssistance3
        {
            get { return (bool?)this["STANDINGWASSISTANCE3"]; }
            set { this["STANDINGWASSISTANCE3"] = value; }
        }

    /// <summary>
    /// Bebek dik pozisyonda ve sırtı dik şekilde en az beş adım atabilmektedir.
    /// </summary>
        public bool? WalkingAlone1
        {
            get { return (bool?)this["WALKINGALONE1"]; }
            set { this["WALKINGALONE1"] = value; }
        }

    /// <summary>
    /// Bebeğin bir ayağı ileri doğru adım atarken diğer ayağından destek almaktadır.
    /// </summary>
        public bool? WalkingAlone2
        {
            get { return (bool?)this["WALKINGALONE2"]; }
            set { this["WALKINGALONE2"] = value; }
        }

    /// <summary>
    /// Bebeğin herhangi bir obje veya kişi ile teması bulunmamaktadır.
    /// </summary>
        public bool? WalkingAlone3
        {
            get { return (bool?)this["WALKINGALONE3"]; }
            set { this["WALKINGALONE3"] = value; }
        }

    /// <summary>
    /// Bebek sırtı dik pozisyonda ayakta durabilmektedir.
    /// </summary>
        public bool? WalkingWAssistance1
        {
            get { return (bool?)this["WALKINGWASSISTANCE1"]; }
            set { this["WALKINGWASSISTANCE1"] = value; }
        }

    /// <summary>
    /// Bebek bir objeye tek elle veya iki elle tutunarak ileri ya da geri hareket edebilmektedir.
    /// </summary>
        public bool? WalkingWAssistance2
        {
            get { return (bool?)this["WALKINGWASSISTANCE2"]; }
            set { this["WALKINGWASSISTANCE2"] = value; }
        }

    /// <summary>
    /// Gelişimi ile ilgili bir sorun olduğu düşünülüyor mu?
    /// </summary>
        public string NurseObservationQ7
        {
            get { return (string)this["NURSEOBSERVATIONQ7"]; }
            set { this["NURSEOBSERVATIONQ7"] = value; }
        }

    /// <summary>
    /// Bebek ellerini ve dizlerini kullanarak ileriye ya da geriye doğru hareket edebilmektedir.
    /// </summary>
        public bool? Crawling1
        {
            get { return (bool?)this["CRAWLING1"]; }
            set { this["CRAWLING1"] = value; }
        }

    /// <summary>
    /// Bebeğin karnı emekleme esnasında yere temas etmemektedir.
    /// </summary>
        public bool? Crawling2
        {
            get { return (bool?)this["CRAWLING2"]; }
            set { this["CRAWLING2"] = value; }
        }

    /// <summary>
    /// Bebek sürekli ve ardışık en az üç hareket yapabilmektedir.
    /// </summary>
        public bool? Crawling3
        {
            get { return (bool?)this["CRAWLING3"]; }
            set { this["CRAWLING3"] = value; }
        }

        public DateTime? MotorAssesmentDate
        {
            get { return (DateTime?)this["MOTORASSESMENTDATE"]; }
            set { this["MOTORASSESMENTDATE"] = value; }
        }

    /// <summary>
    /// Bebek kafasını dik tutarak en az 10 saniye oturabilmektedir.
    /// </summary>
        public bool? SittingWoSupport1
        {
            get { return (bool?)this["SITTINGWOSUPPORT1"]; }
            set { this["SITTINGWOSUPPORT1"] = value; }
        }

    /// <summary>
    /// Oturur pozisyonda iken dengesini kurmak için ellerine ve ayaklarına ihtiyaç duymaz.
    /// </summary>
        public bool? SittingWoSupport2
        {
            get { return (bool?)this["SITTINGWOSUPPORT2"]; }
            set { this["SITTINGWOSUPPORT2"] = value; }
        }

    /// <summary>
    /// Bebek iki ayağı yere basarken sırtı dik olacak şekilde ayakta durabilmektedir.
    /// </summary>
        public bool? StandingAlone1
        {
            get { return (bool?)this["STANDINGALONE1"]; }
            set { this["STANDINGALONE1"] = value; }
        }

    /// <summary>
    /// Bebeğin ayakları vücut ağırlığının %100ünü taşımaktadır.
    /// </summary>
        public bool? StandingAlone2
        {
            get { return (bool?)this["STANDINGALONE2"]; }
            set { this["STANDINGALONE2"] = value; }
        }

    /// <summary>
    /// Bebeğin herhangi bir obje veya kişi ile teması bulunmamaktadır.
    /// </summary>
        public bool? StandingAlone3
        {
            get { return (bool?)this["STANDINGALONE3"]; }
            set { this["STANDINGALONE3"] = value; }
        }

    /// <summary>
    /// Bebek ayakta en az on saniye durabilmektedir.
    /// </summary>
        public bool? StandingAlone4
        {
            get { return (bool?)this["STANDINGALONE4"]; }
            set { this["STANDINGALONE4"] = value; }
        }

    /// <summary>
    /// Bebek dik pozisyonda iki ayağının üstüne bakarak, sabit bir objeye tutunarak, mobilya sandalye gibi bir objeye dayanmadan ayağa kalkabilmektedir.
    /// </summary>
        public bool? StandingWAssistance1
        {
            get { return (bool?)this["STANDINGWASSISTANCE1"]; }
            set { this["STANDINGWASSISTANCE1"] = value; }
        }

    /// <summary>
    /// Şikayet Aile Geçmişi
    /// </summary>
        public string FamilyHistory
        {
            get { return (string)this["FAMILYHISTORY"]; }
            set { this["FAMILYHISTORY"] = value; }
        }

    /// <summary>
    /// Natal Geçmiş
    /// </summary>
        public string NatalHistory
        {
            get { return (string)this["NATALHISTORY"]; }
            set { this["NATALHISTORY"] = value; }
        }

    /// <summary>
    /// Bebeğin Şikayeti
    /// </summary>
        public string BabyComplaint
        {
            get { return (string)this["BABYCOMPLAINT"]; }
            set { this["BABYCOMPLAINT"] = value; }
        }

    /// <summary>
    /// Şikayet Başlangıç Tarihi
    /// </summary>
        public DateTime? ComplaintStartDate
        {
            get { return (DateTime?)this["COMPLAINTSTARTDATE"]; }
            set { this["COMPLAINTSTARTDATE"] = value; }
        }

    /// <summary>
    /// Postnatal Geçmiş
    /// </summary>
        public string PostnatalHistory
        {
            get { return (string)this["POSTNATALHISTORY"]; }
            set { this["POSTNATALHISTORY"] = value; }
        }

    /// <summary>
    /// Prenatal Geçmiş
    /// </summary>
        public string PrenatalHistory
        {
            get { return (string)this["PRENATALHISTORY"]; }
            set { this["PRENATALHISTORY"] = value; }
        }

    /// <summary>
    /// Karın Muayenesi
    /// </summary>
        public string AbdomenExamination
        {
            get { return (string)this["ABDOMENEXAMINATION"]; }
            set { this["ABDOMENEXAMINATION"] = value; }
        }

    /// <summary>
    /// Anal, Genital, Lokal Muayene
    /// </summary>
        public string AnalGenitalLocalExamination
        {
            get { return (string)this["ANALGENITALLOCALEXAMINATION"]; }
            set { this["ANALGENITALLOCALEXAMINATION"] = value; }
        }

    /// <summary>
    /// Kardiyovasküler Sistem
    /// </summary>
        public string CardiovascularSystem
        {
            get { return (string)this["CARDIOVASCULARSYSTEM"]; }
            set { this["CARDIOVASCULARSYSTEM"] = value; }
        }

    /// <summary>
    /// Günlük İzlem
    /// </summary>
        public string DailyObservations
        {
            get { return (string)this["DAILYOBSERVATIONS"]; }
            set { this["DAILYOBSERVATIONS"] = value; }
        }

    /// <summary>
    /// Detaylar
    /// </summary>
        public string Details
        {
            get { return (string)this["DETAILS"]; }
            set { this["DETAILS"] = value; }
        }

    /// <summary>
    /// Ekstremiteler
    /// </summary>
        public string Extremities
        {
            get { return (string)this["EXTREMITIES"]; }
            set { this["EXTREMITIES"] = value; }
        }

    /// <summary>
    /// Baş, Boyun, Tiroid
    /// </summary>
        public string HeadNeckThyroidInfo
        {
            get { return (string)this["HEADNECKTHYROIDINFO"]; }
            set { this["HEADNECKTHYROIDINFO"] = value; }
        }

    /// <summary>
    /// Nörolojik Muayene
    /// </summary>
        public string NeurologicalExamination
        {
            get { return (string)this["NEUROLOGICALEXAMINATION"]; }
            set { this["NEUROLOGICALEXAMINATION"] = value; }
        }

    /// <summary>
    /// Solunum Sistemi
    /// </summary>
        public string RespiratorySystem
        {
            get { return (string)this["RESPIRATORYSYSTEM"]; }
            set { this["RESPIRATORYSYSTEM"] = value; }
        }

    /// <summary>
    /// Öneriler
    /// </summary>
        public string PhysicalExamSuggestions
        {
            get { return (string)this["PHYSICALEXAMSUGGESTIONS"]; }
            set { this["PHYSICALEXAMSUGGESTIONS"] = value; }
        }

    /// <summary>
    /// Diğer Detaylar, Öneriler
    /// </summary>
        public string NurseSuggestions
        {
            get { return (string)this["NURSESUGGESTIONS"]; }
            set { this["NURSESUGGESTIONS"] = value; }
        }

    /// <summary>
    /// Hastanın visiti girildiği zamanki yaşı
    /// </summary>
        public string CalculatedAge
        {
            get { return (string)this["CALCULATEDAGE"]; }
            set { this["CALCULATEDAGE"] = value; }
        }

    /// <summary>
    /// Hastanın gün bazında yaşı
    /// </summary>
        public int? CalculatedAgeByDay
        {
            get { return (int?)this["CALCULATEDAGEBYDAY"]; }
            set { this["CALCULATEDAGEBYDAY"] = value; }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bebeğin beslenme durumu
    /// </summary>
        public SKRSBebeginBeslenmeDurumu InfantNutritionalStatus
        {
            get { return (SKRSBebeginBeslenmeDurumu)((ITTObject)this).GetParent("INFANTNUTRITIONALSTATUS"); }
            set { this["INFANTNUTRITIONALSTATUS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Gelişim Durumu 
    /// </summary>
        public SKRSGelisimTablosuBilgilerininSorgulanmasi InfantGrowthStatusInfo
        {
            get { return (SKRSGelisimTablosuBilgilerininSorgulanmasi)((ITTObject)this).GetParent("INFANTGROWTHSTATUSINFO"); }
            set { this["INFANTGROWTHSTATUSINFO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSDVitaminiLojistigiveDestegi VitaminDSupplementationInfo
        {
            get { return (SKRSDVitaminiLojistigiveDestegi)((ITTObject)this).GetParent("VITAMINDSUPPLEMENTATIONINFO"); }
            set { this["VITAMINDSUPPLEMENTATIONINFO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSDemirLojistigiveDestegi IronSupplementationInfo
        {
            get { return (SKRSDemirLojistigiveDestegi)((ITTObject)this).GetParent("IRONSUPPLEMENTATIONINFO"); }
            set { this["IRONSUPPLEMENTATIONINFO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateChildBrainDevelopmentRiskFactorsCollection()
        {
            _ChildBrainDevelopmentRiskFactors = new ChildBrainDevelopmentRiskFactors.ChildChildBrainDevelopmentRiskFactorsCollection(this, new Guid("cc3b947d-922f-479f-8654-0237cb5191ff"));
            ((ITTChildObjectCollection)_ChildBrainDevelopmentRiskFactors).GetChildren();
        }

        protected ChildBrainDevelopmentRiskFactors.ChildChildBrainDevelopmentRiskFactorsCollection _ChildBrainDevelopmentRiskFactors = null;
        public ChildBrainDevelopmentRiskFactors.ChildChildBrainDevelopmentRiskFactorsCollection ChildBrainDevelopmentRiskFactors
        {
            get
            {
                if (_ChildBrainDevelopmentRiskFactors == null)
                    CreateChildBrainDevelopmentRiskFactorsCollection();
                return _ChildBrainDevelopmentRiskFactors;
            }
        }

        virtual protected void CreateInfantRiskFactorsCollection()
        {
            _InfantRiskFactors = new InfantRiskFactors.ChildInfantRiskFactorsCollection(this, new Guid("5a8ee12c-1fd8-4279-abc1-51239ac6c4fa"));
            ((ITTChildObjectCollection)_InfantRiskFactors).GetChildren();
        }

        protected InfantRiskFactors.ChildInfantRiskFactorsCollection _InfantRiskFactors = null;
        public InfantRiskFactors.ChildInfantRiskFactorsCollection InfantRiskFactors
        {
            get
            {
                if (_InfantRiskFactors == null)
                    CreateInfantRiskFactorsCollection();
                return _InfantRiskFactors;
            }
        }

        virtual protected void CreateParentalActivitiesForPsychologicalDevelopmentCollection()
        {
            _ParentalActivitiesForPsychologicalDevelopment = new ParentalActivitiesForPsychologicalDevelopment.ChildParentalActivitiesForPsychologicalDevelopmentCollection(this, new Guid("3b8aea9e-843e-4fd3-b900-b6b5f510bcaa"));
            ((ITTChildObjectCollection)_ParentalActivitiesForPsychologicalDevelopment).GetChildren();
        }

        protected ParentalActivitiesForPsychologicalDevelopment.ChildParentalActivitiesForPsychologicalDevelopmentCollection _ParentalActivitiesForPsychologicalDevelopment = null;
        public ParentalActivitiesForPsychologicalDevelopment.ChildParentalActivitiesForPsychologicalDevelopmentCollection ParentalActivitiesForPsychologicalDevelopment
        {
            get
            {
                if (_ParentalActivitiesForPsychologicalDevelopment == null)
                    CreateParentalActivitiesForPsychologicalDevelopmentCollection();
                return _ParentalActivitiesForPsychologicalDevelopment;
            }
        }

        protected ChildGrowthVisits(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ChildGrowthVisits(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ChildGrowthVisits(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ChildGrowthVisits(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ChildGrowthVisits(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHILDGROWTHVISITS", dataRow) { }
        protected ChildGrowthVisits(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHILDGROWTHVISITS", dataRow, isImported) { }
        public ChildGrowthVisits(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ChildGrowthVisits(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ChildGrowthVisits() : base() { }

    }
}