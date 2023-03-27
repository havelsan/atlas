using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedicalWasteConfig : IEntityTypeConfiguration<AtlasModel.MedicalWaste>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedicalWaste> builder)
        {
            builder.ToTable("MEDICALWASTE");
            builder.HasKey(nameof(AtlasModel.MedicalWaste.ObjectId));
            builder.Property(nameof(AtlasModel.MedicalWaste.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MedicalWaste.TransactionDate)).HasColumnName("TRANSACTIONDATE");
            builder.Property(nameof(AtlasModel.MedicalWaste.Amount)).HasColumnName("AMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.MedicalWaste.DeliveryDate)).HasColumnName("DELIVERYDATE");
        }
    }
}