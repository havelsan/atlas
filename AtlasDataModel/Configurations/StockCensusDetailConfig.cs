using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockCensusDetailConfig : IEntityTypeConfiguration<AtlasModel.StockCensusDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockCensusDetail> builder)
        {
            builder.ToTable("STOCKCENSUSDETAIL");
            builder.HasKey(nameof(AtlasModel.StockCensusDetail.ObjectId));
            builder.Property(nameof(AtlasModel.StockCensusDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockCensusDetail.TotalInHeld)).HasColumnName("TOTALINHELD").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.StockCensusDetail.TotalInPrice)).HasColumnName("TOTALINPRICE").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.StockCensusDetail.CardOrderNo)).HasColumnName("CARDORDERNO");
            builder.Property(nameof(AtlasModel.StockCensusDetail.TotalIn)).HasColumnName("TOTALIN").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.StockCensusDetail.Inheld)).HasColumnName("INHELD").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.StockCensusDetail.Consigned)).HasColumnName("CONSIGNED").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.StockCensusDetail.YearCensus)).HasColumnName("YEARCENSUS").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.StockCensusDetail.OldStockCardStatus)).HasColumnName("OLDSTOCKCARDSTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.StockCensusDetail.Used)).HasColumnName("USED").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.StockCensusDetail.TotalOut)).HasColumnName("TOTALOUT").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.StockCensusDetail.TotalOutPrice)).HasColumnName("TOTALOUTPRICE").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.StockCensusDetail.OldCardOrderNo)).HasColumnName("OLDCARDORDERNO");
            builder.Property(nameof(AtlasModel.StockCensusDetail.YearCensusPrice)).HasColumnName("YEARCENSUSPRICE").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.StockCensusDetail.StockCardRef)).HasColumnName("STOCKCARD").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCensusDetail.StockCensusRef)).HasColumnName("STOCKCENSUS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCensusDetail.AccountingTermRef)).HasColumnName("ACCOUNTINGTERM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCensusDetail.StockRef)).HasColumnName("STOCK").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.StockCard).WithOne().HasForeignKey<AtlasModel.StockCensusDetail>(x => x.StockCardRef).IsRequired(false);
            builder.HasOne(t => t.StockCensus).WithOne().HasForeignKey<AtlasModel.StockCensusDetail>(x => x.StockCensusRef).IsRequired(false);
            builder.HasOne(t => t.AccountingTerm).WithOne().HasForeignKey<AtlasModel.StockCensusDetail>(x => x.AccountingTermRef).IsRequired(false);
            builder.HasOne(t => t.Stock).WithOne().HasForeignKey<AtlasModel.StockCensusDetail>(x => x.StockRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}