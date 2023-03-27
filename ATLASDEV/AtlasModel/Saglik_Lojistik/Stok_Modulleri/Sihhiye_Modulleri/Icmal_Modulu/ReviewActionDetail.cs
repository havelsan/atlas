using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ReviewActionDetail
    {
        public Guid ObjectId { get; set; }
        public Guid? StoreObjID { get; set; }
        public string StoreName { get; set; }
        public decimal? UnitPrice { get; set; }
        public Guid? StockTranactionGuid { get; set; }
        public Guid? BudgetTypeDefinitionRef { get; set; }

        #region Base Object Navigation Property
        public virtual StockActionDetailOut StockActionDetailOut { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual BudgetTypeDefinition BudgetTypeDefinition { get; set; }
        #endregion Parent Relations
    }
}