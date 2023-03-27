
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneticEquipment")] 

    /// <summary>
    /// Genetik Cihaz
    /// </summary>
    public  partial class GeneticEquipment : TTObject
    {
        public class GeneticEquipmentList : TTObjectCollection<GeneticEquipment> { }
                    
        public class ChildGeneticEquipmentCollection : TTObject.TTChildObjectCollection<GeneticEquipment>
        {
            public ChildGeneticEquipmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneticEquipmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tıbbi Genetic Cihazı ilişkisi
    /// </summary>
        public ResGeneticEqiupmentDef Equipment
        {
            get { return (ResGeneticEqiupmentDef)((ITTObject)this).GetParent("EQUIPMENT"); }
            set { this["EQUIPMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tıbbi Genetik Ana İlişkisi
    /// </summary>
        public Genetic Genetic
        {
            get { return (Genetic)((ITTObject)this).GetParent("GENETIC"); }
            set { this["GENETIC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected GeneticEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneticEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneticEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneticEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneticEquipment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENETICEQUIPMENT", dataRow) { }
        protected GeneticEquipment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENETICEQUIPMENT", dataRow, isImported) { }
        public GeneticEquipment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneticEquipment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneticEquipment() : base() { }

    }
}