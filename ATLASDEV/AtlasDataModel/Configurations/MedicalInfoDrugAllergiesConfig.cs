using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedicalInfoDrugAllergiesConfig : IEntityTypeConfiguration<AtlasModel.MedicalInfoDrugAllergies>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedicalInfoDrugAllergies> builder)
        {
            builder.ToTable("MEDICALINFODRUGALLERGIES");
            builder.HasKey(nameof(AtlasModel.MedicalInfoDrugAllergies.ObjectId));
            builder.Property(nameof(AtlasModel.MedicalInfoDrugAllergies.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MedicalInfoDrugAllergies.MedicalInfoAllergiesRef)).HasColumnName("MEDICALINFOALLERGIES").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalInfoDrugAllergies.ActiveIngredientRef)).HasColumnName("ACTIVEINGREDIENT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.MedicalInfoAllergies).WithOne().HasForeignKey<AtlasModel.MedicalInfoDrugAllergies>(x => x.MedicalInfoAllergiesRef).IsRequired(false);
            builder.HasOne(t => t.ActiveIngredient).WithOne().HasForeignKey<AtlasModel.MedicalInfoDrugAllergies>(x => x.ActiveIngredientRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}