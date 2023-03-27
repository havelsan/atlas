using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingCareGrid
    {
        public Guid ObjectId { get; set; }
        public Guid? NursingCareRef { get; set; }
        public Guid? NursingNandaRef { get; set; }

        #region Parent Relations
        public virtual NursingCareDefinition NursingCare { get; set; }
        public virtual NursingCare NursingNanda { get; set; }
        #endregion Parent Relations
    }
}