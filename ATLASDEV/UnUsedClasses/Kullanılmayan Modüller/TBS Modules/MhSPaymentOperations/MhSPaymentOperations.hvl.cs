
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSPaymentOperations")] 

    /// <summary>
    /// Ödeme İşlemleri
    /// </summary>
    public  partial class MhSPaymentOperations : TTObject
    {
        public class MhSPaymentOperationsList : TTObjectCollection<MhSPaymentOperations> { }
                    
        public class ChildMhSPaymentOperationsCollection : TTObject.TTChildObjectCollection<MhSPaymentOperations>
        {
            public ChildMhSPaymentOperationsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSPaymentOperationsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MhSPaymentOperations(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSPaymentOperations(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSPaymentOperations(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSPaymentOperations(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSPaymentOperations(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSPAYMENTOPERATIONS", dataRow) { }
        protected MhSPaymentOperations(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSPAYMENTOPERATIONS", dataRow, isImported) { }
        public MhSPaymentOperations(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSPaymentOperations(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSPaymentOperations() : base() { }

    }
}