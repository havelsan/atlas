
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaintenancePlan_PlannedWork")] 

    /// <summary>
    /// Bakım / Kalibrasyon Planlama Planlanan İş Sekmesi
    /// </summary>
    public  partial class MaintenancePlan_PlannedWork : TTObject
    {
        public class MaintenancePlan_PlannedWorkList : TTObjectCollection<MaintenancePlan_PlannedWork> { }
                    
        public class ChildMaintenancePlan_PlannedWorkCollection : TTObject.TTChildObjectCollection<MaintenancePlan_PlannedWork>
        {
            public ChildMaintenancePlan_PlannedWorkCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaintenancePlan_PlannedWorkCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("27481b6b-32e9-4e35-9c4d-5ee7a65a1518"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("3c2604e3-94f9-4361-99ae-ccc4ebc645c7"); } }
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
    /// Planlama Türü
    /// </summary>
        public MaintenancePlanTypeEnum? MaintenancePlanType
        {
            get { return (MaintenancePlanTypeEnum?)(int?)this["MAINTENANCEPLANTYPE"]; }
            set { this["MAINTENANCEPLANTYPE"] = value; }
        }

        public Maintenance Maintenance
        {
            get { return (Maintenance)((ITTObject)this).GetParent("MAINTENANCE"); }
            set { this["MAINTENANCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetMaterialDefinition FixedAssetMaterialDefinition
        {
            get { return (FixedAssetMaterialDefinition)((ITTObject)this).GetParent("FIXEDASSETMATERIALDEFINITION"); }
            set { this["FIXEDASSETMATERIALDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Calibration Calibration
        {
            get { return (Calibration)((ITTObject)this).GetParent("CALIBRATION"); }
            set { this["CALIBRATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Service Service
        {
            get { return (Service)((ITTObject)this).GetParent("SERVICE"); }
            set { this["SERVICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaintenancePlan MaintenancePlan
        {
            get { return (MaintenancePlan)((ITTObject)this).GetParent("MAINTENANCEPLAN"); }
            set { this["MAINTENANCEPLAN"] = (value==null ? null : (Guid?)value.ObjectID); }
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

        virtual protected void CreateSelectedPlannedWorkCollection()
        {
            _SelectedPlannedWork = new MaintenancePlan.ChildMaintenancePlanCollection(this, new Guid("ee0e3e68-3a24-416d-8d50-079be0a94f4b"));
            ((ITTChildObjectCollection)_SelectedPlannedWork).GetChildren();
        }

        protected MaintenancePlan.ChildMaintenancePlanCollection _SelectedPlannedWork = null;
    /// <summary>
    /// Child collection for Temporary
    /// </summary>
        public MaintenancePlan.ChildMaintenancePlanCollection SelectedPlannedWork
        {
            get
            {
                if (_SelectedPlannedWork == null)
                    CreateSelectedPlannedWorkCollection();
                return _SelectedPlannedWork;
            }
        }

        virtual protected void CreateMaintenancePlan_PlannedWorkDetailsCollection()
        {
            _MaintenancePlan_PlannedWorkDetails = new MaintenancePlan_PlannedWorkDetail.ChildMaintenancePlan_PlannedWorkDetailCollection(this, new Guid("d72a6aa9-305b-419f-910b-451d143155db"));
            ((ITTChildObjectCollection)_MaintenancePlan_PlannedWorkDetails).GetChildren();
        }

        protected MaintenancePlan_PlannedWorkDetail.ChildMaintenancePlan_PlannedWorkDetailCollection _MaintenancePlan_PlannedWorkDetails = null;
        public MaintenancePlan_PlannedWorkDetail.ChildMaintenancePlan_PlannedWorkDetailCollection MaintenancePlan_PlannedWorkDetails
        {
            get
            {
                if (_MaintenancePlan_PlannedWorkDetails == null)
                    CreateMaintenancePlan_PlannedWorkDetailsCollection();
                return _MaintenancePlan_PlannedWorkDetails;
            }
        }

        protected MaintenancePlan_PlannedWork(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaintenancePlan_PlannedWork(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaintenancePlan_PlannedWork(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaintenancePlan_PlannedWork(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaintenancePlan_PlannedWork(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINTENANCEPLAN_PLANNEDWORK", dataRow) { }
        protected MaintenancePlan_PlannedWork(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINTENANCEPLAN_PLANNEDWORK", dataRow, isImported) { }
        public MaintenancePlan_PlannedWork(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaintenancePlan_PlannedWork(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaintenancePlan_PlannedWork() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}