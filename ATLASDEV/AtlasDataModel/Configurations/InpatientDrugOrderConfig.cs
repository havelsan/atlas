using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InpatientDrugOrderConfig : IEntityTypeConfiguration<AtlasModel.InpatientDrugOrder>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InpatientDrugOrder> builder)
        {
            builder.ToTable("INPATIENTDRUGORDER");
            builder.HasKey(nameof(AtlasModel.InpatientDrugOrder.ObjectId));
            builder.Property(nameof(AtlasModel.InpatientDrugOrder.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.InpatientDrugOrder.PackageAmount)).HasColumnName("PACKAGEAMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.InpatientDrugOrder.DrugOrderID)).HasColumnName("DRUGORDERID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InpatientDrugOrder.InpatientPrescriptionRef)).HasColumnName("INPATIENTPRESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.DrugOrder).WithOne().HasForeignKey<AtlasModel.DrugOrder>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.InpatientPrescription).WithOne().HasForeignKey<AtlasModel.InpatientDrugOrder>(x => x.InpatientPrescriptionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}