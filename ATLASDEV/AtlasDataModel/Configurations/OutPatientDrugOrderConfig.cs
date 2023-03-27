using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class OutPatientDrugOrderConfig : IEntityTypeConfiguration<AtlasModel.OutPatientDrugOrder>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.OutPatientDrugOrder> builder)
        {
            builder.ToTable("OUTPATIENTDRUGORDER");
            builder.HasKey(nameof(AtlasModel.OutPatientDrugOrder.ObjectId));
            builder.Property(nameof(AtlasModel.OutPatientDrugOrder.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.OutPatientDrugOrder.SPTSProvisionDetail)).HasColumnName("SPTSPROVISIONDETAIL").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.OutPatientDrugOrder.SPTSProvisionResult)).HasColumnName("SPTSPROVISIONRESULT");
            builder.Property(nameof(AtlasModel.OutPatientDrugOrder.Report)).HasColumnName("REPORT");
            builder.Property(nameof(AtlasModel.OutPatientDrugOrder.RequiredAmount)).HasColumnName("REQUIREDAMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.OutPatientDrugOrder.PackageAmount)).HasColumnName("PACKAGEAMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.OutPatientDrugOrder.UnitPrice)).HasColumnName("UNITPRICE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.OutPatientDrugOrder.Price)).HasColumnName("PRICE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.OutPatientDrugOrder.StoreInheld)).HasColumnName("STOREINHELD").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.OutPatientDrugOrder.ReceivedPrice)).HasColumnName("RECEIVEDPRICE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.OutPatientDrugOrder.TenDaily)).HasColumnName("TENDAILY");
            builder.Property(nameof(AtlasModel.OutPatientDrugOrder.PeriodUnitType)).HasColumnName("PERIODUNITTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.OutPatientDrugOrder.DrugSupply)).HasColumnName("DRUGSUPPLY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.OutPatientDrugOrder.TreatmentTime)).HasColumnName("TREATMENTTIME").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.OutPatientDrugOrder.OutPatientPrescriptionRef)).HasColumnName("OUTPATIENTPRESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.OutPatientDrugOrder.PhysicianDrugRef)).HasColumnName("PHYSICIANDRUG").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.DrugOrder).WithOne().HasForeignKey<AtlasModel.DrugOrder>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.OutPatientPrescription).WithOne().HasForeignKey<AtlasModel.OutPatientDrugOrder>(x => x.OutPatientPrescriptionRef).IsRequired(false);
            builder.HasOne(t => t.PhysicianDrug).WithOne().HasForeignKey<AtlasModel.OutPatientDrugOrder>(x => x.PhysicianDrugRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}