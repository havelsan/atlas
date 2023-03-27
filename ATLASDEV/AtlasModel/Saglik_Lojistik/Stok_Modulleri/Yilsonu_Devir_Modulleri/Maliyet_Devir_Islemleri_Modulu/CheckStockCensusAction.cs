using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class CheckStockCensusAction
    {
        public Guid ObjectId { get; set; }
        public bool? IsChecked { get; set; }
        public bool? IsUpdateCreationDate { get; set; }
        public Guid? MainStoreDefinitionRef { get; set; }
        public Guid? AccountingTermRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAction BaseAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual MainStoreDefinition MainStoreDefinition { get; set; }
        public virtual AccountingTerm AccountingTerm { get; set; }
        #endregion Parent Relations
    }
}