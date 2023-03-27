using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseAdditionalApplication
    {
        public Guid ObjectId { get; set; }
        public string NurseNotes { get; set; }
        public string Result { get; set; }
        public string Description { get; set; }
        public Guid? ReportApplicationAreaRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSurgeryAndManipulationProcedure BaseSurgeryAndManipulationProcedure { get; set; }
        #endregion Base Object Navigation Property
    }
}