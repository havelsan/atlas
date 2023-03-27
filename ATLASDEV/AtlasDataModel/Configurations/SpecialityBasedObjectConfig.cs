using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SpecialityBasedObjectConfig : IEntityTypeConfiguration<AtlasModel.SpecialityBasedObject>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SpecialityBasedObject> builder)
        {
            builder.ToTable("SPECIALITYBASEDOBJECT");
            builder.HasKey(nameof(AtlasModel.SpecialityBasedObject.ObjectId));
            builder.Property(nameof(AtlasModel.SpecialityBasedObject.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SpecialityBasedObject.PhysicianApplicationRef)).HasColumnName("PHYSICIANAPPLICATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SpecialityBasedObject.OldPhysicianApplicationRef)).HasColumnName("OLDPHYSICIANAPPLICATION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.PhysicianApplication).WithOne().HasForeignKey<AtlasModel.SpecialityBasedObject>(x => x.PhysicianApplicationRef).IsRequired(false);
            builder.HasOne(t => t.OldPhysicianApplication).WithOne().HasForeignKey<AtlasModel.SpecialityBasedObject>(x => x.OldPhysicianApplicationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}