using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DrugOrderTransactionDetail
    {
        public Guid ObjectId { get; set; }
        public bool? IsStockOperation { get; set; }
        public double? Amount { get; set; }
        public Guid? DrugOrderTransactionRef { get; set; }
        public Guid? StockTransactionRef { get; set; }
        public Guid? DrugOrderDetailRef { get; set; }

        #region Parent Relations
        public virtual DrugOrderTransaction DrugOrderTransaction { get; set; }
        public virtual StockTransaction StockTransaction { get; set; }
        public virtual DrugOrderDetail DrugOrderDetail { get; set; }
        #endregion Parent Relations
    }
}