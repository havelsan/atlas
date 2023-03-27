
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaintenancePlan_Service")] 

    /// <summary>
    /// Bakım / Kalibrasyon Planlama Servis Sekmesi
    /// </summary>
    public  partial class MaintenancePlan_Service : TTObject
    {
        public class MaintenancePlan_ServiceList : TTObjectCollection<MaintenancePlan_Service> { }
                    
        public class ChildMaintenancePlan_ServiceCollection : TTObject.TTChildObjectCollection<MaintenancePlan_Service>
        {
            public ChildMaintenancePlan_ServiceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaintenancePlan_ServiceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İş Yükü
    /// </summary>
        public int? Workload
        {
            get { return (int?)this["WORKLOAD"]; }
            set { this["WORKLOAD"] = value; }
        }

        public MaintenancePlan MaintenancePlan
        {
            get { return (MaintenancePlan)((ITTObject)this).GetParent("MAINTENANCEPLAN"); }
            set { this["MAINTENANCEPLAN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Service Service
        {
            get { return (Service)((ITTObject)this).GetParent("SERVICE"); }
            set { this["SERVICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Resource Resource
        {
            get { return (Resource)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser WorkShopUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("WORKSHOPUSER"); }
            set { this["WORKSHOPUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaintenancePlan_Service(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaintenancePlan_Service(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaintenancePlan_Service(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaintenancePlan_Service(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaintenancePlan_Service(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINTENANCEPLAN_SERVICE", dataRow) { }
        protected MaintenancePlan_Service(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINTENANCEPLAN_SERVICE", dataRow, isImported) { }
        public MaintenancePlan_Service(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaintenancePlan_Service(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaintenancePlan_Service() : base() { }

    }
}