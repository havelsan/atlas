
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Pregnancy")] 

    public  partial class Pregnancy : TTObject
    {
        public class PregnancyList : TTObjectCollection<Pregnancy> { }
                    
        public class ChildPregnancyCollection : TTObject.TTChildObjectCollection<Pregnancy>
        {
            public ChildPregnancyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPregnancyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPreviousPregnanciesByPatient_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? BirthTerminationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHTERMINATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCY"].AllPropertyDefs["BIRTHTERMINATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public PregnancyPhysiologyEnum? Pregnancyphysiologytext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREGNANCYPHYSIOLOGYTEXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCY"].AllPropertyDefs["PREGNANCYPHYSIOLOGY"].DataType;
                    return (PregnancyPhysiologyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string PregnancyPhysiologyInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREGNANCYPHYSIOLOGYINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCY"].AllPropertyDefs["PREGNANCYPHYSIOLOGYINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PregnancyHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREGNANCYHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCY"].AllPropertyDefs["PREGNANCYHISTORY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Birthhelper
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHHELPER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSDOGUMAYARDIMEDEN"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Birthlocation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHLOCATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSDOGUMUNGERCEKLESTIGIYER"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Birthtype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSDOGUMYONTEMI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cesareanindication
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CESAREANINDICATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSEZARYANENDIKASYONLAR"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPreviousPregnanciesByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPreviousPregnanciesByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPreviousPregnanciesByPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllPregnanciesByPatient_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? BirthTerminationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHTERMINATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCY"].AllPropertyDefs["BIRTHTERMINATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public PregnancyPhysiologyEnum? PregnancyPhysiology
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREGNANCYPHYSIOLOGY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCY"].AllPropertyDefs["PREGNANCYPHYSIOLOGY"].DataType;
                    return (PregnancyPhysiologyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string PregnancyPhysiologyInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREGNANCYPHYSIOLOGYINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCY"].AllPropertyDefs["PREGNANCYPHYSIOLOGYINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PregnancyHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREGNANCYHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCY"].AllPropertyDefs["PREGNANCYHISTORY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Birthhelper
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHHELPER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSDOGUMAYARDIMEDEN"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Birthlocation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHLOCATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSDOGUMUNGERCEKLESTIGIYER"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Birthtype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSDOGUMYONTEMI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cesareanindication
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CESAREANINDICATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSEZARYANENDIKASYONLAR"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAllPregnanciesByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllPregnanciesByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllPregnanciesByPatient_Class() : base() { }
        }

    /// <summary>
    /// Hasta Geçmiş Gebelik Bilgileri
    /// </summary>
        public static BindingList<Pregnancy.GetPreviousPregnanciesByPatient_Class> GetPreviousPregnanciesByPatient(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PREGNANCY"].QueryDefs["GetPreviousPregnanciesByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<Pregnancy.GetPreviousPregnanciesByPatient_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Hasta Geçmiş Gebelik Bilgileri
    /// </summary>
        public static BindingList<Pregnancy.GetPreviousPregnanciesByPatient_Class> GetPreviousPregnanciesByPatient(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PREGNANCY"].QueryDefs["GetPreviousPregnanciesByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<Pregnancy.GetPreviousPregnanciesByPatient_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hastanın Tüm Gebelikleri
    /// </summary>
        public static BindingList<Pregnancy.GetAllPregnanciesByPatient_Class> GetAllPregnanciesByPatient(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PREGNANCY"].QueryDefs["GetAllPregnanciesByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<Pregnancy.GetAllPregnanciesByPatient_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Hastanın Tüm Gebelikleri
    /// </summary>
        public static BindingList<Pregnancy.GetAllPregnanciesByPatient_Class> GetAllPregnanciesByPatient(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PREGNANCY"].QueryDefs["GetAllPregnanciesByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<Pregnancy.GetAllPregnanciesByPatient_Class>(objectContext, queryDef, paramList, pi);
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
    /// Gebelik Tipi
    /// </summary>
        public PregnancyTypeEnum? PregnancyType
        {
            get { return (PregnancyTypeEnum?)(int?)this["PREGNANCYTYPE"]; }
            set { this["PREGNANCYTYPE"] = value; }
        }

    /// <summary>
    /// Gebelik Notu
    /// </summary>
        public string PregnancyInformation
        {
            get { return (string)this["PREGNANCYINFORMATION"]; }
            set { this["PREGNANCYINFORMATION"] = value; }
        }

    /// <summary>
    /// Gebelik Yaş Riski
    /// </summary>
        public GestationalAgeEnum? RiskOfGestationalAge
        {
            get { return (GestationalAgeEnum?)(int?)this["RISKOFGESTATIONALAGE"]; }
            set { this["RISKOFGESTATIONALAGE"] = value; }
        }

    /// <summary>
    /// Gebelik Fizyolojisi
    /// </summary>
        public PregnancyPhysiologyEnum? PregnancyPhysiology
        {
            get { return (PregnancyPhysiologyEnum?)(int?)this["PREGNANCYPHYSIOLOGY"]; }
            set { this["PREGNANCYPHYSIOLOGY"] = value; }
        }

    /// <summary>
    /// Gebelik Fizyolojisi Açıklaması
    /// </summary>
        public string PregnancyPhysiologyInfo
        {
            get { return (string)this["PREGNANCYPHYSIOLOGYINFO"]; }
            set { this["PREGNANCYPHYSIOLOGYINFO"] = value; }
        }

    /// <summary>
    /// Doğum Sonlanma Tarihi
    /// </summary>
        public DateTime? BirthTerminationDate
        {
            get { return (DateTime?)this["BIRTHTERMINATIONDATE"]; }
            set { this["BIRTHTERMINATIONDATE"] = value; }
        }

    /// <summary>
    /// Gebelik Öyküsü
    /// </summary>
        public string PregnancyHistory
        {
            get { return (string)this["PREGNANCYHISTORY"]; }
            set { this["PREGNANCYHISTORY"] = value; }
        }

    /// <summary>
    /// Tahmini Doğum Tarihi
    /// </summary>
        public DateTime? EstimatedBirthDate
        {
            get { return (DateTime?)this["ESTIMATEDBIRTHDATE"]; }
            set { this["ESTIMATEDBIRTHDATE"] = value; }
        }

    /// <summary>
    /// Günleme Tarihi
    /// </summary>
        public DateTime? MeasuredPregnancyDate
        {
            get { return (DateTime?)this["MEASUREDPREGNANCYDATE"]; }
            set { this["MEASUREDPREGNANCYDATE"] = value; }
        }

    /// <summary>
    /// Hasta IVF ile Gebe Kaldıysa Blastokist Transfer Tarihi
    /// </summary>
        public DateTime? BlastocystTransferDate
        {
            get { return (DateTime?)this["BLASTOCYSTTRANSFERDATE"]; }
            set { this["BLASTOCYSTTRANSFERDATE"] = value; }
        }

    /// <summary>
    /// Hasta IVF ile Gebe Kaldıysa Yumurta Toplama Tarihi
    /// </summary>
        public DateTime? EggCollectionDate
        {
            get { return (DateTime?)this["EGGCOLLECTIONDATE"]; }
            set { this["EGGCOLLECTIONDATE"] = value; }
        }

    /// <summary>
    /// Hasta IVF ile Gebe Kaldıysa Embriyo Transfer Tarihi
    /// </summary>
        public DateTime? EmbryoTransferDate
        {
            get { return (DateTime?)this["EMBRYOTRANSFERDATE"]; }
            set { this["EMBRYOTRANSFERDATE"] = value; }
        }

    /// <summary>
    /// Günleme Günü
    /// </summary>
        public int? MeasuredPregnancyDay
        {
            get { return (int?)this["MEASUREDPREGNANCYDAY"]; }
            set { this["MEASUREDPREGNANCYDAY"] = value; }
        }

    /// <summary>
    /// Günleme Haftası
    /// </summary>
        public int? MeasuredPregnancyWeek
        {
            get { return (int?)this["MEASUREDPREGNANCYWEEK"]; }
            set { this["MEASUREDPREGNANCYWEEK"] = value; }
        }

    /// <summary>
    /// Yeni doğan bebek sayısı
    /// </summary>
        public int? NumberOfNewborns
        {
            get { return (int?)this["NUMBEROFNEWBORNS"]; }
            set { this["NUMBEROFNEWBORNS"] = value; }
        }

    /// <summary>
    /// Ölü doğan bebek sayısı
    /// </summary>
        public int? NumberOfStillbornBabies
        {
            get { return (int?)this["NUMBEROFSTILLBORNBABIES"]; }
            set { this["NUMBEROFSTILLBORNBABIES"] = value; }
        }

        public WomanSpecialityObject StarterWomanSpecialityObject
        {
            get { return (WomanSpecialityObject)((ITTObject)this).GetParent("STARTERWOMANSPECIALITYOBJECT"); }
            set { this["STARTERWOMANSPECIALITYOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doğuma Yardım Eden
    /// </summary>
        public SKRSDogumaYardimEden BirthHelper
        {
            get { return (SKRSDogumaYardimEden)((ITTObject)this).GetParent("BIRTHHELPER"); }
            set { this["BIRTHHELPER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doğumun Gerçekleştiği Yer
    /// </summary>
        public SKRSDogumunGerceklestigiYer BirthLocation
        {
            get { return (SKRSDogumunGerceklestigiYer)((ITTObject)this).GetParent("BIRTHLOCATION"); }
            set { this["BIRTHLOCATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doğum Yöntemi
    /// </summary>
        public SKRSDogumYontemi BirthType
        {
            get { return (SKRSDogumYontemi)((ITTObject)this).GetParent("BIRTHTYPE"); }
            set { this["BIRTHTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sezaryan Endikasyonu
    /// </summary>
        public SKRSSezaryanEndikasyonlar CesareanIndication
        {
            get { return (SKRSSezaryanEndikasyonlar)((ITTObject)this).GetParent("CESAREANINDICATION"); }
            set { this["CESAREANINDICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePregnancyNotificationCollection()
        {
            _PregnancyNotification = new PregnancyNotification.ChildPregnancyNotificationCollection(this, new Guid("f98c6606-c0cb-47a6-8cb2-d87e8ac79875"));
            ((ITTChildObjectCollection)_PregnancyNotification).GetChildren();
        }

        protected PregnancyNotification.ChildPregnancyNotificationCollection _PregnancyNotification = null;
        public PregnancyNotification.ChildPregnancyNotificationCollection PregnancyNotification
        {
            get
            {
                if (_PregnancyNotification == null)
                    CreatePregnancyNotificationCollection();
                return _PregnancyNotification;
            }
        }

        virtual protected void CreatePregnancyResultsCollection()
        {
            _PregnancyResults = new PregnancyResult.ChildPregnancyResultCollection(this, new Guid("013bf560-452e-435d-939b-ea9da09baea0"));
            ((ITTChildObjectCollection)_PregnancyResults).GetChildren();
        }

        protected PregnancyResult.ChildPregnancyResultCollection _PregnancyResults = null;
        public PregnancyResult.ChildPregnancyResultCollection PregnancyResults
        {
            get
            {
                if (_PregnancyResults == null)
                    CreatePregnancyResultsCollection();
                return _PregnancyResults;
            }
        }

        virtual protected void CreatePregnancyFollowsCollection()
        {
            _PregnancyFollows = new PregnancyFollow.ChildPregnancyFollowCollection(this, new Guid("0dcc3582-a695-48a5-9137-be5d98a8cbe2"));
            ((ITTChildObjectCollection)_PregnancyFollows).GetChildren();
        }

        protected PregnancyFollow.ChildPregnancyFollowCollection _PregnancyFollows = null;
        public PregnancyFollow.ChildPregnancyFollowCollection PregnancyFollows
        {
            get
            {
                if (_PregnancyFollows == null)
                    CreatePregnancyFollowsCollection();
                return _PregnancyFollows;
            }
        }

        virtual protected void CreateIndicationReasonsCollection()
        {
            _IndicationReasons = new IndicationReason.ChildIndicationReasonCollection(this, new Guid("b018e0fa-2074-440a-8c80-c291a5b1473e"));
            ((ITTChildObjectCollection)_IndicationReasons).GetChildren();
        }

        protected IndicationReason.ChildIndicationReasonCollection _IndicationReasons = null;
        public IndicationReason.ChildIndicationReasonCollection IndicationReasons
        {
            get
            {
                if (_IndicationReasons == null)
                    CreateIndicationReasonsCollection();
                return _IndicationReasons;
            }
        }

        virtual protected void CreatePregnancyComplicationsCollection()
        {
            _PregnancyComplications = new PregnancyComplications.ChildPregnancyComplicationsCollection(this, new Guid("75f3c7c2-bc82-4c6a-9a77-89ba34adebcf"));
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

        virtual protected void CreateObstetricInformationCollection()
        {
            _ObstetricInformation = new RegularObstetric.ChildRegularObstetricCollection(this, new Guid("83f6f843-13ed-42ae-ab9c-5eff7148e91f"));
            ((ITTChildObjectCollection)_ObstetricInformation).GetChildren();
        }

        protected RegularObstetric.ChildRegularObstetricCollection _ObstetricInformation = null;
    /// <summary>
    /// Child collection for Hangi Gebeliğin Doğumu Olduğu Bilgisi
    /// </summary>
        public RegularObstetric.ChildRegularObstetricCollection ObstetricInformation
        {
            get
            {
                if (_ObstetricInformation == null)
                    CreateObstetricInformationCollection();
                return _ObstetricInformation;
            }
        }

        protected Pregnancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Pregnancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Pregnancy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Pregnancy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Pregnancy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PREGNANCY", dataRow) { }
        protected Pregnancy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PREGNANCY", dataRow, isImported) { }
        public Pregnancy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Pregnancy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Pregnancy() : base() { }

    }
}