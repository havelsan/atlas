using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ActionDefaultMasterResourceGrid
    {
        public Guid ObjectId { get; set; }
        public Guid? ResourceRef { get; set; }
        public Guid? ActionDefMasterResDefinitionRef { get; set; }

        #region Parent Relations
        public virtual ResSection Resource { get; set; }
        #endregion Parent Relations
    }
}