
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LoadSummary")] 

    /// <summary>
    /// Yüklemenin Hülasası
    /// </summary>
    public  partial class LoadSummary : TTObject
    {
        public class LoadSummaryList : TTObjectCollection<LoadSummary> { }
                    
        public class ChildLoadSummaryCollection : TTObject.TTChildObjectCollection<LoadSummary>
        {
            public ChildLoadSummaryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLoadSummaryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OutputSendingDocumentReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string PackageKind
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEKIND"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOADSUMMARY"].AllPropertyDefs["PACKAGEKIND"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kind
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIND"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOADSUMMARY"].AllPropertyDefs["KIND"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? TotalCapacity
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALCAPACITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOADSUMMARY"].AllPropertyDefs["TOTALCAPACITY"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? TotalWeight
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALWEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOADSUMMARY"].AllPropertyDefs["TOTALWEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public long? TotalPackage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPACKAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOADSUMMARY"].AllPropertyDefs["TOTALPACKAGE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public OutputSendingDocumentReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OutputSendingDocumentReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OutputSendingDocumentReportQuery_Class() : base() { }
        }

        public static BindingList<LoadSummary.OutputSendingDocumentReportQuery_Class> OutputSendingDocumentReportQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LOADSUMMARY"].QueryDefs["OutputSendingDocumentReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<LoadSummary.OutputSendingDocumentReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LoadSummary.OutputSendingDocumentReportQuery_Class> OutputSendingDocumentReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LOADSUMMARY"].QueryDefs["OutputSendingDocumentReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<LoadSummary.OutputSendingDocumentReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Ambalaj Nevi
    /// </summary>
        public string PackageKind
        {
            get { return (string)this["PACKAGEKIND"]; }
            set { this["PACKAGEKIND"] = value; }
        }

    /// <summary>
    /// Cins
    /// </summary>
        public string Kind
        {
            get { return (string)this["KIND"]; }
            set { this["KIND"] = value; }
        }

    /// <summary>
    /// Hacim Toplamı
    /// </summary>
        public double? TotalCapacity
        {
            get { return (double?)this["TOTALCAPACITY"]; }
            set { this["TOTALCAPACITY"] = value; }
        }

    /// <summary>
    /// Ağırlık Toplamı
    /// </summary>
        public double? TotalWeight
        {
            get { return (double?)this["TOTALWEIGHT"]; }
            set { this["TOTALWEIGHT"] = value; }
        }

    /// <summary>
    /// Ambalaj Toplamı
    /// </summary>
        public long? TotalPackage
        {
            get { return (long?)this["TOTALPACKAGE"]; }
            set { this["TOTALPACKAGE"] = value; }
        }

        public StockAction StockAction
        {
            get { return (StockAction)((ITTObject)this).GetParent("STOCKACTION"); }
            set { this["STOCKACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LoadSummary(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LoadSummary(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LoadSummary(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LoadSummary(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LoadSummary(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LOADSUMMARY", dataRow) { }
        protected LoadSummary(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LOADSUMMARY", dataRow, isImported) { }
        public LoadSummary(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LoadSummary(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LoadSummary() : base() { }

    }
}