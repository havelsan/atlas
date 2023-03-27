
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResendReqandReportTeletip")] 

    public  partial class ResendReqandReportTeletip : BaseScheduledTask
    {
        public class ResendReqandReportTeletipList : TTObjectCollection<ResendReqandReportTeletip> { }
                    
        public class ChildResendReqandReportTeletipCollection : TTObject.TTChildObjectCollection<ResendReqandReportTeletip>
        {
            public ChildResendReqandReportTeletipCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResendReqandReportTeletipCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ResendReqandReportTeletip(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResendReqandReportTeletip(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResendReqandReportTeletip(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResendReqandReportTeletip(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResendReqandReportTeletip(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESENDREQANDREPORTTELETIP", dataRow) { }
        protected ResendReqandReportTeletip(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESENDREQANDREPORTTELETIP", dataRow, isImported) { }
        public ResendReqandReportTeletip(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResendReqandReportTeletip(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResendReqandReportTeletip() : base() { }

    }
}