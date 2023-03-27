using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class RadiologyGridDepartmentDefinitionConfig : IEntityTypeConfiguration<AtlasModel.RadiologyGridDepartmentDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.RadiologyGridDepartmentDefinition> builder)
        {
            builder.ToTable("RADGRIDDEPARTMENTDEF");
            builder.HasKey(nameof(AtlasModel.RadiologyGridDepartmentDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.RadiologyGridDepartmentDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.RadiologyGridDepartmentDefinition.DepartmentRef)).HasColumnName("DEPARTMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RadiologyGridDepartmentDefinition.RadiologyTestRef)).HasColumnName("RADIOLOGYTEST").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.RadiologyTest).WithOne().HasForeignKey<AtlasModel.RadiologyGridDepartmentDefinition>(x => x.RadiologyTestRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}