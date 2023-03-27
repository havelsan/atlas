using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedicalInfoContiniousDrugsConfig : IEntityTypeConfiguration<AtlasModel.MedicalInfoContiniousDrugs>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedicalInfoContiniousDrugs> builder)
        {
            builder.ToTable("MEDICALINFOCONTDRUGS");
            builder.HasKey(nameof(AtlasModel.MedicalInfoContiniousDrugs.ObjectId));
            builder.Property(nameof(AtlasModel.MedicalInfoContiniousDrugs.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MedicalInfoContiniousDrugs.DrugRef)).HasColumnName("DRUG").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalInfoContiniousDrugs.MedicalInformationRef)).HasColumnName("MEDICALINFORMATION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Drug).WithOne().HasForeignKey<AtlasModel.MedicalInfoContiniousDrugs>(x => x.DrugRef).IsRequired(false);
            builder.HasOne(t => t.MedicalInformation).WithOne().HasForeignKey<AtlasModel.MedicalInfoContiniousDrugs>(x => x.MedicalInformationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}