using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ChangeStockLevelTypeConfig : IEntityTypeConfiguration<AtlasModel.ChangeStockLevelType>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ChangeStockLevelType> builder)
        {
            builder.ToTable("CHANGESTOCKLEVELTYPE");
            builder.HasKey(nameof(AtlasModel.ChangeStockLevelType.ObjectId));
            builder.Property(nameof(AtlasModel.ChangeStockLevelType.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.StockAction).WithOne().HasForeignKey<AtlasModel.StockAction>(p => p.ObjectId);
        }
    }
}