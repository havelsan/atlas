using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Payment
    {
        public Guid ObjectId { get; set; }
        public decimal? Price { get; set; }
        public Guid? AccountDocumentRef { get; set; }

        #region Parent Relations
        public virtual AccountDocument AccountDocument { get; set; }
        #endregion Parent Relations
    }
}