using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class CreditCard
    {
        public Guid ObjectId { get; set; }
        public string PhoneNo { get; set; }
        public string Owner { get; set; }
        public DateTime? ValidDate { get; set; }
        public CreditCardTypeEnum? CardType { get; set; }
        public string CardNo { get; set; }
        public Guid? BankNameRef { get; set; }

        #region Base Object Navigation Property
        public virtual Payment Payment { get; set; }
        #endregion Base Object Navigation Property
    }
}