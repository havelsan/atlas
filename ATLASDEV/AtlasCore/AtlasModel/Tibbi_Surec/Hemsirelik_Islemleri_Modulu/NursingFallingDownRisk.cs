using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingFallingDownRisk
    {
        public Guid ObjectId { get; set; }
        public DateTime? ActionDate { get; set; }
        public Guid? RiskFactorRef { get; set; }
        public Guid? BaseNursingFallingDownRiskRef { get; set; }

        #region Parent Relations
        public virtual FallingDownRiskDefinition RiskFactor { get; set; }
        public virtual BaseNursingFallingDownRisk BaseNursingFallingDownRisk { get; set; }
        #endregion Parent Relations
    }
}