using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class CreatingEpicrisisConfig : IEntityTypeConfiguration<AtlasModel.CreatingEpicrisis>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.CreatingEpicrisis> builder)
        {
            builder.ToTable("CREATINGEPICRISIS");
            builder.HasKey(nameof(AtlasModel.CreatingEpicrisis.ObjectId));
            builder.Property(nameof(AtlasModel.CreatingEpicrisis.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.CreatingEpicrisis.PROCEDURE)).HasColumnName("PROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.CreatingEpicrisis.Suggestion)).HasColumnName("SUGGESTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.CreatingEpicrisis.AUTOBIOGRAPHY)).HasColumnName("AUTOBIOGRAPHY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.CreatingEpicrisis.Report)).HasColumnName("REPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.CreatingEpicrisis.PHYSICALEXAMINATION)).HasColumnName("PHYSICALEXAMINATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.CreatingEpicrisis.COMPLAINTANDSTORY)).HasColumnName("COMPLAINTANDSTORY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.CreatingEpicrisis.ReportNo)).HasColumnName("REPORTNO");
            builder.Property(nameof(AtlasModel.CreatingEpicrisis.STORY)).HasColumnName("STORY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.CreatingEpicrisis.SYMPTOM)).HasColumnName("SYMPTOM").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);
        }
    }
}