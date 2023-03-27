using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockCensusDetail
    {
        public Guid ObjectId { get; set; }
        public decimal? TotalInHeld { get; set; }
        public decimal? TotalInPrice { get; set; }
        public long? CardOrderNo { get; set; }
        public decimal? TotalIn { get; set; }
        public decimal? Inheld { get; set; }
        public decimal? Consigned { get; set; }
        public decimal? YearCensus { get; set; }
        public StockCardStatusEnum? OldStockCardStatus { get; set; }
        public decimal? Used { get; set; }
        public decimal? TotalOut { get; set; }
        public decimal? TotalOutPrice { get; set; }
        public long? OldCardOrderNo { get; set; }
        public decimal? YearCensusPrice { get; set; }
        public Guid? StockCardRef { get; set; }
        public Guid? StockCensusRef { get; set; }
        public Guid? AccountingTermRef { get; set; }
        public Guid? StockRef { get; set; }

        #region Parent Relations
        public virtual StockCard StockCard { get; set; }
        public virtual StockCensus StockCensus { get; set; }
        public virtual AccountingTerm AccountingTerm { get; set; }
        public virtual Stock Stock { get; set; }
        #endregion Parent Relations
    }
}