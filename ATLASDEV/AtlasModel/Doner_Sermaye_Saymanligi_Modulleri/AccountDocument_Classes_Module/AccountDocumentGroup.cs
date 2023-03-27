using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AccountDocumentGroup
    {
        public Guid ObjectId { get; set; }
        public string GroupDescription { get; set; }
        public string GroupCode { get; set; }
        public Guid? AccountDocumentRef { get; set; }

        #region Parent Relations
        public virtual AccountDocument AccountDocument { get; set; }
        #endregion Parent Relations

        #region Child Relations
        public virtual ICollection<AccountDocumentDetail> AccountDocumentDetails { get; set; }
        #endregion Child Relations
    }
}