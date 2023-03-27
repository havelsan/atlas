using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResRoomConfig : IEntityTypeConfiguration<AtlasModel.ResRoom>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResRoom> builder)
        {
            builder.ToTable("RESROOM");
            builder.HasKey(nameof(AtlasModel.ResRoom.ObjectId));
            builder.Property(nameof(AtlasModel.ResRoom.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResRoom.RoomGroupRef)).HasColumnName("ROOMGROUP").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ResSection).WithOne().HasForeignKey<AtlasModel.ResSection>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.RoomGroup).WithOne().HasForeignKey<AtlasModel.ResRoom>(x => x.RoomGroupRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}