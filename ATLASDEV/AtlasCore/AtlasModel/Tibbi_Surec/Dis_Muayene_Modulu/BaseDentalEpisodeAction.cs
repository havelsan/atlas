using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseDentalEpisodeAction
    {
        public Guid ObjectId { get; set; }
        public string ToothNumbers { get; set; }

        #region Base Object Navigation Property
        public virtual PhysicianApplication PhysicianApplication { get; set; }
        #endregion Base Object Navigation Property
    }
}