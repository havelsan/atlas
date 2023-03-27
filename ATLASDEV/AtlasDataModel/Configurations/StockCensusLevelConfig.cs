using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockCensusLevelConfig : IEntityTypeConfiguration<AtlasModel.StockCensusLevel>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockCensusLevel> builder)
        {
            builder.ToTable("STOCKCENSUSLEVEL");
            builder.HasKey(nameof(AtlasModel.StockCensusLevel.ObjectId));
            builder.Property(nameof(AtlasModel.StockCensusLevel.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockCensusLevel.Amount)).HasColumnName("AMOUNT").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.StockCensusLevel.StockLevelTypeRef)).HasColumnName("STOCKLEVELTYPE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockCensusLevel.StockCensusDetailRef)).HasColumnName("STOCKCENSUSDETAIL").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.StockLevelType).WithOne().HasForeignKey<AtlasModel.StockCensusLevel>(x => x.StockLevelTypeRef).IsRequired(true);
            builder.HasOne(t => t.StockCensusDetail).WithOne().HasForeignKey<AtlasModel.StockCensusLevel>(x => x.StockCensusDetailRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}