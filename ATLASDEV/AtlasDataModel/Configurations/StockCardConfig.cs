using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockCardConfig : IEntityTypeConfiguration<AtlasModel.StockCard>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockCard> builder)
        {
            builder.ToTable("STOCKCARD");
            builder.HasKey(nameof(AtlasModel.StockCard.ObjectId));
            builder.Property(nameof(AtlasModel.StockCard.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockCard.RepairCheckbox)).HasColumnName("REPAIRCHECKBOX");
            builder.Property(nameof(AtlasModel.StockCard.CardOrderNO)).HasColumnName("CARDORDERNO");
            builder.Property(nameof(AtlasModel.StockCard.CreationDate)).HasColumnName("CREATIONDATE");
            builder.Property(nameof(AtlasModel.StockCard.EnglishName)).HasColumnName("ENGLISHNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.StockCard.Status)).HasColumnName("STATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.StockCard.CardAmount)).HasColumnName("CARDAMOUNT");
            builder.Property(nameof(AtlasModel.StockCard.Description)).HasColumnName("DESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.StockCard.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.StockCard.CardPicture)).HasColumnName("CARDPICTURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCard.ProductionCheckbox)).HasColumnName("PRODUCTIONCHECKBOX");
            builder.Property(nameof(AtlasModel.StockCard.NATOStockNO)).HasColumnName("NATOSTOCKNO").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.StockCard.ETKMDescription)).HasColumnName("ETKMDESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.StockCard.OffereeName)).HasColumnName("OFFEREENAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.StockCard.StockMethod)).HasColumnName("STOCKMETHOD").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.StockCard.MainStoreCheckbox)).HasColumnName("MAINSTORECHECKBOX");
            builder.Property(nameof(AtlasModel.StockCard.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.Property(nameof(AtlasModel.StockCard.NATOStockNO_Shadow)).HasColumnName("NATOSTOCKNO_SHADOW");
            builder.Property(nameof(AtlasModel.StockCard.AllowLevelUpdateInSubStores)).HasColumnName("ALLOWLEVELUPDATEINSUBSTORES");
            builder.Property(nameof(AtlasModel.StockCard.StockCardClassRef)).HasColumnName("STOCKCARDCLASS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCard.DistributionTypeRef)).HasColumnName("DISTRIBUTIONTYPE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCard.CardDrawerRef)).HasColumnName("CARDDRAWER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCard.NATOGroupCodeRef)).HasColumnName("NATOGROUPCODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCard.GMDNCodeRef)).HasColumnName("GMDNCODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCard.JoinedStockCardRef)).HasColumnName("JOINEDSTOCKCARD").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCard.CreatedSiteRef)).HasColumnName("CREATEDSITE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCard.PurchaseGroupRef)).HasColumnName("PURCHASEGROUP").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCard.MalzemeGetDataRef)).HasColumnName("MALZEMEGETDATA").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.StockCardClass).WithOne().HasForeignKey<AtlasModel.StockCard>(x => x.StockCardClassRef).IsRequired(true);
            builder.HasOne(t => t.DistributionType).WithOne().HasForeignKey<AtlasModel.StockCard>(x => x.DistributionTypeRef).IsRequired(true);
            builder.HasOne(t => t.JoinedStockCard).WithOne().HasForeignKey<AtlasModel.StockCard>(x => x.JoinedStockCardRef).IsRequired(false);
            builder.HasOne(t => t.MalzemeGetData).WithOne().HasForeignKey<AtlasModel.StockCard>(x => x.MalzemeGetDataRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}