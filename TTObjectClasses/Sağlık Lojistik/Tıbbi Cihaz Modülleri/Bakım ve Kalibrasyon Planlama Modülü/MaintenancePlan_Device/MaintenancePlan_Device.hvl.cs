
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaintenancePlan_Device")] 

    /// <summary>
    /// Bakım / Kalibrasyon Planlama Cihaz Sekmesi
    /// </summary>
    public  partial class MaintenancePlan_Device : TTObject
    {
        public class MaintenancePlan_DeviceList : TTObjectCollection<MaintenancePlan_Device> { }
                    
        public class ChildMaintenancePlan_DeviceCollection : TTObject.TTChildObjectCollection<MaintenancePlan_Device>
        {
            public ChildMaintenancePlan_DeviceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaintenancePlan_DeviceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public FixedAssetMaterialDefinition FixedAssetMaterialDefinition
        {
            get { return (FixedAssetMaterialDefinition)((ITTObject)this).GetParent("FIXEDASSETMATERIALDEFINITION"); }
            set { this["FIXEDASSETMATERIALDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaintenancePlan MaintenancePlan
        {
            get { return (MaintenancePlan)((ITTObject)this).GetParent("MAINTENANCEPLAN"); }
            set { this["MAINTENANCEPLAN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaintenancePlan_Device(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaintenancePlan_Device(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaintenancePlan_Device(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaintenancePlan_Device(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaintenancePlan_Device(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINTENANCEPLAN_DEVICE", dataRow) { }
        protected MaintenancePlan_Device(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINTENANCEPLAN_DEVICE", dataRow, isImported) { }
        public MaintenancePlan_Device(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaintenancePlan_Device(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaintenancePlan_Device() : base() { }

    }
}