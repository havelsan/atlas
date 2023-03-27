using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AccountVoucherConfig : IEntityTypeConfiguration<AtlasModel.AccountVoucher>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AccountVoucher> builder)
        {
            builder.ToTable("ACCOUNTVOUCHER");
            builder.HasKey(nameof(AtlasModel.AccountVoucher.ObjectId));
            builder.Property(nameof(AtlasModel.AccountVoucher.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AccountVoucher.TotalPrice)).HasColumnName("TOTALPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.AccountVoucher.IsDept)).HasColumnName("ISDEPT");
            builder.Property(nameof(AtlasModel.AccountVoucher.AccountPeriodRef)).HasColumnName("ACCOUNTPERIOD").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountVoucher.AccountancyAddingActionRef)).HasColumnName("ACCOUNTANCYADDINGACTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.AccountPeriod).WithOne().HasForeignKey<AtlasModel.AccountVoucher>(x => x.AccountPeriodRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}