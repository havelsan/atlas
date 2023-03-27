using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InPatientPhysicianProgresses
    {
        public Guid ObjectId { get; set; }
        public DateTime? ProgressDate { get; set; }
        public Guid? Description { get; set; }
        public Guid? EntryEpisodeActionRef { get; set; }
        public Guid? ProcedureDoctorRef { get; set; }
        public Guid? SubEpisodeRef { get; set; }

        #region Parent Relations
        public virtual EpisodeAction EntryEpisodeAction { get; set; }
        public virtual ResUser ProcedureDoctor { get; set; }
        public virtual SubEpisode SubEpisode { get; set; }
        #endregion Parent Relations
    }
}