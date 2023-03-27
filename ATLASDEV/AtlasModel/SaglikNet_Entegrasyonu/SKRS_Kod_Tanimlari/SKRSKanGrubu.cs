using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SKRSKanGrubu
    {
        public Guid ObjectId { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSKRSCommonDef BaseSKRSCommonDef { get; set; }
        #endregion Base Object Navigation Property
    }
}