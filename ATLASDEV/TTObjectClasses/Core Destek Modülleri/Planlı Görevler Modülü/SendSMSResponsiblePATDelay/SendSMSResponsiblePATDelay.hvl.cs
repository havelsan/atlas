
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendSMSResponsiblePATDelay")] 

    /// <summary>
    /// Patoloji Gecikmeleri için Sorumlu Doktora SMS Gönderme İşlemi
    /// </summary>
    public  partial class SendSMSResponsiblePATDelay : BaseScheduledTask
    {
        public class SendSMSResponsiblePATDelayList : TTObjectCollection<SendSMSResponsiblePATDelay> { }
                    
        public class ChildSendSMSResponsiblePATDelayCollection : TTObject.TTChildObjectCollection<SendSMSResponsiblePATDelay>
        {
            public ChildSendSMSResponsiblePATDelayCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendSMSResponsiblePATDelayCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SendSMSResponsiblePATDelay(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendSMSResponsiblePATDelay(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendSMSResponsiblePATDelay(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendSMSResponsiblePATDelay(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendSMSResponsiblePATDelay(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDSMSRESPONSIBLEPATDELAY", dataRow) { }
        protected SendSMSResponsiblePATDelay(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDSMSRESPONSIBLEPATDELAY", dataRow, isImported) { }
        public SendSMSResponsiblePATDelay(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendSMSResponsiblePATDelay(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendSMSResponsiblePATDelay() : base() { }

    }
}