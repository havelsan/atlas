using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AccountAction
    {
        public Guid ObjectId { get; set; }
        public decimal? TotalPrice { get; set; }
        public string CashOfficeName { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAction BaseAction { get; set; }
        #endregion Base Object Navigation Property
    }
}