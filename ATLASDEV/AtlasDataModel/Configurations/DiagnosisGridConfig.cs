using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DiagnosisGridConfig : IEntityTypeConfiguration<AtlasModel.DiagnosisGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DiagnosisGrid> builder)
        {
            builder.ToTable("DIAGNOSISGRID");
            builder.HasKey(nameof(AtlasModel.DiagnosisGrid.ObjectId));
            builder.Property(nameof(AtlasModel.DiagnosisGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DiagnosisGrid.FreeDiagnosis)).HasColumnName("FREEDIAGNOSIS").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DiagnosisGrid.DiagnoseDate)).HasColumnName("DIAGNOSEDATE");
            builder.Property(nameof(AtlasModel.DiagnosisGrid.DiagnosisType)).HasColumnName("DIAGNOSISTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DiagnosisGrid.EntryActionType)).HasColumnName("ENTRYACTIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DiagnosisGrid.AddToHistory)).HasColumnName("ADDTOHISTORY");
            builder.Property(nameof(AtlasModel.DiagnosisGrid.StartTimeOfInfectious)).HasColumnName("STARTTIMEOFINFECTIOUS");
            builder.Property(nameof(AtlasModel.DiagnosisGrid.DiagnosisDefinition)).HasColumnName("DIAGNOSISDEFINITION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.DiagnosisGrid.AllDiagnosisDefTeshis)).HasColumnName("ALLDIAGNOSISDEFTESHIS");
            builder.Property(nameof(AtlasModel.DiagnosisGrid.taniKodu)).HasColumnName("TANIKODU");
            builder.Property(nameof(AtlasModel.DiagnosisGrid.IsMainDiagnose)).HasColumnName("ISMAINDIAGNOSE");
            builder.Property(nameof(AtlasModel.DiagnosisGrid.SubactionProcedureRef)).HasColumnName("SUBACTIONPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DiagnosisGrid.EpisodeActionRef)).HasColumnName("EPISODEACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DiagnosisGrid.SKRSVakaTipiRef)).HasColumnName("SKRSVAKATIPI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DiagnosisGrid.EpisodeRef)).HasColumnName("EPISODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DiagnosisGrid.ImportantMedicalInformationRef)).HasColumnName("IMPORTANTMEDICALINFORMATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DiagnosisGrid.DiagnoseRef)).HasColumnName("DIAGNOSE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DiagnosisGrid.ResponsibleUserRef)).HasColumnName("RESPONSIBLEUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DiagnosisGrid.OzelDurumRef)).HasColumnName("OZELDURUM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DiagnosisGrid.ExaminationInfoByBransRef)).HasColumnName("EXAMINATIONINFOBYBRANS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DiagnosisGrid.ResponsibleDoctorRef)).HasColumnName("RESPONSIBLEDOCTOR").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.SubactionProcedure).WithOne().HasForeignKey<AtlasModel.DiagnosisGrid>(x => x.SubactionProcedureRef).IsRequired(false);
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.DiagnosisGrid>(x => x.EpisodeActionRef).IsRequired(false);
            builder.HasOne(t => t.Episode).WithOne().HasForeignKey<AtlasModel.DiagnosisGrid>(x => x.EpisodeRef).IsRequired(false);
            builder.HasOne(t => t.Diagnose).WithOne().HasForeignKey<AtlasModel.DiagnosisGrid>(x => x.DiagnoseRef).IsRequired(true);
            builder.HasOne(t => t.ResponsibleUser).WithOne().HasForeignKey<AtlasModel.DiagnosisGrid>(x => x.ResponsibleUserRef).IsRequired(false);
            builder.HasOne(t => t.OzelDurum).WithOne().HasForeignKey<AtlasModel.DiagnosisGrid>(x => x.OzelDurumRef).IsRequired(false);
            builder.HasOne(t => t.ResponsibleDoctor).WithOne().HasForeignKey<AtlasModel.DiagnosisGrid>(x => x.ResponsibleDoctorRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}