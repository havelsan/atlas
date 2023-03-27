using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class KScheduleInfectionDrugConfig : IEntityTypeConfiguration<AtlasModel.KScheduleInfectionDrug>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.KScheduleInfectionDrug> builder)
        {
            builder.ToTable("KSCHEDULEINFECTIONDRUG");
            builder.HasKey(nameof(AtlasModel.KScheduleInfectionDrug.ObjectId));
            builder.Property(nameof(AtlasModel.KScheduleInfectionDrug.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.KScheduleInfectionDrug.BarcodeVerifyCounter)).HasColumnName("BARCODEVERIFYCOUNTER").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.KScheduleInfectionDrug.DrugAmount)).HasColumnName("DRUGAMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.KScheduleInfectionDrug.ExpirationDate)).HasColumnName("EXPIRATIONDATE");
            builder.Property(nameof(AtlasModel.KScheduleInfectionDrug.IsApproved)).HasColumnName("ISAPPROVED");
            builder.Property(nameof(AtlasModel.KScheduleInfectionDrug.StockActionStatus)).HasColumnName("STOCKACTIONSTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.KScheduleInfectionDrug.DrugOrderObjectID)).HasColumnName("DRUGORDEROBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.KScheduleInfectionDrug.MaterialRef)).HasColumnName("MATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.KScheduleInfectionDrug.KScheduleRef)).HasColumnName("KSCHEDULE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Material).WithOne().HasForeignKey<AtlasModel.KScheduleInfectionDrug>(x => x.MaterialRef).IsRequired(false);
            builder.HasOne(t => t.KSchedule).WithOne().HasForeignKey<AtlasModel.KScheduleInfectionDrug>(x => x.KScheduleRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}