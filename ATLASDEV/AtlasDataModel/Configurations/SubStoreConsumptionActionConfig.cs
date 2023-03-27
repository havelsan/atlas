using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SubStoreConsumptionActionConfig : IEntityTypeConfiguration<AtlasModel.SubStoreConsumptionAction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SubStoreConsumptionAction> builder)
        {
            builder.ToTable("SUBSTORECONSUMPTIONACTION");
            builder.HasKey(nameof(AtlasModel.SubStoreConsumptionAction.ObjectId));
            builder.Property(nameof(AtlasModel.SubStoreConsumptionAction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.StockAction).WithOne().HasForeignKey<AtlasModel.StockAction>(p => p.ObjectId);
        }
    }
}