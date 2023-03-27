using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientLastUseDrugConfig : IEntityTypeConfiguration<AtlasModel.PatientLastUseDrug>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientLastUseDrug> builder)
        {
            builder.ToTable("PATIENTLASTUSEDRUG");
            builder.HasKey(nameof(AtlasModel.PatientLastUseDrug.ObjectId));
            builder.Property(nameof(AtlasModel.PatientLastUseDrug.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PatientLastUseDrug.Amount)).HasColumnName("AMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.PatientLastUseDrug.MaterialRef)).HasColumnName("MATERIAL").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Material).WithOne().HasForeignKey<AtlasModel.PatientLastUseDrug>(x => x.MaterialRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}