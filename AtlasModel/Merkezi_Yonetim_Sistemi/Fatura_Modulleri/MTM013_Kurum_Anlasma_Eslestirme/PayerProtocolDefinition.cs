using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PayerProtocolDefinition
    {
        public Guid ObjectId { get; set; }
        public DateTime? ProtocolStartDate { get; set; }
        public DateTime? ProtocolEndDate { get; set; }
        public Guid? PayerRef { get; set; }
        public Guid? ProtocolRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual PayerDefinition Payer { get; set; }
        #endregion Parent Relations
    }
}