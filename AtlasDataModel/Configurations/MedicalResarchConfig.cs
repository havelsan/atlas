using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedicalResarchConfig : IEntityTypeConfiguration<AtlasModel.MedicalResarch>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedicalResarch> builder)
        {
            builder.ToTable("MEDICALRESARCH");
            builder.HasKey(nameof(AtlasModel.MedicalResarch.ObjectId));
            builder.Property(nameof(AtlasModel.MedicalResarch.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MedicalResarch.Code)).HasColumnName("CODE");
            builder.Property(nameof(AtlasModel.MedicalResarch.PatientCount)).HasColumnName("PATIENTCOUNT");
            builder.Property(nameof(AtlasModel.MedicalResarch.StartDate)).HasColumnName("STARTDATE");
            builder.Property(nameof(AtlasModel.MedicalResarch.EndDate)).HasColumnName("ENDDATE");
            builder.Property(nameof(AtlasModel.MedicalResarch.Desciption)).HasColumnName("DESCIPTION").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.MedicalResarch.BudgetTotalPrice)).HasColumnName("BUDGETTOTALPRICE").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.MedicalResarch.Name)).HasColumnName("NAME").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.MedicalResarch.MedicalResarchTermDefRef)).HasColumnName("MEDICALRESARCHTERMDEF").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.MedicalResarchTermDef).WithOne().HasForeignKey<AtlasModel.MedicalResarch>(x => x.MedicalResarchTermDefRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}