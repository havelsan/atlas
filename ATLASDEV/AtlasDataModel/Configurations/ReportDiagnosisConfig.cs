using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ReportDiagnosisConfig : IEntityTypeConfiguration<AtlasModel.ReportDiagnosis>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ReportDiagnosis> builder)
        {
            builder.ToTable("REPORTDIAGNOSIS");
            builder.HasKey(nameof(AtlasModel.ReportDiagnosis.ObjectId));
            builder.Property(nameof(AtlasModel.ReportDiagnosis.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ReportDiagnosis.DiagnoseDate)).HasColumnName("DIAGNOSEDATE");
            builder.Property(nameof(AtlasModel.ReportDiagnosis.DiagnoseRef)).HasColumnName("DIAGNOSE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ReportDiagnosis.EpisodeActionRef)).HasColumnName("EPISODEACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ReportDiagnosis.DiagnosisGridRef)).HasColumnName("DIAGNOSISGRID").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Diagnose).WithOne().HasForeignKey<AtlasModel.ReportDiagnosis>(x => x.DiagnoseRef).IsRequired(false);
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.ReportDiagnosis>(x => x.EpisodeActionRef).IsRequired(false);
            builder.HasOne(t => t.DiagnosisGrid).WithOne().HasForeignKey<AtlasModel.ReportDiagnosis>(x => x.DiagnosisGridRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}