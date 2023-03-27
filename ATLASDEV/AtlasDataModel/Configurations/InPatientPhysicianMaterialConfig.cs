using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InPatientPhysicianMaterialConfig : IEntityTypeConfiguration<AtlasModel.InPatientPhysicianMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InPatientPhysicianMaterial> builder)
        {
            builder.ToTable("INPATIENTPHYSICIANMATERIAL");
            builder.HasKey(nameof(AtlasModel.InPatientPhysicianMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.InPatientPhysicianMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseTreatmentMaterial).WithOne().HasForeignKey<AtlasModel.BaseTreatmentMaterial>(p => p.ObjectId);
        }
    }
}