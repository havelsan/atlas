using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MainCashOfficeOperation
    {
        public Guid ObjectId { get; set; }
        public Guid? CashOfficeReceiptDocumentRef { get; set; }

        #region Base Object Navigation Property
        public virtual AccountAction AccountAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual CashOfficeReceiptDocument CashOfficeReceiptDocument { get; set; }
        #endregion Parent Relations
    }
}