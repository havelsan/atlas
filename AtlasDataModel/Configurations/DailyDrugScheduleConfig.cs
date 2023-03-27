using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DailyDrugScheduleConfig : IEntityTypeConfiguration<AtlasModel.DailyDrugSchedule>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DailyDrugSchedule> builder)
        {
            builder.ToTable("DAILYDRUGSCHEDULE");
            builder.HasKey(nameof(AtlasModel.DailyDrugSchedule.ObjectId));
            builder.Property(nameof(AtlasModel.DailyDrugSchedule.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DailyDrugSchedule.EndDate)).HasColumnName("ENDDATE");
            builder.Property(nameof(AtlasModel.DailyDrugSchedule.StartDate)).HasColumnName("STARTDATE");
            builder.HasOne(t => t.StockAction).WithOne().HasForeignKey<AtlasModel.StockAction>(p => p.ObjectId);
        }
    }
}