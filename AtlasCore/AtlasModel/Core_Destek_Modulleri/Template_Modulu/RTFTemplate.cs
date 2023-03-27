using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class RTFTemplate
    {
        public Guid ObjectId { get; set; }

        #region Base Object Navigation Property
        public virtual BaseTemplate BaseTemplate { get; set; }
        #endregion Base Object Navigation Property
    }
}