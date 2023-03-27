using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DentalExaminationTreatmentMaterial
    {
        public Guid ObjectId { get; set; }

        #region Base Object Navigation Property
        public virtual BaseTreatmentMaterial BaseTreatmentMaterial { get; set; }
        #endregion Base Object Navigation Property
    }
}