using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingPainScale
    {
        public Guid ObjectId { get; set; }
        public DateTime? NursingAppDoneDate { get; set; }
        public PostNursingInitiativesEnum? PostNursingInitiative { get; set; }
        public string PainDetail { get; set; }
        public string PainTime { get; set; }
        public string DurationofPain { get; set; }
        public string AchingSide { get; set; }
        public string PainQualityDescription { get; set; }
        public PainFaceScaleEnum? PainFaceScale { get; set; }

        #region Base Object Navigation Property
        public virtual BaseNursingDataEntry BaseNursingDataEntry { get; set; }
        #endregion Base Object Navigation Property
    }
}