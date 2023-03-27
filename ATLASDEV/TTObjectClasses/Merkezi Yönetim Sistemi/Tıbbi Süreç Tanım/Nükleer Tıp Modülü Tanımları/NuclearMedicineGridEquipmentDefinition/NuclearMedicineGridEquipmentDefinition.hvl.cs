
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NuclearMedicineGridEquipmentDefinition")] 

    public  partial class NuclearMedicineGridEquipmentDefinition : TTDefinitionSet
    {
        public class NuclearMedicineGridEquipmentDefinitionList : TTObjectCollection<NuclearMedicineGridEquipmentDefinition> { }
                    
        public class ChildNuclearMedicineGridEquipmentDefinitionCollection : TTObject.TTChildObjectCollection<NuclearMedicineGridEquipmentDefinition>
        {
            public ChildNuclearMedicineGridEquipmentDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNuclearMedicineGridEquipmentDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Nükleer Tıp Cihaz İlişkisi
    /// </summary>
        public ResNuclearMedicineEquipment MyEquipment
        {
            get { return (ResNuclearMedicineEquipment)((ITTObject)this).GetParent("MYEQUIPMENT"); }
            set { this["MYEQUIPMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Nükleer Tıp Test Tanım İlişkisi
    /// </summary>
        public NuclearMedicineTestDefinition NuclearMedicineTest
        {
            get { return (NuclearMedicineTestDefinition)((ITTObject)this).GetParent("NUCLEARMEDICINETEST"); }
            set { this["NUCLEARMEDICINETEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NuclearMedicineGridEquipmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NuclearMedicineGridEquipmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NuclearMedicineGridEquipmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NuclearMedicineGridEquipmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NuclearMedicineGridEquipmentDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NUCLEARMEDICINEGRIDEQUIPMENTDEFINITION", dataRow) { }
        protected NuclearMedicineGridEquipmentDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NUCLEARMEDICINEGRIDEQUIPMENTDEFINITION", dataRow, isImported) { }
        public NuclearMedicineGridEquipmentDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NuclearMedicineGridEquipmentDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NuclearMedicineGridEquipmentDefinition() : base() { }

    }
}