using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EstheticAlternativeProcedureDefinitionConfig : IEntityTypeConfiguration<AtlasModel.EstheticAlternativeProcedureDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EstheticAlternativeProcedureDefinition> builder)
        {
            builder.ToTable("ESTHETICALTERNATIVEPROCDEF");
            builder.HasKey(nameof(AtlasModel.EstheticAlternativeProcedureDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.EstheticAlternativeProcedureDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.ProcedureDefinition).WithOne().HasForeignKey<AtlasModel.ProcedureDefinition>(p => p.ObjectId);
        }
    }
}