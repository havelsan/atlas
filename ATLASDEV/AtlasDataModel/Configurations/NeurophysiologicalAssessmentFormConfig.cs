using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NeurophysiologicalAssessmentFormConfig : IEntityTypeConfiguration<AtlasModel.NeurophysiologicalAssessmentForm>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NeurophysiologicalAssessmentForm> builder)
        {
            builder.ToTable("NEUROPSYCHOLOGICALASSESS");
            builder.HasKey(nameof(AtlasModel.NeurophysiologicalAssessmentForm.ObjectId));
            builder.Property(nameof(AtlasModel.NeurophysiologicalAssessmentForm.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NeurophysiologicalAssessmentForm.BobathBrunstrum)).HasColumnName("BOBATHBRUNSTRUM").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.NeurophysiologicalAssessmentForm.ChedokeStrokeAssessmentScale)).HasColumnName("CHEDOKESTROKEASSESSMENTSCALE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.NeurophysiologicalAssessmentForm.Rood)).HasColumnName("ROOD").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.NeurophysiologicalAssessmentForm.Kabat)).HasColumnName("KABAT").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.NeurophysiologicalAssessmentForm.Vojta)).HasColumnName("VOJTA").HasMaxLength(1000);
            builder.HasOne(t => t.BaseAdditionalInfo).WithOne().HasForeignKey<AtlasModel.BaseAdditionalInfo>(p => p.ObjectId);
        }
    }
}