using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class EkokardiografiFormObject
    {
        public Guid ObjectId { get; set; }
        public string KalpHizi { get; set; }
        public string Ritim { get; set; }
        public Guid? LVSegmentHareket { get; set; }
        public Guid? PerikartOzellik { get; set; }
        public Guid? EkoSonuc { get; set; }
        public string Boy { get; set; }
        public string Kilo { get; set; }

        #region Base Object Navigation Property
        public virtual ManipulationFormBaseObject ManipulationFormBaseObject { get; set; }
        #endregion Base Object Navigation Property
    }
}