
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BranchDefinition")] 

    public  partial class BranchDefinition : TerminologyManagerDef
    {
        public class BranchDefinitionList : TTObjectCollection<BranchDefinition> { }
                    
        public class ChildBranchDefinitionCollection : TTObject.TTChildObjectCollection<BranchDefinition>
        {
            public ChildBranchDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBranchDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBranchDefinitionList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BRANCHDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetBranchDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBranchDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBranchDefinitionList_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_BranchDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BRANCHDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_BranchDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_BranchDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_BranchDefinition_Class() : base() { }
        }

        public static BindingList<BranchDefinition.GetBranchDefinitionList_Class> GetBranchDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BRANCHDEFINITION"].QueryDefs["GetBranchDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BranchDefinition.GetBranchDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BranchDefinition.GetBranchDefinitionList_Class> GetBranchDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BRANCHDEFINITION"].QueryDefs["GetBranchDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BranchDefinition.GetBranchDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BranchDefinition.OLAP_BranchDefinition_Class> OLAP_BranchDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BRANCHDEFINITION"].QueryDefs["OLAP_BranchDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BranchDefinition.OLAP_BranchDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BranchDefinition.OLAP_BranchDefinition_Class> OLAP_BranchDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BRANCHDEFINITION"].QueryDefs["OLAP_BranchDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BranchDefinition.OLAP_BranchDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public string NAME
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected BranchDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BranchDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BranchDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BranchDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BranchDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BRANCHDEFINITION", dataRow) { }
        protected BranchDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BRANCHDEFINITION", dataRow, isImported) { }
        public BranchDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BranchDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BranchDefinition() : base() { }

    }
}