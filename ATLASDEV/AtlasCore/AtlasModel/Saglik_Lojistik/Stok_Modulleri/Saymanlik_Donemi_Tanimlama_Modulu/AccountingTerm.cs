using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AccountingTerm
    {
        public Guid ObjectId { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public AccountingTermStatusEnum? Status { get; set; }
        public CostingMethodEnum? CostingMethod { get; set; }
        public bool? IsFirstTerm { get; set; }
        public Guid? AccountancyRef { get; set; }
        public Guid? PrevTermRef { get; set; }

        #region Parent Relations
        public virtual Accountancy Accountancy { get; set; }
        public virtual AccountingTerm PrevTerm { get; set; }
        #endregion Parent Relations
    }
}