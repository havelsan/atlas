using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DailyDrugSchOrder
    {
        public Guid ObjectId { get; set; }
        public Guid? KSchMaterial { get; set; }
        public double? DoseAmount { get; set; }
        public Guid? DailyDrugScheduleRef { get; set; }
        public Guid? MaterialRef { get; set; }
        public Guid? DailyDrugPatientRef { get; set; }

        #region Parent Relations
        public virtual DailyDrugSchedule DailyDrugSchedule { get; set; }
        public virtual Material Material { get; set; }
        public virtual DailyDrugPatient DailyDrugPatient { get; set; }
        #endregion Parent Relations
    }
}