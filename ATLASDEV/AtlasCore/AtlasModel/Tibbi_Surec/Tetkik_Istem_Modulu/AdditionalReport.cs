using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AdditionalReport
    {
        public Guid ObjectId { get; set; }
        public bool? IsCompleted { get; set; }
        public Guid? Report { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAdditionalInfo BaseAdditionalInfo { get; set; }
        #endregion Base Object Navigation Property
    }
}