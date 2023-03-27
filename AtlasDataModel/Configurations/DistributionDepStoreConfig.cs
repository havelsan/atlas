using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DistributionDepStoreConfig : IEntityTypeConfiguration<AtlasModel.DistributionDepStore>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DistributionDepStore> builder)
        {
            builder.ToTable("DISTRIBUTIONDEPSTORE");
            builder.HasKey(nameof(AtlasModel.DistributionDepStore.ObjectId));
            builder.Property(nameof(AtlasModel.DistributionDepStore.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.StockAction).WithOne().HasForeignKey<AtlasModel.StockAction>(p => p.ObjectId);
        }
    }
}