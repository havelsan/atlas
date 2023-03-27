using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AnesthesiaConsultationProcedureConfig : IEntityTypeConfiguration<AtlasModel.AnesthesiaConsultationProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AnesthesiaConsultationProcedure> builder)
        {
            builder.ToTable("ANESTHESIACONSPROCEDURE");
            builder.HasKey(nameof(AtlasModel.AnesthesiaConsultationProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.AnesthesiaConsultationProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);
        }
    }
}