
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WorkDayExceptionDef")] 

    public  partial class WorkDayExceptionDef : TerminologyManagerDef
    {
        public class WorkDayExceptionDefList : TTObjectCollection<WorkDayExceptionDef> { }
                    
        public class ChildWorkDayExceptionDefCollection : TTObject.TTChildObjectCollection<WorkDayExceptionDef>
        {
            public ChildWorkDayExceptionDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWorkDayExceptionDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetWorkDayExceptionDefs_Class : TTReportNqlObject 
        {
            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].AllPropertyDefs["DATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetWorkDayExceptionDefs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWorkDayExceptionDefs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWorkDayExceptionDefs_Class() : base() { }
        }

        [Serializable] 

        public partial class WorkDayExceptionDefFormNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].AllPropertyDefs["DATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public WorkDayExceptionDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public WorkDayExceptionDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected WorkDayExceptionDefFormNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetWorkDayExcesptionsQuery_Class : TTReportNqlObject 
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

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
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

            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].AllPropertyDefs["DATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].AllPropertyDefs["DESCRIPTION_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetWorkDayExcesptionsQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWorkDayExcesptionsQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWorkDayExcesptionsQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActiveWorkDayExceptionDefs_Class : TTReportNqlObject 
        {
            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].AllPropertyDefs["DATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetActiveWorkDayExceptionDefs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveWorkDayExceptionDefs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveWorkDayExceptionDefs_Class() : base() { }
        }

        [Serializable] 

        public partial class GetWorkDayExceptionsDate_Class : TTReportNqlObject 
        {
            public Object Onlydate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ONLYDATE"]);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetWorkDayExceptionsDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWorkDayExceptionsDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWorkDayExceptionsDate_Class() : base() { }
        }

        public static BindingList<WorkDayExceptionDef.GetWorkDayExceptionDefs_Class> GetWorkDayExceptionDefs(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].QueryDefs["GetWorkDayExceptionDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WorkDayExceptionDef.GetWorkDayExceptionDefs_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<WorkDayExceptionDef.GetWorkDayExceptionDefs_Class> GetWorkDayExceptionDefs(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].QueryDefs["GetWorkDayExceptionDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WorkDayExceptionDef.GetWorkDayExceptionDefs_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<WorkDayExceptionDef> GetWorkDayExceptions(TTObjectContext objectContext, DateTime DATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].QueryDefs["GetWorkDayExceptions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return ((ITTQuery)objectContext).QueryObjects<WorkDayExceptionDef>(queryDef, paramList);
        }

        public static BindingList<WorkDayExceptionDef.WorkDayExceptionDefFormNQL_Class> WorkDayExceptionDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].QueryDefs["WorkDayExceptionDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WorkDayExceptionDef.WorkDayExceptionDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<WorkDayExceptionDef.WorkDayExceptionDefFormNQL_Class> WorkDayExceptionDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].QueryDefs["WorkDayExceptionDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WorkDayExceptionDef.WorkDayExceptionDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<WorkDayExceptionDef> GetWorkDayExceptionDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].QueryDefs["GetWorkDayExceptionDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<WorkDayExceptionDef>(queryDef, paramList);
        }

        public static BindingList<WorkDayExceptionDef> GetWorkDaysStartsFrom(TTObjectContext objectContext, DateTime STARTDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].QueryDefs["GetWorkDaysStartsFrom"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);

            return ((ITTQuery)objectContext).QueryObjects<WorkDayExceptionDef>(queryDef, paramList);
        }

        public static BindingList<WorkDayExceptionDef.GetWorkDayExcesptionsQuery_Class> GetWorkDayExcesptionsQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].QueryDefs["GetWorkDayExcesptionsQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WorkDayExceptionDef.GetWorkDayExcesptionsQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<WorkDayExceptionDef.GetWorkDayExcesptionsQuery_Class> GetWorkDayExcesptionsQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].QueryDefs["GetWorkDayExcesptionsQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WorkDayExceptionDef.GetWorkDayExcesptionsQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Aktif Olan Tatil Günleri
    /// </summary>
        public static BindingList<WorkDayExceptionDef.GetActiveWorkDayExceptionDefs_Class> GetActiveWorkDayExceptionDefs(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].QueryDefs["GetActiveWorkDayExceptionDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WorkDayExceptionDef.GetActiveWorkDayExceptionDefs_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Aktif Olan Tatil Günleri
    /// </summary>
        public static BindingList<WorkDayExceptionDef.GetActiveWorkDayExceptionDefs_Class> GetActiveWorkDayExceptionDefs(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].QueryDefs["GetActiveWorkDayExceptionDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WorkDayExceptionDef.GetActiveWorkDayExceptionDefs_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<WorkDayExceptionDef.GetWorkDayExceptionsDate_Class> GetWorkDayExceptionsDate(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].QueryDefs["GetWorkDayExceptionsDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WorkDayExceptionDef.GetWorkDayExceptionsDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<WorkDayExceptionDef.GetWorkDayExceptionsDate_Class> GetWorkDayExceptionsDate(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKDAYEXCEPTIONDEF"].QueryDefs["GetWorkDayExceptionsDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WorkDayExceptionDef.GetWorkDayExceptionsDate_Class>(objectContext, queryDef, paramList, pi);
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
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public string Description_Shadow
        {
            get { return (string)this["DESCRIPTION_SHADOW"]; }
        }

        protected WorkDayExceptionDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WorkDayExceptionDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WorkDayExceptionDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WorkDayExceptionDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WorkDayExceptionDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WORKDAYEXCEPTIONDEF", dataRow) { }
        protected WorkDayExceptionDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WORKDAYEXCEPTIONDEF", dataRow, isImported) { }
        public WorkDayExceptionDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WorkDayExceptionDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WorkDayExceptionDef() : base() { }

    }
}