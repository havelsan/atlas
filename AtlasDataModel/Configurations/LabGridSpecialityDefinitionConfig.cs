using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class LabGridSpecialityDefinitionConfig : IEntityTypeConfiguration<AtlasModel.LabGridSpecialityDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.LabGridSpecialityDefinition> builder)
        {
            builder.ToTable("LABGRIDSPECIALITYDEF");
            builder.HasKey(nameof(AtlasModel.LabGridSpecialityDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.LabGridSpecialityDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.LabGridSpecialityDefinition.SpecialityDefinitonRef)).HasColumnName("SPECIALITYDEFINITON").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LabGridSpecialityDefinition.LaboratoryTestRef)).HasColumnName("LABORATORYTEST").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.LaboratoryTest).WithOne().HasForeignKey<AtlasModel.LabGridSpecialityDefinition>(x => x.LaboratoryTestRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}