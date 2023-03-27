using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class RadiologyTest
    {
        public Guid ObjectId { get; set; }
        public string AdditionalRequest { get; set; }
        public string OwnerType { get; set; }
        public DateTime? TestDate { get; set; }
        public bool? IsMessageInPACS { get; set; }
        public ToothNumberEnum? TestToothNumber { get; set; }
        public int? DisTaahhutNo { get; set; }
        public bool? IsGunubirlikTakip { get; set; }
        public RadiologyBodyPositionEnum? BodyPosition { get; set; }
        public RadiologyBodySiteEnum? BodySite { get; set; }
        public bool? Check { get; set; }
        public string Description { get; set; }
        public string ReportTxt { get; set; }
        public DateTime? ReportDate { get; set; }
        public DateTime? RequestDate { get; set; }
        public string TechnicianNote { get; set; }
        public DentalPositionEnum? DentalPosition { get; set; }
        public bool? Anomali { get; set; }
        public bool? IsProcedureRepeated { get; set; }
        public string ToothNumber { get; set; }
        public string AccessionNo { get; set; }
        public string birim { get; set; }
        public Guid? Report { get; set; }
        public bool? IsResultSeen { get; set; }
        public Guid? PreDiagnosis { get; set; }
        public string GeneralDescription { get; set; }
        public Guid? PhysicalExamination { get; set; }
        public Guid? PatientHistory { get; set; }
        public Guid? Complaint { get; set; }
        public Guid? MTSConclusion { get; set; }
        public bool? IsMessageInTELETIP { get; set; }
        public string ACKMessagePACS { get; set; }
        public string ACKMessageTELETIP { get; set; }
        public ImageQualityAssesmentEnum? ImageQualityAssesment { get; set; }
        public Guid? RadiographyTechnique { get; set; }
        public Guid? ComparisonInfo { get; set; }
        public Guid? Results { get; set; }
        public bool? IsMessageInExternalHIS { get; set; }
        public string ACKMessageExternalHIS { get; set; }
        public RequestReasonAssesment? RequestReasonAssesment { get; set; }
        public RadiologyContrastTypeEnum? ContrastType { get; set; }
        public Guid? ReportedByRef { get; set; }
        public Guid? ApprovedByRef { get; set; }
        public Guid? RejectReasonRef { get; set; }
        public Guid? RepeatReasonRef { get; set; }
        public Guid? EquipmentRef { get; set; }
        public Guid? ResUserRef { get; set; }
        public Guid? OzelDurumRef { get; set; }
        public Guid? AyniFarkliKesiRef { get; set; }
        public Guid? SagSolRef { get; set; }
        public Guid? RadiologyAdditionalReportRef { get; set; }

        #region Base Object Navigation Property
        public virtual SubactionProcedureFlowable SubactionProcedureFlowable { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser ReportedBy { get; set; }
        public virtual ResUser ApprovedBy { get; set; }
        public virtual ResUser ResUser { get; set; }
        public virtual OzelDurum OzelDurum { get; set; }
        #endregion Parent Relations
    }
}