using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Allocation
    {
        public Guid ObjectId { get; set; }
        public DateTime? AllocateDate { get; set; }
        public DateTime? DeallocateDate { get; set; }
        public Guid? EpisodeActionRef { get; set; }
        public Guid? EpisodeRef { get; set; }
        public Guid? SpecialityRef { get; set; }
        public Guid? SubActionProcedureRef { get; set; }

        #region Parent Relations
        public virtual EpisodeAction EpisodeAction { get; set; }
        public virtual Episode Episode { get; set; }
        public virtual SubActionProcedure SubActionProcedure { get; set; }
        #endregion Parent Relations
    }
}