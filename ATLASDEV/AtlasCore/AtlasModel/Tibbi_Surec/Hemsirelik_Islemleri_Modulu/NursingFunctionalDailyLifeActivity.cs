using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingFunctionalDailyLifeActivity
    {
        public Guid ObjectId { get; set; }
        public NursingDailyLifeActivityEnum? Status { get; set; }
        public string DetailNote { get; set; }
        public bool? IsCheck { get; set; }
        public Guid? NursingDailyLifeActivityRef { get; set; }
        public Guid? DailyLifeActivityRef { get; set; }

        #region Parent Relations
        public virtual NursingDailyLifeActivity NursingDailyLifeActivity { get; set; }
        #endregion Parent Relations
    }
}