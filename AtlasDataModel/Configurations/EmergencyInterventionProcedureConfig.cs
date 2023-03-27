using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EmergencyInterventionProcedureConfig : IEntityTypeConfiguration<AtlasModel.EmergencyInterventionProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EmergencyInterventionProcedure> builder)
        {
            builder.ToTable("EMERINTERPROCEDURE");
            builder.HasKey(nameof(AtlasModel.EmergencyInterventionProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.EmergencyInterventionProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);
        }
    }
}