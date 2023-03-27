using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DiagnosisDefTeshis
    {
        public Guid ObjectId { get; set; }
        public Guid? TeshisRef { get; set; }
        public Guid? DiagnosisDefinitionRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual DiagnosisDefinition DiagnosisDefinition { get; set; }
        #endregion Parent Relations
    }
}