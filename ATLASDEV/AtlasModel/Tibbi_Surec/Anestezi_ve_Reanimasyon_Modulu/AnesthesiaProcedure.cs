using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AnesthesiaProcedure
    {
        public Guid ObjectId { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAnesthesiaProcedure BaseAnesthesiaProcedure { get; set; }
        #endregion Base Object Navigation Property
    }
}