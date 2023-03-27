using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class EpisodeAccountAction
    {
        public Guid ObjectId { get; set; }
        public decimal? TotalDiscountPrice { get; set; }
        public string Description { get; set; }
        public string CashOfficeName { get; set; }
        public decimal? GeneralTotalPrice { get; set; }
        public decimal? TotalPrice { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property
    }
}