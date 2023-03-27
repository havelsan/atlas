using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockReservation
    {
        public Guid ObjectId { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public Guid? StockRef { get; set; }

        #region Parent Relations
        public virtual Stock Stock { get; set; }
        #endregion Parent Relations
    }
}