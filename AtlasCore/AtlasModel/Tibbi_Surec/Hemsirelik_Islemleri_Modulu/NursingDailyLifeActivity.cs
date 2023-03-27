using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingDailyLifeActivity
    {
        public Guid ObjectId { get; set; }
        public string Note { get; set; }
        public DateTime? ActionDate { get; set; }

        #region Base Object Navigation Property
        public virtual BaseNursingDataEntry BaseNursingDataEntry { get; set; }
        #endregion Base Object Navigation Property
    }
}