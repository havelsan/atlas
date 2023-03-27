using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockOut
    {
        public Guid ObjectId { get; set; }
        public bool? CreateRemote { get; set; }
        public Guid? ProductionDepStoreObjectID { get; set; }

        #region Base Object Navigation Property
        public virtual StockAction StockAction { get; set; }
        #endregion Base Object Navigation Property
    }
}