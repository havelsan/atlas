
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendSMSWorkHealthSecWarn")] 

    /// <summary>
    /// İş Sağlığı ve Güvenliği Muayenelerinin hatırlatma smslerinin gönderileceği planlı görev
    /// </summary>
    public  partial class SendSMSWorkHealthSecWarn : BaseScheduledTask
    {
        public class SendSMSWorkHealthSecWarnList : TTObjectCollection<SendSMSWorkHealthSecWarn> { }
                    
        public class ChildSendSMSWorkHealthSecWarnCollection : TTObject.TTChildObjectCollection<SendSMSWorkHealthSecWarn>
        {
            public ChildSendSMSWorkHealthSecWarnCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendSMSWorkHealthSecWarnCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SendSMSWorkHealthSecWarn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendSMSWorkHealthSecWarn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendSMSWorkHealthSecWarn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendSMSWorkHealthSecWarn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendSMSWorkHealthSecWarn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDSMSWORKHEALTHSECWARN", dataRow) { }
        protected SendSMSWorkHealthSecWarn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDSMSWORKHEALTHSECWARN", dataRow, isImported) { }
        public SendSMSWorkHealthSecWarn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendSMSWorkHealthSecWarn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendSMSWorkHealthSecWarn() : base() { }

    }
}