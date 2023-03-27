using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DiagnosisDefTeshisConfig : IEntityTypeConfiguration<AtlasModel.DiagnosisDefTeshis>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DiagnosisDefTeshis> builder)
        {
            builder.ToTable("DIAGNOSISDEFTESHIS");
            builder.HasKey(nameof(AtlasModel.DiagnosisDefTeshis.ObjectId));
            builder.Property(nameof(AtlasModel.DiagnosisDefTeshis.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DiagnosisDefTeshis.TeshisRef)).HasColumnName("TESHIS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DiagnosisDefTeshis.DiagnosisDefinitionRef)).HasColumnName("DIAGNOSISDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.DiagnosisDefinition).WithOne().HasForeignKey<AtlasModel.DiagnosisDefTeshis>(x => x.DiagnosisDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}