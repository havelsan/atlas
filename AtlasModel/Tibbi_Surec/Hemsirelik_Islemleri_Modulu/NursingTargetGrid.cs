using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingTargetGrid
    {
        public Guid ObjectId { get; set; }
        public Guid? NursingTargetRef { get; set; }
        public Guid? NursingNandaRef { get; set; }

        #region Parent Relations
        public virtual NursingTargetDefinition NursingTarget { get; set; }
        public virtual NursingCare NursingNanda { get; set; }
        #endregion Parent Relations
    }
}