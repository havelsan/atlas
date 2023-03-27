using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Receipt
    {
        public Guid ObjectId { get; set; }
        public decimal? TotalDiscountEntry { get; set; }
        public decimal? TotalPayment { get; set; }
        public decimal? DebentureTaken { get; set; }
        public decimal? AdvanceTaken { get; set; }
        public bool? UnDetailedReport { get; set; }
        public Guid? DiscountTypeDefinitionRef { get; set; }
        public Guid? ReceiptDocumentRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAccountAction EpisodeAccountAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ReceiptDocument ReceiptDocument { get; set; }
        #endregion Parent Relations
    }
}