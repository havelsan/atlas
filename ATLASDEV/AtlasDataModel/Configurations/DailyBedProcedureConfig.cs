using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DailyBedProcedureConfig : IEntityTypeConfiguration<AtlasModel.DailyBedProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DailyBedProcedure> builder)
        {
            builder.ToTable("DAILYBEDPROCEDURE");
            builder.HasKey(nameof(AtlasModel.DailyBedProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.DailyBedProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);
        }
    }
}