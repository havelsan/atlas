
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RepairHEKCommisionMember")] 

    /// <summary>
    /// Onarım HEK Komisyon Üyeleri Sekmesi
    /// </summary>
    public  partial class RepairHEKCommisionMember : CommisionMember
    {
        public class RepairHEKCommisionMemberList : TTObjectCollection<RepairHEKCommisionMember> { }
                    
        public class ChildRepairHEKCommisionMemberCollection : TTObject.TTChildObjectCollection<RepairHEKCommisionMember>
        {
            public ChildRepairHEKCommisionMemberCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRepairHEKCommisionMemberCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public Repair Repair
        {
            get { return (Repair)((ITTObject)this).GetParent("REPAIR"); }
            set { this["REPAIR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RepairHEKCommisionMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RepairHEKCommisionMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RepairHEKCommisionMember(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RepairHEKCommisionMember(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RepairHEKCommisionMember(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REPAIRHEKCOMMISIONMEMBER", dataRow) { }
        protected RepairHEKCommisionMember(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REPAIRHEKCOMMISIONMEMBER", dataRow, isImported) { }
        public RepairHEKCommisionMember(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RepairHEKCommisionMember(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RepairHEKCommisionMember() : base() { }

    }
}