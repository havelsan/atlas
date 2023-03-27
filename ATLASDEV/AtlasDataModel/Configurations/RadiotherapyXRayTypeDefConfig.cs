using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class RadiotherapyXRayTypeDefConfig : IEntityTypeConfiguration<AtlasModel.RadiotherapyXRayTypeDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.RadiotherapyXRayTypeDef> builder)
        {
            builder.ToTable("RADIOTHERAPYXRAYTYPEDEF");
            builder.HasKey(nameof(AtlasModel.RadiotherapyXRayTypeDef.ObjectId));
            builder.Property(nameof(AtlasModel.RadiotherapyXRayTypeDef.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.RadiotherapyXRayTypeDef.Code)).HasColumnName("CODE").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.RadiotherapyXRayTypeDef.Name)).HasColumnName("NAME").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.RadiotherapyXRayTypeDef.Active)).HasColumnName("ACTIVE");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}