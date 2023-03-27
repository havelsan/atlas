using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class CompanionApplicationConfig : IEntityTypeConfiguration<AtlasModel.CompanionApplication>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.CompanionApplication> builder)
        {
            builder.ToTable("COMPANIONAPPLICATIONS");
            builder.HasKey(nameof(AtlasModel.CompanionApplication.ObjectId));
            builder.Property(nameof(AtlasModel.CompanionApplication.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.CompanionApplication.CompanionAddress)).HasColumnName("COMPANIONADDRESS").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.CompanionApplication.StayingDateCount)).HasColumnName("STAYINGDATECOUNT");
            builder.Property(nameof(AtlasModel.CompanionApplication.CompanionName)).HasColumnName("COMPANIONNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.CompanionApplication.CompanionBirthDate)).HasColumnName("COMPANIONBIRTHDATE");
            builder.Property(nameof(AtlasModel.CompanionApplication.EndDate)).HasColumnName("ENDDATE");
            builder.Property(nameof(AtlasModel.CompanionApplication.MedicalReasonForCompanion)).HasColumnName("MEDICALREASONFORCOMPANION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.CompanionApplication.PassportNo)).HasColumnName("PASSPORTNO");
            builder.Property(nameof(AtlasModel.CompanionApplication.Relationship)).HasColumnName("RELATIONSHIP").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.CompanionApplication.UniqueRefNo)).HasColumnName("UNIQUEREFNO");
            builder.Property(nameof(AtlasModel.CompanionApplication.InpatientAdmissionRef)).HasColumnName("INPATIENTADMISSION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.InpatientAdmission).WithOne().HasForeignKey<AtlasModel.CompanionApplication>(x => x.InpatientAdmissionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}