
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaintenanceParameter")] 

    public  partial class MaintenanceParameter : TTDefinitionSet
    {
        public class MaintenanceParameterList : TTObjectCollection<MaintenanceParameter> { }
                    
        public class ChildMaintenanceParameterCollection : TTObject.TTChildObjectCollection<MaintenanceParameter>
        {
            public ChildMaintenanceParameterCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaintenanceParameterCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public bool? Check
        {
            get { return (bool?)this["CHECK"]; }
            set { this["CHECK"] = value; }
        }

        public MaintenanceParameterDefinition MaintenanceParameterDef
        {
            get { return (MaintenanceParameterDefinition)((ITTObject)this).GetParent("MAINTENANCEPARAMETERDEF"); }
            set { this["MAINTENANCEPARAMETERDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Maintenance Maintenance
        {
            get { return (Maintenance)((ITTObject)this).GetParent("MAINTENANCE"); }
            set { this["MAINTENANCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaintenanceParameter(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaintenanceParameter(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaintenanceParameter(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaintenanceParameter(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaintenanceParameter(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINTENANCEPARAMETER", dataRow) { }
        protected MaintenanceParameter(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINTENANCEPARAMETER", dataRow, isImported) { }
        public MaintenanceParameter(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaintenanceParameter(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaintenanceParameter() : base() { }

    }
}