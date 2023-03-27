using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SendMessageToPatient
    {
        public Guid ObjectId { get; set; }
        public string MessageInfo { get; set; }
        public DateTime? MessageDate { get; set; }
        public Guid? SubEpisodeRef { get; set; }
        public Guid? PatientRef { get; set; }
        public Guid? SKRSHastaMesajlariRef { get; set; }

        #region Parent Relations
        public virtual SubEpisode SubEpisode { get; set; }
        public virtual Patient Patient { get; set; }
        #endregion Parent Relations
    }
}