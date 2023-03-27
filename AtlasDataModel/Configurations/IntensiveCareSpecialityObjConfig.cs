using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class IntensiveCareSpecialityObjConfig : IEntityTypeConfiguration<AtlasModel.IntensiveCareSpecialityObj>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.IntensiveCareSpecialityObj> builder)
        {
            builder.ToTable("INTENSIVECARESPECIALITYOBJ");
            builder.HasKey(nameof(AtlasModel.IntensiveCareSpecialityObj.ObjectId));
            builder.Property(nameof(AtlasModel.IntensiveCareSpecialityObj.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.IntensiveCareSpecialityObj.IntensiveCareStep)).HasColumnName("INTENSIVECARESTEP").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.IntensiveCareSpecialityObj.IntensiveCareType)).HasColumnName("INTENSIVECARETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.IntensiveCareSpecialityObj.SepsisStatusRef)).HasColumnName("SEPSISSTATUS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.IntensiveCareSpecialityObj.SepticShockRef)).HasColumnName("SEPTICSHOCK").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SpecialityBasedObject).WithOne().HasForeignKey<AtlasModel.SpecialityBasedObject>(p => p.ObjectId);
        }
    }
}