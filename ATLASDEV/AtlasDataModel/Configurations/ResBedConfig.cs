using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResBedConfig : IEntityTypeConfiguration<AtlasModel.ResBed>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResBed> builder)
        {
            builder.ToTable("RESBED");
            builder.HasKey(nameof(AtlasModel.ResBed.ObjectId));
            builder.Property(nameof(AtlasModel.ResBed.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResBed.BedCodeForMedula)).HasColumnName("BEDCODEFORMEDULA").HasMaxLength(15);
            builder.Property(nameof(AtlasModel.ResBed.IsVentilator)).HasColumnName("ISVENTILATOR");
            builder.Property(nameof(AtlasModel.ResBed.OrderNo)).HasColumnName("ORDERNO");
            builder.Property(nameof(AtlasModel.ResBed.BedProcedureType)).HasColumnName("BEDPROCEDURETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ResBed.IsClean)).HasColumnName("ISCLEAN");
            builder.Property(nameof(AtlasModel.ResBed.BedProcedureRef)).HasColumnName("BEDPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ResBed.UsedByBedProcedureRef)).HasColumnName("USEDBYBEDPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ResBed.RoomRef)).HasColumnName("ROOM").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ResSection).WithOne().HasForeignKey<AtlasModel.ResSection>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.UsedByBedProcedure).WithOne().HasForeignKey<AtlasModel.ResBed>(x => x.UsedByBedProcedureRef).IsRequired(false);
            builder.HasOne(t => t.Room).WithOne().HasForeignKey<AtlasModel.ResBed>(x => x.RoomRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}