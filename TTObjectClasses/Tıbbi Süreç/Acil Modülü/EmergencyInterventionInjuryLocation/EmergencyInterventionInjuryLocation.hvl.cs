
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EmergencyInterventionInjuryLocation")] 

    /// <summary>
    /// Acil Hasta Yaralanma Tespit Formu
    /// </summary>
    public  partial class EmergencyInterventionInjuryLocation : EpisodeAction
    {
        public class EmergencyInterventionInjuryLocationList : TTObjectCollection<EmergencyInterventionInjuryLocation> { }
                    
        public class ChildEmergencyInterventionInjuryLocationCollection : TTObject.TTChildObjectCollection<EmergencyInterventionInjuryLocation>
        {
            public ChildEmergencyInterventionInjuryLocationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEmergencyInterventionInjuryLocationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEmergencyInterventionInjuryLocation_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? EmergencyIntervention
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EMERGENCYINTERVENTION"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

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

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Kurum
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["KURUM"]);
                }
            }

            public int? HowOldSoldier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOWOLDSOLDIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["HOWOLDSOLDIER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? HowManyDaysInOperation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOWMANYDAYSINOPERATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["HOWMANYDAYSINOPERATION"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string CityOfInjured
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CITYOFINJURED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["CITYOFINJURED"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Asy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["TYPEOFINJURYASY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Eyp
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EYP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["TYPEOFINJURYEYP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Diger
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIGER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["TYPEOFINJURYOTHER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string HowWasInjury
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOWWASINJURY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["HOWWASINJURY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? WearingProtectiveCloting
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEARINGPROTECTIVECLOTING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["WEARINGPROTECTIVECLOTING"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? WearingGoggles
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEARINGGOGGLES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["WEARINGGOGGLES"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? WearingProtectiveHeadgear
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEARINGPROTECTIVEHEADGEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["WEARINGPROTECTIVEHEADGEAR"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? InjuryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INJURYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["INJURYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? FirstAidDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRSTAIDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["FIRSTAIDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? FirstRespondersWhoHimself
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRSTRESPONDERSWHOHIMSELF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["FIRSTRESPONDERSWHOHIMSELF"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? FirstRespondersWhoFriend
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRSTRESPONDERSWHOFRIEND"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["FIRSTRESPONDERSWHOFRIEND"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? FirstRespondersWhoParamedic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRSTRESPONDERSWHOPARAMEDIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["FIRSTRESPONDERSWHOPARAMEDIC"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? FirstRespondersWhoDoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRSTRESPONDERSWHODOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["FIRSTRESPONDERSWHODOCTOR"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string EvacuationTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EVACUATIONTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["EVACUATIONTIME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? Turnikekullanilmis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TURNIKEKULLANILMIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["ISUSEDTOURNIQUET"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Turnikekol
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TURNIKEKOL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["TOURNIQUEUSEDARM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Turnikebacak
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TURNIKEBACAK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["TOURNIQUEUSEDLEG"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string GlaskowKomaSkoru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GLASKOWKOMASKORU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["GLASKOWKOMASKORU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? Kanreplasmanivar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KANREPLASMANIVAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["ISTHEREBLOODREPLACEMENT"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? Kanreplasmanimiktari
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KANREPLASMANIMIKTARI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["AMOUNTOFBLOODREPLACEMENT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public object SurgicalInterventions
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGICALINTERVENTIONS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["SURGICALINTERVENTIONS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public ConditionOfInjured? ConditionOfInjured
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONDITIONOFINJURED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["CONDITIONOFINJURED"].DataType;
                    return (ConditionOfInjured?)(int)dataType.ConvertValue(val);
                }
            }

            public object InjuryLocationImage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INJURYLOCATIONIMAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].AllPropertyDefs["INJURYLOCATIONIMAGE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetEmergencyInterventionInjuryLocation_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmergencyInterventionInjuryLocation_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmergencyInterventionInjuryLocation_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("f2d26b2f-629d-464f-80f9-cd78f70193a1"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("9cbb5f0e-9d13-439e-ae23-1c1f73e38517"); } }
        }

        public static BindingList<EmergencyInterventionInjuryLocation.GetEmergencyInterventionInjuryLocation_Class> GetEmergencyInterventionInjuryLocation(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].QueryDefs["GetEmergencyInterventionInjuryLocation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<EmergencyInterventionInjuryLocation.GetEmergencyInterventionInjuryLocation_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EmergencyInterventionInjuryLocation.GetEmergencyInterventionInjuryLocation_Class> GetEmergencyInterventionInjuryLocation(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATION"].QueryDefs["GetEmergencyInterventionInjuryLocation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<EmergencyInterventionInjuryLocation.GetEmergencyInterventionInjuryLocation_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Yarlanma Şekli ASY
    /// </summary>
        public bool? TypeOfInjuryASY
        {
            get { return (bool?)this["TYPEOFINJURYASY"]; }
            set { this["TYPEOFINJURYASY"] = value; }
        }

    /// <summary>
    /// Yarlanma Şekli EYP
    /// </summary>
        public bool? TypeOfInjuryEYP
        {
            get { return (bool?)this["TYPEOFINJURYEYP"]; }
            set { this["TYPEOFINJURYEYP"] = value; }
        }

    /// <summary>
    /// Yaralanma Şekli Diğer
    /// </summary>
        public bool? TypeOfInjuryOTHER
        {
            get { return (bool?)this["TYPEOFINJURYOTHER"]; }
            set { this["TYPEOFINJURYOTHER"] = value; }
        }

    /// <summary>
    /// Koruyucu Kıyafet Giymiş
    /// </summary>
        public bool? WearingProtectiveCloting
        {
            get { return (bool?)this["WEARINGPROTECTIVECLOTING"]; }
            set { this["WEARINGPROTECTIVECLOTING"] = value; }
        }

    /// <summary>
    /// Koruyucu Başlık Giymiş
    /// </summary>
        public bool? WearingProtectiveHeadgear
        {
            get { return (bool?)this["WEARINGPROTECTIVEHEADGEAR"]; }
            set { this["WEARINGPROTECTIVEHEADGEAR"] = value; }
        }

    /// <summary>
    /// Koruyucu Gözlük Giymiş
    /// </summary>
        public bool? WearingGoggles
        {
            get { return (bool?)this["WEARINGGOGGLES"]; }
            set { this["WEARINGGOGGLES"] = value; }
        }

    /// <summary>
    /// Turnike Kullanılmış
    /// </summary>
        public YesNoEnum? IsUsedTourniquet
        {
            get { return (YesNoEnum?)(int?)this["ISUSEDTOURNIQUET"]; }
            set { this["ISUSEDTOURNIQUET"] = value; }
        }

    /// <summary>
    /// Turnike Kolda Kullanılmış
    /// </summary>
        public bool? TourniqueUsedArm
        {
            get { return (bool?)this["TOURNIQUEUSEDARM"]; }
            set { this["TOURNIQUEUSEDARM"] = value; }
        }

    /// <summary>
    /// Turnike Bacakta Kullanılmış
    /// </summary>
        public bool? TourniqueUsedLeg
        {
            get { return (bool?)this["TOURNIQUEUSEDLEG"]; }
            set { this["TOURNIQUEUSEDLEG"] = value; }
        }

    /// <summary>
    /// Kan Replacemanı Var
    /// </summary>
        public YesNoEnum? IsThereBloodReplacement
        {
            get { return (YesNoEnum?)(int?)this["ISTHEREBLOODREPLACEMENT"]; }
            set { this["ISTHEREBLOODREPLACEMENT"] = value; }
        }

    /// <summary>
    /// Kan Replasmanı Miktarı(Ünite)
    /// </summary>
        public int? AmountOfBloodReplacement
        {
            get { return (int?)this["AMOUNTOFBLOODREPLACEMENT"]; }
            set { this["AMOUNTOFBLOODREPLACEMENT"] = value; }
        }

    /// <summary>
    /// İlk Müdahaleyi Yapan Kendisi
    /// </summary>
        public bool? FirstRespondersWhoHimself
        {
            get { return (bool?)this["FIRSTRESPONDERSWHOHIMSELF"]; }
            set { this["FIRSTRESPONDERSWHOHIMSELF"] = value; }
        }

    /// <summary>
    /// İlk Müdahaleyi Yapan Arkadaşı
    /// </summary>
        public bool? FirstRespondersWhoFriend
        {
            get { return (bool?)this["FIRSTRESPONDERSWHOFRIEND"]; }
            set { this["FIRSTRESPONDERSWHOFRIEND"] = value; }
        }

    /// <summary>
    /// İlk Müdahaleyi Yapan Paramedik
    /// </summary>
        public bool? FirstRespondersWhoParamedic
        {
            get { return (bool?)this["FIRSTRESPONDERSWHOPARAMEDIC"]; }
            set { this["FIRSTRESPONDERSWHOPARAMEDIC"] = value; }
        }

    /// <summary>
    /// İlk Müdahaleyi Yapan Tabip
    /// </summary>
        public bool? FirstRespondersWhoDoctor
        {
            get { return (bool?)this["FIRSTRESPONDERSWHODOCTOR"]; }
            set { this["FIRSTRESPONDERSWHODOCTOR"] = value; }
        }

    /// <summary>
    /// Yaralının Durumu
    /// </summary>
        public ConditionOfInjured? ConditionOfInjured
        {
            get { return (ConditionOfInjured?)(int?)this["CONDITIONOFINJURED"]; }
            set { this["CONDITIONOFINJURED"] = value; }
        }

    /// <summary>
    /// Kaç Yıllık XXXXXX
    /// </summary>
        public int? HowOldSoldier
        {
            get { return (int?)this["HOWOLDSOLDIER"]; }
            set { this["HOWOLDSOLDIER"] = value; }
        }

    /// <summary>
    /// Kaç Gündür Operasyonda
    /// </summary>
        public int? HowManyDaysInOperation
        {
            get { return (int?)this["HOWMANYDAYSINOPERATION"]; }
            set { this["HOWMANYDAYSINOPERATION"] = value; }
        }

    /// <summary>
    /// Yaralandığı Yer(il/İlçe)
    /// </summary>
        public string CityOfInjured
        {
            get { return (string)this["CITYOFINJURED"]; }
            set { this["CITYOFINJURED"] = value; }
        }

    /// <summary>
    /// Olayın Oluş Şekli(Çatışma,Kaza,İntihar)
    /// </summary>
        public string HowWasInjury
        {
            get { return (string)this["HOWWASINJURY"]; }
            set { this["HOWWASINJURY"] = value; }
        }

    /// <summary>
    /// Yaralanma Tarih ve Saati
    /// </summary>
        public DateTime? InjuryDate
        {
            get { return (DateTime?)this["INJURYDATE"]; }
            set { this["INJURYDATE"] = value; }
        }

    /// <summary>
    /// İlk Müdahale Tarih ve Saati
    /// </summary>
        public DateTime? FirstAidDate
        {
            get { return (DateTime?)this["FIRSTAIDDATE"]; }
            set { this["FIRSTAIDDATE"] = value; }
        }

    /// <summary>
    /// Tahliye Süresi
    /// </summary>
        public string EvacuationTime
        {
            get { return (string)this["EVACUATIONTIME"]; }
            set { this["EVACUATIONTIME"] = value; }
        }

    /// <summary>
    /// Glaskow Koma Skoru
    /// </summary>
        public string GlaskowKomaSkoru
        {
            get { return (string)this["GLASKOWKOMASKORU"]; }
            set { this["GLASKOWKOMASKORU"] = value; }
        }

    /// <summary>
    /// Yapılan Cerrahi Müdahele(Kısa Adı)
    /// </summary>
        public object SurgicalInterventions
        {
            get { return (object)this["SURGICALINTERVENTIONS"]; }
            set { this["SURGICALINTERVENTIONS"] = value; }
        }

    /// <summary>
    /// Yaralanma Bölgesi Şekli
    /// </summary>
        public object InjuryLocationImage
        {
            get { return (object)this["INJURYLOCATIONIMAGE"]; }
            set { this["INJURYLOCATIONIMAGE"] = value; }
        }

        public EmergencyIntervention EmergencyIntervention
        {
            get { return (EmergencyIntervention)((ITTObject)this).GetParent("EMERGENCYINTERVENTION"); }
            set { this["EMERGENCYINTERVENTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateInjuryLocationGridCollection()
        {
            _InjuryLocationGrid = new EmergencyInterventionInjuryLocationGrid.ChildEmergencyInterventionInjuryLocationGridCollection(this, new Guid("7d193f82-40c1-445a-ac2e-210dfbdffb91"));
            ((ITTChildObjectCollection)_InjuryLocationGrid).GetChildren();
        }

        protected EmergencyInterventionInjuryLocationGrid.ChildEmergencyInterventionInjuryLocationGridCollection _InjuryLocationGrid = null;
        public EmergencyInterventionInjuryLocationGrid.ChildEmergencyInterventionInjuryLocationGridCollection InjuryLocationGrid
        {
            get
            {
                if (_InjuryLocationGrid == null)
                    CreateInjuryLocationGridCollection();
                return _InjuryLocationGrid;
            }
        }

        protected EmergencyInterventionInjuryLocation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EmergencyInterventionInjuryLocation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EmergencyInterventionInjuryLocation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EmergencyInterventionInjuryLocation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EmergencyInterventionInjuryLocation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EMERGENCYINTERVENTIONINJURYLOCATION", dataRow) { }
        protected EmergencyInterventionInjuryLocation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EMERGENCYINTERVENTIONINJURYLOCATION", dataRow, isImported) { }
        public EmergencyInterventionInjuryLocation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EmergencyInterventionInjuryLocation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EmergencyInterventionInjuryLocation() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}