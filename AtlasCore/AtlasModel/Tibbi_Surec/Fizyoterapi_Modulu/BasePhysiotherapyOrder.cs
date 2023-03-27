using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BasePhysiotherapyOrder
    {
        public Guid ObjectId { get; set; }

        #region Base Object Navigation Property
        public virtual PlannedAction PlannedAction { get; set; }
        #endregion Base Object Navigation Property
    }
}