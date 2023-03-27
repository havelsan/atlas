using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DailyDrugSchOrderConfig : IEntityTypeConfiguration<AtlasModel.DailyDrugSchOrder>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DailyDrugSchOrder> builder)
        {
            builder.ToTable("DAILYDRUGSCHORDER");
            builder.HasKey(nameof(AtlasModel.DailyDrugSchOrder.ObjectId));
            builder.Property(nameof(AtlasModel.DailyDrugSchOrder.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DailyDrugSchOrder.KSchMaterial)).HasColumnName("KSCHMATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DailyDrugSchOrder.DoseAmount)).HasColumnName("DOSEAMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DailyDrugSchOrder.DailyDrugScheduleRef)).HasColumnName("DAILYDRUGSCHEDULE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DailyDrugSchOrder.MaterialRef)).HasColumnName("MATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DailyDrugSchOrder.DailyDrugPatientRef)).HasColumnName("DAILYDRUGPATIENT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DailyDrugSchedule).WithOne().HasForeignKey<AtlasModel.DailyDrugSchOrder>(x => x.DailyDrugScheduleRef).IsRequired(false);
            builder.HasOne(t => t.Material).WithOne().HasForeignKey<AtlasModel.DailyDrugSchOrder>(x => x.MaterialRef).IsRequired(false);
            builder.HasOne(t => t.DailyDrugPatient).WithOne().HasForeignKey<AtlasModel.DailyDrugSchOrder>(x => x.DailyDrugPatientRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}