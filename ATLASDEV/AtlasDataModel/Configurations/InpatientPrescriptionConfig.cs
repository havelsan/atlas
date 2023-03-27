using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InpatientPrescriptionConfig : IEntityTypeConfiguration<AtlasModel.InpatientPrescription>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InpatientPrescription> builder)
        {
            builder.ToTable("INPATIENTPRESCRIPTION");
            builder.HasKey(nameof(AtlasModel.InpatientPrescription.ObjectId));
            builder.Property(nameof(AtlasModel.InpatientPrescription.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.InpatientPrescription.ChangePres)).HasColumnName("CHANGEPRES");
            builder.Property(nameof(AtlasModel.InpatientPrescription.ExternalPharmacyRef)).HasColumnName("EXTERNALPHARMACY").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.Prescription).WithOne().HasForeignKey<AtlasModel.Prescription>(p => p.ObjectId);
        }
    }
}