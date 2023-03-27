using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTRoleMemberConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTRoleMember>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTRoleMember> builder)
        {
            builder.HasKey(t => t.RoleId);
            builder.Property(t => t.RoleId).HasColumnName("ROLEID").HasMaxLength(36);
            builder.Property(t => t.MemberId).HasColumnName("MEMBERID").HasMaxLength(36);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
            builder.Property(t => t.TransferType).HasColumnName("TRANSFERTYPE");
        }
    }
}