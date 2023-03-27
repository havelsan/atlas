using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingOrderDetail
    {
        public Guid ObjectId { get; set; }

        #region Base Object Navigation Property
        public virtual BaseNursingOrderDetails BaseNursingOrderDetails { get; set; }
        #endregion Base Object Navigation Property
    }
}