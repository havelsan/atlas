using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class CollectiveInvoiceOpDetail
    {
        public Guid ObjectId { get; set; }
        public Guid? ExecObjectID { get; set; }
        public string ExecObjectType { get; set; }
        public DateTime? ExecDate { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string MedulaTakipNo { get; set; }
        public string ProtocolNo { get; set; }
        public Guid? CollectiveInvoiceOpRef { get; set; }

        #region Parent Relations
        public virtual CollectiveInvoiceOp CollectiveInvoiceOp { get; set; }
        #endregion Parent Relations
    }
}