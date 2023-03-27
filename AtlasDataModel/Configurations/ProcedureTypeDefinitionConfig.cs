using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ProcedureTypeDefinitionConfig : IEntityTypeConfiguration<AtlasModel.ProcedureTypeDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ProcedureTypeDefinition> builder)
        {
            builder.ToTable("PROCEDURETYPEDEFINITION");
            builder.HasKey(nameof(AtlasModel.ProcedureTypeDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.ProcedureTypeDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ProcedureTypeDefinition.ProcedureTypeName_Shadow)).HasColumnName("PROCEDURETYPENAME_SHADOW");
            builder.Property(nameof(AtlasModel.ProcedureTypeDefinition.Code)).HasColumnName("CODE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ProcedureTypeDefinition.ProcedureTypeName)).HasColumnName("PROCEDURETYPENAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ProcedureTypeDefinition.ParentProcedureTypeRef)).HasColumnName("PARENTPROCEDURETYPE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ParentProcedureType).WithOne().HasForeignKey<AtlasModel.ProcedureTypeDefinition>(x => x.ParentProcedureTypeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}