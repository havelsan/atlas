
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaintenanceCheckList")] 

    /// <summary>
    /// Kontrol Listesi
    /// </summary>
    public  partial class MaintenanceCheckList : TTObject
    {
        public class MaintenanceCheckListList : TTObjectCollection<MaintenanceCheckList> { }
                    
        public class ChildMaintenanceCheckListCollection : TTObject.TTChildObjectCollection<MaintenanceCheckList>
        {
            public ChildMaintenanceCheckListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaintenanceCheckListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Evet
    /// </summary>
        public bool? Check
        {
            get { return (bool?)this["CHECK"]; }
            set { this["CHECK"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public Maintenance Maintenance
        {
            get { return (Maintenance)((ITTObject)this).GetParent("MAINTENANCE"); }
            set { this["MAINTENANCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaintenanceParameterDefinition MaintenanceParameterDef
        {
            get { return (MaintenanceParameterDefinition)((ITTObject)this).GetParent("MAINTENANCEPARAMETERDEF"); }
            set { this["MAINTENANCEPARAMETERDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaintenanceCheckList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaintenanceCheckList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaintenanceCheckList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaintenanceCheckList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaintenanceCheckList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINTENANCECHECKLIST", dataRow) { }
        protected MaintenanceCheckList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINTENANCECHECKLIST", dataRow, isImported) { }
        public MaintenanceCheckList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaintenanceCheckList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaintenanceCheckList() : base() { }

    }
}