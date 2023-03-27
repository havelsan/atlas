
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneticGridEquipmentDefinition")] 

    public  partial class GeneticGridEquipmentDefinition : TTDefinitionSet
    {
        public class GeneticGridEquipmentDefinitionList : TTObjectCollection<GeneticGridEquipmentDefinition> { }
                    
        public class ChildGeneticGridEquipmentDefinitionCollection : TTObject.TTChildObjectCollection<GeneticGridEquipmentDefinition>
        {
            public ChildGeneticGridEquipmentDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneticGridEquipmentDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ResGeneticEqiupmentDef MyEquipment
        {
            get { return (ResGeneticEqiupmentDef)((ITTObject)this).GetParent("MYEQUIPMENT"); }
            set { this["MYEQUIPMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public GeneticTestDefinition GeneticTest
        {
            get { return (GeneticTestDefinition)((ITTObject)this).GetParent("GENETICTEST"); }
            set { this["GENETICTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected GeneticGridEquipmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneticGridEquipmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneticGridEquipmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneticGridEquipmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneticGridEquipmentDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENETICGRIDEQUIPMENTDEFINITION", dataRow) { }
        protected GeneticGridEquipmentDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENETICGRIDEQUIPMENTDEFINITION", dataRow, isImported) { }
        public GeneticGridEquipmentDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneticGridEquipmentDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneticGridEquipmentDefinition() : base() { }

    }
}