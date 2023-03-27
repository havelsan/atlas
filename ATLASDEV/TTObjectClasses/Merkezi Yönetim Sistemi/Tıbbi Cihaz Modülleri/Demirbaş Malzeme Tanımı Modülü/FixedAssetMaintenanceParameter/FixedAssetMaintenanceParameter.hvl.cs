
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetMaintenanceParameter")] 

    public  partial class FixedAssetMaintenanceParameter : TTDefinitionSet
    {
        public class FixedAssetMaintenanceParameterList : TTObjectCollection<FixedAssetMaintenanceParameter> { }
                    
        public class ChildFixedAssetMaintenanceParameterCollection : TTObject.TTChildObjectCollection<FixedAssetMaintenanceParameter>
        {
            public ChildFixedAssetMaintenanceParameterCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetMaintenanceParameterCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public MaintenanceParameterDefinition MaintenanceParameterDef
        {
            get { return (MaintenanceParameterDefinition)((ITTObject)this).GetParent("MAINTENANCEPARAMETERDEF"); }
            set { this["MAINTENANCEPARAMETERDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDefinition FixedAssetDefinition
        {
            get { return (FixedAssetDefinition)((ITTObject)this).GetParent("FIXEDASSETDEFINITION"); }
            set { this["FIXEDASSETDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FixedAssetMaintenanceParameter(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetMaintenanceParameter(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetMaintenanceParameter(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetMaintenanceParameter(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetMaintenanceParameter(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETMAINTENANCEPARAMETER", dataRow) { }
        protected FixedAssetMaintenanceParameter(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETMAINTENANCEPARAMETER", dataRow, isImported) { }
        public FixedAssetMaintenanceParameter(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetMaintenanceParameter(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetMaintenanceParameter() : base() { }

    }
}