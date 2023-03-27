using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ChattelDocumentDistribution
    {
        public Guid ObjectId { get; set; }
        public decimal? DistributionAmount { get; set; }
        public Guid? DemandDetailRef { get; set; }
        public Guid? ChattelDocumentWithPurchaseRef { get; set; }
        public Guid? ChattelDocDetailWithPurchaseRef { get; set; }

        #region Parent Relations
        public virtual ChattelDocumentWithPurchase ChattelDocumentWithPurchase { get; set; }
        public virtual ChattelDocumentDetailWithPurchase ChattelDocDetailWithPurchase { get; set; }
        #endregion Parent Relations
    }
}