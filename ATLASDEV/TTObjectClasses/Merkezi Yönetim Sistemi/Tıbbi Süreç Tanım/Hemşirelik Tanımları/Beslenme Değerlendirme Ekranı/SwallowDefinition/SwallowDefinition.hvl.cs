
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SwallowDefinition")] 

    public  partial class SwallowDefinition : TerminologyManagerDef
    {
        public class SwallowDefinitionList : TTObjectCollection<SwallowDefinition> { }
                    
        public class ChildSwallowDefinitionCollection : TTObject.TTChildObjectCollection<SwallowDefinition>
        {
            public ChildSwallowDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSwallowDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSwallowList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SWALLOWDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSwallowList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSwallowList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSwallowList_Class() : base() { }
        }

        public static BindingList<SwallowDefinition.GetSwallowList_Class> GetSwallowList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SWALLOWDEFINITION"].QueryDefs["GetSwallowList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SwallowDefinition.GetSwallowList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SwallowDefinition.GetSwallowList_Class> GetSwallowList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SWALLOWDEFINITION"].QueryDefs["GetSwallowList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SwallowDefinition.GetSwallowList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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

        protected SwallowDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SwallowDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SwallowDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SwallowDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SwallowDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SWALLOWDEFINITION", dataRow) { }
        protected SwallowDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SWALLOWDEFINITION", dataRow, isImported) { }
        public SwallowDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SwallowDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SwallowDefinition() : base() { }

    }
}