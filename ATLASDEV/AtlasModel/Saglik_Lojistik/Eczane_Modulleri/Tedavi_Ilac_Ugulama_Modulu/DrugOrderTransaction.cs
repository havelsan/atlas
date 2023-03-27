using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DrugOrderTransaction
    {
        public Guid ObjectId { get; set; }
        public double? Amount { get; set; }
        public DateTime? TransactionDate { get; set; }
        public Guid? DrugOrderRef { get; set; }
        public Guid? KScheduleMaterialRef { get; set; }

        #region Parent Relations
        public virtual DrugOrder DrugOrder { get; set; }
        public virtual KScheduleMaterial KScheduleMaterial { get; set; }
        #endregion Parent Relations
    }
}