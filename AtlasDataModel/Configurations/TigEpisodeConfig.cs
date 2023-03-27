using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class TigEpisodeConfig : IEntityTypeConfiguration<AtlasModel.TigEpisode>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.TigEpisode> builder)
        {
            builder.ToTable("TIGEPISODE");
            builder.HasKey(nameof(AtlasModel.TigEpisode.ObjectId));
            builder.Property(nameof(AtlasModel.TigEpisode.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.TigEpisode.ResourceGuid)).HasColumnName("RESOURCEGUID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.TigEpisode.DischargeDate)).HasColumnName("DISCHARGEDATE");
            builder.Property(nameof(AtlasModel.TigEpisode.DoctorGuid)).HasColumnName("DOCTORGUID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.TigEpisode.DischargerDoctorGuid)).HasColumnName("DISCHARGERDOCTORGUID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.TigEpisode.BranchGuid)).HasColumnName("BRANCHGUID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.TigEpisode.AppointmentStatus)).HasColumnName("APPOINTMENTSTATUS");
            builder.Property(nameof(AtlasModel.TigEpisode.EpicrisisStatus)).HasColumnName("EPICRISISSTATUS");
            builder.Property(nameof(AtlasModel.TigEpisode.PathologyRequestStatus)).HasColumnName("PATHOLOGYREQUESTSTATUS");
            builder.Property(nameof(AtlasModel.TigEpisode.PathologyReportStatus)).HasColumnName("PATHOLOGYREPORTSTATUS");
            builder.Property(nameof(AtlasModel.TigEpisode.InvoiceStatus)).HasColumnName("INVOICESTATUS");
            builder.Property(nameof(AtlasModel.TigEpisode.Cancelled)).HasColumnName("CANCELLED");
            builder.Property(nameof(AtlasModel.TigEpisode.InpatientDate)).HasColumnName("INPATIENTDATE");
            builder.Property(nameof(AtlasModel.TigEpisode.PatientType)).HasColumnName("PATIENTTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.TigEpisode.InPatientProtocolNo)).HasColumnName("INPATIENTPROTOCOLNO").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.TigEpisode.Surgeries)).HasColumnName("SURGERIES").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.TigEpisode.XMLStatus)).HasColumnName("XMLSTATUS");
            builder.Property(nameof(AtlasModel.TigEpisode.XMLCreationDate)).HasColumnName("XMLCREATIONDATE");
            builder.Property(nameof(AtlasModel.TigEpisode.CodingStatus)).HasColumnName("CODINGSTATUS");
            builder.Property(nameof(AtlasModel.TigEpisode.CodingDate)).HasColumnName("CODINGDATE");
            builder.Property(nameof(AtlasModel.TigEpisode.Description)).HasColumnName("DESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.TigEpisode.EpisodeGuid)).HasColumnName("EPISODEGUID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.TigEpisode.PatientGuid)).HasColumnName("PATIENTGUID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.TigEpisode.SEPGuid)).HasColumnName("SEPGUID").HasMaxLength(36).IsFixedLength();
        }
    }
}