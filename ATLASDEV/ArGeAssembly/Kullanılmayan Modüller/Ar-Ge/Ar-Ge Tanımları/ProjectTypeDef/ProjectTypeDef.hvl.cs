
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProjectTypeDef")] 

    public  partial class ProjectTypeDef : BaseResDevDef
    {
        public class ProjectTypeDefList : TTObjectCollection<ProjectTypeDef> { }
                    
        public class ChildProjectTypeDefCollection : TTObject.TTChildObjectCollection<ProjectTypeDef>
        {
            public ChildProjectTypeDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProjectTypeDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetProjectTypeDef_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROJECTTYPEDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROJECTTYPEDEF"].AllPropertyDefs["CODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetProjectTypeDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProjectTypeDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProjectTypeDef_Class() : base() { }
        }

        public static BindingList<ProjectTypeDef.GetProjectTypeDef_Class> GetProjectTypeDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROJECTTYPEDEF"].QueryDefs["GetProjectTypeDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProjectTypeDef.GetProjectTypeDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProjectTypeDef.GetProjectTypeDef_Class> GetProjectTypeDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROJECTTYPEDEF"].QueryDefs["GetProjectTypeDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProjectTypeDef.GetProjectTypeDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected ProjectTypeDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProjectTypeDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProjectTypeDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProjectTypeDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProjectTypeDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROJECTTYPEDEF", dataRow) { }
        protected ProjectTypeDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROJECTTYPEDEF", dataRow, isImported) { }
        public ProjectTypeDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProjectTypeDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProjectTypeDef() : base() { }

    }
}