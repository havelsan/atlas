using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DailyDrugSchOrderDetail
    {
        public Guid ObjectId { get; set; }
        public Guid? DrugOrderDetailRef { get; set; }
        public Guid? DailyDrugSchOrderRef { get; set; }

        #region Parent Relations
        public virtual DrugOrderDetail DrugOrderDetail { get; set; }
        public virtual DailyDrugSchOrder DailyDrugSchOrder { get; set; }
        #endregion Parent Relations
    }
}