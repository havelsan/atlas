using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class IIMProtocol
    {
        public Guid ObjectId { get; set; }
        public bool? Checked { get; set; }
        public Guid? InvoiceInclusionMasterRef { get; set; }
        public Guid? ProtocolDefinitionRef { get; set; }

        #region Parent Relations
        public virtual InvoiceInclusionMaster InvoiceInclusionMaster { get; set; }
        #endregion Parent Relations
    }
}