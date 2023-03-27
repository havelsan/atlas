using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class IIMDetail
    {
        public Guid ObjectId { get; set; }
        public bool? Checked { get; set; }
        public Guid? InvoiceInclusionMasterRef { get; set; }
        public Guid? InvoiceInclusionDetailRef { get; set; }

        #region Parent Relations
        public virtual InvoiceInclusionMaster InvoiceInclusionMaster { get; set; }
        #endregion Parent Relations
    }
}