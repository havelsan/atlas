
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UrgeDefinition")] 

    public  partial class UrgeDefinition : TerminologyManagerDef
    {
        public class UrgeDefinitionList : TTObjectCollection<UrgeDefinition> { }
                    
        public class ChildUrgeDefinitionCollection : TTObject.TTChildObjectCollection<UrgeDefinition>
        {
            public ChildUrgeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUrgeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetUrgeList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["URGEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetUrgeList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUrgeList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUrgeList_Class() : base() { }
        }

        public static BindingList<UrgeDefinition.GetUrgeList_Class> GetUrgeList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["URGEDEFINITION"].QueryDefs["GetUrgeList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UrgeDefinition.GetUrgeList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<UrgeDefinition.GetUrgeList_Class> GetUrgeList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["URGEDEFINITION"].QueryDefs["GetUrgeList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UrgeDefinition.GetUrgeList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
            set { this["NAME_SHADOW"] = value; }
        }

        protected UrgeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UrgeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UrgeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UrgeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UrgeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "URGEDEFINITION", dataRow) { }
        protected UrgeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "URGEDEFINITION", dataRow, isImported) { }
        public UrgeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UrgeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UrgeDefinition() : base() { }

    }
}