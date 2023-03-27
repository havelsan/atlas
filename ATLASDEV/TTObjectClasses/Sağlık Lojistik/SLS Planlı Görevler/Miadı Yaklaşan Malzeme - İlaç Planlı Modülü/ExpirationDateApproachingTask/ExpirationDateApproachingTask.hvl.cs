
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExpirationDateApproachingTask")] 

    /// <summary>
    /// Miadı Yaklaşan Malzeme / İlaçlar
    /// </summary>
    public  partial class ExpirationDateApproachingTask : BaseScheduledTask
    {
        public class ExpirationDateApproachingTaskList : TTObjectCollection<ExpirationDateApproachingTask> { }
                    
        public class ChildExpirationDateApproachingTaskCollection : TTObject.TTChildObjectCollection<ExpirationDateApproachingTask>
        {
            public ChildExpirationDateApproachingTaskCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExpirationDateApproachingTaskCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Aydan Az
    /// </summary>
        public int? ExpirationMonth
        {
            get { return (int?)this["EXPIRATIONMONTH"]; }
            set { this["EXPIRATIONMONTH"] = value; }
        }

    /// <summary>
    /// Depo
    /// </summary>
        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateExpirationDateApproachingTaskUsersCollection()
        {
            _ExpirationDateApproachingTaskUsers = new ExpirationDateApproachingTaskUser.ChildExpirationDateApproachingTaskUserCollection(this, new Guid("7451210a-3ffe-4da0-98bf-d9a2a70687c1"));
            ((ITTChildObjectCollection)_ExpirationDateApproachingTaskUsers).GetChildren();
        }

        protected ExpirationDateApproachingTaskUser.ChildExpirationDateApproachingTaskUserCollection _ExpirationDateApproachingTaskUsers = null;
        public ExpirationDateApproachingTaskUser.ChildExpirationDateApproachingTaskUserCollection ExpirationDateApproachingTaskUsers
        {
            get
            {
                if (_ExpirationDateApproachingTaskUsers == null)
                    CreateExpirationDateApproachingTaskUsersCollection();
                return _ExpirationDateApproachingTaskUsers;
            }
        }

        protected ExpirationDateApproachingTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExpirationDateApproachingTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExpirationDateApproachingTask(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExpirationDateApproachingTask(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExpirationDateApproachingTask(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXPIRATIONDATEAPPROACHINGTASK", dataRow) { }
        protected ExpirationDateApproachingTask(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXPIRATIONDATEAPPROACHINGTASK", dataRow, isImported) { }
        public ExpirationDateApproachingTask(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExpirationDateApproachingTask(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExpirationDateApproachingTask() : base() { }

    }
}