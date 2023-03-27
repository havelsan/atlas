using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseNursingOrder
    {
        public Guid ObjectId { get; set; }

        #region Base Object Navigation Property
        public virtual PeriodicOrder PeriodicOrder { get; set; }
        #endregion Base Object Navigation Property
    }
}