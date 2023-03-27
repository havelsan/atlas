using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class LaboratoryGridPanelTestDefinitionConfig : IEntityTypeConfiguration<AtlasModel.LaboratoryGridPanelTestDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.LaboratoryGridPanelTestDefinition> builder)
        {
            builder.ToTable("LABGRIDPANELTESTDEF");
            builder.HasKey(nameof(AtlasModel.LaboratoryGridPanelTestDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.LaboratoryGridPanelTestDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.LaboratoryGridPanelTestDefinition.SequenceNo)).HasColumnName("SEQUENCENO");
            builder.Property(nameof(AtlasModel.LaboratoryGridPanelTestDefinition.LaboratoryTestRef)).HasColumnName("LABORATORYTEST").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryGridPanelTestDefinition.LaboratoryTestDefinitionRef)).HasColumnName("LABORATORYTESTDEFINITION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.LaboratoryTest).WithOne().HasForeignKey<AtlasModel.LaboratoryGridPanelTestDefinition>(x => x.LaboratoryTestRef).IsRequired(false);
            builder.HasOne(t => t.LaboratoryTestDefinition).WithOne().HasForeignKey<AtlasModel.LaboratoryGridPanelTestDefinition>(x => x.LaboratoryTestDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}