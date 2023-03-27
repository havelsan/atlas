
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendBirthDayMessage")] 

    /// <summary>
    /// Doğum günü mesajı
    /// </summary>
    public  partial class SendBirthDayMessage : BaseScheduledTask
    {
        public class SendBirthDayMessageList : TTObjectCollection<SendBirthDayMessage> { }
                    
        public class ChildSendBirthDayMessageCollection : TTObject.TTChildObjectCollection<SendBirthDayMessage>
        {
            public ChildSendBirthDayMessageCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendBirthDayMessageCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SendBirthDayMessage(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendBirthDayMessage(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendBirthDayMessage(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendBirthDayMessage(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendBirthDayMessage(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDBIRTHDAYMESSAGE", dataRow) { }
        protected SendBirthDayMessage(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDBIRTHDAYMESSAGE", dataRow, isImported) { }
        public SendBirthDayMessage(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendBirthDayMessage(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendBirthDayMessage() : base() { }

    }
}