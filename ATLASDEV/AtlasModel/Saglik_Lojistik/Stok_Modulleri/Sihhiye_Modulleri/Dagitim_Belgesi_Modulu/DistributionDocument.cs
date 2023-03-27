using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DistributionDocument
    {
        public Guid ObjectId { get; set; }
        public Guid? DistributionDepStoreObjectID { get; set; }
        public bool? IsAutoDistribution { get; set; }

        #region Base Object Navigation Property
        public virtual StockAction StockAction { get; set; }
        #endregion Base Object Navigation Property
    }
}