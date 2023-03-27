using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class HCExaminationDisabledRatio
    {
        public Guid ObjectId { get; set; }
        public string DisabledRatio { get; set; }
        public Guid? HCExaminationComponentRef { get; set; }

        #region Parent Relations
        public virtual HCExaminationComponent HCExaminationComponent { get; set; }
        #endregion Parent Relations
    }
}