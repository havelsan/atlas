using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ScoliosisAssessmentFormConfig : IEntityTypeConfiguration<AtlasModel.ScoliosisAssessmentForm>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ScoliosisAssessmentForm> builder)
        {
            builder.ToTable("SCOLIOSISASSESSMENTFORM");
            builder.HasKey(nameof(AtlasModel.ScoliosisAssessmentForm.ObjectId));
            builder.Property(nameof(AtlasModel.ScoliosisAssessmentForm.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ScoliosisAssessmentForm.ChestPosture)).HasColumnName("CHESTPOSTURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ScoliosisAssessmentForm.ShoulderPosture)).HasColumnName("SHOULDERPOSTURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ScoliosisAssessmentForm.ScapulaPosture)).HasColumnName("SCAPULAPOSTURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ScoliosisAssessmentForm.SpinePosture)).HasColumnName("SPINEPOSTURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ScoliosisAssessmentForm.LegPosture)).HasColumnName("LEGPOSTURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ScoliosisAssessmentForm.FeetPosture)).HasColumnName("FEETPOSTURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ScoliosisAssessmentForm.LegsLength)).HasColumnName("LEGSLENGTH").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ScoliosisAssessmentForm.HeadPosture)).HasColumnName("HEADPOSTURE").HasColumnType("NUMBER(10)");
            builder.HasOne(t => t.BaseAdditionalInfo).WithOne().HasForeignKey<AtlasModel.BaseAdditionalInfo>(p => p.ObjectId);
        }
    }
}