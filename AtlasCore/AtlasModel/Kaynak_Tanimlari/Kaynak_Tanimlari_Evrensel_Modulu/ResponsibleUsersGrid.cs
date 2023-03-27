using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResponsibleUsersGrid
    {
        public Guid ObjectId { get; set; }
        public Guid? ResSectionRef { get; set; }
        public Guid? ResUserRef { get; set; }

        #region Parent Relations
        public virtual ResSection ResSection { get; set; }
        public virtual ResUser ResUser { get; set; }
        #endregion Parent Relations
    }
}