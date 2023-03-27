
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DemandDetailStoreStock")] 

    /// <summary>
    /// Her istek kalemi için o kalemin mevcut depo miktar bilgilerinin tutulduğu sınıftır
    /// </summary>
    public  partial class DemandDetailStoreStock : TTObject
    {
        public class DemandDetailStoreStockList : TTObjectCollection<DemandDetailStoreStock> { }
                    
        public class ChildDemandDetailStoreStockCollection : TTObject.TTChildObjectCollection<DemandDetailStoreStock>
        {
            public ChildDemandDetailStoreStockCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDemandDetailStoreStockCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Muvazene
    /// </summary>
        public Currency? TransferAmount
        {
            get { return (Currency?)this["TRANSFERAMOUNT"]; }
            set { this["TRANSFERAMOUNT"] = value; }
        }

        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public DemandDetail DemandDetail
        {
            get { return (DemandDetail)((ITTObject)this).GetParent("DEMANDDETAIL"); }
            set { this["DEMANDDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateStoreStockDetailsCollection()
        {
            _StoreStockDetails = new DemandDetStoreStockDetail.ChildDemandDetStoreStockDetailCollection(this, new Guid("c45f7f32-498b-455e-8060-b163b1d65a47"));
            ((ITTChildObjectCollection)_StoreStockDetails).GetChildren();
        }

        protected DemandDetStoreStockDetail.ChildDemandDetStoreStockDetailCollection _StoreStockDetails = null;
        public DemandDetStoreStockDetail.ChildDemandDetStoreStockDetailCollection StoreStockDetails
        {
            get
            {
                if (_StoreStockDetails == null)
                    CreateStoreStockDetailsCollection();
                return _StoreStockDetails;
            }
        }

        protected DemandDetailStoreStock(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DemandDetailStoreStock(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DemandDetailStoreStock(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DemandDetailStoreStock(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DemandDetailStoreStock(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEMANDDETAILSTORESTOCK", dataRow) { }
        protected DemandDetailStoreStock(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEMANDDETAILSTORESTOCK", dataRow, isImported) { }
        public DemandDetailStoreStock(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DemandDetailStoreStock(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DemandDetailStoreStock() : base() { }

    }
}