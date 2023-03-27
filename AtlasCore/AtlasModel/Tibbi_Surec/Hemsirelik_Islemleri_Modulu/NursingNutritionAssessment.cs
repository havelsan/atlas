using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingNutritionAssessment
    {
        public Guid ObjectId { get; set; }
        public double? Weight { get; set; }
        public int? Height { get; set; }
        public string WeightChange { get; set; }
        public string WeightChangeNote { get; set; }
        public int? AbdominalCircle { get; set; }
        public bool? Gastronomy { get; set; }
        public int? LeftLegCircle { get; set; }
        public int? RightLegCircle { get; set; }
        public bool? NasogastricTube { get; set; }

        #region Base Object Navigation Property
        public virtual BaseNursingDataEntry BaseNursingDataEntry { get; set; }
        #endregion Base Object Navigation Property
    }
}