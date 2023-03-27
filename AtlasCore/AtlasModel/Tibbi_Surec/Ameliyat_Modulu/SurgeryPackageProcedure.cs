using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SurgeryPackageProcedure
    {
        public Guid ObjectId { get; set; }
        public Guid? SurgeryRef { get; set; }
        public Guid? PackageProcedureDefinitionRef { get; set; }
        public Guid? SurgeryProcedureRef { get; set; }

        #region Base Object Navigation Property
        public virtual SubActionPackageProcedure SubActionPackageProcedure { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual Surgery Surgery { get; set; }
        public virtual PackageProcedureDefinition PackageProcedureDefinition { get; set; }
        public virtual SurgeryProcedure SurgeryProcedure { get; set; }
        #endregion Parent Relations
    }
}