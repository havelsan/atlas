using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PaymentConfig : IEntityTypeConfiguration<AtlasModel.Payment>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Payment> builder)
        {
            builder.ToTable("PAYMENT");
            builder.HasKey(nameof(AtlasModel.Payment.ObjectId));
            builder.Property(nameof(AtlasModel.Payment.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Payment.Price)).HasColumnName("PRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.Payment.AccountDocumentRef)).HasColumnName("ACCOUNTDOCUMENT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.AccountDocument).WithOne().HasForeignKey<AtlasModel.Payment>(x => x.AccountDocumentRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}