using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockCensusLevel
    {
        public Guid ObjectId { get; set; }
        public decimal? Amount { get; set; }
        public Guid? StockLevelTypeRef { get; set; }
        public Guid? StockCensusDetailRef { get; set; }

        #region Parent Relations
        public virtual StockLevelType StockLevelType { get; set; }
        public virtual StockCensusDetail StockCensusDetail { get; set; }
        #endregion Parent Relations
    }
}