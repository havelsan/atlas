using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ReturningDocument
    {
        public Guid ObjectId { get; set; }
        public DateTime? FillingDate { get; set; }
        public Guid? RepairObjectID { get; set; }
        public Guid? MaterialRepairObjectID { get; set; }
        public Guid? ReturnDepStoreObjectID { get; set; }
        public bool? IsChattelDocFlag { get; set; }
        public DateTime? BaseDateTime { get; set; }
        public string BaseNumber { get; set; }

        #region Base Object Navigation Property
        public virtual StockAction StockAction { get; set; }
        #endregion Base Object Navigation Property
    }
}