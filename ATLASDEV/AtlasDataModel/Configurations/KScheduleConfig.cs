using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class KScheduleConfig : IEntityTypeConfiguration<AtlasModel.KSchedule>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.KSchedule> builder)
        {
            builder.ToTable("KSCHEDULE");
            builder.HasKey(nameof(AtlasModel.KSchedule.ObjectId));
            builder.Property(nameof(AtlasModel.KSchedule.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.KSchedule.EndDate)).HasColumnName("ENDDATE");
            builder.Property(nameof(AtlasModel.KSchedule.StartDate)).HasColumnName("STARTDATE");
            builder.Property(nameof(AtlasModel.KSchedule.DailyDrugScheduleRef)).HasColumnName("DAILYDRUGSCHEDULE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.KSchedule.EpisodeRef)).HasColumnName("EPISODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.KSchedule.InPatientPhysicianApplicationRef)).HasColumnName("INPATIENTPHYSICIANAPPLICATION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.StockAction).WithOne().HasForeignKey<AtlasModel.StockAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.DailyDrugSchedule).WithOne().HasForeignKey<AtlasModel.KSchedule>(x => x.DailyDrugScheduleRef).IsRequired(false);
            builder.HasOne(t => t.Episode).WithOne().HasForeignKey<AtlasModel.KSchedule>(x => x.EpisodeRef).IsRequired(false);
            builder.HasOne(t => t.InPatientPhysicianApplication).WithOne().HasForeignKey<AtlasModel.KSchedule>(x => x.InPatientPhysicianApplicationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}