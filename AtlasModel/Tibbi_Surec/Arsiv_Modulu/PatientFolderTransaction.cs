using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PatientFolderTransaction
    {
        public Guid ObjectId { get; set; }
        public long? TransactionID { get; set; }
        public FolderTransactionTypeEnum? TransactionType { get; set; }
        public DateTime? TransactionDate { get; set; }
        public Guid? TransactionUserRef { get; set; }
        public Guid? FolderLocationRef { get; set; }
        public Guid? PatientFolderRef { get; set; }

        #region Parent Relations
        public virtual ResUser TransactionUser { get; set; }
        public virtual ResSection FolderLocation { get; set; }
        public virtual PatientFolder PatientFolder { get; set; }
        #endregion Parent Relations
    }
}