using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class TigEpisode
    {
        public Guid ObjectId { get; set; }
        public Guid? ResourceGuid { get; set; }
        public DateTime? DischargeDate { get; set; }
        public Guid? DoctorGuid { get; set; }
        public Guid? DischargerDoctorGuid { get; set; }
        public Guid? BranchGuid { get; set; }
        public bool? AppointmentStatus { get; set; }
        public bool? EpicrisisStatus { get; set; }
        public bool? PathologyRequestStatus { get; set; }
        public bool? PathologyReportStatus { get; set; }
        public bool? InvoiceStatus { get; set; }
        public bool? Cancelled { get; set; }
        public DateTime? InpatientDate { get; set; }
        public TIGPatientTypeEnum? PatientType { get; set; }
        public string InPatientProtocolNo { get; set; }
        public string Surgeries { get; set; }
        public bool? XMLStatus { get; set; }
        public DateTime? XMLCreationDate { get; set; }
        public bool? CodingStatus { get; set; }
        public DateTime? CodingDate { get; set; }
        public string Description { get; set; }
        public Guid? EpisodeGuid { get; set; }
        public Guid? PatientGuid { get; set; }
        public Guid? SEPGuid { get; set; }
    }
}