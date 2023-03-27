using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BloodPressure
    {
        public Guid ObjectId { get; set; }
        public int? Sistolik { get; set; }
        public int? Diastolik { get; set; }

        #region Base Object Navigation Property
        public virtual VitalSign VitalSign { get; set; }
        #endregion Base Object Navigation Property
    }
}