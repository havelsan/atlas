using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTPasswordHistoryConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTPasswordHistory>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTPasswordHistory> builder)
        {
            builder.HasKey(t => t.UserId);
            builder.Property(t => t.UserId).HasColumnName("USERID").HasMaxLength(36);
            builder.Property(t => t.ChangeDate).HasColumnName("CHANGEDATE");
            builder.Property(t => t.Password).HasColumnName("PASSWORD").HasMaxLength(50);
        }
    }
}