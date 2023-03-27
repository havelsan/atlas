using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PatientExamination
    {
        public Guid ObjectId { get; set; }
        public bool? IsObservationTaken { get; set; }
        public bool? IsReportMHRSGreenList { get; set; }
        public bool? ReportedMHRSGreenList { get; set; }
        public bool? IsApproveMHRSGreenList { get; set; }
        public bool? ApprovedMHRSGreenList { get; set; }
        public DischargeTypeEnum? MTSDischargeType { get; set; }
        public DishargeToPlaceEnum? MTSDischargeToPlace { get; set; }
        public string MedulaESevkNo { get; set; }
        public string MedulaMutatDisiAracRaporNo { get; set; }
        public DateTime? MutatDisiAracRaporTarihi { get; set; }
        public DateTime? MutatDisiAracBaslangicTarihi { get; set; }
        public DateTime? MutatDisiAracBitisTarihi { get; set; }
        public string MutatDisiGerekcesi { get; set; }
        public string MedulaRefakatciGerekcesi { get; set; }
        public bool? MedulaRefakatciDurumu { get; set; }
        public long? MutatDisiAracRaporId { get; set; }
        public PatientExaminationEnum? PatientExaminationType { get; set; }
        public Guid? TreatmentResultRef { get; set; }
        public Guid? MuayeneGirisRef { get; set; }
        public Guid? MedulaSevkDonusVasitasiRef { get; set; }
        public Guid? MTSHospitalSendingToRef { get; set; }
        public Guid? DispatchedSpecialityRef { get; set; }
        public Guid? ResUserRef { get; set; }
        public Guid? EmergencyInterventionRef { get; set; }
        public Guid? ResponsibleDoctorRef { get; set; }
        public Guid? HCExaminationComponentRef { get; set; }

        #region Base Object Navigation Property
        public virtual PhysicianApplication PhysicianApplication { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResSection MTSHospitalSendingTo { get; set; }
        public virtual ResUser ResUser { get; set; }
        public virtual EmergencyIntervention EmergencyIntervention { get; set; }
        public virtual ResUser ResponsibleDoctor { get; set; }
        public virtual HCExaminationComponent HCExaminationComponent { get; set; }
        #endregion Parent Relations
    }
}