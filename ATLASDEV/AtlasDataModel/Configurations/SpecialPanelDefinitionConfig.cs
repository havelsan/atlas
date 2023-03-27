using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SpecialPanelDefinitionConfig : IEntityTypeConfiguration<AtlasModel.SpecialPanelDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SpecialPanelDefinition> builder)
        {
            builder.ToTable("SPECIALPANELDEFINITION");
            builder.HasKey(nameof(AtlasModel.SpecialPanelDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.SpecialPanelDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SpecialPanelDefinition.Caption)).HasColumnName("CAPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SpecialPanelDefinition.Name)).HasColumnName("NAME").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SpecialPanelDefinition.WorkListDefinitionRef)).HasColumnName("WORKLISTDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SpecialPanelDefinition.UserRef)).HasColumnName("USER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.WorkListDefinition).WithOne().HasForeignKey<AtlasModel.SpecialPanelDefinition>(x => x.WorkListDefinitionRef).IsRequired(false);
            builder.HasOne(t => t.User).WithOne().HasForeignKey<AtlasModel.SpecialPanelDefinition>(x => x.UserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}