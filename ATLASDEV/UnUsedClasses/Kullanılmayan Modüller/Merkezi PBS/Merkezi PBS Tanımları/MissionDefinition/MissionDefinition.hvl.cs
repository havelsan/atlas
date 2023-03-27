
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MissionDefinition")] 

    public  partial class MissionDefinition : TerminologyManagerDef
    {
        public class MissionDefinitionList : TTObjectCollection<MissionDefinition> { }
                    
        public class ChildMissionDefinitionCollection : TTObject.TTChildObjectCollection<MissionDefinition>
        {
            public ChildMissionDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMissionDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMissionDefinitionList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MISSIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sharedname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHAREDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SHAREDMISSIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMissionDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMissionDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMissionDefinitionList_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetMissionDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MISSIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? SharedMissionId
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SHAREDMISSIONID"]);
                }
            }

            public OLAP_GetMissionDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetMissionDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetMissionDefinition_Class() : base() { }
        }

        public static BindingList<MissionDefinition.GetMissionDefinitionList_Class> GetMissionDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MISSIONDEFINITION"].QueryDefs["GetMissionDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MissionDefinition.GetMissionDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MissionDefinition.GetMissionDefinitionList_Class> GetMissionDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MISSIONDEFINITION"].QueryDefs["GetMissionDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MissionDefinition.GetMissionDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MissionDefinition.OLAP_GetMissionDefinition_Class> OLAP_GetMissionDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MISSIONDEFINITION"].QueryDefs["OLAP_GetMissionDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MissionDefinition.OLAP_GetMissionDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MissionDefinition.OLAP_GetMissionDefinition_Class> OLAP_GetMissionDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MISSIONDEFINITION"].QueryDefs["OLAP_GetMissionDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MissionDefinition.OLAP_GetMissionDefinition_Class>(objectContext, queryDef, paramList, pi);
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

    /// <summary>
    /// SharedMission
    /// </summary>
        public SharedMissionDefinition SharedMissionId
        {
            get { return (SharedMissionDefinition)((ITTObject)this).GetParent("SHAREDMISSIONID"); }
            set { this["SHAREDMISSIONID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MissionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MissionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MissionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MissionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MissionDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MISSIONDEFINITION", dataRow) { }
        protected MissionDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MISSIONDEFINITION", dataRow, isImported) { }
        public MissionDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MissionDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MissionDefinition() : base() { }

    }
}