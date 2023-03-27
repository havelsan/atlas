using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ChemotherapyRadiotherapy
    {
        public Guid ObjectId { get; set; }
        public DateTime? CureStartDate { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property
    }
}