using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PhysiotherapyTreatmentUnitGridConfig : IEntityTypeConfiguration<AtlasModel.PhysiotherapyTreatmentUnitGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PhysiotherapyTreatmentUnitGrid> builder)
        {
            builder.ToTable("PHYSIOTHERAPYTREATUNITGRD");
            builder.HasKey(nameof(AtlasModel.PhysiotherapyTreatmentUnitGrid.ObjectId));
            builder.Property(nameof(AtlasModel.PhysiotherapyTreatmentUnitGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PhysiotherapyTreatmentUnitGrid.PhysiotherapyDefinitionRef)).HasColumnName("PHYSIOTHERAPYDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysiotherapyTreatmentUnitGrid.TreatmentDiagnosisUnitRef)).HasColumnName("TREATMENTDIAGNOSISUNIT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.PhysiotherapyDefinition).WithOne().HasForeignKey<AtlasModel.PhysiotherapyTreatmentUnitGrid>(x => x.PhysiotherapyDefinitionRef).IsRequired(false);
            builder.HasOne(t => t.TreatmentDiagnosisUnit).WithOne().HasForeignKey<AtlasModel.PhysiotherapyTreatmentUnitGrid>(x => x.TreatmentDiagnosisUnitRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}