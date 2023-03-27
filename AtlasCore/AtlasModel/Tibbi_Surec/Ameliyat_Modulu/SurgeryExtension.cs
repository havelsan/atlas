using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SurgeryExtension
    {
        public Guid ObjectId { get; set; }
        public Guid? DescriptionToPreOp { get; set; }
        public bool? CancelledBySurgery { get; set; }
        public string PreOpDescriptions { get; set; }
        public Guid? MainSurgeryRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual Surgery MainSurgery { get; set; }
        #endregion Parent Relations
    }
}