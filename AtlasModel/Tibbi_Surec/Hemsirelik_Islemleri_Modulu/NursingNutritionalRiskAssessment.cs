using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingNutritionalRiskAssessment
    {
        public Guid ObjectId { get; set; }
        public bool? SevereDiseaseInfo { get; set; }
        public bool? BMI { get; set; }
        public bool? ThreeMonthWeightLoss { get; set; }
        public bool? WeeklyIntakeDecrease { get; set; }
        public int? TotalScore { get; set; }
        public NutritionIntakeAssessmentEnum? NutritionIntake { get; set; }
        public bool? DiseaseLevelNormal { get; set; }
        public bool? DiseaseLevelLow { get; set; }
        public bool? DiseaseLevelMedium { get; set; }
        public bool? DiseaseLevelHigh { get; set; }
        public int? Height { get; set; }
        public double? Weight { get; set; }

        #region Base Object Navigation Property
        public virtual BaseNursingDataEntry BaseNursingDataEntry { get; set; }
        #endregion Base Object Navigation Property
    }
}