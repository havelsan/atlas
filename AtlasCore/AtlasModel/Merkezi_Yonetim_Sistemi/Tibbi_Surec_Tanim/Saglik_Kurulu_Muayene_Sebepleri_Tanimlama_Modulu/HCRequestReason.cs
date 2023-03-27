using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class HCRequestReason
    {
        public Guid ObjectId { get; set; }
        public string ReasonName { get; set; }
        public HCEDynamicReportTypeEnum? HCEReportType { get; set; }
        public Guid? ReasonForExaminationRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ReasonForExaminationDefinition ReasonForExamination { get; set; }
        #endregion Parent Relations
    }
}