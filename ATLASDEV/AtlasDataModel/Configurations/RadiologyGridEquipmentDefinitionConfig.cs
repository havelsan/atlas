using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class RadiologyGridEquipmentDefinitionConfig : IEntityTypeConfiguration<AtlasModel.RadiologyGridEquipmentDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.RadiologyGridEquipmentDefinition> builder)
        {
            builder.ToTable("RADGRIDEQUIPMENTDEF");
            builder.HasKey(nameof(AtlasModel.RadiologyGridEquipmentDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.RadiologyGridEquipmentDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.RadiologyGridEquipmentDefinition.EquipmentRef)).HasColumnName("EQUIPMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyGridEquipmentDefinition.RadiologyTestRef)).HasColumnName("RADIOLOGYTEST").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.RadiologyTest).WithOne().HasForeignKey<AtlasModel.RadiologyGridEquipmentDefinition>(x => x.RadiologyTestRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}