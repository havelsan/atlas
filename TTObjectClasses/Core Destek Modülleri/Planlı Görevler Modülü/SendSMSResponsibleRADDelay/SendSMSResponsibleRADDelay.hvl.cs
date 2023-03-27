
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendSMSResponsibleRADDelay")] 

    /// <summary>
    /// Radyoloji Gecikmeleri için Sorumlu Doktora SMS Gönderme İşlemi
    /// </summary>
    public  partial class SendSMSResponsibleRADDelay : BaseScheduledTask
    {
        public class SendSMSResponsibleRADDelayList : TTObjectCollection<SendSMSResponsibleRADDelay> { }
                    
        public class ChildSendSMSResponsibleRADDelayCollection : TTObject.TTChildObjectCollection<SendSMSResponsibleRADDelay>
        {
            public ChildSendSMSResponsibleRADDelayCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendSMSResponsibleRADDelayCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SendSMSResponsibleRADDelay(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendSMSResponsibleRADDelay(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendSMSResponsibleRADDelay(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendSMSResponsibleRADDelay(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendSMSResponsibleRADDelay(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDSMSRESPONSIBLERADDELAY", dataRow) { }
        protected SendSMSResponsibleRADDelay(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDSMSRESPONSIBLERADDELAY", dataRow, isImported) { }
        public SendSMSResponsibleRADDelay(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendSMSResponsibleRADDelay(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendSMSResponsibleRADDelay() : base() { }

    }
}