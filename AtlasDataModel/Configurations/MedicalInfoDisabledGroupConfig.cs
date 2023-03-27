using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedicalInfoDisabledGroupConfig : IEntityTypeConfiguration<AtlasModel.MedicalInfoDisabledGroup>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedicalInfoDisabledGroup> builder)
        {
            builder.ToTable("MEDICALINFODISABLEDGROUP");
            builder.HasKey(nameof(AtlasModel.MedicalInfoDisabledGroup.ObjectId));
            builder.Property(nameof(AtlasModel.MedicalInfoDisabledGroup.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MedicalInfoDisabledGroup.Orthopedic)).HasColumnName("ORTHOPEDIC");
            builder.Property(nameof(AtlasModel.MedicalInfoDisabledGroup.Vision)).HasColumnName("VISION");
            builder.Property(nameof(AtlasModel.MedicalInfoDisabledGroup.Hearing)).HasColumnName("HEARING");
            builder.Property(nameof(AtlasModel.MedicalInfoDisabledGroup.SpeechAndLanguage)).HasColumnName("SPEECHANDLANGUAGE");
            builder.Property(nameof(AtlasModel.MedicalInfoDisabledGroup.Mental)).HasColumnName("MENTAL");
            builder.Property(nameof(AtlasModel.MedicalInfoDisabledGroup.PsychicAndEmotional)).HasColumnName("PSYCHICANDEMOTIONAL");
            builder.Property(nameof(AtlasModel.MedicalInfoDisabledGroup.Chronic)).HasColumnName("CHRONIC");
            builder.Property(nameof(AtlasModel.MedicalInfoDisabledGroup.Unclassified)).HasColumnName("UNCLASSIFIED");
            builder.Property(nameof(AtlasModel.MedicalInfoDisabledGroup.Nonexistence)).HasColumnName("NONEXISTENCE");
        }
    }
}