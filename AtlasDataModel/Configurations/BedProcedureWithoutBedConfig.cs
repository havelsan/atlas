using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BedProcedureWithoutBedConfig : IEntityTypeConfiguration<AtlasModel.BedProcedureWithoutBed>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BedProcedureWithoutBed> builder)
        {
            builder.ToTable("BEDPROCEDUREWITHOUTBED");
            builder.HasKey(nameof(AtlasModel.BedProcedureWithoutBed.ObjectId));
            builder.Property(nameof(AtlasModel.BedProcedureWithoutBed.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);
        }
    }
}