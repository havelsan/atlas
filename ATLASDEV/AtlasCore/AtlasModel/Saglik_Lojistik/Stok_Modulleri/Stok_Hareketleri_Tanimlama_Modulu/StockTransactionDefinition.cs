using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockTransactionDefinition
    {
        public Guid ObjectId { get; set; }
        public string ShortDescription { get; set; }
        public ReferenceLetterEnum? ReferenceLetter { get; set; }
        public MaintainLevelCodeEnum? DestinationMaintainLevelCode { get; set; }
        public bool? IsStockDown { get; set; }
        public string RegistrationPrefix { get; set; }
        public string StartDateTimeFormat { get; set; }
        public bool? IsFixedAsset { get; set; }
        public string Description { get; set; }
        public TransactionTypeEnum? TransactionType { get; set; }
        public bool? AskForDateTime { get; set; }
        public string Description_Shadow { get; set; }
        public MaintainLevelCodeEnum? MaintainLevelCode { get; set; }
        public bool? IsTotalReport { get; set; }
        public string EndDateTimeFormat { get; set; }
        public bool? IsMinMaxLevelCalc { get; set; }
        public Guid? ChangedStockLevelTypeRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual StockLevelType ChangedStockLevelType { get; set; }
        #endregion Parent Relations
    }
}