using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SEPDiagnosisConfig : IEntityTypeConfiguration<AtlasModel.SEPDiagnosis>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SEPDiagnosis> builder)
        {
            builder.ToTable("SEPDIAGNOSIS");
            builder.HasKey(nameof(AtlasModel.SEPDiagnosis.ObjectId));
            builder.Property(nameof(AtlasModel.SEPDiagnosis.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SEPDiagnosis.Id)).HasColumnName("ID");
            builder.Property(nameof(AtlasModel.SEPDiagnosis.MedulaProcessNo)).HasColumnName("MEDULAPROCESSNO");
            builder.Property(nameof(AtlasModel.SEPDiagnosis.IsMainDiagnose)).HasColumnName("ISMAINDIAGNOSE");
            builder.Property(nameof(AtlasModel.SEPDiagnosis.DiagnosisType)).HasColumnName("DIAGNOSISTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SEPDiagnosis.MedulaResultCode)).HasColumnName("MEDULARESULTCODE");
            builder.Property(nameof(AtlasModel.SEPDiagnosis.MedulaResultMessage)).HasColumnName("MEDULARESULTMESSAGE").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.SEPDiagnosis.DiagnoseRef)).HasColumnName("DIAGNOSE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SEPDiagnosis.DiagnosisGridRef)).HasColumnName("DIAGNOSISGRID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SEPDiagnosis.SubEpisodeProtocolRef)).HasColumnName("SUBEPISODEPROTOCOL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SEPDiagnosis.OzelDurumRef)).HasColumnName("OZELDURUM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SEPDiagnosis.DiagnosisSubEpisodeRef)).HasColumnName("DIAGNOSISSUBEPISODE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Diagnose).WithOne().HasForeignKey<AtlasModel.SEPDiagnosis>(x => x.DiagnoseRef).IsRequired(true);
            builder.HasOne(t => t.DiagnosisGrid).WithOne().HasForeignKey<AtlasModel.SEPDiagnosis>(x => x.DiagnosisGridRef).IsRequired(false);
            builder.HasOne(t => t.SubEpisodeProtocol).WithOne().HasForeignKey<AtlasModel.SEPDiagnosis>(x => x.SubEpisodeProtocolRef).IsRequired(true);
            builder.HasOne(t => t.OzelDurum).WithOne().HasForeignKey<AtlasModel.SEPDiagnosis>(x => x.OzelDurumRef).IsRequired(false);
            builder.HasOne(t => t.DiagnosisSubEpisode).WithOne().HasForeignKey<AtlasModel.SEPDiagnosis>(x => x.DiagnosisSubEpisodeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}