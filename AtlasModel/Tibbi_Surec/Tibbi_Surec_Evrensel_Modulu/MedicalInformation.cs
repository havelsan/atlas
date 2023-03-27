using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MedicalInformation
    {
        public Guid ObjectId { get; set; }
        public VarYokGarantiEnum? HasAllergy { get; set; }
        public string OtherInformation { get; set; }
        public string Transplantation { get; set; }
        public string OncologicFollowUp { get; set; }
        public string Implant { get; set; }
        public string Hemodialysis { get; set; }
        public bool? Pregnancy { get; set; }
        public string ChronicDiseases { get; set; }
        public VarYokGarantiEnum? HasContagiousDisease { get; set; }
        public string ContagiousDisease { get; set; }
        public bool? CardiacPacemaker { get; set; }
        public bool? HeartFailure { get; set; }
        public bool? Broken { get; set; }
        public bool? Diabetes { get; set; }
        public bool? Malignancy { get; set; }
        public bool? MetalImplant { get; set; }
        public bool? VascularDisorder { get; set; }
        public bool? Infection { get; set; }
        public bool? Stent { get; set; }
        public bool? Other { get; set; }
        public bool? Advers { get; set; }
        public Guid? MedicalInfoAllergiesRef { get; set; }
        public Guid? MedicalInfoHabitsRef { get; set; }
        public Guid? MedicalInfoDisabledGroupRef { get; set; }

        #region Parent Relations
        public virtual MedicalInfoAllergies MedicalInfoAllergies { get; set; }
        public virtual MedicalInfoHabits MedicalInfoHabits { get; set; }
        public virtual MedicalInfoDisabledGroup MedicalInfoDisabledGroup { get; set; }
        #endregion Parent Relations
    }
}