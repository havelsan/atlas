using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class LaboratoryGridDepartmentDefinitionConfig : IEntityTypeConfiguration<AtlasModel.LaboratoryGridDepartmentDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.LaboratoryGridDepartmentDefinition> builder)
        {
            builder.ToTable("LABGRIDDEPARTMENTDEF");
            builder.HasKey(nameof(AtlasModel.LaboratoryGridDepartmentDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.LaboratoryGridDepartmentDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.LaboratoryGridDepartmentDefinition.LaboratoryTestRef)).HasColumnName("LABORATORYTEST").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryGridDepartmentDefinition.DepartmentRef)).HasColumnName("DEPARTMENT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.LaboratoryTest).WithOne().HasForeignKey<AtlasModel.LaboratoryGridDepartmentDefinition>(x => x.LaboratoryTestRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}