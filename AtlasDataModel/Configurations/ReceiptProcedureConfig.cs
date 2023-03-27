using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ReceiptProcedureConfig : IEntityTypeConfiguration<AtlasModel.ReceiptProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ReceiptProcedure> builder)
        {
            builder.ToTable("RECEIPTPROCEDURE");
            builder.HasKey(nameof(AtlasModel.ReceiptProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.ReceiptProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ReceiptProcedure.ActionDate)).HasColumnName("ACTIONDATE");
            builder.Property(nameof(AtlasModel.ReceiptProcedure.ExternalCode)).HasColumnName("EXTERNALCODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.ReceiptProcedure.Description)).HasColumnName("DESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ReceiptProcedure.Paid)).HasColumnName("PAID");
            builder.Property(nameof(AtlasModel.ReceiptProcedure.TotalDiscountPrice)).HasColumnName("TOTALDISCOUNTPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.ReceiptProcedure.Amount)).HasColumnName("AMOUNT");
            builder.Property(nameof(AtlasModel.ReceiptProcedure.UnitPrice)).HasColumnName("UNITPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.ReceiptProcedure.TotalDiscountedPrice)).HasColumnName("TOTALDISCOUNTEDPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.ReceiptProcedure.TotalPrice)).HasColumnName("TOTALPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.ReceiptProcedure.RevenueType)).HasColumnName("REVENUETYPE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ReceiptProcedure.RemainingPrice)).HasColumnName("REMAININGPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.ReceiptProcedure.PaymentPrice)).HasColumnName("PAYMENTPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.ReceiptProcedure.ReceiptRef)).HasColumnName("RECEIPT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Receipt).WithOne().HasForeignKey<AtlasModel.ReceiptProcedure>(x => x.ReceiptRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}