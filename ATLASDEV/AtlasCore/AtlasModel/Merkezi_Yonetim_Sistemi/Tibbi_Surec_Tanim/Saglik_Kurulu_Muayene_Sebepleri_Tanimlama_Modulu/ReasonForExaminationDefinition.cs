using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ReasonForExaminationDefinition
    {
        public Guid ObjectId { get; set; }
        public string Reason { get; set; }
        public ReasonForExaminationTypeEnum? ReasonForExaminationType { get; set; }
        public long? Code { get; set; }
        public bool? IsForcedDiagnosis { get; set; }
        public bool? IsPrintReportBeforeExam { get; set; }
        public bool? IsPoliclinicAllowedReport { get; set; }
        public int? ControlTime { get; set; }
        public UnitOfTimeEnum? ControlUnitOfTime { get; set; }
        public Guid? PackageProcedureRef { get; set; }
        public Guid? HCReportTypeDefinitionRef { get; set; }
        public Guid? MemberOfHealthCommitteeRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual PackageProcedureDefinition PackageProcedure { get; set; }
        #endregion Parent Relations
    }
}