using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockCollectedTrx
    {
        public Guid ObjectId { get; set; }
        public Guid? StockActionDetailRef { get; set; }
        public Guid? StockTransactionRef { get; set; }

        #region Parent Relations
        public virtual StockActionDetail StockActionDetail { get; set; }
        public virtual StockTransaction StockTransaction { get; set; }
        #endregion Parent Relations
    }
}