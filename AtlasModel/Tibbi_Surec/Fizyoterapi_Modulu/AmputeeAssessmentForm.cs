using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AmputeeAssessmentForm
    {
        public Guid ObjectId { get; set; }
        public string TrinityExperienceScale { get; set; }
        public string ProstheticIpperExtremityIndex { get; set; }
        public string TheSicknessImpactProfile { get; set; }
        public string GroningenScale { get; set; }
        public string MGFCScale { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAdditionalInfo BaseAdditionalInfo { get; set; }
        #endregion Base Object Navigation Property
    }
}