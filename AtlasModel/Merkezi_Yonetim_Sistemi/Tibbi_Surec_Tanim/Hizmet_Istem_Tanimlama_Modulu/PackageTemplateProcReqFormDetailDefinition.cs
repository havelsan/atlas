using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PackageTemplateProcReqFormDetailDefinition
    {
        public Guid ObjectId { get; set; }
        public Guid? ProcedureReqFormDetailDefRef { get; set; }
        public Guid? PackageTemplateDefinitionRef { get; set; }

        #region Parent Relations
        public virtual ProcedureRequestFormDetailDefinition ProcedureReqFormDetailDef { get; set; }
        public virtual PackageTemplateDefinition PackageTemplateDefinition { get; set; }
        #endregion Parent Relations
    }
}