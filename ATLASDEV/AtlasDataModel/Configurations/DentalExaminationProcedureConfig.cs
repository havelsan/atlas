using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DentalExaminationProcedureConfig : IEntityTypeConfiguration<AtlasModel.DentalExaminationProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DentalExaminationProcedure> builder)
        {
            builder.ToTable("DENTALEXAMINATIONPROCEDURE");
            builder.HasKey(nameof(AtlasModel.DentalExaminationProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.DentalExaminationProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);
        }
    }
}