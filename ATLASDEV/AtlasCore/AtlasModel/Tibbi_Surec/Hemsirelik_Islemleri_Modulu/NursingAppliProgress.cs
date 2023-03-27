using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingAppliProgress
    {
        public Guid ObjectId { get; set; }
        public string Description { get; set; }
        public DateTime? ProgressDate { get; set; }
        public bool? HandOverNote { get; set; }

        #region Base Object Navigation Property
        public virtual BaseNursingDataEntry BaseNursingDataEntry { get; set; }
        #endregion Base Object Navigation Property
    }
}