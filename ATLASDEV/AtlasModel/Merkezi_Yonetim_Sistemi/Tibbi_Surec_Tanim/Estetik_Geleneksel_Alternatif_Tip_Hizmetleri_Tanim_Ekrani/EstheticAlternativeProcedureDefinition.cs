using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class EstheticAlternativeProcedureDefinition
    {
        public Guid ObjectId { get; set; }

        #region Base Object Navigation Property
        public virtual ProcedureDefinition ProcedureDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}