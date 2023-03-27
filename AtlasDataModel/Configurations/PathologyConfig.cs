using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PathologyConfig : IEntityTypeConfiguration<AtlasModel.Pathology>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Pathology> builder)
        {
            builder.ToTable("PATHOLOGY");
            builder.HasKey(nameof(AtlasModel.Pathology.ObjectId));
            builder.Property(nameof(AtlasModel.Pathology.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Pathology.MacroscopyInspection)).HasColumnName("MACROSCOPYINSPECTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Pathology.MaterialPrtNoPrefix)).HasColumnName("MATERIALPRTNOPREFIX").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.Pathology.ResultEntryDate)).HasColumnName("RESULTENTRYDATE");
            builder.Property(nameof(AtlasModel.Pathology.AdditionalInfo)).HasColumnName("ADDITIONALINFO").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.Pathology.BlockCount)).HasColumnName("BLOCKCOUNT");
            builder.Property(nameof(AtlasModel.Pathology.IntraoperativeConsultation)).HasColumnName("INTRAOPERATIVECONSULTATION");
            builder.Property(nameof(AtlasModel.Pathology.LamCount)).HasColumnName("LAMCOUNT");
            builder.Property(nameof(AtlasModel.Pathology.FreeDiagnoseEntry)).HasColumnName("FREEDIAGNOSEENTRY").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.Pathology.ReasonForRepeatation)).HasColumnName("REASONFORREPEATATION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.Pathology.MaterialPrtNoPostFix)).HasColumnName("MATERIALPRTNOPOSTFIX").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.Pathology.ProcedureDate)).HasColumnName("PROCEDUREDATE");
            builder.Property(nameof(AtlasModel.Pathology.MatPrtNoString)).HasColumnName("MATPRTNOSTRING").HasMaxLength(15);
            builder.Property(nameof(AtlasModel.Pathology.ReportDate)).HasColumnName("REPORTDATE");
            builder.Property(nameof(AtlasModel.Pathology.SeqNo)).HasColumnName("SEQNO");
            builder.Property(nameof(AtlasModel.Pathology.ApproveDate)).HasColumnName("APPROVEDATE");
            builder.Property(nameof(AtlasModel.Pathology.Liquid)).HasColumnName("LIQUID");
            builder.Property(nameof(AtlasModel.Pathology.MaterialResponsible)).HasColumnName("MATERIALRESPONSIBLE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Pathology.RemoteSpecialDoctor)).HasColumnName("REMOTESPECIALDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Pathology.HasSpecialProcedures)).HasColumnName("HASSPECIALPROCEDURES");
            builder.Property(nameof(AtlasModel.Pathology.birim)).HasColumnName("BIRIM");
            builder.Property(nameof(AtlasModel.Pathology.raporTakipNo)).HasColumnName("RAPORTAKIPNO");
            builder.Property(nameof(AtlasModel.Pathology.SubMatPrtNoSuffixNo)).HasColumnName("SUBMATPRTNOSUFFIXNO");
            builder.Property(nameof(AtlasModel.Pathology.SubMatPrtNoSuffixString)).HasColumnName("SUBMATPRTNOSUFFIXSTRING").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.Pathology.drAnesteziTescilNo)).HasColumnName("DRANESTEZITESCILNO");
            builder.Property(nameof(AtlasModel.Pathology.Description)).HasColumnName("DESCRIPTION").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.Pathology.SendedMaterial)).HasColumnName("SENDEDMATERIAL").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Pathology.TechnicianNote)).HasColumnName("TECHNICIANNOTE").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.Pathology.NumberOfMaterials)).HasColumnName("NUMBEROFMATERIALS");
            builder.Property(nameof(AtlasModel.Pathology.SendToApproveDate)).HasColumnName("SENDTOAPPROVEDATE");
            builder.Property(nameof(AtlasModel.Pathology.IsBiopsy)).HasColumnName("ISBIOPSY");
            builder.Property(nameof(AtlasModel.Pathology.IsCytology)).HasColumnName("ISCYTOLOGY");
            builder.Property(nameof(AtlasModel.Pathology.PathologyArchiveNo)).HasColumnName("PATHOLOGYARCHIVENO").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.Pathology.BiopsySeqNo)).HasColumnName("BIOPSYSEQNO");
            builder.Property(nameof(AtlasModel.Pathology.CytologySeqNo)).HasColumnName("CYTOLOGYSEQNO");
            builder.Property(nameof(AtlasModel.Pathology.SpecialDoctorRef)).HasColumnName("SPECIALDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Pathology.AssistantDoctorRef)).HasColumnName("ASSISTANTDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Pathology.PathologyRequestRef)).HasColumnName("PATHOLOGYREQUEST").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Pathology.ResponsibleDoctorRef)).HasColumnName("RESPONSIBLEDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Pathology.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Pathology.OzelDurumRef)).HasColumnName("OZELDURUM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Pathology.AyniFarkliKesiRef)).HasColumnName("AYNIFARKLIKESI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Pathology.SagSolRef)).HasColumnName("SAGSOL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Pathology.PathologyAdditionalReportRef)).HasColumnName("PATHOLOGYADDITIONALREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Pathology.PathologyPanicAlertRef)).HasColumnName("PATHOLOGYPANICALERT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.SpecialDoctor).WithOne().HasForeignKey<AtlasModel.Pathology>(x => x.SpecialDoctorRef).IsRequired(false);
            builder.HasOne(t => t.AssistantDoctor).WithOne().HasForeignKey<AtlasModel.Pathology>(x => x.AssistantDoctorRef).IsRequired(false);
            builder.HasOne(t => t.PathologyRequest).WithOne().HasForeignKey<AtlasModel.Pathology>(x => x.PathologyRequestRef).IsRequired(false);
            builder.HasOne(t => t.ResponsibleDoctor).WithOne().HasForeignKey<AtlasModel.Pathology>(x => x.ResponsibleDoctorRef).IsRequired(false);
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.Pathology>(x => x.ResUserRef).IsRequired(false);
            builder.HasOne(t => t.OzelDurum).WithOne().HasForeignKey<AtlasModel.Pathology>(x => x.OzelDurumRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}