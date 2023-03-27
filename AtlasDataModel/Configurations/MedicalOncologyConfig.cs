using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedicalOncologyConfig : IEntityTypeConfiguration<AtlasModel.MedicalOncology>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedicalOncology> builder)
        {
            builder.ToTable("MEDICALONCOLOGY");
            builder.HasKey(nameof(AtlasModel.MedicalOncology.ObjectId));
            builder.Property(nameof(AtlasModel.MedicalOncology.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MedicalOncology.PreTreatmentStaging)).HasColumnName("PRETREATMENTSTAGING").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalOncology.InterimEvaluation)).HasColumnName("INTERIMEVALUATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalOncology.FirstLineTreatment)).HasColumnName("FIRSTLINETREATMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalOncology.SecondLineTreatment)).HasColumnName("SECONDLINETREATMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalOncology.Story)).HasColumnName("STORY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalOncology.Pathology)).HasColumnName("PATHOLOGY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalOncology.Description)).HasColumnName("DESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalOncology.PS)).HasColumnName("PS");
            builder.Property(nameof(AtlasModel.MedicalOncology.TA)).HasColumnName("TA");
            builder.Property(nameof(AtlasModel.MedicalOncology.NB)).HasColumnName("NB");
            builder.Property(nameof(AtlasModel.MedicalOncology.M2)).HasColumnName("M2");
            builder.Property(nameof(AtlasModel.MedicalOncology.Height)).HasColumnName("HEIGHT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.MedicalOncology.Weight)).HasColumnName("WEIGHT").HasColumnType("FLOAT");
            builder.HasOne(t => t.SpecialityBasedObject).WithOne().HasForeignKey<AtlasModel.SpecialityBasedObject>(p => p.ObjectId);
        }
    }
}