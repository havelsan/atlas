using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AmputeeAssessmentFormConfig : IEntityTypeConfiguration<AtlasModel.AmputeeAssessmentForm>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AmputeeAssessmentForm> builder)
        {
            builder.ToTable("AMPUTEEASSESSMENTFORM");
            builder.HasKey(nameof(AtlasModel.AmputeeAssessmentForm.ObjectId));
            builder.Property(nameof(AtlasModel.AmputeeAssessmentForm.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AmputeeAssessmentForm.TrinityExperienceScale)).HasColumnName("TRINITYEXPERIENCESCALE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.AmputeeAssessmentForm.ProstheticIpperExtremityIndex)).HasColumnName("PROSTHETICIPPEREXTREMITYINDEX").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.AmputeeAssessmentForm.TheSicknessImpactProfile)).HasColumnName("THESICKNESSIMPACTPROFILE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.AmputeeAssessmentForm.GroningenScale)).HasColumnName("GRONINGENSCALE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.AmputeeAssessmentForm.MGFCScale)).HasColumnName("MGFCSCALE").HasMaxLength(1000);
            builder.HasOne(t => t.BaseAdditionalInfo).WithOne().HasForeignKey<AtlasModel.BaseAdditionalInfo>(p => p.ObjectId);
        }
    }
}