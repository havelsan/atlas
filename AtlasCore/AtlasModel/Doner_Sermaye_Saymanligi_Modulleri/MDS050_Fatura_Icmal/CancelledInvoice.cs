using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class CancelledInvoice
    {
        public Guid ObjectId { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public CancelledInvoiceTypeEnum? Type { get; set; }
        public Guid? SEPRef { get; set; }
        public Guid? ICDRef { get; set; }
        public Guid? PIDRef { get; set; }
        public Guid? UserRef { get; set; }

        #region Parent Relations
        public virtual SubEpisodeProtocol SEP { get; set; }
        public virtual InvoiceCollectionDetail ICD { get; set; }
        public virtual PayerInvoiceDocument PID { get; set; }
        public virtual ResUser User { get; set; }
        #endregion Parent Relations
    }
}