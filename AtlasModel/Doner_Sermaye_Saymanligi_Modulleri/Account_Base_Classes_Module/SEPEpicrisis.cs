using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SEPEpicrisis
    {
        public Guid ObjectId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Description { get; set; }
        public Guid? ResUserRef { get; set; }

        #region Parent Relations
        public virtual ResUser ResUser { get; set; }
        #endregion Parent Relations
    }
}