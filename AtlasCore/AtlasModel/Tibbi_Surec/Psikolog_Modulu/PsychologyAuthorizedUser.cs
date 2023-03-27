using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PsychologyAuthorizedUser
    {
        public Guid ObjectId { get; set; }
        public Guid? PsychologyBasedObjectRef { get; set; }
        public Guid? ResUserRef { get; set; }

        #region Parent Relations
        public virtual PsychologyBasedObject PsychologyBasedObject { get; set; }
        public virtual ResUser ResUser { get; set; }
        #endregion Parent Relations
    }
}