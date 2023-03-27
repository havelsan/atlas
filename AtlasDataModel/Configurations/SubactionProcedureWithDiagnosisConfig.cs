using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SubactionProcedureWithDiagnosisConfig : IEntityTypeConfiguration<AtlasModel.SubactionProcedureWithDiagnosis>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SubactionProcedureWithDiagnosis> builder)
        {
            builder.ToTable("SUBACTIONPROCWITHDIAG");
            builder.HasKey(nameof(AtlasModel.SubactionProcedureWithDiagnosis.ObjectId));
            builder.Property(nameof(AtlasModel.SubactionProcedureWithDiagnosis.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.SubactionProcedureFlowable).WithOne().HasForeignKey<AtlasModel.SubactionProcedureFlowable>(p => p.ObjectId);
        }
    }
}