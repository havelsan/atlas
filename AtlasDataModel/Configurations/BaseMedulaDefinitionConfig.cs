using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseMedulaDefinitionConfig : IEntityTypeConfiguration<AtlasModel.BaseMedulaDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseMedulaDefinition> builder)
        {
            builder.ToTable("BASEMEDULADEFINITION");
            builder.HasKey(nameof(AtlasModel.BaseMedulaDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.BaseMedulaDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}