using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PhysiotherapyDefinitionConfig : IEntityTypeConfiguration<AtlasModel.PhysiotherapyDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PhysiotherapyDefinition> builder)
        {
            builder.ToTable("PHYSIOTHERAPYDEFINITION");
            builder.HasKey(nameof(AtlasModel.PhysiotherapyDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.PhysiotherapyDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PhysiotherapyDefinition.TreatmentDuration)).HasColumnName("TREATMENTDURATION");
            builder.Property(nameof(AtlasModel.PhysiotherapyDefinition.ExaminationSubClass)).HasColumnName("EXAMINATIONSUBCLASS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PhysiotherapyDefinition.OrderNo)).HasColumnName("ORDERNO");
            builder.Property(nameof(AtlasModel.PhysiotherapyDefinition.ESWTTransaction)).HasColumnName("ESWTTRANSACTION");
            builder.HasOne(t => t.ProcedureDefinition).WithOne().HasForeignKey<AtlasModel.ProcedureDefinition>(p => p.ObjectId);
        }
    }
}