using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ReceiptDocumentGroupConfig : IEntityTypeConfiguration<AtlasModel.ReceiptDocumentGroup>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ReceiptDocumentGroup> builder)
        {
            builder.ToTable("RECEIPTDOCUMENTGROUP");
            builder.HasKey(nameof(AtlasModel.ReceiptDocumentGroup.ObjectId));
            builder.Property(nameof(AtlasModel.ReceiptDocumentGroup.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.AccountDocumentGroup).WithOne().HasForeignKey<AtlasModel.AccountDocumentGroup>(p => p.ObjectId);
        }
    }
}