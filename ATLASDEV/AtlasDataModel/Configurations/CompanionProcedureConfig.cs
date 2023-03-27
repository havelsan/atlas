using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class CompanionProcedureConfig : IEntityTypeConfiguration<AtlasModel.CompanionProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.CompanionProcedure> builder)
        {
            builder.ToTable("COMPANIONPROCEDURE");
            builder.HasKey(nameof(AtlasModel.CompanionProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.CompanionProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);
        }
    }
}