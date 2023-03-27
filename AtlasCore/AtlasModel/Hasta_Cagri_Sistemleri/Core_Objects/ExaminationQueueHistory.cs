using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ExaminationQueueHistory
    {
        public Guid ObjectId { get; set; }
        public DateTime? HistoryDate { get; set; }
        public Guid? ExaminationQueueItemRef { get; set; }

        #region Parent Relations
        public virtual ExaminationQueueItem ExaminationQueueItem { get; set; }
        #endregion Parent Relations
    }
}