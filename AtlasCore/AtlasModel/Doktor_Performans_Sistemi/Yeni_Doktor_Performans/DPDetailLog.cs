using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DPDetailLog
    {
        public Guid ObjectId { get; set; }
        public DateTime? ExecDate { get; set; }
        public Guid? Log { get; set; }
        public int? TotalCalcPoint { get; set; }
        public Guid? TermRef { get; set; }
        public Guid? DoctorRef { get; set; }

        #region Parent Relations
        public virtual ResUser Doctor { get; set; }
        #endregion Parent Relations
    }
}