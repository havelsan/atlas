
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendSMSChiefForExamDelay")] 

    /// <summary>
    /// Poliklinik Muayeneleri Gecikmesi için Başhekim Yardımcısına SMS Gönderme İşlemi
    /// </summary>
    public  partial class SendSMSChiefForExamDelay : BaseScheduledTask
    {
        public class SendSMSChiefForExamDelayList : TTObjectCollection<SendSMSChiefForExamDelay> { }
                    
        public class ChildSendSMSChiefForExamDelayCollection : TTObject.TTChildObjectCollection<SendSMSChiefForExamDelay>
        {
            public ChildSendSMSChiefForExamDelayCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendSMSChiefForExamDelayCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SendSMSChiefForExamDelay(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendSMSChiefForExamDelay(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendSMSChiefForExamDelay(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendSMSChiefForExamDelay(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendSMSChiefForExamDelay(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDSMSCHIEFFOREXAMDELAY", dataRow) { }
        protected SendSMSChiefForExamDelay(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDSMSCHIEFFOREXAMDELAY", dataRow, isImported) { }
        public SendSMSChiefForExamDelay(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendSMSChiefForExamDelay(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendSMSChiefForExamDelay() : base() { }

    }
}