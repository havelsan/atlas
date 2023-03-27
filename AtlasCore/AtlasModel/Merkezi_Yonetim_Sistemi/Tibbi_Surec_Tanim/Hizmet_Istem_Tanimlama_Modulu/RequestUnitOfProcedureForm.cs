using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class RequestUnitOfProcedureForm
    {
        public Guid ObjectId { get; set; }
        public Guid? ProcedureRequestFormDefRef { get; set; }
        public Guid? ResourceRef { get; set; }

        #region Parent Relations
        public virtual ProcedureRequestFormDefinition ProcedureRequestFormDef { get; set; }
        public virtual Resource Resource { get; set; }
        #endregion Parent Relations
    }
}