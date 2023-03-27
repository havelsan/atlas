
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PTSStockActionDetail")] 

    public  partial class PTSStockActionDetail : TTObject
    {
        public class PTSStockActionDetailList : TTObjectCollection<PTSStockActionDetail> { }
                    
        public class ChildPTSStockActionDetailCollection : TTObject.TTChildObjectCollection<PTSStockActionDetail>
        {
            public ChildPTSStockActionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPTSStockActionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// IndirimTutari
    /// </summary>
        public BigCurrency? DiscountAmount
        {
            get { return (BigCurrency?)this["DISCOUNTAMOUNT"]; }
            set { this["DISCOUNTAMOUNT"] = value; }
        }

    /// <summary>
    /// IndirimOrani
    /// </summary>
        public BigCurrency? DiscountRate
        {
            get { return (BigCurrency?)this["DISCOUNTRATE"]; }
            set { this["DISCOUNTRATE"] = value; }
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
    /// Lot Nu.
    /// </summary>
        public string LotNo
        {
            get { return (string)this["LOTNO"]; }
            set { this["LOTNO"] = value; }
        }

        public string MKYS_DigerAciklama
        {
            get { return (string)this["MKYS_DIGERACIKLAMA"]; }
            set { this["MKYS_DIGERACIKLAMA"] = value; }
        }

    /// <summary>
    /// İndirimsiz Birim Fiyatı
    /// </summary>
        public BigCurrency? NotDiscountedUnitPrice
        {
            get { return (BigCurrency?)this["NOTDISCOUNTEDUNITPRICE"]; }
            set { this["NOTDISCOUNTEDUNITPRICE"] = value; }
        }

    /// <summary>
    /// UretimTarihi
    /// </summary>
        public DateTime? ProductionDate
        {
            get { return (DateTime?)this["PRODUCTIONDATE"]; }
            set { this["PRODUCTIONDATE"] = value; }
        }

    /// <summary>
    /// EdinimYili
    /// </summary>
        public int? RetrievalYear
        {
            get { return (int?)this["RETRIEVALYEAR"]; }
            set { this["RETRIEVALYEAR"] = value; }
        }

    /// <summary>
    /// ToplamIndirimTutari
    /// </summary>
        public BigCurrency? TotalDiscountAmount
        {
            get { return (BigCurrency?)this["TOTALDISCOUNTAMOUNT"]; }
            set { this["TOTALDISCOUNTAMOUNT"] = value; }
        }

    /// <summary>
    /// ToplamIndirimsizTutari
    /// </summary>
        public BigCurrency? TotalPriceNotDiscount
        {
            get { return (BigCurrency?)this["TOTALPRICENOTDISCOUNT"]; }
            set { this["TOTALPRICENOTDISCOUNT"] = value; }
        }

    /// <summary>
    /// Birim Fiyatı
    /// </summary>
        public BigCurrency? UnitPrice
        {
            get { return (BigCurrency?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

    /// <summary>
    /// KDV
    /// </summary>
        public long? VatRate
        {
            get { return (long?)this["VATRATE"]; }
            set { this["VATRATE"] = value; }
        }

    /// <summary>
    /// MakbuzDetayKayitNo
    /// </summary>
        public int? VoucherDetailRecordNo
        {
            get { return (int?)this["VOUCHERDETAILRECORDNO"]; }
            set { this["VOUCHERDETAILRECORDNO"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockAction StockAction
        {
            get { return (StockAction)((ITTObject)this).GetParent("STOCKACTION"); }
            set { this["STOCKACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateStockActionDetailsCollection()
        {
            _StockActionDetails = new StockActionDetail.ChildStockActionDetailCollection(this, new Guid("abd87f70-e45f-4e90-95e1-e9d7c62de9e5"));
            ((ITTChildObjectCollection)_StockActionDetails).GetChildren();
        }

        protected StockActionDetail.ChildStockActionDetailCollection _StockActionDetails = null;
        public StockActionDetail.ChildStockActionDetailCollection StockActionDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _StockActionDetails;
            }
        }

        protected PTSStockActionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PTSStockActionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PTSStockActionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PTSStockActionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PTSStockActionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PTSSTOCKACTIONDETAIL", dataRow) { }
        protected PTSStockActionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PTSSTOCKACTIONDETAIL", dataRow, isImported) { }
        public PTSStockActionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PTSStockActionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PTSStockActionDetail() : base() { }

    }
}