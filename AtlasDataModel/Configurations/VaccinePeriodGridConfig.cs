using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class VaccinePeriodGridConfig : IEntityTypeConfiguration<AtlasModel.VaccinePeriodGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.VaccinePeriodGrid> builder)
        {
            builder.ToTable("VACCINEPERIODGRID");
            builder.HasKey(nameof(AtlasModel.VaccinePeriodGrid.ObjectId));
            builder.Property(nameof(AtlasModel.VaccinePeriodGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.VaccinePeriodGrid.PeriodDescription)).HasColumnName("PERIODDESCRIPTION");
            builder.Property(nameof(AtlasModel.VaccinePeriodGrid.Period)).HasColumnName("PERIOD");
            builder.Property(nameof(AtlasModel.VaccinePeriodGrid.PeriodType)).HasColumnName("PERIODTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.VaccinePeriodGrid.PeriodNumber)).HasColumnName("PERIODNUMBER");
            builder.Property(nameof(AtlasModel.VaccinePeriodGrid.VaccineDefinitionRef)).HasColumnName("VACCINEDEFINITION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.VaccineDefinition).WithOne().HasForeignKey<AtlasModel.VaccinePeriodGrid>(x => x.VaccineDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}