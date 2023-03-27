using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MaterialConfig : IEntityTypeConfiguration<AtlasModel.Material>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Material> builder)
        {
            builder.ToTable("MATERIAL");
            builder.HasKey(nameof(AtlasModel.Material.ObjectId));
            builder.Property(nameof(AtlasModel.Material.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Material.MaterialPicture)).HasColumnName("MATERIALPICTURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Material.Description)).HasColumnName("DESCRIPTION").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.Material.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Material.AllowToGivePatient)).HasColumnName("ALLOWTOGIVEPATIENT");
            builder.Property(nameof(AtlasModel.Material.Code)).HasColumnName("CODE").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.Material.OriginalName)).HasColumnName("ORIGINALNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Material.Chargable)).HasColumnName("CHARGABLE");
            builder.Property(nameof(AtlasModel.Material.DividePriceToVolume)).HasColumnName("DIVIDEPRICETOVOLUME");
            builder.Property(nameof(AtlasModel.Material.AuctionDate)).HasColumnName("AUCTIONDATE");
            builder.Property(nameof(AtlasModel.Material.RegistrationAuctionNo)).HasColumnName("REGISTRATIONAUCTIONNO").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.Material.SetMedulaInfoByMultiplier)).HasColumnName("SETMEDULAINFOBYMULTIPLIER");
            builder.Property(nameof(AtlasModel.Material.ETKMDescription)).HasColumnName("ETKMDESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.Material.CreationDate)).HasColumnName("CREATIONDATE");
            builder.Property(nameof(AtlasModel.Material.MedulaMultiplier)).HasColumnName("MEDULAMULTIPLIER").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.Material.IsArmyDrug)).HasColumnName("ISARMYDRUG");
            builder.Property(nameof(AtlasModel.Material.CreateInMedulaDontSendState)).HasColumnName("CREATEINMEDULADONTSENDSTATE");
            builder.Property(nameof(AtlasModel.Material.IsRestrictedMaterial)).HasColumnName("ISRESTRICTEDMATERIAL");
            builder.Property(nameof(AtlasModel.Material.AccTrxAmountMultiplier)).HasColumnName("ACCTRXAMOUNTMULTIPLIER").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.Material.AccTrxUnitPriceDivider)).HasColumnName("ACCTRXUNITPRICEDIVIDER").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.Material.IsExpendableMaterial)).HasColumnName("ISEXPENDABLEMATERIAL");
            builder.Property(nameof(AtlasModel.Material.Barcode)).HasColumnName("BARCODE").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.Material.LicenceDate)).HasColumnName("LICENCEDATE");
            builder.Property(nameof(AtlasModel.Material.CurrentPrice)).HasColumnName("CURRENTPRICE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.Material.Discount)).HasColumnName("DISCOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.Material.LicenceNO)).HasColumnName("LICENCENO").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Material.LicencingOrganization)).HasColumnName("LICENCINGORGANIZATION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Material.BarcodeName)).HasColumnName("BARCODENAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Material.PackageAmount)).HasColumnName("PACKAGEAMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.Material.ProductNumber)).HasColumnName("PRODUCTNUMBER");
            builder.Property(nameof(AtlasModel.Material.SPTSDrugID)).HasColumnName("SPTSDRUGID");
            builder.Property(nameof(AtlasModel.Material.SPTSLicencingOrganizationID)).HasColumnName("SPTSLICENCINGORGANIZATIONID");
            builder.Property(nameof(AtlasModel.Material.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.Property(nameof(AtlasModel.Material.MaterialPricingType)).HasColumnName("MATERIALPRICINGTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Material.PurchaseDate)).HasColumnName("PURCHASEDATE");
            builder.Property(nameof(AtlasModel.Material.IsOldMaterial)).HasColumnName("ISOLDMATERIAL");
            builder.Property(nameof(AtlasModel.Material.MkysMalzemeKodu)).HasColumnName("MKYSMALZEMEKODU");
            builder.Property(nameof(AtlasModel.Material.MaterialTypeForInvoice)).HasColumnName("MATERIALTYPEFORINVOICE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Material.SUTAppendix)).HasColumnName("SUTAPPENDIX").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Material.ShowZeroOnDistributionInfo)).HasColumnName("SHOWZEROONDISTRIBUTIONINFO");
            builder.Property(nameof(AtlasModel.Material.IsIndividualTrackingRequired)).HasColumnName("ISINDIVIDUALTRACKINGREQUIRED");
            builder.Property(nameof(AtlasModel.Material.IsPackageExclusive)).HasColumnName("ISPACKAGEEXCLUSIVE");
            builder.Property(nameof(AtlasModel.Material.StorageConditions)).HasColumnName("STORAGECONDITIONS").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.Material.EstimatedTimeOfCheck)).HasColumnName("ESTIMATEDTIMEOFCHECK");
            builder.Property(nameof(AtlasModel.Material.IsTagNoRequired)).HasColumnName("ISTAGNOREQUIRED");
            builder.Property(nameof(AtlasModel.Material.PatientMaxDayOut)).HasColumnName("PATIENTMAXDAYOUT");
            builder.Property(nameof(AtlasModel.Material.OperatingShare)).HasColumnName("OPERATINGSHARE").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.Material.TresuryShare)).HasColumnName("TRESURYSHARE").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.Material.ShcekShare)).HasColumnName("SHCEKSHARE").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.Material.IsmId)).HasColumnName("ISMID");
            builder.Property(nameof(AtlasModel.Material.NotShownOnEpicrisisForm)).HasColumnName("NOTSHOWNONEPICRISISFORM");
            builder.Property(nameof(AtlasModel.Material.DailyStay)).HasColumnName("DAILYSTAY");
            builder.Property(nameof(AtlasModel.Material.MaterialCodeSequence)).HasColumnName("MATERIALCODESEQUENCE");
            builder.Property(nameof(AtlasModel.Material.SendSMS)).HasColumnName("SENDSMS");
            builder.Property(nameof(AtlasModel.Material.MaximumEstimatedTimeOfCheck)).HasColumnName("MAXIMUMESTIMATEDTIMEOFCHECK");
            builder.Property(nameof(AtlasModel.Material.WarningDayDuration)).HasColumnName("WARNINGDAYDURATION");
            builder.Property(nameof(AtlasModel.Material.MaterialTreeRef)).HasColumnName("MATERIALTREE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Material.StockCardRef)).HasColumnName("STOCKCARD").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Material.JoinedMaterialRef)).HasColumnName("JOINEDMATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Material.CreatedSiteRef)).HasColumnName("CREATEDSITE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Material.ProducerRef)).HasColumnName("PRODUCER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Material.GMDNCodeRef)).HasColumnName("GMDNCODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Material.MaterialPlaceOfUseDefRef)).HasColumnName("MATERIALPLACEOFUSEDEF").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Material.MaterialPurposeDefinitionRef)).HasColumnName("MATERIALPURPOSEDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Material.MKYSMalzemeRef)).HasColumnName("MKYSMALZEME").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.MaterialTree).WithOne().HasForeignKey<AtlasModel.Material>(x => x.MaterialTreeRef).IsRequired(true);
            builder.HasOne(t => t.StockCard).WithOne().HasForeignKey<AtlasModel.Material>(x => x.StockCardRef).IsRequired(false);
            builder.HasOne(t => t.JoinedMaterial).WithOne().HasForeignKey<AtlasModel.Material>(x => x.JoinedMaterialRef).IsRequired(false);
            builder.HasOne(t => t.Producer).WithOne().HasForeignKey<AtlasModel.Material>(x => x.ProducerRef).IsRequired(false);
            builder.HasOne(t => t.MKYSMalzeme).WithOne().HasForeignKey<AtlasModel.Material>(x => x.MKYSMalzemeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}