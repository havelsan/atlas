using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class KSchedule
    {
        public Guid ObjectId { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartDate { get; set; }
        public Guid? DailyDrugScheduleRef { get; set; }
        public Guid? EpisodeRef { get; set; }
        public Guid? InPatientPhysicianApplicationRef { get; set; }

        #region Base Object Navigation Property
        public virtual StockAction StockAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual DailyDrugSchedule DailyDrugSchedule { get; set; }
        public virtual Episode Episode { get; set; }
        public virtual InPatientPhysicianApplication InPatientPhysicianApplication { get; set; }
        #endregion Parent Relations
    }
}