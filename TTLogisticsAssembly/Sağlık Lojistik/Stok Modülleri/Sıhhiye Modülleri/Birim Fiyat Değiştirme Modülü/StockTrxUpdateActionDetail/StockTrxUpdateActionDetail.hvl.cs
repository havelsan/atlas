
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockTrxUpdateActionDetail")] 

    public  partial class StockTrxUpdateActionDetail : TTObject
    {
        public class StockTrxUpdateActionDetailList : TTObjectCollection<StockTrxUpdateActionDetail> { }
                    
        public class ChildStockTrxUpdateActionDetailCollection : TTObject.TTChildObjectCollection<StockTrxUpdateActionDetail>
        {
            public ChildStockTrxUpdateActionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockTrxUpdateActionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İşlem Adı
    /// </summary>
        public string StockActionName
        {
            get { return (string)this["STOCKACTIONNAME"]; }
            set { this["STOCKACTIONNAME"] = value; }
        }

    /// <summary>
    /// Eski Birim Fiyatı
    /// </summary>
        public BigCurrency? OldUnitPrice
        {
            get { return (BigCurrency?)this["OLDUNITPRICE"]; }
            set { this["OLDUNITPRICE"] = value; }
        }

    /// <summary>
    /// Yeni Birim Fiyatı
    /// </summary>
        public BigCurrency? NewUnitPrice
        {
            get { return (BigCurrency?)this["NEWUNITPRICE"]; }
            set { this["NEWUNITPRICE"] = value; }
        }

        public StockTrxUpdateAction StockTrxUpdateAction
        {
            get { return (StockTrxUpdateAction)((ITTObject)this).GetParent("STOCKTRXUPDATEACTION"); }
            set { this["STOCKTRXUPDATEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockTransaction StockTransaction
        {
            get { return (StockTransaction)((ITTObject)this).GetParent("STOCKTRANSACTION"); }
            set { this["STOCKTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected StockTrxUpdateActionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockTrxUpdateActionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockTrxUpdateActionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockTrxUpdateActionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockTrxUpdateActionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKTRXUPDATEACTIONDETAIL", dataRow) { }
        protected StockTrxUpdateActionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKTRXUPDATEACTIONDETAIL", dataRow, isImported) { }
        public StockTrxUpdateActionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockTrxUpdateActionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockTrxUpdateActionDetail() : base() { }

    }
}