using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Resource
    {
        public Guid ObjectId { get; set; }
        public string Qref { get; set; }
        public string Name { get; set; }
        public long? ID { get; set; }
        public string Name_Shadow { get; set; }
        public string Location { get; set; }
        public string DeskPhoneNumber { get; set; }
        public Guid? ResTypeRef { get; set; }
        public Guid? StoreRef { get; set; }

        #region Parent Relations
        public virtual Store Store { get; set; }
        #endregion Parent Relations
    }
}