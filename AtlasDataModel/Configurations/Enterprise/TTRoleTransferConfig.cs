using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTRoleTransferConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTRoleTransfer>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTRoleTransfer> builder)
        {
            builder.HasKey(t => t.TransferId);
            builder.Property(t => t.TransferId).HasColumnName("TRANSFERID").HasMaxLength(36);
            builder.Property(t => t.UserId).HasColumnName("USERID").HasMaxLength(36);
            builder.Property(t => t.CreationDate).HasColumnName("CREATIONDATE");
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(255);
            builder.Property(t => t.Cancelled).HasColumnName("CANCELLED");
        }
    }
}