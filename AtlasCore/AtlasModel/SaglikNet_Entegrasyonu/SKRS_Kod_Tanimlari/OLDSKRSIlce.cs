using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class OLDSKRSIlce
    {
        public Guid ObjectId { get; set; }
        public string ADI { get; set; }
        public int? KODU { get; set; }
        public int? ILKODU { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSKRSDefinition BaseSKRSDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}