
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DPQueryDaily")] 

    public  partial class DPQueryDaily : BaseScheduledTask
    {
        public class DPQueryDailyList : TTObjectCollection<DPQueryDaily> { }
                    
        public class ChildDPQueryDailyCollection : TTObject.TTChildObjectCollection<DPQueryDaily>
        {
            public ChildDPQueryDailyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDPQueryDailyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected DPQueryDaily(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DPQueryDaily(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DPQueryDaily(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DPQueryDaily(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DPQueryDaily(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DPQUERYDAILY", dataRow) { }
        protected DPQueryDaily(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DPQUERYDAILY", dataRow, isImported) { }
        public DPQueryDaily(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DPQueryDaily(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DPQueryDaily() : base() { }

    }
}