using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ExaminationQueueItem
    {
        public Guid ObjectId { get; set; }
        public string PriorityReason { get; set; }
        public bool? IsEmergency { get; set; }
        public int? CallCount { get; set; }
        public DateTime? QueueDate { get; set; }
        public long? NextItemsCount { get; set; }
        public DateTime? CallTime { get; set; }
        public DateTime? DivertedTime { get; set; }
        public long? Priority { get; set; }
        public bool? IsResultExamination { get; set; }
        public string OrderNo { get; set; }
        public Guid? DestinationResourceRef { get; set; }
        public Guid? EpisodeActionRef { get; set; }
        public Guid? ExaminationQueueDefinitionRef { get; set; }
        public Guid? DoctorRef { get; set; }
        public Guid? AppointmentRef { get; set; }
        public Guid? PatientRef { get; set; }
        public Guid? SubactionProcedureFlowableRef { get; set; }
        public Guid? CompletedByRef { get; set; }

        #region Parent Relations
        public virtual Resource DestinationResource { get; set; }
        public virtual EpisodeAction EpisodeAction { get; set; }
        public virtual ExaminationQueueDefinition ExaminationQueueDefinition { get; set; }
        public virtual ResUser Doctor { get; set; }
        public virtual Appointment Appointment { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual SubactionProcedureFlowable SubactionProcedureFlowable { get; set; }
        public virtual ResUser CompletedBy { get; set; }
        #endregion Parent Relations
    }
}