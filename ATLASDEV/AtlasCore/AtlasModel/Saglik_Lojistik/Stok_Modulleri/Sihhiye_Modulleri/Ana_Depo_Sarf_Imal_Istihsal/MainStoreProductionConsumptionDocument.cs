using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MainStoreProductionConsumptionDocument
    {
        public Guid ObjectId { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? FillingDate { get; set; }
        public DateTime? StartDate { get; set; }

        #region Base Object Navigation Property
        public virtual StockAction StockAction { get; set; }
        #endregion Base Object Navigation Property
    }
}