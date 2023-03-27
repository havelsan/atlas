using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ExternalHospitalDefinitionConfig : IEntityTypeConfiguration<AtlasModel.ExternalHospitalDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ExternalHospitalDefinition> builder)
        {
            builder.ToTable("EXTERNALHOSPITALDEFINITION");
            builder.HasKey(nameof(AtlasModel.ExternalHospitalDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.ExternalHospitalDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ExternalHospitalDefinition.HospitalID)).HasColumnName("HOSPITALID");
            builder.Property(nameof(AtlasModel.ExternalHospitalDefinition.MedulaSiteCode)).HasColumnName("MEDULASITECODE");
            builder.Property(nameof(AtlasModel.ExternalHospitalDefinition.LinkedCityRef)).HasColumnName("LINKEDCITY").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ResSection).WithOne().HasForeignKey<AtlasModel.ResSection>(p => p.ObjectId);
        }
    }
}