
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DispatchCancellation")] 

    public  partial class DispatchCancellation : TTObject
    {
        public class DispatchCancellationList : TTObjectCollection<DispatchCancellation> { }
                    
        public class ChildDispatchCancellationCollection : TTObject.TTChildObjectCollection<DispatchCancellation>
        {
            public ChildDispatchCancellationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDispatchCancellationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected DispatchCancellation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DispatchCancellation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DispatchCancellation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DispatchCancellation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DispatchCancellation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISPATCHCANCELLATION", dataRow) { }
        protected DispatchCancellation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISPATCHCANCELLATION", dataRow, isImported) { }
        public DispatchCancellation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DispatchCancellation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DispatchCancellation() : base() { }

    }
}