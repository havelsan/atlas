
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Maintenance_ConsumedMaterial")] 

    /// <summary>
    /// Sipariş İstek Yapılan Malzeme Sekmesi
    /// </summary>
    public  partial class Maintenance_ConsumedMaterial : ConsumedMaterial
    {
        public class Maintenance_ConsumedMaterialList : TTObjectCollection<Maintenance_ConsumedMaterial> { }
                    
        public class ChildMaintenance_ConsumedMaterialCollection : TTObject.TTChildObjectCollection<Maintenance_ConsumedMaterial>
        {
            public ChildMaintenance_ConsumedMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaintenance_ConsumedMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public MaintenanceOrder MaintenanceOrder
        {
            get { return (MaintenanceOrder)((ITTObject)this).GetParent("MAINTENANCEORDER"); }
            set { this["MAINTENANCEORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected Maintenance_ConsumedMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Maintenance_ConsumedMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Maintenance_ConsumedMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Maintenance_ConsumedMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Maintenance_ConsumedMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINTENANCE_CONSUMEDMATERIAL", dataRow) { }
        protected Maintenance_ConsumedMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINTENANCE_CONSUMEDMATERIAL", dataRow, isImported) { }
        public Maintenance_ConsumedMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Maintenance_ConsumedMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Maintenance_ConsumedMaterial() : base() { }

    }
}