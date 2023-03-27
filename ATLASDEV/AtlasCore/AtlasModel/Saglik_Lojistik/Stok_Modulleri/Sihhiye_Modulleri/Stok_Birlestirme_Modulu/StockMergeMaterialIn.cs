using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockMergeMaterialIn
    {
        public Guid ObjectId { get; set; }
        public Guid? StockMergeMaterialOutRef { get; set; }

        #region Base Object Navigation Property
        public virtual StockActionDetailIn StockActionDetailIn { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual StockMergeMaterialOut StockMergeMaterialOut { get; set; }
        #endregion Parent Relations
    }
}