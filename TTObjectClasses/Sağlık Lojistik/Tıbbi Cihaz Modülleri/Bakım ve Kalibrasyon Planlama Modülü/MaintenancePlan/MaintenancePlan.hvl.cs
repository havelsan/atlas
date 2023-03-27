
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaintenancePlan")] 

    /// <summary>
    /// Bakım ve Kalibrasyon Planlama
    /// </summary>
    public  partial class MaintenancePlan : CMRAction
    {
        public class MaintenancePlanList : TTObjectCollection<MaintenancePlan> { }
                    
        public class ChildMaintenancePlanCollection : TTObject.TTChildObjectCollection<MaintenancePlan>
        {
            public ChildMaintenancePlanCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaintenancePlanCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("cab986c8-2209-482d-b981-185382946b29"); } }
    /// <summary>
    /// Tamamlanmış Planlama
    /// </summary>
            public static Guid Completed { get { return new Guid("d87226ef-52a5-4ccb-868d-4743268658b8"); } }
    /// <summary>
    /// Planlama
    /// </summary>
            public static Guid New { get { return new Guid("0162a0b3-22f1-4465-85eb-ad6f1fb7d631"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("820fcb2a-db0d-4150-9bd2-3011aeab7e85"); } }
        }

        public static BindingList<MaintenancePlan> GetMaintenancePlanByYear(TTObjectContext objectContext, int YEAR)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEPLAN"].QueryDefs["GetMaintenancePlanByYear"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("YEAR", YEAR);

            return ((ITTQuery)objectContext).QueryObjects<MaintenancePlan>(queryDef, paramList);
        }

    /// <summary>
    /// Planlama Türü
    /// </summary>
        public MaintenancePlanStrategyEnum? MaintenancePlanStrategyType
        {
            get { return (MaintenancePlanStrategyEnum?)(int?)this["MAINTENANCEPLANSTRATEGYTYPE"]; }
            set { this["MAINTENANCEPLANSTRATEGYTYPE"] = value; }
        }

    /// <summary>
    /// Planlama
    /// </summary>
        public MaintenancePlanTypeEnum? MaintenancePlanType
        {
            get { return (MaintenancePlanTypeEnum?)(int?)this["MAINTENANCEPLANTYPE"]; }
            set { this["MAINTENANCEPLANTYPE"] = value; }
        }

    /// <summary>
    /// Yıl
    /// </summary>
        public long? Year
        {
            get { return (long?)this["YEAR"]; }
            set { this["YEAR"] = value; }
        }

    /// <summary>
    /// İşlemde Hata
    /// </summary>
        public bool? HasError
        {
            get { return (bool?)this["HASERROR"]; }
            set { this["HASERROR"] = value; }
        }

    /// <summary>
    /// Hata Mesajı
    /// </summary>
        public string ErrorString
        {
            get { return (string)this["ERRORSTRING"]; }
            set { this["ERRORSTRING"] = value; }
        }

    /// <summary>
    /// Temporary
    /// </summary>
        public MaintenancePlan_PlannedWork MaintenancePlan_PlannedWork
        {
            get { return (MaintenancePlan_PlannedWork)((ITTObject)this).GetParent("MAINTENANCEPLAN_PLANNEDWORK"); }
            set { this["MAINTENANCEPLAN_PLANNEDWORK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMaintenancePlan_ServicesCollection()
        {
            _MaintenancePlan_Services = new MaintenancePlan_Service.ChildMaintenancePlan_ServiceCollection(this, new Guid("df3fe489-6d44-4b18-94ff-4cf7472df6bc"));
            ((ITTChildObjectCollection)_MaintenancePlan_Services).GetChildren();
        }

        protected MaintenancePlan_Service.ChildMaintenancePlan_ServiceCollection _MaintenancePlan_Services = null;
        public MaintenancePlan_Service.ChildMaintenancePlan_ServiceCollection MaintenancePlan_Services
        {
            get
            {
                if (_MaintenancePlan_Services == null)
                    CreateMaintenancePlan_ServicesCollection();
                return _MaintenancePlan_Services;
            }
        }

        virtual protected void CreateMaintenancePlan_PersonnelsCollection()
        {
            _MaintenancePlan_Personnels = new MaintenancePlan_Personnel.ChildMaintenancePlan_PersonnelCollection(this, new Guid("91c89163-6084-4114-bb98-aadb07955a7f"));
            ((ITTChildObjectCollection)_MaintenancePlan_Personnels).GetChildren();
        }

        protected MaintenancePlan_Personnel.ChildMaintenancePlan_PersonnelCollection _MaintenancePlan_Personnels = null;
        public MaintenancePlan_Personnel.ChildMaintenancePlan_PersonnelCollection MaintenancePlan_Personnels
        {
            get
            {
                if (_MaintenancePlan_Personnels == null)
                    CreateMaintenancePlan_PersonnelsCollection();
                return _MaintenancePlan_Personnels;
            }
        }

        virtual protected void CreateMaintenancePlan_PlannedWorksCollection()
        {
            _MaintenancePlan_PlannedWorks = new MaintenancePlan_PlannedWork.ChildMaintenancePlan_PlannedWorkCollection(this, new Guid("182a613f-bddc-4881-8bd7-97e02d4cf6d5"));
            ((ITTChildObjectCollection)_MaintenancePlan_PlannedWorks).GetChildren();
        }

        protected MaintenancePlan_PlannedWork.ChildMaintenancePlan_PlannedWorkCollection _MaintenancePlan_PlannedWorks = null;
        public MaintenancePlan_PlannedWork.ChildMaintenancePlan_PlannedWorkCollection MaintenancePlan_PlannedWorks
        {
            get
            {
                if (_MaintenancePlan_PlannedWorks == null)
                    CreateMaintenancePlan_PlannedWorksCollection();
                return _MaintenancePlan_PlannedWorks;
            }
        }

        virtual protected void CreateMaintenancePlan_DevicesCollection()
        {
            _MaintenancePlan_Devices = new MaintenancePlan_Device.ChildMaintenancePlan_DeviceCollection(this, new Guid("6c492593-d97d-4f1e-856d-9b0a6b2464bc"));
            ((ITTChildObjectCollection)_MaintenancePlan_Devices).GetChildren();
        }

        protected MaintenancePlan_Device.ChildMaintenancePlan_DeviceCollection _MaintenancePlan_Devices = null;
        public MaintenancePlan_Device.ChildMaintenancePlan_DeviceCollection MaintenancePlan_Devices
        {
            get
            {
                if (_MaintenancePlan_Devices == null)
                    CreateMaintenancePlan_DevicesCollection();
                return _MaintenancePlan_Devices;
            }
        }

        protected MaintenancePlan(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaintenancePlan(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaintenancePlan(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaintenancePlan(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaintenancePlan(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINTENANCEPLAN", dataRow) { }
        protected MaintenancePlan(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINTENANCEPLAN", dataRow, isImported) { }
        public MaintenancePlan(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaintenancePlan(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaintenancePlan() : base() { }

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