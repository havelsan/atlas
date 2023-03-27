using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PackageTemplateICDDetailDefinitionConfig : IEntityTypeConfiguration<AtlasModel.PackageTemplateICDDetailDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PackageTemplateICDDetailDefinition> builder)
        {
            builder.ToTable("PACKAGETEMPICDDETAILDEF");
            builder.HasKey(nameof(AtlasModel.PackageTemplateICDDetailDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.PackageTemplateICDDetailDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PackageTemplateICDDetailDefinition.DiagnosisDefinition)).HasColumnName("DIAGNOSISDEFINITION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.PackageTemplateICDDetailDefinition.FreeDiagnosis)).HasColumnName("FREEDIAGNOSIS").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.PackageTemplateICDDetailDefinition.IsMainDiagnose)).HasColumnName("ISMAINDIAGNOSE");
            builder.Property(nameof(AtlasModel.PackageTemplateICDDetailDefinition.DiagnosisType)).HasColumnName("DIAGNOSISTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PackageTemplateICDDetailDefinition.TaniKodu)).HasColumnName("TANIKODU");
            builder.Property(nameof(AtlasModel.PackageTemplateICDDetailDefinition.PackageTemplateDefinitionRef)).HasColumnName("PACKAGETEMPLATEDEFINITION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.PackageTemplateDefinition).WithOne().HasForeignKey<AtlasModel.PackageTemplateICDDetailDefinition>(x => x.PackageTemplateDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}