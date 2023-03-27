using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingApplicationTreatmentMaterialConfig : IEntityTypeConfiguration<AtlasModel.NursingApplicationTreatmentMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingApplicationTreatmentMaterial> builder)
        {
            builder.ToTable("NURAPPTREATMENTMATERIAL");
            builder.HasKey(nameof(AtlasModel.NursingApplicationTreatmentMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.NursingApplicationTreatmentMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseTreatmentMaterial).WithOne().HasForeignKey<AtlasModel.BaseTreatmentMaterial>(p => p.ObjectId);
        }
    }
}