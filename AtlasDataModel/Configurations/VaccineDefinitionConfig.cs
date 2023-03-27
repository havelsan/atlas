using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class VaccineDefinitionConfig : IEntityTypeConfiguration<AtlasModel.VaccineDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.VaccineDefinition> builder)
        {
            builder.ToTable("VACCINEDEFINITION");
            builder.HasKey(nameof(AtlasModel.VaccineDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.VaccineDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.VaccineDefinition.PeriodCriterion)).HasColumnName("PERIODCRITERION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.VaccineDefinition.Code)).HasColumnName("CODE");
            builder.Property(nameof(AtlasModel.VaccineDefinition.Name)).HasColumnName("NAME");
            builder.Property(nameof(AtlasModel.VaccineDefinition.AutoAdd)).HasColumnName("AUTOADD");
            builder.Property(nameof(AtlasModel.VaccineDefinition.AutoAddAgeType)).HasColumnName("AUTOADDAGETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.VaccineDefinition.MaxPeriodRange)).HasColumnName("MAXPERIODRANGE");
            builder.Property(nameof(AtlasModel.VaccineDefinition.MaxPeriodRangeUnit)).HasColumnName("MAXPERIODRANGEUNIT").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.VaccineDefinition.SKRSAsiKoduRef)).HasColumnName("SKRSASIKODU").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.SKRSAsiKodu).WithOne().HasForeignKey<AtlasModel.VaccineDefinition>(x => x.SKRSAsiKoduRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}