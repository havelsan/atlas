using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class FallingDownRiskDefinitionConfig : IEntityTypeConfiguration<AtlasModel.FallingDownRiskDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.FallingDownRiskDefinition> builder)
        {
            builder.ToTable("FALLINGDOWNRISKDEFINITION");
            builder.HasKey(nameof(AtlasModel.FallingDownRiskDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.FallingDownRiskDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.FallingDownRiskDefinition.Score)).HasColumnName("SCORE");
            builder.Property(nameof(AtlasModel.FallingDownRiskDefinition.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.FallingDownRiskDefinition.Type)).HasColumnName("TYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.FallingDownRiskDefinition.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}