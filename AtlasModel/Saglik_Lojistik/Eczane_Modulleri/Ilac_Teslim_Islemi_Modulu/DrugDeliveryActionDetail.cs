using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DrugDeliveryActionDetail
    {
        public Guid ObjectId { get; set; }
        public string DrugName { get; set; }
        public double? ResDose { get; set; }
        public Guid? DrugDeliveryActionRef { get; set; }
        public Guid? DrugOrderTransactionRef { get; set; }

        #region Parent Relations
        public virtual DrugDeliveryAction DrugDeliveryAction { get; set; }
        public virtual DrugOrderTransaction DrugOrderTransaction { get; set; }
        #endregion Parent Relations
    }
}