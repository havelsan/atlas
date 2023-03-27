using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ForensicMedicalReport
    {
        public Guid ObjectId { get; set; }
        public long? ReportNo { get; set; }
        public Guid? Report { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string DocumentNumber { get; set; }
        public long? ProtocolNo { get; set; }
        public string Attaches5 { get; set; }
        public bool? Attaches3 { get; set; }
        public bool? Attaches4 { get; set; }
        public bool? NoNeed { get; set; }
        public bool? Need { get; set; }
        public ReasonExaminationTypeEnum? ReasonExaminationReportType { get; set; }
        public bool? PsychiatricConsultation { get; set; }
        public bool? Attaches1 { get; set; }
        public bool? Attaches2 { get; set; }
        public string ArterialBloodPresure { get; set; }
        public string Pulse { get; set; }
        public bool? HeadNeck { get; set; }
        public bool? Chest { get; set; }
        public bool? Abdominal { get; set; }
        public bool? Back { get; set; }
        public bool? UpperExtrimity { get; set; }
        public bool? LowerExtremity { get; set; }
        public bool? GenitalArea { get; set; }
        public PemissionDepartmentEnum? PermissionDepartment { get; set; }
        public SexEnum? Sex { get; set; }
        public string ResonOfDispatch { get; set; }
        public string Explanation1 { get; set; }
        public string Explanation2 { get; set; }
        public string PropertiesOfLesions { get; set; }
        public string SystemFindings { get; set; }
        public string OtherReasonExamination { get; set; }
        public string PatientIdentity { get; set; }
        public string HistoryOfEvent { get; set; }
        public string PatientComplaints { get; set; }
        public string MedicalHistory { get; set; }
        public string ConsultationRequested { get; set; }
        public Guid? ReportImage { get; set; }
        public RespitoryEnum? Respitory { get; set; }
        public bool? CentralNervousSystem { get; set; }
        public bool? CardiovascularSystem { get; set; }
        public bool? RespiratorySys { get; set; }
        public bool? UrogenitalSys { get; set; }
        public bool? SkeletalSys { get; set; }
        public bool? SensoryOrgansSys { get; set; }
        public bool? DigestiveSys { get; set; }
        public GeneralConditionOfPatientEnum? GeneralConditionOfPatient { get; set; }
        public Guid? LaboratoryProcedures { get; set; }
        public AwarenessEnum? Awareness { get; set; }
        public PupilPropertiesEnum? PupilProperties { get; set; }
        public LightReflexEnum? LightReflex { get; set; }
        public TendonReflexesEnum? TendonReflexes { get; set; }
        public bool? NoEvidancePsycho { get; set; }
        public bool? PyschiatricExamination { get; set; }
        public DateTime? ExaminationDate { get; set; }
        public string AttendantNameSurname { get; set; }
        public bool? SuitableEnvironment1 { get; set; }
        public bool? SuitableEnvironment2 { get; set; }
        public bool? PeopleInExamination1 { get; set; }
        public bool? PeopleInExamination2 { get; set; }
        public bool? PeopleInExamination3 { get; set; }
        public bool? PeopleInExamination4 { get; set; }
        public bool? ClothesOfPatient1 { get; set; }
        public bool? ClothesOfPatient2 { get; set; }
        public bool? ClothesOfPatient3 { get; set; }
        public bool? ChkLabProcedures { get; set; }
        public bool? ChkDirectGraph { get; set; }
        public bool? ChkBTMR { get; set; }
        public bool? ChkUltrasonography { get; set; }
        public bool? ChkBiopsy { get; set; }
        public bool? ChkOther { get; set; }
        public string Attaches2Text { get; set; }
        public string Attaches3Text1 { get; set; }
        public string Attaches3Text2 { get; set; }
        public bool? UncertainReport { get; set; }
        public bool? CertainReport { get; set; }
        public Guid? SenderChairRef { get; set; }
        public Guid? ResUserRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser ResUser { get; set; }
        #endregion Parent Relations
    }
}