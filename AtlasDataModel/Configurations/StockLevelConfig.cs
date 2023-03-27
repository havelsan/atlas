using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockLevelConfig : IEntityTypeConfiguration<AtlasModel.StockLevel>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockLevel> builder)
        {
            builder.ToTable("STOCKLEVEL");
            builder.HasKey(nameof(AtlasModel.StockLevel.ObjectId));
            builder.Property(nameof(AtlasModel.StockLevel.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockLevel.Amount)).HasColumnName("AMOUNT").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.StockLevel.StockRef)).HasColumnName("STOCK").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockLevel.StockLevelTypeRef)).HasColumnName("STOCKLEVELTYPE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Stock).WithOne().HasForeignKey<AtlasModel.StockLevel>(x => x.StockRef).IsRequired(true);
            builder.HasOne(t => t.StockLevelType).WithOne().HasForeignKey<AtlasModel.StockLevel>(x => x.StockLevelTypeRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}