using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AccountVoucher
    {
        public Guid ObjectId { get; set; }
        public decimal? TotalPrice { get; set; }
        public bool? IsDept { get; set; }
        public Guid? AccountPeriodRef { get; set; }
        public Guid? AccountancyAddingActionRef { get; set; }

        #region Parent Relations
        public virtual AccountPeriodDefinition AccountPeriod { get; set; }
        #endregion Parent Relations
    }
}