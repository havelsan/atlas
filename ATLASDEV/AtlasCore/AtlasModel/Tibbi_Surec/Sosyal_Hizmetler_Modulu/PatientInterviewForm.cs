using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PatientInterviewForm
    {
        public Guid ObjectId { get; set; }
        public string InterviewPlace { get; set; }
        public string InterviewedContacts { get; set; }
        public string ProblemDefinition { get; set; }
        public string MeetingReason { get; set; }
        public string PatientHealthPhysicalCond { get; set; }
        public string PatientPhoneNum { get; set; }
        public string PatientAddress { get; set; }
        public string PatientPsychosocialFamilyCond { get; set; }
        public string PatientAccomodationEcoCon { get; set; }
        public string Evaluation { get; set; }
        public string ResultsAndRecommendations { get; set; }
        public TypeOfServicesEnum? TypeOfService { get; set; }
        public DateTime? ExaminationDate { get; set; }
        public PatientTypeEnum? PatientType { get; set; }
        public bool? PsychosocialStudyWithPatient { get; set; }
        public bool? PsychosocialStudyPatFamily { get; set; }
        public bool? SocialReviewAndEvolution { get; set; }
        public bool? HomeOrOrganizationVisit { get; set; }
        public bool? WorkplaceVisit { get; set; }
        public bool? SchoolVisit { get; set; }
        public bool? InstutionalCarePlacement { get; set; }
        public bool? PlacementInTemporaryShelters { get; set; }
        public bool? GoodsAndMoneyHelp { get; set; }
        public bool? TreatmentExpenseResourceRoute { get; set; }
        public bool? PatientsGroupStudy { get; set; }
        public bool? GroupStudyWithPatientFamily { get; set; }
        public bool? PatientEducationAndWorkStudy { get; set; }
        public bool? PatientTransferervice { get; set; }
        public bool? PsychosocialEduPatientFamily { get; set; }
        public bool? SocialActivity { get; set; }
        public bool? OtherVocationalInterventions { get; set; }
        public MaritalStatusEnum? MaritalStatus { get; set; }
        public Guid? PhysicianApplicationRef { get; set; }
        public Guid? RequestedByRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual PhysicianApplication PhysicianApplication { get; set; }
        public virtual ResUser RequestedBy { get; set; }
        #endregion Parent Relations
    }
}