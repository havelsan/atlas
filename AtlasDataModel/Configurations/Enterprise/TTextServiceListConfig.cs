using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTextServiceListConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTextServiceList>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTextServiceList> builder)
        {
            builder.HasKey(t => t.ServiceId);
            builder.Property(t => t.ServiceId).HasColumnName("SERVICEID").HasMaxLength(36);
            builder.Property(t => t.ServiceName).HasColumnName("SERVICENAME").HasMaxLength(64);
            builder.Property(t => t.ServiceDescription).HasColumnName("SERVICEDESCRIPTION").HasMaxLength(128);
        }
    }
}