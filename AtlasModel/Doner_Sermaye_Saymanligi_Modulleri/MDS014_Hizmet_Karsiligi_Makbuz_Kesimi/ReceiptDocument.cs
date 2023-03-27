using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ReceiptDocument
    {
        public Guid ObjectId { get; set; }
        public decimal? TotalVATPrice { get; set; }
        public long? CreditCardSpecialNo { get; set; }
        public long? PatientNo { get; set; }
        public string PatientName { get; set; }
        public string CreditCardDocumentNo { get; set; }
        public long? SpecialNo { get; set; }
        public string PayeeName { get; set; }
        public decimal? GeneralTotalPrice { get; set; }
        public decimal? TotalDiscountPrice { get; set; }

        #region Base Object Navigation Property
        public virtual AccountDocument AccountDocument { get; set; }
        #endregion Base Object Navigation Property
    }
}