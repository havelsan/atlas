
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PregnancyNotification")] 

    public  partial class PregnancyNotification : TTObject
    {
        public class PregnancyNotificationList : TTObjectCollection<PregnancyNotification> { }
                    
        public class ChildPregnancyNotificationCollection : TTObject.TTChildObjectCollection<PregnancyNotification>
        {
            public ChildPregnancyNotificationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPregnancyNotificationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public Pregnancy Pregnancy
        {
            get { return (Pregnancy)((ITTObject)this).GetParent("PREGNANCY"); }
            set { this["PREGNANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSGebeBilgilendirmeveDanismanlik Notification
        {
            get { return (SKRSGebeBilgilendirmeveDanismanlik)((ITTObject)this).GetParent("NOTIFICATION"); }
            set { this["NOTIFICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PregnancyNotification(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PregnancyNotification(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PregnancyNotification(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PregnancyNotification(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PregnancyNotification(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PREGNANCYNOTIFICATION", dataRow) { }
        protected PregnancyNotification(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PREGNANCYNOTIFICATION", dataRow, isImported) { }
        public PregnancyNotification(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PregnancyNotification(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PregnancyNotification() : base() { }

    }
}