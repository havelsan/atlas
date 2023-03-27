using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockActionDateCorrectionConfig : IEntityTypeConfiguration<AtlasModel.StockActionDateCorrection>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockActionDateCorrection> builder)
        {
            builder.ToTable("STOCKACTIONDATECORRECTION");
            builder.HasKey(nameof(AtlasModel.StockActionDateCorrection.ObjectId));
            builder.Property(nameof(AtlasModel.StockActionDateCorrection.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockActionDateCorrection.OldStockCensusConsigned)).HasColumnName("OLDSTOCKCENSUSCONSIGNED").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.StockActionDateCorrection.OldStockCensusInheld)).HasColumnName("OLDSTOCKCENSUSINHELD").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.StockActionDateCorrection.UpdateLog)).HasColumnName("UPDATELOG").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.StockActionDateCorrection.ChangeTransactionDate)).HasColumnName("CHANGETRANSACTIONDATE");
            builder.Property(nameof(AtlasModel.StockActionDateCorrection.MainStoreDefinitionRef)).HasColumnName("MAINSTOREDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockActionDateCorrection.AccountingTermRef)).HasColumnName("ACCOUNTINGTERM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockActionDateCorrection.MaterialRef)).HasColumnName("MATERIAL").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseDataCorrection).WithOne().HasForeignKey<AtlasModel.BaseDataCorrection>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.MainStoreDefinition).WithOne().HasForeignKey<AtlasModel.StockActionDateCorrection>(x => x.MainStoreDefinitionRef).IsRequired(false);
            builder.HasOne(t => t.AccountingTerm).WithOne().HasForeignKey<AtlasModel.StockActionDateCorrection>(x => x.AccountingTermRef).IsRequired(false);
            builder.HasOne(t => t.Material).WithOne().HasForeignKey<AtlasModel.StockActionDateCorrection>(x => x.MaterialRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}