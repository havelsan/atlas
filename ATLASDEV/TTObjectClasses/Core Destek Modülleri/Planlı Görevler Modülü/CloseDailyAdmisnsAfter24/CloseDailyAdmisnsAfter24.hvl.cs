
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CloseDailyAdmisnsAfter24")] 

    /// <summary>
    /// Kabülü izerinden 24 saat geçmiş günübirlik kabullerin kapatılması
    /// </summary>
    public  partial class CloseDailyAdmisnsAfter24 : BaseScheduledTask
    {
        public class CloseDailyAdmisnsAfter24List : TTObjectCollection<CloseDailyAdmisnsAfter24> { }
                    
        public class ChildCloseDailyAdmisnsAfter24Collection : TTObject.TTChildObjectCollection<CloseDailyAdmisnsAfter24>
        {
            public ChildCloseDailyAdmisnsAfter24Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCloseDailyAdmisnsAfter24Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CloseDailyAdmisnsAfter24(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CloseDailyAdmisnsAfter24(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CloseDailyAdmisnsAfter24(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CloseDailyAdmisnsAfter24(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CloseDailyAdmisnsAfter24(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CLOSEDAILYADMISNSAFTER24", dataRow) { }
        protected CloseDailyAdmisnsAfter24(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CLOSEDAILYADMISNSAFTER24", dataRow, isImported) { }
        public CloseDailyAdmisnsAfter24(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CloseDailyAdmisnsAfter24(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CloseDailyAdmisnsAfter24() : base() { }

    }
}