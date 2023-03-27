using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InvoiceCollectionDocumentDetailConfig : IEntityTypeConfiguration<AtlasModel.InvoiceCollectionDocumentDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InvoiceCollectionDocumentDetail> builder)
        {
            builder.ToTable("INVOICECOLLECTIONDOCDETAIL");
            builder.HasKey(nameof(AtlasModel.InvoiceCollectionDocumentDetail.ObjectId));
            builder.Property(nameof(AtlasModel.InvoiceCollectionDocumentDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.AccountDocumentDetail).WithOne().HasForeignKey<AtlasModel.AccountDocumentDetail>(p => p.ObjectId);
        }
    }
}