using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DistributionDepStoreMatConfig : IEntityTypeConfiguration<AtlasModel.DistributionDepStoreMat>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DistributionDepStoreMat> builder)
        {
            builder.ToTable("DISTRIBUTIONDEPSTOREMAT");
            builder.HasKey(nameof(AtlasModel.DistributionDepStoreMat.ObjectId));
            builder.Property(nameof(AtlasModel.DistributionDepStoreMat.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.StockActionDetailIn).WithOne().HasForeignKey<AtlasModel.StockActionDetailIn>(p => p.ObjectId);
        }
    }
}