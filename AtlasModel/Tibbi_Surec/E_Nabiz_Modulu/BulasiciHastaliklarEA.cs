using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BulasiciHastaliklarEA
    {
        public Guid ObjectId { get; set; }
        public Guid? BulasiciHastalikVeriSetiRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property
    }
}