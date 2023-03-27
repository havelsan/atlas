using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StoreSMSUser
    {
        public Guid ObjectId { get; set; }
        public Guid? ResUserRef { get; set; }
        public Guid? StoreRef { get; set; }

        #region Parent Relations
        public virtual ResUser ResUser { get; set; }
        public virtual Store Store { get; set; }
        #endregion Parent Relations
    }
}