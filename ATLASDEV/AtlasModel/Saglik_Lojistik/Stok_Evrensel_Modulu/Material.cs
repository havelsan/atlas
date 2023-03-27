using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Material
    {
        public Guid ObjectId { get; set; }
        public Guid? MaterialPicture { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool? AllowToGivePatient { get; set; }
        public string Code { get; set; }
        public string OriginalName { get; set; }
        public bool? Chargable { get; set; }
        public bool? DividePriceToVolume { get; set; }
        public DateTime? AuctionDate { get; set; }
        public string RegistrationAuctionNo { get; set; }
        public bool? SetMedulaInfoByMultiplier { get; set; }
        public string ETKMDescription { get; set; }
        public DateTime? CreationDate { get; set; }
        public double? MedulaMultiplier { get; set; }
        public bool? IsArmyDrug { get; set; }
        public bool? CreateInMedulaDontSendState { get; set; }
        public bool? IsRestrictedMaterial { get; set; }
        public double? AccTrxAmountMultiplier { get; set; }
        public double? AccTrxUnitPriceDivider { get; set; }
        public bool? IsExpendableMaterial { get; set; }
        public string Barcode { get; set; }
        public DateTime? LicenceDate { get; set; }
        public double? CurrentPrice { get; set; }
        public double? Discount { get; set; }
        public string LicenceNO { get; set; }
        public LicencingOrganizationEnum? LicencingOrganization { get; set; }
        public string BarcodeName { get; set; }
        public double? PackageAmount { get; set; }
        public long? ProductNumber { get; set; }
        public long? SPTSDrugID { get; set; }
        public int? SPTSLicencingOrganizationID { get; set; }
        public string Name_Shadow { get; set; }
        public MaterialPricingTypeEnum? MaterialPricingType { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public bool? IsOldMaterial { get; set; }
        public int? MkysMalzemeKodu { get; set; }
        public MaterialTypeForInvoiceEnum? MaterialTypeForInvoice { get; set; }
        public SUTMalzemeEKEnum? SUTAppendix { get; set; }
        public bool? ShowZeroOnDistributionInfo { get; set; }
        public bool? IsIndividualTrackingRequired { get; set; }
        public bool? IsPackageExclusive { get; set; }
        public string StorageConditions { get; set; }
        public int? EstimatedTimeOfCheck { get; set; }
        public bool? IsTagNoRequired { get; set; }
        public int? PatientMaxDayOut { get; set; }
        public decimal? OperatingShare { get; set; }
        public decimal? TresuryShare { get; set; }
        public decimal? ShcekShare { get; set; }
        public string IsmId { get; set; }
        public bool? NotShownOnEpicrisisForm { get; set; }
        public bool? DailyStay { get; set; }
        public long? MaterialCodeSequence { get; set; }
        public bool? SendSMS { get; set; }
        public int? MaximumEstimatedTimeOfCheck { get; set; }
        public int? WarningDayDuration { get; set; }
        public Guid? MaterialTreeRef { get; set; }
        public Guid? StockCardRef { get; set; }
        public Guid? JoinedMaterialRef { get; set; }
        public Guid? CreatedSiteRef { get; set; }
        public Guid? ProducerRef { get; set; }
        public Guid? GMDNCodeRef { get; set; }
        public Guid? MaterialPlaceOfUseDefRef { get; set; }
        public Guid? MaterialPurposeDefinitionRef { get; set; }
        public Guid? MKYSMalzemeRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual MaterialTreeDefinition MaterialTree { get; set; }
        public virtual StockCard StockCard { get; set; }
        public virtual Material JoinedMaterial { get; set; }
        public virtual Producer Producer { get; set; }
        public virtual MalzemeGetData MKYSMalzeme { get; set; }
        #endregion Parent Relations
    }
}