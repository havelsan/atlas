
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TmpOrderedSupplier")] 

    public  partial class TmpOrderedSupplier : TTObject
    {
        public class TmpOrderedSupplierList : TTObjectCollection<TmpOrderedSupplier> { }
                    
        public class ChildTmpOrderedSupplierCollection : TTObject.TTChildObjectCollection<TmpOrderedSupplier>
        {
            public ChildTmpOrderedSupplierCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTmpOrderedSupplierCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public PurchaseOrder PurchaseOrder
        {
            get { return (PurchaseOrder)((ITTObject)this).GetParent("PURCHASEORDER"); }
            set { this["PURCHASEORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ChattelDocumentWithPurchase ChattelDocumentWithPurchase
        {
            get { return (ChattelDocumentWithPurchase)((ITTObject)this).GetParent("CHATTELDOCUMENTWITHPURCHASE"); }
            set { this["CHATTELDOCUMENTWITHPURCHASE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TmpOrderedSupplier(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TmpOrderedSupplier(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TmpOrderedSupplier(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TmpOrderedSupplier(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TmpOrderedSupplier(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TMPORDEREDSUPPLIER", dataRow) { }
        protected TmpOrderedSupplier(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TMPORDEREDSUPPLIER", dataRow, isImported) { }
        public TmpOrderedSupplier(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TmpOrderedSupplier(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TmpOrderedSupplier() : base() { }

    }
}