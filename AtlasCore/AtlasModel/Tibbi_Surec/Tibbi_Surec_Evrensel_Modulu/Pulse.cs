using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Pulse
    {
        public Guid ObjectId { get; set; }
        public int? Value { get; set; }

        #region Base Object Navigation Property
        public virtual VitalSign VitalSign { get; set; }
        #endregion Base Object Navigation Property
    }
}