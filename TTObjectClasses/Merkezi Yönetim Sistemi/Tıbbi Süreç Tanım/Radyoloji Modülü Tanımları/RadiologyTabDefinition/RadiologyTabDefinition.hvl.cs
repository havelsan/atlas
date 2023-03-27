
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyTabDefinition")] 

    /// <summary>
    /// Radyoloji İstek Ekran Tanımları
    /// </summary>
    public  partial class RadiologyTabDefinition : TTDefinitionSet
    {
        public class RadiologyTabDefinitionList : TTObjectCollection<RadiologyTabDefinition> { }
                    
        public class ChildRadiologyTabDefinitionCollection : TTObject.TTChildObjectCollection<RadiologyTabDefinition>
        {
            public ChildRadiologyTabDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyTabDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRadiologyTabDefinition_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTABDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? TabOrder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABORDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTABDEFINITION"].AllPropertyDefs["TABORDER"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetRadiologyTabDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRadiologyTabDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRadiologyTabDefinition_Class() : base() { }
        }

        public static BindingList<RadiologyTabDefinition> GetRadTabs(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTABDEFINITION"].QueryDefs["GetRadTabs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<RadiologyTabDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<RadiologyTabDefinition.GetRadiologyTabDefinition_Class> GetRadiologyTabDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTABDEFINITION"].QueryDefs["GetRadiologyTabDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTabDefinition.GetRadiologyTabDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiologyTabDefinition.GetRadiologyTabDefinition_Class> GetRadiologyTabDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTABDEFINITION"].QueryDefs["GetRadiologyTabDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTabDefinition.GetRadiologyTabDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Tab Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Sıra
    /// </summary>
        public int? TabOrder
        {
            get { return (int?)this["TABORDER"]; }
            set { this["TABORDER"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string TabDescription
        {
            get { return (string)this["TABDESCRIPTION"]; }
            set { this["TABDESCRIPTION"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        public ResRadiologyDepartment RadiologyDepartment
        {
            get { return (ResRadiologyDepartment)((ITTObject)this).GetParent("RADIOLOGYDEPARTMENT"); }
            set { this["RADIOLOGYDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RadiologyTabDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyTabDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyTabDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyTabDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyTabDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYTABDEFINITION", dataRow) { }
        protected RadiologyTabDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYTABDEFINITION", dataRow, isImported) { }
        public RadiologyTabDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyTabDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyTabDefinition() : base() { }

    }
}