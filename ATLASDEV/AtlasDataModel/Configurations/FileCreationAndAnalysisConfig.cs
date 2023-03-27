using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class FileCreationAndAnalysisConfig : IEntityTypeConfiguration<AtlasModel.FileCreationAndAnalysis>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.FileCreationAndAnalysis> builder)
        {
            builder.ToTable("FILECREATIONANDANALYSIS");
            builder.HasKey(nameof(AtlasModel.FileCreationAndAnalysis.ObjectId));
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.InIncompleteArea)).HasColumnName("ININCOMPLETEAREA");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.InArchive)).HasColumnName("INARCHIVE");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.OnlyYear)).HasColumnName("ONLYYEAR").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HMHASTAYAKINI)).HasColumnName("HMHASTAYAKINI");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.Room)).HasColumnName("ROOM");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.AdliVaka)).HasColumnName("ADLIVAKA");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HMHEMSHIZ)).HasColumnName("HMHEMSHIZ");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HMHASTYAKFORM)).HasColumnName("HMHASTYAKFORM");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HMHEMSBAKPL)).HasColumnName("HMHEMSBAKPL");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HMSIVIZFORM)).HasColumnName("HMSIVIZFORM");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HMDIGER)).HasColumnName("HMDIGER");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HMACIKLAMA)).HasColumnName("HMACIKLAMA").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HKMESANFORM)).HasColumnName("HKMESANFORM");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HKGUNMUSKAG)).HasColumnName("HKGUNMUSKAG");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HKANESTEZI)).HasColumnName("HKANESTEZI");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HKONAM)).HasColumnName("HKONAM");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HKCERTARONFORM)).HasColumnName("HKCERTARONFORM");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HKTABHASTBIL)).HasColumnName("HKTABHASTBIL");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HKSAGKURRAP)).HasColumnName("HKSAGKURRAP");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HKEPIKRIZ)).HasColumnName("HKEPIKRIZ");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HKHASTTAB)).HasColumnName("HKHASTTAB");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HKDUSRISOL)).HasColumnName("HKDUSRISOL");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HKGUCCERKONT)).HasColumnName("HKGUCCERKONT");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HKDIGER)).HasColumnName("HKDIGER");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HKACIKLAMA)).HasColumnName("HKACIKLAMA").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.SEKHASGIRKAG)).HasColumnName("SEKHASGIRKAG");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.SEKACIKLAMA)).HasColumnName("SEKACIKLAMA").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.HMHEMGOZFORM)).HasColumnName("HMHEMGOZFORM");
            builder.Property(nameof(AtlasModel.FileCreationAndAnalysis.FileLocationRef)).HasColumnName("FILELOCATION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.FileLocation).WithOne().HasForeignKey<AtlasModel.FileCreationAndAnalysis>(x => x.FileLocationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}