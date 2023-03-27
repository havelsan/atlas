using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingSystemInterrogation
    {
        public Guid ObjectId { get; set; }
        public Guid? BaseNursSysInterrogationRef { get; set; }

        #region Parent Relations
        public virtual BaseNursingSystemInterrogation BaseNursSysInterrogation { get; set; }
        #endregion Parent Relations
    }
}