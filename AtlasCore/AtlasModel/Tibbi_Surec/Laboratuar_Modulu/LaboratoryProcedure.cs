using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class LaboratoryProcedure
    {
        public Guid ObjectId { get; set; }
        public DateTime? TechnicianApproveDate { get; set; }
        public string Reference { get; set; }
        public HighLowEnum? Warning { get; set; }
        public string Result { get; set; }
        public bool? Check { get; set; }
        public string Description { get; set; }
        public string TechnicianID { get; set; }
        public string OwnerType { get; set; }
        public string Unit { get; set; }
        public long? BarcodeId { get; set; }
        public bool? IsAntibiogram { get; set; }
        public DateTime? ResultDate { get; set; }
        public Guid? LongReport { get; set; }
        public bool? MicrobiologyPanicNotification { get; set; }
        public LaboratoryAbnormalFlagsEnum? Panic { get; set; }
        public string TestGroup { get; set; }
        public string Environment { get; set; }
        public string drAnesteziTescilNo { get; set; }
        public DateTime? AcceptDate { get; set; }
        public DateTime? ApproveDate { get; set; }
        public DateTime? ProcedureDate { get; set; }
        public string ResultDescription { get; set; }
        public string ProcessNote { get; set; }
        public Guid? Report { get; set; }
        public DateTime? RequestDate { get; set; }
        public string RequestNote { get; set; }
        public DateTime? SampleAcceptionDate { get; set; }
        public DateTime? SampleDate { get; set; }
        public Guid? SpecialReference { get; set; }
        public string Techniciannote { get; set; }
        public Guid? TestDefID { get; set; }
        public bool? IsResultSeen { get; set; }
        public long? SpecimenId { get; set; }
        public Guid? DepartmentRef { get; set; }
        public Guid? MasterTestDefRef { get; set; }
        public Guid? TubeInformationRef { get; set; }
        public Guid? AcceptUserRef { get; set; }
        public Guid? ProcedureDepartmentRef { get; set; }
        public Guid? ProcedureUserRef { get; set; }
        public Guid? AcceptResourceRef { get; set; }
        public Guid? EquipmentRef { get; set; }
        public Guid? RequestedTabRef { get; set; }
        public Guid? AyniFarkliKesiRef { get; set; }
        public Guid? SagSolRef { get; set; }
        public Guid? SampleRejectionReasonRef { get; set; }
        public Guid? AnesteziDoktorRef { get; set; }
        public Guid? OzelDurumRef { get; set; }
        public Guid? UserOfSampleRejectionRef { get; set; }
        public Guid? RequestResourceRef { get; set; }
        public Guid? RequestUserRef { get; set; }
        public Guid? SampleResourceRef { get; set; }
        public Guid? SampleUserRef { get; set; }
        public Guid? ApproveUserRef { get; set; }

        #region Base Object Navigation Property
        public virtual SubactionProcedureFlowable SubactionProcedureFlowable { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual LaboratoryTestDefinition MasterTestDef { get; set; }
        public virtual LaboratoryProcedureTubeInfo TubeInformation { get; set; }
        public virtual ResUser AcceptUser { get; set; }
        public virtual Resource ProcedureDepartment { get; set; }
        public virtual ResUser ProcedureUser { get; set; }
        public virtual Resource AcceptResource { get; set; }
        public virtual ResUser AnesteziDoktor { get; set; }
        public virtual OzelDurum OzelDurum { get; set; }
        public virtual ResUser UserOfSampleRejection { get; set; }
        public virtual Resource RequestResource { get; set; }
        public virtual ResUser RequestUser { get; set; }
        public virtual Resource SampleResource { get; set; }
        public virtual ResUser SampleUser { get; set; }
        public virtual ResUser ApproveUser { get; set; }
        #endregion Parent Relations
    }
}