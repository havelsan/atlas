using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class CashOfficeReceiptDocument
    {
        public Guid ObjectId { get; set; }
        public string PayeeAddress { get; set; }
        public string PayeeName { get; set; }
        public long? SpecialNo { get; set; }
        public string PayeeUniqueRefNo { get; set; }
        public string Phone { get; set; }
        public string TenderName { get; set; }
        public string TenderNo { get; set; }
        public Guid? SupplierRef { get; set; }
        public Guid? MoneyReceivedTypeRef { get; set; }
        public Guid? BankDecountRef { get; set; }

        #region Base Object Navigation Property
        public virtual AccountDocument AccountDocument { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual Supplier Supplier { get; set; }
        public virtual MainCashOfficePaymentTypeDefinition MoneyReceivedType { get; set; }
        #endregion Parent Relations
    }
}