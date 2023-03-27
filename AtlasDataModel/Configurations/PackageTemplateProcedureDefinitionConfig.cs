using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PackageTemplateProcedureDefinitionConfig : IEntityTypeConfiguration<AtlasModel.PackageTemplateProcedureDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PackageTemplateProcedureDefinition> builder)
        {
            builder.ToTable("PACKAGETEMPPROCEDUREDEF");
            builder.HasKey(nameof(AtlasModel.PackageTemplateProcedureDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.PackageTemplateProcedureDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PackageTemplateProcedureDefinition.PackageTemplateDefinitionRef)).HasColumnName("PACKAGETEMPLATEDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PackageTemplateProcedureDefinition.ProcedureDefinitionRef)).HasColumnName("PROCEDUREDEFINITION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.PackageTemplateDefinition).WithOne().HasForeignKey<AtlasModel.PackageTemplateProcedureDefinition>(x => x.PackageTemplateDefinitionRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureDefinition).WithOne().HasForeignKey<AtlasModel.PackageTemplateProcedureDefinition>(x => x.ProcedureDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}