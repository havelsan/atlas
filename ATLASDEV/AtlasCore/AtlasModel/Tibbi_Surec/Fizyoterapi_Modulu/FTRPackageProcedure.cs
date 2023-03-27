using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class FTRPackageProcedure
    {
        public Guid ObjectId { get; set; }
        public Guid? PhysiotherapyOrderDetailRef { get; set; }

        #region Base Object Navigation Property
        public virtual SubActionPackageProcedure SubActionPackageProcedure { get; set; }
        #endregion Base Object Navigation Property
    }
}