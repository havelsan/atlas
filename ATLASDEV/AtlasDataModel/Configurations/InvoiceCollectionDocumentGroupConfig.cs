using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InvoiceCollectionDocumentGroupConfig : IEntityTypeConfiguration<AtlasModel.InvoiceCollectionDocumentGroup>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InvoiceCollectionDocumentGroup> builder)
        {
            builder.ToTable("INVOICECOLLECTIONDOCGROUP");
            builder.HasKey(nameof(AtlasModel.InvoiceCollectionDocumentGroup.ObjectId));
            builder.Property(nameof(AtlasModel.InvoiceCollectionDocumentGroup.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.AccountDocumentGroup).WithOne().HasForeignKey<AtlasModel.AccountDocumentGroup>(p => p.ObjectId);
        }
    }
}