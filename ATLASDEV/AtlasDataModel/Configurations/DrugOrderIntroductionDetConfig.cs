using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DrugOrderIntroductionDetConfig : IEntityTypeConfiguration<AtlasModel.DrugOrderIntroductionDet>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DrugOrderIntroductionDet> builder)
        {
            builder.ToTable("DRUGORDERINTRODUCTIONDET");
            builder.HasKey(nameof(AtlasModel.DrugOrderIntroductionDet.ObjectId));
            builder.Property(nameof(AtlasModel.DrugOrderIntroductionDet.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DrugOrderIntroductionDet.Day)).HasColumnName("DAY");
            builder.Property(nameof(AtlasModel.DrugOrderIntroductionDet.DoseAmount)).HasColumnName("DOSEAMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugOrderIntroductionDet.Frequency)).HasColumnName("FREQUENCY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugOrderIntroductionDet.UsageNote)).HasColumnName("USAGENOTE").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.DrugOrderIntroductionDet.PatientOwnDrug)).HasColumnName("PATIENTOWNDRUG");
            builder.Property(nameof(AtlasModel.DrugOrderIntroductionDet.DrugOrderType)).HasColumnName("DRUGORDERTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugOrderIntroductionDet.DrugDescription)).HasColumnName("DRUGDESCRIPTION");
            builder.Property(nameof(AtlasModel.DrugOrderIntroductionDet.DrugDescriptionType)).HasColumnName("DRUGDESCRIPTIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugOrderIntroductionDet.DrugUsageType)).HasColumnName("DRUGUSAGETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugOrderIntroductionDet.IsImmediate)).HasColumnName("ISIMMEDIATE");
            builder.Property(nameof(AtlasModel.DrugOrderIntroductionDet.NextDayOrder)).HasColumnName("NEXTDAYORDER");
            builder.Property(nameof(AtlasModel.DrugOrderIntroductionDet.PeriodUnitType)).HasColumnName("PERIODUNITTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugOrderIntroductionDet.PackageAmount)).HasColumnName("PACKAGEAMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugOrderIntroductionDet.CaseOfNeed)).HasColumnName("CASEOFNEED");
            builder.Property(nameof(AtlasModel.DrugOrderIntroductionDet.DrugOrderRef)).HasColumnName("DRUGORDER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrderIntroductionDet.MaterialRef)).HasColumnName("MATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrderIntroductionDet.DrugOrderIntroductionRef)).HasColumnName("DRUGORDERINTRODUCTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DrugOrder).WithOne().HasForeignKey<AtlasModel.DrugOrderIntroductionDet>(x => x.DrugOrderRef).IsRequired(false);
            builder.HasOne(t => t.Material).WithOne().HasForeignKey<AtlasModel.DrugOrderIntroductionDet>(x => x.MaterialRef).IsRequired(false);
            builder.HasOne(t => t.DrugOrderIntroduction).WithOne().HasForeignKey<AtlasModel.DrugOrderIntroductionDet>(x => x.DrugOrderIntroductionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}