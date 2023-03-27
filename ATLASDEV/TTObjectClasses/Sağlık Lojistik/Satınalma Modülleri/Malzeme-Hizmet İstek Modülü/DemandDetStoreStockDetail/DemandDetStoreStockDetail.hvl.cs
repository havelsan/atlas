
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DemandDetStoreStockDetail")] 

    /// <summary>
    /// Her istek kalemi için o kalemin mevcut depo miktar detaylarının tutulduğu sınıftır
    /// </summary>
    public  partial class DemandDetStoreStockDetail : TTObject
    {
        public class DemandDetStoreStockDetailList : TTObjectCollection<DemandDetStoreStockDetail> { }
                    
        public class ChildDemandDetStoreStockDetailCollection : TTObject.TTChildObjectCollection<DemandDetStoreStockDetail>
        {
            public ChildDemandDetStoreStockDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDemandDetStoreStockDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Muvazene Miktarı
    /// </summary>
        public Currency? TransferAmount
        {
            get { return (Currency?)this["TRANSFERAMOUNT"]; }
            set { this["TRANSFERAMOUNT"] = value; }
        }

        public DemandDetailStoreStock DemandDetailStoreStock
        {
            get { return (DemandDetailStoreStock)((ITTObject)this).GetParent("DEMANDDETAILSTORESTOCK"); }
            set { this["DEMANDDETAILSTORESTOCK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DemandDetStoreStockDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DemandDetStoreStockDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DemandDetStoreStockDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DemandDetStoreStockDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DemandDetStoreStockDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEMANDDETSTORESTOCKDETAIL", dataRow) { }
        protected DemandDetStoreStockDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEMANDDETSTORESTOCKDETAIL", dataRow, isImported) { }
        public DemandDetStoreStockDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DemandDetStoreStockDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DemandDetStoreStockDetail() : base() { }

    }
}