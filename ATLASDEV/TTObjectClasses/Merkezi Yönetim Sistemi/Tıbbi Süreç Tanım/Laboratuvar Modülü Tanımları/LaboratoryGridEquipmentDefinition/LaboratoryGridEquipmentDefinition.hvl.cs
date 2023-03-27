
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryGridEquipmentDefinition")] 

    public  partial class LaboratoryGridEquipmentDefinition : TTDefinitionSet
    {
        public class LaboratoryGridEquipmentDefinitionList : TTObjectCollection<LaboratoryGridEquipmentDefinition> { }
                    
        public class ChildLaboratoryGridEquipmentDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryGridEquipmentDefinition>
        {
            public ChildLaboratoryGridEquipmentDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryGridEquipmentDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Cihaz İlişkisi
    /// </summary>
        public ResLaboratoryEquipment Equipment
        {
            get { return (ResLaboratoryEquipment)((ITTObject)this).GetParent("EQUIPMENT"); }
            set { this["EQUIPMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Laboratuvar Test Tanım İlişkisi
    /// </summary>
        public LaboratoryTestDefinition LaboratoryTestDefinition
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("LABORATORYTESTDEFINITION"); }
            set { this["LABORATORYTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LaboratoryGridEquipmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryGridEquipmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryGridEquipmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryGridEquipmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryGridEquipmentDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYGRIDEQUIPMENTDEFINITION", dataRow) { }
        protected LaboratoryGridEquipmentDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYGRIDEQUIPMENTDEFINITION", dataRow, isImported) { }
        public LaboratoryGridEquipmentDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryGridEquipmentDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryGridEquipmentDefinition() : base() { }

    }
}