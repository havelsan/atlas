using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class HospitalsUnitsDefinitionGridConfig : IEntityTypeConfiguration<AtlasModel.HospitalsUnitsDefinitionGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.HospitalsUnitsDefinitionGrid> builder)
        {
            builder.ToTable("HOSPITALSUNITSDEFGRD");
            builder.HasKey(nameof(AtlasModel.HospitalsUnitsDefinitionGrid.ObjectId));
            builder.Property(nameof(AtlasModel.HospitalsUnitsDefinitionGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.HospitalsUnitsDefinitionGrid.Sex)).HasColumnName("SEX").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.HospitalsUnitsDefinitionGrid.TemplateDescription)).HasColumnName("TEMPLATEDESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.HospitalsUnitsDefinitionGrid.MaxOld)).HasColumnName("MAXOLD");
            builder.Property(nameof(AtlasModel.HospitalsUnitsDefinitionGrid.MinOld)).HasColumnName("MINOLD");
            builder.Property(nameof(AtlasModel.HospitalsUnitsDefinitionGrid.TemplateRef)).HasColumnName("TEMPLATE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HospitalsUnitsDefinitionGrid.ReasonForExaminationDefRef)).HasColumnName("REASONFOREXAMINATIONDEF").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HospitalsUnitsDefinitionGrid.PolicklinicRef)).HasColumnName("POLICKLINIC").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HospitalsUnitsDefinitionGrid.ProcedureDoctorRef)).HasColumnName("PROCEDUREDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HospitalsUnitsDefinitionGrid.EpisodeActionTemplateRef)).HasColumnName("EPISODEACTIONTEMPLATE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.HospitalsUnitsDefinitionGrid.SpecialityRef)).HasColumnName("SPECIALITY").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ReasonForExaminationDef).WithOne().HasForeignKey<AtlasModel.HospitalsUnitsDefinitionGrid>(x => x.ReasonForExaminationDefRef).IsRequired(false);
            builder.HasOne(t => t.Policklinic).WithOne().HasForeignKey<AtlasModel.HospitalsUnitsDefinitionGrid>(x => x.PolicklinicRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureDoctor).WithOne().HasForeignKey<AtlasModel.HospitalsUnitsDefinitionGrid>(x => x.ProcedureDoctorRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}