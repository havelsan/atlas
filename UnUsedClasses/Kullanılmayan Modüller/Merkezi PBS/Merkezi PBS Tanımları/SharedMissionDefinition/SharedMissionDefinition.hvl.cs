
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SharedMissionDefinition")] 

    public  partial class SharedMissionDefinition : TerminologyManagerDef
    {
        public class SharedMissionDefinitionList : TTObjectCollection<SharedMissionDefinition> { }
                    
        public class ChildSharedMissionDefinitionCollection : TTObject.TTChildObjectCollection<SharedMissionDefinition>
        {
            public ChildSharedMissionDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSharedMissionDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSharedMissionDefinitionList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SHAREDMISSIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSharedMissionDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSharedMissionDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSharedMissionDefinitionList_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_SharedMissionDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SHAREDMISSIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_SharedMissionDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_SharedMissionDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_SharedMissionDefinition_Class() : base() { }
        }

        public static BindingList<SharedMissionDefinition.GetSharedMissionDefinitionList_Class> GetSharedMissionDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SHAREDMISSIONDEFINITION"].QueryDefs["GetSharedMissionDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SharedMissionDefinition.GetSharedMissionDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SharedMissionDefinition.GetSharedMissionDefinitionList_Class> GetSharedMissionDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SHAREDMISSIONDEFINITION"].QueryDefs["GetSharedMissionDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SharedMissionDefinition.GetSharedMissionDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SharedMissionDefinition.OLAP_SharedMissionDefinition_Class> OLAP_SharedMissionDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SHAREDMISSIONDEFINITION"].QueryDefs["OLAP_SharedMissionDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SharedMissionDefinition.OLAP_SharedMissionDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SharedMissionDefinition.OLAP_SharedMissionDefinition_Class> OLAP_SharedMissionDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SHAREDMISSIONDEFINITION"].QueryDefs["OLAP_SharedMissionDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SharedMissionDefinition.OLAP_SharedMissionDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public string NAME
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string ALIAS
        {
            get { return (string)this["ALIAS"]; }
            set { this["ALIAS"] = value; }
        }

        protected SharedMissionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SharedMissionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SharedMissionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SharedMissionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SharedMissionDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SHAREDMISSIONDEFINITION", dataRow) { }
        protected SharedMissionDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SHAREDMISSIONDEFINITION", dataRow, isImported) { }
        public SharedMissionDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SharedMissionDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SharedMissionDefinition() : base() { }

    }
}