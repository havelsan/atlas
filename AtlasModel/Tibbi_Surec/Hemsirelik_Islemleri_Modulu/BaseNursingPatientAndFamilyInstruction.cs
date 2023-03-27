using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseNursingPatientAndFamilyInstruction
    {
        public Guid ObjectId { get; set; }
        public string InstructionNote { get; set; }
        public bool? CompanionInstruction { get; set; }

        #region Base Object Navigation Property
        public virtual BaseNursingDataEntry BaseNursingDataEntry { get; set; }
        #endregion Base Object Navigation Property
    }
}