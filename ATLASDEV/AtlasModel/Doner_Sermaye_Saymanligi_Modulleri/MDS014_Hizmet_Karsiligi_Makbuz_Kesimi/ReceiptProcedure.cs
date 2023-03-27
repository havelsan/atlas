using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ReceiptProcedure
    {
        public Guid ObjectId { get; set; }
        public DateTime? ActionDate { get; set; }
        public string ExternalCode { get; set; }
        public string Description { get; set; }
        public bool? Paid { get; set; }
        public decimal? TotalDiscountPrice { get; set; }
        public int? Amount { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalDiscountedPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public string RevenueType { get; set; }
        public decimal? RemainingPrice { get; set; }
        public decimal? PaymentPrice { get; set; }
        public Guid? ReceiptRef { get; set; }

        #region Parent Relations
        public virtual Receipt Receipt { get; set; }
        #endregion Parent Relations
    }
}