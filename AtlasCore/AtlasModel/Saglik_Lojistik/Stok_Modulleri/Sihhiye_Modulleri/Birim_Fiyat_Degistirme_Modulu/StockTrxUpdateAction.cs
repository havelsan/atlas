using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockTrxUpdateAction
    {
        public Guid ObjectId { get; set; }
        public decimal? NewUnitPrice { get; set; }
        public Guid? MainStoreDefinitionRef { get; set; }
        public Guid? StockCardRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAction BaseAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual MainStoreDefinition MainStoreDefinition { get; set; }
        public virtual StockCard StockCard { get; set; }
        #endregion Parent Relations
    }
}