using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EmergencyPatientStatusInfoConfig : IEntityTypeConfiguration<AtlasModel.EmergencyPatientStatusInfo>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EmergencyPatientStatusInfo> builder)
        {
            builder.ToTable("EMERGENCYPATIENTSTATUSINFO");
            builder.HasKey(nameof(AtlasModel.EmergencyPatientStatusInfo.ObjectId));
            builder.Property(nameof(AtlasModel.EmergencyPatientStatusInfo.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.EmergencyPatientStatusInfo.PatientStatus)).HasColumnName("PATIENTSTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.EmergencyPatientStatusInfo.LastUpdateTime)).HasColumnName("LASTUPDATETIME");
        }
    }
}