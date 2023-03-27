using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PayerInvoiceDocumentGroupConfig : IEntityTypeConfiguration<AtlasModel.PayerInvoiceDocumentGroup>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PayerInvoiceDocumentGroup> builder)
        {
            builder.ToTable("PAYERINVOICEDOCUMENTGROUP");
            builder.HasKey(nameof(AtlasModel.PayerInvoiceDocumentGroup.ObjectId));
            builder.Property(nameof(AtlasModel.PayerInvoiceDocumentGroup.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.AccountDocumentGroup).WithOne().HasForeignKey<AtlasModel.AccountDocumentGroup>(p => p.ObjectId);
        }
    }
}