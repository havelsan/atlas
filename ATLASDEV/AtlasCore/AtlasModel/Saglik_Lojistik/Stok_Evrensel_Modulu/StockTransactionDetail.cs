using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockTransactionDetail
    {
        public Guid ObjectId { get; set; }
        public decimal? Amount { get; set; }
        public Guid? InStockTransactionRef { get; set; }
        public Guid? OutStockTransactionRef { get; set; }

        #region Parent Relations
        public virtual StockTransaction InStockTransaction { get; set; }
        public virtual StockTransaction OutStockTransaction { get; set; }
        #endregion Parent Relations
    }
}