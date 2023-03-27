
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PregnancyFollow")] 

    public  partial class PregnancyFollow : TTObject
    {
        public class PregnancyFollowList : TTObjectCollection<PregnancyFollow> { }
                    
        public class ChildPregnancyFollowCollection : TTObject.TTChildObjectCollection<PregnancyFollow>
        {
            public ChildPregnancyFollowCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPregnancyFollowCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPregnancyFollowByPregnancy_Class : TTReportNqlObject 
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

            public DateTime? LastMenstrualPeriod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTMENSTRUALPERIOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCY"].AllPropertyDefs["LASTMENSTRUALPERIOD"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string PretibialEdema
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRETIBIALEDEMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYFOLLOW"].AllPropertyDefs["PRETIBIALEDEMA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? MotherWeight
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOTHERWEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYFOLLOW"].AllPropertyDefs["MOTHERWEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? BabyWeight
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BABYWEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FETUSFOLLOW"].AllPropertyDefs["BABYWEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? FKA
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FKA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FETUSFOLLOW"].AllPropertyDefs["FKA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetPregnancyFollowByPregnancy_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPregnancyFollowByPregnancy_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPregnancyFollowByPregnancy_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUniqueRefNoByID_Class : TTReportNqlObject 
        {
            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetUniqueRefNoByID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUniqueRefNoByID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUniqueRefNoByID_Class() : base() { }
        }

    /// <summary>
    /// Gebe Takip Geçmişi
    /// </summary>
        public static BindingList<PregnancyFollow.GetPregnancyFollowByPregnancy_Class> GetPregnancyFollowByPregnancy(Guid PREGNANCY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYFOLLOW"].QueryDefs["GetPregnancyFollowByPregnancy"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PREGNANCY", PREGNANCY);

            return TTReportNqlObject.QueryObjects<PregnancyFollow.GetPregnancyFollowByPregnancy_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Gebe Takip Geçmişi
    /// </summary>
        public static BindingList<PregnancyFollow.GetPregnancyFollowByPregnancy_Class> GetPregnancyFollowByPregnancy(TTObjectContext objectContext, Guid PREGNANCY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYFOLLOW"].QueryDefs["GetPregnancyFollowByPregnancy"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PREGNANCY", PREGNANCY);

            return TTReportNqlObject.QueryObjects<PregnancyFollow.GetPregnancyFollowByPregnancy_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PregnancyFollow.GetUniqueRefNoByID_Class> GetUniqueRefNoByID(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYFOLLOW"].QueryDefs["GetUniqueRefNoByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PregnancyFollow.GetUniqueRefNoByID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PregnancyFollow.GetUniqueRefNoByID_Class> GetUniqueRefNoByID(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYFOLLOW"].QueryDefs["GetUniqueRefNoByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PregnancyFollow.GetUniqueRefNoByID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Tansiyon
    /// </summary>
        public bool? Tension
        {
            get { return (bool?)this["TENSION"]; }
            set { this["TENSION"] = value; }
        }

    /// <summary>
    /// Gebelik Şekeri
    /// </summary>
        public bool? GestationalDiabetes
        {
            get { return (bool?)this["GESTATIONALDIABETES"]; }
            set { this["GESTATIONALDIABETES"] = value; }
        }

    /// <summary>
    /// Damar Hastalıkları
    /// </summary>
        public bool? CardiovascularDiseases
        {
            get { return (bool?)this["CARDIOVASCULARDISEASES"]; }
            set { this["CARDIOVASCULARDISEASES"] = value; }
        }

    /// <summary>
    /// Anemi
    /// </summary>
        public bool? Anemia
        {
            get { return (bool?)this["ANEMIA"]; }
            set { this["ANEMIA"] = value; }
        }

    /// <summary>
    /// Bulantı
    /// </summary>
        public bool? Nausea
        {
            get { return (bool?)this["NAUSEA"]; }
            set { this["NAUSEA"] = value; }
        }

    /// <summary>
    /// Kanama
    /// </summary>
        public bool? Bleeding
        {
            get { return (bool?)this["BLEEDING"]; }
            set { this["BLEEDING"] = value; }
        }

    /// <summary>
    /// Anne Kilo
    /// </summary>
        public int? MotherWeight
        {
            get { return (int?)this["MOTHERWEIGHT"]; }
            set { this["MOTHERWEIGHT"] = value; }
        }

    /// <summary>
    /// Gebelik Hastalıkları Açıklama
    /// </summary>
        public string PregnancyDiseasesDescription
        {
            get { return (string)this["PREGNANCYDISEASESDESCRIPTION"]; }
            set { this["PREGNANCYDISEASESDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Hemoglobin
    /// </summary>
        public double? Hemoglobin
        {
            get { return (double?)this["HEMOGLOBIN"]; }
            set { this["HEMOGLOBIN"] = value; }
        }

    /// <summary>
    /// Pretibial Ödem
    /// </summary>
        public string PretibialEdema
        {
            get { return (string)this["PRETIBIALEDEMA"]; }
            set { this["PRETIBIALEDEMA"] = value; }
        }

    /// <summary>
    /// Açıklık
    /// </summary>
        public string Openness
        {
            get { return (string)this["OPENNESS"]; }
            set { this["OPENNESS"] = value; }
        }

    /// <summary>
    /// Varis
    /// </summary>
        public string Varicose
        {
            get { return (string)this["VARICOSE"]; }
            set { this["VARICOSE"] = value; }
        }

    /// <summary>
    /// Pelvis Durumu
    /// </summary>
        public string PelvicCondition
        {
            get { return (string)this["PELVICCONDITION"]; }
            set { this["PELVICCONDITION"] = value; }
        }

    /// <summary>
    /// Ultrason Bulguları
    /// </summary>
        public string UltrasonicFinding
        {
            get { return (string)this["ULTRASONICFINDING"]; }
            set { this["ULTRASONICFINDING"] = value; }
        }

    /// <summary>
    /// Şikayetler
    /// </summary>
        public string Complaints
        {
            get { return (string)this["COMPLAINTS"]; }
            set { this["COMPLAINTS"] = value; }
        }

        public string InformerName
        {
            get { return (string)this["INFORMERNAME"]; }
            set { this["INFORMERNAME"] = value; }
        }

        public string InformerPhone
        {
            get { return (string)this["INFORMERPHONE"]; }
            set { this["INFORMERPHONE"] = value; }
        }

        public SKRSIdrardaProtein UrinaryProtein
        {
            get { return (SKRSIdrardaProtein)((ITTObject)this).GetParent("URINARYPROTEIN"); }
            set { this["URINARYPROTEIN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKonjenitalAnomaliliDogumVarligi CongenitalAnomalies
        {
            get { return (SKRSKonjenitalAnomaliliDogumVarligi)((ITTObject)this).GetParent("CONGENITALANOMALIES"); }
            set { this["CONGENITALANOMALIES"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKadinSagligiIslemleri WomansHealthOperations
        {
            get { return (SKRSKadinSagligiIslemleri)((ITTObject)this).GetParent("WOMANSHEALTHOPERATIONS"); }
            set { this["WOMANSHEALTHOPERATIONS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSGestasyonelDiyabetTaramasi SkrsGestationalDiabetes
        {
            get { return (SKRSGestasyonelDiyabetTaramasi)((ITTObject)this).GetParent("SKRSGESTATIONALDIABETES"); }
            set { this["SKRSGESTATIONALDIABETES"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSGebelikteRiskDurumu RiskSituation
        {
            get { return (SKRSGebelikteRiskDurumu)((ITTObject)this).GetParent("RISKSITUATION"); }
            set { this["RISKSITUATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSDemirLojistigiveDestegi IronSupplements
        {
            get { return (SKRSDemirLojistigiveDestegi)((ITTObject)this).GetParent("IRONSUPPLEMENTS"); }
            set { this["IRONSUPPLEMENTS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSDVitaminiLojistigiveDestegi VitaminDSupplements
        {
            get { return (SKRSDVitaminiLojistigiveDestegi)((ITTObject)this).GetParent("VITAMINDSUPPLEMENTS"); }
            set { this["VITAMINDSUPPLEMENTS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKacinciGebeIzlem WhichPregnancyFollow
        {
            get { return (SKRSKacinciGebeIzlem)((ITTObject)this).GetParent("WHICHPREGNANCYFOLLOW"); }
            set { this["WHICHPREGNANCYFOLLOW"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSGebelikteRiskFaktorleri RiskFactors
        {
            get { return (SKRSGebelikteRiskFaktorleri)((ITTObject)this).GetParent("RISKFACTORS"); }
            set { this["RISKFACTORS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Pregnancy Pregnancy
        {
            get { return (Pregnancy)((ITTObject)this).GetParent("PREGNANCY"); }
            set { this["PREGNANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateObligedRiskFactorsCollection()
        {
            _ObligedRiskFactors = new ObligedRiskFactors.ChildObligedRiskFactorsCollection(this, new Guid("9ac92e62-c531-4aef-a782-325227c0355f"));
            ((ITTChildObjectCollection)_ObligedRiskFactors).GetChildren();
        }

        protected ObligedRiskFactors.ChildObligedRiskFactorsCollection _ObligedRiskFactors = null;
        public ObligedRiskFactors.ChildObligedRiskFactorsCollection ObligedRiskFactors
        {
            get
            {
                if (_ObligedRiskFactors == null)
                    CreateObligedRiskFactorsCollection();
                return _ObligedRiskFactors;
            }
        }

        virtual protected void CreatePregnancyComplicationsCollection()
        {
            _PregnancyComplications = new PregnancyComplications.ChildPregnancyComplicationsCollection(this, new Guid("ead6082d-5e9f-42b9-aae7-1615dbb58671"));
            ((ITTChildObjectCollection)_PregnancyComplications).GetChildren();
        }

        protected PregnancyComplications.ChildPregnancyComplicationsCollection _PregnancyComplications = null;
        public PregnancyComplications.ChildPregnancyComplicationsCollection PregnancyComplications
        {
            get
            {
                if (_PregnancyComplications == null)
                    CreatePregnancyComplicationsCollection();
                return _PregnancyComplications;
            }
        }

        virtual protected void CreatePregnancyDangerSignCollection()
        {
            _PregnancyDangerSign = new PregnancyDangerSign.ChildPregnancyDangerSignCollection(this, new Guid("e38cb831-6afe-43be-9d0e-dba1aef3a39d"));
            ((ITTChildObjectCollection)_PregnancyDangerSign).GetChildren();
        }

        protected PregnancyDangerSign.ChildPregnancyDangerSignCollection _PregnancyDangerSign = null;
        public PregnancyDangerSign.ChildPregnancyDangerSignCollection PregnancyDangerSign
        {
            get
            {
                if (_PregnancyDangerSign == null)
                    CreatePregnancyDangerSignCollection();
                return _PregnancyDangerSign;
            }
        }

        virtual protected void CreateFetusFollowCollection()
        {
            _FetusFollow = new FetusFollow.ChildFetusFollowCollection(this, new Guid("73c23e84-ad7d-4e1b-b0d6-f1bfb3cc82b0"));
            ((ITTChildObjectCollection)_FetusFollow).GetChildren();
        }

        protected FetusFollow.ChildFetusFollowCollection _FetusFollow = null;
        public FetusFollow.ChildFetusFollowCollection FetusFollow
        {
            get
            {
                if (_FetusFollow == null)
                    CreateFetusFollowCollection();
                return _FetusFollow;
            }
        }

        virtual protected void CreateWomanSpecialityObjectCollection()
        {
            _WomanSpecialityObject = new WomanSpecialityObject.ChildWomanSpecialityObjectCollection(this, new Guid("713b16bd-f006-45a5-8830-4257568df2fc"));
            ((ITTChildObjectCollection)_WomanSpecialityObject).GetChildren();
        }

        protected WomanSpecialityObject.ChildWomanSpecialityObjectCollection _WomanSpecialityObject = null;
        public WomanSpecialityObject.ChildWomanSpecialityObjectCollection WomanSpecialityObject
        {
            get
            {
                if (_WomanSpecialityObject == null)
                    CreateWomanSpecialityObjectCollection();
                return _WomanSpecialityObject;
            }
        }

        protected PregnancyFollow(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PregnancyFollow(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PregnancyFollow(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PregnancyFollow(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PregnancyFollow(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PREGNANCYFOLLOW", dataRow) { }
        protected PregnancyFollow(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PREGNANCYFOLLOW", dataRow, isImported) { }
        public PregnancyFollow(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PregnancyFollow(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PregnancyFollow() : base() { }

    }
}