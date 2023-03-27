
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendSMSResponsibleExamDelay")] 

    /// <summary>
    /// Poliklinik Muayeneleri Gecikmesi için Klinik/Branş İdari Sorumluşuna SMS Gönderme İşlemi
    /// </summary>
    public  partial class SendSMSResponsibleExamDelay : BaseScheduledTask
    {
        public class SendSMSResponsibleExamDelayList : TTObjectCollection<SendSMSResponsibleExamDelay> { }
                    
        public class ChildSendSMSResponsibleExamDelayCollection : TTObject.TTChildObjectCollection<SendSMSResponsibleExamDelay>
        {
            public ChildSendSMSResponsibleExamDelayCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendSMSResponsibleExamDelayCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SendSMSResponsibleExamDelay(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendSMSResponsibleExamDelay(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendSMSResponsibleExamDelay(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendSMSResponsibleExamDelay(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendSMSResponsibleExamDelay(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDSMSRESPONSIBLEEXAMDELAY", dataRow) { }
        protected SendSMSResponsibleExamDelay(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDSMSRESPONSIBLEEXAMDELAY", dataRow, isImported) { }
        public SendSMSResponsibleExamDelay(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendSMSResponsibleExamDelay(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendSMSResponsibleExamDelay() : base() { }

    }
}