using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockCardClass
    {
        public Guid ObjectId { get; set; }
        public bool? IsGroup { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string QREF { get; set; }
        public string Name_Shadow { get; set; }
        public Guid? ParentStockCardClassRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual StockCardClass ParentStockCardClass { get; set; }
        #endregion Parent Relations
    }
}