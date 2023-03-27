using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AccountDocumentDetail
    {
        public Guid ObjectId { get; set; }
        public string Description { get; set; }
        public double? Amount { get; set; }
        public string ExternalCode { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalDiscountPrice { get; set; }
        public decimal? VATPrice { get; set; }
        public decimal? TotalDiscountedPrice { get; set; }
        public Guid? AccountDocumentGroupRef { get; set; }
        public Guid? CurrencyTypeRef { get; set; }

        #region Parent Relations
        public virtual AccountDocumentGroup AccountDocumentGroup { get; set; }
        #endregion Parent Relations
    }
}