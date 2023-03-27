using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class LaboratoryGridBoundedTestDefinitionConfig : IEntityTypeConfiguration<AtlasModel.LaboratoryGridBoundedTestDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.LaboratoryGridBoundedTestDefinition> builder)
        {
            builder.ToTable("LABGRIDBOUNDEDTESTDEF");
            builder.HasKey(nameof(AtlasModel.LaboratoryGridBoundedTestDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.LaboratoryGridBoundedTestDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.LaboratoryGridBoundedTestDefinition.LaboratoryTestDefinitionRef)).HasColumnName("LABORATORYTESTDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryGridBoundedTestDefinition.LaboratoryTestRef)).HasColumnName("LABORATORYTEST").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.LaboratoryTestDefinition).WithOne().HasForeignKey<AtlasModel.LaboratoryGridBoundedTestDefinition>(x => x.LaboratoryTestDefinitionRef).IsRequired(false);
            builder.HasOne(t => t.LaboratoryTest).WithOne().HasForeignKey<AtlasModel.LaboratoryGridBoundedTestDefinition>(x => x.LaboratoryTestRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}