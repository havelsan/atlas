using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DpRuleSpeciality
    {
        public Guid ObjectId { get; set; }
        public string Master { get; set; }
        public string Code { get; set; }
        public int? BannOrMustType { get; set; }
        public string Name { get; set; }
        public Guid? DPRuleMasterRef { get; set; }

        #region Parent Relations
        public virtual DPRuleMaster DPRuleMaster { get; set; }
        #endregion Parent Relations
    }
}