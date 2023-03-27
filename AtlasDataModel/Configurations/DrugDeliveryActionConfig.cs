using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DrugDeliveryActionConfig : IEntityTypeConfiguration<AtlasModel.DrugDeliveryAction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DrugDeliveryAction> builder)
        {
            builder.ToTable("DRUGDELIVERYACTION");
            builder.HasKey(nameof(AtlasModel.DrugDeliveryAction.ObjectId));
            builder.Property(nameof(AtlasModel.DrugDeliveryAction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);
        }
    }
}