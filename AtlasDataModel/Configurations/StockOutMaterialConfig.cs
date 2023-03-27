using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockOutMaterialConfig : IEntityTypeConfiguration<AtlasModel.StockOutMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockOutMaterial> builder)
        {
            builder.ToTable("STOCKOUTMATERIAL");
            builder.HasKey(nameof(AtlasModel.StockOutMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.StockOutMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.StockActionDetailOut).WithOne().HasForeignKey<AtlasModel.StockActionDetailOut>(p => p.ObjectId);
        }
    }
}