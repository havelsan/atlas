using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingReasonGrid
    {
        public Guid ObjectId { get; set; }
        public Guid? NursingReasonRef { get; set; }
        public Guid? NursingNandaRef { get; set; }

        #region Parent Relations
        public virtual NursingReasonDefinition NursingReason { get; set; }
        public virtual NursingCare NursingNanda { get; set; }
        #endregion Parent Relations
    }
}