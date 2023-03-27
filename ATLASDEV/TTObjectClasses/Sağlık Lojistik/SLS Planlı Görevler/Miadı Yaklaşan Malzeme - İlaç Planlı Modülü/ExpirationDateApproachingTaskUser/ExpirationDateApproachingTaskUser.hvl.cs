
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExpirationDateApproachingTaskUser")] 

    public  partial class ExpirationDateApproachingTaskUser : TTObject
    {
        public class ExpirationDateApproachingTaskUserList : TTObjectCollection<ExpirationDateApproachingTaskUser> { }
                    
        public class ChildExpirationDateApproachingTaskUserCollection : TTObject.TTChildObjectCollection<ExpirationDateApproachingTaskUser>
        {
            public ChildExpirationDateApproachingTaskUserCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExpirationDateApproachingTaskUserCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ExpirationDateApproachingTask ExpirationDateApproachingTask
        {
            get { return (ExpirationDateApproachingTask)((ITTObject)this).GetParent("EXPIRATIONDATEAPPROACHINGTASK"); }
            set { this["EXPIRATIONDATEAPPROACHINGTASK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kullanıcı
    /// </summary>
        public ResUser User
        {
            get { return (ResUser)((ITTObject)this).GetParent("USER"); }
            set { this["USER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ExpirationDateApproachingTaskUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExpirationDateApproachingTaskUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExpirationDateApproachingTaskUser(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExpirationDateApproachingTaskUser(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExpirationDateApproachingTaskUser(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXPIRATIONDATEAPPROACHINGTASKUSER", dataRow) { }
        protected ExpirationDateApproachingTaskUser(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXPIRATIONDATEAPPROACHINGTASKUSER", dataRow, isImported) { }
        public ExpirationDateApproachingTaskUser(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExpirationDateApproachingTaskUser(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExpirationDateApproachingTaskUser() : base() { }

    }
}