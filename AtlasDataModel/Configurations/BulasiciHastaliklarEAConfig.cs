using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BulasiciHastaliklarEAConfig : IEntityTypeConfiguration<AtlasModel.BulasiciHastaliklarEA>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BulasiciHastaliklarEA> builder)
        {
            builder.ToTable("BULASICIHASTALIKLAREA");
            builder.HasKey(nameof(AtlasModel.BulasiciHastaliklarEA.ObjectId));
            builder.Property(nameof(AtlasModel.BulasiciHastaliklarEA.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BulasiciHastaliklarEA.BulasiciHastalikVeriSetiRef)).HasColumnName("BULASICIHASTALIKVERISETI").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);
        }
    }
}