using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class EpisodeActionSMSInfo
    {
        public Guid ObjectId { get; set; }
        public DateTime? EpisodeActionDate { get; set; }
        public bool? IsActiveFlag { get; set; }
        public bool? CompletedFlag { get; set; }
        public string ObjectDefName { get; set; }
        public int? SMSNumberForResponsible { get; set; }
        public int? SMSNumberForDoctor { get; set; }
        public int? SMSNumberForChief { get; set; }
        public Guid? EpisodeActionRef { get; set; }

        #region Parent Relations
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Parent Relations
    }
}