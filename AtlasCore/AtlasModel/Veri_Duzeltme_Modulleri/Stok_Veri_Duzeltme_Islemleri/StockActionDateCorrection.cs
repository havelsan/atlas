using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockActionDateCorrection
    {
        public Guid ObjectId { get; set; }
        public decimal? OldStockCensusConsigned { get; set; }
        public decimal? OldStockCensusInheld { get; set; }
        public string UpdateLog { get; set; }
        public DateTime? ChangeTransactionDate { get; set; }
        public Guid? MainStoreDefinitionRef { get; set; }
        public Guid? AccountingTermRef { get; set; }
        public Guid? MaterialRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseDataCorrection BaseDataCorrection { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual MainStoreDefinition MainStoreDefinition { get; set; }
        public virtual AccountingTerm AccountingTerm { get; set; }
        public virtual Material Material { get; set; }
        #endregion Parent Relations
    }
}