using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class WorkListDefinitionConfig : IEntityTypeConfiguration<AtlasModel.WorkListDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.WorkListDefinition> builder)
        {
            builder.ToTable("WORKLISTDEFINITION");
            builder.HasKey(nameof(AtlasModel.WorkListDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.WorkListDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.WorkListDefinition.InterfaceDefName)).HasColumnName("INTERFACEDEFNAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.WorkListDefinition.WorkListIcon)).HasColumnName("WORKLISTICON").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.WorkListDefinition.RightDefID)).HasColumnName("RIGHTDEFID");
            builder.Property(nameof(AtlasModel.WorkListDefinition.RoleID)).HasColumnName("ROLEID");
            builder.Property(nameof(AtlasModel.WorkListDefinition.FormName)).HasColumnName("FORMNAME").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.WorkListDefinition.Caption)).HasColumnName("CAPTION").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.WorkListDefinition.NoRightCheck)).HasColumnName("NORIGHTCHECK");
            builder.Property(nameof(AtlasModel.WorkListDefinition.ReportDefName)).HasColumnName("REPORTDEFNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.WorkListDefinition.LastSpecialPanelRef)).HasColumnName("LASTSPECIALPANEL").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.LastSpecialPanel).WithOne().HasForeignKey<AtlasModel.WorkListDefinition>(x => x.LastSpecialPanelRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}