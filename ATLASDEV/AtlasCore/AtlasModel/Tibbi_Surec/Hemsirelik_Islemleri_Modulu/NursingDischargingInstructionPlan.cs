using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingDischargingInstructionPlan
    {
        public Guid ObjectId { get; set; }
        public string Note { get; set; }
        public DateTime? ActionDate { get; set; }
        public bool? PatientGetInstruction { get; set; }
        public Guid? DischargingInstructionPlanRef { get; set; }
        public Guid? BaseDischargingPlanRef { get; set; }

        #region Parent Relations
        public virtual BaseNursingDischargingInstructionPlan BaseDischargingPlan { get; set; }
        #endregion Parent Relations
    }
}