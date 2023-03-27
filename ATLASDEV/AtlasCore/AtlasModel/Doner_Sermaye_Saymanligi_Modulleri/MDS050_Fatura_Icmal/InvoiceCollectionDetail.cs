using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InvoiceCollectionDetail
    {
        public Guid ObjectId { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? Payment { get; set; }
        public decimal? Deduction { get; set; }
        public Guid? CreateUserRef { get; set; }
        public Guid? InvoiceCollectionRef { get; set; }
        public Guid? EpisodeRef { get; set; }
        public Guid? NewInvoiceCollectionDetailRef { get; set; }
        public Guid? PayerInvoiceDocumentRef { get; set; }

        #region Parent Relations
        public virtual ResUser CreateUser { get; set; }
        public virtual Episode Episode { get; set; }
        public virtual InvoiceCollectionDetail NewInvoiceCollectionDetail { get; set; }
        public virtual PayerInvoiceDocument PayerInvoiceDocument { get; set; }
        #endregion Parent Relations
    }
}