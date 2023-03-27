
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RULHekCommisionMember")] 

    public  partial class RULHekCommisionMember : CommisionMember
    {
        public class RULHekCommisionMemberList : TTObjectCollection<RULHekCommisionMember> { }
                    
        public class ChildRULHekCommisionMemberCollection : TTObject.TTChildObjectCollection<RULHekCommisionMember>
        {
            public ChildRULHekCommisionMemberCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRULHekCommisionMemberCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ReferToUpperLevel ReferToUpperLevel
        {
            get { return (ReferToUpperLevel)((ITTObject)this).GetParent("REFERTOUPPERLEVEL"); }
            set { this["REFERTOUPPERLEVEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RULHekCommisionMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RULHekCommisionMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RULHekCommisionMember(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RULHekCommisionMember(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RULHekCommisionMember(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RULHEKCOMMISIONMEMBER", dataRow) { }
        protected RULHekCommisionMember(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RULHEKCOMMISIONMEMBER", dataRow, isImported) { }
        public RULHekCommisionMember(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RULHekCommisionMember(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RULHekCommisionMember() : base() { }

    }
}