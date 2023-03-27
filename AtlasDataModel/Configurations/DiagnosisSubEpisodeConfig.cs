using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DiagnosisSubEpisodeConfig : IEntityTypeConfiguration<AtlasModel.DiagnosisSubEpisode>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DiagnosisSubEpisode> builder)
        {
            builder.ToTable("DIAGNOSISSUBEPISODE");
            builder.HasKey(nameof(AtlasModel.DiagnosisSubEpisode.ObjectId));
            builder.Property(nameof(AtlasModel.DiagnosisSubEpisode.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DiagnosisSubEpisode.DiagnosisGridRef)).HasColumnName("DIAGNOSISGRID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DiagnosisSubEpisode.SubEpisodeRef)).HasColumnName("SUBEPISODE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DiagnosisGrid).WithOne().HasForeignKey<AtlasModel.DiagnosisSubEpisode>(x => x.DiagnosisGridRef).IsRequired(true);
            builder.HasOne(t => t.SubEpisode).WithOne().HasForeignKey<AtlasModel.DiagnosisSubEpisode>(x => x.SubEpisodeRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}