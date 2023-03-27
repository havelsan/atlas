using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseInpatientAdmission
    {
        public Guid ObjectId { get; set; }
        public string ReasonForInpatientAdmission { get; set; }
        public bool? NoCupboard { get; set; }
        public string GivenAndTakenStatus { get; set; }
        public DateTime? RiskWarningLastSeenDate { get; set; }
        public bool? NeedCompanion { get; set; }
        public bool? HasTightContactIsolation { get; set; }
        public int? EstimatedInpatientDateCount { get; set; }
        public DateTime? EstimatedDischargeDate { get; set; }
        public DateTime? EstimatedInpatientDate { get; set; }
        public bool? HasFallingRisk { get; set; }
        public bool? HasDropletIsolation { get; set; }
        public bool? HasContactIsolation { get; set; }
        public bool? HasAirborneContactIsolation { get; set; }
        public DateTime? HospitalDischargeDate { get; set; }
        public DateTime? HospitalInPatientDate { get; set; }
        public Guid? RoomRef { get; set; }
        public Guid? PhysicalStateClinicRef { get; set; }
        public Guid? BedRef { get; set; }
        public Guid? RoomGroupRef { get; set; }
        public Guid? TreatmentClinicRef { get; set; }
        public Guid? InpatientReasonRef { get; set; }
        public Guid? EpisodeFolderRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResRoom Room { get; set; }
        public virtual ResWard PhysicalStateClinic { get; set; }
        public virtual ResBed Bed { get; set; }
        public virtual ResRoomGroup RoomGroup { get; set; }
        public virtual ResClinic TreatmentClinic { get; set; }
        public virtual EpisodeFolder EpisodeFolder { get; set; }
        #endregion Parent Relations
    }
}