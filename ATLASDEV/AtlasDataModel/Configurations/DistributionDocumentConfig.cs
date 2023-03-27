using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DistributionDocumentConfig : IEntityTypeConfiguration<AtlasModel.DistributionDocument>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DistributionDocument> builder)
        {
            builder.ToTable("DISTRIBUTIONDOCUMENT");
            builder.HasKey(nameof(AtlasModel.DistributionDocument.ObjectId));
            builder.Property(nameof(AtlasModel.DistributionDocument.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DistributionDocument.DistributionDepStoreObjectID)).HasColumnName("DISTRIBUTIONDEPSTOREOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DistributionDocument.IsAutoDistribution)).HasColumnName("ISAUTODISTRIBUTION");
            builder.HasOne(t => t.StockAction).WithOne().HasForeignKey<AtlasModel.StockAction>(p => p.ObjectId);
        }
    }
}