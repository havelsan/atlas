using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockGuideCardDetail
    {
        public Guid ObjectId { get; set; }
        public double? Amount { get; set; }
        public Guid? MaterialRef { get; set; }
        public Guid? StockGuideCardRef { get; set; }

        #region Parent Relations
        public virtual Material Material { get; set; }
        public virtual StockGuideCard StockGuideCard { get; set; }
        #endregion Parent Relations
    }
}