using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MainCashOfficePaymentTypeDefinition
    {
        public Guid ObjectId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool? IsSubCashOfficePayment { get; set; }
        public bool? AccountEntegration { get; set; }
        public bool? IsBankOperation { get; set; }
        public bool? SubCashierCanDo { get; set; }
        public string Name_Shadow { get; set; }
        public bool? IsChattel { get; set; }
        public Guid? RevenueSubAccountCodeRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual RevenueSubAccountCodeDefinition RevenueSubAccountCode { get; set; }
        #endregion Parent Relations
    }
}