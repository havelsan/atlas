using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingGlaskowComaScale
    {
        public Guid ObjectId { get; set; }
        public GlaskowComaScaleScoreEnum? TotalScore { get; set; }
        public DateTime? ActionDate { get; set; }
        public Guid? Note { get; set; }
        public Guid? OralAnswerRef { get; set; }
        public Guid? EyesRef { get; set; }
        public Guid? MotorAnswerRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseNursingDataEntry BaseNursingDataEntry { get; set; }
        #endregion Base Object Navigation Property
    }
}