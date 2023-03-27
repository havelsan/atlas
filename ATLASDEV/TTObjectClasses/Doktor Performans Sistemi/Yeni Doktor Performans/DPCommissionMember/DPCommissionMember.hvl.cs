
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DPCommissionMember")] 

    public  partial class DPCommissionMember : TTObject
    {
        public class DPCommissionMemberList : TTObjectCollection<DPCommissionMember> { }
                    
        public class ChildDPCommissionMemberCollection : TTObject.TTChildObjectCollection<DPCommissionMember>
        {
            public ChildDPCommissionMemberCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDPCommissionMemberCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DPACommisionMemberDutyEnum? Duty
        {
            get { return (DPACommisionMemberDutyEnum?)(int?)this["DUTY"]; }
            set { this["DUTY"] = value; }
        }

        public DPCommissionDecision DPCommissionDecision
        {
            get { return (DPCommissionDecision)((ITTObject)this).GetParent("DPCOMMISSIONDECISION"); }
            set { this["DPCOMMISSIONDECISION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser Member
        {
            get { return (ResUser)((ITTObject)this).GetParent("MEMBER"); }
            set { this["MEMBER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DPCommissionMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DPCommissionMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DPCommissionMember(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DPCommissionMember(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DPCommissionMember(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DPCOMMISSIONMEMBER", dataRow) { }
        protected DPCommissionMember(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DPCOMMISSIONMEMBER", dataRow, isImported) { }
        public DPCommissionMember(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DPCommissionMember(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DPCommissionMember() : base() { }

    }
}