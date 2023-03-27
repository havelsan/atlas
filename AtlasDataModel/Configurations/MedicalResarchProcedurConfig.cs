using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedicalResarchProcedurConfig : IEntityTypeConfiguration<AtlasModel.MedicalResarchProcedur>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedicalResarchProcedur> builder)
        {
            builder.ToTable("MEDICALRESARCHPROCEDUR");
            builder.HasKey(nameof(AtlasModel.MedicalResarchProcedur.ObjectId));
            builder.Property(nameof(AtlasModel.MedicalResarchProcedur.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MedicalResarchProcedur.ProcedureDefinitionRef)).HasColumnName("PROCEDUREDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalResarchProcedur.MedicalResarchRef)).HasColumnName("MEDICALRESARCH").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ProcedureDefinition).WithOne().HasForeignKey<AtlasModel.MedicalResarchProcedur>(x => x.ProcedureDefinitionRef).IsRequired(false);
            builder.HasOne(t => t.MedicalResarch).WithOne().HasForeignKey<AtlasModel.MedicalResarchProcedur>(x => x.MedicalResarchRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}