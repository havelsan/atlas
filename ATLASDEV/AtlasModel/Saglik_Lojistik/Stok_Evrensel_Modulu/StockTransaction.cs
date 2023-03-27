using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockTransaction
    {
        public Guid ObjectId { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public TransactionTypeEnum? InOut { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal? UnitPrice { get; set; }
        public MaintainLevelCodeEnum? MaintainLevelCode { get; set; }
        public long? VatRate { get; set; }
        public string LotNo { get; set; }
        public decimal? Amount { get; set; }
        public int? MKYS_StokHareketID { get; set; }
        public string SerialNo { get; set; }
        public string ReceiveNotificationID { get; set; }
        public string IncomingDeliveryNotifID { get; set; }
        public string DeliveryNotifictionID { get; set; }
        public string UsageNotificationID { get; set; }
        public Guid? StockRef { get; set; }
        public Guid? StockTransactionDefinitionRef { get; set; }
        public Guid? StockLevelTypeRef { get; set; }
        public Guid? StockActionDetailRef { get; set; }
        public Guid? BudgetTypeDefinitionRef { get; set; }
        public Guid? PatientRef { get; set; }

        #region Parent Relations
        public virtual Stock Stock { get; set; }
        public virtual StockTransactionDefinition StockTransactionDefinition { get; set; }
        public virtual StockLevelType StockLevelType { get; set; }
        public virtual StockActionDetail StockActionDetail { get; set; }
        public virtual BudgetTypeDefinition BudgetTypeDefinition { get; set; }
        public virtual Patient Patient { get; set; }
        #endregion Parent Relations
    }
}