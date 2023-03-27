using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockActionDetailIn
    {
        public Guid ObjectId { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public decimal? NotDiscountedUnitPrice { get; set; }
        public decimal? TotalPriceNotDiscount { get; set; }
        public decimal? TotalDiscountAmount { get; set; }
        public decimal? UnitPrice { get; set; }
        public string LotNo { get; set; }
        public long? VatRate { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string MKYS_DigerAciklama { get; set; }
        public DateTime? ProductionDate { get; set; }
        public int? RetrievalYear { get; set; }
        public int? VoucherDetailRecordNo { get; set; }
        public string DeliveryNotifictionID { get; set; }
        public string IncomingDeliveryNotifID { get; set; }
        public string ReceiveNotificationID { get; set; }

        #region Base Object Navigation Property
        public virtual StockActionDetail StockActionDetail { get; set; }
        #endregion Base Object Navigation Property
    }
}