using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedicalInformationConfig : IEntityTypeConfiguration<AtlasModel.MedicalInformation>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedicalInformation> builder)
        {
            builder.ToTable("MEDICALINFORMATION");
            builder.HasKey(nameof(AtlasModel.MedicalInformation.ObjectId));
            builder.Property(nameof(AtlasModel.MedicalInformation.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MedicalInformation.HasAllergy)).HasColumnName("HASALLERGY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.MedicalInformation.OtherInformation)).HasColumnName("OTHERINFORMATION").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.MedicalInformation.Transplantation)).HasColumnName("TRANSPLANTATION").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.MedicalInformation.OncologicFollowUp)).HasColumnName("ONCOLOGICFOLLOWUP").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.MedicalInformation.Implant)).HasColumnName("IMPLANT").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.MedicalInformation.Hemodialysis)).HasColumnName("HEMODIALYSIS").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.MedicalInformation.Pregnancy)).HasColumnName("PREGNANCY");
            builder.Property(nameof(AtlasModel.MedicalInformation.ChronicDiseases)).HasColumnName("CHRONICDISEASES").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.MedicalInformation.HasContagiousDisease)).HasColumnName("HASCONTAGIOUSDISEASE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.MedicalInformation.ContagiousDisease)).HasColumnName("CONTAGIOUSDISEASE").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.MedicalInformation.CardiacPacemaker)).HasColumnName("CARDIACPACEMAKER");
            builder.Property(nameof(AtlasModel.MedicalInformation.HeartFailure)).HasColumnName("HEARTFAILURE");
            builder.Property(nameof(AtlasModel.MedicalInformation.Broken)).HasColumnName("BROKEN");
            builder.Property(nameof(AtlasModel.MedicalInformation.Diabetes)).HasColumnName("DIABETES");
            builder.Property(nameof(AtlasModel.MedicalInformation.Malignancy)).HasColumnName("MALIGNANCY");
            builder.Property(nameof(AtlasModel.MedicalInformation.MetalImplant)).HasColumnName("METALIMPLANT");
            builder.Property(nameof(AtlasModel.MedicalInformation.VascularDisorder)).HasColumnName("VASCULARDISORDER");
            builder.Property(nameof(AtlasModel.MedicalInformation.Infection)).HasColumnName("INFECTION");
            builder.Property(nameof(AtlasModel.MedicalInformation.Stent)).HasColumnName("STENT");
            builder.Property(nameof(AtlasModel.MedicalInformation.Other)).HasColumnName("OTHER");
            builder.Property(nameof(AtlasModel.MedicalInformation.Advers)).HasColumnName("ADVERS");
            builder.Property(nameof(AtlasModel.MedicalInformation.MedicalInfoAllergiesRef)).HasColumnName("MEDICALINFOALLERGIES").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalInformation.MedicalInfoHabitsRef)).HasColumnName("MEDICALINFOHABITS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MedicalInformation.MedicalInfoDisabledGroupRef)).HasColumnName("MEDICALINFODISABLEDGROUP").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.MedicalInfoAllergies).WithOne().HasForeignKey<AtlasModel.MedicalInformation>(x => x.MedicalInfoAllergiesRef).IsRequired(false);
            builder.HasOne(t => t.MedicalInfoHabits).WithOne().HasForeignKey<AtlasModel.MedicalInformation>(x => x.MedicalInfoHabitsRef).IsRequired(false);
            builder.HasOne(t => t.MedicalInfoDisabledGroup).WithOne().HasForeignKey<AtlasModel.MedicalInformation>(x => x.MedicalInfoDisabledGroupRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}