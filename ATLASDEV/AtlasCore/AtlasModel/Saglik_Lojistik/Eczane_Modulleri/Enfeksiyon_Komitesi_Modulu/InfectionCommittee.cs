using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InfectionCommittee
    {
        public Guid ObjectId { get; set; }
        public string CancelReason { get; set; }
        public Guid? InPatientPhysicianApplicationRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual InPatientPhysicianApplication InPatientPhysicianApplication { get; set; }
        #endregion Parent Relations
    }
}