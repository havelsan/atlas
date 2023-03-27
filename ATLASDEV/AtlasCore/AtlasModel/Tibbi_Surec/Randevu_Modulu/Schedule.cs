using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Schedule
    {
        public Guid ObjectId { get; set; }
        public int? Duration { get; set; }
        public ScheduleTypeEnum? ScheduleType { get; set; }
        public string Notes { get; set; }
        public string RecurrenceID { get; set; }
        public int? CountLimit { get; set; }
        public bool? IsWorkHour { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public DateTime? StartTime { get; set; }
        public string MHRSTaslakCetvelID { get; set; }
        public long? MHRSKesinCetvelID { get; set; }
        public bool? SentToMHRS { get; set; }
        public long? MHRSIstisnaID { get; set; }
        public MHRSScheduleTypeEnum? MHRSScheduleType { get; set; }
        public string ErrorOfMHRSApprove { get; set; }
        public Guid? MasterScheduleRef { get; set; }
        public Guid? ResourceRef { get; set; }
        public Guid? AppointmentDefinitionRef { get; set; }
        public Guid? MasterResourceRef { get; set; }
        public Guid? MHRSActionTypeDefinitionRef { get; set; }

        #region Parent Relations
        public virtual Schedule MasterSchedule { get; set; }
        public virtual Resource Resource { get; set; }
        public virtual AppointmentDefinition AppointmentDefinition { get; set; }
        public virtual Resource MasterResource { get; set; }
        public virtual MHRSActionTypeDefinition MHRSActionTypeDefinition { get; set; }
        #endregion Parent Relations
    }
}