using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResAdministrativeUnitConfig : IEntityTypeConfiguration<AtlasModel.ResAdministrativeUnit>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResAdministrativeUnit> builder)
        {
            builder.ToTable("RESADMINISTRATIVEUNIT");
            builder.HasKey(nameof(AtlasModel.ResAdministrativeUnit.ObjectId));
            builder.Property(nameof(AtlasModel.ResAdministrativeUnit.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResAdministrativeUnit.HospitalRef)).HasColumnName("HOSPITAL").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ResSection).WithOne().HasForeignKey<AtlasModel.ResSection>(p => p.ObjectId);
        }
    }
}