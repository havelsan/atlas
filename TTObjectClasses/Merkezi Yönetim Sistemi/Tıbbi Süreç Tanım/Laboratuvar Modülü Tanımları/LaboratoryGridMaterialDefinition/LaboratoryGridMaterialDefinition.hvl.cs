
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryGridMaterialDefinition")] 

    public  partial class LaboratoryGridMaterialDefinition : TTDefinitionSet
    {
        public class LaboratoryGridMaterialDefinitionList : TTObjectCollection<LaboratoryGridMaterialDefinition> { }
                    
        public class ChildLaboratoryGridMaterialDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryGridMaterialDefinition>
        {
            public ChildLaboratoryGridMaterialDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryGridMaterialDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Laboratuvar Test Tanımı İlişkisi
    /// </summary>
        public LaboratoryTestDefinition LaboratoryTestDefinition
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("LABORATORYTESTDEFINITION"); }
            set { this["LABORATORYTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Malzeme İlişkisi
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LaboratoryGridMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryGridMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryGridMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryGridMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryGridMaterialDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYGRIDMATERIALDEFINITION", dataRow) { }
        protected LaboratoryGridMaterialDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYGRIDMATERIALDEFINITION", dataRow, isImported) { }
        public LaboratoryGridMaterialDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryGridMaterialDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryGridMaterialDefinition() : base() { }

    }
}