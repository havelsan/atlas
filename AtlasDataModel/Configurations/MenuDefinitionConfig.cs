using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MenuDefinitionConfig : IEntityTypeConfiguration<AtlasModel.MenuDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MenuDefinition> builder)
        {
            builder.ToTable("MENUDEFINITION");
            builder.HasKey(nameof(AtlasModel.MenuDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.MenuDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MenuDefinition.ObjectDefinitionName)).HasColumnName("OBJECTDEFINITIONNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.MenuDefinition.OrderNo)).HasColumnName("ORDERNO");
            builder.Property(nameof(AtlasModel.MenuDefinition.EntryState)).HasColumnName("ENTRYSTATE");
            builder.Property(nameof(AtlasModel.MenuDefinition.MenuGroup)).HasColumnName("MENUGROUP").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.MenuDefinition.Caption_Shadow)).HasColumnName("CAPTION_SHADOW");
            builder.Property(nameof(AtlasModel.MenuDefinition.Caption)).HasColumnName("CAPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.MenuDefinition.UnboundFormName)).HasColumnName("UNBOUNDFORMNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.MenuDefinition.MenuDefinitionNo)).HasColumnName("MENUDEFINITIONNO");
            builder.Property(nameof(AtlasModel.MenuDefinition.IsDisabled)).HasColumnName("ISDISABLED");
            builder.Property(nameof(AtlasModel.MenuDefinition.IconPath)).HasColumnName("ICONPATH").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.MenuDefinition.ParentMenuRef)).HasColumnName("PARENTMENU").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ParentMenu).WithOne().HasForeignKey<AtlasModel.MenuDefinition>(x => x.ParentMenuRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}