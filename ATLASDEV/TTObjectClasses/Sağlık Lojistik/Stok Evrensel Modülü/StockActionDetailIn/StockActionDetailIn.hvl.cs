
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockActionDetailIn")] 

    /// <summary>
    /// Stok hareketlerinde giriş detaylarını barındıran sınıftır. Stok modüllerindeki giriş tipindeki detay sınıfları bu sınıftan türer
    /// </summary>
    public  abstract  partial class StockActionDetailIn : StockActionDetail, IStockActionDetailIn
    {
        public class StockActionDetailInList : TTObjectCollection<StockActionDetailIn> { }
                    
        public class ChildStockActionDetailInCollection : TTObject.TTChildObjectCollection<StockActionDetailIn>
        {
            public ChildStockActionDetailInCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockActionDetailInCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// İndirimsiz Birim Fiyatı
    /// </summary>
        public BigCurrency? NotDiscountedUnitPrice
        {
            get { return (BigCurrency?)this["NOTDISCOUNTEDUNITPRICE"]; }
            set { this["NOTDISCOUNTEDUNITPRICE"] = value; }
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
    /// ToplamIndirimTutari
    /// </summary>
        public BigCurrency? TotalDiscountAmount
        {
            get { return (BigCurrency?)this["TOTALDISCOUNTAMOUNT"]; }
            set { this["TOTALDISCOUNTAMOUNT"] = value; }
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
    /// Lot Nu.
    /// </summary>
        public string LotNo
        {
            get { return (string)this["LOTNO"]; }
            set { this["LOTNO"] = value; }
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
    /// IndirimOrani
    /// </summary>
        public BigCurrency? DiscountRate
        {
            get { return (BigCurrency?)this["DISCOUNTRATE"]; }
            set { this["DISCOUNTRATE"] = value; }
        }

    /// <summary>
    /// IndirimTutari
    /// </summary>
        public BigCurrency? DiscountAmount
        {
            get { return (BigCurrency?)this["DISCOUNTAMOUNT"]; }
            set { this["DISCOUNTAMOUNT"] = value; }
        }

        public string MKYS_DigerAciklama
        {
            get { return (string)this["MKYS_DIGERACIKLAMA"]; }
            set { this["MKYS_DIGERACIKLAMA"] = value; }
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
    /// MakbuzDetayKayitNo
    /// </summary>
        public int? VoucherDetailRecordNo
        {
            get { return (int?)this["VOUCHERDETAILRECORDNO"]; }
            set { this["VOUCHERDETAILRECORDNO"] = value; }
        }

    /// <summary>
    /// Yapılan Verme Bildirimi ID
    /// </summary>
        public string DeliveryNotifictionID
        {
            get { return (string)this["DELIVERYNOTIFICTIONID"]; }
            set { this["DELIVERYNOTIFICTIONID"] = value; }
        }

    /// <summary>
    /// Gelen Verme Bildirimi ID
    /// </summary>
        public string IncomingDeliveryNotifID
        {
            get { return (string)this["INCOMINGDELIVERYNOTIFID"]; }
            set { this["INCOMINGDELIVERYNOTIFID"] = value; }
        }

    /// <summary>
    /// Alma Bildirimi ID
    /// </summary>
        public string ReceiveNotificationID
        {
            get { return (string)this["RECEIVENOTIFICATIONID"]; }
            set { this["RECEIVENOTIFICATIONID"] = value; }
        }

        override protected void CreateFixedAssetDetailsCollectionViews()
        {
            base.CreateFixedAssetDetailsCollectionViews();
            _FixedAssetInDetails = new FixedAssetInDetail.ChildFixedAssetInDetailCollection(_FixedAssetDetails, "FixedAssetInDetails");
        }

        private FixedAssetInDetail.ChildFixedAssetInDetailCollection _FixedAssetInDetails = null;
        public FixedAssetInDetail.ChildFixedAssetInDetailCollection FixedAssetInDetails
        {
            get
            {
                if (_FixedAssetDetails == null)
                    CreateFixedAssetDetailsCollection();
                return _FixedAssetInDetails;
            }            
        }

        override protected void CreateQRCodeDetailsCollectionViews()
        {
            base.CreateQRCodeDetailsCollectionViews();
            _QRCodeInDetails = new QRCodeInDetail.ChildQRCodeInDetailCollection(_QRCodeDetails, "QRCodeInDetails");
        }

        private QRCodeInDetail.ChildQRCodeInDetailCollection _QRCodeInDetails = null;
        public QRCodeInDetail.ChildQRCodeInDetailCollection QRCodeInDetails
        {
            get
            {
                if (_QRCodeDetails == null)
                    CreateQRCodeDetailsCollection();
                return _QRCodeInDetails;
            }            
        }

        override protected void CreatePrescriptionPaperDetailsCollectionViews()
        {
            base.CreatePrescriptionPaperDetailsCollectionViews();
            _PrescriptionPaperInDetails = new PrescriptionPaperInDetail.ChildPrescriptionPaperInDetailCollection(_PrescriptionPaperDetails, "PrescriptionPaperInDetails");
        }

        private PrescriptionPaperInDetail.ChildPrescriptionPaperInDetailCollection _PrescriptionPaperInDetails = null;
        public PrescriptionPaperInDetail.ChildPrescriptionPaperInDetailCollection PrescriptionPaperInDetails
        {
            get
            {
                if (_PrescriptionPaperDetails == null)
                    CreatePrescriptionPaperDetailsCollection();
                return _PrescriptionPaperInDetails;
            }            
        }

        protected StockActionDetailIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockActionDetailIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockActionDetailIn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockActionDetailIn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockActionDetailIn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKACTIONDETAILIN", dataRow) { }
        protected StockActionDetailIn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKACTIONDETAILIN", dataRow, isImported) { }
        public StockActionDetailIn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockActionDetailIn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockActionDetailIn() : base() { }

    }
}