using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseChattelDocument
    {
        public Guid ObjectId { get; set; }
        public string SpendingUnit { get; set; }
        public string SpendingUnitCode { get; set; }
        public string BaseNumber { get; set; }
        public DateTime? BaseDateTime { get; set; }

        #region Base Object Navigation Property
        public virtual StockAction StockAction { get; set; }
        #endregion Base Object Navigation Property
    }
}