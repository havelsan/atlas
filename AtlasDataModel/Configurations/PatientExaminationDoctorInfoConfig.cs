using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientExaminationDoctorInfoConfig : IEntityTypeConfiguration<AtlasModel.PatientExaminationDoctorInfo>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientExaminationDoctorInfo> builder)
        {
            builder.ToTable("PATIENTEXAMINATIONDOCTOR");
            builder.HasKey(nameof(AtlasModel.PatientExaminationDoctorInfo.ObjectId));
            builder.Property(nameof(AtlasModel.PatientExaminationDoctorInfo.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PatientExaminationDoctorInfo.ExaminationDate)).HasColumnName("EXAMINATIONDATE");
            builder.Property(nameof(AtlasModel.PatientExaminationDoctorInfo.ExaminationFlag)).HasColumnName("EXAMINATIONFLAG");
            builder.Property(nameof(AtlasModel.PatientExaminationDoctorInfo.IsSMSsendForDoctor)).HasColumnName("ISSMSSENDFORDOCTOR");
            builder.Property(nameof(AtlasModel.PatientExaminationDoctorInfo.IsSMSsendForChief)).HasColumnName("ISSMSSENDFORCHIEF");
            builder.Property(nameof(AtlasModel.PatientExaminationDoctorInfo.IsSMSsendForResponsible)).HasColumnName("ISSMSSENDFORRESPONSIBLE");
            builder.Property(nameof(AtlasModel.PatientExaminationDoctorInfo.IsActiveFlag)).HasColumnName("ISACTIVEFLAG");
            builder.Property(nameof(AtlasModel.PatientExaminationDoctorInfo.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientExaminationDoctorInfo.PatientExaminationRef)).HasColumnName("PATIENTEXAMINATION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.PatientExaminationDoctorInfo>(x => x.ResUserRef).IsRequired(true);
            builder.HasOne(t => t.PatientExamination).WithOne().HasForeignKey<AtlasModel.PatientExaminationDoctorInfo>(x => x.PatientExaminationRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}