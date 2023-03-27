using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BasePhysiotherapyOrderDetail
    {
        public Guid ObjectId { get; set; }

        #region Base Object Navigation Property
        public virtual SubactionProcedureFlowable SubactionProcedureFlowable { get; set; }
        #endregion Base Object Navigation Property
    }
}