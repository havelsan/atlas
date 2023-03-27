using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AccountPeriodDefinition
    {
        public Guid ObjectId { get; set; }
        public int? Year { get; set; }
        public MonthsEnum? Month { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}