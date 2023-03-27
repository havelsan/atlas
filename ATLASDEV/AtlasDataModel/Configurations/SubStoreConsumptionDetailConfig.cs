using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SubStoreConsumptionDetailConfig : IEntityTypeConfiguration<AtlasModel.SubStoreConsumptionDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SubStoreConsumptionDetail> builder)
        {
            builder.ToTable("SUBSTORECONSUMPTIONDET");
            builder.HasKey(nameof(AtlasModel.SubStoreConsumptionDetail.ObjectId));
            builder.Property(nameof(AtlasModel.SubStoreConsumptionDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.StockActionDetailOut).WithOne().HasForeignKey<AtlasModel.StockActionDetailOut>(p => p.ObjectId);
        }
    }
}