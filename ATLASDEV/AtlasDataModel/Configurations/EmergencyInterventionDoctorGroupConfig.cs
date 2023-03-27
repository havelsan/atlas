using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EmergencyInterventionDoctorGroupConfig : IEntityTypeConfiguration<AtlasModel.EmergencyInterventionDoctorGroup>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EmergencyInterventionDoctorGroup> builder)
        {
            builder.ToTable("EMERINTERDOCTORGROUP");
            builder.HasKey(nameof(AtlasModel.EmergencyInterventionDoctorGroup.ObjectId));
            builder.Property(nameof(AtlasModel.EmergencyInterventionDoctorGroup.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.EmergencyInterventionDoctorGroup.ActionDate)).HasColumnName("ACTIONDATE");
            builder.Property(nameof(AtlasModel.EmergencyInterventionDoctorGroup.DoctorRef)).HasColumnName("DOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EmergencyInterventionDoctorGroup.EmergencyInterventionRef)).HasColumnName("EMERGENCYINTERVENTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Doctor).WithOne().HasForeignKey<AtlasModel.EmergencyInterventionDoctorGroup>(x => x.DoctorRef).IsRequired(false);
            builder.HasOne(t => t.EmergencyIntervention).WithOne().HasForeignKey<AtlasModel.EmergencyInterventionDoctorGroup>(x => x.EmergencyInterventionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}