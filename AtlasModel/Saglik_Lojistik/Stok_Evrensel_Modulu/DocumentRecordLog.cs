using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DocumentRecordLog
    {
        public Guid ObjectId { get; set; }
        public string TakenGivenPlace_Shadow { get; set; }
        public string Descriptions { get; set; }
        public DateTime? DocumentDateTime { get; set; }
        public long? DocumentRecordLogNumber { get; set; }
        public DocumentTransactionTypeEnum? DocumentTransactionType { get; set; }
        public int? NumberOfRows { get; set; }
        public string Subject { get; set; }
        public string TakenGivenPlace { get; set; }
        public MKYS_EButceTurEnum? BudgeType { get; set; }
        public int? ReceiptNumber { get; set; }
        public MKYSControlEnum? MKYSStatus { get; set; }
        public Guid? StockActionRef { get; set; }

        #region Parent Relations
        public virtual StockAction StockAction { get; set; }
        #endregion Parent Relations
    }
}