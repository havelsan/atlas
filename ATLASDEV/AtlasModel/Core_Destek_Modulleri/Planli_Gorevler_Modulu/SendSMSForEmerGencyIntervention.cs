using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SendSMSForEmerGencyIntervention
    {
        public Guid ObjectId { get; set; }

        #region Base Object Navigation Property
        public virtual BaseScheduledTask BaseScheduledTask { get; set; }
        #endregion Base Object Navigation Property
    }
}