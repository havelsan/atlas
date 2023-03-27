using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class UserTemplate
    {
        public Guid ObjectId { get; set; }
        public string Description { get; set; }
        public Guid? TAObjectID { get; set; }
        public Guid? TAObjectDefID { get; set; }
        public string FiliterData { get; set; }
        public Guid? ResUserRef { get; set; }

        #region Parent Relations
        public virtual ResUser ResUser { get; set; }
        #endregion Parent Relations
    }
}