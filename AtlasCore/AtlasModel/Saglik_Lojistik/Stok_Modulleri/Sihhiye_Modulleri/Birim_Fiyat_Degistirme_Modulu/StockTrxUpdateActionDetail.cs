using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockTrxUpdateActionDetail
    {
        public Guid ObjectId { get; set; }
        public string StockActionName { get; set; }
        public decimal? OldUnitPrice { get; set; }
        public decimal? NewUnitPrice { get; set; }
        public Guid? StockTrxUpdateActionRef { get; set; }
        public Guid? StockTransactionRef { get; set; }

        #region Parent Relations
        public virtual StockTrxUpdateAction StockTrxUpdateAction { get; set; }
        public virtual StockTransaction StockTransaction { get; set; }
        #endregion Parent Relations
    }
}