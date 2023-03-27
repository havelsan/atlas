using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SurgeryDefinitionConfig : IEntityTypeConfiguration<AtlasModel.SurgeryDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SurgeryDefinition> builder)
        {
            builder.ToTable("SURGERYDEFINITION");
            builder.HasKey(nameof(AtlasModel.SurgeryDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.SurgeryDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SurgeryDefinition.SurgeryPointGroup)).HasColumnName("SURGERYPOINTGROUP").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SurgeryDefinition.SUTGroup)).HasColumnName("SUTGROUP").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SurgeryDefinition.InVitroFertilizationProcess)).HasColumnName("INVITROFERTILIZATIONPROCESS");
            builder.Property(nameof(AtlasModel.SurgeryDefinition.ReportIsRequired)).HasColumnName("REPORTISREQUIRED");
            builder.Property(nameof(AtlasModel.SurgeryDefinition.SurgeryProcedureType)).HasColumnName("SURGERYPROCEDURETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SurgeryDefinition.GILGroup)).HasColumnName("GILGROUP").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SurgeryDefinition.PhysiotherapyFormName)).HasColumnName("PHYSIOTHERAPYFORMNAME").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SurgeryDefinition.ManipulationFormName)).HasColumnName("MANIPULATIONFORMNAME").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SurgeryDefinition.IsDescriptionNeeded_1)).HasColumnName("ISDESCRIPTIONNEEDED_1");
            builder.Property(nameof(AtlasModel.SurgeryDefinition.IsNeedEuroScore)).HasColumnName("ISNEEDEUROSCORE");
            builder.Property(nameof(AtlasModel.SurgeryDefinition.ManipulationStartState)).HasColumnName("MANIPULATIONSTARTSTATE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SurgeryDefinition.IsSurgery)).HasColumnName("ISSURGERY");
            builder.Property(nameof(AtlasModel.SurgeryDefinition.IsManipulation)).HasColumnName("ISMANIPULATION");
            builder.Property(nameof(AtlasModel.SurgeryDefinition.IsAdditionalApplication)).HasColumnName("ISADDITIONALAPPLICATION");
            builder.Property(nameof(AtlasModel.SurgeryDefinition.ResourceRef)).HasColumnName("RESOURCE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ProcedureDefinition).WithOne().HasForeignKey<AtlasModel.ProcedureDefinition>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Resource).WithOne().HasForeignKey<AtlasModel.SurgeryDefinition>(x => x.ResourceRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}