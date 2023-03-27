
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProjectCodeDefinition")] 

    public  partial class ProjectCodeDefinition : TerminologyManagerDef
    {
        public class ProjectCodeDefinitionList : TTObjectCollection<ProjectCodeDefinition> { }
                    
        public class ChildProjectCodeDefinitionCollection : TTObject.TTChildObjectCollection<ProjectCodeDefinition>
        {
            public ChildProjectCodeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProjectCodeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetProjectCodeDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROJECTCODEDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROJECTCODEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetProjectCodeDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProjectCodeDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProjectCodeDefinitionList_Class() : base() { }
        }

        public static BindingList<ProjectCodeDefinition.GetProjectCodeDefinitionList_Class> GetProjectCodeDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROJECTCODEDEFINITION"].QueryDefs["GetProjectCodeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProjectCodeDefinition.GetProjectCodeDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProjectCodeDefinition.GetProjectCodeDefinitionList_Class> GetProjectCodeDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROJECTCODEDEFINITION"].QueryDefs["GetProjectCodeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProjectCodeDefinition.GetProjectCodeDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Proje Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Proje Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected ProjectCodeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProjectCodeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProjectCodeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProjectCodeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProjectCodeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROJECTCODEDEFINITION", dataRow) { }
        protected ProjectCodeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROJECTCODEDEFINITION", dataRow, isImported) { }
        public ProjectCodeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProjectCodeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProjectCodeDefinition() : base() { }

    }
}