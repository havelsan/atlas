using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockActionDetail
    {
        public Guid ObjectId { get; set; }
        public decimal? Amount { get; set; }
        public StockActionDetailStatusEnum? Status { get; set; }
        public int? ChattelDocDetailOrderNo { get; set; }
        public DateTime? AuctionDate { get; set; }
        public string RegistrationAuctionNo { get; set; }
        public bool? ResetOuttableStockTransaction { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int? MKYS_StokHareketID { get; set; }
        public string SerialNo { get; set; }
        public Guid? StockLevelTypeRef { get; set; }
        public Guid? StockActionRef { get; set; }
        public Guid? MaterialRef { get; set; }
        public Guid? PatientRef { get; set; }
        public Guid? PTSStockActionDetailRef { get; set; }

        #region Parent Relations
        public virtual StockLevelType StockLevelType { get; set; }
        public virtual StockAction StockAction { get; set; }
        public virtual Material Material { get; set; }
        public virtual Patient Patient { get; set; }
        #endregion Parent Relations
    }
}