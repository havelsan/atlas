using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class APRTrx
    {
        public Guid ObjectId { get; set; }
        public decimal? Price { get; set; }
        public Guid? AccountPayableReceivableRef { get; set; }
        public Guid? AccountDocumentRef { get; set; }
        public Guid? APRTrxTypeRef { get; set; }

        #region Parent Relations
        public virtual AccountPayableReceivable AccountPayableReceivable { get; set; }
        public virtual AccountDocument AccountDocument { get; set; }
        #endregion Parent Relations
    }
}