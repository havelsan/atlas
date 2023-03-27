using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResTreatmentDiagnosisUnitConfig : IEntityTypeConfiguration<AtlasModel.ResTreatmentDiagnosisUnit>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResTreatmentDiagnosisUnit> builder)
        {
            builder.ToTable("RESTREATMENTDIAGNOSISUNIT");
            builder.HasKey(nameof(AtlasModel.ResTreatmentDiagnosisUnit.ObjectId));
            builder.Property(nameof(AtlasModel.ResTreatmentDiagnosisUnit.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResTreatmentDiagnosisUnit.OpenOnSaturday)).HasColumnName("OPENONSATURDAY");
            builder.Property(nameof(AtlasModel.ResTreatmentDiagnosisUnit.OpenOnSunday)).HasColumnName("OPENONSUNDAY");
            builder.Property(nameof(AtlasModel.ResTreatmentDiagnosisUnit.OpenOnTuesday)).HasColumnName("OPENONTUESDAY");
            builder.Property(nameof(AtlasModel.ResTreatmentDiagnosisUnit.OpenOnWednesday)).HasColumnName("OPENONWEDNESDAY");
            builder.Property(nameof(AtlasModel.ResTreatmentDiagnosisUnit.OpenOnFriday)).HasColumnName("OPENONFRIDAY");
            builder.Property(nameof(AtlasModel.ResTreatmentDiagnosisUnit.OpenOnMonday)).HasColumnName("OPENONMONDAY");
            builder.Property(nameof(AtlasModel.ResTreatmentDiagnosisUnit.OpenOnThursday)).HasColumnName("OPENONTHURSDAY");
            builder.Property(nameof(AtlasModel.ResTreatmentDiagnosisUnit.DepartmentRef)).HasColumnName("DEPARTMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ResTreatmentDiagnosisUnit.HospitalRef)).HasColumnName("HOSPITAL").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ResSection).WithOne().HasForeignKey<AtlasModel.ResSection>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Department).WithOne().HasForeignKey<AtlasModel.ResTreatmentDiagnosisUnit>(x => x.DepartmentRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}