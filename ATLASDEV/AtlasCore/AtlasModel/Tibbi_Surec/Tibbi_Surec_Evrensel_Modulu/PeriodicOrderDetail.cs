using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PeriodicOrderDetail
    {
        public Guid ObjectId { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public Guid? PeriodicOrderRef { get; set; }

        #region Base Object Navigation Property
        public virtual SubactionProcedureFlowable SubactionProcedureFlowable { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual PeriodicOrder PeriodicOrder { get; set; }
        #endregion Parent Relations
    }
}