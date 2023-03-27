using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MainStoreDistributionDocConfig : IEntityTypeConfiguration<AtlasModel.MainStoreDistributionDoc>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MainStoreDistributionDoc> builder)
        {
            builder.ToTable("MAINSTOREDISTRIBUTIONDOC");
            builder.HasKey(nameof(AtlasModel.MainStoreDistributionDoc.ObjectId));
            builder.Property(nameof(AtlasModel.MainStoreDistributionDoc.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.StockAction).WithOne().HasForeignKey<AtlasModel.StockAction>(p => p.ObjectId);
        }
    }
}