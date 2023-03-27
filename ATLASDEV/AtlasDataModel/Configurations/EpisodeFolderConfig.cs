using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EpisodeFolderConfig : IEntityTypeConfiguration<AtlasModel.EpisodeFolder>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EpisodeFolder> builder)
        {
            builder.ToTable("EPISODEFOLDER");
            builder.HasKey(nameof(AtlasModel.EpisodeFolder.ObjectId));
            builder.Property(nameof(AtlasModel.EpisodeFolder.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.EpisodeFolder.FolderStatus)).HasColumnName("FOLDERSTATUS");
            builder.Property(nameof(AtlasModel.EpisodeFolder.EpisodeFolderID)).HasColumnName("EPISODEFOLDERID");
            builder.Property(nameof(AtlasModel.EpisodeFolder.FolderInformation)).HasColumnName("FOLDERINFORMATION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.EpisodeFolder.ManuelArchiveNo)).HasColumnName("MANUELARCHIVENO");
            builder.Property(nameof(AtlasModel.EpisodeFolder.PatientFolderRef)).HasColumnName("PATIENTFOLDER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EpisodeFolder.EpisodeFolderLocationRef)).HasColumnName("EPISODEFOLDERLOCATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EpisodeFolder.LastEpisodeFolderTransactionRef)).HasColumnName("LASTEPISODEFOLDERTRANSACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EpisodeFolder.FileCreationAndAnalysisRef)).HasColumnName("FILECREATIONANDANALYSIS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EpisodeFolder.MyEpisodeRef)).HasColumnName("MYEPISODE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.PatientFolder).WithOne().HasForeignKey<AtlasModel.EpisodeFolder>(x => x.PatientFolderRef).IsRequired(false);
            builder.HasOne(t => t.EpisodeFolderLocation).WithOne().HasForeignKey<AtlasModel.EpisodeFolder>(x => x.EpisodeFolderLocationRef).IsRequired(false);
            builder.HasOne(t => t.LastEpisodeFolderTransaction).WithOne().HasForeignKey<AtlasModel.EpisodeFolder>(x => x.LastEpisodeFolderTransactionRef).IsRequired(false);
            builder.HasOne(t => t.FileCreationAndAnalysis).WithOne().HasForeignKey<AtlasModel.EpisodeFolder>(x => x.FileCreationAndAnalysisRef).IsRequired(false);
            builder.HasOne(t => t.MyEpisode).WithOne().HasForeignKey<AtlasModel.EpisodeFolder>(x => x.MyEpisodeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}