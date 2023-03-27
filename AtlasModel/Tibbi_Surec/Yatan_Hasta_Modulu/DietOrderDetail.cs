using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DietOrderDetail
    {
        public Guid ObjectId { get; set; }
        public bool? IsReported { get; set; }
        public bool? AdditionalRation { get; set; }
        public DateTime? ReportDate { get; set; }

        #region Base Object Navigation Property
        public virtual BaseDietOrderDetail BaseDietOrderDetail { get; set; }
        #endregion Base Object Navigation Property
    }
}