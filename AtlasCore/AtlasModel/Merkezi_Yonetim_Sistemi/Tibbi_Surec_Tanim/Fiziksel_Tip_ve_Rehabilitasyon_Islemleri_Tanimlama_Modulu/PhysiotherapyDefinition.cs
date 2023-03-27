using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PhysiotherapyDefinition
    {
        public Guid ObjectId { get; set; }
        public int? TreatmentDuration { get; set; }
        public ExaminationSubClassEnum? ExaminationSubClass { get; set; }
        public int? OrderNo { get; set; }
        public bool? ESWTTransaction { get; set; }

        #region Base Object Navigation Property
        public virtual ProcedureDefinition ProcedureDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}