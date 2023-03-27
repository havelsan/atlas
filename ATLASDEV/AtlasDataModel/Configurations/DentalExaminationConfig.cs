using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DentalExaminationConfig : IEntityTypeConfiguration<AtlasModel.DentalExamination>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DentalExamination> builder)
        {
            builder.ToTable("DENTALEXAMINATION");
            builder.HasKey(nameof(AtlasModel.DentalExamination.ObjectId));
            builder.Property(nameof(AtlasModel.DentalExamination.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DentalExamination.LeftLowerJaw)).HasColumnName("LEFTLOWERJAW").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DentalExamination.RightUpperJaw)).HasColumnName("RIGHTUPPERJAW").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DentalExamination.ProcessTime)).HasColumnName("PROCESSTIME");
            builder.Property(nameof(AtlasModel.DentalExamination.RightLowerJaw)).HasColumnName("RIGHTLOWERJAW").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DentalExamination.LeftUpperJaw)).HasColumnName("LEFTUPPERJAW").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DentalExamination.DentalExaminationFile)).HasColumnName("DENTALEXAMINATIONFILE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DentalExamination.GeneralAnesthesia)).HasColumnName("GENERALANESTHESIA");
            builder.Property(nameof(AtlasModel.DentalExamination.TriajCode)).HasColumnName("TRIAJCODE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DentalExamination.IsFollowUpExam)).HasColumnName("ISFOLLOWUPEXAM");
            builder.Property(nameof(AtlasModel.DentalExamination.DrAnesteziTescilNo)).HasColumnName("DRANESTEZITESCILNO");
            builder.Property(nameof(AtlasModel.DentalExamination.DentalExaminationType)).HasColumnName("DENTALEXAMINATIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DentalExamination.IsConsultation)).HasColumnName("ISCONSULTATION");
            builder.Property(nameof(AtlasModel.DentalExamination.ConsultationResultAndOffers)).HasColumnName("CONSULTATIONRESULTANDOFFERS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DentalExamination.RequestDescription)).HasColumnName("REQUESTDESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DentalExamination.ProcedureDepartmentRef)).HasColumnName("PROCEDUREDEPARTMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DentalExamination.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DentalExamination.RequesterDoctorRef)).HasColumnName("REQUESTERDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DentalExamination.ConsultationRequestResourceRef)).HasColumnName("CONSULTATIONREQUESTRESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DentalExamination.DentalCommitmentRef)).HasColumnName("DENTALCOMMITMENT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseDentalEpisodeAction).WithOne().HasForeignKey<AtlasModel.BaseDentalEpisodeAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ProcedureDepartment).WithOne().HasForeignKey<AtlasModel.DentalExamination>(x => x.ProcedureDepartmentRef).IsRequired(false);
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.DentalExamination>(x => x.ResUserRef).IsRequired(false);
            builder.HasOne(t => t.RequesterDoctor).WithOne().HasForeignKey<AtlasModel.DentalExamination>(x => x.RequesterDoctorRef).IsRequired(false);
            builder.HasOne(t => t.ConsultationRequestResource).WithOne().HasForeignKey<AtlasModel.DentalExamination>(x => x.ConsultationRequestResourceRef).IsRequired(false);
            builder.HasOne(t => t.DentalCommitment).WithOne().HasForeignKey<AtlasModel.DentalExamination>(x => x.DentalCommitmentRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}