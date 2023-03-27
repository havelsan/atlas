using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResRoomGroupConfig : IEntityTypeConfiguration<AtlasModel.ResRoomGroup>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResRoomGroup> builder)
        {
            builder.ToTable("RESROOMGROUP");
            builder.HasKey(nameof(AtlasModel.ResRoomGroup.ObjectId));
            builder.Property(nameof(AtlasModel.ResRoomGroup.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResRoomGroup.WardRef)).HasColumnName("WARD").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ResSection).WithOne().HasForeignKey<AtlasModel.ResSection>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Ward).WithOne().HasForeignKey<AtlasModel.ResRoomGroup>(x => x.WardRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}