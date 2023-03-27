using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SendToENabiz
    {
        public Guid ObjectId { get; set; }
        public string PackageCode { get; set; }
        public SendToENabizEnum? Status { get; set; }
        public Guid? InternalObjectID { get; set; }
        public string InternalObjectDefName { get; set; }
        public DateTime? RecordDate { get; set; }
        public Guid? SubEpisodeRef { get; set; }

        #region Parent Relations
        public virtual SubEpisode SubEpisode { get; set; }
        #endregion Parent Relations
    }
}