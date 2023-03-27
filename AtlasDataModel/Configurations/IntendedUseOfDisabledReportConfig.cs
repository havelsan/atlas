using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class IntendedUseOfDisabledReportConfig : IEntityTypeConfiguration<AtlasModel.IntendedUseOfDisabledReport>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.IntendedUseOfDisabledReport> builder)
        {
            builder.ToTable("INTENDEDUSEOFDISABLEDREPOR");
            builder.HasKey(nameof(AtlasModel.IntendedUseOfDisabledReport.ObjectId));
            builder.Property(nameof(AtlasModel.IntendedUseOfDisabledReport.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.IntendedUseOfDisabledReport.DisabledIdentityCardEvalution)).HasColumnName("DISABLEDIDENTITYCARDEVALUTION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.IntendedUseOfDisabledReport.OtherEvaluation)).HasColumnName("OTHEREVALUATION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.IntendedUseOfDisabledReport.OtherExplanation)).HasColumnName("OTHEREXPLANATION").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.IntendedUseOfDisabledReport.LawNo2022Evaluation)).HasColumnName("LAWNO2022EVALUATION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.IntendedUseOfDisabledReport.EducationEvaluation)).HasColumnName("EDUCATIONEVALUATION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.IntendedUseOfDisabledReport.EmploymentEvaluation)).HasColumnName("EMPLOYMENTEVALUATION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.IntendedUseOfDisabledReport.SocialAidEvaluation)).HasColumnName("SOCIALAIDEVALUATION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.IntendedUseOfDisabledReport.OrtesisProsthesEquEvaluation)).HasColumnName("ORTESISPROSTHESEQUEVALUATION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.IntendedUseOfDisabledReport.DisabledChaiEvaluation)).HasColumnName("DISABLEDCHAIEVALUATION").HasColumnType("NUMBER(10)");
        }
    }
}