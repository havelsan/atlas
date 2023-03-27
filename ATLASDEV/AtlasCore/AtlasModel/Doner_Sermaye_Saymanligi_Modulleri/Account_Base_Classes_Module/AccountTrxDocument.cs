using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AccountTrxDocument
    {
        public Guid ObjectId { get; set; }
        public Guid? AccountTransactionRef { get; set; }
        public Guid? AccountDocumentDetailRef { get; set; }

        #region Parent Relations
        public virtual AccountTransaction AccountTransaction { get; set; }
        public virtual AccountDocumentDetail AccountDocumentDetail { get; set; }
        #endregion Parent Relations
    }
}