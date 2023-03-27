using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PatientAuthorizedResource
    {
        public Guid ObjectId { get; set; }
        public Guid? ResourceRef { get; set; }
        public Guid? EpisodeRef { get; set; }
        public Guid? PatientRef { get; set; }

        #region Parent Relations
        public virtual Resource Resource { get; set; }
        public virtual Episode Episode { get; set; }
        public virtual Patient Patient { get; set; }
        #endregion Parent Relations
    }
}