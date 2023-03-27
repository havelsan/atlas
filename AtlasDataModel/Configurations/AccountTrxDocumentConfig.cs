using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AccountTrxDocumentConfig : IEntityTypeConfiguration<AtlasModel.AccountTrxDocument>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AccountTrxDocument> builder)
        {
            builder.ToTable("ACCOUNTTRXDOCUMENT");
            builder.HasKey(nameof(AtlasModel.AccountTrxDocument.ObjectId));
            builder.Property(nameof(AtlasModel.AccountTrxDocument.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AccountTrxDocument.AccountTransactionRef)).HasColumnName("ACCOUNTTRANSACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTrxDocument.AccountDocumentDetailRef)).HasColumnName("ACCOUNTDOCUMENTDETAIL").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.AccountTransaction).WithOne().HasForeignKey<AtlasModel.AccountTrxDocument>(x => x.AccountTransactionRef).IsRequired(true);
            builder.HasOne(t => t.AccountDocumentDetail).WithOne().HasForeignKey<AtlasModel.AccountTrxDocument>(x => x.AccountDocumentDetailRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}