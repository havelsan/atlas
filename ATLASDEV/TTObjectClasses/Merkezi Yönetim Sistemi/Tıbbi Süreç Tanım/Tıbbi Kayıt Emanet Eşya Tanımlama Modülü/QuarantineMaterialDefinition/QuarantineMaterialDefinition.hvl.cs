
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="QuarantineMaterialDefinition")] 

    /// <summary>
    /// Tıbbi Kayıt Emanet Eşya Tanımları
    /// </summary>
    public  partial class QuarantineMaterialDefinition : TTDefinitionSet
    {
        public class QuarantineMaterialDefinitionList : TTObjectCollection<QuarantineMaterialDefinition> { }
                    
        public class ChildQuarantineMaterialDefinitionCollection : TTObject.TTChildObjectCollection<QuarantineMaterialDefinition>
        {
            public ChildQuarantineMaterialDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildQuarantineMaterialDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetQuarantineMaterialDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Material
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QUARANTINEMATERIALDEFINITION"].AllPropertyDefs["MATERIAL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public QuarantineMaterialTypeEnum? MaterialType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QUARANTINEMATERIALDEFINITION"].AllPropertyDefs["MATERIALTYPE"].DataType;
                    return (QuarantineMaterialTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetQuarantineMaterialDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetQuarantineMaterialDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetQuarantineMaterialDefinition_Class() : base() { }
        }

        public static BindingList<QuarantineMaterialDefinition.GetQuarantineMaterialDefinition_Class> GetQuarantineMaterialDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QUARANTINEMATERIALDEFINITION"].QueryDefs["GetQuarantineMaterialDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<QuarantineMaterialDefinition.GetQuarantineMaterialDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<QuarantineMaterialDefinition.GetQuarantineMaterialDefinition_Class> GetQuarantineMaterialDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QUARANTINEMATERIALDEFINITION"].QueryDefs["GetQuarantineMaterialDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<QuarantineMaterialDefinition.GetQuarantineMaterialDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Karantine Malzeme Türü
    /// </summary>
        public QuarantineMaterialTypeEnum? MaterialType
        {
            get { return (QuarantineMaterialTypeEnum?)(int?)this["MATERIALTYPE"]; }
            set { this["MATERIALTYPE"] = value; }
        }

    /// <summary>
    /// Eşya Adı
    /// </summary>
        public string Material
        {
            get { return (string)this["MATERIAL"]; }
            set { this["MATERIAL"] = value; }
        }

        public string Material_Shadow
        {
            get { return (string)this["MATERIAL_SHADOW"]; }
        }

        protected QuarantineMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected QuarantineMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected QuarantineMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected QuarantineMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected QuarantineMaterialDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "QUARANTINEMATERIALDEFINITION", dataRow) { }
        protected QuarantineMaterialDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "QUARANTINEMATERIALDEFINITION", dataRow, isImported) { }
        protected QuarantineMaterialDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public QuarantineMaterialDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public QuarantineMaterialDefinition() : base() { }

    }
}