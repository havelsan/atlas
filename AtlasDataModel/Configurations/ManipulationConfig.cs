using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ManipulationConfig : IEntityTypeConfiguration<AtlasModel.Manipulation>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Manipulation> builder)
        {
            builder.ToTable("MANIPULATION");
            builder.HasKey(nameof(AtlasModel.Manipulation.ObjectId));
            builder.Property(nameof(AtlasModel.Manipulation.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Manipulation.ReturnReason)).HasColumnName("RETURNREASON").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Manipulation.TechnicianNote)).HasColumnName("TECHNICIANNOTE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Manipulation.PreInformation)).HasColumnName("PREINFORMATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Manipulation.ProcedureReport)).HasColumnName("PROCEDUREREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Manipulation.ProtocolNo)).HasColumnName("PROTOCOLNO");
            builder.Property(nameof(AtlasModel.Manipulation.ReasonToContinue)).HasColumnName("REASONTOCONTINUE").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.Manipulation.IsPatientApprovalFormGiven)).HasColumnName("ISPATIENTAPPROVALFORMGIVEN");
            builder.Property(nameof(AtlasModel.Manipulation.IsGunubirlikTakip)).HasColumnName("ISGUNUBIRLIKTAKIP");
            builder.Property(nameof(AtlasModel.Manipulation.ReportPDF)).HasColumnName("REPORTPDF").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Manipulation.Report)).HasColumnName("REPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Manipulation.ManipulationRequestRef)).HasColumnName("MANIPULATIONREQUEST").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Manipulation.TechnicianRef)).HasColumnName("TECHNICIAN").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Manipulation.SorumluDoktorRef)).HasColumnName("SORUMLUDOKTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Manipulation.OzelDurumRef)).HasColumnName("OZELDURUM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Manipulation.ResponsiblePersonnelRef)).HasColumnName("RESPONSIBLEPERSONNEL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Manipulation.RequestedByUserRef)).HasColumnName("REQUESTEDBYUSER").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ManipulationRequest).WithOne().HasForeignKey<AtlasModel.Manipulation>(x => x.ManipulationRequestRef).IsRequired(false);
            builder.HasOne(t => t.Technician).WithOne().HasForeignKey<AtlasModel.Manipulation>(x => x.TechnicianRef).IsRequired(false);
            builder.HasOne(t => t.SorumluDoktor).WithOne().HasForeignKey<AtlasModel.Manipulation>(x => x.SorumluDoktorRef).IsRequired(false);
            builder.HasOne(t => t.OzelDurum).WithOne().HasForeignKey<AtlasModel.Manipulation>(x => x.OzelDurumRef).IsRequired(false);
            builder.HasOne(t => t.ResponsiblePersonnel).WithOne().HasForeignKey<AtlasModel.Manipulation>(x => x.ResponsiblePersonnelRef).IsRequired(false);
            builder.HasOne(t => t.RequestedByUser).WithOne().HasForeignKey<AtlasModel.Manipulation>(x => x.RequestedByUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}