using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MainStoreDistDocDetail
    {
        public Guid ObjectId { get; set; }
        public decimal? SendedAmount { get; set; }

        #region Base Object Navigation Property
        public virtual StockActionDetailOut StockActionDetailOut { get; set; }
        #endregion Base Object Navigation Property
    }
}