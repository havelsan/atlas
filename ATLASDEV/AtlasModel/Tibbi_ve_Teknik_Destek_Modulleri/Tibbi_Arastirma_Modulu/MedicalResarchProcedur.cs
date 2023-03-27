using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MedicalResarchProcedur
    {
        public Guid ObjectId { get; set; }
        public Guid? ProcedureDefinitionRef { get; set; }
        public Guid? MedicalResarchRef { get; set; }

        #region Parent Relations
        public virtual ProcedureDefinition ProcedureDefinition { get; set; }
        public virtual MedicalResarch MedicalResarch { get; set; }
        #endregion Parent Relations
    }
}