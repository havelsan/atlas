using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ExtendExpirationDateDetail
    {
        public Guid ObjectId { get; set; }
        public DateTime? NewDateForExpiration { get; set; }
        public DateTime? CurrentExpirationDate { get; set; }
        public decimal? SelectedLotRestAmount { get; set; }

        #region Base Object Navigation Property
        public virtual StockActionDetailOut StockActionDetailOut { get; set; }
        #endregion Base Object Navigation Property
    }
}