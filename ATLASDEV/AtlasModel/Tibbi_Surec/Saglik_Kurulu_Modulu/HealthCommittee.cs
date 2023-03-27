using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class HealthCommittee
    {
        public Guid ObjectId { get; set; }
        public DateTime? HealthCommitteeStartDate { get; set; }
        public bool? AutomaticallyCreated { get; set; }
        public long? ReportNo { get; set; }
        public string BodyMassIndex { get; set; }
        public long? ProtocolNo { get; set; }
        public long? BookNumber { get; set; }
        public int? ClinicWeight { get; set; }
        public LargeMajorityUnanimityEnum? Unanimity { get; set; }
        public string BookCategory { get; set; }
        public double? HCHeight { get; set; }
        public double? ClinicHeight { get; set; }
        public DateTime? ReportDate { get; set; }
        public string DocumentNumber { get; set; }
        public int? NumberOfProcedure { get; set; }
        public DateTime? DocumentDate { get; set; }
        public Guid? TargetObjectID { get; set; }
        public Guid? SourceObjectID { get; set; }
        public string MessageID { get; set; }
        public string AppointmentInfo { get; set; }
        public Guid? Report { get; set; }
        public PositiveNegativeEnum? Ration { get; set; }
        public string PreDiagnosis { get; set; }
        public DateTime? NasbiTarihi { get; set; }
        public WhoPaysEnum? WhoPays { get; set; }
        public int? HCDecisionTime { get; set; }
        public UnitOfTimeEnum? HCDecisionUnitOfTime { get; set; }
        public Guid? DecisionOffer { get; set; }
        public HCCommitteeAcceptanceStatus? CommitteeAcceptanceStatus { get; set; }
        public DateTime? DateOfExit { get; set; }
        public double? HCWeight { get; set; }
        public bool? UnsuitableForMilitaryService { get; set; }
        public double? FunctionRatio { get; set; }
        public DateTime? IncomingDocumentDate { get; set; }
        public string IncomingDocumentNo { get; set; }
        public string IncomingReportNo { get; set; }
        public string Definition { get; set; }
        public string UnworkField { get; set; }
        public Guid? ReportDiagnose { get; set; }
        public string QulityOfUnemployableWorks { get; set; }
        public bool? IsHeavyDisabled { get; set; }
        public SendExaminationEnum? SendExamination { get; set; }
        public Guid? HCReoprtDecision { get; set; }
        public Guid? HealthCommitteeDecision { get; set; }
        public string ClinicalFindings { get; set; }
        public DegreeOfBloodRelativesEnum? DegreeOfBloodRelatives { get; set; }
        public long? UniqueRefReceiveReport { get; set; }
        public string NameSurnameReceiveReport { get; set; }
        public Guid? DepartmentRef { get; set; }
        public Guid? ExaminationUnitsHospitalsRef { get; set; }
        public Guid? DoctorRef { get; set; }
        public Guid? GroupNoRef { get; set; }
        public Guid? RequesterRef { get; set; }
        public Guid? IntendedUseOfDisabledReportRef { get; set; }
        public Guid? HCDutyTypeRef { get; set; }
        public Guid? AircraftTypeRef { get; set; }
        public Guid? HCRequestReasonRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseHealthCommittee BaseHealthCommittee { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResSection Department { get; set; }
        public virtual ResClinic ExaminationUnitsHospitals { get; set; }
        public virtual ResUser Doctor { get; set; }
        public virtual ResUser Requester { get; set; }
        public virtual IntendedUseOfDisabledReport IntendedUseOfDisabledReport { get; set; }
        public virtual HCRequestReason HCRequestReason { get; set; }
        #endregion Parent Relations
    }
}