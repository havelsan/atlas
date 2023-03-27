using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseDentalEpisodeActionDiagnosisGridConfig : IEntityTypeConfiguration<AtlasModel.BaseDentalEpisodeActionDiagnosisGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseDentalEpisodeActionDiagnosisGrid> builder)
        {
            builder.ToTable("BASEDENTALEPISODACTDIAGGRD");
            builder.HasKey(nameof(AtlasModel.BaseDentalEpisodeActionDiagnosisGrid.ObjectId));
            builder.Property(nameof(AtlasModel.BaseDentalEpisodeActionDiagnosisGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseDentalEpisodeActionDiagnosisGrid.DentalPosition)).HasColumnName("DENTALPOSITION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.BaseDentalEpisodeActionDiagnosisGrid.ToothNumber)).HasColumnName("TOOTHNUMBER").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.BaseDentalEpisodeActionDiagnosisGrid.ExternalID)).HasColumnName("EXTERNALID").HasMaxLength(255);
            builder.HasOne(t => t.DiagnosisGrid).WithOne().HasForeignKey<AtlasModel.DiagnosisGrid>(p => p.ObjectId);
        }
    }
}