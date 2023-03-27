using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class OccupationalAssessmentFormConfig : IEntityTypeConfiguration<AtlasModel.OccupationalAssessmentForm>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.OccupationalAssessmentForm> builder)
        {
            builder.ToTable("OCCUPATIONALASSESSMENTFORM");
            builder.HasKey(nameof(AtlasModel.OccupationalAssessmentForm.ObjectId));
            builder.Property(nameof(AtlasModel.OccupationalAssessmentForm.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.OccupationalAssessmentForm.CHART)).HasColumnName("CHART").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.OccupationalAssessmentForm.FCE)).HasColumnName("FCE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.OccupationalAssessmentForm.DASH)).HasColumnName("DASH").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.OccupationalAssessmentForm.POP)).HasColumnName("POP").HasMaxLength(1000);
            builder.HasOne(t => t.BaseAdditionalInfo).WithOne().HasForeignKey<AtlasModel.BaseAdditionalInfo>(p => p.ObjectId);
        }
    }
}