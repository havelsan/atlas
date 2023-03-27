using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class KSchedulePatienOwnDrugConfig : IEntityTypeConfiguration<AtlasModel.KSchedulePatienOwnDrug>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.KSchedulePatienOwnDrug> builder)
        {
            builder.ToTable("KSCHEDULEPATIENOWNDRUG");
            builder.HasKey(nameof(AtlasModel.KSchedulePatienOwnDrug.ObjectId));
            builder.Property(nameof(AtlasModel.KSchedulePatienOwnDrug.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.KSchedulePatienOwnDrug.StockActionStatus)).HasColumnName("STOCKACTIONSTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.KSchedulePatienOwnDrug.BarcodeVerifyCounter)).HasColumnName("BARCODEVERIFYCOUNTER").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.KSchedulePatienOwnDrug.ExpirationDate)).HasColumnName("EXPIRATIONDATE");
            builder.Property(nameof(AtlasModel.KSchedulePatienOwnDrug.DrugAmount)).HasColumnName("DRUGAMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.KSchedulePatienOwnDrug.DrugOrderObjectID)).HasColumnName("DRUGORDEROBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.KSchedulePatienOwnDrug.MaterialRef)).HasColumnName("MATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.KSchedulePatienOwnDrug.KScheduleRef)).HasColumnName("KSCHEDULE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Material).WithOne().HasForeignKey<AtlasModel.KSchedulePatienOwnDrug>(x => x.MaterialRef).IsRequired(false);
            builder.HasOne(t => t.KSchedule).WithOne().HasForeignKey<AtlasModel.KSchedulePatienOwnDrug>(x => x.KScheduleRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}