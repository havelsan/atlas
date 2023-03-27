using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EpisodeActionWithDiagnosisConfig : IEntityTypeConfiguration<AtlasModel.EpisodeActionWithDiagnosis>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EpisodeActionWithDiagnosis> builder)
        {
            builder.ToTable("EPISODEACTIONWITHDIAGNOSIS");
            builder.HasKey(nameof(AtlasModel.EpisodeActionWithDiagnosis.ObjectId));
            builder.Property(nameof(AtlasModel.EpisodeActionWithDiagnosis.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);
        }
    }
}