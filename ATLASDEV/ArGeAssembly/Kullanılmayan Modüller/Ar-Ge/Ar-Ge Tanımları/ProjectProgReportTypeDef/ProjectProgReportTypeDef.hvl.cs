
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProjectProgReportTypeDef")] 

    public  partial class ProjectProgReportTypeDef : BaseResDevDef
    {
        public class ProjectProgReportTypeDefList : TTObjectCollection<ProjectProgReportTypeDef> { }
                    
        public class ChildProjectProgReportTypeDefCollection : TTObject.TTChildObjectCollection<ProjectProgReportTypeDef>
        {
            public ChildProjectProgReportTypeDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProjectProgReportTypeDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetProjectProgRepTypeDef_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROJECTPROGREPORTTYPEDEF"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROJECTPROGREPORTTYPEDEF"].AllPropertyDefs["CODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetProjectProgRepTypeDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProjectProgRepTypeDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProjectProgRepTypeDef_Class() : base() { }
        }

        public static BindingList<ProjectProgReportTypeDef.GetProjectProgRepTypeDef_Class> GetProjectProgRepTypeDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROJECTPROGREPORTTYPEDEF"].QueryDefs["GetProjectProgRepTypeDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProjectProgReportTypeDef.GetProjectProgRepTypeDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProjectProgReportTypeDef.GetProjectProgRepTypeDef_Class> GetProjectProgRepTypeDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROJECTPROGREPORTTYPEDEF"].QueryDefs["GetProjectProgRepTypeDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProjectProgReportTypeDef.GetProjectProgRepTypeDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected ProjectProgReportTypeDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProjectProgReportTypeDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProjectProgReportTypeDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProjectProgReportTypeDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProjectProgReportTypeDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROJECTPROGREPORTTYPEDEF", dataRow) { }
        protected ProjectProgReportTypeDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROJECTPROGREPORTTYPEDEF", dataRow, isImported) { }
        public ProjectProgReportTypeDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProjectProgReportTypeDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProjectProgReportTypeDef() : base() { }

    }
}