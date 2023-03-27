using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PayerInvoiceDocumentConfig : IEntityTypeConfiguration<AtlasModel.PayerInvoiceDocument>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PayerInvoiceDocument> builder)
        {
            builder.ToTable("PAYERINVOICEDOCUMENT");
            builder.HasKey(nameof(AtlasModel.PayerInvoiceDocument.ObjectId));
            builder.Property(nameof(AtlasModel.PayerInvoiceDocument.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PayerInvoiceDocument.GeneralTotalPrice)).HasColumnName("GENERALTOTALPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.PayerInvoiceDocument.TotalVATPrice)).HasColumnName("TOTALVATPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.PayerInvoiceDocument.TotalDiscountPrice)).HasColumnName("TOTALDISCOUNTPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.PayerInvoiceDocument.InvoicePostingInvoiceType)).HasColumnName("INVOICEPOSTINGINVOICETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PayerInvoiceDocument.OrderNo)).HasColumnName("ORDERNO");
            builder.Property(nameof(AtlasModel.PayerInvoiceDocument.DrugTotal)).HasColumnName("DRUGTOTAL").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.PayerInvoiceDocument.MaterialTotal)).HasColumnName("MATERIALTOTAL").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.PayerInvoiceDocument.PayerRef)).HasColumnName("PAYER").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.AccountDocument).WithOne().HasForeignKey<AtlasModel.AccountDocument>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Payer).WithOne().HasForeignKey<AtlasModel.PayerInvoiceDocument>(x => x.PayerRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}