using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ReceiptDocumentDetail
    {
        public Guid ObjectId { get; set; }
        public decimal? PaymentPrice { get; set; }
        public decimal? PaymentPriceByAdvance { get; set; }
        public bool? IsParticipationShare { get; set; }

        #region Base Object Navigation Property
        public virtual AccountDocumentDetail AccountDocumentDetail { get; set; }
        #endregion Base Object Navigation Property
    }
}