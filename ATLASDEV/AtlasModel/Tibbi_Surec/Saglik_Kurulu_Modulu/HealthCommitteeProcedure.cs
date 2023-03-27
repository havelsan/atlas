using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class HealthCommitteeProcedure
    {
        public Guid ObjectId { get; set; }
        public Guid? OzelDurumRef { get; set; }

        #region Base Object Navigation Property
        public virtual SubActionProcedure SubActionProcedure { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual OzelDurum OzelDurum { get; set; }
        #endregion Parent Relations
    }
}