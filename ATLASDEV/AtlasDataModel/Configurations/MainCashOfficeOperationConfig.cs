using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MainCashOfficeOperationConfig : IEntityTypeConfiguration<AtlasModel.MainCashOfficeOperation>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MainCashOfficeOperation> builder)
        {
            builder.ToTable("MAINCASHOFFICEOPERATION");
            builder.HasKey(nameof(AtlasModel.MainCashOfficeOperation.ObjectId));
            builder.Property(nameof(AtlasModel.MainCashOfficeOperation.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MainCashOfficeOperation.CashOfficeReceiptDocumentRef)).HasColumnName("CASHOFFICERECEIPTDOCUMENT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.AccountAction).WithOne().HasForeignKey<AtlasModel.AccountAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.CashOfficeReceiptDocument).WithOne().HasForeignKey<AtlasModel.MainCashOfficeOperation>(x => x.CashOfficeReceiptDocumentRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}