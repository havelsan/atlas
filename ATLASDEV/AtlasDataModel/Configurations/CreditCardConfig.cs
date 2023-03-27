using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class CreditCardConfig : IEntityTypeConfiguration<AtlasModel.CreditCard>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.CreditCard> builder)
        {
            builder.ToTable("CREDITCARD");
            builder.HasKey(nameof(AtlasModel.CreditCard.ObjectId));
            builder.Property(nameof(AtlasModel.CreditCard.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.CreditCard.PhoneNo)).HasColumnName("PHONENO").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.CreditCard.Owner)).HasColumnName("OWNER").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.CreditCard.ValidDate)).HasColumnName("VALIDDATE");
            builder.Property(nameof(AtlasModel.CreditCard.CardType)).HasColumnName("CARDTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.CreditCard.CardNo)).HasColumnName("CARDNO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.CreditCard.BankNameRef)).HasColumnName("BANKNAME").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.Payment).WithOne().HasForeignKey<AtlasModel.Payment>(p => p.ObjectId);
        }
    }
}