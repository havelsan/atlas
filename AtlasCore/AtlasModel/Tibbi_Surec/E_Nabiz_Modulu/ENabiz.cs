using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ENabiz
    {
        public Guid ObjectId { get; set; }
        public int? PackageID { get; set; }
        public string PackageName { get; set; }
        public Guid? EpisodeActionRef { get; set; }
        public Guid? SubEpisodeRef { get; set; }

        #region Parent Relations
        public virtual EpisodeAction EpisodeAction { get; set; }
        public virtual SubEpisode SubEpisode { get; set; }
        #endregion Parent Relations
    }
}