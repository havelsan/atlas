using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InPatientRtfBySpecialityConfig : IEntityTypeConfiguration<AtlasModel.InPatientRtfBySpeciality>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InPatientRtfBySpeciality> builder)
        {
            builder.ToTable("INPATIENTRTFBYSPECIALITY");
            builder.HasKey(nameof(AtlasModel.InPatientRtfBySpeciality.ObjectId));
            builder.Property(nameof(AtlasModel.InPatientRtfBySpeciality.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.InPatientRtfBySpeciality.Rtf)).HasColumnName("RTF").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InPatientRtfBySpeciality.Title)).HasColumnName("TITLE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.InPatientRtfBySpeciality.RTFDefinitionsBySpecialityRef)).HasColumnName("RTFDEFINITIONSBYSPECIALITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InPatientRtfBySpeciality.SubEpisodeRef)).HasColumnName("SUBEPISODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InPatientRtfBySpeciality.EpisodeActionRef)).HasColumnName("EPISODEACTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.SubEpisode).WithOne().HasForeignKey<AtlasModel.InPatientRtfBySpeciality>(x => x.SubEpisodeRef).IsRequired(false);
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.InPatientRtfBySpeciality>(x => x.EpisodeActionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}