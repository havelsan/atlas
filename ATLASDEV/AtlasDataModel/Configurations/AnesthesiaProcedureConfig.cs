using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AnesthesiaProcedureConfig : IEntityTypeConfiguration<AtlasModel.AnesthesiaProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AnesthesiaProcedure> builder)
        {
            builder.ToTable("ANESTHESIAPROCEDURE");
            builder.HasKey(nameof(AtlasModel.AnesthesiaProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.AnesthesiaProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseAnesthesiaProcedure).WithOne().HasForeignKey<AtlasModel.BaseAnesthesiaProcedure>(p => p.ObjectId);
        }
    }
}