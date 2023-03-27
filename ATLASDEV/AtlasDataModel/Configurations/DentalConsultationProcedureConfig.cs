using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DentalConsultationProcedureConfig : IEntityTypeConfiguration<AtlasModel.DentalConsultationProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DentalConsultationProcedure> builder)
        {
            builder.ToTable("DENTALCONSPROCEDURE");
            builder.HasKey(nameof(AtlasModel.DentalConsultationProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.DentalConsultationProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);
        }
    }
}