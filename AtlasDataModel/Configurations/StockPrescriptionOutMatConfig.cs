using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockPrescriptionOutMatConfig : IEntityTypeConfiguration<AtlasModel.StockPrescriptionOutMat>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockPrescriptionOutMat> builder)
        {
            builder.ToTable("STOCKPRESCRIPTIONOUTMAT");
            builder.HasKey(nameof(AtlasModel.StockPrescriptionOutMat.ObjectId));
            builder.Property(nameof(AtlasModel.StockPrescriptionOutMat.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.StockActionDetailOut).WithOne().HasForeignKey<AtlasModel.StockActionDetailOut>(p => p.ObjectId);
        }
    }
}