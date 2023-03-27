using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class KScheduleUnListMaterial
    {
        public Guid ObjectId { get; set; }
        public double? UnlistVolume { get; set; }
        public string UnlistDrug { get; set; }
        public double? UnlistAmount { get; set; }
        public string UnlistPatient { get; set; }
        public string UnlistReason { get; set; }
        public Guid? KScheduleRef { get; set; }

        #region Parent Relations
        public virtual KSchedule KSchedule { get; set; }
        #endregion Parent Relations
    }
}