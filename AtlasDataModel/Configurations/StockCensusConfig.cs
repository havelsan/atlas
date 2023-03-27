using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockCensusConfig : IEntityTypeConfiguration<AtlasModel.StockCensus>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockCensus> builder)
        {
            builder.ToTable("STOCKCENSUS");
            builder.HasKey(nameof(AtlasModel.StockCensus.ObjectId));
            builder.Property(nameof(AtlasModel.StockCensus.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockCensus.NewZeroCensus)).HasColumnName("NEWZEROCENSUS");
            builder.Property(nameof(AtlasModel.StockCensus.ZeroCensus)).HasColumnName("ZEROCENSUS");
            builder.Property(nameof(AtlasModel.StockCensus.OldZeroCensus)).HasColumnName("OLDZEROCENSUS");
            builder.Property(nameof(AtlasModel.StockCensus.CardOrderNO)).HasColumnName("CARDORDERNO");
            builder.Property(nameof(AtlasModel.StockCensus.StockCardName)).HasColumnName("STOCKCARDNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.StockCensus.MaterialCensus)).HasColumnName("MATERIALCENSUS");
            builder.Property(nameof(AtlasModel.StockCensus.OldMaterialCensus)).HasColumnName("OLDMATERIALCENSUS");
            builder.Property(nameof(AtlasModel.StockCensus.NewMaterialCensus)).HasColumnName("NEWMATERIALCENSUS");
            builder.Property(nameof(AtlasModel.StockCensus.NewCardAmount)).HasColumnName("NEWCARDAMOUNT");
            builder.Property(nameof(AtlasModel.StockCensus.NormalCardAmount)).HasColumnName("NORMALCARDAMOUNT");
            builder.Property(nameof(AtlasModel.StockCensus.MaterialOldCensus)).HasColumnName("MATERIALOLDCENSUS");
            builder.Property(nameof(AtlasModel.StockCensus.ZeroOldCensus)).HasColumnName("ZEROOLDCENSUS");
            builder.Property(nameof(AtlasModel.StockCensus.DistributionType)).HasColumnName("DISTRIBUTIONTYPE").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.StockCensus.TotalCardAmount)).HasColumnName("TOTALCARDAMOUNT");
            builder.Property(nameof(AtlasModel.StockCensus.StockCardClassRef)).HasColumnName("STOCKCARDCLASS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCensus.StoreRef)).HasColumnName("STORE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCensus.AccountingTermRef)).HasColumnName("ACCOUNTINGTERM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCensus.CardDrawerRef)).HasColumnName("CARDDRAWER").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseAction).WithOne().HasForeignKey<AtlasModel.BaseAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.StockCardClass).WithOne().HasForeignKey<AtlasModel.StockCensus>(x => x.StockCardClassRef).IsRequired(false);
            builder.HasOne(t => t.Store).WithOne().HasForeignKey<AtlasModel.StockCensus>(x => x.StoreRef).IsRequired(false);
            builder.HasOne(t => t.AccountingTerm).WithOne().HasForeignKey<AtlasModel.StockCensus>(x => x.AccountingTermRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}