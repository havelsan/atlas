using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AccountDayTerm
    {
        public Guid ObjectId { get; set; }
        public decimal? Average { get; set; }
        public decimal? MovableAverage { get; set; }
        public decimal? ProcedureAverage { get; set; }
        public Guid? AccountPeriodRef { get; set; }

        #region Parent Relations
        public virtual AccountPeriodDefinition AccountPeriod { get; set; }
        #endregion Parent Relations
    }
}