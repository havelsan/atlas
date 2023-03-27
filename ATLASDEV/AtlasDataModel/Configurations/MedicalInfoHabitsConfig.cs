using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedicalInfoHabitsConfig : IEntityTypeConfiguration<AtlasModel.MedicalInfoHabits>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedicalInfoHabits> builder)
        {
            builder.ToTable("MEDICALINFOHABITS");
            builder.HasKey(nameof(AtlasModel.MedicalInfoHabits.ObjectId));
            builder.Property(nameof(AtlasModel.MedicalInfoHabits.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MedicalInfoHabits.Cigarette)).HasColumnName("CIGARETTE");
            builder.Property(nameof(AtlasModel.MedicalInfoHabits.Alcohol)).HasColumnName("ALCOHOL");
            builder.Property(nameof(AtlasModel.MedicalInfoHabits.Tea)).HasColumnName("TEA");
            builder.Property(nameof(AtlasModel.MedicalInfoHabits.Coffee)).HasColumnName("COFFEE");
            builder.Property(nameof(AtlasModel.MedicalInfoHabits.Other)).HasColumnName("OTHER");
            builder.Property(nameof(AtlasModel.MedicalInfoHabits.Description)).HasColumnName("DESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.MedicalInfoHabits.Drug)).HasColumnName("DRUG");
            builder.Property(nameof(AtlasModel.MedicalInfoHabits.CigaretteUsageFrequencyRef)).HasColumnName("CIGARETTEUSAGEFREQUENCY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalInfoHabits.AlcoholUsageFrequencyRef)).HasColumnName("ALCOHOLUSAGEFREQUENCY").HasMaxLength(36).IsFixedLength();
        }
    }
}