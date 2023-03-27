using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class FallingDownRiskDefinition
    {
        public Guid ObjectId { get; set; }
        public int? Score { get; set; }
        public string Name { get; set; }
        public FallingDownRiskTypeEnum? Type { get; set; }
        public string Name_Shadow { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}