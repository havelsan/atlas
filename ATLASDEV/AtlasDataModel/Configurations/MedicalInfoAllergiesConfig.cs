using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedicalInfoAllergiesConfig : IEntityTypeConfiguration<AtlasModel.MedicalInfoAllergies>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedicalInfoAllergies> builder)
        {
            builder.ToTable("MEDICALINFOALLERGIES");
            builder.HasKey(nameof(AtlasModel.MedicalInfoAllergies.ObjectId));
            builder.Property(nameof(AtlasModel.MedicalInfoAllergies.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MedicalInfoAllergies.OtherAllergies)).HasColumnName("OTHERALLERGIES").HasMaxLength(1000);
        }
    }
}