
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendSMSChiefRADDelay")] 

    /// <summary>
    /// Radyoloji Gecikmeleri için Başhekim Yardımcısına SMS Gönderme İşlemi
    /// </summary>
    public  partial class SendSMSChiefRADDelay : BaseScheduledTask
    {
        public class SendSMSChiefRADDelayList : TTObjectCollection<SendSMSChiefRADDelay> { }
                    
        public class ChildSendSMSChiefRADDelayCollection : TTObject.TTChildObjectCollection<SendSMSChiefRADDelay>
        {
            public ChildSendSMSChiefRADDelayCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendSMSChiefRADDelayCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SendSMSChiefRADDelay(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendSMSChiefRADDelay(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendSMSChiefRADDelay(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendSMSChiefRADDelay(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendSMSChiefRADDelay(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDSMSCHIEFRADDELAY", dataRow) { }
        protected SendSMSChiefRADDelay(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDSMSCHIEFRADDELAY", dataRow, isImported) { }
        public SendSMSChiefRADDelay(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendSMSChiefRADDelay(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendSMSChiefRADDelay() : base() { }

    }
}