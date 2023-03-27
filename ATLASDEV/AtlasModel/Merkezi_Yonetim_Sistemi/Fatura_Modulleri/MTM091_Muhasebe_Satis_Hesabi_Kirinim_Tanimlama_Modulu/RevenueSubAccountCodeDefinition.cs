using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class RevenueSubAccountCodeDefinition
    {
        public Guid ObjectId { get; set; }
        public string AccountCode { get; set; }
        public string Description { get; set; }
        public string Description_Shadow { get; set; }
        public AccountEntegrationAccountTypeEnum? AccountType { get; set; }
        public RevenueSubAccountTypeEnum? SubAccountType { get; set; }
        public Guid? MasterRevenueSubAccountRef { get; set; }
        public Guid? RelatedRevenueSubAccountRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual RevenueSubAccountCodeDefinition MasterRevenueSubAccount { get; set; }
        public virtual RevenueSubAccountCodeDefinition RelatedRevenueSubAccount { get; set; }
        #endregion Parent Relations
    }
}