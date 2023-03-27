
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UnitMaintenance")] 

    /// <summary>
    /// Birlik Seviyesi Bakım Parametreleri
    /// </summary>
    public  partial class UnitMaintenance : TTObject
    {
        public class UnitMaintenanceList : TTObjectCollection<UnitMaintenance> { }
                    
        public class ChildUnitMaintenanceCollection : TTObject.TTChildObjectCollection<UnitMaintenance>
        {
            public ChildUnitMaintenanceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUnitMaintenanceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Yapıldı
    /// </summary>
        public bool? Checked
        {
            get { return (bool?)this["CHECKED"]; }
            set { this["CHECKED"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Bakım Parametresi
    /// </summary>
        public MaintenanceParameterDefinition Parameter
        {
            get { return (MaintenanceParameterDefinition)((ITTObject)this).GetParent("PARAMETER"); }
            set { this["PARAMETER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Cihazin birlik seviyesi bakım parametresi
    /// </summary>
        public CMRAction CMRAction
        {
            get { return (CMRAction)((ITTObject)this).GetParent("CMRACTION"); }
            set { this["CMRACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected UnitMaintenance(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UnitMaintenance(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UnitMaintenance(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UnitMaintenance(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UnitMaintenance(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UNITMAINTENANCE", dataRow) { }
        protected UnitMaintenance(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UNITMAINTENANCE", dataRow, isImported) { }
        public UnitMaintenance(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UnitMaintenance(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UnitMaintenance() : base() { }

    }
}