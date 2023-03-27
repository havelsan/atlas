using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PackageTemplateICDDetailDefinition
    {
        public Guid ObjectId { get; set; }
        public string DiagnosisDefinition { get; set; }
        public string FreeDiagnosis { get; set; }
        public bool? IsMainDiagnose { get; set; }
        public DiagnosisTypeEnum? DiagnosisType { get; set; }
        public string TaniKodu { get; set; }
        public Guid? PackageTemplateDefinitionRef { get; set; }

        #region Parent Relations
        public virtual PackageTemplateDefinition PackageTemplateDefinition { get; set; }
        #endregion Parent Relations
    }
}