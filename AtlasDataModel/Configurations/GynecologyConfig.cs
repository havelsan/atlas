using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class GynecologyConfig : IEntityTypeConfiguration<AtlasModel.Gynecology>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Gynecology> builder)
        {
            builder.ToTable("GYNECOLOGY");
            builder.HasKey(nameof(AtlasModel.Gynecology.ObjectId));
            builder.Property(nameof(AtlasModel.Gynecology.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Gynecology.MenstrualCycleAbnormalities)).HasColumnName("MENSTRUALCYCLEABNORMALITIES").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Gynecology.MenstrualCycleInformation)).HasColumnName("MENSTRUALCYCLEINFORMATION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Gynecology.GenitalExamination)).HasColumnName("GENITALEXAMINATION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Gynecology.PelvicExamination)).HasColumnName("PELVICEXAMINATION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Gynecology.VulvaVagen)).HasColumnName("VULVAVAGEN").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Gynecology.Cervix)).HasColumnName("CERVIX").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Gynecology.Uterus)).HasColumnName("UTERUS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Gynecology.ReproductiveAbnormalitiesInfo)).HasColumnName("REPRODUCTIVEABNORMALITIESINFO").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Gynecology.GynecologicalHistory)).HasColumnName("GYNECOLOGICALHISTORY").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Gynecology.BasalUltrasound)).HasColumnName("BASALULTRASOUND").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Gynecology.TumorMarkers)).HasColumnName("TUMORMARKERS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Gynecology.LastExaminationDate)).HasColumnName("LASTEXAMINATIONDATE");
            builder.Property(nameof(AtlasModel.Gynecology.LastSmearDate)).HasColumnName("LASTSMEARDATE");
            builder.Property(nameof(AtlasModel.Gynecology.PreviousBirthControlMethod)).HasColumnName("PREVIOUSBIRTHCONTROLMETHOD").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Gynecology.CurrentBirthControlMethod)).HasColumnName("CURRENTBIRTHCONTROLMETHOD").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Gynecology.VaginalDischarge)).HasColumnName("VAGINALDISCHARGE");
            builder.Property(nameof(AtlasModel.Gynecology.GenitalAbnormalities)).HasColumnName("GENITALABNORMALITIES").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Gynecology.GenitalAbnormalitiesInfo)).HasColumnName("GENITALABNORMALITIESINFO").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Gynecology.Dysuria)).HasColumnName("DYSURIA");
            builder.Property(nameof(AtlasModel.Gynecology.DysuriaInformation)).HasColumnName("DYSURIAINFORMATION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Gynecology.Dyspareunia)).HasColumnName("DYSPAREUNIA");
            builder.Property(nameof(AtlasModel.Gynecology.DyspareuniaInformation)).HasColumnName("DYSPAREUNIAINFORMATION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Gynecology.Hirsutism)).HasColumnName("HIRSUTISM");
            builder.Property(nameof(AtlasModel.Gynecology.HirsutismInformation)).HasColumnName("HIRSUTISMINFORMATION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Gynecology.VaginalDischargeInformation)).HasColumnName("VAGINALDISCHARGEINFORMATION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Gynecology.ReproductiveAbnormalityRef)).HasColumnName("REPRODUCTIVEABNORMALITY").HasMaxLength(36).IsFixedLength();
        }
    }
}