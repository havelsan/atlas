using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PackageProcedureDefinitionConfig : IEntityTypeConfiguration<AtlasModel.PackageProcedureDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PackageProcedureDefinition> builder)
        {
            builder.ToTable("PACKAGEPROCEDUREDEFINITION");
            builder.HasKey(nameof(AtlasModel.PackageProcedureDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.PackageProcedureDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PackageProcedureDefinition.HolidaysIncluded)).HasColumnName("HOLIDAYSINCLUDED");
            builder.Property(nameof(AtlasModel.PackageProcedureDefinition.Type)).HasColumnName("TYPE").HasColumnType("NUMBER(10)");
            builder.HasOne(t => t.ProcedureDefinition).WithOne().HasForeignKey<AtlasModel.ProcedureDefinition>(p => p.ObjectId);
        }
    }
}