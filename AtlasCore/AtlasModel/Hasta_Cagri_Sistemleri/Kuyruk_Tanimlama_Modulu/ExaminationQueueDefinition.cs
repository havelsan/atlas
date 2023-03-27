using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ExaminationQueueDefinition
    {
        public Guid ObjectId { get; set; }
        public int? RecallCount { get; set; }
        public bool? IsEmergencyQueue { get; set; }
        public bool? NotAllowToSelectDoctor { get; set; }
        public bool? IsActiveQueue { get; set; }
        public bool? IgnorePriority { get; set; }
        public int? DisplayPeriod { get; set; }
        public string Name { get; set; }
        public int? DivertTime { get; set; }
        public Guid? QueuePriorityTemplateDefRef { get; set; }
        public Guid? ResSectionRef { get; set; }

        #region Parent Relations
        public virtual ResSection ResSection { get; set; }
        #endregion Parent Relations
    }
}