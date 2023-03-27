using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockLocation
    {
        public Guid ObjectId { get; set; }
        public bool? IsGroup { get; set; }
        public string Name { get; set; }
        public string Name_Shadow { get; set; }
        public Guid? ParentStockLocationRef { get; set; }

        #region Parent Relations
        public virtual StockLocation ParentStockLocation { get; set; }
        #endregion Parent Relations
    }
}