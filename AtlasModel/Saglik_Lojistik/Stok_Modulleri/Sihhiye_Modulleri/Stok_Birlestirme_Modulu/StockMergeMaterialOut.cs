using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockMergeMaterialOut
    {
        public Guid ObjectId { get; set; }
        public Guid? StockMergeMaterialInRef { get; set; }
        public Guid? OutableStockTransactionRef { get; set; }

        #region Base Object Navigation Property
        public virtual StockActionDetailOut StockActionDetailOut { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual StockMergeMaterialIn StockMergeMaterialIn { get; set; }
        public virtual StockTransaction OutableStockTransaction { get; set; }
        #endregion Parent Relations
    }
}