using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class OldDebtReceiptDocumentConfig : IEntityTypeConfiguration<AtlasModel.OldDebtReceiptDocument>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.OldDebtReceiptDocument> builder)
        {
            builder.ToTable("OLDDEBTRECEIPTDOCUMENT");
            builder.HasKey(nameof(AtlasModel.OldDebtReceiptDocument.ObjectId));
            builder.Property(nameof(AtlasModel.OldDebtReceiptDocument.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.AccountDocument).WithOne().HasForeignKey<AtlasModel.AccountDocument>(p => p.ObjectId);
        }
    }
}