using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DiagnosisSubEpisode
    {
        public Guid ObjectId { get; set; }
        public Guid? DiagnosisGridRef { get; set; }
        public Guid? SubEpisodeRef { get; set; }

        #region Parent Relations
        public virtual DiagnosisGrid DiagnosisGrid { get; set; }
        public virtual SubEpisode SubEpisode { get; set; }
        #endregion Parent Relations
    }
}