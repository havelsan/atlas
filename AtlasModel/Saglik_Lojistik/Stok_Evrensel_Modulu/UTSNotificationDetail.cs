using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class UTSNotificationDetail
    {
        public Guid ObjectId { get; set; }
        public int? Amount { get; set; }
        public string NotificationID { get; set; }
        public UTSNotificationTypeEnum? NotificationType { get; set; }
        public DateTime? NotificationDate { get; set; }
        public Guid? StockTransactionRef { get; set; }

        #region Parent Relations
        public virtual StockTransaction StockTransaction { get; set; }
        #endregion Parent Relations
    }
}