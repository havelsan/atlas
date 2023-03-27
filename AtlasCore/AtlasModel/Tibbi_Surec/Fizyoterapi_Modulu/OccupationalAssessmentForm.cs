using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class OccupationalAssessmentForm
    {
        public Guid ObjectId { get; set; }
        public string CHART { get; set; }
        public string FCE { get; set; }
        public string DASH { get; set; }
        public string POP { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAdditionalInfo BaseAdditionalInfo { get; set; }
        #endregion Base Object Navigation Property
    }
}