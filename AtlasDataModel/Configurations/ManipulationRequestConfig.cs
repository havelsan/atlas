using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ManipulationRequestConfig : IEntityTypeConfiguration<AtlasModel.ManipulationRequest>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ManipulationRequest> builder)
        {
            builder.ToTable("MANIPULATIONREQUEST");
            builder.HasKey(nameof(AtlasModel.ManipulationRequest.ObjectId));
            builder.Property(nameof(AtlasModel.ManipulationRequest.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ManipulationRequest.ProtocolNo)).HasColumnName("PROTOCOLNO");
            builder.Property(nameof(AtlasModel.ManipulationRequest.IsPatientApprovalFormGiven)).HasColumnName("ISPATIENTAPPROVALFORMGIVEN");
            builder.Property(nameof(AtlasModel.ManipulationRequest.PreInformation)).HasColumnName("PREINFORMATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ManipulationRequest.ReportNo)).HasColumnName("REPORTNO");
            builder.Property(nameof(AtlasModel.ManipulationRequest.ReportStartDate)).HasColumnName("REPORTSTARTDATE");
            builder.Property(nameof(AtlasModel.ManipulationRequest.ReportEndDate)).HasColumnName("REPORTENDDATE");
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);
        }
    }
}