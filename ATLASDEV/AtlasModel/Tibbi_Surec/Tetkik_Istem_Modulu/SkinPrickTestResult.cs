using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SkinPrickTestResult
    {
        public Guid ObjectId { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAdditionalInfo BaseAdditionalInfo { get; set; }
        #endregion Base Object Navigation Property
    }
}