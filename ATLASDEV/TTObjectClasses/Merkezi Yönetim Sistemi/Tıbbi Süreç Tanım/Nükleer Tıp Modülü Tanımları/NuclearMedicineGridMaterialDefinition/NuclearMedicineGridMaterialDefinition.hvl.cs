
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NuclearMedicineGridMaterialDefinition")] 

    public  partial class NuclearMedicineGridMaterialDefinition : TTDefinitionSet
    {
        public class NuclearMedicineGridMaterialDefinitionList : TTObjectCollection<NuclearMedicineGridMaterialDefinition> { }
                    
        public class ChildNuclearMedicineGridMaterialDefinitionCollection : TTObject.TTChildObjectCollection<NuclearMedicineGridMaterialDefinition>
        {
            public ChildNuclearMedicineGridMaterialDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNuclearMedicineGridMaterialDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Malzeme ile olan ilişkisi
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Nükleer Tıp Test Tanımı İlişkisi
    /// </summary>
        public NuclearMedicineTestDefinition NuclearMedicineTest
        {
            get { return (NuclearMedicineTestDefinition)((ITTObject)this).GetParent("NUCLEARMEDICINETEST"); }
            set { this["NUCLEARMEDICINETEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NuclearMedicineGridMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NuclearMedicineGridMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NuclearMedicineGridMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NuclearMedicineGridMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NuclearMedicineGridMaterialDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NUCLEARMEDICINEGRIDMATERIALDEFINITION", dataRow) { }
        protected NuclearMedicineGridMaterialDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NUCLEARMEDICINEGRIDMATERIALDEFINITION", dataRow, isImported) { }
        public NuclearMedicineGridMaterialDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NuclearMedicineGridMaterialDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NuclearMedicineGridMaterialDefinition() : base() { }

    }
}