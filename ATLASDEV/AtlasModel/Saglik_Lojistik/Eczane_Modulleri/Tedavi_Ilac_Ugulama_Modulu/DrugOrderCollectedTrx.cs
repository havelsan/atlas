using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DrugOrderCollectedTrx
    {
        public Guid ObjectId { get; set; }
        public Guid? StockActionDetailRef { get; set; }
        public Guid? DrugOrderTransactionDetailRef { get; set; }

        #region Parent Relations
        public virtual StockActionDetail StockActionDetail { get; set; }
        public virtual DrugOrderTransactionDetail DrugOrderTransactionDetail { get; set; }
        #endregion Parent Relations
    }
}