using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DistributionDocumentMaterialConfig : IEntityTypeConfiguration<AtlasModel.DistributionDocumentMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DistributionDocumentMaterial> builder)
        {
            builder.ToTable("DISTRIBUTIONDOCUMENTMAT");
            builder.HasKey(nameof(AtlasModel.DistributionDocumentMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.DistributionDocumentMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DistributionDocumentMaterial.AcceptedAmount)).HasColumnName("ACCEPTEDAMOUNT").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.DistributionDocumentMaterial.DistributionDepStoreMatID)).HasColumnName("DISTRIBUTIONDEPSTOREMATID").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.StockActionDetailOut).WithOne().HasForeignKey<AtlasModel.StockActionDetailOut>(p => p.ObjectId);
        }
    }
}