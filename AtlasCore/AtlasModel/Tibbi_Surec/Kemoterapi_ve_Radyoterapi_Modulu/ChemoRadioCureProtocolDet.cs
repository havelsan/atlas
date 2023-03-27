using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ChemoRadioCureProtocolDet
    {
        public Guid ObjectId { get; set; }
        public string Note { get; set; }
        public Guid? ChemoRadioCureProtocolRef { get; set; }
        public Guid? DrugMaterialRef { get; set; }
        public Guid? SolutionMaterialRef { get; set; }

        #region Base Object Navigation Property
        public virtual SubactionProcedureFlowable SubactionProcedureFlowable { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ChemoRadioCureProtocol ChemoRadioCureProtocol { get; set; }
        public virtual BaseTreatmentMaterial DrugMaterial { get; set; }
        public virtual BaseTreatmentMaterial SolutionMaterial { get; set; }
        #endregion Parent Relations
    }
}