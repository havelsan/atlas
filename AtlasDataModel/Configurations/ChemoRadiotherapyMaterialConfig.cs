using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ChemoRadiotherapyMaterialConfig : IEntityTypeConfiguration<AtlasModel.ChemoRadiotherapyMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ChemoRadiotherapyMaterial> builder)
        {
            builder.ToTable("CHEMORADIOTHERAPYMATERIAL");
            builder.HasKey(nameof(AtlasModel.ChemoRadiotherapyMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.ChemoRadiotherapyMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseTreatmentMaterial).WithOne().HasForeignKey<AtlasModel.BaseTreatmentMaterial>(p => p.ObjectId);
        }
    }
}