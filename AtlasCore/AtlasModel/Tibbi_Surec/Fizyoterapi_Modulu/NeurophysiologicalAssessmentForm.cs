using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NeurophysiologicalAssessmentForm
    {
        public Guid ObjectId { get; set; }
        public string BobathBrunstrum { get; set; }
        public string ChedokeStrokeAssessmentScale { get; set; }
        public string Rood { get; set; }
        public string Kabat { get; set; }
        public string Vojta { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAdditionalInfo BaseAdditionalInfo { get; set; }
        #endregion Base Object Navigation Property
    }
}