using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class GlaskowScore
    {
        public Guid ObjectId { get; set; }
        public int? Total { get; set; }
        public GlaskowComaScaleScoreEnum? TotalScore { get; set; }
        public Guid? EyesRef { get; set; }
        public Guid? MotorAnswerRef { get; set; }
        public Guid? OralAnswerRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseMultipleDataEntry BaseMultipleDataEntry { get; set; }
        #endregion Base Object Navigation Property
    }
}