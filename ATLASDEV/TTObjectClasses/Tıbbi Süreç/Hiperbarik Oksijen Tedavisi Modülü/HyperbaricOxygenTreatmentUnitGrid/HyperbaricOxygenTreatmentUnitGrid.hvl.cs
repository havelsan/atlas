
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HyperbaricOxygenTreatmentUnitGrid")] 

    /// <summary>
    /// Deniz ve Sualtı Hekimliği Kaynak Listesi
    /// </summary>
    public  partial class HyperbaricOxygenTreatmentUnitGrid : TTObject
    {
        public class HyperbaricOxygenTreatmentUnitGridList : TTObjectCollection<HyperbaricOxygenTreatmentUnitGrid> { }
                    
        public class ChildHyperbaricOxygenTreatmentUnitGridCollection : TTObject.TTChildObjectCollection<HyperbaricOxygenTreatmentUnitGrid>
        {
            public ChildHyperbaricOxygenTreatmentUnitGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHyperbaricOxygenTreatmentUnitGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hiperbarik Oksijen Tedavi Ünitesi
    /// </summary>
        public ResSection HyperbaricOxygenTreatmentUnit
        {
            get { return (ResSection)((ITTObject)this).GetParent("HYPERBARICOXYGENTREATMENTUNIT"); }
            set { this["HYPERBARICOXYGENTREATMENTUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tanı Tedavi Üniteleri
    /// </summary>
        public HyperbaricOxygenTreatmentDefinition HyperbaricOxygenTreatmentDef
        {
            get { return (HyperbaricOxygenTreatmentDefinition)((ITTObject)this).GetParent("HYPERBARICOXYGENTREATMENTDEF"); }
            set { this["HYPERBARICOXYGENTREATMENTDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HyperbaricOxygenTreatmentUnitGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HyperbaricOxygenTreatmentUnitGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HyperbaricOxygenTreatmentUnitGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HyperbaricOxygenTreatmentUnitGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HyperbaricOxygenTreatmentUnitGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HYPERBARICOXYGENTREATMENTUNITGRID", dataRow) { }
        protected HyperbaricOxygenTreatmentUnitGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HYPERBARICOXYGENTREATMENTUNITGRID", dataRow, isImported) { }
        protected HyperbaricOxygenTreatmentUnitGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HyperbaricOxygenTreatmentUnitGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HyperbaricOxygenTreatmentUnitGrid() : base() { }

    }
}