using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PackageTemplateProcedureDefinition
    {
        public Guid ObjectId { get; set; }
        public Guid? PackageTemplateDefinitionRef { get; set; }
        public Guid? ProcedureDefinitionRef { get; set; }

        #region Parent Relations
        public virtual PackageTemplateDefinition PackageTemplateDefinition { get; set; }
        public virtual ProcedureDefinition ProcedureDefinition { get; set; }
        #endregion Parent Relations
    }
}