
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaintenancePlan_Personnel")] 

    /// <summary>
    /// Bakım / Kalibrasyon Planlama Personel Sekmesi
    /// </summary>
    public  partial class MaintenancePlan_Personnel : TTObject
    {
        public class MaintenancePlan_PersonnelList : TTObjectCollection<MaintenancePlan_Personnel> { }
                    
        public class ChildMaintenancePlan_PersonnelCollection : TTObject.TTChildObjectCollection<MaintenancePlan_Personnel>
        {
            public ChildMaintenancePlan_PersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaintenancePlan_PersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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

        public ResUser WorkShopUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("WORKSHOPUSER"); }
            set { this["WORKSHOPUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaintenancePlan_Personnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaintenancePlan_Personnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaintenancePlan_Personnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaintenancePlan_Personnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaintenancePlan_Personnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINTENANCEPLAN_PERSONNEL", dataRow) { }
        protected MaintenancePlan_Personnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINTENANCEPLAN_PERSONNEL", dataRow, isImported) { }
        public MaintenancePlan_Personnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaintenancePlan_Personnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaintenancePlan_Personnel() : base() { }

    }
}