using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ChattelDocumentDetailWithPurchase
    {
        public Guid ObjectId { get; set; }
        public decimal? UnitPriceWithOutVat { get; set; }
        public decimal? UnitPriceWithInVat { get; set; }

        #region Base Object Navigation Property
        public virtual StockActionDetailIn StockActionDetailIn { get; set; }
        #endregion Base Object Navigation Property
    }
}