using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class UserResource
    {
        public Guid ObjectId { get; set; }
        public Guid? UserRef { get; set; }
        public Guid? ResourceRef { get; set; }

        #region Parent Relations
        public virtual ResUser User { get; set; }
        public virtual ResSection Resource { get; set; }
        #endregion Parent Relations
    }
}