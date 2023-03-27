using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ChemoRadioCureProtocol
    {
        public Guid ObjectId { get; set; }
        public int? CureCount { get; set; }
        public int? RepetitiveDayCount { get; set; }
        public int? PreCureMinute { get; set; }
        public int? CureTime { get; set; }
        public int? AfterCureTime { get; set; }
        public int? DrugDose { get; set; }
        public int? SolventDose { get; set; }
        public Guid? CureDescription { get; set; }
        public bool? IsRadiotherapyCure { get; set; }
        public Guid? ChemotherapyRadiotherapyRef { get; set; }
        public Guid? EtkinMaddeRef { get; set; }
        public Guid? RadiotherapyXRayTypeDefRef { get; set; }
        public Guid? MaterialRef { get; set; }
        public Guid? ChemotherapyApplyMethodRef { get; set; }
        public Guid? ChemotherapyApplySubMethodRef { get; set; }

        #region Base Object Navigation Property
        public virtual PlannedAction PlannedAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ChemotherapyRadiotherapy ChemotherapyRadiotherapy { get; set; }
        public virtual EtkinMadde EtkinMadde { get; set; }
        public virtual RadiotherapyXRayTypeDef RadiotherapyXRayTypeDef { get; set; }
        public virtual Material Material { get; set; }
        public virtual ChemotherapyApplyMethod ChemotherapyApplyMethod { get; set; }
        public virtual ChemotherapyApplySubMethod ChemotherapyApplySubMethod { get; set; }
        #endregion Parent Relations
    }
}