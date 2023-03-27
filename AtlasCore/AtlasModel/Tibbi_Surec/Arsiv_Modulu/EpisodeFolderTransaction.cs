using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class EpisodeFolderTransaction
    {
        public Guid ObjectId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public long? TransactionID { get; set; }
        public FolderTransactionTypeEnum? TransactionType { get; set; }
        public Guid? EpisodeFolderLocationRef { get; set; }
        public Guid? EpisodeFolderRef { get; set; }
        public Guid? TransactionUserRef { get; set; }

        #region Parent Relations
        public virtual ResSection EpisodeFolderLocation { get; set; }
        public virtual EpisodeFolder EpisodeFolder { get; set; }
        public virtual ResUser TransactionUser { get; set; }
        #endregion Parent Relations
    }
}