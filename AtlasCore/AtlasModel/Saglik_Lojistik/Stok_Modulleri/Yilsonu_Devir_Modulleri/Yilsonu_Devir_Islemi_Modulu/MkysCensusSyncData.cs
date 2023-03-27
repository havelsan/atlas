using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MkysCensusSyncData
    {
        public Guid ObjectId { get; set; }
        public decimal? YeniBirimFiyat { get; set; }
        public decimal? EskiBirimFiyat { get; set; }
        public int? YeniStokHareketId { get; set; }
        public int? EskiStokHareketId { get; set; }
        public Guid? StockTransactionGuid { get; set; }
        public Guid? StockGuid { get; set; }
        public Guid? StockCensusRef { get; set; }

        #region Parent Relations
        public virtual StockCensus StockCensus { get; set; }
        #endregion Parent Relations
    }
}