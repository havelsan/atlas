
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StoreSMSUser")] 

    public  partial class StoreSMSUser : TTObject
    {
        public class StoreSMSUserList : TTObjectCollection<StoreSMSUser> { }
                    
        public class ChildStoreSMSUserCollection : TTObject.TTChildObjectCollection<StoreSMSUser>
        {
            public ChildStoreSMSUserCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStoreSMSUserCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected StoreSMSUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StoreSMSUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StoreSMSUser(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StoreSMSUser(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StoreSMSUser(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STORESMSUSER", dataRow) { }
        protected StoreSMSUser(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STORESMSUSER", dataRow, isImported) { }
        public StoreSMSUser(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StoreSMSUser(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StoreSMSUser() : base() { }

    }
}