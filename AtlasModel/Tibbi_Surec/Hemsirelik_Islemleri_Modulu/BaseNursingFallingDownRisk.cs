using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseNursingFallingDownRisk
    {
        public Guid ObjectId { get; set; }
        public DateTime? NursingAppDoneDate { get; set; }
        public FallingDownRiskReasonEnum? FallingDownRiskReason { get; set; }
        public string Note { get; set; }
        public int? TotalScore { get; set; }

        #region Base Object Navigation Property
        public virtual BaseNursingDataEntry BaseNursingDataEntry { get; set; }
        #endregion Base Object Navigation Property
    }
}