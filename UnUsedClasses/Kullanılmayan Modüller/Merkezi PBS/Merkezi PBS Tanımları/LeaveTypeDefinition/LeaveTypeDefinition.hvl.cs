
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LeaveTypeDefinition")] 

    public  partial class LeaveTypeDefinition : TerminologyManagerDef
    {
        public class LeaveTypeDefinitionList : TTObjectCollection<LeaveTypeDefinition> { }
                    
        public class ChildLeaveTypeDefinitionCollection : TTObject.TTChildObjectCollection<LeaveTypeDefinition>
        {
            public ChildLeaveTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLeaveTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetLeaveTypeDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LEAVETYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SHORT_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHORT_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LEAVETYPEDEFINITION"].AllPropertyDefs["SHORT_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? SEQUENCE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQUENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LEAVETYPEDEFINITION"].AllPropertyDefs["SEQUENCE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetLeaveTypeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLeaveTypeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLeaveTypeDefinition_Class() : base() { }
        }

        public static BindingList<LeaveTypeDefinition.GetLeaveTypeDefinition_Class> GetLeaveTypeDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LEAVETYPEDEFINITION"].QueryDefs["GetLeaveTypeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LeaveTypeDefinition.GetLeaveTypeDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LeaveTypeDefinition.GetLeaveTypeDefinition_Class> GetLeaveTypeDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LEAVETYPEDEFINITION"].QueryDefs["GetLeaveTypeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LeaveTypeDefinition.GetLeaveTypeDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string SHORT_NAME
        {
            get { return (string)this["SHORT_NAME"]; }
            set { this["SHORT_NAME"] = value; }
        }

        public int? LEAVETYPEIND
        {
            get { return (int?)this["LEAVETYPEIND"]; }
            set { this["LEAVETYPEIND"] = value; }
        }

        public string NAME
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public int? SEQUENCE
        {
            get { return (int?)this["SEQUENCE"]; }
            set { this["SEQUENCE"] = value; }
        }

        protected LeaveTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LeaveTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LeaveTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LeaveTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LeaveTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LEAVETYPEDEFINITION", dataRow) { }
        protected LeaveTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LEAVETYPEDEFINITION", dataRow, isImported) { }
        public LeaveTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LeaveTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LeaveTypeDefinition() : base() { }

    }
}