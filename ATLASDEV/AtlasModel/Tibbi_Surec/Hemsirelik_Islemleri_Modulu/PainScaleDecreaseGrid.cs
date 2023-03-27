using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PainScaleDecreaseGrid
    {
        public Guid ObjectId { get; set; }
        public Guid? NursingPainScaleRef { get; set; }
        public Guid? PainChangingSituationRef { get; set; }

        #region Parent Relations
        public virtual NursingPainScale NursingPainScale { get; set; }
        #endregion Parent Relations
    }
}