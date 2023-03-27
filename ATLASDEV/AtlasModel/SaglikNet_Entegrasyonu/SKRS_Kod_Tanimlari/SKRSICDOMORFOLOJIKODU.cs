using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SKRSICDOMORFOLOJIKODU
    {
        public Guid ObjectId { get; set; }
        public string MORFOLOJIKOD { get; set; }
        public string MORFOLOJIKODTANIM { get; set; }
        public string MORFOLOJIKODACIKLAMA { get; set; }
        public string Morfoloji_Shadow { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSKRSDefinition BaseSKRSDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}