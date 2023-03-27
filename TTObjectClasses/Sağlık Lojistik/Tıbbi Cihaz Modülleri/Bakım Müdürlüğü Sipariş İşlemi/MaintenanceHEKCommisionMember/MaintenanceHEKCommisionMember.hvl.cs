
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaintenanceHEKCommisionMember")] 

    /// <summary>
    /// Sipariş HEK Komisyonu Sekmesi
    /// </summary>
    public  partial class MaintenanceHEKCommisionMember : CommisionMember
    {
        public class MaintenanceHEKCommisionMemberList : TTObjectCollection<MaintenanceHEKCommisionMember> { }
                    
        public class ChildMaintenanceHEKCommisionMemberCollection : TTObject.TTChildObjectCollection<MaintenanceHEKCommisionMember>
        {
            public ChildMaintenanceHEKCommisionMemberCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaintenanceHEKCommisionMemberCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public MaintenanceOrder MaintenanceOrder
        {
            get { return (MaintenanceOrder)((ITTObject)this).GetParent("MAINTENANCEORDER"); }
            set { this["MAINTENANCEORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaintenanceHEKCommisionMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaintenanceHEKCommisionMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaintenanceHEKCommisionMember(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaintenanceHEKCommisionMember(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaintenanceHEKCommisionMember(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINTENANCEHEKCOMMISIONMEMBER", dataRow) { }
        protected MaintenanceHEKCommisionMember(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINTENANCEHEKCOMMISIONMEMBER", dataRow, isImported) { }
        public MaintenanceHEKCommisionMember(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaintenanceHEKCommisionMember(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaintenanceHEKCommisionMember() : base() { }

    }
}