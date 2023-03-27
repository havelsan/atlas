using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ChattelDocumentInputDetailWithAccountancy
    {
        public Guid ObjectId { get; set; }
        public Guid? SupplierRef { get; set; }

        #region Base Object Navigation Property
        public virtual StockActionDetailIn StockActionDetailIn { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual Supplier Supplier { get; set; }
        #endregion Parent Relations
    }
}