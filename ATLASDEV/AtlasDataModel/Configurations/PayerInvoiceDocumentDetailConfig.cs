using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PayerInvoiceDocumentDetailConfig : IEntityTypeConfiguration<AtlasModel.PayerInvoiceDocumentDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PayerInvoiceDocumentDetail> builder)
        {
            builder.ToTable("PAYERINVOICEDOCUMENTDETAIL");
            builder.HasKey(nameof(AtlasModel.PayerInvoiceDocumentDetail.ObjectId));
            builder.Property(nameof(AtlasModel.PayerInvoiceDocumentDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.AccountDocumentDetail).WithOne().HasForeignKey<AtlasModel.AccountDocumentDetail>(p => p.ObjectId);
        }
    }
}