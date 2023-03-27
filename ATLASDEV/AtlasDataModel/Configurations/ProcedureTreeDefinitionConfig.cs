using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ProcedureTreeDefinitionConfig : IEntityTypeConfiguration<AtlasModel.ProcedureTreeDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ProcedureTreeDefinition> builder)
        {
            builder.ToTable("PROCEDURETREEDEFINITION");
            builder.HasKey(nameof(AtlasModel.ProcedureTreeDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.ProcedureTreeDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ProcedureTreeDefinition.ExternalCode)).HasColumnName("EXTERNALCODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.ProcedureTreeDefinition.ID)).HasColumnName("ID");
            builder.Property(nameof(AtlasModel.ProcedureTreeDefinition.Description_Shadow)).HasColumnName("DESCRIPTION_SHADOW");
            builder.Property(nameof(AtlasModel.ProcedureTreeDefinition.Description)).HasColumnName("DESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ProcedureTreeDefinition.ParentIDRef)).HasColumnName("PARENTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ProcedureTreeDefinition.RevenueSubAccountCodeRef)).HasColumnName("REVENUESUBACCOUNTCODE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ParentID).WithOne().HasForeignKey<AtlasModel.ProcedureTreeDefinition>(x => x.ParentIDRef).IsRequired(false);
            builder.HasOne(t => t.RevenueSubAccountCode).WithOne().HasForeignKey<AtlasModel.ProcedureTreeDefinition>(x => x.RevenueSubAccountCodeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}