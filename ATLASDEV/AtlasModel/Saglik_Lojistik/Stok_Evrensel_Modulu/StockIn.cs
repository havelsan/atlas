using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockIn
    {
        public Guid ObjectId { get; set; }
        public Guid? DrugReturnActionRef { get; set; }

        #region Base Object Navigation Property
        public virtual StockAction StockAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual DrugReturnAction DrugReturnAction { get; set; }
        #endregion Parent Relations
    }
}