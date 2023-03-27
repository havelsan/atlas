using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class EmergencyIntervention
    {
        public Guid ObjectId { get; set; }
        public Guid? PatientHistoryDescription { get; set; }
        public string BringerAddress { get; set; }
        public string BringerPhone { get; set; }
        public Guid? ContinuousDrugs { get; set; }
        public Guid? Habits { get; set; }
        public string PatientHistory { get; set; }
        public string BringerName { get; set; }
        public Guid? Picture { get; set; }
        public bool? IsTraumaticPatient { get; set; }
        public DateTime? EnteranceTime { get; set; }
        public Guid? InPatientFolder { get; set; }
        public bool? IsEmergencyInjured { get; set; }
        public bool? IsEmergencyDispatched { get; set; }
        public DateTime? DischargeTime { get; set; }
        public bool? IsPatientApprovalFormGiven { get; set; }
        public string LastEatingInfo { get; set; }
        public int? AlcoholPromile { get; set; }
        public bool? TetanusVaccine { get; set; }
        public string Complaint { get; set; }
        public long? ProtocolNo { get; set; }
        public Guid? ComplaintDescription { get; set; }
        public string ComplaintDuration { get; set; }
        public DateTime? InpatientObservationTime { get; set; }
        public bool? IsPregnant { get; set; }
        public DateTime? LastMenstrualPeriod { get; set; }
        public Guid? AllergyDescription { get; set; }
        public DateTime? InterventionStartTime { get; set; }
        public DateTime? InterventionEndTime { get; set; }
        public Guid? ResponsibleNurseRef { get; set; }
        public Guid? MuayeneGirisRef { get; set; }
        public Guid? ResponsibleDoctorRef { get; set; }
        public Guid? ImportantMedicalInformationRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser ResponsibleNurse { get; set; }
        public virtual ResUser ResponsibleDoctor { get; set; }
        #endregion Parent Relations
    }
}