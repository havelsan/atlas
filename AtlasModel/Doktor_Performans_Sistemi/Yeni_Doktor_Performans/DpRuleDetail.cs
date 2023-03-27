using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DpRuleDetail
    {
        public Guid ObjectId { get; set; }
        public int? Sex { get; set; }
        public string TedaviTuru { get; set; }
        public int? Kesi { get; set; }
        public int? Report { get; set; }
        public int? Age { get; set; }
        public int? AgeType { get; set; }
        public int? HospitalType { get; set; }
        public int? PeriodScope { get; set; }
        public int? PeriodAmount { get; set; }
        public int? Period { get; set; }
        public int? PeriodTimeType { get; set; }
        public string Master { get; set; }
        public Guid? DPRuleMasterRef { get; set; }

        #region Parent Relations
        public virtual DPRuleMaster DPRuleMaster { get; set; }
        #endregion Parent Relations
    }
}