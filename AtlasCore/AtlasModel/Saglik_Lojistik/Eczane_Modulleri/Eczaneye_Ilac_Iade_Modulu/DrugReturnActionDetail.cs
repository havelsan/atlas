using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DrugReturnActionDetail
    {
        public Guid ObjectId { get; set; }
        public double? SendAmount { get; set; }
        public double? Amount { get; set; }
        public string DrugName { get; set; }
        public Guid? DrugReturnActionRef { get; set; }
        public Guid? DrugOrderTransactionRef { get; set; }

        #region Parent Relations
        public virtual DrugReturnAction DrugReturnAction { get; set; }
        public virtual DrugOrderTransaction DrugOrderTransaction { get; set; }
        #endregion Parent Relations
    }
}