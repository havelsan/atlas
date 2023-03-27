using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MainStoreProductionConsumptionDocumentMaterial
    {
        public Guid ObjectId { get; set; }
        public double? Existing { get; set; }

        #region Base Object Navigation Property
        public virtual StockActionDetailOut StockActionDetailOut { get; set; }
        #endregion Base Object Navigation Property
    }
}