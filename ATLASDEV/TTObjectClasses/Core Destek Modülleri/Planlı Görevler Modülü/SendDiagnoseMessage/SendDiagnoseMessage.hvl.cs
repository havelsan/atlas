
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendDiagnoseMessage")] 

    /// <summary>
    /// Hastaya belirlenmiş bir tanı konulduğunda belirlenmiş bir kullanıcıya sms atmak için oluşturuldu.
    /// </summary>
    public  partial class SendDiagnoseMessage : BaseScheduledTask
    {
        public class SendDiagnoseMessageList : TTObjectCollection<SendDiagnoseMessage> { }
                    
        public class ChildSendDiagnoseMessageCollection : TTObject.TTChildObjectCollection<SendDiagnoseMessage>
        {
            public ChildSendDiagnoseMessageCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendDiagnoseMessageCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SendDiagnoseMessage(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendDiagnoseMessage(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendDiagnoseMessage(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendDiagnoseMessage(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendDiagnoseMessage(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDDIAGNOSEMESSAGE", dataRow) { }
        protected SendDiagnoseMessage(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDDIAGNOSEMESSAGE", dataRow, isImported) { }
        public SendDiagnoseMessage(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendDiagnoseMessage(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendDiagnoseMessage() : base() { }

    }
}