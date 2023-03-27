
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaintenancePlan_PlannedWorkDetail")] 

    /// <summary>
    /// Bakım / Kalibrasyon Planlama İş Saati Dağılım Sekmesi
    /// </summary>
    public  partial class MaintenancePlan_PlannedWorkDetail : TTObject
    {
        public class MaintenancePlan_PlannedWorkDetailList : TTObjectCollection<MaintenancePlan_PlannedWorkDetail> { }
                    
        public class ChildMaintenancePlan_PlannedWorkDetailCollection : TTObject.TTChildObjectCollection<MaintenancePlan_PlannedWorkDetail>
        {
            public ChildMaintenancePlan_PlannedWorkDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaintenancePlan_PlannedWorkDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

    /// <summary>
    /// İş Yükü
    /// </summary>
        public int? Workload
        {
            get { return (int?)this["WORKLOAD"]; }
            set { this["WORKLOAD"] = value; }
        }

        public MaintenancePlan_PlannedWork MaintenancePlan_PlannedWork
        {
            get { return (MaintenancePlan_PlannedWork)((ITTObject)this).GetParent("MAINTENANCEPLAN_PLANNEDWORK"); }
            set { this["MAINTENANCEPLAN_PLANNEDWORK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaintenancePlan_PlannedWorkDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaintenancePlan_PlannedWorkDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaintenancePlan_PlannedWorkDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaintenancePlan_PlannedWorkDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaintenancePlan_PlannedWorkDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINTENANCEPLAN_PLANNEDWORKDETAIL", dataRow) { }
        protected MaintenancePlan_PlannedWorkDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINTENANCEPLAN_PLANNEDWORKDETAIL", dataRow, isImported) { }
        public MaintenancePlan_PlannedWorkDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaintenancePlan_PlannedWorkDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaintenancePlan_PlannedWorkDetail() : base() { }

    }
}