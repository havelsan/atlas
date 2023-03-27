using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PsychologicExaminationConfig : IEntityTypeConfiguration<AtlasModel.PsychologicExamination>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PsychologicExamination> builder)
        {
            builder.ToTable("PSYCHOLOGICEXAMINATION");
            builder.HasKey(nameof(AtlasModel.PsychologicExamination.ObjectId));
            builder.Property(nameof(AtlasModel.PsychologicExamination.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PsychologicExamination.ConsultationRequestStatement)).HasColumnName("CONSULTATIONREQUESTSTATEMENT").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.PsychologicExamination.ConsultationResult)).HasColumnName("CONSULTATIONRESULT").HasMaxLength(1000);
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);
        }
    }
}