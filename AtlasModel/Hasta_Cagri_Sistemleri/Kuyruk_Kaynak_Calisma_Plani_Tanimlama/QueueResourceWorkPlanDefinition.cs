using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class QueueResourceWorkPlanDefinition
    {
        public Guid ObjectId { get; set; }
        public DateTime? LastCallTime { get; set; }
        public DateTime? WorkDate { get; set; }
        public Guid? ResourceRef { get; set; }
        public Guid? QueueRef { get; set; }
        public Guid? LCDNotificationRef { get; set; }

        #region Parent Relations
        public virtual Resource Resource { get; set; }
        public virtual ExaminationQueueDefinition Queue { get; set; }
        public virtual LCDNotificationDefinition LCDNotification { get; set; }
        #endregion Parent Relations
    }
}