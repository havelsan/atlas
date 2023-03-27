using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResourcesToBeReferredGrid
    {
        public Guid ObjectId { get; set; }
        public Guid? ResourceRef { get; set; }

        #region Parent Relations
        public virtual ResSection Resource { get; set; }
        #endregion Parent Relations
    }
}