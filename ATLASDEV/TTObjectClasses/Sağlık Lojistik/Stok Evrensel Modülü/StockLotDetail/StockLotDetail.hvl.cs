
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockLotDetail")] 

    /// <summary>
    /// Lot Detay
    /// </summary>
    public  partial class StockLotDetail : TTObject
    {
        public class StockLotDetailList : TTObjectCollection<StockLotDetail> { }
                    
        public class ChildStockLotDetailCollection : TTObject.TTChildObjectCollection<StockLotDetail>
        {
            public ChildStockLotDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockLotDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Lot Nu.
    /// </summary>
        public string LotNo
        {
            get { return (string)this["LOTNO"]; }
            set { this["LOTNO"] = value; }
        }

    /// <summary>
    /// Son Kullanma Tarihi
    /// </summary>
        public DateTime? ExpirationDate
        {
            get { return (DateTime?)this["EXPIRATIONDATE"]; }
            set { this["EXPIRATIONDATE"] = value; }
        }

    /// <summary>
    /// Kalan Miktar
    /// </summary>
        public Currency? RestAmount
        {
            get { return (Currency?)this["RESTAMOUNT"]; }
            set { this["RESTAMOUNT"] = value; }
        }

        public Stock Stock
        {
            get { return (Stock)((ITTObject)this).GetParent("STOCK"); }
            set { this["STOCK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockLevelType StockLevelType
        {
            get { return (StockLevelType)((ITTObject)this).GetParent("STOCKLEVELTYPE"); }
            set { this["STOCKLEVELTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected StockLotDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockLotDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockLotDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockLotDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockLotDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKLOTDETAIL", dataRow) { }
        protected StockLotDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKLOTDETAIL", dataRow, isImported) { }
        public StockLotDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockLotDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockLotDetail() : base() { }

    }
}