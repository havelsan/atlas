using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SurgeryDefinition
    {
        public Guid ObjectId { get; set; }
        public SurgeryPointGroupEnum? SurgeryPointGroup { get; set; }
        public SurgeryProcedureGroup? SUTGroup { get; set; }
        public bool? InVitroFertilizationProcess { get; set; }
        public bool? ReportIsRequired { get; set; }
        public SurgeyProcedureTypeEnum? SurgeryProcedureType { get; set; }
        public SurgeryProcedureGroup? GILGroup { get; set; }
        public PhysiotherapyFormsEnum? PhysiotherapyFormName { get; set; }
        public ManipulationFormNameEnum? ManipulationFormName { get; set; }
        public bool? IsDescriptionNeeded_1 { get; set; }
        public bool? IsNeedEuroScore { get; set; }
        public ManipulationStartStateEnum? ManipulationStartState { get; set; }
        public bool? IsSurgery { get; set; }
        public bool? IsManipulation { get; set; }
        public bool? IsAdditionalApplication { get; set; }
        public Guid? ResourceRef { get; set; }

        #region Base Object Navigation Property
        public virtual ProcedureDefinition ProcedureDefinition { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual Resource Resource { get; set; }
        #endregion Parent Relations
    }
}