
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExternalReportTypeDefinition")] 

    public  partial class ExternalReportTypeDefinition : TerminologyManagerDef
    {
        public class ExternalReportTypeDefinitionList : TTObjectCollection<ExternalReportTypeDefinition> { }
                    
        public class ChildExternalReportTypeDefinitionCollection : TTObject.TTChildObjectCollection<ExternalReportTypeDefinition>
        {
            public ChildExternalReportTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExternalReportTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetExternalReportType_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALREPORTTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetExternalReportType_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetExternalReportType_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetExternalReportType_Class() : base() { }
        }

        public static BindingList<ExternalReportTypeDefinition.GetExternalReportType_Class> GetExternalReportType(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXTERNALREPORTTYPEDEFINITION"].QueryDefs["GetExternalReportType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ExternalReportTypeDefinition.GetExternalReportType_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ExternalReportTypeDefinition.GetExternalReportType_Class> GetExternalReportType(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXTERNALREPORTTYPEDEFINITION"].QueryDefs["GetExternalReportType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ExternalReportTypeDefinition.GetExternalReportType_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected ExternalReportTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExternalReportTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExternalReportTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExternalReportTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExternalReportTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXTERNALREPORTTYPEDEFINITION", dataRow) { }
        protected ExternalReportTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXTERNALREPORTTYPEDEFINITION", dataRow, isImported) { }
        public ExternalReportTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExternalReportTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExternalReportTypeDefinition() : base() { }

    }
}