using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingInitiative
    {
        public Guid ObjectId { get; set; }
        public Guid? NursingPainScaleRef { get; set; }

        #region Parent Relations
        public virtual NursingPainScale NursingPainScale { get; set; }
        #endregion Parent Relations
    }
}