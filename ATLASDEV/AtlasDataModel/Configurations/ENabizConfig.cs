using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ENabizConfig : IEntityTypeConfiguration<AtlasModel.ENabiz>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ENabiz> builder)
        {
            builder.ToTable("ENABIZ");
            builder.HasKey(nameof(AtlasModel.ENabiz.ObjectId));
            builder.Property(nameof(AtlasModel.ENabiz.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ENabiz.PackageID)).HasColumnName("PACKAGEID");
            builder.Property(nameof(AtlasModel.ENabiz.PackageName)).HasColumnName("PACKAGENAME").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.ENabiz.EpisodeActionRef)).HasColumnName("EPISODEACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ENabiz.SubEpisodeRef)).HasColumnName("SUBEPISODE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.ENabiz>(x => x.EpisodeActionRef).IsRequired(false);
            builder.HasOne(t => t.SubEpisode).WithOne().HasForeignKey<AtlasModel.ENabiz>(x => x.SubEpisodeRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}