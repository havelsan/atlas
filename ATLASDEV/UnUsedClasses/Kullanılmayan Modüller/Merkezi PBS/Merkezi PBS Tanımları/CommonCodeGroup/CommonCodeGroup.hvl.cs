
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CommonCodeGroup")] 

    public  partial class CommonCodeGroup : TerminologyManagerDef
    {
        public class CommonCodeGroupList : TTObjectCollection<CommonCodeGroup> { }
                    
        public class ChildCommonCodeGroupCollection : TTObject.TTChildObjectCollection<CommonCodeGroup>
        {
            public ChildCommonCodeGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCommonCodeGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCommonCodeGroupList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string GROUP_CODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GROUP_CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODEGROUP"].AllPropertyDefs["GROUP_CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GROUP_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GROUP_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODEGROUP"].AllPropertyDefs["GROUP_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GROUP_DESCR
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GROUP_DESCR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODEGROUP"].AllPropertyDefs["GROUP_DESCR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetCommonCodeGroupList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCommonCodeGroupList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCommonCodeGroupList_Class() : base() { }
        }

        public static BindingList<CommonCodeGroup.GetCommonCodeGroupList_Class> GetCommonCodeGroupList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODEGROUP"].QueryDefs["GetCommonCodeGroupList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCodeGroup.GetCommonCodeGroupList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CommonCodeGroup.GetCommonCodeGroupList_Class> GetCommonCodeGroupList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODEGROUP"].QueryDefs["GetCommonCodeGroupList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCodeGroup.GetCommonCodeGroupList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string GROUP_DESCR
        {
            get { return (string)this["GROUP_DESCR"]; }
            set { this["GROUP_DESCR"] = value; }
        }

        public string GROUP_NAME
        {
            get { return (string)this["GROUP_NAME"]; }
            set { this["GROUP_NAME"] = value; }
        }

        public string GROUP_CODE
        {
            get { return (string)this["GROUP_CODE"]; }
            set { this["GROUP_CODE"] = value; }
        }

        protected CommonCodeGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CommonCodeGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CommonCodeGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CommonCodeGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CommonCodeGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMMONCODEGROUP", dataRow) { }
        protected CommonCodeGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMMONCODEGROUP", dataRow, isImported) { }
        public CommonCodeGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CommonCodeGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CommonCodeGroup() : base() { }

    }
}