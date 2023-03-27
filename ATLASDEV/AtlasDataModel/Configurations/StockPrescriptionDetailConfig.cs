using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockPrescriptionDetailConfig : IEntityTypeConfiguration<AtlasModel.StockPrescriptionDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockPrescriptionDetail> builder)
        {
            builder.ToTable("STOCKPRESCRIPTIONDETAIL");
            builder.HasKey(nameof(AtlasModel.StockPrescriptionDetail.ObjectId));
            builder.Property(nameof(AtlasModel.StockPrescriptionDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockPrescriptionDetail.VolumeNo)).HasColumnName("VOLUMENO").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.StockPrescriptionDetail.SerialNo)).HasColumnName("SERIALNO").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.StockPrescriptionDetail.StockRef)).HasColumnName("STOCK").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockPrescriptionDetail.PrescriptionRef)).HasColumnName("PRESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockPrescriptionDetail.PrescriptionPaperRef)).HasColumnName("PRESCRIPTIONPAPER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Stock).WithOne().HasForeignKey<AtlasModel.StockPrescriptionDetail>(x => x.StockRef).IsRequired(false);
            builder.HasOne(t => t.Prescription).WithOne().HasForeignKey<AtlasModel.StockPrescriptionDetail>(x => x.PrescriptionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}