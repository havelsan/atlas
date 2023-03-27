using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingPupilSymptomsConfig : IEntityTypeConfiguration<AtlasModel.NursingPupilSymptoms>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingPupilSymptoms> builder)
        {
            builder.ToTable("NURSINGPUPILSYMPTOMS");
            builder.HasKey(nameof(AtlasModel.NursingPupilSymptoms.ObjectId));
            builder.Property(nameof(AtlasModel.NursingPupilSymptoms.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingPupilSymptoms.LeftPupil)).HasColumnName("LEFTPUPIL").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingPupilSymptoms.RightPupilWideness)).HasColumnName("RIGHTPUPILWIDENESS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingPupilSymptoms.RightPupil)).HasColumnName("RIGHTPUPIL").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingPupilSymptoms.ActionDate)).HasColumnName("ACTIONDATE");
            builder.Property(nameof(AtlasModel.NursingPupilSymptoms.LeftGleamRef)).HasColumnName("LEFTGLEAMREF").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingPupilSymptoms.RightGleamRef)).HasColumnName("RIGHTGLEAMREF").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingPupilSymptoms.LeftPupilWideness)).HasColumnName("LEFTPUPILWIDENESS").HasColumnType("NUMBER(10)");
            builder.HasOne(t => t.BaseNursingDataEntry).WithOne().HasForeignKey<AtlasModel.BaseNursingDataEntry>(p => p.ObjectId);
        }
    }
}