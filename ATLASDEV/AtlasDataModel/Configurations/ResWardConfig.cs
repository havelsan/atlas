using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResWardConfig : IEntityTypeConfiguration<AtlasModel.ResWard>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResWard> builder)
        {
            builder.ToTable("RESWARD");
            builder.HasKey(nameof(AtlasModel.ResWard.ObjectId));
            builder.Property(nameof(AtlasModel.ResWard.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResWard.PercentageOfEmptyBedFor112)).HasColumnName("PERCENTAGEOFEMPTYBEDFOR112");
            builder.Property(nameof(AtlasModel.ResWard.Floor)).HasColumnName("FLOOR").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.ResWard.IsIntensiveCare)).HasColumnName("ISINTENSIVECARE");
            builder.Property(nameof(AtlasModel.ResWard.BedProcedureType)).HasColumnName("BEDPROCEDURETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ResWard.HospitalRef)).HasColumnName("HOSPITAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ResWard.Res112ClinicDefRef)).HasColumnName("RES112CLINICDEF").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ResSection).WithOne().HasForeignKey<AtlasModel.ResSection>(p => p.ObjectId);
        }
    }
}