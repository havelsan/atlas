using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DentalExaminationTreatmentMaterialConfig : IEntityTypeConfiguration<AtlasModel.DentalExaminationTreatmentMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DentalExaminationTreatmentMaterial> builder)
        {
            builder.ToTable("DENTALEXAMTREATMENTMAT");
            builder.HasKey(nameof(AtlasModel.DentalExaminationTreatmentMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.DentalExaminationTreatmentMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseTreatmentMaterial).WithOne().HasForeignKey<AtlasModel.BaseTreatmentMaterial>(p => p.ObjectId);
        }
    }
}