using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingPatientAndFamilyInstruction
    {
        public Guid ObjectId { get; set; }
        public string Note { get; set; }
        public DateTime? ActionDate { get; set; }
        public bool? PatientGetInstruction { get; set; }
        public bool? CompanionGetInstruction { get; set; }
        public Guid? PatientAndFamilyInstructionRef { get; set; }
        public Guid? BasePatAndFamInstructionRef { get; set; }

        #region Parent Relations
        public virtual BaseNursingPatientAndFamilyInstruction BasePatAndFamInstruction { get; set; }
        #endregion Parent Relations
    }
}