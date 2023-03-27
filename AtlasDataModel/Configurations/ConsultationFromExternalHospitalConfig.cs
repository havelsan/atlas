using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ConsultationFromExternalHospitalConfig : IEntityTypeConfiguration<AtlasModel.ConsultationFromExternalHospital>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ConsultationFromExternalHospital> builder)
        {
            builder.ToTable("CONSULTATIONFROMEXTHOSP");
            builder.HasKey(nameof(AtlasModel.ConsultationFromExternalHospital.ObjectId));
            builder.Property(nameof(AtlasModel.ConsultationFromExternalHospital.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ConsultationFromExternalHospital.RequestDescription)).HasColumnName("REQUESTDESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ConsultationFromExternalHospital.RequestedExternalHospitalRef)).HasColumnName("REQUESTEDEXTERNALHOSPITAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ConsultationFromExternalHospital.RequestedExternalSpecialityRef)).HasColumnName("REQUESTEDEXTERNALSPECIALITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ConsultationFromExternalHospital.PhysicianApplicationRef)).HasColumnName("PHYSICIANAPPLICATION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.PhysicianApplication).WithOne().HasForeignKey<AtlasModel.PhysicianApplication>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.RequestedExternalHospital).WithOne().HasForeignKey<AtlasModel.ConsultationFromExternalHospital>(x => x.RequestedExternalHospitalRef).IsRequired(false);
            builder.HasOne(t => t.PhysicianApplicationExternalConsultations).WithOne().HasForeignKey<AtlasModel.ConsultationFromExternalHospital>(x => x.PhysicianApplicationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}