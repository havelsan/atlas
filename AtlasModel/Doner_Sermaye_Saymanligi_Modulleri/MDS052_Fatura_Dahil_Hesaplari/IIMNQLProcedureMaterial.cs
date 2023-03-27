using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class IIMNQLProcedureMaterial
    {
        public Guid ObjectId { get; set; }
        public InvoiceInclusionResultEnum? Result { get; set; }
        public Guid? InvoiceInclusionMasterRef { get; set; }
        public Guid? ProcedureDefinitionRef { get; set; }
        public Guid? InvoiceInclusionNQLRef { get; set; }

        #region Parent Relations
        public virtual InvoiceInclusionMaster InvoiceInclusionMaster { get; set; }
        public virtual ProcedureDefinition ProcedureDefinition { get; set; }
        public virtual InvoiceInclusionNQL InvoiceInclusionNQL { get; set; }
        #endregion Parent Relations
    }
}