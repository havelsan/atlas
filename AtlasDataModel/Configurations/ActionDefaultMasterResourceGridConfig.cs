using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ActionDefaultMasterResourceGridConfig : IEntityTypeConfiguration<AtlasModel.ActionDefaultMasterResourceGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ActionDefaultMasterResourceGrid> builder)
        {
            builder.ToTable("ACTIONDEFAULTMASTERRESGRD");
            builder.HasKey(nameof(AtlasModel.ActionDefaultMasterResourceGrid.ObjectId));
            builder.Property(nameof(AtlasModel.ActionDefaultMasterResourceGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ActionDefaultMasterResourceGrid.ResourceRef)).HasColumnName("RESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ActionDefaultMasterResourceGrid.ActionDefMasterResDefinitionRef)).HasColumnName("ACTIONDEFMASTERRESDEFINITION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Resource).WithOne().HasForeignKey<AtlasModel.ActionDefaultMasterResourceGrid>(x => x.ResourceRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}