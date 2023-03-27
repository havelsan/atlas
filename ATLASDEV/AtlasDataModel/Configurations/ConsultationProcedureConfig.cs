using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ConsultationProcedureConfig : IEntityTypeConfiguration<AtlasModel.ConsultationProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ConsultationProcedure> builder)
        {
            builder.ToTable("CONSULTATIONPROCEDURE");
            builder.HasKey(nameof(AtlasModel.ConsultationProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.ConsultationProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);
        }
    }
}