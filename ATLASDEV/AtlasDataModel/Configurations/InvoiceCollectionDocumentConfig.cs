using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InvoiceCollectionDocumentConfig : IEntityTypeConfiguration<AtlasModel.InvoiceCollectionDocument>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InvoiceCollectionDocument> builder)
        {
            builder.ToTable("INVOICECOLLECTIONDOCUMENT");
            builder.HasKey(nameof(AtlasModel.InvoiceCollectionDocument.ObjectId));
            builder.Property(nameof(AtlasModel.InvoiceCollectionDocument.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.InvoiceCollectionDocument.DrugTotal)).HasColumnName("DRUGTOTAL").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.InvoiceCollectionDocument.MaterialTotal)).HasColumnName("MATERIALTOTAL").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.InvoiceCollectionDocument.PayerRef)).HasColumnName("PAYER").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.AccountDocument).WithOne().HasForeignKey<AtlasModel.AccountDocument>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Payer).WithOne().HasForeignKey<AtlasModel.InvoiceCollectionDocument>(x => x.PayerRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}