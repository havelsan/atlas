using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SKRSRaporTuru
    {
        public Guid ObjectId { get; set; }
        public string RaporGrubu { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSKRSCommonDef BaseSKRSCommonDef { get; set; }
        #endregion Base Object Navigation Property
    }
}