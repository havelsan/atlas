using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class WoundPhoto
    {
        public Guid ObjectId { get; set; }
        public Guid? Photo { get; set; }
        public DateTime? PhotoDate { get; set; }
        public Guid? NursingWoundRef { get; set; }

        #region Parent Relations
        public virtual NursingWoundedAssesment NursingWound { get; set; }
        #endregion Parent Relations
    }
}