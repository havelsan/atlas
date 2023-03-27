using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class RadiologyMaterialConfig : IEntityTypeConfiguration<AtlasModel.RadiologyMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.RadiologyMaterial> builder)
        {
            builder.ToTable("RADIOLOGYMATERIAL");
            builder.HasKey(nameof(AtlasModel.RadiologyMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.RadiologyMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.RadiologyMaterial.RadiologyRef)).HasColumnName("RADIOLOGY").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseTreatmentMaterial).WithOne().HasForeignKey<AtlasModel.BaseTreatmentMaterial>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Radiology).WithOne().HasForeignKey<AtlasModel.RadiologyMaterial>(x => x.RadiologyRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}