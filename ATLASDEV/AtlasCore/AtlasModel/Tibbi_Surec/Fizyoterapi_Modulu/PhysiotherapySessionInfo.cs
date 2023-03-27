using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PhysiotherapySessionInfo
    {
        public Guid ObjectId { get; set; }
        public DateTime? PlannedDate { get; set; }
        public Guid? PhysiotherapyRequestRef { get; set; }

        #region Parent Relations
        public virtual PhysiotherapyRequest PhysiotherapyRequest { get; set; }
        #endregion Parent Relations
    }
}