using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SurgeryPackageProcedureConfig : IEntityTypeConfiguration<AtlasModel.SurgeryPackageProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SurgeryPackageProcedure> builder)
        {
            builder.ToTable("SURGERYPACKAGEPROCEDURE");
            builder.HasKey(nameof(AtlasModel.SurgeryPackageProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.SurgeryPackageProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SurgeryPackageProcedure.SurgeryRef)).HasColumnName("SURGERY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SurgeryPackageProcedure.PackageProcedureDefinitionRef)).HasColumnName("PACKAGEPROCEDUREDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SurgeryPackageProcedure.SurgeryProcedureRef)).HasColumnName("SURGERYPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SubActionPackageProcedure).WithOne().HasForeignKey<AtlasModel.SubActionPackageProcedure>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Surgery).WithOne().HasForeignKey<AtlasModel.SurgeryPackageProcedure>(x => x.SurgeryRef).IsRequired(false);
            builder.HasOne(t => t.PackageProcedureDefinition).WithOne().HasForeignKey<AtlasModel.SurgeryPackageProcedure>(x => x.PackageProcedureDefinitionRef).IsRequired(false);
            builder.HasOne(t => t.SurgeryProcedure).WithOne().HasForeignKey<AtlasModel.SurgeryPackageProcedure>(x => x.SurgeryProcedureRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}