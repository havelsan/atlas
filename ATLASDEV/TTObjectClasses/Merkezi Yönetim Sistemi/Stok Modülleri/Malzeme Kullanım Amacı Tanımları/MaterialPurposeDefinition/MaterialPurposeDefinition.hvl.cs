
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaterialPurposeDefinition")] 

    public  partial class MaterialPurposeDefinition : TerminologyManagerDef
    {
        public class MaterialPurposeDefinitionList : TTObjectCollection<MaterialPurposeDefinition> { }
                    
        public class ChildMaterialPurposeDefinitionCollection : TTObject.TTChildObjectCollection<MaterialPurposeDefinition>
        {
            public ChildMaterialPurposeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaterialPurposeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMaterialPurposeDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Purpose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURPOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALPURPOSEDEFINITION"].AllPropertyDefs["PURPOSE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMaterialPurposeDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialPurposeDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialPurposeDefinitionList_Class() : base() { }
        }

        public static BindingList<MaterialPurposeDefinition.GetMaterialPurposeDefinitionList_Class> GetMaterialPurposeDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPURPOSEDEFINITION"].QueryDefs["GetMaterialPurposeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaterialPurposeDefinition.GetMaterialPurposeDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MaterialPurposeDefinition.GetMaterialPurposeDefinitionList_Class> GetMaterialPurposeDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPURPOSEDEFINITION"].QueryDefs["GetMaterialPurposeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaterialPurposeDefinition.GetMaterialPurposeDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kullanım Amacı
    /// </summary>
        public string Purpose
        {
            get { return (string)this["PURPOSE"]; }
            set { this["PURPOSE"] = value; }
        }

        protected MaterialPurposeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaterialPurposeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaterialPurposeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaterialPurposeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaterialPurposeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATERIALPURPOSEDEFINITION", dataRow) { }
        protected MaterialPurposeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATERIALPURPOSEDEFINITION", dataRow, isImported) { }
        public MaterialPurposeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaterialPurposeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaterialPurposeDefinition() : base() { }

    }
}