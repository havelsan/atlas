using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockCard
    {
        public Guid ObjectId { get; set; }
        public bool? RepairCheckbox { get; set; }
        public long? CardOrderNO { get; set; }
        public DateTime? CreationDate { get; set; }
        public string EnglishName { get; set; }
        public StockCardStatusEnum? Status { get; set; }
        public long? CardAmount { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public Guid? CardPicture { get; set; }
        public bool? ProductionCheckbox { get; set; }
        public string NATOStockNO { get; set; }
        public string ETKMDescription { get; set; }
        public string OffereeName { get; set; }
        public StockMethodEnum? StockMethod { get; set; }
        public bool? MainStoreCheckbox { get; set; }
        public string Name_Shadow { get; set; }
        public string NATOStockNO_Shadow { get; set; }
        public bool? AllowLevelUpdateInSubStores { get; set; }
        public Guid? StockCardClassRef { get; set; }
        public Guid? DistributionTypeRef { get; set; }
        public Guid? CardDrawerRef { get; set; }
        public Guid? NATOGroupCodeRef { get; set; }
        public Guid? GMDNCodeRef { get; set; }
        public Guid? JoinedStockCardRef { get; set; }
        public Guid? CreatedSiteRef { get; set; }
        public Guid? PurchaseGroupRef { get; set; }
        public Guid? MalzemeGetDataRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual StockCardClass StockCardClass { get; set; }
        public virtual DistributionTypeDefinition DistributionType { get; set; }
        public virtual StockCard JoinedStockCard { get; set; }
        public virtual MalzemeGetData MalzemeGetData { get; set; }
        #endregion Parent Relations
    }
}