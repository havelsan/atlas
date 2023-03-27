using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockCensus
    {
        public Guid ObjectId { get; set; }
        public long? NewZeroCensus { get; set; }
        public long? ZeroCensus { get; set; }
        public long? OldZeroCensus { get; set; }
        public long? CardOrderNO { get; set; }
        public string StockCardName { get; set; }
        public long? MaterialCensus { get; set; }
        public long? OldMaterialCensus { get; set; }
        public long? NewMaterialCensus { get; set; }
        public long? NewCardAmount { get; set; }
        public long? NormalCardAmount { get; set; }
        public long? MaterialOldCensus { get; set; }
        public long? ZeroOldCensus { get; set; }
        public string DistributionType { get; set; }
        public long? TotalCardAmount { get; set; }
        public Guid? StockCardClassRef { get; set; }
        public Guid? StoreRef { get; set; }
        public Guid? AccountingTermRef { get; set; }
        public Guid? CardDrawerRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAction BaseAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual StockCardClass StockCardClass { get; set; }
        public virtual MainStoreDefinition Store { get; set; }
        public virtual AccountingTerm AccountingTerm { get; set; }
        #endregion Parent Relations
    }
}