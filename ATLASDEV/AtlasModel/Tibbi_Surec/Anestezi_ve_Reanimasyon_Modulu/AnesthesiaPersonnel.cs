using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AnesthesiaPersonnel
    {
        public Guid ObjectId { get; set; }
        public string Role { get; set; }
        public Guid? AnesthesiaAndReanimationRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAnesthesiaPersonnel BaseAnesthesiaPersonnel { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual AnesthesiaAndReanimation AnesthesiaAndReanimation { get; set; }
        #endregion Parent Relations
    }
}