using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTAssemblyDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTAssemblyDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTAssemblyDef> builder)
        {
            builder.HasKey(t => t.AssemblyDefId);
            builder.Property(t => t.AssemblyDefId).HasColumnName("ASSEMBLYDEFID").HasMaxLength(36).IsRequired();
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(100);
            builder.Property(t => t.Version).HasColumnName("VERSION");
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
            builder.Property(t => t.LastBuildDate).HasColumnName("LASTBUILDDATE");
            builder.Property(t => t.CheckOutId).HasColumnName("CHECKOUTID").HasMaxLength(36);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
        }
    }
}