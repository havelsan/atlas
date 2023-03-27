using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AccountActionConfig : IEntityTypeConfiguration<AtlasModel.AccountAction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AccountAction> builder)
        {
            builder.ToTable("ACCOUNTACTION");
            builder.HasKey(nameof(AtlasModel.AccountAction.ObjectId));
            builder.Property(nameof(AtlasModel.AccountAction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AccountAction.TotalPrice)).HasColumnName("TOTALPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.AccountAction.CashOfficeName)).HasColumnName("CASHOFFICENAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.AccountAction.Description)).HasColumnName("DESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.AccountAction.CreateDate)).HasColumnName("CREATEDATE");
            builder.HasOne(t => t.BaseAction).WithOne().HasForeignKey<AtlasModel.BaseAction>(p => p.ObjectId);
        }
    }
}