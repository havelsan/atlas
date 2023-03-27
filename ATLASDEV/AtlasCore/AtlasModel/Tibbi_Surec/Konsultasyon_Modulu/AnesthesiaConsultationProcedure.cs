using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AnesthesiaConsultationProcedure
    {
        public Guid ObjectId { get; set; }

        #region Base Object Navigation Property
        public virtual SubActionProcedure SubActionProcedure { get; set; }
        #endregion Base Object Navigation Property
    }
}