using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class GaitAnalysisForm
    {
        public Guid ObjectId { get; set; }
        public string FIM { get; set; }
        public string FAC { get; set; }
        public string RivermeadAssessment { get; set; }
        public string BarthelIndex { get; set; }
        public string PULSESProfile { get; set; }
        public string GMFCS { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAdditionalInfo BaseAdditionalInfo { get; set; }
        #endregion Base Object Navigation Property
    }
}