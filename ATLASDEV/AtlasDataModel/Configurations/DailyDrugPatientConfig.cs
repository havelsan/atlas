using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DailyDrugPatientConfig : IEntityTypeConfiguration<AtlasModel.DailyDrugPatient>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DailyDrugPatient> builder)
        {
            builder.ToTable("DAILYDRUGPATIENT");
            builder.HasKey(nameof(AtlasModel.DailyDrugPatient.ObjectId));
            builder.Property(nameof(AtlasModel.DailyDrugPatient.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DailyDrugPatient.IsCheck)).HasColumnName("ISCHECK");
            builder.Property(nameof(AtlasModel.DailyDrugPatient.InPatientPhysicianApplicationRef)).HasColumnName("INPATIENTPHYSICIANAPPLICATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DailyDrugPatient.DailyDrugScheduleRef)).HasColumnName("DAILYDRUGSCHEDULE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DailyDrugPatient.EpisodeRef)).HasColumnName("EPISODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DailyDrugPatient.PatientRef)).HasColumnName("PATIENT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.InPatientPhysicianApplication).WithOne().HasForeignKey<AtlasModel.DailyDrugPatient>(x => x.InPatientPhysicianApplicationRef).IsRequired(false);
            builder.HasOne(t => t.DailyDrugSchedule).WithOne().HasForeignKey<AtlasModel.DailyDrugPatient>(x => x.DailyDrugScheduleRef).IsRequired(false);
            builder.HasOne(t => t.Episode).WithOne().HasForeignKey<AtlasModel.DailyDrugPatient>(x => x.EpisodeRef).IsRequired(false);
            builder.HasOne(t => t.Patient).WithOne().HasForeignKey<AtlasModel.DailyDrugPatient>(x => x.PatientRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}