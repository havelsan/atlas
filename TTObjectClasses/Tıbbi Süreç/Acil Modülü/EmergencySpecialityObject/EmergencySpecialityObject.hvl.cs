
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EmergencySpecialityObject")] 

    /// <summary>
    /// Acil Muayene Hasta Değerlendirme Objesi
    /// </summary>
    public  partial class EmergencySpecialityObject : SpecialityBasedObject
    {
        public class EmergencySpecialityObjectList : TTObjectCollection<EmergencySpecialityObject> { }
                    
        public class ChildEmergencySpecialityObjectCollection : TTObject.TTChildObjectCollection<EmergencySpecialityObject>
        {
            public ChildEmergencySpecialityObjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEmergencySpecialityObjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOldInfoForEmergencySpecialityForm_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public String Defname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Doctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetOldInfoForEmergencySpecialityForm_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForEmergencySpecialityForm_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForEmergencySpecialityForm_Class() : base() { }
        }

        public static BindingList<EmergencySpecialityObject> GetEmergencySpecialityObjectByPatient(TTObjectContext objectContext, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYSPECIALITYOBJECT"].QueryDefs["GetEmergencySpecialityObjectByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<EmergencySpecialityObject>(queryDef, paramList);
        }

        public static BindingList<EmergencySpecialityObject.GetOldInfoForEmergencySpecialityForm_Class> GetOldInfoForEmergencySpecialityForm(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYSPECIALITYOBJECT"].QueryDefs["GetOldInfoForEmergencySpecialityForm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<EmergencySpecialityObject.GetOldInfoForEmergencySpecialityForm_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EmergencySpecialityObject.GetOldInfoForEmergencySpecialityForm_Class> GetOldInfoForEmergencySpecialityForm(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYSPECIALITYOBJECT"].QueryDefs["GetOldInfoForEmergencySpecialityForm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<EmergencySpecialityObject.GetOldInfoForEmergencySpecialityForm_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public bool? TetanusVaccine
        {
            get { return (bool?)this["TETANUSVACCINE"]; }
            set { this["TETANUSVACCINE"] = value; }
        }

    /// <summary>
    /// Genel Durum İyi
    /// </summary>
        public bool? GeneralEvaluationGood
        {
            get { return (bool?)this["GENERALEVALUATIONGOOD"]; }
            set { this["GENERALEVALUATIONGOOD"] = value; }
        }

    /// <summary>
    /// Genel Durum Orta
    /// </summary>
        public bool? GeneralEvaluationMedium
        {
            get { return (bool?)this["GENERALEVALUATIONMEDIUM"]; }
            set { this["GENERALEVALUATIONMEDIUM"] = value; }
        }

        public bool? GeneralEvaluationBad
        {
            get { return (bool?)this["GENERALEVALUATIONBAD"]; }
            set { this["GENERALEVALUATIONBAD"] = value; }
        }

        public bool? GeneralEvaluationPainly
        {
            get { return (bool?)this["GENERALEVALUATIONPAINLY"]; }
            set { this["GENERALEVALUATIONPAINLY"] = value; }
        }

        public bool? GeneralEvaluationDispneic
        {
            get { return (bool?)this["GENERALEVALUATIONDISPNEIC"]; }
            set { this["GENERALEVALUATIONDISPNEIC"] = value; }
        }

        public bool? GeneralEvaluationDehidrate
        {
            get { return (bool?)this["GENERALEVALUATIONDEHIDRATE"]; }
            set { this["GENERALEVALUATIONDEHIDRATE"] = value; }
        }

        public bool? GeneralEvaluationSweaty
        {
            get { return (bool?)this["GENERALEVALUATIONSWEATY"]; }
            set { this["GENERALEVALUATIONSWEATY"] = value; }
        }

        public bool? GeneralEvaluationCold
        {
            get { return (bool?)this["GENERALEVALUATIONCOLD"]; }
            set { this["GENERALEVALUATIONCOLD"] = value; }
        }

        public bool? PsychologicalEvaluationNormal
        {
            get { return (bool?)this["PSYCHOLOGICALEVALUATIONNORMAL"]; }
            set { this["PSYCHOLOGICALEVALUATIONNORMAL"] = value; }
        }

        public bool? PsychologicalEvaluationAngry
        {
            get { return (bool?)this["PSYCHOLOGICALEVALUATIONANGRY"]; }
            set { this["PSYCHOLOGICALEVALUATIONANGRY"] = value; }
        }

        public bool? PsychologicalEvaluationSad
        {
            get { return (bool?)this["PSYCHOLOGICALEVALUATIONSAD"]; }
            set { this["PSYCHOLOGICALEVALUATIONSAD"] = value; }
        }

        public bool? PsychologicalEvalWorried
        {
            get { return (bool?)this["PSYCHOLOGICALEVALWORRIED"]; }
            set { this["PSYCHOLOGICALEVALWORRIED"] = value; }
        }

        public bool? PsychologicalEvalIrrelevant
        {
            get { return (bool?)this["PSYCHOLOGICALEVALIRRELEVANT"]; }
            set { this["PSYCHOLOGICALEVALIRRELEVANT"] = value; }
        }

        public string PsychologicalEvaluationOther
        {
            get { return (string)this["PSYCHOLOGICALEVALUATIONOTHER"]; }
            set { this["PSYCHOLOGICALEVALUATIONOTHER"] = value; }
        }

        public bool? HeadAche
        {
            get { return (bool?)this["HEADACHE"]; }
            set { this["HEADACHE"] = value; }
        }

        public string PainPlace
        {
            get { return (string)this["PAINPLACE"]; }
            set { this["PAINPLACE"] = value; }
        }

        public string PainDegree
        {
            get { return (string)this["PAINDEGREE"]; }
            set { this["PAINDEGREE"] = value; }
        }

        public string PainPeriod
        {
            get { return (string)this["PAINPERIOD"]; }
            set { this["PAINPERIOD"] = value; }
        }

        public int? FaceScala
        {
            get { return (int?)this["FACESCALA"]; }
            set { this["FACESCALA"] = value; }
        }

        public bool? BehaviourLoss
        {
            get { return (bool?)this["BEHAVIOURLOSS"]; }
            set { this["BEHAVIOURLOSS"] = value; }
        }

    /// <summary>
    /// Not
    /// </summary>
        public object Note
        {
            get { return (object)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// Şikayet
    /// </summary>
        public string Complaint
        {
            get { return (string)this["COMPLAINT"]; }
            set { this["COMPLAINT"] = value; }
        }

    /// <summary>
    /// Şikayet Açıklama
    /// </summary>
        public object ComplaintDescription
        {
            get { return (object)this["COMPLAINTDESCRIPTION"]; }
            set { this["COMPLAINTDESCRIPTION"] = value; }
        }

        public string ComplaintDuration
        {
            get { return (string)this["COMPLAINTDURATION"]; }
            set { this["COMPLAINTDURATION"] = value; }
        }

    /// <summary>
    /// Devamlı İlaçlar
    /// </summary>
        public object ContinuousDrugs
        {
            get { return (object)this["CONTINUOUSDRUGS"]; }
            set { this["CONTINUOUSDRUGS"] = value; }
        }

        public string LastEatingInfo
        {
            get { return (string)this["LASTEATINGINFO"]; }
            set { this["LASTEATINGINFO"] = value; }
        }

    /// <summary>
    /// Özgeçmiş / Soygeçmiş
    /// </summary>
        public string PatientHistory
        {
            get { return (string)this["PATIENTHISTORY"]; }
            set { this["PATIENTHISTORY"] = value; }
        }

    /// <summary>
    /// Hasta Özgeçmiş Açıklaması
    /// </summary>
        public object PatientHistoryDescription
        {
            get { return (object)this["PATIENTHISTORYDESCRIPTION"]; }
            set { this["PATIENTHISTORYDESCRIPTION"] = value; }
        }

        public int? AlcoholPromile
        {
            get { return (int?)this["ALCOHOLPROMILE"]; }
            set { this["ALCOHOLPROMILE"] = value; }
        }

    /// <summary>
    /// Hamile
    /// </summary>
        public bool? IsPregnant
        {
            get { return (bool?)this["ISPREGNANT"]; }
            set { this["ISPREGNANT"] = value; }
        }

    /// <summary>
    /// Son Adet Tarihi
    /// </summary>
        public DateTime? LastMenstrualPeriod
        {
            get { return (DateTime?)this["LASTMENSTRUALPERIOD"]; }
            set { this["LASTMENSTRUALPERIOD"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? ApplicationDate
        {
            get { return (DateTime?)this["APPLICATIONDATE"]; }
            set { this["APPLICATIONDATE"] = value; }
        }

        public string PainQualityDescription
        {
            get { return (string)this["PAINQUALITYDESCRIPTION"]; }
            set { this["PAINQUALITYDESCRIPTION"] = value; }
        }

        public string AchingSide
        {
            get { return (string)this["ACHINGSIDE"]; }
            set { this["ACHINGSIDE"] = value; }
        }

        public string PainDetail
        {
            get { return (string)this["PAINDETAIL"]; }
            set { this["PAINDETAIL"] = value; }
        }

        public string PainTime
        {
            get { return (string)this["PAINTIME"]; }
            set { this["PAINTIME"] = value; }
        }

        public string DurationofPain
        {
            get { return (string)this["DURATIONOFPAIN"]; }
            set { this["DURATIONOFPAIN"] = value; }
        }

        public PainFaceScaleEnum? PainFaceScale
        {
            get { return (PainFaceScaleEnum?)(int?)this["PAINFACESCALE"]; }
            set { this["PAINFACESCALE"] = value; }
        }

    /// <summary>
    /// Toplam Puan
    /// </summary>
        public GlaskowComaScaleScoreEnum? TotalScore
        {
            get { return (GlaskowComaScaleScoreEnum?)(int?)this["TOTALSCORE"]; }
            set { this["TOTALSCORE"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Alerji Açıklaması
    /// </summary>
        public object AllergyDescription
        {
            get { return (object)this["ALLERGYDESCRIPTION"]; }
            set { this["ALLERGYDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Alışkanlıklar
    /// </summary>
        public object Habits
        {
            get { return (object)this["HABITS"]; }
            set { this["HABITS"] = value; }
        }

    /// <summary>
    /// Gözler
    /// </summary>
        public GlaskowComaScaleDefinition Eyes
        {
            get { return (GlaskowComaScaleDefinition)((ITTObject)this).GetParent("EYES"); }
            set { this["EYES"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Motor Cevap
    /// </summary>
        public GlaskowComaScaleDefinition MotorAnswer
        {
            get { return (GlaskowComaScaleDefinition)((ITTObject)this).GetParent("MOTORANSWER"); }
            set { this["MOTORANSWER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sözel Cevap
    /// </summary>
        public GlaskowComaScaleDefinition OralAnswer
        {
            get { return (GlaskowComaScaleDefinition)((ITTObject)this).GetParent("ORALANSWER"); }
            set { this["ORALANSWER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Acil Triaj
    /// </summary>
        public SKRSTRIAJKODU Triage
        {
            get { return (SKRSTRIAJKODU)((ITTObject)this).GetParent("TRIAGE"); }
            set { this["TRIAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ağrının Niteliği
    /// </summary>
        public PainQualityDefinition PainQuality
        {
            get { return (PainQualityDefinition)((ITTObject)this).GetParent("PAINQUALITY"); }
            set { this["PAINQUALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ağrının Sıklığı
    /// </summary>
        public PainFrequencyDefiniton PainFrequency
        {
            get { return (PainFrequencyDefiniton)((ITTObject)this).GetParent("PAINFREQUENCY"); }
            set { this["PAINFREQUENCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ağrının Yeri
    /// </summary>
        public PainPlaceDefition PainPlaces
        {
            get { return (PainPlaceDefition)((ITTObject)this).GetParent("PAINPLACES"); }
            set { this["PAINPLACES"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAllergiesCollection()
        {
            _Allergies = new Allergy.ChildAllergyCollection(this, new Guid("3fd431a8-b4dd-4723-ae5a-fb28143e44a5"));
            ((ITTChildObjectCollection)_Allergies).GetChildren();
        }

        protected Allergy.ChildAllergyCollection _Allergies = null;
    /// <summary>
    /// Child collection for Allergies
    /// </summary>
        public Allergy.ChildAllergyCollection Allergies
        {
            get
            {
                if (_Allergies == null)
                    CreateAllergiesCollection();
                return _Allergies;
            }
        }

        virtual protected void CreateVaccinationsCollection()
        {
            _Vaccinations = new Vaccination.ChildVaccinationCollection(this, new Guid("8736efb3-bbce-4a03-8599-63376cb10800"));
            ((ITTChildObjectCollection)_Vaccinations).GetChildren();
        }

        protected Vaccination.ChildVaccinationCollection _Vaccinations = null;
    /// <summary>
    /// Child collection for Allergies
    /// </summary>
        public Vaccination.ChildVaccinationCollection Vaccinations
        {
            get
            {
                if (_Vaccinations == null)
                    CreateVaccinationsCollection();
                return _Vaccinations;
            }
        }

        virtual protected void CreateEmergencySurveyObjectsCollection()
        {
            _EmergencySurveyObjects = new EmergencySurveyObject.ChildEmergencySurveyObjectCollection(this, new Guid("ef4ec8b8-f8c5-4b86-8755-2b57c07879b3"));
            ((ITTChildObjectCollection)_EmergencySurveyObjects).GetChildren();
        }

        protected EmergencySurveyObject.ChildEmergencySurveyObjectCollection _EmergencySurveyObjects = null;
        public EmergencySurveyObject.ChildEmergencySurveyObjectCollection EmergencySurveyObjects
        {
            get
            {
                if (_EmergencySurveyObjects == null)
                    CreateEmergencySurveyObjectsCollection();
                return _EmergencySurveyObjects;
            }
        }

        protected EmergencySpecialityObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EmergencySpecialityObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EmergencySpecialityObject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EmergencySpecialityObject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EmergencySpecialityObject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EMERGENCYSPECIALITYOBJECT", dataRow) { }
        protected EmergencySpecialityObject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EMERGENCYSPECIALITYOBJECT", dataRow, isImported) { }
        public EmergencySpecialityObject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EmergencySpecialityObject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EmergencySpecialityObject() : base() { }

    }
}