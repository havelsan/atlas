using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockInMaterial
    {
        public Guid ObjectId { get; set; }

        #region Base Object Navigation Property
        public virtual StockActionDetailIn StockActionDetailIn { get; set; }
        #endregion Base Object Navigation Property
    }
}