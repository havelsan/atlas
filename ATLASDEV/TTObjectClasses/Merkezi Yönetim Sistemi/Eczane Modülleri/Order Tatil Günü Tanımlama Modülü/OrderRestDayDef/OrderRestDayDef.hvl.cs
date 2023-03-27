
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OrderRestDayDef")] 

    public  partial class OrderRestDayDef : TerminologyManagerDef
    {
        public class OrderRestDayDefList : TTObjectCollection<OrderRestDayDef> { }
                    
        public class ChildOrderRestDayDefCollection : TTObject.TTChildObjectCollection<OrderRestDayDef>
        {
            public ChildOrderRestDayDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOrderRestDayDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOrderRestDayByDate_Class : TTReportNqlObject 
        {
            public int? RestDayCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESTDAYCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORDERRESTDAYDEF"].AllPropertyDefs["RESTDAYCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string RestDayDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESTDAYDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORDERRESTDAYDEF"].AllPropertyDefs["RESTDAYDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOrderRestDayByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOrderRestDayByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOrderRestDayByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOrderRestDayDefList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? OrderDay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORDERRESTDAYDEF"].AllPropertyDefs["ORDERDAY"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? RestDayCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESTDAYCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORDERRESTDAYDEF"].AllPropertyDefs["RESTDAYCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string RestDayDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESTDAYDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORDERRESTDAYDEF"].AllPropertyDefs["RESTDAYDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOrderRestDayDefList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOrderRestDayDefList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOrderRestDayDefList_Class() : base() { }
        }

        public static BindingList<OrderRestDayDef.GetOrderRestDayByDate_Class> GetOrderRestDayByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORDERRESTDAYDEF"].QueryDefs["GetOrderRestDayByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<OrderRestDayDef.GetOrderRestDayByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OrderRestDayDef.GetOrderRestDayByDate_Class> GetOrderRestDayByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORDERRESTDAYDEF"].QueryDefs["GetOrderRestDayByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<OrderRestDayDef.GetOrderRestDayByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<OrderRestDayDef.GetOrderRestDayDefList_Class> GetOrderRestDayDefList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORDERRESTDAYDEF"].QueryDefs["GetOrderRestDayDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OrderRestDayDef.GetOrderRestDayDefList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<OrderRestDayDef.GetOrderRestDayDefList_Class> GetOrderRestDayDefList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORDERRESTDAYDEF"].QueryDefs["GetOrderRestDayDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OrderRestDayDef.GetOrderRestDayDefList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public DateTime? OrderDay
        {
            get { return (DateTime?)this["ORDERDAY"]; }
            set { this["ORDERDAY"] = value; }
        }

        public int? RestDayCount
        {
            get { return (int?)this["RESTDAYCOUNT"]; }
            set { this["RESTDAYCOUNT"] = value; }
        }

        public string RestDayDescription
        {
            get { return (string)this["RESTDAYDESCRIPTION"]; }
            set { this["RESTDAYDESCRIPTION"] = value; }
        }

        protected OrderRestDayDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OrderRestDayDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OrderRestDayDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OrderRestDayDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OrderRestDayDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ORDERRESTDAYDEF", dataRow) { }
        protected OrderRestDayDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ORDERRESTDAYDEF", dataRow, isImported) { }
        public OrderRestDayDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OrderRestDayDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OrderRestDayDef() : base() { }

    }
}