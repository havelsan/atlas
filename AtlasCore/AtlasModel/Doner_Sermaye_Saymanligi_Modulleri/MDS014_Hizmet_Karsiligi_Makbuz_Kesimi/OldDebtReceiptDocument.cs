using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class OldDebtReceiptDocument
    {
        public Guid ObjectId { get; set; }

        #region Base Object Navigation Property
        public virtual AccountDocument AccountDocument { get; set; }
        #endregion Base Object Navigation Property
    }
}