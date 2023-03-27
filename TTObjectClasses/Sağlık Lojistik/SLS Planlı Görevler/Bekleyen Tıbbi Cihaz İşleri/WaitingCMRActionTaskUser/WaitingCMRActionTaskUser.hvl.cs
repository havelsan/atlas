
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WaitingCMRActionTaskUser")] 

    public  partial class WaitingCMRActionTaskUser : TTObject
    {
        public class WaitingCMRActionTaskUserList : TTObjectCollection<WaitingCMRActionTaskUser> { }
                    
        public class ChildWaitingCMRActionTaskUserCollection : TTObject.TTChildObjectCollection<WaitingCMRActionTaskUser>
        {
            public ChildWaitingCMRActionTaskUserCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWaitingCMRActionTaskUserCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public WaitingCMRActionTask WaitingCMRActionTask
        {
            get { return (WaitingCMRActionTask)((ITTObject)this).GetParent("WAITINGCMRACTIONTASK"); }
            set { this["WAITINGCMRACTIONTASK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser User
        {
            get { return (ResUser)((ITTObject)this).GetParent("USER"); }
            set { this["USER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected WaitingCMRActionTaskUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WaitingCMRActionTaskUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WaitingCMRActionTaskUser(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WaitingCMRActionTaskUser(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WaitingCMRActionTaskUser(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WAITINGCMRACTIONTASKUSER", dataRow) { }
        protected WaitingCMRActionTaskUser(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WAITINGCMRACTIONTASKUSER", dataRow, isImported) { }
        public WaitingCMRActionTaskUser(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WaitingCMRActionTaskUser(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WaitingCMRActionTaskUser() : base() { }

    }
}