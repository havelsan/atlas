using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InPatientTreatmentClinicApplication
    {
        public Guid ObjectId { get; set; }
        public DateTime? ClinicDischargeDate { get; set; }
        public DateTime? ClinicInpatientDate { get; set; }
        public long? ProtocolNo { get; set; }
        public bool? MedulaHastaCikisKayitFailed { get; set; }
        public bool? IsDailyOperation { get; set; }
        public Guid? ShotInpatientReason { get; set; }
        public InpatientAcceptionTypeEnum? InpatientAcceptionType { get; set; }
        public Guid? LongInpatientReason { get; set; }
        public Guid? ResponsibleNurseRef { get; set; }
        public Guid? BaseInpatientAdmissionRef { get; set; }
        public Guid? TreatmentDischargeRef { get; set; }
        public Guid? FromInPatientTrtmentClinicAppRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser ResponsibleNurse { get; set; }
        public virtual BaseInpatientAdmission BaseInpatientAdmission { get; set; }
        public virtual TreatmentDischarge TreatmentDischarge { get; set; }
        public virtual InPatientTreatmentClinicApplication FromInPatientTrtmentClinicApp { get; set; }
        #endregion Parent Relations
    }
}