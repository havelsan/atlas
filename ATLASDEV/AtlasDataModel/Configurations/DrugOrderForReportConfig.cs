using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DrugOrderForReportConfig : IEntityTypeConfiguration<AtlasModel.DrugOrderForReport>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DrugOrderForReport> builder)
        {
            builder.ToTable("DRUGORDERFORREPORT");
            builder.HasKey(nameof(AtlasModel.DrugOrderForReport.ObjectId));
            builder.Property(nameof(AtlasModel.DrugOrderForReport.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DrugOrderForReport.HasReport)).HasColumnName("HASREPORT");
            builder.Property(nameof(AtlasModel.DrugOrderForReport.Dosage)).HasColumnName("DOSAGE");
            builder.Property(nameof(AtlasModel.DrugOrderForReport.DosageAmount)).HasColumnName("DOSAGEAMOUNT");
            builder.Property(nameof(AtlasModel.DrugOrderForReport.WeeklyMonthly)).HasColumnName("WEEKLYMONTHLY");
            builder.Property(nameof(AtlasModel.DrugOrderForReport.HasTenDays)).HasColumnName("HASTENDAYS");
            builder.Property(nameof(AtlasModel.DrugOrderForReport.DrugRef)).HasColumnName("DRUG").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrderForReport.SPTSReportEntryActionRef)).HasColumnName("SPTSREPORTENTRYACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrderForReport.BarcodeLevelRef)).HasColumnName("BARCODELEVEL").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Drug).WithOne().HasForeignKey<AtlasModel.DrugOrderForReport>(x => x.DrugRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}