
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendSMSForUnReportedSurgery")] 

    /// <summary>
    /// Rapor Yazılmayan Ameliyatlar İçin SMS Gönder
    /// </summary>
    public  partial class SendSMSForUnReportedSurgery : BaseScheduledTask
    {
        public class SendSMSForUnReportedSurgeryList : TTObjectCollection<SendSMSForUnReportedSurgery> { }
                    
        public class ChildSendSMSForUnReportedSurgeryCollection : TTObject.TTChildObjectCollection<SendSMSForUnReportedSurgery>
        {
            public ChildSendSMSForUnReportedSurgeryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendSMSForUnReportedSurgeryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SendSMSForUnReportedSurgery(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendSMSForUnReportedSurgery(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendSMSForUnReportedSurgery(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendSMSForUnReportedSurgery(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendSMSForUnReportedSurgery(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDSMSFORUNREPORTEDSURGERY", dataRow) { }
        protected SendSMSForUnReportedSurgery(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDSMSFORUNREPORTEDSURGERY", dataRow, isImported) { }
        public SendSMSForUnReportedSurgery(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendSMSForUnReportedSurgery(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendSMSForUnReportedSurgery() : base() { }

    }
}