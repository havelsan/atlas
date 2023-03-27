using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ScheduledTaskHistory
    {
        public Guid ObjectId { get; set; }
        public string Log { get; set; }
        public DateTime? LogDate { get; set; }
        public Guid? BaseScheduledTaskRef { get; set; }

        #region Parent Relations
        public virtual BaseScheduledTask BaseScheduledTask { get; set; }
        #endregion Parent Relations
    }
}