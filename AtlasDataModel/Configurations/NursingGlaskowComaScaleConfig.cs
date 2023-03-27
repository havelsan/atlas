using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingGlaskowComaScaleConfig : IEntityTypeConfiguration<AtlasModel.NursingGlaskowComaScale>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingGlaskowComaScale> builder)
        {
            builder.ToTable("NURSINGGLASKOWCOMASCALE");
            builder.HasKey(nameof(AtlasModel.NursingGlaskowComaScale.ObjectId));
            builder.Property(nameof(AtlasModel.NursingGlaskowComaScale.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingGlaskowComaScale.TotalScore)).HasColumnName("TOTALSCORE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingGlaskowComaScale.ActionDate)).HasColumnName("ACTIONDATE");
            builder.Property(nameof(AtlasModel.NursingGlaskowComaScale.Note)).HasColumnName("NOTE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.NursingGlaskowComaScale.OralAnswerRef)).HasColumnName("ORALANSWER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.NursingGlaskowComaScale.EyesRef)).HasColumnName("EYES").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.NursingGlaskowComaScale.MotorAnswerRef)).HasColumnName("MOTORANSWER").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseNursingDataEntry).WithOne().HasForeignKey<AtlasModel.BaseNursingDataEntry>(p => p.ObjectId);
        }
    }
}