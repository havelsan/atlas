using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DrugOrderForReport
    {
        public Guid ObjectId { get; set; }
        public bool? HasReport { get; set; }
        public int? Dosage { get; set; }
        public int? DosageAmount { get; set; }
        public int? WeeklyMonthly { get; set; }
        public bool? HasTenDays { get; set; }
        public Guid? DrugRef { get; set; }
        public Guid? SPTSReportEntryActionRef { get; set; }
        public Guid? BarcodeLevelRef { get; set; }

        #region Parent Relations
        public virtual DrugDefinition Drug { get; set; }
        #endregion Parent Relations
    }
}