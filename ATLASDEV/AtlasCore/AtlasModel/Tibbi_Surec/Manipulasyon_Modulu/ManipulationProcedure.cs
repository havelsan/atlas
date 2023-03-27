using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ManipulationProcedure
    {
        public Guid ObjectId { get; set; }
        public string Birim { get; set; }
        public string Sonuc { get; set; }
        public string RaporTakipNo { get; set; }
        public string Description { get; set; }
        public bool? IsResultSeen { get; set; }
        public Guid? ManipulationRequestRef { get; set; }
        public Guid? ProcedureDepartmentRef { get; set; }
        public Guid? SagSolRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSurgeryAndManipulationProcedure BaseSurgeryAndManipulationProcedure { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ManipulationRequest ManipulationRequest { get; set; }
        public virtual ResSection ProcedureDepartment { get; set; }
        #endregion Parent Relations
    }
}