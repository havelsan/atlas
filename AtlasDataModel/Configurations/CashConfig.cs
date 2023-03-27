using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class CashConfig : IEntityTypeConfiguration<AtlasModel.Cash>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Cash> builder)
        {
            builder.ToTable("CASH");
            builder.HasKey(nameof(AtlasModel.Cash.ObjectId));
            builder.Property(nameof(AtlasModel.Cash.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Cash.CurrencyTypeRef)).HasColumnName("CURRENCYTYPE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.Payment).WithOne().HasForeignKey<AtlasModel.Payment>(p => p.ObjectId);
        }
    }
}