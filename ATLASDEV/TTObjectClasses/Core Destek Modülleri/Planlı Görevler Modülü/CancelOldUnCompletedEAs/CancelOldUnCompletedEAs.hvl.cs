
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CancelOldUnCompletedEAs")] 

    public  partial class CancelOldUnCompletedEAs : BaseScheduledTask
    {
        public class CancelOldUnCompletedEAsList : TTObjectCollection<CancelOldUnCompletedEAs> { }
                    
        public class ChildCancelOldUnCompletedEAsCollection : TTObject.TTChildObjectCollection<CancelOldUnCompletedEAs>
        {
            public ChildCancelOldUnCompletedEAsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCancelOldUnCompletedEAsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CancelOldUnCompletedEAs(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CancelOldUnCompletedEAs(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CancelOldUnCompletedEAs(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CancelOldUnCompletedEAs(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CancelOldUnCompletedEAs(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CANCELOLDUNCOMPLETEDEAS", dataRow) { }
        protected CancelOldUnCompletedEAs(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CANCELOLDUNCOMPLETEDEAS", dataRow, isImported) { }
        public CancelOldUnCompletedEAs(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CancelOldUnCompletedEAs(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CancelOldUnCompletedEAs() : base() { }

    }
}