using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class VitalSign
    {
        public Guid ObjectId { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public Guid? EpisodeActionRef { get; set; }
        public Guid? SubActionProcedureRef { get; set; }

        #region Parent Relations
        public virtual EpisodeAction EpisodeAction { get; set; }
        public virtual SubActionProcedure SubActionProcedure { get; set; }
        #endregion Parent Relations
    }
}