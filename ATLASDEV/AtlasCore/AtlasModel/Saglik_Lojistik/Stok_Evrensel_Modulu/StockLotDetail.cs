using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockLotDetail
    {
        public Guid ObjectId { get; set; }
        public string LotNo { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public decimal? RestAmount { get; set; }
        public Guid? StockRef { get; set; }
        public Guid? StockLevelTypeRef { get; set; }

        #region Parent Relations
        public virtual Stock Stock { get; set; }
        public virtual StockLevelType StockLevelType { get; set; }
        #endregion Parent Relations
    }
}