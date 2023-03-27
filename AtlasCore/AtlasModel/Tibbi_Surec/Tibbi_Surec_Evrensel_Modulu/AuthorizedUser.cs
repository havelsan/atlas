using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AuthorizedUser
    {
        public Guid ObjectId { get; set; }
        public Guid? ActionRef { get; set; }
        public Guid? SubactionProcedureRef { get; set; }
        public Guid? UserRef { get; set; }

        #region Parent Relations
        public virtual BaseAction Action { get; set; }
        public virtual SubactionProcedureFlowable SubactionProcedure { get; set; }
        public virtual ResUser User { get; set; }
        #endregion Parent Relations
    }
}