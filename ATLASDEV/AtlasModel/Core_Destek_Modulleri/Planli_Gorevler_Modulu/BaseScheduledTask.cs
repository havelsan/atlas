using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseScheduledTask
    {
        public Guid ObjectId { get; set; }
        public int? WorkHour { get; set; }
        public int? Recurrency { get; set; }
        public DateTime? LastExecutionDate { get; set; }
        public bool? NoEndDate { get; set; }
        public string TaskName { get; set; }
        public ScheduledTaskPeriodEnum? Period { get; set; }
        public bool? Active { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartDate { get; set; }
        public int? ExecutionCount { get; set; }
        public string CronExpression { get; set; }
        public int? WorkMinute { get; set; }
    }
}