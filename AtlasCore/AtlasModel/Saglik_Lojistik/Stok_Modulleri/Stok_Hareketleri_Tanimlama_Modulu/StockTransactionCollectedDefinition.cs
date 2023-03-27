using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockTransactionCollectedDefinition
    {
        public Guid ObjectId { get; set; }
        public Guid? CheckedStockTransactionDefRef { get; set; }
        public Guid? StockTransactionDefinitionRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual StockTransactionDefinition CheckedStockTransactionDef { get; set; }
        public virtual StockTransactionDefinition StockTransactionDefinition { get; set; }
        #endregion Parent Relations
    }
}