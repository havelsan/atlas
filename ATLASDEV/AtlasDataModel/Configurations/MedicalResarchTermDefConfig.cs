using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedicalResarchTermDefConfig : IEntityTypeConfiguration<AtlasModel.MedicalResarchTermDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedicalResarchTermDef> builder)
        {
            builder.ToTable("MEDICALRESARCHTERMDEF");
            builder.HasKey(nameof(AtlasModel.MedicalResarchTermDef.ObjectId));
            builder.Property(nameof(AtlasModel.MedicalResarchTermDef.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MedicalResarchTermDef.TermName)).HasColumnName("TERMNAME").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.MedicalResarchTermDef.StartDate)).HasColumnName("STARTDATE");
            builder.Property(nameof(AtlasModel.MedicalResarchTermDef.EndDate)).HasColumnName("ENDDATE");
            builder.Property(nameof(AtlasModel.MedicalResarchTermDef.TermCode)).HasColumnName("TERMCODE").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.MedicalResarchTermDef.TermBudgetPrice)).HasColumnName("TERMBUDGETPRICE").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.MedicalResarchTermDef.Desciption)).HasColumnName("DESCIPTION").HasColumnType("VARCHAR2(4000)");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}