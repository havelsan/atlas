using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InPatientPhysicianApplicationConfig : IEntityTypeConfiguration<AtlasModel.InPatientPhysicianApplication>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InPatientPhysicianApplication> builder)
        {
            builder.ToTable("INPATIENTPHYSICIANAPP");
            builder.HasKey(nameof(AtlasModel.InPatientPhysicianApplication.ObjectId));
            builder.Property(nameof(AtlasModel.InPatientPhysicianApplication.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.InPatientPhysicianApplication.InPatientFolder)).HasColumnName("INPATIENTFOLDER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InPatientPhysicianApplication.EmergencyInterventionRef)).HasColumnName("EMERGENCYINTERVENTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InPatientPhysicianApplication.InPatientTreatmentClinicAppRef)).HasColumnName("INPATIENTTREATMENTCLINICAPP").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.PhysicianApplication).WithOne().HasForeignKey<AtlasModel.PhysicianApplication>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.EmergencyIntervention).WithOne().HasForeignKey<AtlasModel.InPatientPhysicianApplication>(x => x.EmergencyInterventionRef).IsRequired(false);
            builder.HasOne(t => t.InPatientTreatmentClinicApp).WithOne().HasForeignKey<AtlasModel.InPatientPhysicianApplication>(x => x.InPatientTreatmentClinicAppRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}