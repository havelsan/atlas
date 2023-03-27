using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class VitalSignAndNursingDefinitionConfig : IEntityTypeConfiguration<AtlasModel.VitalSignAndNursingDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.VitalSignAndNursingDefinition> builder)
        {
            builder.ToTable("VITALSIGNANDNURSINGDEF");
            builder.HasKey(nameof(AtlasModel.VitalSignAndNursingDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.VitalSignAndNursingDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.VitalSignAndNursingDefinition.DontNeedDataDuringApplication)).HasColumnName("DONTNEEDDATADURINGAPPLICATION");
            builder.Property(nameof(AtlasModel.VitalSignAndNursingDefinition.VitalSignType)).HasColumnName("VITALSIGNTYPE").HasColumnType("NUMBER(10)");
            builder.HasOne(t => t.ProcedureDefinition).WithOne().HasForeignKey<AtlasModel.ProcedureDefinition>(p => p.ObjectId);
        }
    }
}