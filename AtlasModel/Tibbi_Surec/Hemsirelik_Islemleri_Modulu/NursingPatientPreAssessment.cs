using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingPatientPreAssessment
    {
        public Guid ObjectId { get; set; }
        public string PatientLanguage { get; set; }
        public int? ChildCount { get; set; }
        public CauseOfInjuryEnum? CauseOfInjury { get; set; }
        public YesNoEnum? RehabHistory { get; set; }
        public DateTime? LastRehabDate { get; set; }
        public string WhereThePatientCameFrom { get; set; }
        public TheWayThePatientArriveEnum? TheWayThePatientArrive { get; set; }
        public string HereditaryDiseases { get; set; }
        public string PastIllnessesAndOperations { get; set; }
        public string AssistiveDevices { get; set; }
        public YesNoEnum? BloodTransfusionPracticed { get; set; }
        public string BloodTransfusionReaction { get; set; }
        public int? Height { get; set; }
        public double? Weight { get; set; }

        #region Base Object Navigation Property
        public virtual BaseNursingDataEntry BaseNursingDataEntry { get; set; }
        #endregion Base Object Navigation Property
    }
}