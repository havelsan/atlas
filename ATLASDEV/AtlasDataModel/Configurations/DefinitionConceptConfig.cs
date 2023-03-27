using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DefinitionConceptConfig : IEntityTypeConfiguration<AtlasModel.DefinitionConcept>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DefinitionConcept> builder)
        {
            builder.ToTable("DEFINITIONCONCEPT");
            builder.HasKey(nameof(AtlasModel.DefinitionConcept.ObjectId));
            builder.Property(nameof(AtlasModel.DefinitionConcept.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DefinitionConcept.Concept_Shadow)).HasColumnName("CONCEPT_SHADOW");
            builder.Property(nameof(AtlasModel.DefinitionConcept.Concept)).HasColumnName("CONCEPT");
            builder.Property(nameof(AtlasModel.DefinitionConcept.TerminologyManagerDefRef)).HasColumnName("TERMINOLOGYMANAGERDEF").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.TerminologyManagerDefDefinitionConcepts).WithOne().HasForeignKey<AtlasModel.DefinitionConcept>(x => x.TerminologyManagerDefRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}