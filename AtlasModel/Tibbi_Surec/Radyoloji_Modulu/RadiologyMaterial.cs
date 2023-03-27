using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class RadiologyMaterial
    {
        public Guid ObjectId { get; set; }
        public Guid? RadiologyRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseTreatmentMaterial BaseTreatmentMaterial { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual Radiology Radiology { get; set; }
        #endregion Parent Relations
    }
}