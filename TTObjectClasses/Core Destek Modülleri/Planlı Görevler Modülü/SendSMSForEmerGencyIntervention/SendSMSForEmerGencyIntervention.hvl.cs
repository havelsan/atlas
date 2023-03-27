
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendSMSForEmerGencyIntervention")] 

    /// <summary>
    /// Müşahade süresi 24 saati geçenler için Sorumlulara mesaj atar
    /// </summary>
    public  partial class SendSMSForEmerGencyIntervention : BaseScheduledTask
    {
        public class SendSMSForEmerGencyInterventionList : TTObjectCollection<SendSMSForEmerGencyIntervention> { }
                    
        public class ChildSendSMSForEmerGencyInterventionCollection : TTObject.TTChildObjectCollection<SendSMSForEmerGencyIntervention>
        {
            public ChildSendSMSForEmerGencyInterventionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendSMSForEmerGencyInterventionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SendSMSForEmerGencyIntervention(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendSMSForEmerGencyIntervention(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendSMSForEmerGencyIntervention(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendSMSForEmerGencyIntervention(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendSMSForEmerGencyIntervention(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDSMSFOREMERGENCYINTERVENTION", dataRow) { }
        protected SendSMSForEmerGencyIntervention(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDSMSFOREMERGENCYINTERVENTION", dataRow, isImported) { }
        public SendSMSForEmerGencyIntervention(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendSMSForEmerGencyIntervention(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendSMSForEmerGencyIntervention() : base() { }

    }
}