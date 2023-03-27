using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AnesthesiaPersonnelConfig : IEntityTypeConfiguration<AtlasModel.AnesthesiaPersonnel>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AnesthesiaPersonnel> builder)
        {
            builder.ToTable("ANESTHESIAPERSONNEL");
            builder.HasKey(nameof(AtlasModel.AnesthesiaPersonnel.ObjectId));
            builder.Property(nameof(AtlasModel.AnesthesiaPersonnel.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AnesthesiaPersonnel.Role)).HasColumnName("ROLE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.AnesthesiaPersonnel.AnesthesiaAndReanimationRef)).HasColumnName("ANESTHESIAANDREANIMATION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseAnesthesiaPersonnel).WithOne().HasForeignKey<AtlasModel.BaseAnesthesiaPersonnel>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.AnesthesiaAndReanimation).WithOne().HasForeignKey<AtlasModel.AnesthesiaPersonnel>(x => x.AnesthesiaAndReanimationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}