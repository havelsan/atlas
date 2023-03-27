
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseBedProcedure")] 

    public  partial class BaseBedProcedure : BedProcedureWithoutBed
    {
        public class BaseBedProcedureList : TTObjectCollection<BaseBedProcedure> { }
                    
        public class ChildBaseBedProcedureCollection : TTObject.TTChildObjectCollection<BaseBedProcedure>
        {
            public ChildBaseBedProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseBedProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetLastUsedBedByEpisode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Clinic
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLINIC"]);
                }
            }

            public OLAP_GetLastUsedBedByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetLastUsedBedByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetLastUsedBedByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetEpisodeFromUsedBed_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Ward
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["WARD"]);
                }
            }

            public Guid? EpisodeAction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEACTION"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public OLAP_GetEpisodeFromUsedBed_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetEpisodeFromUsedBed_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetEpisodeFromUsedBed_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetUsedBedByDate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Ward
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["WARD"]);
                }
            }

            public Guid? EpisodeAction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEACTION"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public DateTime? BedInPatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BEDINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEBEDPROCEDURE"].AllPropertyDefs["BEDINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? BedDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BEDDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEBEDPROCEDURE"].AllPropertyDefs["BEDDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetUsedBedByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetUsedBedByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetUsedBedByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_HASTA_YATAK_Class : TTReportNqlObject 
        {
            public Guid? Hasta_yatak_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_YATAK_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Hasta_basvuru_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_BASVURU_KODU"]);
                }
            }

            public Guid? Yatak_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["YATAK_KODU"]);
                }
            }

            public DateTime? Baslama_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASLAMA_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEBEDPROCEDURE"].AllPropertyDefs["BEDINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Bitis_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BITIS_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEBEDPROCEDURE"].AllPropertyDefs["BEDDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Ekleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public Object Guncelleme_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                }
            }

            public Object Guncelleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_HASTA_YATAK_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_HASTA_YATAK_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_HASTA_YATAK_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_ANLIK_YATAN_HASTA_Class : TTReportNqlObject 
        {
            public Guid? Anlik_yatan_hasta_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ANLIK_YATAN_HASTA_KODU"]);
                }
            }

            public Guid? Hasta_basvuru_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_BASVURU_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Hekim_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HEKIM_KODU"]);
                }
            }

            public long? Yatis_protokol_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATIS_PROTOKOL_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Birim_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BIRIM_KODU"]);
                }
            }

            public Guid? Yatak_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["YATAK_KODU"]);
                }
            }

            public Guid? Oda_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ODA_KODU"]);
                }
            }

            public DateTime? Yatis_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATIS_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEBEDPROCEDURE"].AllPropertyDefs["BEDINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Ekleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public Object Guncelleme_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                }
            }

            public Object Guncelleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_ANLIK_YATAN_HASTA_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_ANLIK_YATAN_HASTA_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_ANLIK_YATAN_HASTA_Class() : base() { }
        }

        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        public static BindingList<BaseBedProcedure.OLAP_GetLastUsedBedByEpisode_Class> OLAP_GetLastUsedBedByEpisode(string EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEBEDPROCEDURE"].QueryDefs["OLAP_GetLastUsedBedByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<BaseBedProcedure.OLAP_GetLastUsedBedByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseBedProcedure.OLAP_GetLastUsedBedByEpisode_Class> OLAP_GetLastUsedBedByEpisode(TTObjectContext objectContext, string EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEBEDPROCEDURE"].QueryDefs["OLAP_GetLastUsedBedByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<BaseBedProcedure.OLAP_GetLastUsedBedByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BaseBedProcedure> GetByPatientAndUseStatus(TTObjectContext objectContext, string PATIENT, UsedStatusEnum USEDSTATUS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEBEDPROCEDURE"].QueryDefs["GetByPatientAndUseStatus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("USEDSTATUS", (int)USEDSTATUS);

            return ((ITTQuery)objectContext).QueryObjects<BaseBedProcedure>(queryDef, paramList);
        }

        public static BindingList<BaseBedProcedure> GetByBaseInpatientAdmissionAndUseStatus(TTObjectContext objectContext, string BASEINPATIENTADMISSION, UsedStatusEnum USEDSTATUS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEBEDPROCEDURE"].QueryDefs["GetByBaseInpatientAdmissionAndUseStatus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BASEINPATIENTADMISSION", BASEINPATIENTADMISSION);
            paramList.Add("USEDSTATUS", (int)USEDSTATUS);

            return ((ITTQuery)objectContext).QueryObjects<BaseBedProcedure>(queryDef, paramList);
        }

        public static BindingList<BaseBedProcedure.OLAP_GetEpisodeFromUsedBed_Class> OLAP_GetEpisodeFromUsedBed(string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEBEDPROCEDURE"].QueryDefs["OLAP_GetEpisodeFromUsedBed"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<BaseBedProcedure.OLAP_GetEpisodeFromUsedBed_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseBedProcedure.OLAP_GetEpisodeFromUsedBed_Class> OLAP_GetEpisodeFromUsedBed(TTObjectContext objectContext, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEBEDPROCEDURE"].QueryDefs["OLAP_GetEpisodeFromUsedBed"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<BaseBedProcedure.OLAP_GetEpisodeFromUsedBed_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BaseBedProcedure.OLAP_GetUsedBedByDate_Class> OLAP_GetUsedBedByDate(DateTime DATETIME, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEBEDPROCEDURE"].QueryDefs["OLAP_GetUsedBedByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATETIME", DATETIME);

            return TTReportNqlObject.QueryObjects<BaseBedProcedure.OLAP_GetUsedBedByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseBedProcedure.OLAP_GetUsedBedByDate_Class> OLAP_GetUsedBedByDate(TTObjectContext objectContext, DateTime DATETIME, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEBEDPROCEDURE"].QueryDefs["OLAP_GetUsedBedByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATETIME", DATETIME);

            return TTReportNqlObject.QueryObjects<BaseBedProcedure.OLAP_GetUsedBedByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BaseBedProcedure> GetByEpisodeOrderByLastBed(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEBEDPROCEDURE"].QueryDefs["GetByEpisodeOrderByLastBed"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<BaseBedProcedure>(queryDef, paramList);
        }

        public static BindingList<BaseBedProcedure> GetByEpisodeOrderByFirstBed(TTObjectContext objectContext, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEBEDPROCEDURE"].QueryDefs["GetByEpisodeOrderByFirstBed"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<BaseBedProcedure>(queryDef, paramList);
        }

        public static BindingList<BaseBedProcedure> GetActiveBedProcedures(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEBEDPROCEDURE"].QueryDefs["GetActiveBedProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<BaseBedProcedure>(queryDef, paramList);
        }

        public static BindingList<BaseBedProcedure.VEM_HASTA_YATAK_Class> VEM_HASTA_YATAK(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEBEDPROCEDURE"].QueryDefs["VEM_HASTA_YATAK"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseBedProcedure.VEM_HASTA_YATAK_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseBedProcedure.VEM_HASTA_YATAK_Class> VEM_HASTA_YATAK(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEBEDPROCEDURE"].QueryDefs["VEM_HASTA_YATAK"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseBedProcedure.VEM_HASTA_YATAK_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BaseBedProcedure.VEM_ANLIK_YATAN_HASTA_Class> VEM_ANLIK_YATAN_HASTA(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEBEDPROCEDURE"].QueryDefs["VEM_ANLIK_YATAN_HASTA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseBedProcedure.VEM_ANLIK_YATAN_HASTA_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseBedProcedure.VEM_ANLIK_YATAN_HASTA_Class> VEM_ANLIK_YATAN_HASTA(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEBEDPROCEDURE"].QueryDefs["VEM_ANLIK_YATAN_HASTA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseBedProcedure.VEM_ANLIK_YATAN_HASTA_Class>(objectContext, queryDef, paramList, pi);
        }

        public bool? IsLast
        {
            get { return (bool?)this["ISLAST"]; }
            set { this["ISLAST"] = value; }
        }

    /// <summary>
    /// Yatak Çıkış Tarihi
    /// </summary>
        public DateTime? BedDischargeDate
        {
            get { return (DateTime?)this["BEDDISCHARGEDATE"]; }
            set { this["BEDDISCHARGEDATE"] = value; }
        }

    /// <summary>
    /// Yatak Yatış Tarihi
    /// </summary>
        public DateTime? BedInPatientDate
        {
            get { return (DateTime?)this["BEDINPATIENTDATE"]; }
            set { this["BEDINPATIENTDATE"] = value; }
        }

    /// <summary>
    /// Kullanım Durumu
    /// </summary>
        public UsedStatusEnum? UsedStatus
        {
            get { return (UsedStatusEnum?)(int?)this["USEDSTATUS"]; }
            set { this["USEDSTATUS"] = value; }
        }

    /// <summary>
    /// Dr Anestezi Tescil No
    /// </summary>
        public string DrAnesteziTescilNo
        {
            get { return (string)this["DRANESTEZITESCILNO"]; }
            set { this["DRANESTEZITESCILNO"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Aciklama
        {
            get { return (string)this["ACIKLAMA"]; }
            set { this["ACIKLAMA"] = value; }
        }

    /// <summary>
    /// BedProcedure oluşturan türde mi
    /// </summary>
        public bool? IsNewPricingType
        {
            get { return (bool?)this["ISNEWPRICINGTYPE"]; }
            set { this["ISNEWPRICINGTYPE"] = value; }
        }

        public ResRoom Room
        {
            get { return (ResRoom)((ITTObject)this).GetParent("ROOM"); }
            set { this["ROOM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// OdaGrup
    /// </summary>
        public ResRoomGroup RoomGroup
        {
            get { return (ResRoomGroup)((ITTObject)this).GetParent("ROOMGROUP"); }
            set { this["ROOMGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResBed Bed
        {
            get { return (ResBed)((ITTObject)this).GetParent("BED"); }
            set { this["BED"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yattığı Klinik
    /// </summary>
        public ResWard Clinic
        {
            get { return (ResWard)((ITTObject)this).GetParent("CLINIC"); }
            set { this["CLINIC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yatak Hizmetinin Hangi Klinik İşleminden Girildiğini Belirler
    /// </summary>
        public BaseInpatientAdmission BaseInpatientAdmission
        {
            get { return (BaseInpatientAdmission)((ITTObject)this).GetParent("BASEINPATIENTADMISSION"); }
            set { this["BASEINPATIENTADMISSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InPatientTreatmentClinicApplication InPatientTreatmentClinicApp
        {
            get 
            {   
                if (EpisodeAction is InPatientTreatmentClinicApplication)
                    return (InPatientTreatmentClinicApplication)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        public IntensiveCareAfterSurgery IntensiveCareAfterSurgery
        {
            get 
            {   
                if (EpisodeAction is IntensiveCareAfterSurgery)
                    return (IntensiveCareAfterSurgery)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        virtual protected void CreateCokluOzelDurumCollection()
        {
            _CokluOzelDurum = new CokluOzelDurum.ChildCokluOzelDurumCollection(this, new Guid("7f4ed88a-1738-4e18-b7f1-97ec6337fd80"));
            ((ITTChildObjectCollection)_CokluOzelDurum).GetChildren();
        }

        protected CokluOzelDurum.ChildCokluOzelDurumCollection _CokluOzelDurum = null;
        public CokluOzelDurum.ChildCokluOzelDurumCollection CokluOzelDurum
        {
            get
            {
                if (_CokluOzelDurum == null)
                    CreateCokluOzelDurumCollection();
                return _CokluOzelDurum;
            }
        }

        virtual protected void CreateBedProceduresCollection()
        {
            _BedProcedures = new BedProcedure.ChildBedProcedureCollection(this, new Guid("5173911f-6d65-4bc2-ae38-7b3778f7c55b"));
            ((ITTChildObjectCollection)_BedProcedures).GetChildren();
        }

        protected BedProcedure.ChildBedProcedureCollection _BedProcedures = null;
    /// <summary>
    /// Child collection for Nabız Yatak İşlemi
    /// </summary>
        public BedProcedure.ChildBedProcedureCollection BedProcedures
        {
            get
            {
                if (_BedProcedures == null)
                    CreateBedProceduresCollection();
                return _BedProcedures;
            }
        }

        protected BaseBedProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseBedProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseBedProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseBedProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseBedProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEBEDPROCEDURE", dataRow) { }
        protected BaseBedProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEBEDPROCEDURE", dataRow, isImported) { }
        public BaseBedProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseBedProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseBedProcedure() : base() { }

    }
}