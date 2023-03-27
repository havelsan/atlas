using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTFolderDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTFolderDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTFolderDef> builder)
        {
            builder.HasKey(t => t.FolderDefId);
            builder.Property(t => t.FolderDefId).HasColumnName("FOLDERDEFID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(100);
            builder.Property(t => t.ParentFolderDefId).HasColumnName("PARENTFOLDERDEFID").HasMaxLength(36);
            builder.Property(t => t.PTNodeId).HasColumnName("PTNODEID").HasMaxLength(36);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
            builder.Property(t => t.CheckOutId).HasColumnName("CHECKOUTID").HasMaxLength(36);
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
        }
    }
}