using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedicalStuffConfig : IEntityTypeConfiguration<AtlasModel.MedicalStuff>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedicalStuff> builder)
        {
            builder.ToTable("MEDICALSTUFF");
            builder.HasKey(nameof(AtlasModel.MedicalStuff.ObjectId));
            builder.Property(nameof(AtlasModel.MedicalStuff.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MedicalStuff.StuffDescription)).HasColumnName("STUFFDESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.MedicalStuff.StuffAmount)).HasColumnName("STUFFAMOUNT");
            builder.Property(nameof(AtlasModel.MedicalStuff.PeriodUnit)).HasColumnName("PERIODUNIT");
            builder.Property(nameof(AtlasModel.MedicalStuff.PeriodUnitType)).HasColumnName("PERIODUNITTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.MedicalStuff.OdyometryTestId)).HasColumnName("ODYOMETRYTESTID");
            builder.Property(nameof(AtlasModel.MedicalStuff.MedicalStuffPlaceOfUsageRef)).HasColumnName("MEDICALSTUFFPLACEOFUSAGE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalStuff.MedicalStuffDefRef)).HasColumnName("MEDICALSTUFFDEF").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalStuff.MedicalStuffGroupRef)).HasColumnName("MEDICALSTUFFGROUP").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalStuff.MedicalStuffReportRef)).HasColumnName("MEDICALSTUFFREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalStuff.MedicalStuffPrescriptionRef)).HasColumnName("MEDICALSTUFFPRESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalStuff.MedicalStuffUsageTypeRef)).HasColumnName("MEDICALSTUFFUSAGETYPE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.MedicalStuffDef).WithOne().HasForeignKey<AtlasModel.MedicalStuff>(x => x.MedicalStuffDefRef).IsRequired(false);
            builder.HasOne(t => t.MedicalStuffReport).WithOne().HasForeignKey<AtlasModel.MedicalStuff>(x => x.MedicalStuffReportRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}