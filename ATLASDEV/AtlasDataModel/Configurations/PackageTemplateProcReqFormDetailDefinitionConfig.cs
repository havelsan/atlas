using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PackageTemplateProcReqFormDetailDefinitionConfig : IEntityTypeConfiguration<AtlasModel.PackageTemplateProcReqFormDetailDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PackageTemplateProcReqFormDetailDefinition> builder)
        {
            builder.ToTable("PACKAGETEMPLPROCREQFORMDET");
            builder.HasKey(nameof(AtlasModel.PackageTemplateProcReqFormDetailDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.PackageTemplateProcReqFormDetailDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PackageTemplateProcReqFormDetailDefinition.ProcedureReqFormDetailDefRef)).HasColumnName("PROCEDUREREQFORMDETAILDEF").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PackageTemplateProcReqFormDetailDefinition.PackageTemplateDefinitionRef)).HasColumnName("PACKAGETEMPLATEDEFINITION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ProcedureReqFormDetailDef).WithOne().HasForeignKey<AtlasModel.PackageTemplateProcReqFormDetailDefinition>(x => x.ProcedureReqFormDetailDefRef).IsRequired(false);
            builder.HasOne(t => t.PackageTemplateDefinition).WithOne().HasForeignKey<AtlasModel.PackageTemplateProcReqFormDetailDefinition>(x => x.PackageTemplateDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}