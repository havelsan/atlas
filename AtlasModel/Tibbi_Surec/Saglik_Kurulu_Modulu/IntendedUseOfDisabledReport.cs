using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class IntendedUseOfDisabledReport
    {
        public Guid ObjectId { get; set; }
        public EvetHayirDegerlendirilmediEnum? DisabledIdentityCardEvalution { get; set; }
        public EvetHayirDegerlendirilmediEnum? OtherEvaluation { get; set; }
        public string OtherExplanation { get; set; }
        public EvetHayirDegerlendirilmediEnum? LawNo2022Evaluation { get; set; }
        public EvetHayirDegerlendirilmediEnum? EducationEvaluation { get; set; }
        public EvetHayirDegerlendirilmediEnum? EmploymentEvaluation { get; set; }
        public EvetHayirDegerlendirilmediEnum? SocialAidEvaluation { get; set; }
        public EvetHayirDegerlendirilmediEnum? OrtesisProsthesEquEvaluation { get; set; }
        public EvetHayirDegerlendirilmediEnum? DisabledChaiEvaluation { get; set; }
    }
}