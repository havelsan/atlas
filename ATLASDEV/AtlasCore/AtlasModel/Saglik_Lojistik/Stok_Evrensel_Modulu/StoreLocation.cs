using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StoreLocation
    {
        public Guid ObjectId { get; set; }
        public Guid? StockLocationRef { get; set; }
        public Guid? StockRef { get; set; }

        #region Parent Relations
        public virtual StockLocation StockLocation { get; set; }
        public virtual Stock Stock { get; set; }
        #endregion Parent Relations
    }
}