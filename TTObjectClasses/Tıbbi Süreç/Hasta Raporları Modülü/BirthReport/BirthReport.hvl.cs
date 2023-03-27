
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BirthReport")] 

    /// <summary>
    /// Doğum Raporunu Yazıldığı Temel Nesnedir
    /// </summary>
    public  partial class BirthReport : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        public class BirthReportList : TTObjectCollection<BirthReport> { }
                    
        public class ChildBirthReportCollection : TTObject.TTChildObjectCollection<BirthReport>
        {
            public ChildBirthReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBirthReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBirtfReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string PartnerName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARTNERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].AllPropertyDefs["PARTNERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].AllPropertyDefs["REPORT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? BabyBirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BABYBIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].AllPropertyDefs["BABYBIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? BirthTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].AllPropertyDefs["BIRTHTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public SexEnum? Sex
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].AllPropertyDefs["SEX"].DataType;
                    return (SexEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public BirthReportBabyStatus? BabyStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BABYSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].AllPropertyDefs["BABYSTATUS"].DataType;
                    return (BirthReportBabyStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public string Dogumsekli
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOGUMSEKLI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BORNTYPE"].AllPropertyDefs["TYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Height
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].AllPropertyDefs["HEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Weight
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].AllPropertyDefs["WEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTID"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Birimadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIMADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? XXXXXXprotno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["XXXXXXPROTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Anne
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ANNE"]);
                }
            }

            public string Doctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetBirtfReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBirtfReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBirtfReport_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetBirthReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public BirthReportBabyStatus? BabyStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BABYSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].AllPropertyDefs["BABYSTATUS"].DataType;
                    return (BirthReportBabyStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? BornType
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BORNTYPE"]);
                }
            }

            public BirthReportAnestesiaTYpeEnum? AestesiaType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AESTESIATYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].AllPropertyDefs["AESTESIATYPE"].DataType;
                    return (BirthReportAnestesiaTYpeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public SexEnum? Sex
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].AllPropertyDefs["SEX"].DataType;
                    return (SexEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? BabyBirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BABYBIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].AllPropertyDefs["BABYBIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDOCTOR"]);
                }
            }

            public DateTime? Motherbirthdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOTHERBIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public OLAP_GetBirthReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetBirthReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetBirthReport_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledBirthReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public OLAP_GetCancelledBirthReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledBirthReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledBirthReport_Class() : base() { }
        }

        public static class States
        {
            public static Guid ReportEntry { get { return new Guid("d99aa6f5-8298-4451-b103-786fda5360b3"); } }
            public static Guid Completed { get { return new Guid("64c14682-4b82-4aab-803d-25d6ebf0c85d"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("738f9c9e-068c-43c4-b0aa-d9de9948bee9"); } }
        }

        public static BindingList<BirthReport.GetBirtfReport_Class> GetBirtfReport(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].QueryDefs["GetBirtfReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<BirthReport.GetBirtfReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BirthReport.GetBirtfReport_Class> GetBirtfReport(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].QueryDefs["GetBirtfReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<BirthReport.GetBirtfReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BirthReport.OLAP_GetBirthReport_Class> OLAP_GetBirthReport(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].QueryDefs["OLAP_GetBirthReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<BirthReport.OLAP_GetBirthReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BirthReport.OLAP_GetBirthReport_Class> OLAP_GetBirthReport(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].QueryDefs["OLAP_GetBirthReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<BirthReport.OLAP_GetBirthReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BirthReport> GetBirthDateReportById(TTObjectContext objectContext, string OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].QueryDefs["GetBirthDateReportById"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<BirthReport>(queryDef, paramList);
        }

        public static BindingList<BirthReport.OLAP_GetCancelledBirthReport_Class> OLAP_GetCancelledBirthReport(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].QueryDefs["OLAP_GetCancelledBirthReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<BirthReport.OLAP_GetCancelledBirthReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BirthReport.OLAP_GetCancelledBirthReport_Class> OLAP_GetCancelledBirthReport(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].QueryDefs["OLAP_GetCancelledBirthReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<BirthReport.OLAP_GetCancelledBirthReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BirthReport> GetBirthReportByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].QueryDefs["GetBirthReportByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<BirthReport>(queryDef, paramList);
        }

        public static BindingList<BirthReport> GetBySubEpisode(TTObjectContext objectContext, Guid SUBEPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORT"].QueryDefs["GetBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<BirthReport>(queryDef, paramList);
        }

    /// <summary>
    /// Rapor Düzenlenme Tarihi
    /// </summary>
        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

    /// <summary>
    /// Bebeğin Baba Adı
    /// </summary>
        public string PartnerName
        {
            get { return (string)this["PARTNERNAME"]; }
            set { this["PARTNERNAME"] = value; }
        }

    /// <summary>
    /// Rapor Bitiş Tarihi
    /// </summary>
        public DateTime? ReportEndDate
        {
            get { return (DateTime?)this["REPORTENDDATE"]; }
            set { this["REPORTENDDATE"] = value; }
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
    /// Rapor No
    /// </summary>
        public TTSequence ReportNo
        {
            get { return GetSequence("REPORTNO"); }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public string Report
        {
            get { return (string)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// Rapor Başlangıç Tarihi
    /// </summary>
        public DateTime? ReportStartDate
        {
            get { return (DateTime?)this["REPORTSTARTDATE"]; }
            set { this["REPORTSTARTDATE"] = value; }
        }

    /// <summary>
    /// Ağırlık
    /// </summary>
        public double? Weight
        {
            get { return (double?)this["WEIGHT"]; }
            set { this["WEIGHT"] = value; }
        }

    /// <summary>
    /// Cinsiyet
    /// </summary>
        public SexEnum? Sex
        {
            get { return (SexEnum?)(int?)this["SEX"]; }
            set { this["SEX"] = value; }
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
    /// Doğum Saati
    /// </summary>
        public DateTime? BirthTime
        {
            get { return (DateTime?)this["BIRTHTIME"]; }
            set { this["BIRTHTIME"] = value; }
        }

    /// <summary>
    /// Bebeğin Durumu
    /// </summary>
        public BirthReportBabyStatus? BabyStatus
        {
            get { return (BirthReportBabyStatus?)(int?)this["BABYSTATUS"]; }
            set { this["BABYSTATUS"] = value; }
        }

    /// <summary>
    /// Boy
    /// </summary>
        public double? Height
        {
            get { return (double?)this["HEIGHT"]; }
            set { this["HEIGHT"] = value; }
        }

    /// <summary>
    /// Epizyotemi
    /// </summary>
        public YesNoEnum? Episiotomy
        {
            get { return (YesNoEnum?)(int?)this["EPISIOTOMY"]; }
            set { this["EPISIOTOMY"] = value; }
        }

    /// <summary>
    /// Klinik Tanı
    /// </summary>
        public string ClinicDiagnose
        {
            get { return (string)this["CLINICDIAGNOSE"]; }
            set { this["CLINICDIAGNOSE"] = value; }
        }

    /// <summary>
    /// Rapor Düzenlenme Türü
    /// </summary>
        public BirthReportTypeEnum? ReportType
        {
            get { return (BirthReportTypeEnum?)(int?)this["REPORTTYPE"]; }
            set { this["REPORTTYPE"] = value; }
        }

    /// <summary>
    /// Bebeğin Adı
    /// </summary>
        public string BabyName
        {
            get { return (string)this["BABYNAME"]; }
            set { this["BABYNAME"] = value; }
        }

    /// <summary>
    /// Karantina Protokol No
    /// </summary>
        public TTSequence QuarantineProtocolNo
        {
            get { return GetSequence("QUARANTINEPROTOCOLNO"); }
        }

    /// <summary>
    /// Anestezi Tipi
    /// </summary>
        public BirthReportAnestesiaTYpeEnum? AestesiaType
        {
            get { return (BirthReportAnestesiaTYpeEnum?)(int?)this["AESTESIATYPE"]; }
            set { this["AESTESIATYPE"] = value; }
        }

    /// <summary>
    /// Aydınlatılmış Onam Formu Verildi
    /// </summary>
        public bool? IsPatientApprovalFormGiven
        {
            get { return (bool?)this["ISPATIENTAPPROVALFORMGIVEN"]; }
            set { this["ISPATIENTAPPROVALFORMGIVEN"] = value; }
        }

    /// <summary>
    /// Doğum Şekli
    /// </summary>
        public BornType BornType
        {
            get { return (BornType)((ITTObject)this).GetParent("BORNTYPE"); }
            set { this["BORNTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doğumun Gerçekleştirildiği İşlem
    /// </summary>
        public EpisodeAction BirthEpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("BIRTHEPISODEACTION"); }
            set { this["BIRTHEPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bebek
    /// </summary>
        public Patient Baby
        {
            get { return (Patient)((ITTObject)this).GetParent("BABY"); }
            set { this["BABY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek-Doğum Raporları
    /// </summary>
        public BirthReportRequest BirthReportRequest
        {
            get { return (BirthReportRequest)((ITTObject)this).GetParent("BIRTHREPORTREQUEST"); }
            set { this["BIRTHREPORTREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBirthReportDoctorInfoCollection()
        {
            _BirthReportDoctorInfo = new BirthReportDoctorInfoGrid.ChildBirthReportDoctorInfoGridCollection(this, new Guid("914bba62-e357-4a0b-84ce-5a5e852457a7"));
            ((ITTChildObjectCollection)_BirthReportDoctorInfo).GetChildren();
        }

        protected BirthReportDoctorInfoGrid.ChildBirthReportDoctorInfoGridCollection _BirthReportDoctorInfo = null;
    /// <summary>
    /// Child collection for Doğum Raporu Doktor Bilgisi
    /// </summary>
        public BirthReportDoctorInfoGrid.ChildBirthReportDoctorInfoGridCollection BirthReportDoctorInfo
        {
            get
            {
                if (_BirthReportDoctorInfo == null)
                    CreateBirthReportDoctorInfoCollection();
                return _BirthReportDoctorInfo;
            }
        }

        protected BirthReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BirthReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BirthReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BirthReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BirthReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BIRTHREPORT", dataRow) { }
        protected BirthReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BIRTHREPORT", dataRow, isImported) { }
        public BirthReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BirthReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BirthReport() : base() { }

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