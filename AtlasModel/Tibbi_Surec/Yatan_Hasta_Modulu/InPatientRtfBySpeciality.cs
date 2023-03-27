using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InPatientRtfBySpeciality
    {
        public Guid ObjectId { get; set; }
        public Guid? Rtf { get; set; }
        public string Title { get; set; }
        public Guid? RTFDefinitionsBySpecialityRef { get; set; }
        public Guid? SubEpisodeRef { get; set; }
        public Guid? EpisodeActionRef { get; set; }

        #region Parent Relations
        public virtual SubEpisode SubEpisode { get; set; }
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Parent Relations
    }
}