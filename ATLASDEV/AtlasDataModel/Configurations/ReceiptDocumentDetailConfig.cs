using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ReceiptDocumentDetailConfig : IEntityTypeConfiguration<AtlasModel.ReceiptDocumentDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ReceiptDocumentDetail> builder)
        {
            builder.ToTable("RECEIPTDOCUMENTDETAIL");
            builder.HasKey(nameof(AtlasModel.ReceiptDocumentDetail.ObjectId));
            builder.Property(nameof(AtlasModel.ReceiptDocumentDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ReceiptDocumentDetail.PaymentPrice)).HasColumnName("PAYMENTPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.ReceiptDocumentDetail.PaymentPriceByAdvance)).HasColumnName("PAYMENTPRICEBYADVANCE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.ReceiptDocumentDetail.IsParticipationShare)).HasColumnName("ISPARTICIPATIONSHARE");
            builder.HasOne(t => t.AccountDocumentDetail).WithOne().HasForeignKey<AtlasModel.AccountDocumentDetail>(p => p.ObjectId);
        }
    }
}