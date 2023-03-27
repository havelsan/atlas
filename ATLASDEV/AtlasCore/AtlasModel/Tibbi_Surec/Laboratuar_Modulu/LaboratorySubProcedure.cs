using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class LaboratorySubProcedure
    {
        public Guid ObjectId { get; set; }
        public string Result { get; set; }
        public bool? Check { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public string Reference { get; set; }
        public HighLowEnum? Warning { get; set; }
        public Guid? LabProcedureID { get; set; }
        public bool? MicrobiologyPanicNotification { get; set; }
        public HighLowEnum? Panic { get; set; }
        public DateTime? AcceptDate { get; set; }
        public DateTime? ApproveDate { get; set; }
        public DateTime? ProcedureDate { get; set; }
        public Guid? LongReport { get; set; }
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
        public Guid? DepartmentRef { get; set; }
        public Guid? EquipmentRef { get; set; }
        public Guid? AcceptResourceRef { get; set; }
        public Guid? AcceptUserRef { get; set; }
        public Guid? ProcedureDepartmentRef { get; set; }
        public Guid? ProcedureUserRef { get; set; }
        public Guid? RequestResourceRef { get; set; }
        public Guid? RequestUserRef { get; set; }
        public Guid? SampleResourceRef { get; set; }
        public Guid? SampleUserRef { get; set; }

        #region Base Object Navigation Property
        public virtual SubactionProcedureFlowable SubactionProcedureFlowable { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser AcceptResource { get; set; }
        public virtual ResUser AcceptUser { get; set; }
        public virtual Resource ProcedureDepartment { get; set; }
        public virtual ResUser ProcedureUser { get; set; }
        public virtual Resource RequestResource { get; set; }
        public virtual ResUser RequestUser { get; set; }
        public virtual Resource SampleResource { get; set; }
        public virtual ResUser SampleUser { get; set; }
        #endregion Parent Relations
    }
}