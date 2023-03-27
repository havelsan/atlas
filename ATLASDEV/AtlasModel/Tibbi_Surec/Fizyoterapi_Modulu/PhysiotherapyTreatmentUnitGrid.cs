using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PhysiotherapyTreatmentUnitGrid
    {
        public Guid ObjectId { get; set; }
        public Guid? PhysiotherapyDefinitionRef { get; set; }
        public Guid? TreatmentDiagnosisUnitRef { get; set; }

        #region Parent Relations
        public virtual PhysiotherapyDefinition PhysiotherapyDefinition { get; set; }
        public virtual ResTreatmentDiagnosisUnit TreatmentDiagnosisUnit { get; set; }
        #endregion Parent Relations
    }
}