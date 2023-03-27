using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PayerInvoiceDocumentGroup
    {
        public Guid ObjectId { get; set; }

        #region Base Object Navigation Property
        public virtual AccountDocumentGroup AccountDocumentGroup { get; set; }
        #endregion Base Object Navigation Property
    }
}