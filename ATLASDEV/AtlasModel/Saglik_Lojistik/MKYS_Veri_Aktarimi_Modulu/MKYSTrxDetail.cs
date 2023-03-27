using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MKYSTrxDetail
    {
        public Guid ObjectId { get; set; }
        public decimal? Amount { get; set; }
        public Guid? InMKYSTrxRef { get; set; }
        public Guid? OutMKYSTrxRef { get; set; }

        #region Parent Relations
        public virtual MKYSTrx InMKYSTrx { get; set; }
        public virtual MKYSTrx OutMKYSTrx { get; set; }
        #endregion Parent Relations
    }
}