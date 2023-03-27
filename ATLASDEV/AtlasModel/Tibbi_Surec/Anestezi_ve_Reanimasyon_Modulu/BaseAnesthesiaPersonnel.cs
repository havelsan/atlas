using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseAnesthesiaPersonnel
    {
        public Guid ObjectId { get; set; }
        public Guid? AnesthesiaPersonnelRef { get; set; }

        #region Parent Relations
        public virtual ResUser AnesthesiaPersonnel { get; set; }
        #endregion Parent Relations
    }
}