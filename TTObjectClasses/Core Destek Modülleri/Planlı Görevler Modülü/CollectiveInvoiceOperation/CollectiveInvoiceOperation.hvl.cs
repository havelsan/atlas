
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CollectiveInvoiceOperation")] 

    public  partial class CollectiveInvoiceOperation : BaseScheduledTask
    {
        public class CollectiveInvoiceOperationList : TTObjectCollection<CollectiveInvoiceOperation> { }
                    
        public class ChildCollectiveInvoiceOperationCollection : TTObject.TTChildObjectCollection<CollectiveInvoiceOperation>
        {
            public ChildCollectiveInvoiceOperationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCollectiveInvoiceOperationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CollectiveInvoiceOperation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CollectiveInvoiceOperation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CollectiveInvoiceOperation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CollectiveInvoiceOperation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CollectiveInvoiceOperation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COLLECTIVEINVOICEOPERATION", dataRow) { }
        protected CollectiveInvoiceOperation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COLLECTIVEINVOICEOPERATION", dataRow, isImported) { }
        public CollectiveInvoiceOperation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CollectiveInvoiceOperation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CollectiveInvoiceOperation() : base() { }

    }
}