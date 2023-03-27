using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockGuideCard
    {
        public Guid ObjectId { get; set; }
        public string ShortDescription { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Description_Shadow { get; set; }
        public string Name_Shadow { get; set; }
        public Guid? StockCardRef { get; set; }

        #region Parent Relations
        public virtual StockCard StockCard { get; set; }
        #endregion Parent Relations
    }
}