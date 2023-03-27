
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendSMSChiefPATDelay")] 

    /// <summary>
    /// Patoloji Gecikmeleri için Başhekim Yardımcısına SMS Gönderme İşlemi
    /// </summary>
    public  partial class SendSMSChiefPATDelay : BaseScheduledTask
    {
        public class SendSMSChiefPATDelayList : TTObjectCollection<SendSMSChiefPATDelay> { }
                    
        public class ChildSendSMSChiefPATDelayCollection : TTObject.TTChildObjectCollection<SendSMSChiefPATDelay>
        {
            public ChildSendSMSChiefPATDelayCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendSMSChiefPATDelayCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SendSMSChiefPATDelay(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendSMSChiefPATDelay(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendSMSChiefPATDelay(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendSMSChiefPATDelay(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendSMSChiefPATDelay(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDSMSCHIEFPATDELAY", dataRow) { }
        protected SendSMSChiefPATDelay(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDSMSCHIEFPATDELAY", dataRow, isImported) { }
        public SendSMSChiefPATDelay(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendSMSChiefPATDelay(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendSMSChiefPATDelay() : base() { }

    }
}