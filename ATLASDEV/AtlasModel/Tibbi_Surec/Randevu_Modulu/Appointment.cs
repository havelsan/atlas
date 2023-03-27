using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Appointment
    {
        public Guid ObjectId { get; set; }
        public string StateID { get; set; }
        public long? AppointmentID { get; set; }
        public string Notes { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? AppDate { get; set; }
        public bool? BreakAppointment { get; set; }
        public AppointmentTypeEnum? AppointmentType { get; set; }
        public bool? GivingType { get; set; }
        public bool? IsNumarator { get; set; }
        public string MHRSRandevuHrn { get; set; }
        public bool? IsCancelledByMHRSIstisna { get; set; }
        public bool? AppointmentUpdate { get; set; }
        public bool? MHRSHastaGeldi { get; set; }
        public bool? CancelledMHRS { get; set; }
        public string AppViewerState { get; set; }
        public string InitialObjectID { get; set; }
        public string ExternalAppointmentID { get; set; }
        public Guid? SubActionProcedureRef { get; set; }
        public Guid? AppointmentDefinitionRef { get; set; }
        public Guid? AppointmentCarrierRef { get; set; }
        public Guid? ActionRef { get; set; }
        public Guid? MasterResourceRef { get; set; }
        public Guid? MasterAppointmentsRef { get; set; }
        public Guid? ScheduleRef { get; set; }
        public Guid? GivenByRef { get; set; }
        public Guid? PatientRef { get; set; }
        public Guid? ResourceRef { get; set; }
        public Guid? EpisodeActionRef { get; set; }
        public Guid? ResEquipmentAppointmentRef { get; set; }

        #region Parent Relations
        public virtual SubActionProcedure SubActionProcedure { get; set; }
        public virtual AppointmentDefinition AppointmentDefinition { get; set; }
        public virtual AppointmentCarrier AppointmentCarrier { get; set; }
        public virtual BaseAction Action { get; set; }
        public virtual Resource MasterResource { get; set; }
        public virtual Appointment MasterAppointments { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual ResUser GivenBy { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Resource Resource { get; set; }
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Parent Relations
    }
}