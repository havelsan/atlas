using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MainStoreStockTransferMat
    {
        public Guid ObjectId { get; set; }
        public decimal? RequestAmount { get; set; }

        #region Base Object Navigation Property
        public virtual StockActionDetailOut StockActionDetailOut { get; set; }
        #endregion Base Object Navigation Property
    }
}