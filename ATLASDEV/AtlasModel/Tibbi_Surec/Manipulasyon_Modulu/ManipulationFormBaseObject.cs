using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ManipulationFormBaseObject
    {
        public Guid ObjectId { get; set; }
        public Guid? ManipulationRef { get; set; }

        #region Parent Relations
        public virtual Manipulation Manipulation { get; set; }
        #endregion Parent Relations
    }
}