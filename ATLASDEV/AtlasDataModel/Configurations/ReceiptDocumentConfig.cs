using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ReceiptDocumentConfig : IEntityTypeConfiguration<AtlasModel.ReceiptDocument>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ReceiptDocument> builder)
        {
            builder.ToTable("RECEIPTDOCUMENT");
            builder.HasKey(nameof(AtlasModel.ReceiptDocument.ObjectId));
            builder.Property(nameof(AtlasModel.ReceiptDocument.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ReceiptDocument.TotalVATPrice)).HasColumnName("TOTALVATPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.ReceiptDocument.CreditCardSpecialNo)).HasColumnName("CREDITCARDSPECIALNO");
            builder.Property(nameof(AtlasModel.ReceiptDocument.PatientNo)).HasColumnName("PATIENTNO");
            builder.Property(nameof(AtlasModel.ReceiptDocument.PatientName)).HasColumnName("PATIENTNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ReceiptDocument.CreditCardDocumentNo)).HasColumnName("CREDITCARDDOCUMENTNO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.ReceiptDocument.SpecialNo)).HasColumnName("SPECIALNO");
            builder.Property(nameof(AtlasModel.ReceiptDocument.PayeeName)).HasColumnName("PAYEENAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ReceiptDocument.GeneralTotalPrice)).HasColumnName("GENERALTOTALPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.ReceiptDocument.TotalDiscountPrice)).HasColumnName("TOTALDISCOUNTPRICE").HasColumnType("NUMBER(15,2)");
            builder.HasOne(t => t.AccountDocument).WithOne().HasForeignKey<AtlasModel.AccountDocument>(p => p.ObjectId);
        }
    }
}