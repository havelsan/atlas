using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DailyDrugUnDrug
    {
        public Guid ObjectId { get; set; }
        public double? UnlistVolume { get; set; }
        public Guid? KSchUnMaterial { get; set; }
        public double? DoseAmount { get; set; }
        public Guid? DailyDrugPatientRef { get; set; }
        public Guid? MaterialRef { get; set; }
        public Guid? DailyDrugScheduleRef { get; set; }

        #region Parent Relations
        public virtual DailyDrugPatient DailyDrugPatient { get; set; }
        public virtual Material Material { get; set; }
        public virtual DailyDrugSchedule DailyDrugSchedule { get; set; }
        #endregion Parent Relations
    }
}