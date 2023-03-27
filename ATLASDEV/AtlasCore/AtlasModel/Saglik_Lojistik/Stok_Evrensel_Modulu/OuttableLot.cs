using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class OuttableLot
    {
        public Guid ObjectId { get; set; }
        public bool? isUse { get; set; }
        public decimal? Amount { get; set; }
        public decimal? RestAmount { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string LotNo { get; set; }
        public Guid? StockActionDetailOutRef { get; set; }

        #region Parent Relations
        public virtual StockActionDetailOut StockActionDetailOut { get; set; }
        #endregion Parent Relations
    }
}