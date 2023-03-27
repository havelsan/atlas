using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DailyActivityTestsForm
    {
        public Guid ObjectId { get; set; }
        public string BarthelTest { get; set; }
        public string FonctionalIndependenceMeasure { get; set; }
        public string HealthAssessmentQuostionnarie { get; set; }
        public string BASFI { get; set; }
        public string KatzIndex { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAdditionalInfo BaseAdditionalInfo { get; set; }
        #endregion Base Object Navigation Property
    }
}