
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WaitingCMRActionTask")] 

    /// <summary>
    /// Bekleyen Tıbbi Cihaz İşleri
    /// </summary>
    public  partial class WaitingCMRActionTask : BaseScheduledTask
    {
        public class WaitingCMRActionTaskList : TTObjectCollection<WaitingCMRActionTask> { }
                    
        public class ChildWaitingCMRActionTaskCollection : TTObject.TTChildObjectCollection<WaitingCMRActionTask>
        {
            public ChildWaitingCMRActionTaskCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWaitingCMRActionTaskCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Günden Fazla Bekleyen
    /// </summary>
        public int? ExpirationDay
        {
            get { return (int?)this["EXPIRATIONDAY"]; }
            set { this["EXPIRATIONDAY"] = value; }
        }

        virtual protected void CreateWaitingCMRActionTaskUsersCollection()
        {
            _WaitingCMRActionTaskUsers = new WaitingCMRActionTaskUser.ChildWaitingCMRActionTaskUserCollection(this, new Guid("af7792b2-ba55-4742-a289-607f1bc0156e"));
            ((ITTChildObjectCollection)_WaitingCMRActionTaskUsers).GetChildren();
        }

        protected WaitingCMRActionTaskUser.ChildWaitingCMRActionTaskUserCollection _WaitingCMRActionTaskUsers = null;
        public WaitingCMRActionTaskUser.ChildWaitingCMRActionTaskUserCollection WaitingCMRActionTaskUsers
        {
            get
            {
                if (_WaitingCMRActionTaskUsers == null)
                    CreateWaitingCMRActionTaskUsersCollection();
                return _WaitingCMRActionTaskUsers;
            }
        }

        protected WaitingCMRActionTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WaitingCMRActionTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WaitingCMRActionTask(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WaitingCMRActionTask(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WaitingCMRActionTask(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WAITINGCMRACTIONTASK", dataRow) { }
        protected WaitingCMRActionTask(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WAITINGCMRACTIONTASK", dataRow, isImported) { }
        public WaitingCMRActionTask(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WaitingCMRActionTask(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WaitingCMRActionTask() : base() { }

    }
}