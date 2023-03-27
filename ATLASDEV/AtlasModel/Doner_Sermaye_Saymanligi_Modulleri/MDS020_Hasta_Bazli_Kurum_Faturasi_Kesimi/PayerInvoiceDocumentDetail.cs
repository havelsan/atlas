using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PayerInvoiceDocumentDetail
    {
        public Guid ObjectId { get; set; }

        #region Base Object Navigation Property
        public virtual AccountDocumentDetail AccountDocumentDetail { get; set; }
        #endregion Base Object Navigation Property
    }
}