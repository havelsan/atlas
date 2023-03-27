using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ConsultationConfig : IEntityTypeConfiguration<AtlasModel.Consultation>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Consultation> builder)
        {
            builder.ToTable("CONSULTATION");
            builder.HasKey(nameof(AtlasModel.Consultation.ObjectId));
            builder.Property(nameof(AtlasModel.Consultation.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Consultation.ConsultationResultAndOffers)).HasColumnName("CONSULTATIONRESULTANDOFFERS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Consultation.drAnesteziTescilNo)).HasColumnName("DRANESTEZITESCILNO");
            builder.Property(nameof(AtlasModel.Consultation.InPatientBed)).HasColumnName("INPATIENTBED");
            builder.Property(nameof(AtlasModel.Consultation.IsPatientApprovalFormGiven)).HasColumnName("ISPATIENTAPPROVALFORMGIVEN");
            builder.Property(nameof(AtlasModel.Consultation.RequestDescription)).HasColumnName("REQUESTDESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Consultation.RequesterDoctorRef)).HasColumnName("REQUESTERDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Consultation.RequesterResourceRef)).HasColumnName("REQUESTERRESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Consultation.PhysicianApplicationRef)).HasColumnName("PHYSICIANAPPLICATION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.PhysicianApplication).WithOne().HasForeignKey<AtlasModel.PhysicianApplication>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.RequesterDoctor).WithOne().HasForeignKey<AtlasModel.Consultation>(x => x.RequesterDoctorRef).IsRequired(false);
            builder.HasOne(t => t.RequesterResource).WithOne().HasForeignKey<AtlasModel.Consultation>(x => x.RequesterResourceRef).IsRequired(true);
            builder.HasOne(t => t.PhysicianApplicationConsultations).WithOne().HasForeignKey<AtlasModel.Consultation>(x => x.PhysicianApplicationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}