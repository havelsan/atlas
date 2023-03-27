using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ScoliosisAssessmentForm
    {
        public Guid ObjectId { get; set; }
        public ChestPostureEnum? ChestPosture { get; set; }
        public ShoulderPostureEnum? ShoulderPosture { get; set; }
        public ScapulaPostureEnum? ScapulaPosture { get; set; }
        public SpinePostureEnum? SpinePosture { get; set; }
        public LegPostureEnum? LegPosture { get; set; }
        public FeetPostureEnum? FeetPosture { get; set; }
        public LegsLengthEnum? LegsLength { get; set; }
        public HeadPostureEnum? HeadPosture { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAdditionalInfo BaseAdditionalInfo { get; set; }
        #endregion Base Object Navigation Property
    }
}