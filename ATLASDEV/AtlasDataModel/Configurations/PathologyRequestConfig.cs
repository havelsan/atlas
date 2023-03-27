using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PathologyRequestConfig : IEntityTypeConfiguration<AtlasModel.PathologyRequest>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PathologyRequest> builder)
        {
            builder.ToTable("PATHOLOGYREQUEST");
            builder.HasKey(nameof(AtlasModel.PathologyRequest.ObjectId));
            builder.Property(nameof(AtlasModel.PathologyRequest.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PathologyRequest.AcceptionNote)).HasColumnName("ACCEPTIONNOTE").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.PathologyRequest.AcceptionDate)).HasColumnName("ACCEPTIONDATE");
            builder.Property(nameof(AtlasModel.PathologyRequest.MaterialResponsible)).HasColumnName("MATERIALRESPONSIBLE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.PathologyRequest.Description)).HasColumnName("DESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.PathologyRequest.RequestMaterialNumber)).HasColumnName("REQUESTMATERIALNUMBER");
            builder.Property(nameof(AtlasModel.PathologyRequest.SpecialDoctorRef)).HasColumnName("SPECIALDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PathologyRequest.ResponsibleDoctorRef)).HasColumnName("RESPONSIBLEDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PathologyRequest.RequestDoctorRef)).HasColumnName("REQUESTDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PathologyRequest.AssistantDoctorRef)).HasColumnName("ASSISTANTDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PathologyRequest.ReasonForPathologyRejectionRef)).HasColumnName("REASONFORPATHOLOGYREJECTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PathologyRequest.RequesterReferableHospitalRef)).HasColumnName("REQUESTERREFERABLEHOSPITAL").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.SpecialDoctor).WithOne().HasForeignKey<AtlasModel.PathologyRequest>(x => x.SpecialDoctorRef).IsRequired(false);
            builder.HasOne(t => t.ResponsibleDoctor).WithOne().HasForeignKey<AtlasModel.PathologyRequest>(x => x.ResponsibleDoctorRef).IsRequired(false);
            builder.HasOne(t => t.RequestDoctor).WithOne().HasForeignKey<AtlasModel.PathologyRequest>(x => x.RequestDoctorRef).IsRequired(false);
            builder.HasOne(t => t.AssistantDoctor).WithOne().HasForeignKey<AtlasModel.PathologyRequest>(x => x.AssistantDoctorRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}