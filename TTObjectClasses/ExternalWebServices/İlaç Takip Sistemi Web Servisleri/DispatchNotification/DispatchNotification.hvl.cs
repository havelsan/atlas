
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DispatchNotification")] 

    public  partial class DispatchNotification : TTObject
    {
        public class DispatchNotificationList : TTObjectCollection<DispatchNotification> { }
                    
        public class ChildDispatchNotificationCollection : TTObject.TTChildObjectCollection<DispatchNotification>
        {
            public ChildDispatchNotificationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDispatchNotificationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected DispatchNotification(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DispatchNotification(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DispatchNotification(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DispatchNotification(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DispatchNotification(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISPATCHNOTIFICATION", dataRow) { }
        protected DispatchNotification(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISPATCHNOTIFICATION", dataRow, isImported) { }
        public DispatchNotification(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DispatchNotification(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DispatchNotification() : base() { }

    }
}