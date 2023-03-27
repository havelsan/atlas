using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class OrthesisProthesisRequestTreatmentMaterialConfig : IEntityTypeConfiguration<AtlasModel.OrthesisProthesisRequestTreatmentMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.OrthesisProthesisRequestTreatmentMaterial> builder)
        {
            builder.ToTable("ORTHESISPPROTHESISTREATMAT");
            builder.HasKey(nameof(AtlasModel.OrthesisProthesisRequestTreatmentMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.OrthesisProthesisRequestTreatmentMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseTreatmentMaterial).WithOne().HasForeignKey<AtlasModel.BaseTreatmentMaterial>(p => p.ObjectId);
        }
    }
}