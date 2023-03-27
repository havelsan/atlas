using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseDentalEpisodeActionConfig : IEntityTypeConfiguration<AtlasModel.BaseDentalEpisodeAction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseDentalEpisodeAction> builder)
        {
            builder.ToTable("BASEDENTALEPISODEACTION");
            builder.HasKey(nameof(AtlasModel.BaseDentalEpisodeAction.ObjectId));
            builder.Property(nameof(AtlasModel.BaseDentalEpisodeAction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseDentalEpisodeAction.ToothNumbers)).HasColumnName("TOOTHNUMBERS").HasMaxLength(255);
            builder.HasOne(t => t.PhysicianApplication).WithOne().HasForeignKey<AtlasModel.PhysicianApplication>(p => p.ObjectId);
        }
    }
}