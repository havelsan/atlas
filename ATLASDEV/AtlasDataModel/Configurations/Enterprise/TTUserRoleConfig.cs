using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTUserRoleConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTUserRole>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTUserRole> builder)
        {
            builder.Property(t => t.UserId).HasColumnName("USERID").HasMaxLength(36);
            builder.Property(t => t.RoleId).HasColumnName("ROLEID").HasMaxLength(36);
            builder.Property(t => t.TransferType).HasColumnName("TRANSFERTYPE");
            builder.Property(t => t.TransferId).HasColumnName("TRANSFERID").HasMaxLength(36);
            builder.Property(t => t.StartDate).HasColumnName("STARTDATE");
            builder.Property(t => t.EndDate).HasColumnName("ENDDATE");
        }
    }
}