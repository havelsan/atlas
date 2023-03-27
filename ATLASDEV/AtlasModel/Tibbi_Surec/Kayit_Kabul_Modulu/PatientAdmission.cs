using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PatientAdmission
    {
        public Guid ObjectId { get; set; }
        public string Email { get; set; }
        public DispatchTypeEnum? DispatchType { get; set; }
        public bool? IsFiresFromPACorrection { get; set; }
        public bool? IsCorrected { get; set; }
        public string ProvisionNo { get; set; }
        public string DocumentNumber { get; set; }
        public bool? Arrested { get; set; }
        public DateTime? DocumentDate { get; set; }
        public AdmissionStatusEnum? AdmissionStatus { get; set; }
        public WhoPaysEnum? HCModeOfPayment { get; set; }
        public bool? RealDisabled { get; set; }
        public bool? Sevkli { get; set; }
        public string takipAlCevap { get; set; }
        public string takipAlHataMesaji { get; set; }
        public string MedulaESevkNo { get; set; }
        public string RelatedProvision { get; set; }
        public bool? Donor { get; set; }
        public string DispatchedConsultationDef { get; set; }
        public PAStatusEnum? PAStatus { get; set; }
        public bool? IsNewBorn { get; set; }
        public bool? Sevkli112 { get; set; }
        public string Emergency112RefNo { get; set; }
        public Guid? ImportantPAInfo { get; set; }
        public long? ResultQueueNumber { get; set; }
        public bool? DispatchEmergencyCons { get; set; }
        public string BeneficiaryName { get; set; }
        public long? BeneficiaryUniqueRefNo { get; set; }
        public bool? DeathApplication { get; set; }
        public long? AdmissionQueueNumber { get; set; }
        public PatientClassTypeEnum? PatientClassGroup { get; set; }
        public ApplicationReasonEnum? ApplicationReason { get; set; }
        public DateTime? MedulaVakaTarihi { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid? EpisodeRef { get; set; }
        public Guid? RecordUserIDRef { get; set; }
        public Guid? ProtocolRef { get; set; }
        public Guid? HCRequestReasonRef { get; set; }
        public Guid? PayerRef { get; set; }
        public Guid? SKRSOlayAfetBilgisiRef { get; set; }
        public Guid? SKRSVatandasTipiRef { get; set; }
        public Guid? PriorityStatusRef { get; set; }
        public Guid? MedulaSigortaliTuruRef { get; set; }
        public Guid? PA_AddressRef { get; set; }
        public Guid? AdmissionAppointmentRef { get; set; }
        public Guid? BuildingRef { get; set; }
        public Guid? PoliclinicRef { get; set; }
        public Guid? PatientMedulaHastaKabulRef { get; set; }
        public Guid? ProvisionRequestRef { get; set; }
        public Guid? SKRSVakaTuruRef { get; set; }
        public Guid? DepartmentRef { get; set; }
        public Guid? ProcedureDoctorRef { get; set; }
        public Guid? EmergencyInterventionRef { get; set; }
        public Guid? OldTriageRef { get; set; }
        public Guid? TriageRef { get; set; }
        public Guid? MedulaIstisnaiHalRef { get; set; }
        public Guid? SKRSAdliVakaRef { get; set; }
        public Guid? EDisabledReportRef { get; set; }
        public Guid? EStatusNotRepCommitteeObjRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAction BaseAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual Episode Episode { get; set; }
        public virtual ResUser RecordUserID { get; set; }
        public virtual HCRequestReason HCRequestReason { get; set; }
        public virtual PayerDefinition Payer { get; set; }
        public virtual SKRSOlayAfetBilgisi SKRSOlayAfetBilgisi { get; set; }
        public virtual PatientIdentityAndAddress PA_Address { get; set; }
        public virtual AdmissionAppointment AdmissionAppointment { get; set; }
        public virtual ResPoliclinic Policlinic { get; set; }
        public virtual ResDepartment Department { get; set; }
        public virtual ResUser ProcedureDoctor { get; set; }
        public virtual EmergencyIntervention EmergencyIntervention { get; set; }
        public virtual EDisabledReport EDisabledReport { get; set; }
        public virtual EStatusNotRepCommitteeObj EStatusNotRepCommitteeObj { get; set; }
        #endregion Parent Relations
    }
}