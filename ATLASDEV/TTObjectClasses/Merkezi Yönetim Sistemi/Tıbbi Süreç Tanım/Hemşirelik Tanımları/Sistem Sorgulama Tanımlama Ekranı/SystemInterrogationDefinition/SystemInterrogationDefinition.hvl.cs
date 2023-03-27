
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SystemInterrogationDefinition")] 

    public  partial class SystemInterrogationDefinition : TerminologyManagerDef
    {
        public class SystemInterrogationDefinitionList : TTObjectCollection<SystemInterrogationDefinition> { }
                    
        public class ChildSystemInterrogationDefinitionCollection : TTObject.TTChildObjectCollection<SystemInterrogationDefinition>
        {
            public ChildSystemInterrogationDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSystemInterrogationDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSystemInterrogationDefinitionList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMINTERROGATIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public NursingSystemInterrogationEnum? ActivityGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVITYGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMINTERROGATIONDEFINITION"].AllPropertyDefs["ACTIVITYGROUP"].DataType;
                    return (NursingSystemInterrogationEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Groupname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GROUPNAME"]);
                }
            }

            public Object Text
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TEXT"]);
                }
            }

            public GetSystemInterrogationDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSystemInterrogationDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSystemInterrogationDefinitionList_Class() : base() { }
        }

        public static BindingList<SystemInterrogationDefinition> GetAllSysInterrogDefList(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SYSTEMINTERROGATIONDEFINITION"].QueryDefs["GetAllSysInterrogDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<SystemInterrogationDefinition>(queryDef, paramList);
        }

        public static BindingList<SystemInterrogationDefinition.GetSystemInterrogationDefinitionList_Class> GetSystemInterrogationDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SYSTEMINTERROGATIONDEFINITION"].QueryDefs["GetSystemInterrogationDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SystemInterrogationDefinition.GetSystemInterrogationDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SystemInterrogationDefinition.GetSystemInterrogationDefinitionList_Class> GetSystemInterrogationDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SYSTEMINTERROGATIONDEFINITION"].QueryDefs["GetSystemInterrogationDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SystemInterrogationDefinition.GetSystemInterrogationDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Grup
    /// </summary>
        public NursingSystemInterrogationEnum? ActivityGroup
        {
            get { return (NursingSystemInterrogationEnum?)(int?)this["ACTIVITYGROUP"]; }
            set { this["ACTIVITYGROUP"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected SystemInterrogationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SystemInterrogationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SystemInterrogationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SystemInterrogationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SystemInterrogationDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SYSTEMINTERROGATIONDEFINITION", dataRow) { }
        protected SystemInterrogationDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SYSTEMINTERROGATIONDEFINITION", dataRow, isImported) { }
        public SystemInterrogationDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SystemInterrogationDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SystemInterrogationDefinition() : base() { }

    }
}