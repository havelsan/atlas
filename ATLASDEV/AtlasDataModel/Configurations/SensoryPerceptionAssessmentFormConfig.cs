using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SensoryPerceptionAssessmentFormConfig : IEntityTypeConfiguration<AtlasModel.SensoryPerceptionAssessmentForm>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SensoryPerceptionAssessmentForm> builder)
        {
            builder.ToTable("SENSORYPERCEPTIONASSESST");
            builder.HasKey(nameof(AtlasModel.SensoryPerceptionAssessmentForm.ObjectId));
            builder.Property(nameof(AtlasModel.SensoryPerceptionAssessmentForm.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SensoryPerceptionAssessmentForm.ASIAImpairmentScale)).HasColumnName("ASIAIMPAIRMENTSCALE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SensoryPerceptionAssessmentForm.KurtzkeScale)).HasColumnName("KURTZKESCALE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SensoryPerceptionAssessmentForm.FuglMeyerTest)).HasColumnName("FUGLMEYERTEST").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SensoryPerceptionAssessmentForm.RivemeadIndex)).HasColumnName("RIVEMEADINDEX").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SensoryPerceptionAssessmentForm.MiniMentalStateExamination)).HasColumnName("MINIMENTALSTATEEXAMINATION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SensoryPerceptionAssessmentForm.StarCancellationTest)).HasColumnName("STARCANCELLATIONTEST").HasMaxLength(1000);
            builder.HasOne(t => t.BaseAdditionalInfo).WithOne().HasForeignKey<AtlasModel.BaseAdditionalInfo>(p => p.ObjectId);
        }
    }
}