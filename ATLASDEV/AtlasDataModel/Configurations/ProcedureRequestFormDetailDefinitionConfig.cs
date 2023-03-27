using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ProcedureRequestFormDetailDefinitionConfig : IEntityTypeConfiguration<AtlasModel.ProcedureRequestFormDetailDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ProcedureRequestFormDetailDefinition> builder)
        {
            builder.ToTable("PROCEDUREREQFORMDETAILDEF");
            builder.HasKey(nameof(AtlasModel.ProcedureRequestFormDetailDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.ProcedureRequestFormDetailDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ProcedureRequestFormDetailDefinition.OrderNo)).HasColumnName("ORDERNO");
            builder.Property(nameof(AtlasModel.ProcedureRequestFormDetailDefinition.ObservationUnitRef)).HasColumnName("OBSERVATIONUNIT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ProcedureRequestFormDetailDefinition.ProcedureDefinitionRef)).HasColumnName("PROCEDUREDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ProcedureRequestFormDetailDefinition.ProcedureRequestCategoryRef)).HasColumnName("PROCEDUREREQUESTCATEGORY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ProcedureRequestFormDetailDefinition.PatientAdmissionResSectionRef)).HasColumnName("PATIENTADMISSIONRESSECTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ObservationUnit).WithOne().HasForeignKey<AtlasModel.ProcedureRequestFormDetailDefinition>(x => x.ObservationUnitRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureDefinition).WithOne().HasForeignKey<AtlasModel.ProcedureRequestFormDetailDefinition>(x => x.ProcedureDefinitionRef).IsRequired(true);
            builder.HasOne(t => t.ProcedureRequestCategory).WithOne().HasForeignKey<AtlasModel.ProcedureRequestFormDetailDefinition>(x => x.ProcedureRequestCategoryRef).IsRequired(true);
            builder.HasOne(t => t.PatientAdmissionResSection).WithOne().HasForeignKey<AtlasModel.ProcedureRequestFormDetailDefinition>(x => x.PatientAdmissionResSectionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}