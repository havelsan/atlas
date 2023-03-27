using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MainStoreDefinition
    {
        public Guid ObjectId { get; set; }
        public MKYS_EButceTurEnum? MKYS_ButceTuru { get; set; }
        public MKYS_EEntegrasyonDurumuEnum? IntegrationScope { get; set; }
        public string StoreCode { get; set; }
        public int? StoreRecordNo { get; set; }
        public int? UnitRecordNo { get; set; }
        public Guid? AccountancyRef { get; set; }
        public Guid? GoodsAccountantRef { get; set; }
        public Guid? GoodsResponsibleRef { get; set; }
        public Guid? AccountManagerRef { get; set; }

        #region Base Object Navigation Property
        public virtual Store Store { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual Accountancy Accountancy { get; set; }
        public virtual ResUser GoodsAccountant { get; set; }
        public virtual ResUser GoodsResponsible { get; set; }
        public virtual ResUser AccountManager { get; set; }
        #endregion Parent Relations
    }
}