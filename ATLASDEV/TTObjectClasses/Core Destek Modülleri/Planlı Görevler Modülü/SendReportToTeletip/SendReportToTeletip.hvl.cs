
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendReportToTeletip")] 

    public  partial class SendReportToTeletip : BaseScheduledTask
    {
        public class SendReportToTeletipList : TTObjectCollection<SendReportToTeletip> { }
                    
        public class ChildSendReportToTeletipCollection : TTObject.TTChildObjectCollection<SendReportToTeletip>
        {
            public ChildSendReportToTeletipCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendReportToTeletipCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SendReportToTeletip(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendReportToTeletip(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendReportToTeletip(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendReportToTeletip(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendReportToTeletip(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDREPORTTOTELETIP", dataRow) { }
        protected SendReportToTeletip(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDREPORTTOTELETIP", dataRow, isImported) { }
        public SendReportToTeletip(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendReportToTeletip(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendReportToTeletip() : base() { }

    }
}