
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SurgeryStatusDefinition")] 

    /// <summary>
    /// Ameliyat Durumu Tanımlama
    /// </summary>
    public  partial class SurgeryStatusDefinition : TTDefinitionSet
    {
        public class SurgeryStatusDefinitionList : TTObjectCollection<SurgeryStatusDefinition> { }
                    
        public class ChildSurgeryStatusDefinitionCollection : TTObject.TTChildObjectCollection<SurgeryStatusDefinition>
        {
            public ChildSurgeryStatusDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurgeryStatusDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class SurgeryStatusDefinitionNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYSTATUSDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SurgeryStatusDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SurgeryStatusDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SurgeryStatusDefinitionNQL_Class() : base() { }
        }

        public static BindingList<SurgeryStatusDefinition.SurgeryStatusDefinitionNQL_Class> SurgeryStatusDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYSTATUSDEFINITION"].QueryDefs["SurgeryStatusDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryStatusDefinition.SurgeryStatusDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SurgeryStatusDefinition.SurgeryStatusDefinitionNQL_Class> SurgeryStatusDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYSTATUSDEFINITION"].QueryDefs["SurgeryStatusDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryStatusDefinition.SurgeryStatusDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SurgeryStatusDefinition> GetSurgeryStatusDefinitionList(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYSTATUSDEFINITION"].QueryDefs["GetSurgeryStatusDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<SurgeryStatusDefinition>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Ameliyat Durumu Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected SurgeryStatusDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SurgeryStatusDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SurgeryStatusDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SurgeryStatusDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SurgeryStatusDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURGERYSTATUSDEFINITION", dataRow) { }
        protected SurgeryStatusDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURGERYSTATUSDEFINITION", dataRow, isImported) { }
        public SurgeryStatusDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SurgeryStatusDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SurgeryStatusDefinition() : base() { }

    }
}