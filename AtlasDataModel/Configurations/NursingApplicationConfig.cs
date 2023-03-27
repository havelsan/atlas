using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingApplicationConfig : IEntityTypeConfiguration<AtlasModel.NursingApplication>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingApplication> builder)
        {
            builder.ToTable("NURSINGAPPLICATION");
            builder.HasKey(nameof(AtlasModel.NursingApplication.ObjectId));
            builder.Property(nameof(AtlasModel.NursingApplication.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingApplication.InPatientTreatmentClinicAppRef)).HasColumnName("INPATIENTTREATMENTCLINICAPP").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.NursingApplication.EmergencyInterventionRef)).HasColumnName("EMERGENCYINTERVENTION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.InPatientTreatmentClinicApp).WithOne().HasForeignKey<AtlasModel.NursingApplication>(x => x.InPatientTreatmentClinicAppRef).IsRequired(false);
            builder.HasOne(t => t.EmergencyIntervention).WithOne().HasForeignKey<AtlasModel.NursingApplication>(x => x.EmergencyInterventionRef).IsRequired(false);
            #endregion Parent Relations

            #region Child Relations
            builder.HasMany(t => t.BaseNursingDataEntries).WithOne(x => x.NursingApplication).HasForeignKey(x => x.NursingApplicationRef);
            #endregion Child Relations
        }
    }
}