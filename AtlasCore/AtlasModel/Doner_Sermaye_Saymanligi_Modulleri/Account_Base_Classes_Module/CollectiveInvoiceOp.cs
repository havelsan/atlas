using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class CollectiveInvoiceOp
    {
        public Guid ObjectId { get; set; }
        public DateTime? EndDate { get; set; }
        public CollectiveInvoiceOpTypeEnum? OpType { get; set; }
        public DateTime? StartDate { get; set; }
        public PayerTypeEnum? PayerType { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string InvoiceDescription { get; set; }
        public Guid? InvoiceCollectionID { get; set; }
        public string ExtraData { get; set; }
        public DateTime? CreateDate { get; set; }
        public CollectiveInvoiceTaskType? TaskType { get; set; }
        public string ErrorCodeText { get; set; }
        public string ErrorSutCodeText { get; set; }
        public CollectiveInvoiceExecType? ExecType { get; set; }
        public Guid? UserRef { get; set; }
        public Guid? NextCIORef { get; set; }

        #region Parent Relations
        public virtual ResUser User { get; set; }
        public virtual CollectiveInvoiceOp NextCIO { get; set; }
        #endregion Parent Relations
    }
}