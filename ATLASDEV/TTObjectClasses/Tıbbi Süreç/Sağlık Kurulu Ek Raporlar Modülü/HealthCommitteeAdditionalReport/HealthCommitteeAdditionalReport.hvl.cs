
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteeAdditionalReport")] 

    /// <summary>
    /// Sağlık Kurulu Zeyil/Ek Raporları
    /// </summary>
    public  partial class HealthCommitteeAdditionalReport : EpisodeAction, IWorkListHealthCommittee
    {
        public class HealthCommitteeAdditionalReportList : TTObjectCollection<HealthCommitteeAdditionalReport> { }
                    
        public class ChildHealthCommitteeAdditionalReportCollection : TTObject.TTChildObjectCollection<HealthCommitteeAdditionalReport>
        {
            public ChildHealthCommitteeAdditionalReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteeAdditionalReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHCAdditionalReportByDate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetHCAdditionalReportByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCAdditionalReportByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCAdditionalReportByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCurrentHCAdditionalReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public object Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEADDITIONALREPORT"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEADDITIONALREPORT"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEADDITIONALREPORT"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public HCAdditionalReportTypeEnum? ReportType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEADDITIONALREPORT"].AllPropertyDefs["REPORTTYPE"].DataType;
                    return (HCAdditionalReportTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? HealthCommittee
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HEALTHCOMMITTEE"]);
                }
            }

            public Guid? MemberOfHealthCommittee
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MEMBEROFHEALTHCOMMITTEE"]);
                }
            }

            public DateTime? HCDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HCDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEADDITIONALREPORT"].AllPropertyDefs["HCDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? HCReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HCREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEADDITIONALREPORT"].AllPropertyDefs["HCREPORTNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOtherHospitalHC
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOTHERHOSPITALHC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEADDITIONALREPORT"].AllPropertyDefs["ISOTHERHOSPITALHC"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetCurrentHCAdditionalReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCurrentHCAdditionalReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCurrentHCAdditionalReport_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("a4a272db-b4f4-41e3-b6d6-556e551c2bfb"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("42d7246f-765e-4b60-9269-cad5c8a3d06f"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancel { get { return new Guid("ba84932e-7b9a-4fc2-b969-0899fd832506"); } }
        }

        public static BindingList<HealthCommitteeAdditionalReport.GetHCAdditionalReportByDate_Class> GetHCAdditionalReportByDate(DateTime STARTDATE, DateTime ENDDATE, int HEALTHCOMMITTEETYPEFLAG, HealthCommitteeTypeEnum HEALTHCOMMITTEETYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEADDITIONALREPORT"].QueryDefs["GetHCAdditionalReportByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("HEALTHCOMMITTEETYPEFLAG", HEALTHCOMMITTEETYPEFLAG);
            paramList.Add("HEALTHCOMMITTEETYPE", (int)HEALTHCOMMITTEETYPE);

            return TTReportNqlObject.QueryObjects<HealthCommitteeAdditionalReport.GetHCAdditionalReportByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeAdditionalReport.GetHCAdditionalReportByDate_Class> GetHCAdditionalReportByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, int HEALTHCOMMITTEETYPEFLAG, HealthCommitteeTypeEnum HEALTHCOMMITTEETYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEADDITIONALREPORT"].QueryDefs["GetHCAdditionalReportByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("HEALTHCOMMITTEETYPEFLAG", HEALTHCOMMITTEETYPEFLAG);
            paramList.Add("HEALTHCOMMITTEETYPE", (int)HEALTHCOMMITTEETYPE);

            return TTReportNqlObject.QueryObjects<HealthCommitteeAdditionalReport.GetHCAdditionalReportByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeAdditionalReport.GetCurrentHCAdditionalReport_Class> GetCurrentHCAdditionalReport(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEADDITIONALREPORT"].QueryDefs["GetCurrentHCAdditionalReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeAdditionalReport.GetCurrentHCAdditionalReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeAdditionalReport.GetCurrentHCAdditionalReport_Class> GetCurrentHCAdditionalReport(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEADDITIONALREPORT"].QueryDefs["GetCurrentHCAdditionalReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeAdditionalReport.GetCurrentHCAdditionalReport_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// XXXXXX Adı
    /// </summary>
        public string HCHospitalName
        {
            get { return (string)this["HCHOSPITALNAME"]; }
            set { this["HCHOSPITALNAME"] = value; }
        }

    /// <summary>
    /// Sağlık Kurulu Rapor
    /// </summary>
        public int? HCReportNo
        {
            get { return (int?)this["HCREPORTNO"]; }
            set { this["HCREPORTNO"] = value; }
        }

    /// <summary>
    /// Sağlık Kurulu İşlem Tarihi
    /// </summary>
        public DateTime? HCDate
        {
            get { return (DateTime?)this["HCDATE"]; }
            set { this["HCDATE"] = value; }
        }

    /// <summary>
    /// Diğer XXXXXXlerden Sağlık Kurulu
    /// </summary>
        public bool? IsOtherHospitalHC
        {
            get { return (bool?)this["ISOTHERHOSPITALHC"]; }
            set { this["ISOTHERHOSPITALHC"] = value; }
        }

    /// <summary>
    /// Sağlık Kurulu Türü
    /// </summary>
        public HealthCommitteeTypeEnum? HCCommitteeType
        {
            get { return (HealthCommitteeTypeEnum?)(int?)this["HCCOMMITTEETYPE"]; }
            set { this["HCCOMMITTEETYPE"] = value; }
        }

    /// <summary>
    /// Rapor Tarihi
    /// </summary>
        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

    /// <summary>
    /// Rapor Türü
    /// </summary>
        public HCAdditionalReportTypeEnum? ReportType
        {
            get { return (HCAdditionalReportTypeEnum?)(int?)this["REPORTTYPE"]; }
            set { this["REPORTTYPE"] = value; }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// Rapor Numarası
    /// </summary>
        public TTSequence ReportNo
        {
            get { return GetSequence("REPORTNO"); }
        }

    /// <summary>
    /// Heyet Teşkili
    /// </summary>
        public MemberOfHealthCommitteeDefinition MemberOfHealthCommittee
        {
            get { return (MemberOfHealthCommitteeDefinition)((ITTObject)this).GetParent("MEMBEROFHEALTHCOMMITTEE"); }
            set { this["MEMBEROFHEALTHCOMMITTEE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sağlık Kurulu İşlemi
    /// </summary>
        public HealthCommittee HealthCommittee
        {
            get { return (HealthCommittee)((ITTObject)this).GetParent("HEALTHCOMMITTEE"); }
            set { this["HEALTHCOMMITTEE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HealthCommitteeAdditionalReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteeAdditionalReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteeAdditionalReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteeAdditionalReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteeAdditionalReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEEADDITIONALREPORT", dataRow) { }
        protected HealthCommitteeAdditionalReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEEADDITIONALREPORT", dataRow, isImported) { }
        public HealthCommitteeAdditionalReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteeAdditionalReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteeAdditionalReport() : base() { }

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