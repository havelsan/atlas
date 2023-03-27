using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseHealthCommittee_HospitalsUnitsGrid
    {
        public Guid ObjectId { get; set; }
        public Guid? TemplateRef { get; set; }
        public Guid? BaseHealthCommitteeRef { get; set; }
        public Guid? EpisodeActionTemplateRef { get; set; }

        #region Base Object Navigation Property
        public virtual HospitalsUnitsGrid HospitalsUnitsGrid { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual BaseHealthCommittee BaseHealthCommittee { get; set; }
        #endregion Parent Relations
    }
}