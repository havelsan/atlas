using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SensoryPerceptionAssessmentForm
    {
        public Guid ObjectId { get; set; }
        public string ASIAImpairmentScale { get; set; }
        public string KurtzkeScale { get; set; }
        public string FuglMeyerTest { get; set; }
        public string RivemeadIndex { get; set; }
        public string MiniMentalStateExamination { get; set; }
        public string StarCancellationTest { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAdditionalInfo BaseAdditionalInfo { get; set; }
        #endregion Base Object Navigation Property
    }
}