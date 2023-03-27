using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DailyDrugPatient
    {
        public Guid ObjectId { get; set; }
        public bool? IsCheck { get; set; }
        public Guid? InPatientPhysicianApplicationRef { get; set; }
        public Guid? DailyDrugScheduleRef { get; set; }
        public Guid? EpisodeRef { get; set; }
        public Guid? PatientRef { get; set; }

        #region Parent Relations
        public virtual InPatientPhysicianApplication InPatientPhysicianApplication { get; set; }
        public virtual DailyDrugSchedule DailyDrugSchedule { get; set; }
        public virtual Episode Episode { get; set; }
        public virtual Patient Patient { get; set; }
        #endregion Parent Relations
    }
}