using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class CashOfficeReceiptDocumentConfig : IEntityTypeConfiguration<AtlasModel.CashOfficeReceiptDocument>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.CashOfficeReceiptDocument> builder)
        {
            builder.ToTable("CASHOFFICERECEIPTDOCUMENT");
            builder.HasKey(nameof(AtlasModel.CashOfficeReceiptDocument.ObjectId));
            builder.Property(nameof(AtlasModel.CashOfficeReceiptDocument.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.CashOfficeReceiptDocument.PayeeAddress)).HasColumnName("PAYEEADDRESS").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.CashOfficeReceiptDocument.PayeeName)).HasColumnName("PAYEENAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.CashOfficeReceiptDocument.SpecialNo)).HasColumnName("SPECIALNO");
            builder.Property(nameof(AtlasModel.CashOfficeReceiptDocument.PayeeUniqueRefNo)).HasColumnName("PAYEEUNIQUEREFNO").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.CashOfficeReceiptDocument.Phone)).HasColumnName("PHONE");
            builder.Property(nameof(AtlasModel.CashOfficeReceiptDocument.TenderName)).HasColumnName("TENDERNAME");
            builder.Property(nameof(AtlasModel.CashOfficeReceiptDocument.TenderNo)).HasColumnName("TENDERNO");
            builder.Property(nameof(AtlasModel.CashOfficeReceiptDocument.SupplierRef)).HasColumnName("SUPPLIER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.CashOfficeReceiptDocument.MoneyReceivedTypeRef)).HasColumnName("MONEYRECEIVEDTYPE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.CashOfficeReceiptDocument.BankDecountRef)).HasColumnName("BANKDECOUNT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.AccountDocument).WithOne().HasForeignKey<AtlasModel.AccountDocument>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Supplier).WithOne().HasForeignKey<AtlasModel.CashOfficeReceiptDocument>(x => x.SupplierRef).IsRequired(false);
            builder.HasOne(t => t.MoneyReceivedType).WithOne().HasForeignKey<AtlasModel.CashOfficeReceiptDocument>(x => x.MoneyReceivedTypeRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}