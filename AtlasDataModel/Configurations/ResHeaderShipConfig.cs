using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResHeaderShipConfig : IEntityTypeConfiguration<AtlasModel.ResHeaderShip>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResHeaderShip> builder)
        {
            builder.ToTable("RESHEADERSHIP");
            builder.HasKey(nameof(AtlasModel.ResHeaderShip.ObjectId));
            builder.Property(nameof(AtlasModel.ResHeaderShip.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResHeaderShip.HospitalRef)).HasColumnName("HOSPITAL").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ResSection).WithOne().HasForeignKey<AtlasModel.ResSection>(p => p.ObjectId);
        }
    }
}