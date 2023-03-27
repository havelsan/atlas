using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class KScheduleMaterialConfig : IEntityTypeConfiguration<AtlasModel.KScheduleMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.KScheduleMaterial> builder)
        {
            builder.ToTable("KSCHEDULEMATERIAL");
            builder.HasKey(nameof(AtlasModel.KScheduleMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.KScheduleMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.KScheduleMaterial.StoreInheld)).HasColumnName("STOREINHELD").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.KScheduleMaterial.Description)).HasColumnName("DESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.KScheduleMaterial.RequestAmount)).HasColumnName("REQUESTAMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.KScheduleMaterial.PatientName)).HasColumnName("PATIENTNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.KScheduleMaterial.QuarantinaNO)).HasColumnName("QUARANTINANO").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.KScheduleMaterial.PatientID)).HasColumnName("PATIENTID").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.KScheduleMaterial.IsImmediate)).HasColumnName("ISIMMEDIATE");
            builder.Property(nameof(AtlasModel.KScheduleMaterial.BarcodeVerifyCounter)).HasColumnName("BARCODEVERIFYCOUNTER").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.KScheduleMaterial.DrugOrderStartDate)).HasColumnName("DRUGORDERSTARTDATE");
            builder.Property(nameof(AtlasModel.KScheduleMaterial.TimesInADay)).HasColumnName("TIMESINADAY");
            builder.Property(nameof(AtlasModel.KScheduleMaterial.UsageNote)).HasColumnName("USAGENOTE").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.KScheduleMaterial.DrugOrderObjectID)).HasColumnName("DRUGORDEROBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.KScheduleMaterial.KScheduleCollectedOrderRef)).HasColumnName("KSCHEDULECOLLECTEDORDER").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.StockActionDetailOut).WithOne().HasForeignKey<AtlasModel.StockActionDetailOut>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.KScheduleCollectedOrder).WithOne().HasForeignKey<AtlasModel.KScheduleMaterial>(x => x.KScheduleCollectedOrderRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}