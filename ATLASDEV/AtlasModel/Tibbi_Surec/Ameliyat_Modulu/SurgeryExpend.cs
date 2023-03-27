using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SurgeryExpend
    {
        public Guid ObjectId { get; set; }
        public Guid? MainSurgeryRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseTreatmentMaterial BaseTreatmentMaterial { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual Surgery MainSurgery { get; set; }
        #endregion Parent Relations
    }
}