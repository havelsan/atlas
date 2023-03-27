using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InvoiceCollectionDocument
    {
        public Guid ObjectId { get; set; }
        public decimal? DrugTotal { get; set; }
        public decimal? MaterialTotal { get; set; }
        public Guid? PayerRef { get; set; }

        #region Base Object Navigation Property
        public virtual AccountDocument AccountDocument { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual PayerDefinition Payer { get; set; }
        #endregion Parent Relations
    }
}