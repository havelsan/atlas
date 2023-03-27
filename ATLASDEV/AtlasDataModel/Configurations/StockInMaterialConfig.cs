using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockInMaterialConfig : IEntityTypeConfiguration<AtlasModel.StockInMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockInMaterial> builder)
        {
            builder.ToTable("STOCKINMATERIAL");
            builder.HasKey(nameof(AtlasModel.StockInMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.StockInMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.StockActionDetailIn).WithOne().HasForeignKey<AtlasModel.StockActionDetailIn>(p => p.ObjectId);
        }
    }
}