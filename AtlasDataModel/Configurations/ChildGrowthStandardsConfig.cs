using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ChildGrowthStandardsConfig : IEntityTypeConfiguration<AtlasModel.ChildGrowthStandards>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ChildGrowthStandards> builder)
        {
            builder.ToTable("CHILDGROWTHSTANDARDS");
            builder.HasKey(nameof(AtlasModel.ChildGrowthStandards.ObjectId));
            builder.Property(nameof(AtlasModel.ChildGrowthStandards.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ChildGrowthStandards.PatientExaminationRef)).HasColumnName("PATIENTEXAMINATION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SpecialityBasedObject).WithOne().HasForeignKey<AtlasModel.SpecialityBasedObject>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.PatientExamination).WithOne().HasForeignKey<AtlasModel.ChildGrowthStandards>(x => x.PatientExaminationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}