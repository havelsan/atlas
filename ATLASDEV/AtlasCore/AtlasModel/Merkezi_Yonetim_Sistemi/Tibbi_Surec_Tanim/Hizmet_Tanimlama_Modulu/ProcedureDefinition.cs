using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ProcedureDefinition
    {
        public Guid ObjectId { get; set; }
        public string Code { get; set; }
        public bool? Chargable { get; set; }
        public string EnglishName { get; set; }
        public long? ID { get; set; }
        public string Qref { get; set; }
        public string Description { get; set; }
        public SUTHizmetEKEnum? SUTAppendix { get; set; }
        public string Name { get; set; }
        public bool? OnamFormuIste { get; set; }
        public string Name_Shadow { get; set; }
        public bool? CreateInMedulaDontSendState { get; set; }
        public bool? PreProcedureEntryNecessity { get; set; }
        public MedulaSUTGroupEnum? MedulaProcedureType { get; set; }
        public MedulaRaporZorunluluguEnum? MedulaReportNecessity { get; set; }
        public bool? DailyMedulaProvisionNecessity { get; set; }
        public string GILCode { get; set; }
        public int? GILPoint { get; set; }
        public bool? DontBlockInvoice { get; set; }
        public string SUTCode { get; set; }
        public bool? QuickEntryAllowed { get; set; }
        public bool? ReportSelectionRequired { get; set; }
        public string ExternalId { get; set; }
        public bool? IsDescriptionNeeded { get; set; }
        public bool? ParticipationProcedure { get; set; }
        public string GILName { get; set; }
        public bool? RepetitionQueryNeeded { get; set; }
        public bool? IsResultNeeded { get; set; }
        public ProcedureDefGroupEnum? ProcedureType { get; set; }
        public bool? RightLeftInfoNeeded { get; set; }
        public bool? IsVisible { get; set; }
        public int? ControlDayCount { get; set; }
        public int? DailyDayCount { get; set; }
        public int? EmergencyDayCount { get; set; }
        public int? ExaminationDayCount { get; set; }
        public bool? ForbiddenForControl { get; set; }
        public bool? ForbiddenForDaily { get; set; }
        public bool? ForbiddenForEmergency { get; set; }
        public bool? ForbiddenForExamination { get; set; }
        public bool? ForbiddenForInpatient { get; set; }
        public string HUVCode { get; set; }
        public double? HUVPoint { get; set; }
        public double? SUTPoint { get; set; }
        public bool? ExternalOperation { get; set; }
        public bool? PathologyOperationNeeded { get; set; }
        public bool? QualifiedMedicalProcess { get; set; }
        public int? InpatientDayCount { get; set; }
        public Guid? MedulaProvisionTedaviTipiRef { get; set; }
        public Guid? RevenueSubAccountCodeRef { get; set; }
        public Guid? ProcedureTreeRef { get; set; }
        public Guid? OzelDurumRef { get; set; }
        public Guid? TedaviTipiRef { get; set; }
        public Guid? ProvizyonTipiRef { get; set; }
        public Guid? TakipTipiRef { get; set; }
        public Guid? PackageProcedureRef { get; set; }
        public Guid? DoctorRef { get; set; }
        public Guid? SKRSLoincKoduRef { get; set; }
        public Guid? GILDefinitionRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual RevenueSubAccountCodeDefinition RevenueSubAccountCode { get; set; }
        public virtual ProcedureTreeDefinition ProcedureTree { get; set; }
        public virtual OzelDurum OzelDurum { get; set; }
        public virtual PackageProcedureDefinition PackageProcedure { get; set; }
        public virtual ResUser Doctor { get; set; }
        #endregion Parent Relations
    }
}