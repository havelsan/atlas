using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ConsultationTreatmentMaterialConfig : IEntityTypeConfiguration<AtlasModel.ConsultationTreatmentMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ConsultationTreatmentMaterial> builder)
        {
            builder.ToTable("CONSULTATIONTREATMAT");
            builder.HasKey(nameof(AtlasModel.ConsultationTreatmentMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.ConsultationTreatmentMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseTreatmentMaterial).WithOne().HasForeignKey<AtlasModel.BaseTreatmentMaterial>(p => p.ObjectId);
        }
    }
}