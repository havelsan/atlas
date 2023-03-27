using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseMultipleDataEntry
    {
        public Guid ObjectId { get; set; }
        public DateTime? EntryDate { get; set; }
        public Guid? EntryUserRef { get; set; }
        public Guid? EpisodeActionRef { get; set; }

        #region Parent Relations
        public virtual ResUser EntryUser { get; set; }
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Parent Relations
    }
}