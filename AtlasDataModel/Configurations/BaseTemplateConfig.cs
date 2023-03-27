using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseTemplateConfig : IEntityTypeConfiguration<AtlasModel.BaseTemplate>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseTemplate> builder)
        {
            builder.ToTable("BASETEMPLATE");
            builder.HasKey(nameof(AtlasModel.BaseTemplate.ObjectId));
            builder.Property(nameof(AtlasModel.BaseTemplate.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseTemplate.Content)).HasColumnName("CONTENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseTemplate.MenuCaption)).HasColumnName("MENUCAPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.BaseTemplate.Description)).HasColumnName("DESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.BaseTemplate.Enabled)).HasColumnName("ENABLED");
            builder.Property(nameof(AtlasModel.BaseTemplate.TemplateGroupRef)).HasColumnName("TEMPLATEGROUP").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseTemplate.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.TemplateGroup).WithOne().HasForeignKey<AtlasModel.BaseTemplate>(x => x.TemplateGroupRef).IsRequired(true);
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.BaseTemplate>(x => x.ResUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}