
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SurgeryResultDefinition")] 

    /// <summary>
    /// Ameliyat Sonucu Tanımlama
    /// </summary>
    public  partial class SurgeryResultDefinition : TTDefinitionSet
    {
        public class SurgeryResultDefinitionList : TTObjectCollection<SurgeryResultDefinition> { }
                    
        public class ChildSurgeryResultDefinitionCollection : TTObject.TTChildObjectCollection<SurgeryResultDefinition>
        {
            public ChildSurgeryResultDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurgeryResultDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class SurgeryResultDefinitionNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYRESULTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SurgeryResultDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SurgeryResultDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SurgeryResultDefinitionNQL_Class() : base() { }
        }

        public static BindingList<SurgeryResultDefinition.SurgeryResultDefinitionNQL_Class> SurgeryResultDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYRESULTDEFINITION"].QueryDefs["SurgeryResultDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryResultDefinition.SurgeryResultDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SurgeryResultDefinition.SurgeryResultDefinitionNQL_Class> SurgeryResultDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYRESULTDEFINITION"].QueryDefs["SurgeryResultDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryResultDefinition.SurgeryResultDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected SurgeryResultDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SurgeryResultDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SurgeryResultDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SurgeryResultDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SurgeryResultDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURGERYRESULTDEFINITION", dataRow) { }
        protected SurgeryResultDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURGERYRESULTDEFINITION", dataRow, isImported) { }
        public SurgeryResultDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SurgeryResultDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SurgeryResultDefinition() : base() { }

    }
}