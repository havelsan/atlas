
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HyperbaricTreatmentEquipment")] 

    public  partial class HyperbaricTreatmentEquipment : TTObject
    {
        public class HyperbaricTreatmentEquipmentList : TTObjectCollection<HyperbaricTreatmentEquipment> { }
                    
        public class ChildHyperbaricTreatmentEquipmentCollection : TTObject.TTChildObjectCollection<HyperbaricTreatmentEquipment>
        {
            public ChildHyperbaricTreatmentEquipmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHyperbaricTreatmentEquipmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ResEquipment HyperbaricEquipment
        {
            get { return (ResEquipment)((ITTObject)this).GetParent("HYPERBARICEQUIPMENT"); }
            set { this["HYPERBARICEQUIPMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HyperbaricOxygenTreatmentDefinition HyperbaricOxygenTreatmentDef
        {
            get { return (HyperbaricOxygenTreatmentDefinition)((ITTObject)this).GetParent("HYPERBARICOXYGENTREATMENTDEF"); }
            set { this["HYPERBARICOXYGENTREATMENTDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HyperbaricTreatmentEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HyperbaricTreatmentEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HyperbaricTreatmentEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HyperbaricTreatmentEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HyperbaricTreatmentEquipment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HYPERBARICTREATMENTEQUIPMENT", dataRow) { }
        protected HyperbaricTreatmentEquipment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HYPERBARICTREATMENTEQUIPMENT", dataRow, isImported) { }
        public HyperbaricTreatmentEquipment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HyperbaricTreatmentEquipment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HyperbaricTreatmentEquipment() : base() { }

    }
}