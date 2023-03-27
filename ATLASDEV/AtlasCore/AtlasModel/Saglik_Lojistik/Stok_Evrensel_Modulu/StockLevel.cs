using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockLevel
    {
        public Guid ObjectId { get; set; }
        public decimal? Amount { get; set; }
        public Guid? StockRef { get; set; }
        public Guid? StockLevelTypeRef { get; set; }

        #region Parent Relations
        public virtual Stock Stock { get; set; }
        public virtual StockLevelType StockLevelType { get; set; }
        #endregion Parent Relations
    }
}