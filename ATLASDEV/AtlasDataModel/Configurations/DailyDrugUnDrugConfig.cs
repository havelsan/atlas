using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DailyDrugUnDrugConfig : IEntityTypeConfiguration<AtlasModel.DailyDrugUnDrug>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DailyDrugUnDrug> builder)
        {
            builder.ToTable("DAILYDRUGUNDRUG");
            builder.HasKey(nameof(AtlasModel.DailyDrugUnDrug.ObjectId));
            builder.Property(nameof(AtlasModel.DailyDrugUnDrug.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DailyDrugUnDrug.UnlistVolume)).HasColumnName("UNLISTVOLUME").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DailyDrugUnDrug.KSchUnMaterial)).HasColumnName("KSCHUNMATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DailyDrugUnDrug.DoseAmount)).HasColumnName("DOSEAMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DailyDrugUnDrug.DailyDrugPatientRef)).HasColumnName("DAILYDRUGPATIENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DailyDrugUnDrug.MaterialRef)).HasColumnName("MATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DailyDrugUnDrug.DailyDrugScheduleRef)).HasColumnName("DAILYDRUGSCHEDULE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DailyDrugPatient).WithOne().HasForeignKey<AtlasModel.DailyDrugUnDrug>(x => x.DailyDrugPatientRef).IsRequired(false);
            builder.HasOne(t => t.Material).WithOne().HasForeignKey<AtlasModel.DailyDrugUnDrug>(x => x.MaterialRef).IsRequired(false);
            builder.HasOne(t => t.DailyDrugSchedule).WithOne().HasForeignKey<AtlasModel.DailyDrugUnDrug>(x => x.DailyDrugScheduleRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}