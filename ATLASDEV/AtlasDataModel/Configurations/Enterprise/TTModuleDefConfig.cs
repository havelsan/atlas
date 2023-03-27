using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTModuleDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTModuleDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTModuleDef> builder)
        {
            builder.HasKey(t => t.ModuleDefId);
            builder.Property(t => t.ModuleDefId).HasColumnName("MODULEDEFID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(100);
            builder.Property(t => t.FolderDefId).HasColumnName("FOLDERDEFID").HasMaxLength(36);
            builder.Property(t => t.Version).HasColumnName("VERSION");
            builder.Property(t => t.PTNodeId).HasColumnName("PTNODEID").HasMaxLength(36);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
            builder.Property(t => t.CheckOutId).HasColumnName("CHECKOUTID").HasMaxLength(36);
            builder.Property(t => t.LastBuildDate).HasColumnName("LASTBUILDDATE");
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
            builder.Property(t => t.AssemblyDefId).HasColumnName("ASSEMBLYDEFID").HasMaxLength(36);
        }
    }
}