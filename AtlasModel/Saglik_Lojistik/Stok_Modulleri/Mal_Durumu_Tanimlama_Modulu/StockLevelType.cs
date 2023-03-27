using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockLevelType
    {
        public Guid ObjectId { get; set; }
        public string Description { get; set; }
        public StockLevelTypeEnum? StockLevelTypeStatus { get; set; }
        public string Description_Shadow { get; set; }
        public Guid? ParentLevelRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual StockLevelType ParentLevel { get; set; }
        #endregion Parent Relations
    }
}