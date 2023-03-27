using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MainStoreProductionConsumptionDocumentMaterialConfig : IEntityTypeConfiguration<AtlasModel.MainStoreProductionConsumptionDocumentMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MainStoreProductionConsumptionDocumentMaterial> builder)
        {
            builder.ToTable("MSCONSUMPTIONDOCUMENTMAT");
            builder.HasKey(nameof(AtlasModel.MainStoreProductionConsumptionDocumentMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.MainStoreProductionConsumptionDocumentMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MainStoreProductionConsumptionDocumentMaterial.Existing)).HasColumnName("EXISTING").HasColumnType("FLOAT");
            builder.HasOne(t => t.StockActionDetailOut).WithOne().HasForeignKey<AtlasModel.StockActionDetailOut>(p => p.ObjectId);
        }
    }
}