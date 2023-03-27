using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class VitalSignAndNursingDefinition
    {
        public Guid ObjectId { get; set; }
        public bool? DontNeedDataDuringApplication { get; set; }
        public VitalSignType? VitalSignType { get; set; }

        #region Base Object Navigation Property
        public virtual ProcedureDefinition ProcedureDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}