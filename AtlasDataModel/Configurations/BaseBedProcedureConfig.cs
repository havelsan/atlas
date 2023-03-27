using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseBedProcedureConfig : IEntityTypeConfiguration<AtlasModel.BaseBedProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseBedProcedure> builder)
        {
            builder.ToTable("BASEBEDPROCEDURE");
            builder.HasKey(nameof(AtlasModel.BaseBedProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.BaseBedProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseBedProcedure.IsLast)).HasColumnName("ISLAST");
            builder.Property(nameof(AtlasModel.BaseBedProcedure.BedDischargeDate)).HasColumnName("BEDDISCHARGEDATE");
            builder.Property(nameof(AtlasModel.BaseBedProcedure.BedInPatientDate)).HasColumnName("BEDINPATIENTDATE");
            builder.Property(nameof(AtlasModel.BaseBedProcedure.UsedStatus)).HasColumnName("USEDSTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.BaseBedProcedure.DrAnesteziTescilNo)).HasColumnName("DRANESTEZITESCILNO");
            builder.Property(nameof(AtlasModel.BaseBedProcedure.Aciklama)).HasColumnName("ACIKLAMA");
            builder.Property(nameof(AtlasModel.BaseBedProcedure.IsNewPricingType)).HasColumnName("ISNEWPRICINGTYPE");
            builder.Property(nameof(AtlasModel.BaseBedProcedure.RoomRef)).HasColumnName("ROOM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseBedProcedure.RoomGroupRef)).HasColumnName("ROOMGROUP").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseBedProcedure.BedRef)).HasColumnName("BED").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseBedProcedure.ClinicRef)).HasColumnName("CLINIC").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseBedProcedure.OzelDurumRef)).HasColumnName("OZELDURUM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseBedProcedure.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseBedProcedure.BaseInpatientAdmissionRef)).HasColumnName("BASEINPATIENTADMISSION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BedProcedureWithoutBed).WithOne().HasForeignKey<AtlasModel.BedProcedureWithoutBed>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Room).WithOne().HasForeignKey<AtlasModel.BaseBedProcedure>(x => x.RoomRef).IsRequired(false);
            builder.HasOne(t => t.RoomGroup).WithOne().HasForeignKey<AtlasModel.BaseBedProcedure>(x => x.RoomGroupRef).IsRequired(false);
            builder.HasOne(t => t.Bed).WithOne().HasForeignKey<AtlasModel.BaseBedProcedure>(x => x.BedRef).IsRequired(true);
            builder.HasOne(t => t.Clinic).WithOne().HasForeignKey<AtlasModel.BaseBedProcedure>(x => x.ClinicRef).IsRequired(false);
            builder.HasOne(t => t.OzelDurum).WithOne().HasForeignKey<AtlasModel.BaseBedProcedure>(x => x.OzelDurumRef).IsRequired(false);
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.BaseBedProcedure>(x => x.ResUserRef).IsRequired(false);
            builder.HasOne(t => t.BaseInpatientAdmission).WithOne().HasForeignKey<AtlasModel.BaseBedProcedure>(x => x.BaseInpatientAdmissionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}