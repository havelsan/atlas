using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class WomanSpecialityObject
    {
        public Guid ObjectId { get; set; }
        public VarYokGarantiEnum? RhIncompatibility { get; set; }
        public DegreeOfBloodRelativesEnum? DegreeOfRelationship { get; set; }
        public BloodGroupEnum? HusbandBloodGroup { get; set; }
        public int? NumberOfPregnancy { get; set; }
        public int? Parity { get; set; }
        public int? Abortion { get; set; }
        public int? LivingBabies { get; set; }
        public int? DC { get; set; }
        public string HusbandFullName { get; set; }
        public int? MarriageDate { get; set; }
        public BloodGroupEnum? WomanBloodGroup { get; set; }
        public Guid? InfertilityRef { get; set; }
        public Guid? PregnancyFollowRef { get; set; }
        public Guid? GynecologyRef { get; set; }
        public Guid? HusbandRef { get; set; }
        public Guid? PregnantInformationRef { get; set; }

        #region Base Object Navigation Property
        public virtual SpecialityBasedObject SpecialityBasedObject { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual Gynecology Gynecology { get; set; }
        public virtual Patient Husband { get; set; }
        public virtual PregnantInformation PregnantInformation { get; set; }
        #endregion Parent Relations
    }
}