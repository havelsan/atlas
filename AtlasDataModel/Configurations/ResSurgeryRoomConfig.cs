using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResSurgeryRoomConfig : IEntityTypeConfiguration<AtlasModel.ResSurgeryRoom>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResSurgeryRoom> builder)
        {
            builder.ToTable("RESSURGERYROOM");
            builder.HasKey(nameof(AtlasModel.ResSurgeryRoom.ObjectId));
            builder.Property(nameof(AtlasModel.ResSurgeryRoom.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResSurgeryRoom.SurgeryDepartmentRef)).HasColumnName("SURGERYDEPARTMENT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ResSection).WithOne().HasForeignKey<AtlasModel.ResSection>(p => p.ObjectId);
        }
    }
}