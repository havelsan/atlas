using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class UserMessageGroupUsers
    {
        public Guid ObjectId { get; set; }
        public Guid? UserMessageGroupDefinitionRef { get; set; }
        public Guid? ResUserRef { get; set; }

        #region Parent Relations
        public virtual ResUser ResUser { get; set; }
        #endregion Parent Relations
    }
}