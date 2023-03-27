using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class OrthesisProsthesisRequestConfig : IEntityTypeConfiguration<AtlasModel.OrthesisProsthesisRequest>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.OrthesisProsthesisRequest> builder)
        {
            builder.ToTable("ORTHESISPROSTHESISREQUEST");
            builder.HasKey(nameof(AtlasModel.OrthesisProsthesisRequest.ObjectId));
            builder.Property(nameof(AtlasModel.OrthesisProsthesisRequest.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.OrthesisProsthesisRequest.Image)).HasColumnName("IMAGE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.OrthesisProsthesisRequest.TotalDescription)).HasColumnName("TOTALDESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.OrthesisProsthesisRequest.ProtocolNo)).HasColumnName("PROTOCOLNO");
            builder.Property(nameof(AtlasModel.OrthesisProsthesisRequest.FinancialDepartmentNot)).HasColumnName("FINANCIALDEPARTMENTNOT").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.OrthesisProsthesisRequest.Description)).HasColumnName("DESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.OrthesisProsthesisRequest.ChiefTechnicianNote)).HasColumnName("CHIEFTECHNICIANNOTE").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.OrthesisProsthesisRequest.TechnicianNote)).HasColumnName("TECHNICIANNOTE").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.OrthesisProsthesisRequest.ProcessDate)).HasColumnName("PROCESSDATE");
            builder.Property(nameof(AtlasModel.OrthesisProsthesisRequest.IsInRequest)).HasColumnName("ISINREQUEST");
            builder.Property(nameof(AtlasModel.OrthesisProsthesisRequest.RequestReason)).HasColumnName("REQUESTREASON").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.OrthesisProsthesisRequest.WarrantyNote)).HasColumnName("WARRANTYNOTE").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.OrthesisProsthesisRequest.RequesterUsr)).HasColumnName("REQUESTERUSR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.OrthesisProsthesisRequest.ReasonForExaminationRef)).HasColumnName("REASONFOREXAMINATION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ReasonForExamination).WithOne().HasForeignKey<AtlasModel.OrthesisProsthesisRequest>(x => x.ReasonForExaminationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}