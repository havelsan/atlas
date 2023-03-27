
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UnavailableToWorkReport")] 

    /// <summary>
    /// İş Görmezlik Belgesi
    /// </summary>
    public  partial class UnavailableToWorkReport : EpisodeAction
    {
        public class UnavailableToWorkReportList : TTObjectCollection<UnavailableToWorkReport> { }
                    
        public class ChildUnavailableToWorkReportCollection : TTObject.TTChildObjectCollection<UnavailableToWorkReport>
        {
            public ChildUnavailableToWorkReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUnavailableToWorkReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetUnavailableToWorkReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? AbsenceEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ABSENCEENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILABLETOWORKREPORT"].AllPropertyDefs["ABSENCEENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? AbsenceStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ABSENCESTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILABLETOWORKREPORT"].AllPropertyDefs["ABSENCESTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Diagnosiscode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSISCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Diagnosisname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSISNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Excuse
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXCUSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILABLETOWORKREPORT"].AllPropertyDefs["EXCUSE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RestingEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESTINGENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILABLETOWORKREPORT"].AllPropertyDefs["RESTINGENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RestingStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESTINGSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILABLETOWORKREPORT"].AllPropertyDefs["RESTINGSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public MedulaReportSituationEnum? Situation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SITUATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILABLETOWORKREPORT"].AllPropertyDefs["SITUATION"].DataType;
                    return (MedulaReportSituationEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? SituationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SITUATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILABLETOWORKREPORT"].AllPropertyDefs["SITUATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Mresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Rdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILABLETOWORKREPORT"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public long? Refno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Address
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADDRESS"]);
                }
            }

            public Object Hphone
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HPHONE"]);
                }
            }

            public Object Mphone
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MPHONE"]);
                }
            }

            public DateTime? Admissiondate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Dischargedate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
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

            public string Doctorid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Dno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMAREGISTERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetUnavailableToWorkReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnavailableToWorkReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnavailableToWorkReport_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("75a81353-e741-4a22-8127-fba6104eac85"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("a5ff6611-0156-4c22-9cf3-5368f8b30e36"); } }
            public static Guid Completed { get { return new Guid("a615ef50-8b81-452b-90d0-7d739604b0df"); } }
        }

        public static BindingList<UnavailableToWorkReport.GetUnavailableToWorkReport_Class> GetUnavailableToWorkReport(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UNAVAILABLETOWORKREPORT"].QueryDefs["GetUnavailableToWorkReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<UnavailableToWorkReport.GetUnavailableToWorkReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UnavailableToWorkReport.GetUnavailableToWorkReport_Class> GetUnavailableToWorkReport(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UNAVAILABLETOWORKREPORT"].QueryDefs["GetUnavailableToWorkReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<UnavailableToWorkReport.GetUnavailableToWorkReport_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Bebek Doğum Tarihi
    /// </summary>
        public DateTime? BabyBirthDate
        {
            get { return (DateTime?)this["BABYBIRTHDATE"]; }
            set { this["BABYBIRTHDATE"] = value; }
        }

    /// <summary>
    /// Baba Kimlik Numarası
    /// </summary>
        public string FatherTCNo
        {
            get { return (string)this["FATHERTCNO"]; }
            set { this["FATHERTCNO"] = value; }
        }

    /// <summary>
    /// Anne Çalışmıyor
    /// </summary>
        public bool? NotWorkMother
        {
            get { return (bool?)this["NOTWORKMOTHER"]; }
            set { this["NOTWORKMOTHER"] = value; }
        }

    /// <summary>
    /// Taburcu Tarihi
    /// </summary>
        public DateTime? DischargeDate
        {
            get { return (DateTime?)this["DISCHARGEDATE"]; }
            set { this["DISCHARGEDATE"] = value; }
        }

    /// <summary>
    /// Protokol Tarihi
    /// </summary>
        public DateTime? ProtocolDate
        {
            get { return (DateTime?)this["PROTOCOLDATE"]; }
            set { this["PROTOCOLDATE"] = value; }
        }

    /// <summary>
    /// Gün Sayısı
    /// </summary>
        public int? DayCount
        {
            get { return (int?)this["DAYCOUNT"]; }
            set { this["DAYCOUNT"] = value; }
        }

    /// <summary>
    /// Normal Sezeryan Forsebs Dogum çeşidi
    /// </summary>
        public BirthTypeEnum? NorSezFor
        {
            get { return (BirthTypeEnum?)(int?)this["NORSEZFOR"]; }
            set { this["NORSEZFOR"] = value; }
        }

    /// <summary>
    /// Rapor Sıra Numarası
    /// </summary>
        public string ReportRowNumber
        {
            get { return (string)this["REPORTROWNUMBER"]; }
            set { this["REPORTROWNUMBER"] = value; }
        }

    /// <summary>
    /// Medula Rapor Türü
    /// </summary>
        public string MedulaReportType
        {
            get { return (string)this["MEDULAREPORTTYPE"]; }
            set { this["MEDULAREPORTTYPE"] = value; }
        }

    /// <summary>
    /// Medula Takip Numarası
    /// </summary>
        public string MedulaChasingNo
        {
            get { return (string)this["MEDULACHASINGNO"]; }
            set { this["MEDULACHASINGNO"] = value; }
        }

    /// <summary>
    /// Çalışılmayan Tarih Başlangıcı
    /// </summary>
        public DateTime? AbsenceStartDate
        {
            get { return (DateTime?)this["ABSENCESTARTDATE"]; }
            set { this["ABSENCESTARTDATE"] = value; }
        }

    /// <summary>
    /// Çalışılmayan Tarih Sonu
    /// </summary>
        public DateTime? AbsenceEndDate
        {
            get { return (DateTime?)this["ABSENCEENDDATE"]; }
            set { this["ABSENCEENDDATE"] = value; }
        }

    /// <summary>
    /// Durum
    /// </summary>
        public MedulaReportSituationEnum? Situation
        {
            get { return (MedulaReportSituationEnum?)(int?)this["SITUATION"]; }
            set { this["SITUATION"] = value; }
        }

    /// <summary>
    /// Doğan Çocuk Sayısı
    /// </summary>
        public int? ChildrenBornNumber
        {
            get { return (int?)this["CHILDRENBORNNUMBER"]; }
            set { this["CHILDRENBORNNUMBER"] = value; }
        }

    /// <summary>
    /// Canlı Çocuk Sayısı
    /// </summary>
        public int? LiveBirthsNumber
        {
            get { return (int?)this["LIVEBIRTHSNUMBER"]; }
            set { this["LIVEBIRTHSNUMBER"] = value; }
        }

    /// <summary>
    /// Gebelik Haftası 1.
    /// </summary>
        public int? GestationalOne
        {
            get { return (int?)this["GESTATIONALONE"]; }
            set { this["GESTATIONALONE"] = value; }
        }

    /// <summary>
    /// Gebelik Haftası 2.
    /// </summary>
        public int? GestationalTwo
        {
            get { return (int?)this["GESTATIONALTWO"]; }
            set { this["GESTATIONALTWO"] = value; }
        }

    /// <summary>
    /// Bebek Doğum Haftası
    /// </summary>
        public int? BabyBirthWeek
        {
            get { return (int?)this["BABYBIRTHWEEK"]; }
            set { this["BABYBIRTHWEEK"] = value; }
        }

    /// <summary>
    /// Aktarma Haftası
    /// </summary>
        public int? TransferringTheWeek
        {
            get { return (int?)this["TRANSFERRINGTHEWEEK"]; }
            set { this["TRANSFERRINGTHEWEEK"] = value; }
        }

    /// <summary>
    /// Dogum Çeşidi
    /// </summary>
        public BirthTypeEnum? BirthType
        {
            get { return (BirthTypeEnum?)(int?)this["BIRTHTYPE"]; }
            set { this["BIRTHTYPE"] = value; }
        }

    /// <summary>
    /// Devam Durum
    /// </summary>
        public CarryCaseTypeEnum? CarryCase
        {
            get { return (CarryCaseTypeEnum?)(int?)this["CARRYCASE"]; }
            set { this["CARRYCASE"] = value; }
        }

    /// <summary>
    /// Rapor No
    /// </summary>
        public TTSequence ReportSeqNo
        {
            get { return GetSequence("REPORTSEQNO"); }
        }

    /// <summary>
    /// Yaranın Yeri
    /// </summary>
        public string WoundPosition
        {
            get { return (string)this["WOUNDPOSITION"]; }
            set { this["WOUNDPOSITION"] = value; }
        }

    /// <summary>
    /// Yaranın Türü
    /// </summary>
        public string WoundType
        {
            get { return (string)this["WOUNDTYPE"]; }
            set { this["WOUNDTYPE"] = value; }
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
    /// Analık Rapor Tipi
    /// </summary>
        public MaternityReportTypeEnum? MaternityReportType
        {
            get { return (MaternityReportTypeEnum?)(int?)this["MATERNITYREPORTTYPE"]; }
            set { this["MATERNITYREPORTTYPE"] = value; }
        }

    /// <summary>
    /// Aktarma Raporunun Başlıyacağı Zaman
    /// </summary>
        public DateTime? TransferringDate
        {
            get { return (DateTime?)this["TRANSFERRINGDATE"]; }
            set { this["TRANSFERRINGDATE"] = value; }
        }

    /// <summary>
    /// Anne Kimlik Numarası
    /// </summary>
        public string MotherTCNo
        {
            get { return (string)this["MOTHERTCNO"]; }
            set { this["MOTHERTCNO"] = value; }
        }

    /// <summary>
    /// Rapor Düzenleme Türü
    /// </summary>
        public EditingTourTypeEnum? EditingTourType
        {
            get { return (EditingTourTypeEnum?)(int?)this["EDITINGTOURTYPE"]; }
            set { this["EDITINGTOURTYPE"] = value; }
        }

    /// <summary>
    /// Sigortalının Ölüp Ölmediği
    /// </summary>
        public DeathTypeEnum? DeathType
        {
            get { return (DeathTypeEnum?)(int?)this["DEATHTYPE"]; }
            set { this["DEATHTYPE"] = value; }
        }

    /// <summary>
    /// Yatış Devam
    /// </summary>
        public ContinuedHospitalizationTypeEnum? ContinuedHospitalizationType
        {
            get { return (ContinuedHospitalizationTypeEnum?)(int?)this["CONTINUEDHOSPITALIZATIONTYPE"]; }
            set { this["CONTINUEDHOSPITALIZATIONTYPE"] = value; }
        }

    /// <summary>
    /// Kaza Tarihi
    /// </summary>
        public DateTime? AccidentDate
        {
            get { return (DateTime?)this["ACCIDENTDATE"]; }
            set { this["ACCIDENTDATE"] = value; }
        }

    /// <summary>
    /// Nuks
    /// </summary>
        public NuksTypeEnum? NuksType
        {
            get { return (NuksTypeEnum?)(int?)this["NUKSTYPE"]; }
            set { this["NUKSTYPE"] = value; }
        }

    /// <summary>
    /// Mazeret
    /// </summary>
        public string Excuse
        {
            get { return (string)this["EXCUSE"]; }
            set { this["EXCUSE"] = value; }
        }

    /// <summary>
    /// İstırahat Başlangıç Tarihi
    /// </summary>
        public DateTime? RestingStartDate
        {
            get { return (DateTime?)this["RESTINGSTARTDATE"]; }
            set { this["RESTINGSTARTDATE"] = value; }
        }

    /// <summary>
    /// İstırahat Bitiş Tarihi
    /// </summary>
        public DateTime? RestingEndDate
        {
            get { return (DateTime?)this["RESTINGENDDATE"]; }
            set { this["RESTINGENDDATE"] = value; }
        }

    /// <summary>
    /// Durum Tarihi
    /// </summary>
        public DateTime? SituationDate
        {
            get { return (DateTime?)this["SITUATIONDATE"]; }
            set { this["SITUATIONDATE"] = value; }
        }

    /// <summary>
    /// Taburcu Kodu
    /// </summary>
        public DischargedCodeTypeEnum? DischargedCodeType
        {
            get { return (DischargedCodeTypeEnum?)(int?)this["DISCHARGEDCODETYPE"]; }
            set { this["DISCHARGEDCODETYPE"] = value; }
        }

    /// <summary>
    /// Sonuç Açıklaması
    /// </summary>
        public string ResultExplanation
        {
            get { return (string)this["RESULTEXPLANATION"]; }
            set { this["RESULTEXPLANATION"] = value; }
        }

    /// <summary>
    /// Sonuç Kodu
    /// </summary>
        public string ResultCode
        {
            get { return (string)this["RESULTCODE"]; }
            set { this["RESULTCODE"] = value; }
        }

    /// <summary>
    /// İlk ya da ikinci on güne kadar ayaktan istirat
    /// </summary>
        public string FirstOrSecondTenDays
        {
            get { return (string)this["FIRSTORSECONDTENDAYS"]; }
            set { this["FIRSTORSECONDTENDAYS"] = value; }
        }

        public CodeValue VucutYeri
        {
            get { return (CodeValue)((ITTObject)this).GetParent("VUCUTYERI"); }
            set { this["VUCUTYERI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CodeValue YaraTuru
        {
            get { return (CodeValue)((ITTObject)this).GetParent("YARATURU"); }
            set { this["YARATURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DiagnosisDefinition DiagnosisDefinition
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSISDEFINITION"); }
            set { this["DIAGNOSISDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDoctorsGridCollection()
        {
            _DoctorsGrid = new DoctorGrid.ChildDoctorGridCollection(this, new Guid("d0ecb30d-c455-4e8c-82b9-39064b0bc7b5"));
            ((ITTChildObjectCollection)_DoctorsGrid).GetChildren();
        }

        protected DoctorGrid.ChildDoctorGridCollection _DoctorsGrid = null;
        public DoctorGrid.ChildDoctorGridCollection DoctorsGrid
        {
            get
            {
                if (_DoctorsGrid == null)
                    CreateDoctorsGridCollection();
                return _DoctorsGrid;
            }
        }

        protected UnavailableToWorkReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UnavailableToWorkReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UnavailableToWorkReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UnavailableToWorkReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UnavailableToWorkReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UNAVAILABLETOWORKREPORT", dataRow) { }
        protected UnavailableToWorkReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UNAVAILABLETOWORKREPORT", dataRow, isImported) { }
        public UnavailableToWorkReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UnavailableToWorkReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UnavailableToWorkReport() : base() { }

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