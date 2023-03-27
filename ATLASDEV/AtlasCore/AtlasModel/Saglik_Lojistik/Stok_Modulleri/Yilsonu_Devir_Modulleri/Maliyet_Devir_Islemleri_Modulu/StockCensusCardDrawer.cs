using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockCensusCardDrawer
    {
        public Guid ObjectId { get; set; }
        public bool? IsDoubleZeroCompleted { get; set; }
        public bool? IsStockCensusCompleted { get; set; }
        public Guid? DoubleZeroObjectID { get; set; }
        public Guid? StockCensusObjectID { get; set; }
        public Guid? CardDrawerRef { get; set; }
        public Guid? CheckStockCensusActionRef { get; set; }
        public Guid? ResUserRef { get; set; }

        #region Parent Relations
        public virtual CheckStockCensusAction CheckStockCensusAction { get; set; }
        public virtual ResUser ResUser { get; set; }
        #endregion Parent Relations
    }
}