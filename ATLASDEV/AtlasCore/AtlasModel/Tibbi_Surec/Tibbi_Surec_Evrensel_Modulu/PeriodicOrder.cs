using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PeriodicOrder
    {
        public Guid ObjectId { get; set; }
        public FrequencyEnum? Frequency { get; set; }
        public double? Weight { get; set; }
        public int? RecurrenceDayAmount { get; set; }
        public int? AmountForPeriod { get; set; }
        public DateTime? PeriodStartTime { get; set; }
        public double? Heigth { get; set; }
        public DateTime? OrderDate { get; set; }
        public string OrderDescription { get; set; }
        public Guid? ProcedureObjectRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ProcedureDefinition ProcedureObject { get; set; }
        #endregion Parent Relations
    }
}