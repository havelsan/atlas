using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseAnesthesiaPersonnelConfig : IEntityTypeConfiguration<AtlasModel.BaseAnesthesiaPersonnel>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseAnesthesiaPersonnel> builder)
        {
            builder.ToTable("BASEANESTHESIAPERSONNEL");
            builder.HasKey(nameof(AtlasModel.BaseAnesthesiaPersonnel.ObjectId));
            builder.Property(nameof(AtlasModel.BaseAnesthesiaPersonnel.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseAnesthesiaPersonnel.AnesthesiaPersonnelRef)).HasColumnName("ANESTHESIAPERSONNEL").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.AnesthesiaPersonnel).WithOne().HasForeignKey<AtlasModel.BaseAnesthesiaPersonnel>(x => x.AnesthesiaPersonnelRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}