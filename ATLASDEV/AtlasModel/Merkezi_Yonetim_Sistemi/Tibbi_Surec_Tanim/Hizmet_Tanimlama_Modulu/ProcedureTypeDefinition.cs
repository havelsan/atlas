using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ProcedureTypeDefinition
    {
        public Guid ObjectId { get; set; }
        public string ProcedureTypeName_Shadow { get; set; }
        public string Code { get; set; }
        public string ProcedureTypeName { get; set; }
        public Guid? ParentProcedureTypeRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ProcedureTypeDefinition ParentProcedureType { get; set; }
        #endregion Parent Relations
    }
}