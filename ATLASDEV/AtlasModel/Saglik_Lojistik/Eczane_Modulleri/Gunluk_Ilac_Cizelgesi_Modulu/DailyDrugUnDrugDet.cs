using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DailyDrugUnDrugDet
    {
        public Guid ObjectId { get; set; }
        public Guid? DailyDrugUnDrugRef { get; set; }
        public Guid? DrugOrderDetailRef { get; set; }

        #region Parent Relations
        public virtual DailyDrugUnDrug DailyDrugUnDrug { get; set; }
        public virtual DrugOrderDetail DrugOrderDetail { get; set; }
        #endregion Parent Relations
    }
}