using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResUserUsableStore
    {
        public Guid ObjectId { get; set; }
        public Guid? StoreRef { get; set; }
        public Guid? ResUserRef { get; set; }

        #region Parent Relations
        public virtual Store Store { get; set; }
        public virtual ResUser ResUser { get; set; }
        #endregion Parent Relations
    }
}