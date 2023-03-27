
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TmpOrderedDetail")] 

    public  partial class TmpOrderedDetail : TTObject
    {
        public class TmpOrderedDetailList : TTObjectCollection<TmpOrderedDetail> { }
                    
        public class ChildTmpOrderedDetailCollection : TTObject.TTChildObjectCollection<TmpOrderedDetail>
        {
            public ChildTmpOrderedDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTmpOrderedDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Seçili
    /// </summary>
        public bool? Checked
        {
            get { return (bool?)this["CHECKED"]; }
            set { this["CHECKED"] = value; }
        }

        public PurchaseOrderDetail PurchaseOrderDetail
        {
            get { return (PurchaseOrderDetail)((ITTObject)this).GetParent("PURCHASEORDERDETAIL"); }
            set { this["PURCHASEORDERDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ChattelDocumentWithPurchase ChattelDocumentWithPurchase
        {
            get { return (ChattelDocumentWithPurchase)((ITTObject)this).GetParent("CHATTELDOCUMENTWITHPURCHASE"); }
            set { this["CHATTELDOCUMENTWITHPURCHASE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TmpOrderedDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TmpOrderedDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TmpOrderedDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TmpOrderedDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TmpOrderedDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TMPORDEREDDETAIL", dataRow) { }
        protected TmpOrderedDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TMPORDEREDDETAIL", dataRow, isImported) { }
        public TmpOrderedDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TmpOrderedDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TmpOrderedDetail() : base() { }

    }
}